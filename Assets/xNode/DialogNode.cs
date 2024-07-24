using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class DialogNode : Node {
    [Input] public bool _input;
	[Output] public bool _output;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
	[SerializeField][TextArea(5, 10)] private string _text;
    [Output(dynamicPortList = true)] [TextArea(3, 5)] public List<string> _choises;
    
    public string Name => _name;
	public string Text => _text;
    public Sprite Icon => _icon;
	public List<string> Choises => _choises;
	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}