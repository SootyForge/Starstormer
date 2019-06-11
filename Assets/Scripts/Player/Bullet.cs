using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Projectiles;

namespace Projectiles
{
  [RequireComponent(typeof(Rigidbody2D))]
  public class Bullet : Projectile
  {
    public float speed = 50f;
    public GameObject effectPrefab;
    public Transform line, effectSpawn;

    [HideInInspector]
    public Transform hitObject;

    private Rigidbody2D rigid;
    private Vector2 start, end, effectPos;

    void Awake()
    {
      rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
      start = transform.position;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
      end = transform.position;
      effectPos = effectSpawn.position;

      // Get bulletDirection
      Vector2 bulletDir = end - start;

      hitObject = col.transform;

      // Spawn a BulletHole on that contact point
      GameObject clone = Instantiate(effectPrefab, effectPos, transform.rotation);

      DealDamage();

      // Destroy self.
      Destroy(gameObject);
    }
    public override void Fire(Vector3 lineOrigin, Vector3 direction)
    {
      // Set line position to origin
      line.position = lineOrigin;
      // Set bullet flying in direction with speed
      rigid.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    public void DealDamage()
    {
      IHealth health = hitObject.GetComponent<IHealth>();

      if(health != null)
      {
        health.TakeDamage(damage);
      }
    }
  }
}
