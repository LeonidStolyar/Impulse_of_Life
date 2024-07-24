using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class DialogManager : Singleton<DialogManager>
{
    [SerializeField] private DialogGraph currentDialogGraph;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI textNamePerson;
    [SerializeField] private TextMeshProUGUI textDialogPerson;
    [SerializeField] private Image iconPerson;
    [SerializeField] private List<Button> buttonsAnswer;

    private bool canSkip;
    private Node currentNode;
    protected override void Awake() 
    {
        base.Awake();

        // foreach (var node in currentDialogGraph.nodes)
        // {
        //     if(node is DialogNode)
        //     {
        //         Debug.Log(666);
        //     }
        //     else
        //     {
        //         Debug.Log(555);
        //     }

        //     Debug.Log(node.name); 
        //     Debug.Log(node.GetPort("_choises 1")?.Connection?.node);
        // }

        // StartDialog(currentDialogGraph);
    }
    public void StartDialog(DialogGraph dialogGraph)
    {
        foreach (var node in dialogGraph.nodes)
        {
            if (node is StartNode)
            {
                currentNode = node;
                break;
            }
        }
        currentDialogGraph = dialogGraph;

        dialogPanel.SetActive(true);

        CurrentNode();
    }

    private void CurrentNode()
    {
        switch (currentNode)
        {
            case StartNode node:
                currentNode = node.GetPort("_output").Connection?.node;
                CurrentNode();
                break;

            case ActionNode node:
                ActionCurrentNode();
                currentNode = node.GetPort("_output").Connection?.node;
                CurrentNode();
                break;

            case DialogNode node:
                DialogCurrentNode();
                break;

            case EndNode node:
                EndCurrentNode();
                break;
        }
    }
    private void ActionCurrentNode()
    {
        var node = currentNode as ActionNode;
        currentDialogGraph.eventsGraph[node.Name]?.Invoke();
    }
    private void EndCurrentNode()
    {
        dialogPanel.SetActive(false);
    }
    private void DialogCurrentNode()
    {
        var node = currentNode as DialogNode;
        Debug.Log(node.Text);
        foreach (var button in buttonsAnswer)
        {
            button.gameObject.SetActive(false);
        }
        
        if (node.Choises.Count > 0)
        {
            for (int i = 0; i < node.Choises.Count; i++)
            {
                buttonsAnswer[i].gameObject.SetActive(true);

                var textMeshProUGUI = buttonsAnswer[i].GetComponentInChildren<TextMeshProUGUI>();
                textMeshProUGUI.text = node.Choises[i];

                buttonsAnswer[i].onClick.RemoveAllListeners();

                var nodeButton = node.GetPort($"_choises {i}")?.Connection.node;
                buttonsAnswer[i].onClick.AddListener(() => ButtonDialog(nodeButton));
            }
            canSkip = false;
        }
        else
        {
            currentNode = node.GetPort("_output").Connection?.node;
            canSkip = true;
        }

        textNamePerson.text = node.Name;
        textDialogPerson.text = node.Text;
        iconPerson.sprite = node.Icon;
    }
    private void ButtonDialog(Node node)
    {
        currentNode = node;
        CurrentNode();
    }
    private void Update()
    {
        if (!canSkip) return;
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            CurrentNode();
        }
    }

    public void Test1()
    {
        Debug.Log(10);
    }
        
}
