using UnityEngine;

public interface IBounceable
{
    float JumpForce { get; }
    void OnPlayerBounce(Collision2D collision,Rigidbody2D rigidbody);
}
