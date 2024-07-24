using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class ActionNode : Node {
	[Input] public bool _input;
	[Output] public bool _output;
	[SerializeField][XmlText] private string _name;
	
	
	public string Name => _name;
	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}