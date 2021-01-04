using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    public GameObject[] children;

    void Start()
    {
        StartCoroutine(spawn());
    }



    IEnumerator spawn()
    {
        yield return new WaitForSeconds(50f);
        children[0].SetActive(true);
        StartCoroutine(spawn2());

    }

    IEnumerator spawn2()
    {
        yield return new WaitForSeconds(50f);
        children[1].SetActive(true);
        StartCoroutine(spawn3());

    }

    IEnumerator spawn3()
    {
        yield return new WaitForSeconds(50f);
        
        children[2].SetActive(true);
      

    }
}