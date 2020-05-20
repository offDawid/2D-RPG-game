using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalSend raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
           if (!isOpen)
            {
                //open
                OpenChest();
            }
            else
            {
                //opened
                ChestAlreadyOpen();
            }
        }
    }
    public void OpenChest()
    {
        //pojawia sie dialog
        dialogBox.SetActive(true);
        //dialog na tekst
        dialogText.text = contents.itemDescription;
        //dodaje do eq
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //sygnal animacji
        raiseItem.Raise();
        //wykrzyknik
        context.Raise();
        //skrzynka open
        isOpen = true;
        //animacja
        anim.SetBool("opened", true);
    }
    public void ChestAlreadyOpen()
    {
        //wylacz dialog
        dialogBox.SetActive(false);
        //sygnal konca animacji
        raiseItem.Raise();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
