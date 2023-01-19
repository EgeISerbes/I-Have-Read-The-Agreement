using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private System.Action OnCollect;

    public void Init(System.Action OnCollect)
    {
        this.OnCollect = OnCollect;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Virus"))
        {
            OnCollect();
            Destroy(gameObject);
        }
    }
}
