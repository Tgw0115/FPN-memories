using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [TextArea(3,8)]
    [SerializeField]
    private string description;

    [SerializeField]
    private Sprite icon;

    public string ObjectName => objectName;
    private  new Renderer renderer;
    private new Collider collider;

    private void Start ()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObject.Add(this);
        renderer.enabled = false;
        collider.enabled = false;
    }
}
