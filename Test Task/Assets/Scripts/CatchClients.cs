using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public enum zoneType
{
    Cash,
    Give
}

public class CatchClients : MonoBehaviour
{
    public zoneType zoneType;
    public ClientAI c;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Client")
        {
            Debug.Log("cat");
            SendClient(other.gameObject);
        }
    }

    private void SendClient(GameObject catchedClient)
    {
        switch (zoneType)
        {
            case zoneType.Cash:
                Cash cash = FindFirstObjectByType<Cash>();
                cash.client = catchedClient.GetComponent<ClientAI>();
                
                break;
            case zoneType.Give:
                Give give = FindFirstObjectByType<Give>();
                give.client = catchedClient.GetComponent<ClientAI>();
                
                break;
        }
    }
}
