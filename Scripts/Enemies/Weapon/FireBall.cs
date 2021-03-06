using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private int _demage = 1;

    public void SetDemage(int demage)
    {
        _demage = demage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player> (out Player player))
        {
            player.ApplyDemage(_demage);
            Destroy(gameObject);
        }        
    }    
}
