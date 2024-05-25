using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatroling : NPCStrategy
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public NPCPatroling(GameObject target, Transform[] patrolPoints, float moveSpeed, int patrolDestination) : base(target)
    {
        this.patrolPoints = patrolPoints;
        this.moveSpeed = moveSpeed;
        this.patrolDestination = patrolDestination;
    }

    public override void Act()
    {
        nPC.transform.position = Vector2.MoveTowards(nPC.transform.position, patrolPoints[patrolDestination].position, moveSpeed);
        if (Vector2.Distance(nPC.transform.position, patrolPoints[patrolDestination].position) < 0.2f)
        {
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
        }
    }
}
