using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyboxCont : MonoBehaviour
{
    public Material sky;
    public Transform sun;
    Color32 dawn;
    Color32 day;
    Color32 dusk;
    Color32 night;
    float changeTime;
    int changes;
    float endTime;
    bool startEnd;

    void Start()
    {
        sun.eulerAngles = new Vector3(130, sun.eulerAngles.y, sun.eulerAngles.z);
        sun.GetComponent<Animation>()["Day Cylce"].speed = 0.3f;

        dawn = new Color32(56, 65, 80, 128);
        day = new Color32(60, 93, 145, 128);
        dusk = new Color32(255, 63, 35, 128);
        night = new Color32(18, 20, 58, 128);
        sky.color = dawn;
        changeTime = 10.0f;
        endTime = 15.0f;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            sky.color = day;
        }

        if (SceneManager.GetActiveScene().name == "MainScene2")
        {
            if (changes == 0 && sun.eulerAngles.x < 100)
            {
                sky.color = Color.Lerp(dawn, day, (10.0f - changeTime) / 10.0f);
                changeTime -= Time.deltaTime;
            }

            if (changes == 1 && sun.eulerAngles.x < 45)
            {
                sky.color = Color.Lerp(day, dusk, (10.0f - changeTime) / 10.0f);
                changeTime -= Time.deltaTime;
            }

            if (changes == 2 && (sun.eulerAngles.x < 10 || sun.eulerAngles.x > 180))
            {
                sky.color = Color.Lerp(dusk, night, (10.0f - changeTime) / 10.0f);
                changeTime -= Time.deltaTime;
                startEnd = true;
            }

            if (changeTime <= 0)
            {
                changes++;
                changeTime = 10.0f;
            }

            if (startEnd == true)
            {
                if (endTime <= 0)
                {
                    SceneManager.LoadScene(2);
                }
                endTime -= Time.deltaTime;
            }
        }        
    }

    void OnApplicationQuit()
    {
        sky.color = day;
    }
}
