using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
   public GameObject InteractMenu;
    public GameObject Ghost;
    GameObject spawned;
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
            //InteractMenu.SetActive(false);
            // Spawn boss here
            spawned =  Instantiate(Ghost, new Vector3(99.3399963f, 38.5f, 40.3100014f), Quaternion.identity);
            StartCoroutine(Tempdisable());
      }
   }

   private void OnTriggerExit(Collider other)
   {
      InteractMenu.SetActive(false);
   }

    IEnumerator Tempdisable()
    {
        
        yield return new WaitForSeconds(2f);
        spawned.GetComponentInChildren<SphereCollider>().enabled = true;

    }
}
