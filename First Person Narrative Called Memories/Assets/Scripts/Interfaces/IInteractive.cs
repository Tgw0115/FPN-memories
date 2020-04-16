using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Interface that player will be able to interact with.
///</summary>

public interface IInteractive 
{
	string DisplayText { get; }
	void InteractWith();
}
