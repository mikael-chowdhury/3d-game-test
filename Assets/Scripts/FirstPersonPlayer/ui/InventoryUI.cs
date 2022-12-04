using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : UI
{
    public Transform itemsParent;
    InventorySlot[] slots;

    protected InventoryManager inventory;

    // Start is called before the first frame update
    public override void Start()
    {
        Debug.Log(InventoryManager.instance);
        inventory = InventoryManager.instance;
        inventory.onItemChangedCallback += UpdateUI;

        base.trigger = "i";
        base.Start();
        this.REQUIRES_MOUSE = true;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (InventoryManager.Inventory[i] != null)
            {
                slots[i].AddItem(InventoryManager.Inventory[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
