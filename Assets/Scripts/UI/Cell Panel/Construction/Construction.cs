using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Construction : MonoBehaviour
{
    public List<GameObject> elementsOfConstruction = new List<GameObject>();

    private void Start()
    {
        elementsOfConstruction.Add(this.gameObject);
    }

    public void DeleteConstruction()
    {
        if (this.tag == "Function")
        {
            int siblingIdxBrace = GetComponent<MinusCell>().brace.GetSiblingIndex();

            //≈сли справа есть пустые об, то мы их удал€ем
            if (transform.parent.childCount > siblingIdxBrace + 1)
            {
                if (transform.parent.GetChild(siblingIdxBrace + 1).tag == "Empty")
                {
                    int constraintCount = transform.parent.GetComponent<GridLayoutGroup>().constraintCount;
                    for (int numberOfDeletions = constraintCount - siblingIdxBrace % constraintCount - 1;
                        numberOfDeletions > 0; numberOfDeletions--)
                    {
                        print(transform.parent.GetChild(siblingIdxBrace + numberOfDeletions).gameObject);
                        Destroy(transform.parent.GetChild(siblingIdxBrace + numberOfDeletions).gameObject);
                    }
                }
            }
                int siblingIdxFunction = transform.GetSiblingIndex();
            for (int numberOfDeletions = 0; numberOfDeletions < siblingIdxBrace - siblingIdxFunction; numberOfDeletions++)
            { 
                Destroy(transform.parent.GetChild(siblingIdxBrace - numberOfDeletions).gameObject);               
            }                     
        }
        
        foreach (GameObject el in elementsOfConstruction)
        {
            Destroy(el);
        }
    }
    
    public void EraseBlockCode()
    {
        int siblingIdxElement = transform.GetSiblingIndex() + 1;
        int siblingIdxBrace = GetComponent<MinusCell>().brace.GetSiblingIndex();

        Transform cellPanel = transform.parent;
        for (; siblingIdxElement < siblingIdxBrace; siblingIdxElement++)
        {
            if(cellPanel.GetChild(siblingIdxElement).tag == "Cell")
            {
                cellPanel.GetChild(siblingIdxElement).GetComponent<OnCliceOnCell>().OnClice();
            }
        }
    }
}
