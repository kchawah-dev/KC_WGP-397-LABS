using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public List<string> GetItemNames()
    {
        List<string> names = new List<string>();

        foreach (var item in items)
        {
            names.Add(item.itemName);
        }

        return names;
    }

    public void LoadItems(List<string> itemNames)
    {
        items.Clear();

        foreach (string name in itemNames)
        {
            Item item = Resources.Load<Item>("Items/" + name);
            if (item != null)
            {
                items.Add(item);
            }
        }
    }
}