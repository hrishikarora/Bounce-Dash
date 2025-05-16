using UnityEngine;

/// <summary>
/// Abstract base class for all bouncing platforms.
/// Derived classes must specify the jump force applied to the player.
/// </summary>
public abstract class BasePlatform : MonoBehaviour
{
    /// <summary>
    /// The vertical force applied to the player upon collision.
    /// </summary>
    protected abstract float JumpForce { get; }

    /// <summary>
    /// Handles bouncing the player when colliding from above.
    /// </summary>
    /// <param name="collision">Collision info</param>
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y > 0f) return;

        if (!collision.collider.CompareTag("Player")) return;

        Rigidbody2D rb = collision.collider.attachedRigidbody;
        if (rb == null) return;

        Vector2 velocity = rb.linearVelocity;
        velocity.y = JumpForce;
        rb.linearVelocity = velocity;
    }
}