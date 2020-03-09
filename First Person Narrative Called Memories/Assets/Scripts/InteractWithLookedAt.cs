using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Detects when the play looks at a interact button while looking at an IInteractive


public class InteractWithLookedAt : MonoBehaviour
{
    [SerializeField]
    private DetectLookatInteractiveObjects detectLookatInteractive;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && detectLookatInteractive.LookedAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button.");
            detectLookatInteractive.LookedAtInteractive.InteractWith();
		}
    }
}
