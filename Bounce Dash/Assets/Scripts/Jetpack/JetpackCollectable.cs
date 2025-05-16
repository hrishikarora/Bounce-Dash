using Unity.VisualScripting;
using UnityEngine;

public class JetpackCollectable : MonoBehaviour, ICollectable
{
    public void OnCollect(GameObject player)
    {
        this.gameObject.SetActive(false);
        player.GetComponent<JetpackManager>().ActivateJetpack();
    }
}
