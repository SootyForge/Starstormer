using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  public int damage = 10;
  public float attackRate = 10f;

  [HideInInspector] public bool canShoot = false;

  private float attackTimer = 0f;

  // Update is called once per frame
  void Update()
  {
    // Count up shoot timer
    attackTimer += Time.deltaTime;
    // If shoot timer reaches shoot rate
    if (attackTimer >= 1f / attackRate)
    {
      // Can shoot!
      canShoot = true;
    }
  }

  public virtual void Attack()
  {
    // Reset attack timer
    attackTimer = 0f;
    // Reset can shoot
    canShoot = false;
  }
}
