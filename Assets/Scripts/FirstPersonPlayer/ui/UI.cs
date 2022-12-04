using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject Ui;

    protected string trigger;
    protected bool REQUIRES_MOUSE;

    bool isUIOpen = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        this.REQUIRES_MOUSE = false;

        Ui.SetActive(false);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(trigger))
        {
            isUIOpen = !isUIOpen;

            if (isUIOpen)
            {
                UIHandler.Add(this);
                UIHandler.REQUIRES_MOUSE = REQUIRES_MOUSE;
            }
            else
            {
                UIHandler.Remove(this);
                UIHandler.REQUIRES_MOUSE = false;
            }
        }
    }
}
