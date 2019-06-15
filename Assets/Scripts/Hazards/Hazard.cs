using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour, IHealth
{
  public HazardHandler h;
  public GameObject destroyFX;
  public Vector2 pos;

  private int health, damage;
  private float speed;
  private Transform hitObject;

  void Awake()
  {
    pos = transform.position;
    health = h.stat.health;
    damage = h.stat.damage;
    speed = h.stat.speed;
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.tag == "Player")
    {
      hitObject = col.transform;
      DealDamage();
      GameObject clone = Instantiate(destroyFX);
      clone.transform.position = transform.position;
      Destroy(gameObject);
    }
    if (col.gameObject)
    {
      Destroy(gameObject);
    }
  }

  public void Update()
  {
    pos += Vector2.left * speed * Time.deltaTime;
    transform.position = pos;
  }

  public void Heal(int heal)
  {
    throw new System.NotImplementedException();
  }

  public void TakeDamage(int damage)
  {
   health -= damage;
    if (health <= 0)
    {
      GameObject clone = Instantiate(destroyFX, transform.position, transform.rotation);
      destroyFX.transform.position = gameObject.transform.position;
      Destroy(gameObject);
    }
  }

  public void DealDamage()
  {
    IHealth health = hitObject.GetComponent<IHealth>();

    if (health != null)
    {
      health.TakeDamage(damage);
    }
  }
}
