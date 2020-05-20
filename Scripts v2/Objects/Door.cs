using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}
public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D psysicsCollider;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                if (playerInventory.numberOfKeys > 0)
                {
                    playerInventory.numberOfKeys--;
                    Open();
                }
            }
        }
    }
    public void Open()
    {
        doorSprite.enabled = false;
        open = true;
        psysicsCollider.enabled = false;
    }

    public void Close()
    {
        
    }
}
