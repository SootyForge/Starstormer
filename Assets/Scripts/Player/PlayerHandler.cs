using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControls))]
public class PlayerHandler : MonoBehaviour, IHealth
{
  [Header("Stats")]
  public int health = 5;

  [Header("Weapon")]
  public Weapon currentWeapon;
  public int currentWeaponIndex = 0;

  private PlayerControls player;

  void Awake()
  {
    player = GetComponent<PlayerControls>();
  }
  // void Start()
  // {
  //   // Select first one
  //   SelectWeapon(0);
  // }
  void FixedUpdate()
  {
    // If there is a weapon
    if (currentWeapon)
    {
      bool fire1 = Input.GetButton("Fire1");
      if (fire1)
      {
        // Check if weapon can shoot
        if (currentWeapon.canShoot)
        {
          // Shoot the weapon
          currentWeapon.Attack();
        }
      }
    }
  }
  // void DisableAllWeapons()
  // {
  //   // // Loop through all weapons
  //   // foreach (var item in weapons)
  //   // {
  //   //   // Disable each GameObject
  //   //   item.gameObject.SetActive(false);
  //   // }
  // }
  // void SelectWeapon(int index)
  // {
  //   // // Check if index is within bounds
  //   // if (index >= 0 && index < weapons.Count)
  //   // {
  //   //   // Disable all weapons
  //   //   DisableAllWeapons();
  //   //   // Select currentWeapon
  //   //   currentWeapon = weapons[index];
  //   //   // Enable currentWeapon
  //   //   currentWeapon.gameObject.SetActive(true);
  //   //   // Update currentWeaponIndex
  //   //   currentWeaponIndex = index;
  //   // }
  // }

  public void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0)
    {
      print("Ya dead!");
    }
  }
  public void Heal(int heal)
  {
    health += heal;
  }
}
