using UnityEngine;
using UnityEngine.UI;

public class Menu : Singleton<Menu>
{
   private Button quitButton;
   private Button findMatchButton;

   void Start() {
      quitButton = GameObject.Find("Quit").GetComponent<Button>();
      findMatchButton = GameObject.Find("FindMatchAndPlay").GetComponent<Button>();
   }

   public void OnFindMatchPressed()
   {
      //Debug.Log("OnFindMatchPressed clicked ");
      
      // find new match
      WebSocketService.Instance.FindMatch();
      
      StatusController.Instance.SetText(StatusController.WaitingOnMatch);

      quitButton.gameObject.SetActive(true);
      findMatchButton.gameObject.SetActive(false);
   }

   public void OnQuitPressed()
   {
      //Debug.Log("OnQuitPressed clicked ");
      
      WebSocketService.Instance.QuitGame();
      
      quitButton.gameObject.SetActive(false);  
      findMatchButton.gameObject.SetActive(true);  

      StatusController.Instance.SetText(StatusController.GameOver);
   }

   public void showFindMatch() {
      quitButton.gameObject.SetActive(false);  
      findMatchButton.gameObject.SetActive(true);
   }
}
