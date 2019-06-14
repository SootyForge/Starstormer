using UnityEngine;

namespace CardGame
{
  public class CardVisuals : MonoBehaviour
  {
    public Card card;
    public CardVisualProperties[] properties;
    public GameObject statHolder;
    private void Start()
    {
      LoadCard(card);
    }
    public void LoadCard(Card c)
    {
      if(c == null)
      {
        return;
      }
      card = c;
      //c.cardType.OnSetType(this);
      for (int i = 0; i < c.properties.Length; i++)
      {
        CardProperties cp = c.properties[i];
        CardVisualProperties p = GetProperties(cp.element);
        if(p == null)
        {
          continue;
        }
        if(cp.element is ElementInt)
        {
          //if int display on text UI
          p.text.text = cp.intValue.ToString();
        }
        if(cp.element is ElementText)
        {
          //if text display on text UI
          p.text.text = cp.stringValue;
        }
        if(cp.element is ElementImage)
        {
          //if image/sprite display on image UI
          p.img.sprite = cp.sprite;
        }
      }
    }
    public CardVisualProperties GetProperties(Element e)
    {
      CardVisualProperties result = null;
      for (int i = 0; i < properties.Length; i++)
      {
        if(properties[i].element == e)
        {
          result = properties[i];
          break;
        }
      }
      return result;
    }
  } 
}
