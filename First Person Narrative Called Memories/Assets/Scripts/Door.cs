using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [SerializeField]
    private InventoryObject key;

    [SerializeField]
    private bool consumesKey;
    
    [SerializeField]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    private AudioClip lockedAudioClip;

    [SerializeField]
    private AudioClip openAudioClip;

    public override string DisplayText => isLocked ? lockedDisplayText :  base.DisplayText;


    //public override string DisplayText
    //{
    //    get
    //    {
    //        string toReturn;

    //        if (isLocked)
    //            toReturn = HasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
    //        else
    //            toReturn = base.DisplayText;
    //        return toReturn;
    //    }
    //} 

    private bool HasKey => PlayerInventory.InventoryObject.Contains(key);
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked;
    //private bool shouldOpen = Animator.StringToHash(nameof(shouldOpen));
    /// <summary>
    /// Constructor to initalize displayText in editor.
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeIsLocked();
    }
    private void InitializeIsLocked()
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractWith()
    {
        //HasKey = checkForKey();
        if (!isOpen)
        {

            if (isLocked && !HasKey )
            {
                audioSource.clip = lockedAudioClip;
            }
            else if (isLocked && HasKey)
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
                UnlockDoor();
 
            }
            else
            {
                audioSource.clip = lockedAudioClip;
            }

            base.InteractWith(); //This play sounds effect
        }

    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
            PlayerInventory.InventoryObject.Remove(key);
    }

    //private bool CheckForKey()
    //{
    //    foreach(InventoryObject i in PlayerInventory.InventoryObject)
    //    {
    //        if(i.ObjectName = "Door Key")
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}

}
