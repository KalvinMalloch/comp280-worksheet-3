using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public GameObject items;
    public Image fade;
    public Text score;
    float loadTime;
    Color32 first;
    Color32 second;

    void Start()
    {
        items.SetActive(false);
        loadTime = 2.0f;
        first = new Color32(0, 0, 0, 0);
        second = new Color32(0, 0, 0, 128);
        score.text = ("Today you earned $" + PlayerPrefs.GetInt("Money"));
    }

    void Update()
    {
        if(loadTime > 0)
        {
            fade.color = Color32.Lerp(first, second, (2.0f - loadTime) / 2.0f);
        }

        else 
        {
            items.SetActive(true);
        }

        loadTime -= Time.deltaTime;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
