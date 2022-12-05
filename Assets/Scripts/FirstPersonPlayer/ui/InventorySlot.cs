using UnityEngine;
using UnityEngine.UI;
using System;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Transform player;

    public Guid guid = System.Guid.NewGuid();

    InventorySlot[] slots;

    Item item;

    int slotNum;

    public Transform EquippedItem;

    public void Start()
    {
        EquippedItem = UIHandler.UI_Game.transform.Find("EquippedItem");

        slots = UIHandler.UI_Inventory.transform.Find("InventorySlots").GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].guid == guid)
            {
                slotNum = i;
                break;
            }
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;

        removeButton.onClick.AddListener(removeButtonPress);
    }

    public void removeButtonPress()
    {
        if (item != null)
        {
            InventoryManager.instance.RemoveOne(item);

            item.itemModel.transform.position = player.transform.TransformPoint(Vector3.forward * 5);
            item.itemModel.SetActive(true);
            item.itemModel.transform.parent = null;
            item.itemModel.tag = "dropped";
            item.itemModel.transform.tag = "dropped";
            item.itemModel.layer = 0;
            item.itemModel.transform.rotation = Quaternion.Euler(item.itemrotationonfloor);

            if (ItemHandler.instance.currentlyEquippedItem == item)
            {
                Image equippedItemImage = EquippedItem.GetComponent<Image>();
                equippedItemImage.sprite = null;
                equippedItemImage.gameObject.SetActive(false);
            }

            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;

        removeButton.onClick.RemoveAllListeners();
    }
}
