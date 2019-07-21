using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerBehavior>().Health += 5;
            Destroy(this.gameObject);
        }
        
    }
}
