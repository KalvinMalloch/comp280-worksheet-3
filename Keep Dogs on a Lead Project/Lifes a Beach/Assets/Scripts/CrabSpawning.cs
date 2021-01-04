using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawning : MonoBehaviour
{
    public GameObject[] Crabs;

    void Start()
    {
        StartCoroutine(spawn());
    }



    IEnumerator spawn()
    {
        yield return new WaitForSeconds(20f);
        Crabs[0].SetActive(true);
        StartCoroutine(spawn2());

    }

    IEnumerator spawn2()
    {
        yield return new WaitForSeconds(50f);
        Crabs[1].SetActive(true);
        StartCoroutine(spawn3());

    }

    IEnumerator spawn3()
    {
        yield return new WaitForSeconds(50f);

        Crabs[2].SetActive(true);


    }
}
