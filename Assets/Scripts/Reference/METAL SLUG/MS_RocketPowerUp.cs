using System.Collections;
using UnityEngine;

namespace MetalSlug
{
  public class MS_RocketPowerUp : MonoBehaviour
  {

    public MS_Player player;

    //destroy the gunspowerup
    void OnTriggerEnter2D(Collider2D collider)
    {
      if (collider.GetComponent<MS_Player>())
      {
        Debug.Log("Fire rate Upgraded ");
        Destroy(gameObject);
        player.firerate = 0f;
      }
    }
  } 
}
