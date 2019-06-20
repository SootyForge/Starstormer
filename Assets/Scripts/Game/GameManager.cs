using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public bool gameOver = false;
  public int score = 0;
  public int curAmmo = 0;

  public static GameManager Instance = null;

  public delegate void ScoreAddedCallback(int score);
  public ScoreAddedCallback scoreAdded;

  public delegate void CurrentAmmoCallback(int ammo);
  public CurrentAmmoCallback ammoDisplay;

  // Use this for initialization
  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(this);
    }
  }

  public void IncreaseScore(int points)
  {
    // Can't score if there is a game over.
    if (gameOver)
    {
      return;
    }

    // Increase score.
    score += points;

    // If there is a function subscribed.
    if (scoreAdded != null)
    {
      if (score < 9999999)
      {
        // Add score to scoreAdded callback.
        scoreAdded.Invoke(score);
      }
      else
      {
        // Clamp score display.
        scoreAdded(9999999);
      }
    }
  }

  public void AmmoCount(int newAmmo)
  {
    if (gameOver)
    {
      return;
    }

    curAmmo = newAmmo;

    if (ammoDisplay != null)
    {
      ammoDisplay.Invoke(curAmmo);
    }
  }

  public void PlayerDied()
  {
    // Set game over to true
    gameOver = true;
  }
}
