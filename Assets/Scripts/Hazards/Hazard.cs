using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour, IHealth
{
  public HazardProperties h;
  public GameObject destroyFX;
  public Vector2 pos;

  void Awake()
  {
    pos = transform.position;
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
      GameObject clone = Instantiate(destroyFX);
      Destroy(gameObject);
    }
  }
}
