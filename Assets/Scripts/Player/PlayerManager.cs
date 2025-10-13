using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private MoveHandler moveHandler;
    private void OnEnable()
    {
        moveHandler.OnPlayerMove += PlayerMove;
    }

    private void OnDisable()
    {
        moveHandler.OnPlayerMove -= PlayerMove;
    }

    private void PlayerMove(Vector2 targetPos)
    {
        var shortestDistance=Vector2.Distance(transform.position,targetPos);
    }
}
