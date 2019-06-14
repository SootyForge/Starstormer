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
  //public int currentWeaponIndex = 0;
  //public List<Weapon> weapons = new List<Weapon>();

  private PlayerControls player;

  void Awake()
  {
    player = GetComponent<PlayerControls>();
  }
  void Start()
  {
    //// Select first one
    //SelectWeapon(0);
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "Weapon")
    {

    }
  }

  void LateUpdate()
  {
    // If there is a weapon
    if (currentWeapon)
    {
      // Check fire mode.
      if (currentWeapon.isAuto == false)
      {
        bool fire1 = Input.GetButtonDown("Fire1");
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

      else
      {
        bool fire2 = Input.GetButton("Fire1");
        if (fire2)
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
  }
  void DisableAllWeapons()
  {
    // Disable GameObject
    currentWeapon.gameObject.SetActive(false);
  }
  void SwitchWeapon(int index)
  {
    //// Check if index is within bounds
    //if (index >= 0 && index < weapons.Count)
    //{
    //  // Disable all weapons
    //  DisableAllWeapons();
    //  // Select currentWeapon
    //  currentWeapon = weapons[index];
    //  // Enable currentWeapon
    //  currentWeapon.gameObject.SetActive(true);
    //  // Update currentWeaponIndex
    //  currentWeaponIndex = index;
    //}
  }

  public void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0)
    {
      gameObject.SetActive(false);
      print("Ya dead!");
    }
  }
  public void Heal(int heal)
  {
    health += heal;
  }
}
