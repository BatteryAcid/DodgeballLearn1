using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
   private Text _outcomeText;

   public void SetText(string text) {
      _outcomeText.text = text;
   }

   void Start()
   {
      _outcomeText = GetComponent<Text>();
      _outcomeText.text = "Playing";
   }
}
