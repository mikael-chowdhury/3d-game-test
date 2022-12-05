using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject itemModel;
    public Sprite icon;

    protected string itemname;
    protected Rarity itemrarity;

    protected List<Modifiers> modifiers = new List<Modifiers>();

    public Vector3 itempositioninhand;
    public Vector3 itemrotationinhand;
    public Vector3 itemrotationonfloor;

    protected bool equipped = false;

    public bool stackable = false;

    public virtual void InitItem()
    {

    }

    public void EquipItem()
    {
        equipped = true;
        itemModel.transform.localPosition = itempositioninhand;
        itemModel.transform.localRotation = Quaternion.Euler(itemrotationinhand);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

}

