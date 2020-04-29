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
    public Sprite Icon => icon;
    public string Description => description;
    private Renderer[] childRenderers;
    private Collider[] childColliders;

    private void Start ()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        childRenderers = GetComponentsInChildren<Renderer>();
        childColliders = GetComponentsInChildren<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObject.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
        renderer.enabled = false;
        DisableChildRenderers();
        collider.enabled = false;
        DisableChildColliders();
        Debug.Log($"Inventory menu game object name {InventoryMenu.Instance.name}");
    }


    void DisableChildRenderers()
    {
        foreach (Renderer col in childRenderers)
        {
            col.enabled = false;
        }
    }

    void DisableChildColliders()
    {
        foreach (Collider col in childColliders)
        {
            col.enabled = false;
        }
    }

}
