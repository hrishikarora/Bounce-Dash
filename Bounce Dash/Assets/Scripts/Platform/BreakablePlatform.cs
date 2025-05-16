using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A breakable platform which can only be jumped at once.
/// </summary>
public class BreakablePlatform : BasePlatform
{
    [SerializeField, Tooltip("Force applied to player when bouncing.")]
    private float jumpForce = 8f;
    
    public override float JumpForce => jumpForce;

    protected override void AfterBounce()
    {
        Destroy(this.gameObject); //TODO: Add this to object pool
    }
}
