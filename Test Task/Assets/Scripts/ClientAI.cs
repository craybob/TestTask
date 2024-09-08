
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public enum ClientStates
{
    Hungry,
    GiveCash,
    GotBurger,
    Left
}

public class ClientAI : MonoBehaviour
{
    public ClientStates clientStates = ClientStates.Hungry;
    

    private NavMeshAgent agent;
    private Vector3 targetPos;
    [SerializeField] private Vector3 targetPosOffset;
    [SerializeField] private GameDataManager _gameDataManager;

    [Inject]
    private void Constructor(GameDataManager gameDataManager)
    {
        _gameDataManager = gameDataManager;
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _gameDataManager = FindAnyObjectByType<GameDataManager>();
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState()
    {
        switch (clientStates) 
        {
            case ClientStates.Hungry:
                targetPos = GetFreeMovePoint();
                agent.SetDestination(targetPos); 
                break;

            case ClientStates.GiveCash:
                targetPos = GetFreeMovePoint();
                agent.SetDestination(targetPos);
                break;

            case ClientStates.GotBurger:
                targetPos = GetFreeMovePoint();
                agent.SetDestination(targetPos);
                break;
        }
    }

    private Vector3 GetFreeMovePoint()
    {
        switch (clientStates)
        {
            case ClientStates.Hungry:
                int indexCashMovePoints = _gameDataManager.CashMovePoints.Count - 1;
                
                for (int i = indexCashMovePoints; i >= 0; i--)
                {
                    if(_gameDataManager.CashMovePoints[i].isPlaceFree == true)
                    {
                        _gameDataManager.CashMovePoints[i].isPlaceFree = false;
                        return _gameDataManager.CashMovePoints[i].transform.position + targetPosOffset;
                    }
                    
                }
                
                break;
            case ClientStates.GiveCash:
                int indexGetMovePoints = _gameDataManager.GetMovePoints.Count - 1;

                for (int i = indexGetMovePoints; i >= 0; i--)
                {
                    if (_gameDataManager.GetMovePoints[i].isPlaceFree == true)
                    {
                        _gameDataManager.GetMovePoints[i].isPlaceFree = false;
                        return _gameDataManager.GetMovePoints[i].transform.position;
                    }
                }
                break;
            case ClientStates.GotBurger:
                return new Vector3(14, 0, 23);  
        }
        return new Vector3(16, 0, 22);
    }

    
}
