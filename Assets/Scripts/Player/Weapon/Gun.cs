﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Projectiles;

public class Gun : MonoBehaviour
{
  //public bool isEmpty = true;
  //public int currentAmmo = 0;
  //public Transform shotOrigin;
  //public GameObject projectilePrefab;
  //
  //private int maxAmmo = 999;
  //
  //public override void Attack()
  //{
  //  if (!isEmpty)
  //  {
  //    // Reset timer & canShoot to false
  //    currentAmmo--;
  //    // Call Weapon's attack
  //    base.Attack();
  //  }
  //  // Auto-Reload
  //  if (currentAmmo <= 0)
  //  {
  //    isEmpty = true;
  //    attackTimer = 10f;
  //    // Switch
  //  }
  //  else
  //  {
  //    isEmpty = false;
  //  }
  //  // Get some values
  //  Camera attachedCamera = Camera.main; // Note (Manny): Pass the reference into weapon somehow
  //  Transform camTransform = attachedCamera.transform; // Shortening Camera's Transform to 'camTransform'
  //  Vector3 lineOrigin = shotOrigin.position; // Where the bullet line starts
  //  Vector3 direction = camTransform.right; // Forward direction of camera
  //                                            // Spawn Bullet
  //  GameObject clone = Instantiate(projectilePrefab, camTransform.position, camTransform.rotation);
  //  Projectile projectile = clone.GetComponent<Projectile>();
  //  projectile.Fire(lineOrigin, direction);
  //
  //  
  //}
}