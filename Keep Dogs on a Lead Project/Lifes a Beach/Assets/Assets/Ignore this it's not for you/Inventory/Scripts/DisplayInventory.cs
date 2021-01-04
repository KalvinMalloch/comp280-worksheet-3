using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryScript inventory;

    public GameObject Child;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {

            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3((X_START + X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMN)), 0f);
    }

    public void DestroyUI()
    {
        Child = this.gameObject.transform.GetChild(0).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(1).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(2).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(3).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(4).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(5).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(6).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(7).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(8).gameObject;
        Destroy(Child.gameObject);

        Child = this.gameObject.transform.GetChild(9).gameObject;
        Destroy(Child.gameObject);
    }
}
