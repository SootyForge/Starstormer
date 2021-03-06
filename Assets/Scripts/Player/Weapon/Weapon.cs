﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Projectiles;

public class Weapon : MonoBehaviour
{
  public WeaponHandler wep;

  public int damage = 1;
  public float attackRate = 10f;
  public bool isEmpty = true, isAuto = false;
  public int currentAmmo = 0;
  public Transform shotOrigin;
  public GameObject projectilePrefab;

  private int maxAmmo = 999;

  [HideInInspector] public bool canShoot = false;

  private float attackTimer = 0f;

  // Set stats to default wep.
  void Start()
  {
    if (wep == null)
    {
      wep = Resources.Load<WeaponHandler>("Data/Weapons/P1S1");
    }

    SetWeapon();
  }

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
    // Auto-Reload
    if (currentAmmo <= 1)
    {
      wep = Resources.Load<WeaponHandler>("Data/Weapons/P1S1");
      // Switch
      SetWeapon();
    }
    else
    {
      isEmpty = false;
    }
    if (!isEmpty)
    {
      // Reset attack timer
      attackTimer = 0f;
      // Reset can shoot
      canShoot = false;
      // Reset timer & canShoot to false
      currentAmmo--;
    }

    GameManager.Instance.AmmoCount(currentAmmo);

    // Get some values
    Camera attachedCamera = Camera.main;
    Transform camTransform = attachedCamera.transform; // Shortening Camera's Transform to 'camTransform'
    Vector3 lineOrigin = shotOrigin.position; // Where the bullet line starts
    Vector3 direction = camTransform.right; // Forward direction of camera
    // Spawn Bullet
    GameObject clone = Instantiate(projectilePrefab, camTransform.position, camTransform.rotation);
    Projectile projectile = clone.GetComponent<Projectile>();
    projectile.Fire(lineOrigin, direction);
  }

  public void SetWeapon()
  {
    damage = wep.stat.damage;
    attackRate = wep.stat.attackRate;
    isEmpty = wep.stat.isEmpty;
    isAuto = wep.stat.isAuto;
    currentAmmo = wep.stat.ammo;
    projectilePrefab = wep.stat.projectile;
  }
}
