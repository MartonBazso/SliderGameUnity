using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public delegate void OnPlayerMovement(Vector2 moveDirection);
    public event OnPlayerMovement OnPlayerMove;

    public void PlayerMove(Vector2 moveDirection)
    {
        if (OnPlayerMove != null)
        {
            OnPlayerMove(moveDirection);
        }
    }

    public delegate void OnPlayerCollide(Collision collision);
    public event OnPlayerCollide OnPlayerCollision;

    public void PlayerCollide(Collision collision)
    {
        if (OnPlayerCollision != null)
        {
            OnPlayerCollision(collision);
        }
    }
}
