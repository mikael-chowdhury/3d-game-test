using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Transform RHand;
    public Transform LHand;

    void Awake()
    {
        Object prefab = PrefabHandler.GetPrefab("/Items/Weapons/BlueSword");
        DroppedItem.Spawn(prefab, new Vector3(0, 2, 5));
    }

    public void EquipItem(Item item)
    {
        item.transform.parent = RHand;
        item.gameObject.SetActive(true);
        item.gameObject.layer = 9;
        item.EquipItem();
    }
}