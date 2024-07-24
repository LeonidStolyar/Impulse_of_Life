using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SceneManagerAlgebraRoom2 : MonoBehaviour
{
    [SerializeField] private List<BoxTriggerAlgebraRoom2> boxesTrigger;
    private void Awake() {
        //boxesTrigger = FindObjectsOfType<BoxTriggerAlgebraRoom2>().ToList();
    }

    private void Update()
    {
        CheckTriggers();
    }
    private bool IsAnyBoxesTargetNull()
    {
        foreach (var box in boxesTrigger)
        {
            if(box.target == null) return true;

        }
        return false;
    }
    private bool CheckArithmeticSequentially()
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < boxesTrigger.Count - 1; i++)
        {
            TextMeshProUGUI textPro1 = boxesTrigger[i].target?.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI textPro2 = boxesTrigger[i + 1].target?.GetComponentInChildren<TextMeshProUGUI>();
            if (textPro1 == null || textPro2 == null) return false;
            
            int value1;
            int value2;

            var success1 = int.TryParse(textPro1.text, out value1);
            var success2 = int.TryParse(textPro2.text, out value2);

            if (!success1 || !success2) return false;
            numbers.Add(value2 - value1);
        }
        Debug.Log($"{numbers[0]} {numbers[1]} {numbers[2]}");
        if (numbers.Distinct().Count() == 1) return true;
        else return false;
    }
    private void CheckTriggers()
    {
        if(IsAnyBoxesTargetNull())
        {
            foreach (var box in boxesTrigger)
            {
                box.ChangeColorTarget(box.target);
            }
            return;
        }
        var isSequentially = CheckArithmeticSequentially();

        if(isSequentially)
        {
            Debug.Log("EZ");
        }
        else
        {
            foreach (var box in boxesTrigger)
            {
                box.ChangeColorIncorrent(box.target);
            }
        }


    }
}
