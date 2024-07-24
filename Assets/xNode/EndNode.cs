using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class EndNode : Node {

	// Use this for initialization
	[Input] public bool _input;
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}