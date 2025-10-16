using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer;
    
    private bool arrived;
    private Vector2 targetPos;

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var world = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hitCirle = Physics2D.RaycastAll(world, Vector2.down, 0.5f, groundLayer);
            //print(hitCirle.transform.tag+" tagg");
            if (hitCirle != null&&hitCirle.Any(x=>x.transform.tag!="Enemy"))
            {
                targetPos = hitCirle[0].point;
                agent.SetDestination(targetPos);
            }
            
        }
    }
}
