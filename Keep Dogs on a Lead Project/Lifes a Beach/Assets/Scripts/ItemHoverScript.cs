using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoverScript : MonoBehaviour
{
    public GameObject item;
    public Vector3 startPos;
    
    public Vector3 endPos;
    
    public float lerpTime = 5;
    public float currentLerpTime = 0;
    public float distance = 30f;
    public GameObject vCam;

    public Vector3 startPos1;
    public Vector3 endPos1;
    public float lerpTime1 = 5;
    public float currentLerpTime1 = 0;
    public float distance1 = 30f;


    private void Start()
    {
        vCam.SetActive(false);
        startPos = item.transform.position;
        endPos = item.transform.position + Vector3.up * distance;

        startPos1 = item.transform.position;
        endPos1 = item.transform.position + Vector3.down * distance1;

    }
    private void OnMouseOver()
    {
        MoveItemUp();
    }

    private void OnMouseExit()
    {
        MoveItemDown();
    }


    private void MoveItemUp()
    {

        vCam.SetActive(true);
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float Perc = currentLerpTime / lerpTime;
        item.transform.position = Vector3.Lerp(startPos, endPos, Perc);


    }

    private void MoveItemDown()
    {
        vCam.SetActive(false);
        currentLerpTime1 += Time.deltaTime;
        if(currentLerpTime1 >= lerpTime1)
        {
            currentLerpTime1 = lerpTime1;
        }
        float Perc = currentLerpTime1 / lerpTime1;
        item.transform.position = Vector3.Lerp(endPos1, startPos1, Perc);
    }








}
