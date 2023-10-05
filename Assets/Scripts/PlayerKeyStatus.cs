using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyStatus : MonoBehaviour
{

    public bool isBasementKeyCollected = false;
    // Update is called once per frame

    public void PlayerPickedKey()
    {
        isBasementKeyCollected = true;
    }
}
