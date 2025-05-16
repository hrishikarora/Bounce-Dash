using System;
using UnityEngine;

public class JetpackManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private GameObject jetpackGameObject;
    [SerializeField] private float jetpackDuration = 10f;
    [SerializeField] private float jetpackSpeed = 3f;
    
    private bool jetpackActive = false;
    private float jetpackTimer = 0f;

    private void Reset()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (jetpackActive)
        {
            jetpackTimer -= Time.deltaTime;
            if (jetpackTimer > 0f)
            {
                playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jetpackSpeed);
            }
            else
            {
                jetpackActive = false;
                jetpackGameObject.SetActive(false);
            }
        }
    }

    public void ActivateJetpack()
    {
        jetpackActive = true;
        jetpackTimer = jetpackDuration;
        jetpackGameObject.SetActive(true);
    }
}
