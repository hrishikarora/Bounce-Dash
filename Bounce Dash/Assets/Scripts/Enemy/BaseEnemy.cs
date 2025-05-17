using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    // Enemy movement logic
    public abstract void Move();

    // Called when player hits enemy
    public virtual void OnPlayerCollision(GameObject player)
    {
        GameManager.Instance.GameOver();
    }

    // Detect collision with player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerCollision(collision.gameObject);
        }
    }

    private void Update()
    {
        Move();
    }
}