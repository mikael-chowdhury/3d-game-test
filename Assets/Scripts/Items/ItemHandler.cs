using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Transform RHand;
    public Transform LHand;

    public Item currentlyEquippedItem;

    public static ItemHandler instance;

    void Awake()
    {
        instance = this;

        Object prefab = PrefabHandler.GetPrefab("/Items/Weapons/BlueSword");

        DroppedItem.Spawn(prefab, new Vector3(0, 2, 5));
        DroppedItem.Spawn(prefab, new Vector3(0, 2, 4));
        DroppedItem.Spawn(prefab, new Vector3(0, 2, 3));
        DroppedItem.Spawn(prefab, new Vector3(0, 2, 2));
        DroppedItem.Spawn(prefab, new Vector3(0, 2, 1));
    }

    public void EquipItem(Item item)
    {
        item.transform.parent = RHand;
        item.gameObject.SetActive(true);
        item.gameObject.layer = 9;
        item.EquipItem();
        currentlyEquippedItem = item;
    }
}