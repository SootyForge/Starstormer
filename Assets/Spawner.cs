using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public GameObject[] hzdZone;
  public float zoneTrigger = 2f;
  public float zoneTimer = 20f;

  void Update()
  {
    zoneTrigger -= Time.deltaTime;
    if (zoneTrigger <= 0f)
    {
      GameObject clone = Instantiate(hzdZone[Random.Range(0, hzdZone.Length)]);
      zoneTrigger = zoneTimer;
    }
  }
}
