/*using System;
using UnityEngine;

public class MoveHandler:MonoBehaviour
{
    public event Action<Vector2> OnPlayerMove; 
    [SerializeField] LayerMask groundLayer;

    private Vector2 targetPos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var world = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hitCirle = Physics2D.CircleCast(world,1f,Vector2.down,0.1f,groundLayer);
            if (hitCirle != null)
            {
                targetPos = hitCirle.point;
                OnPlayerMove?.Invoke(targetPos);
            }
            
        }
    }
}*/