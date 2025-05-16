using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // TODO: Replace with event-based reference acquisition.

    private void LateUpdate()
    {
        if (player == null) return; // safety check

        if (ShouldFollowPlayer())
        {
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }
    
    //As name suggests, it tells whether camera should follow player
    private bool ShouldFollowPlayer() => player.position.y > transform.position.y;
}
