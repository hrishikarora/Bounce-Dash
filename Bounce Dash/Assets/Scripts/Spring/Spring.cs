using UnityEngine;


public class Spring : MonoBehaviour, IBounceable
{
    [SerializeField, Tooltip("Force applied to player when bouncing.")]
    private float jumpForce = 8f;
    public float JumpForce => jumpForce;
    public void OnPlayerBounce(Collision2D other, Rigidbody2D rb)
    {       
        if (other.relativeVelocity.y < 0f) return;

        if (rb == null) return;

        Vector2 velocity = rb.linearVelocity;
        velocity.y = JumpForce;
        rb.linearVelocity = velocity;
    }
}
