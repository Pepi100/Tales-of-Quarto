using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Inventory.Model;
using Inventory;

public class QUEST : MonoBehaviour
{
    public string askLine;
    public string completedLine;

    public int amount;

    public GameObject reward;
    public ItemSO check;

    public InventoryController invPlayer;
    public TextMeshProUGUI dialogueText;

    bool isQuestCompleted = false;
    bool turnedInItems = false;

    public bool playerIsClose;
    public GameObject dialoguePanel;

    void Start()
    {
        reward.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerIsClose = true;
        if (other.CompareTag("Player"))
        {
            if (turnedInItems == false)
            {
                Debug.Log("Not checked yet");
                // Check if the required collectables are in the inventory
                if (invPlayer.getData().CheckStackableItem(check, amount))
                {
                    Debug.Log("Remove");
                    // Quest is completed, drop items and set the flag
                    isQuestCompleted = true;
                    invPlayer.getData().RemoveStackableItem(check, amount);
                }
            }

            if (isQuestCompleted == true)
            {
                Debug.Log("Quest done");
                dialogueText.text = completedLine;
                if (turnedInItems == false)
                {
                    turnedInItems = true;
                    DropQuestItems();
                }
            }
            else
            {
                Debug.Log("ask");
                dialogueText.text = askLine;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerIsClose = false;
        if (other.CompareTag("Player"))
        {
            dialogueText.text = "";
            zeroText();
        }
    }

    void DropQuestItems()
    {
        Debug.Log("drop quest item");
        Vector3 position = transform.position + new Vector3(1.5f, 0f, 0f);
        Debug.Log(position);
        GameObject go = Instantiate(reward);
        go.transform.position = position;
        go.SetActive(true);
    }
}