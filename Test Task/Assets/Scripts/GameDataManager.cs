using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public List<MovePoint> CashMovePoints;
    public List<MovePoint> GetMovePoints;

    public List<ClientAI> clients;
    

    public 

    // Start is called before the first frame update
    void Awake()
    {
        CollectMovePoints();
        StartCoroutine(UpdateList());
    }

    IEnumerator UpdateList()
    {
        AddNewClients();
        RemoveOldClients();
        yield return new WaitForSeconds(3);
        //foreach (var clientElement in clients)
        //{
        //    clientElement.ChangeState();
        //}

    }

    private void AddNewClients()
    {
        GameObject[] clientsObjects = GameObject.FindGameObjectsWithTag("Client");

        foreach (GameObject clientObj in clientsObjects)
        {
            ClientAI client = clientObj.GetComponent<ClientAI>();
            if (client.clientStates == ClientStates.Hungry && !clients.Contains(client)) 
            {
                clients.Add(client);
            }
        }
    }

    private void RemoveOldClients()
    {
        GameObject[] clientsObjects = GameObject.FindGameObjectsWithTag("Client");

        foreach (GameObject clientObj in clientsObjects)
        {
            ClientAI client = clientObj.GetComponent<ClientAI>();
            if (client.clientStates == ClientStates.Left && clients.Contains(client))
            {
                clients.Remove(client);
            }
        }
    }

    private void CollectMovePoints()
    {
        GameObject[] movePointObjects = GameObject.FindGameObjectsWithTag("MovePoints");

        foreach (GameObject movePointObject in movePointObjects)
        {
            bool moveTypeCash = movePointObject.GetComponent<MovePoint>().pointType == MovePointType.Cash
                ? true
                : false;

            if (moveTypeCash)
            {
                CashMovePoints.Add(movePointObject.GetComponent<MovePoint>());
            }
            else
            {
                GetMovePoints.Add(movePointObject.GetComponent<MovePoint>());
            }
        }
    }
}
