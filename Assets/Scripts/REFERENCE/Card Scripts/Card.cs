using UnityEngine;

namespace CardGame
{
  [CreateAssetMenu(fileName = "Card", menuName = "New Card")]
  public class Card : ScriptableObject
  {
    public CardType cardType;
    public CardProperties[] properties;
  } 
}
