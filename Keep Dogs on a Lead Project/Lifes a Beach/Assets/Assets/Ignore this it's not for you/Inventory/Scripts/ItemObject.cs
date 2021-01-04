using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Relic
}

public abstract class ItemObject : ScriptableObject
{
    public int Value;
    public GameObject prefab;
    public ItemRarity type;
    [TextArea(15,20)]
    public string description;
}
