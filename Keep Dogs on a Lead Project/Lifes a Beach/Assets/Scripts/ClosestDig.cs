using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestDig : MonoBehaviour
{
    public GameObject closestDigObj;
    public float closestDigDis;
    public float soundIntensity;
	public float beepDelay = 10000f;
	public bool beenPlayed = false;
	public AudioSource detectSource;
	public AudioClip detectBeep;


    

	void Start()
	{
	}

    void Update()
    {
		BeepIntensify();

        if (closestDigObj != null)
        {
            closestDigDis = Vector3.Distance(closestDigObj.transform.position, transform.position);
        }
    }
	
	void BeepIntensify()
	{
		if (closestDigDis < 10) {
			StartCoroutine(startDetect());
		}
	}
	
	IEnumerator startDetect()
	{
		if (beenPlayed == false) 
		{
			beenPlayed = true;
			detectSource.PlayOneShot(detectBeep);
			yield return new WaitForSeconds(closestDigDis/5);
			beenPlayed = false;
		}
	}




}
