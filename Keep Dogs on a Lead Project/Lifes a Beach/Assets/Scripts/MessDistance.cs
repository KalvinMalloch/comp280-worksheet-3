using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessDistance : MonoBehaviour
{
    public float distanceAway;
    public GameObject playerObj;

    void Start()
    {
        playerObj = GameObject.FindWithTag("MetalDetector");
    }

    void Update()
    {
        distanceAway = Vector3.Distance(playerObj.transform.position, transform.position);

        if (playerObj.GetComponent<ClosestDig2>().closestDigDis > distanceAway || playerObj.GetComponent<ClosestDig2>().closestDigObj == null)
        {
            playerObj.GetComponent<ClosestDig2>().closestDigObj = this.gameObject;

        }
    }
}
