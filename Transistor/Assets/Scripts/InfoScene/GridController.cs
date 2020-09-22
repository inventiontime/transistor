using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public InfoMainScript mainScript;

    public GameObject HeaderImage;

    public Sprite A;
    public Sprite B;

    public Sprite S1;

    public GameObject OnIndicator;
    public GameObject OffIndicator;

    public float width;
    public float height;

    List<GameObject> temp = new List<GameObject>();

    private void Start()
    {
        ReloadInfo();
    }

    public void ReloadInfo()
    {
        DestroyInfo();
        InstantiateInfo();
    }

    void InstantiateInfo()
    {
        if(mainScript.pageNo == 3)
            return;

        for (int i = 0; i < 3; i++)
        {
            temp.Add(Instantiate(HeaderImage, transform));

            switch (i)
            {
                case 0:
                    temp.Last().GetComponent<SpriteRenderer>().sprite = A;
                    break;

                case 1:
                    temp.Last().GetComponent<SpriteRenderer>().sprite = B;
                    break;

                case 2:
                    temp.Last().GetComponent<SpriteRenderer>().sprite = S1;
                    break;
            }

            temp.Last().transform.localPosition = new Vector2((i + 0.5f) * width, 0.5f * height);
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (j == 0)
                {
                    if (GetInputA(i))
                        temp.Add(Instantiate(OnIndicator, transform));
                    else
                        temp.Add(Instantiate(OffIndicator, transform));
                }
                else if (j == 1)
                {
                    if (GetInputB(i))
                        temp.Add(Instantiate(OnIndicator, transform));
                    else
                        temp.Add(Instantiate(OffIndicator, transform));
                }
                else if (j == 2)
                {
                    if (GetOutput(i))
                        temp.Add(Instantiate(OnIndicator, transform));
                    else
                        temp.Add(Instantiate(OffIndicator, transform));
                }

                temp.Last().transform.localPosition = new Vector2((j + 0.5f) * width, (i + 1.5f) * height);
            }
        }
    }

    void DestroyInfo()
    {
        foreach(var x in temp)
        {
            Destroy(x);
        }

        temp = new List<GameObject>();
    }

    bool GetOutput(int i)
    {
        bool A = GetInputA(i);
        bool B = GetInputB(i);

        switch (mainScript.pageNo)
        {
            case 1:
                return A & B;

            case 2:
                return A & !B;

            case 3:
                return A & !B;

            case 4:
                return A & B;

            case 5:
                return A | B;

            case 6:
                return !(A & B);

            case 7:
                return !(A | B);

            case 8:
                return A ^ B;

            case 9:
                return !(A ^ B);

            default:
                return false;
        }
    }

    bool GetInputA(int i)
    {
        switch(i)
        {
            case 0:
                return false;

            case 1:
                return false;

            case 2:
                return true;

            case 3:
                return true;

            default:
                return false;
        }
    }

    bool GetInputB(int i)
    {
        switch (i)
        {
            case 0:
                return false;

            case 1:
                return true;

            case 2:
                return false;

            case 3:
                return true;

            default:
                return false;
        }
    }
}
