using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("OnShoot");
        }
        else if(context.canceled)
        {
            Debug.Log("No Shoot");
        }
    }
}
