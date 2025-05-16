using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // TODO: Replace with event-based reference acquisition.
    [SerializeField, Tooltip("Time it takes to reach target height. Lower = faster.")]
    private float smoothTime = 0.5f;

    private Vector3 currentVelocity; // Stores camera's current velocity for smooth damp

    private void LateUpdate()
    {
        if (player == null) return; // safety check

        if (ShouldFollowPlayer())
        {
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        }
    }


    private bool ShouldFollowPlayer() => player.position.y > transform.position.y;
}
