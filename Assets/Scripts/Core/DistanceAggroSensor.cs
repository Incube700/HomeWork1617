using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAggroSensor : MonoBehaviour
{
    private const float AggroRadiusMeters = 7.0f;

    public bool IsAggro(Transform self, Transform player)
    {
        Vector3 selfXZ = new Vector3(self.position.x, 0f, self.position.z);
        Vector3 playerXZ = new Vector3(player.position.x, 0f, player.position.z);

        float distance = (selfXZ - playerXZ).magnitude;
        float limit = AggroRadiusMeters * AggroRadiusMeters;

        bool isInsideAggroRadius = distance <= limit;
        return isInsideAggroRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, AggroRadiusMeters);
    }
}