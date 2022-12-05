using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<DroppedItem>() != null && collider.gameObject.tag == "dropped")
        {
            Item item = collider.gameObject.GetComponent<Item>();
            item.itemModel = collider.gameObject;
            InventoryManager.instance.Add(item);
            collider.gameObject.SetActive(false);
            collider.gameObject.tag = "utagged";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
