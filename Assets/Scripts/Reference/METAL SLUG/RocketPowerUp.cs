using System.Collections;
using UnityEngine;

public class RocketPowerUp : MonoBehaviour
{

    public Player player;

    //destroy the gunspowerup
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            Debug.Log("Fire rate Upgraded ");
            Destroy(gameObject);
            player.firerate = 0f;
        }
    }
}
