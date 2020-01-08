using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public void DrawBox(int index, int start, int end, int high, int low)
    {
        LineRenderer br = GetComponent<LineRenderer>();
        if (start == end)
        {
            br.SetPosition(0, new Vector3(index * 0.12f - 10f, (float)end * 0.05f + 0.01f, 0f));
            br.SetPosition(1, new Vector3(index * 0.12f - 10f, (float)start * 0.05f, 0f));
        }
        else
        {
            br.SetPosition(0, new Vector3(index * 0.12f - 10f, (float)end * 0.05f, 0f));
            br.SetPosition(1, new Vector3(index * 0.12f - 10f, (float)start * 0.05f, 0f));
        }
    }
}
