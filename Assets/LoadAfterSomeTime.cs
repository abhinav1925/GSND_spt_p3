using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAfterSomeTime : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
       if(FindObjectOfType<DialogueController>().dialEnd)
        {
            this.gameObject.SetActive(true);
        }
    }
}
