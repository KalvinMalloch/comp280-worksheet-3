using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Common")]

public class SellableObject : ItemObject
{
    public void Awake()
    {
        type = ItemRarity.Common;
    }
}
