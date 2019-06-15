using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
  public WeaponHandler wep;

  public Vector2 pos;
  public float speed = 8f;

  void Awake()
  {
    pos = transform.position;
  }

  void Update()
  {
    pos += Vector2.left * speed * Time.deltaTime;
    transform.position = pos;
  }
}
