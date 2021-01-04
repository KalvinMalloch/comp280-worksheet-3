using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestDig2 : MonoBehaviour
{
    [Header("Public Dig Variables")]
    public GameObject closestDigObj;
    public float closestDigDis;

    [Header("Private Audio Variables")]
    [SerializeField] private bool isBeeping;
    [SerializeField] private float progressToNextBeep = 0f;
    [SerializeField] private AudioSource beep;
	

    void Update()
    {
        // if metal detector in range of anything
        if (closestDigDis < 10 && !isBeeping)
        {
            isBeeping = true;
            beep.Play();
            progressToNextBeep = 0f;
            StartCoroutine(BeepLoop());
        }
        if (closestDigObj != null)
        {
            closestDigDis = Vector3.Distance(closestDigObj.transform.position, transform.position);
        }
    }
	
    IEnumerator BeepLoop()
    {
        if (closestDigDis <= 10)
        {
            // once in range add progress to next beep every 0.05 seconds
            yield return new WaitForSeconds(0.05f);
            if(closestDigDis < 2)
            {
                progressToNextBeep += 30f;
            }
            else if (closestDigDis < 4)
            {
                progressToNextBeep += 20f;
            }
            else if (closestDigDis < 6)
            {
                progressToNextBeep += 15f;
            }
            else if (closestDigDis < 8)
            {
                progressToNextBeep += 9f;
            }
            else
            { 
                progressToNextBeep += 5f;
            }

            if (progressToNextBeep >= 100f)
            {
                beep.Play();
                progressToNextBeep = 0f;
            }
            StartCoroutine(BeepLoop());
        }
        else
        {
            // if left range stop loop
            isBeeping = false;
            yield return new WaitForSeconds(0f);
        }
    }
}
