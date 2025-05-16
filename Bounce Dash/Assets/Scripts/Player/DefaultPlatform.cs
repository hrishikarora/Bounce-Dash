using UnityEngine;

/// <summary>
/// A basic platform that applies a specified jump force to the player upon collision.
/// </summary>
public class DefaultPlatform : BasePlatform
{
    [SerializeField, Tooltip("Force applied to player when bouncing.")]
    private float jumpForce = 8f;
    
    //The vertical force applied to the player on collision.
    protected override float JumpForce => jumpForce;
}