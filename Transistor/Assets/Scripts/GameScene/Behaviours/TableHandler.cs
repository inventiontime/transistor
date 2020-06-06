using UnityEngine;
using UnityEngine.UI;

public class TableHandler : MonoBehaviour
{
    public GameObject TableVerticalDivider;
    public GameObject TableHorizontalDivider;

    public GameObject HeaderImage;

    public Sprite A;
    public Sprite B;
    public Sprite C;
    public Sprite D;

    public Sprite S1;
    public Sprite S2;
    public Sprite S3;

    public GameObject OnIndicator;
    public GameObject OffIndicator;

    float rowThickness;

    RectTransform rectTransform => transform as RectTransform;

    void Start()
    {
        rowThickness = Mathf.Min(rectTransform.sizeDelta.x / GameManager.Instance.levelData.columns, rectTransform.sizeDelta.y / GameManager.Instance.levelData.rows);

        for (int i = 1; i <= GameManager.Instance.levelData.rows; i++)
            (Instantiate(TableHorizontalDivider, transform).transform as RectTransform).anchoredPosition
             = new Vector2(0, -rowThickness * i);

        GameObject temp;

        for (int i = 0; i < GameManager.Instance.levelData.columns; i++)
        {
            temp = Instantiate(HeaderImage, transform);

            switch (GameManager.Instance.levelData.header[i])
            {
                case 'A':
                    temp.GetComponent<Image>().sprite = A;
                    break;

                case 'B':
                    temp.GetComponent<Image>().sprite = B;
                    break;

                case 'C':
                    temp.GetComponent<Image>().sprite = C;
                    break;

                case 'D':
                    temp.GetComponent<Image>().sprite = D;
                    break;

                case '1':
                    temp.GetComponent<Image>().sprite = S1;
                    break;

                case '2':
                    temp.GetComponent<Image>().sprite = S2;
                    break;

                case '3':
                    temp.GetComponent<Image>().sprite = S3;
                    break;
            }

            (temp.transform as RectTransform).anchoredPosition
            = new Vector2(rectTransform.sizeDelta.x * (i + 0.5f) / GameManager.Instance.levelData.columns,
            -rectTransform.sizeDelta.x * 0.5f / GameManager.Instance.levelData.columns);
        }

        for (int i = 0; i < GameManager.Instance.levelData.TruthTable.Count; i++)
        {
            for (int j = 0; j < GameManager.Instance.levelData.TruthTable[i].list.Count; j++)
            {
                if (GameManager.Instance.levelData.TruthTable[i].list[j])
                    temp = Instantiate(OnIndicator, transform);
                else
                    temp = Instantiate(OffIndicator, transform);

                (temp.transform as RectTransform).anchoredPosition
                = new Vector2(rectTransform.sizeDelta.x * (j + 0.5f) / GameManager.Instance.levelData.columns,
                -rowThickness * (i + 1.5f));
            }
        }
    }
}
