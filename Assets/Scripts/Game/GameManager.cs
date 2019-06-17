using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public bool gameOver = false;
  public int score = 0;

  public static GameManager Instance = null;

  public delegate void ScoreAddedCallback(int score);
  public ScoreAddedCallback scoreAdded;

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
    // The bird cant score if there is a game over
    if (gameOver)
    {
      // Exit the function
      return;
    }

    // Increase the score
    score += points;

    // If there is a function subscribed
    if (scoreAdded != null)
    {
      // Call an event to state that a score has been added
      scoreAdded.Invoke(score);
    }
  }

  public void PlayerDied()
  {
    // Set game over to true
    gameOver = true;
  }
}
