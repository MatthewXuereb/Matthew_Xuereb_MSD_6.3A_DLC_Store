using System;
using UnityEngine;
using System.IO;

public class MineData : MonoBehaviour
{
    public string actionString;
    public string fileName;

    public void Mine()
    {
        SaveData data = new SaveData
        {
            action = actionString,
            fullDate = DateTime.Now.ToString()
        };

        string userId = PlayerPrefs.GetString("Id");
        File.WriteAllText(Application.dataPath + "/Resources/Data/" + userId + "_" + fileName + ".txt", JsonUtility.ToJson(data));

        FirebaseStorageManager.UploadFile(userId + "_" + fileName, ".txt", "Resources/Data");
    }
}

public class SaveData
{
    public string action;

    public string fullDate;
}