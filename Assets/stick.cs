using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public GameObject line;
    public GameObject box;

    public void DrawStick(int index, int start, int end, int high, int low)
    {
        line.GetComponent<line>().DrawLine(index, start, end, high, low);
        box.GetComponent<box>().DrawBox(index, start, end, high, low);
    }
}
