﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/SteeredCohesion")]
public class SteeredCohesionBehavior : FilteredFlockBehavior
{

    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;
        //add all the points together and average
        Vector3 cohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            cohesionMove += (Vector3)item.position;
        }
        cohesionMove /= context.Count;


        //create offset from agent position
        cohesionMove -= (Vector3)agent.transform.position;
        cohesionMove = Vector3.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }


}
