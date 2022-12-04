using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static List<UI> UIStack = new List<UI>();

    public static bool REQUIRES_MOUSE = false;

    public static void Pop()
    {
        UIStack[UIStack.Count - 1].Ui.SetActive(false);
        UIStack.RemoveAt(UIStack.Count - 1);
    }

    public static void Add(UI Ui)
    {
        Ui.Ui.SetActive(true);
        UIStack.Add(Ui);
    }

    public static void Remove(UI Ui)
    {
        Ui.Ui.SetActive(false);
        UIStack.Remove(Ui);
    }

    public static void Clear()
    {
        UIStack.ForEach((UI Ui) =>
        {
            Ui.Ui.SetActive(false);
        });
        UIStack.Clear();
    }
}
