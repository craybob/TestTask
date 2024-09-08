using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScr : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Client")
        {
            other.gameObject.GetComponent<ClientAI>().clientStates = ClientStates.Left;
        }
    }

}
