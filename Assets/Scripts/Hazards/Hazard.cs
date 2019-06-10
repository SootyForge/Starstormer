using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour, IHealth
{
  public HazardProperties h;
  public GameObject destroyFX;
  public Vector2 pos;

  private Transform hitObject;

  void Awake()
  {
    pos = transform.position;
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.layer == 9)
    {
      hitObject = col.transform;
      DealDamage();
      GameObject clone = Instantiate(destroyFX, hitObject);
      Destroy(gameObject); 
    }
  }

  public void Update()
  {
    pos += Vector2.left * h.speed * Time.deltaTime;
    transform.position = pos;
  }

  public void Heal(int heal)
  {
    throw new System.NotImplementedException();
  }

  public void TakeDamage(int damage)
  {
    h.health -= damage;
    if (h.health <= 0)
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
      health.TakeDamage(h.damage);
    }
  }
}
