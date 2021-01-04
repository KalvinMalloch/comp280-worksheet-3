using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsItemColliding : MonoBehaviour
{
    public GameObject particle;
    bool hasSpawned;

    void OnTriggerEnter(Collider hit)
    {
        if (!(hit.transform.CompareTag("Ground") || hit.transform.CompareTag("Dog") || hit.transform.CompareTag("Player") || hit.transform.CompareTag("MetalDetector")))
        {
            transform.parent.GetComponent<TreasureSpawner>().collidingItems += 1;
            Destroy(this.gameObject);
        }

        if (hit.transform.CompareTag("Player") && hasSpawned == false)
        {
            Instantiate(particle, this.transform.position, this.transform.rotation, this.transform);
            hasSpawned = true;
        }
    }
}
