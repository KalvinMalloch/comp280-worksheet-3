using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Image fade;
    Transform fence;
    Transform pivot;
    bool play;
    float gateOpening;
    Color newAlpha;
    public GameObject vcam1;
    public float fadeSpeed;
   
    void Start()
    {
        fence = transform.GetChild(0).transform;
        pivot = transform;
        play = false;
        gateOpening = 1.0f;
        newAlpha = new Color(0, 0, 0, 0);
        vcam1.SetActive(false);
        fadeSpeed = Time.deltaTime * fadeSpeed;
    }

    void Update()
    {        
        if (play == true)
        {
            newAlpha.a += 0.01f;
            fade.color = newAlpha;

            if (pivot.rotation.y > 0.75)
            {
                pivot.Rotate(new Vector3(0, -1, 0));
            }

            if (gateOpening <= 0)
            {
                SceneManager.LoadScene(1);
            }

            gateOpening -= fadeSpeed;
        }

        else
        {
            Vector2 mousePos = Input.mousePosition;
            Ray pointing = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hit;

            if (Physics.Raycast(pointing, out hit) && hit.transform.CompareTag("Gate"))
            {
                if (pivot.rotation.y > 0.98)
                {
                    pivot.Rotate(new Vector3(0, -1, 0));
                }

                if (Input.GetMouseButtonDown(0))
                {
                    play = true;
                    vcam1.SetActive(true);
                }
            }

            else
            {
                if (pivot.rotation.y < 1)
                {
                    pivot.Rotate(new Vector3(0, 1, 0));
                }
            }

            if (Physics.Raycast(pointing, out hit) && hit.transform.CompareTag("Exit") && Input.GetMouseButtonDown(0))
            {
                Application.Quit();
                Debug.Log("quit");
            }
        }
    }
}
