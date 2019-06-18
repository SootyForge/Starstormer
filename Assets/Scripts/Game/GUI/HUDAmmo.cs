using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HUDAmmo : MonoBehaviour
{
  public Sprite[] numbers; // Digits for UI.
  public GameObject ammoTextPrefab; // Ammo Prefab text element to create
  public Vector3 standbyPos = new Vector3(-15, 15); // Position offscreen for standby
  public int maxDigits = 3; // The amount of digits to store offscreen for reuse

  private GameObject[] ammoTextPool;
  private int[] digits;

  // Use this for initialization
  void Start()
  {
    // Allocate memory for the ammo text pool
    ammoTextPool = new GameObject[maxDigits];
    // Loop through all available digits
    for (int i = 0; i < maxDigits; i++)
    {
      // Create a new gameObject offscreen
      GameObject clone = Instantiate(ammoTextPrefab, standbyPos, Quaternion.identity);
      // Get the Image component attached to the clone
      Image img = clone.GetComponent<Image>();
      // Set sprite to corresponding number sprite
      img.sprite = numbers[i];
      // Attach to self
      clone.transform.SetParent(transform);
      // Set name of text to index
      clone.name = i.ToString();
      // Add it to pool
      ammoTextPool[i] = clone;
    }

    // Subscribe to GameManager's added ammo event
    GameManager.Instance.ammoDisplay += UpdateAmmo;

    // Update ammo to start on zero
    UpdateAmmo(0);
  }

  public void UpdateAmmo(int ammo)
  {
    // Convert score into array of digits
    int[] digits = GetDigits(ammo);
    // Loop through all digits
    for (int i = 0; i < digits.Length; i++)
    {
      // Get value of each digit
      int value = digits[i];
      // Get corresponding text element in pool
      GameObject textElement = ammoTextPool[i];
      // Get image component attached to it
      Image img = textElement.GetComponent<Image>();
      // Assign sprite to number using value
      img.sprite = numbers[value];
      // Activate text element
      textElement.SetActive(true);
    }

    // Loop through all remaining text elements in the pool
    for (int i = digits.Length; i < ammoTextPool.Length; i++)
    {
      // Deactivate that element
      ammoTextPool[i].SetActive(false);
    }
  }

  int[] GetDigits(int number)
  {
    List<int> digits = new List<int>();
    while (number >= 10)
    {
      digits.Add(number % 10);
      number /= 10;
    }
    digits.Add(number);
    digits.Reverse();
    return digits.ToArray();
  }
}
