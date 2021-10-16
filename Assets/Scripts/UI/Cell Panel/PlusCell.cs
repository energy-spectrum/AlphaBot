using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusCell : MonoBehaviour
{
    public GameObject cellPrefab;
    private Transform cellsTransform;
    void Start()
    {
        cellsTransform = GameObject.Find("Cell Panel").transform;
    }

    private bool canAddCell = true;
    public void AddAllCells()
    {
        while (canAddCell)
        {
            Place�ellInTheBlock();
        }
        canAddCell = true;
    }

    //����� ������� ����������� ������, ���� �����������
    public Transform functionTransform;
    //��������� ������ ������ � ���� 
    public GameObject emptyGO; 
    public void Place�ellInTheBlock()
    {             
        if(functionTransform)
        {
            if(cellsTransform.GetComponent<NumberCellsRemaining>().numberOfCellsRemaining != 0)
            {
                if (cellsTransform.childCount - 1 != this.transform.GetSiblingIndex())
                {
                    Transform goTransform = cellsTransform.GetChild(transform.GetSiblingIndex() + 1);
                    if (goTransform.tag == "Empty")
                    {
                        Destroy(goTransform.gameObject);
                    }

                    GameObject cellGO = Instantiate<GameObject>(cellPrefab, cellsTransform);
                    cellGO.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

                    if (goTransform.tag == "Function")
                    {
                        int constraintCount = cellsTransform.GetComponent<GridLayoutGroup>().constraintCount;
                        for (int i = 0; i < constraintCount - 1; i++)
                        {
                            GameObject cloneEmptyGO = Instantiate<GameObject>(emptyGO, cellsTransform);
                            cloneEmptyGO.transform.SetSiblingIndex(this.transform.GetSiblingIndex() + 1);
                        }
                    }
                }
                else
                {
                    GameObject cellGO = Instantiate<GameObject>(cellPrefab, cellsTransform);
                    cellGO.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
                }

                cellsTransform.GetComponent<NumberCellsRemaining>().ChangeNumberCellsRemaining(-1);// ����� ��� ����� ��� ������ 
            }
            else
            {
                canAddCell = false;
            }
        }
        else if (cellsTransform.GetChild(transform.GetSiblingIndex() + 1).tag == "Cell")
        {
            transform.SetSiblingIndex(transform.GetSiblingIndex() + 1);
        }
        else
        {
            canAddCell = false;
        }
    }
}
