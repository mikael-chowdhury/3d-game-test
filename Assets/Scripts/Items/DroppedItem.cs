using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DroppedItem : MonoBehaviour
{
    protected GameObject itemObj;
    protected Item item;
    public static GameObject itemObjectParam;

    void Start()
    {
        this.itemObj = itemObjectParam;
        this.item = itemObjectParam.GetComponent<Item>();

        // this.itemObj.transform.rotation = Quaternion.Euler(this.item.itemrotationinhand);
    }

    public static void Spawn(Object item, Vector3 position)
    {
        itemObjectParam = Instantiate((GameObject)item, position, Quaternion.Euler(-90, 0, 0));

        itemObjectParam.AddComponent<BoxCollider>();
        BoxCollider bc = itemObjectParam.GetComponent<BoxCollider>();
        // rb.useGravity = false;
        bc.isTrigger = true;

        itemObjectParam.tag = "dropped";
        itemObjectParam.AddComponent<DroppedItem>();
    }
}