using System.Threading;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Firebase.Extensions;
using Firebase.Storage;
using Microsoft.Cci;
using UnityEngine;

public static class FirebaseStorageManager
{
    public static void DownloadManifest()
    {
        StorageReference manifestRef = FirebaseStorage.DefaultInstance.GetReferenceFromUrl("gs://connected-gaming-server.appspot.com/manifest.xml");

        const long maxAllowedSizeInMegaBytes = 10 * 1024 * 1024;
        manifestRef.GetBytesAsync(maxAllowedSizeInMegaBytes).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
            }
            else 
            {
                XDocument manifest = XDocument.Parse(System.Text.Encoding.UTF8.GetString(task.Result));
                foreach (XElement element in manifest.Root.Elements())
                {
                    string nameStr = element.Element("name")?.Value;
                    string priceStr = element?.Element("value")?.Value;

                    StoreItemData storeItem = GameData.items[nameStr];
                    storeItem.name = nameStr;
                    storeItem.price = int.Parse(element?.Element("value")?.Value);
                    storeItem.url = element?.Element("url")?.Value;

                    storeItem.titleText.text = nameStr;
                    storeItem.buttonText.text = priceStr;

                    if (storeItem.bought == true)
                        storeItem.SetToBought();

                    GameData.items[nameStr] = storeItem;
                }
            }
        });
    }

    public static void DownloadImage(string name)
    {
        StorageReference manifestRef = FirebaseStorage.DefaultInstance.GetReferenceFromUrl("gs://connected-gaming-server.appspot.com/Backgrounds/" + name + ".png");

        const long maxAllowedSizeInMegaBytes = 10 * 1024 * 1024;
        manifestRef.GetBytesAsync(maxAllowedSizeInMegaBytes).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
            }
            else
            {
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(task.Result);

                Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                GameData.items[name].backgroundImage = sprite;
            }
        });
    }

    public static void DownloadFile(string fileName, string fileUrl)
    {
        string localUrl = "file://" + Application.dataPath + "/Addressables/" + fileName;
        StorageReference manifestRef = FirebaseStorage.DefaultInstance.GetReferenceFromUrl("gs://connected-gaming-server.appspot.com/" + fileUrl);

        manifestRef.GetFileAsync(localUrl).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted && task.IsCanceled)
                Debug.LogException(task.Exception);
            else
                Debug.Log("File Download");
        });
    }

    public static void UploadFile(string fileName, string fileExtension , string fileUrl)
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;

        StorageReference reference = storage.RootReference.Child("Upload/" + fileName + fileExtension);
        string localFile = "file://" + Application.dataPath + "/" + fileUrl + "/" + fileName + fileExtension;

        reference.PutFileAsync(localFile).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Uploaded");
            }
        });
    }
}
