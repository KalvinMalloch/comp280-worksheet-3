using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int whichItem;

    public ItemObject item;

    public ItemObject item1;
    public ItemObject item2;
    public ItemObject item3;
    public ItemObject item4;
    public ItemObject item5;
    public ItemObject item6;
    public ItemObject item7;
    public ItemObject item8;
    public ItemObject item9;
    public ItemObject item10;
    public ItemObject item11;
    public ItemObject item12;
    public ItemObject item13;
    public ItemObject item14;
    public ItemObject item15;
    public ItemObject item16;
    public ItemObject item17;
    public ItemObject item18;
    public ItemObject item19;
    public ItemObject item20;

    public void Start()
    {
        whichItem = Random.Range(1, 20);

        if (whichItem == 1)
        {
            item = item1;
        }
        else if(whichItem == 2)
        {
            item = item2;
        }
        else if (whichItem == 3)
        {
            item = item3;
        }
        else if (whichItem == 4)
        {
            item = item4;
        }
        else if (whichItem == 5)
        {
            item = item5;
        }
        else if (whichItem == 6)
        {
            item = item6;
        }
        else if (whichItem == 7)
        {
            item = item7;
        }
        else if (whichItem == 8)
        {
            item = item8;
        }
        else if (whichItem == 9)
        {
            item = item9;
        }
        else if (whichItem == 10)
        {
            item = item10;
        }
        else if (whichItem == 11)
        {
            item = item11;
        }
        else if (whichItem == 12)
        {
            item = item12;
        }
        else if (whichItem == 13)
        {
            item = item13;
        }
        else if (whichItem == 14)
        {
            item = item14;
        }
        else if (whichItem == 15)
        {
            item = item15;
        }
        else if (whichItem == 16)
        {
            item = item16;
        }
        else if (whichItem == 17)
        {
            item = item17;
        }
        else if (whichItem == 18)
        {
            item = item18;
        }
        else if (whichItem == 19)
        {
            item = item19;
        }
        else if (whichItem == 20)
        {
            item = item20;
        }
    }

}
