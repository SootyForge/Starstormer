using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJunkRemover : MonoBehaviour
{
  void Awake()
  {
    Destroy(gameObject, 2f);
  }
}
