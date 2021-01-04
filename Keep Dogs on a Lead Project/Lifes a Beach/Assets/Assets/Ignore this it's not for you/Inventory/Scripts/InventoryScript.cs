using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryScript : ScriptableObject
{
    public Movement move;
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        Container.Add(new InventorySlot(_item, _amount));
    }
    public void SellItems()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            move.money = move.money + Container[i].item.Value;
        }
        Container.Clear();
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}