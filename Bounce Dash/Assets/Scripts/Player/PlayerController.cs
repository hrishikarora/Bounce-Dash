using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Controls player horizontal movement using Rigidbody2D velocity.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField, Tooltip("Horizontal movement speed in units per second")] private float movementSpeed = 5f;

    private float horizontalInput;

    private void Reset()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Read horizontal input every frame
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // Apply horizontal movement velocity in physics update
        Vector2 velocity = rb.linearVelocity;
        velocity.x = horizontalInput * movementSpeed;
        rb.linearVelocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<IBounceable>(out var bounceable))
        {
            bounceable.OnPlayerBounce(other,rb);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.OnCollect(gameObject);
        }
    }

}