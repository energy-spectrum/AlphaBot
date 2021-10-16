using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MinusCell : MonoBehaviour
{
    private Transform cellsTransform;
    public Transform brace;
    public bool removeCell;
    void Start()
    {
        cellsTransform = GameObject.Find("Cell Panel").transform;
    }
    
    public GameObject emptyGO;
    //Убрать последнюю ячейку в блоке  
    public void RemoveLastCellInBlock()
    {
        if (cellsTransform.GetChild(brace.GetSiblingIndex() - 1).tag == "Cell")
        {
            if (brace.GetSiblingIndex() - transform.GetSiblingIndex() > 2)
            {
                //Если нужно удалить, т е это функция
                if (removeCell)
                {
                    if (cellsTransform.childCount - 1 != brace.transform.GetSiblingIndex())
                    {
                        int idxBrace = brace.GetSiblingIndex();
                        int idxFunction = this.transform.GetSiblingIndex();

                        int constraintCount = cellsTransform.GetComponent<GridLayoutGroup>().constraintCount;

                        int countEmptyGO = (idxBrace - idxFunction + 1) % (constraintCount);

                        if (countEmptyGO != 1)
                        {
                            GameObject cloneEmptyGO = Instantiate<GameObject>(emptyGO, cellsTransform);
                            cloneEmptyGO.transform.SetSiblingIndex(brace.transform.GetSiblingIndex() + 1);
                        }
                        else
                        {
                            GameObject[] arrEmptyGO = new GameObject[3];
                            for (int i = 0; i < constraintCount - 1; i++)
                            {
                                arrEmptyGO[i] = cellsTransform.GetChild(brace.transform.GetSiblingIndex() + i + 1).gameObject;
                            }

                            for (int i = 0; i < constraintCount - 1; i++)
                            {
                                Destroy(arrEmptyGO[i]);
                            }
                        }
                    }
                    Destroy(cellsTransform.GetChild(brace.GetSiblingIndex() - 1).gameObject);
                    cellsTransform.GetComponent<NumberCellsRemaining>().ChangeNumberCellsRemaining(+1);
                }
                else
                {
                    brace.SetSiblingIndex(brace.GetSiblingIndex() - 1);
                }
            }
        }
    }
}
