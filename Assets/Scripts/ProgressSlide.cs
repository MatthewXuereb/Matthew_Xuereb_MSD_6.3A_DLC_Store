using UnityEngine;
using UnityEngine.UI;

public class ProgressSlide : MonoBehaviour
{
    public GameObject progressBar;

    public Slider slider;

    public float duration = 2.0f;
    private float currentTime = 0.0f;
    private float lastUpdatedTime = 0.0f;

    void Update()
    {
        if (progressBar.activeSelf)
        {
            currentTime = Time.time;
            slider.value = Mathf.InverseLerp(0.0f, duration, currentTime - lastUpdatedTime);

            if (currentTime - lastUpdatedTime > duration)
            {
                lastUpdatedTime = currentTime;
                ToggleProgressBarOff();
            }
        }
    }

    public void ToggleProgressBarOn()
    {
        ResetProgress();
        progressBar.SetActive(true);
    }

    private void ToggleProgressBarOff()
    {
        progressBar.SetActive(false);
    }

    private void ResetProgress()
    {
        lastUpdatedTime = Time.time;
    }
}
