using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlphaBot_Bitcoin;

public class CreateConstruction : MonoBehaviour
{
    public static Transform cellPanelTransform;
    public Transform cellPanelInput;

    public static GameObject ifPrefab, elsePrefab, forPrefab, whilePrefab, bracePrefab;
    public GameObject ifPrefabInput, elsePrefabInput, forPrefabInput, whilePrefabInput, bracePrefabInput;

    //For colors
    public CreateFunction createFuction;

    static private List<Color> colors;
    
    private void Start()
    {
        cellPanelTransform = cellPanelInput;

        ifPrefab = ifPrefabInput;
        elsePrefab = elsePrefabInput;
        forPrefab = forPrefabInput;
        whilePrefab = whilePrefabInput;
        bracePrefab = bracePrefabInput;

        
        colors = new List<Color>();

        Color color = Color.white;
        for (float r = 100; r < 256; r += 100)
        {
            for (float b = 50; b < 256; b += 50)
            {
                for (float g = 50; g < 256; g += 80)
                {
                    color.r = r / 256;
                    color.b = b / 256;
                    color.g = g / 256;

                    colors.Add(color);
                }
            }
        }

        for (float b = 100; b < 256; b += 100)
        {
            for (float r = 50; r < 256; r += 50)
            {
                for (float g = 50; g < 256; g += 50)
                {
                    color.r = r / 256;
                    color.b = b / 256;
                    color.g = g / 256;

                    colors.Add(color);
                }
            }
        }

        for (float g = 100; g < 256; g += 100)
        {
            for (float b = 50; b < 256; b += 50)
            {
                for (float r = 50; r < 256; r += 50)
                {
                    color.r = r / 256;
                    color.b = b / 256;
                    color.g = g / 256;

                    colors.Add(color);
                }
            }
        }
        createFuction.colors = colors;
    }

    static private GameObject CreateConstructionGO(GameObject constructionGO, int siblingIdx, bool isBrace)
    {
        Transform constructionTransform = Instantiate<GameObject>(constructionGO, cellPanelTransform).transform;
        constructionTransform.transform.SetSiblingIndex(siblingIdx);

        constructionTransform.GetComponent<Image>().color = colors[0];

        if (isBrace)
        {
            colors.Add(colors[0]);
            colors.RemoveAt(0);
        }

        return constructionTransform.gameObject;
    }
    static public void CreateConstruction_(Constructions construction, int siblingIdx)
    {
        Construction constructionClass;
        GameObject consturctionGO;
        switch (construction)
        {
            case Constructions.If:
                consturctionGO = CreateConstructionGO(ifPrefab, siblingIdx, false);
                
                constructionClass = consturctionGO.GetComponent<Construction>();
                constructionClass.elementsOfConstruction.Add(CreateConstructionGO(bracePrefab, siblingIdx + 2, true));
                consturctionGO.GetComponent<MinusCell>().brace = constructionClass.elementsOfConstruction[constructionClass.elementsOfConstruction.Count - 1].transform;
                break;
            case Constructions.IfElse:
                consturctionGO = CreateConstructionGO(ifPrefab, siblingIdx, false);

                constructionClass = consturctionGO.GetComponent<Construction>();
                constructionClass.elementsOfConstruction.Add(CreateConstructionGO(bracePrefab, siblingIdx + 2, true));
                consturctionGO.GetComponent<MinusCell>().brace = constructionClass.elementsOfConstruction[constructionClass.elementsOfConstruction.Count - 1].transform;


                consturctionGO = CreateConstructionGO(elsePrefab, siblingIdx + 3, false);

                constructionClass = consturctionGO.GetComponent<Construction>();
                constructionClass.elementsOfConstruction.Add(CreateConstructionGO(bracePrefab, siblingIdx + 5, true));
                consturctionGO.GetComponent<MinusCell>().brace = constructionClass.elementsOfConstruction[constructionClass.elementsOfConstruction.Count - 1].transform;
               
                break;
            case Constructions.While:
                consturctionGO = CreateConstructionGO(whilePrefab, siblingIdx, false);

                constructionClass = consturctionGO.GetComponent<Construction>();
                constructionClass.elementsOfConstruction.Add(CreateConstructionGO(bracePrefab, siblingIdx + 2, true));
                consturctionGO.GetComponent<MinusCell>().brace = constructionClass.elementsOfConstruction[constructionClass.elementsOfConstruction.Count - 1].transform;

                break;
            case Constructions.For:
                consturctionGO = CreateConstructionGO(forPrefab, siblingIdx, false);

                constructionClass = consturctionGO.GetComponent<Construction>();
                constructionClass.elementsOfConstruction.Add(CreateConstructionGO(bracePrefab, siblingIdx + 2, true));
                consturctionGO.GetComponent<MinusCell>().brace = constructionClass.elementsOfConstruction[constructionClass.elementsOfConstruction.Count - 1].transform;
                break;
        }
    }
}
