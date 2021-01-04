using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDigging : MonoBehaviour
{
    public InventoryScript inventory;

    public GameObject player;

    public Movement movementScript;

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "DigSpot") &&(Input.GetKeyDown(KeyCode.RightShift)))
        {
            var item = other.GetComponent<Item>();
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
            Destroy(other.gameObject);
            movementScript.dogDug();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    private void Start()
    {
        movementScript = player.GetComponent<Movement>();
    }
}
