using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XNode;


[CreateAssetMenu(menuName = "Game/Dialog Draph")]
public class DialogGraph : NodeGraph { 
    public Dictionary<string, UnityEvent> eventsGraph;
}

