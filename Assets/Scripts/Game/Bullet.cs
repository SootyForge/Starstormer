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
    public Transform line;

    private Rigidbody2D rigid;
    private Vector3 start, end;

    void Awake()
    {
      rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
      start = transform.position;
    }
    // void Update()
    // {
    //   line.rotation = Quaternion.LookRotation(rigid.velocity);
    // }
    void OnCollisionEnter(Collision col)
    {
      end = transform.position;

      // Get bulletDirection
      Vector3 bulletDir = end - start;

      // Spawn a BulletHole on that contact point
      GameObject clone = Instantiate(effectPrefab);

      // Destroy self
      Destroy(gameObject);
    }
    public override void Fire(Vector3 lineOrigin, Vector3 direction)
    {
      // Set line position to origin
      line.position = lineOrigin;
      // Set bullet flying in direction with speed
      rigid.AddForce(direction * speed, ForceMode2D.Impulse);
    }
  }
}
