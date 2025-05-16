using UnityEngine;

/// <summary>
/// Abstract base class for all bouncing platforms.
/// Derived classes must specify the jump force applied to the player.
/// </summary>
public abstract class BasePlatform : MonoBehaviour, IBounceable
{
    /// <summary>
    /// The vertical force applied to the player upon collision.
    /// </summary>
    public abstract float JumpForce { get; }
    
    public virtual void OnPlayerBounce(Collision2D collision, Rigidbody2D rb)
    {
        // Only bounce if player is moving down onto platform
        if (collision.relativeVelocity.y < 0f) return;

        if (rb == null) return;

        Vector2 velocity = rb.linearVelocity;
        velocity.y = JumpForce;
        rb.linearVelocity = velocity;

        AfterBounce();
    }

    /// <summary>
    /// Implement this class if you want additional functionality after bounce.
    /// </summary>
    /// <param name="rb">Rigidbody 2D</param>
    protected virtual void AfterBounce()
    {
        
    }


}