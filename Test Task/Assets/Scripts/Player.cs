using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private MoveHandler _movementHandler;

    public Vector3 colliderPosOffset;
    public float colliderRadius;
    public ClientAI client;

    //Move Properties
    public float _speed;
    public int money = 0;
    

    [Inject]
    public void Construct(MoveHandler movementHandler)
    {
        _movementHandler = movementHandler;
    }

    // Start is called before the first frame update
    void Start()
    {
        _movementHandler.animator = GetComponent<Animator>();
        _movementHandler.joystick = FindFirstObjectByType<FloatingJoystick>();
        _movementHandler.speed = _speed;
        _movementHandler.transformObj = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _movementHandler.Move();
        
    }

    
}
