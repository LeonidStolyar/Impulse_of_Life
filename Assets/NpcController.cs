using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class NewDictItem
{
    public string name;
    public UnityEvent unityEvent;
}
[Serializable]
public class NewDict
{
    [SerializeField] NewDictItem[] thisDictItems;

    public Dictionary<string, UnityEvent> ToDictionary()
    {
        Dictionary<string, UnityEvent> newDict = new Dictionary<string, UnityEvent>();

        foreach (var item in thisDictItems)
        {
            newDict.Add(item.name, item.unityEvent);
        }

        return newDict;
    }
}

public class NpcController : MonoBehaviour
{
    [SerializeField] private NewDict actionsDict;
    [SerializeField] private DialogManager dialogManager;
    public DialogGraph dialogGraph;

    private void Awake() {
        dialogGraph.eventsGraph = actionsDict.ToDictionary();
        dialogManager = FindObjectOfType<DialogManager>();
    }

    public void StartDialog()
    {
        dialogManager.StartDialog(dialogGraph);
    }
}
