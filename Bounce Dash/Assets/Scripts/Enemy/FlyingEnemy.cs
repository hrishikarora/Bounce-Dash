using UnityEngine;

public class FlyingEnemy : BaseEnemy
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float moveRange = 3f;

    [SerializeField] private bool flyHorizontal = true;
    [SerializeField] private bool flyVertical = false;

    private Vector3 startPosition;
    private float moveTimer;

    private void Start()
    {
        startPosition = transform.position;
        moveTimer = 0f;
    }

    public override void Move()
    {
        moveTimer += Time.deltaTime * speed;
        float offset = Mathf.Sin(moveTimer) * moveRange;

        Vector3 newPos = startPosition;

        if (flyHorizontal)
            newPos.x += offset;

        if (flyVertical)
            newPos.y += offset;

        transform.position = newPos;
    }
}