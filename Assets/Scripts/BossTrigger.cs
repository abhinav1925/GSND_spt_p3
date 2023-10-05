using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
   public GameObject InteractMenu;
   
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
         InteractMenu.SetActive(false);
         // Spawn boss here
      }
   }

   private void OnTriggerExit(Collider other)
   {
      InteractMenu.SetActive(false);
   }
}
