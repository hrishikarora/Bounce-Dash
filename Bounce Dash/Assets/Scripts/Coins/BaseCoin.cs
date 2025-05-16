using UnityEngine;

/// <summary>
/// Base class for all coins.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class BaseCoin : MonoBehaviour, ICollectable
{
    protected abstract int CoinAmount { get; } // The amount of coins awarded to the player.
    
    public void OnCollect(GameObject player)
    {
        Debug.Log($"Player collected {CoinAmount} coin(s).");
        Destroy(gameObject); //TODO: Object pool all the coins
        AfterCollect();
    }
    

    /// <summary>
    /// Generic collet method for all derived classes
    /// Can be overriden for individual base class
    /// </summary>
    protected virtual void AfterCollect(){ }
    
    
    private void Reset()
    {
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }


}