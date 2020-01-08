using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWalk : MonoBehaviour
{
    private int one_stick;
    private int max_stick;
    public GameObject red_stick;
    public GameObject blue_stick;
    public GameObject cam;
    public GameObject inputf_stick;
    public GameObject inputf_limit;

    private int price;

    private void Start()
    {
        inputf_stick.GetComponent<InputField>().text = "50";
        inputf_limit.GetComponent<InputField>().text = "150";
    }

    void Clear()
    {
        foreach (Transform transform in gameObject.transform)
        {
            var go = transform.gameObject;
            Destroy(go);
        }
        price = 0;
    }
    public void run()
    {
        one_stick = int.Parse(inputf_stick.GetComponent<InputField>().text);
        max_stick = int.Parse(inputf_limit.GetComponent<InputField>().text);

        Clear();

        List<Stick> list = new List<Stick>();
        Stick st;

        for (int i = 0; i < max_stick; i++)
        {
            st = new Stick(price);

            for (int j = 0; j < one_stick; j++)
            {
                int r = Random.Range(0, 1000);

                //1/2の確率で1ポイント上がるか下がるかだけ
                if (r % 2 == 0)
                {
                    //up
                    price++;
                    if (price > st.high) st.high = price;
                }
                else
                {
                    //down
                    price--;
                    if (price < st.low) st.low = price;
                }

                if (j == 0) st.start = price;

                st.end = price;
            }
            list.Add(st);
        }

        int index = 0;
        foreach (Stick item in list)
        {
            GameObject stick;
            if (item.start < item.end)
            {
                stick = red_stick;
            }
            else
            {
                stick = blue_stick;
            }

            var obj = Instantiate(stick, new Vector3(0f, 0f, 0f), Quaternion.identity);
            obj.transform.parent = this.transform;
            obj.GetComponent<stick>().DrawStick(index, item.start, item.end, item.high, item.low);

            index++;
        }

        //0ライン
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, new Vector3(-10.12f, 0f, 0f));
        lr.SetPosition(1, new Vector3(list.Count * 0.12f - 10f, 0f, 0f));

        //cam.GetComponent<Camera>().SetDefPosX((-10 + list.Count * 0.12f - 10f) / 2.0f);
        cam.GetComponent<Camera>().SetDefPosX(0f);

        Debug.Log(price);
    }
}

public class Stick
{
    public int high { get; set; }
    public int low { get; set; }
    public int start { get; set; }
    public int end { get; set; }

    public Stick(int p)
    {
        high = p;
        low = p;
        start = p;
        end = p;
    }
}