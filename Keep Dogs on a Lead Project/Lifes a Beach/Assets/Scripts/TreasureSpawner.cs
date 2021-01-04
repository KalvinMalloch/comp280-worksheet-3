using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject item;
    public int count;
    public int collidingItems;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            float newX = Random.Range(-37, 43);
            float newZ = Random.Range(-25, 50);
            Vector3 position = new Vector3(newX, 0, newZ);
            GameObject newItem = Instantiate(item, position, this.transform.rotation, this.transform);

            i -= collidingItems;
            collidingItems = 0;
        }
    }
}
