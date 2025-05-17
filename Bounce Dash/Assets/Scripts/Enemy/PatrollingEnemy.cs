using UnityEngine;

public class PatrollingEnemy : BaseEnemy
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform groundCheck; // child object at front foot position
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private int direction = 1;

    public override void Move()
    {
        // Move horizontally
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        // Raycast downwards in front to detect ground
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        if (hit.collider == null)
        {
            Flip();
        }
    }

    private void Flip()
    {
        direction *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}