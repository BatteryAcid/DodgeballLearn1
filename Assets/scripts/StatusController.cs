using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
   public const string WaitingOnMatch = "Waiting on match...";
   public const string YouWon = "You Won!";
   public const string YouLost = "You Lost!";
   public const string Playing = "Match found. Playing!";
   public const string GameOver = "Game Over";

   private Text _outcomeText;
   
   public void SetText(string text) {
      _outcomeText.text = text;
   }

   void Start()
   {
      _outcomeText = GetComponent<Text>();
      _outcomeText.text = WaitingOnMatch;
   }

   public bool IsGamePlayActive() {
      return _outcomeText.text == Playing;
   }
}
