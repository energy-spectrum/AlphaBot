using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateFunction : MonoBehaviour
{
    public GameObject functionPrefab, cellPrefab, bracePrefab;
  
    public List<Color> colors;
    private Transform cellsTransform;
    private NumberCellsRemaining numberCellsRemaining;

    private AddFunctionCall addFunctionCall;

    private void Start()
    {
        //colors = new List<Color>();
       
        //for (float r = 205; r < 255; r += 30)
        //{
        //    for (float b = 0; b < 255; b += 60)
        //    {
        //        for (float g = 0; g < 255f; g += 50)
        //        {
        //            colors.Add(new Color(r / 255.0f, b / 255.0f, g / 255.0f, 1f));
        //        }
        //    }
        //}

        ////Случайное перемешивание
        //System.Random random = new System.Random();
        //for (int i = 0; i < colors.Count; i++)
        //{
        //    int j = random.Next(colors.Count);
        //    Color temp = colors[i];
        //    colors[i] = colors[j];
        //    colors[j] = temp;
        //}
        //
        //Вывод в консоль количество цветов
      //  print(colors.Count);

        cellsTransform = GameObject.Find("Cell Panel").transform;
        numberCellsRemaining = cellsTransform.GetComponent<NumberCellsRemaining>();

        addFunctionCall = GetComponent<AddFunctionCall>();
    }

    private short numer = 1;

    public GameObject emptyPrefab;
    public void CreateFunction_()
    {
        DeleteConstruction.Off();

        if (numberCellsRemaining.numberOfCellsRemaining == 0) 
        {
            print("Эй, БОСС! Ячеек пустых не осталось!");
            return;
        }

        Image imageFunctionPrefab = functionPrefab.GetComponent<Image>();
        imageFunctionPrefab.color = colors[0];


        if (cellsTransform.GetChild(cellsTransform.childCount - 1).tag != emptyPrefab.tag)
        {
            //Добавление пустых GO для того, чтобы конструкция начиналась с новой строки
            Transform previousBrace = cellsTransform.GetChild(cellsTransform.childCount - 1);

            int idxPreviosuBrace = previousBrace.GetSiblingIndex();
            int idxPreviousFunction = previousBrace.GetComponent<PlusCell>().functionTransform.GetSiblingIndex();

            int constraintCount = cellsTransform.GetComponent<GridLayoutGroup>().constraintCount;

            int countEmptyGO = (idxPreviosuBrace - idxPreviousFunction + 1) % constraintCount;

            if (countEmptyGO != 0)
            {
                for (int i = 0; (i < constraintCount - countEmptyGO); i++)
                {
                    Instantiate<GameObject>(emptyPrefab, cellsTransform);
                }
            }
        }
        //

        GameObject functionConstructionGO = Instantiate<GameObject>(functionPrefab, cellsTransform);

        functionConstructionGO.name = "Function " + numer.ToString();

        Instantiate<GameObject>(cellPrefab, cellsTransform);
        GameObject braceGO = Instantiate<GameObject>(bracePrefab, cellsTransform);

        functionConstructionGO.GetComponent<MinusCell>().brace = braceGO.transform;
        braceGO.GetComponent<PlusCell>().functionTransform = functionConstructionGO.transform;


        //Добавить кнопку FunctionCall для этой функции
        GameObject functionCallGO = addFunctionCall.AddFunctionCall_(colors[0], numer);

        functionConstructionGO.GetComponent<Construction>().elementsOfConstruction.Add(functionCallGO);

        colors.Add(colors[0]);
        colors.RemoveAt(0);
      

        numer++;
    }
}
