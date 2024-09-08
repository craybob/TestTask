using UnityEngine;
public enum MovePointType
{
    Cash,
    Get
}

public class MovePoint : MonoBehaviour
{
    public bool isPlaceFree = true;
    public MovePointType pointType ;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Client")
        {
            isPlaceFree = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Client")
        {
            isPlaceFree = true;
        }
    }
}
