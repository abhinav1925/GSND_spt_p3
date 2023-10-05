using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class CollectKey : MonoBehaviour
{
    public GameObject InteractMenu;
    public GameObject UpdatedObjectivePanel;
    public GameObject ObjectivePanel;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // UI to press E and pick key
            InteractMenu.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            //Player obtained basement staircase key
            InteractMenu.SetActive(false);
            ObjectivePanel.SetActive(false);
            UpdatedObjectivePanel.SetActive(true);
            Player.GetComponent<PlayerKeyStatus>().isBasementKeyCollected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InteractMenu.SetActive(false);
        }
    }
}
