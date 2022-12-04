using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public Image currentlyEquippedImage;

    public static InventoryManager instance;

    public ItemHandler itemhandler;

    public int space = 25;
    public static List<int> inventorycounts = new List<int>();
    public static List<Item> Inventory = new List<Item>();

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        for (int i = 0; i < space; i++)
        {
            inventorycounts.Add(0);
            Inventory.Add((Item)null);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if (InventoryManager.Inventory[0] != null)
            {
                currentlyEquippedImage.sprite = InventoryManager.Inventory[0].icon;
                itemhandler.EquipItem(InventoryManager.Inventory[0]);
            }
        }
    }

    int GetFreeSpace()
    {
        int freespace = 0;

        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i] == null)
            {
                freespace++;
            }
        }

        return freespace;
    }

    int GetFirstFreeSpace()
    {
        int firstfreespace = -1;

        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i] == null)
            {
                firstfreespace = i;
                break;
            }
        }

        return firstfreespace;
    }

    public void Add(Item item)
    {
        if (Inventory.Contains(item))
        {
            int index = Inventory.IndexOf(item);
            inventorycounts[index]++;
            onItemChangedCallback.Invoke();
        }
        else if (GetFreeSpace() > 0)
        {
            int firstfreespace = GetFirstFreeSpace();
            Inventory[firstfreespace] = item;
            inventorycounts[firstfreespace] = 1;
            onItemChangedCallback.Invoke();
        }
    }
}
