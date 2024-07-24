using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class DialogGraphEvents : MonoBehaviour
{
    [SerializeField] private NewDict newDict;
    [SerializeField] private DialogManager dialogManager;
    public DialogGraph dialogGraph;

    private void Awake() {
        dialogGraph.eventsGraph = newDict.ToDictionary();
        dialogManager = FindObjectOfType<DialogManager>();
    }

    public void StartDialog()
    {
        dialogManager.StartDialog(dialogGraph);
    }
}
