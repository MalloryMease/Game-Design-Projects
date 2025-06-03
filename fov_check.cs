using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class fov_check : skinwalker_controller
{
    protected float radius = 10f;
    protected float angle = 90f;
    [SerializeField] protected GameObject player;
    [SerializeField] protected LayerMask targetMask;
    [SerializeField] protected LayerMask obstructionMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        FieldOfViewCheck();
        Debug.Log("in FOV: " + player_in_sight);
    }

    

    private void FieldOfViewCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    player_in_sight = true;
                }
                else { player_in_sight = false; }

            }
            else { player_in_sight = false; }
        }

        else if (player_in_sight)
        {
            player_in_sight = false;
        }
        
    }
}
