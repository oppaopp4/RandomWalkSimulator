using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public void DrawLine(int index, int start, int end, int high, int low)
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, new Vector3(index * 0.12f - 10f, (float)low * 0.05f, 0f));
        lr.SetPosition(1, new Vector3(index * 0.12f - 10f, (float)high * 0.05f, 0f));
    }
}
