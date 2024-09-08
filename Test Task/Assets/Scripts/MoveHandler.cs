using UnityEngine;

public class MoveHandler
{
    
    //Components Properties
    public Animator animator;
    public FloatingJoystick joystick;

    //Move Properties
    public float speed;
    public Transform transformObj;

    #region Move Methods
    public void Move()
    {
        Vector3 moveDirection = GetMoveDirection();
        
        bool isMove = moveDirection == Vector3.zero ? false : true;
        animator.SetBool("Move", isMove);

        if (isMove)
        {
            transformObj.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }

    private Vector3 GetMoveDirection()
    {
        float xDirertion = joystick.Horizontal;
        float zDirection = joystick.Vertical;
        
        Vector3 moveDirection = GetCamRotation(zDirection, xDirertion);

        return moveDirection;

    }
    private Vector3 GetCamRotation(float directionZ, float directionX)
    {
        // --- Character rotation --- 

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Relate the front with the Z direction (depth) and right with X (lateral movement)
        forward = forward * directionZ;
        right = right * directionX;

        if (directionX != 0 || directionZ != 0)
        {
            float angle = Mathf.Atan2(forward.x + right.x, forward.z + right.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transformObj.rotation = Quaternion.Slerp(transformObj.rotation, rotation, 0.15f);
        }

        // --- End rotation ---

        //Vector3 verticalDirection = Vector3.up * Physics.gravity.y;
        Vector3 horizontalDirection = forward + right;

        Vector3 moviment = horizontalDirection;

        return moviment;
    }
    #endregion

}
