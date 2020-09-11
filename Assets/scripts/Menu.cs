using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   [SerializeField]
   private StatusController _statusController = null;

   private Button quitButton;
   private Button findMatchButton;

   void Start()
   {
      quitButton = GameObject.Find("Quit").GetComponent<Button>();
      findMatchButton = GameObject.Find("FindMatchAndPlay").GetComponent<Button>();
   }

   public void OnFindMatchPressed()
   {
      //Debug.Log("OnFindMatchPressed clicked ");

      // find new match
      WebSocketService.Instance.FindMatch();

      _statusController.SetText(StatusController.WaitingOnMatch);

      quitButton.gameObject.SetActive(true);
      findMatchButton.gameObject.SetActive(false);
   }

   public void OnQuitPressed()
   {
      //Debug.Log("OnQuitPressed clicked ");

      WebSocketService.Instance.QuitGame();

      quitButton.gameObject.SetActive(false);
      findMatchButton.gameObject.SetActive(true);

      _statusController.SetText(StatusController.GameOver);
   }

   public void ShowFindMatch()
   {
      quitButton.gameObject.SetActive(false);
      findMatchButton.gameObject.SetActive(true);
   }

   public void Disconnected() {
      quitButton.gameObject.SetActive(false);
      findMatchButton.gameObject.SetActive(true);
      _statusController.SetText(StatusController.GameOver);
   }
}
