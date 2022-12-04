using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Transform player;

    Item item;

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
        item.itemModel.transform.position = player.transform.TransformPoint(Vector3.forward * 3);
        item.itemModel.SetActive(true);
        item.itemModel.transform.parent = null;
        item.itemModel.tag = "dropped";
        item.itemModel.layer = 0;
        item.itemModel.transform.rotation = Quaternion.Euler(item.itemrotationonfloor);

        ClearSlot();
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
