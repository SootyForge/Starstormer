using UnityEngine;
using System;

[Serializable]
public class WeaponProperties
{
  public int damage;
  public float attackRate;
  public bool isEmpty, isAuto;
  public int ammo;
  public int addAmmo;
  public GameObject projectile;
  public Sprite shipSkin;
}
