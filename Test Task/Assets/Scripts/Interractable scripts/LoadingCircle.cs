using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadingCircle : MonoBehaviour
{
    private InterractableHandler _interractableHandler;
    private Player _player;

    [Inject]
    public void Construct(InterractableHandler interractableHandler, Player player)
    {
        _interractableHandler = interractableHandler;
        _player = player;
    }

    private void FixedUpdate()
    {
        PlayerFollow();
    }

    private void PlayerFollow()
    {
        transform.position = new Vector3(_player.transform.position.x + 2f, _player.transform.position.y + 3.5f, _player.transform.position.z);
        transform.LookAt(Camera.main.transform.position);
    }
}
