using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SuperTiled2Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SceneMagagerGeometryRoom1 : MonoBehaviour
{
    [SerializeField] private List<BoxTriggerGeometryRoom1> boxesTrigger;

    [SerializeField] private int needSum;
    private void Awake() {
        boxesTrigger = FindObjectsOfType<BoxTriggerGeometryRoom1>().ToList();
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
    private int GetSumNumbers()
    {
        var sum = 0;
        foreach(var box in boxesTrigger)
        {
            TextMeshProUGUI textPro = box.target?.GetComponentInChildren<TextMeshProUGUI>();
            if (textPro != null)
            {
                int value;
                var success = int.TryParse(textPro.text, out value);
                if (success) sum += value;
            }
            else
            {
                Debug.Log("Error");
            }
        }
        return sum;
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
        var sumNumbers = GetSumNumbers();

        if(sumNumbers == needSum)
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
