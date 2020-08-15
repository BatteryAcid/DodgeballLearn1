[System.Serializable]
public class GameMessage
{
   public string uuid;
   public string opcode;
   public string message;
   public string gameStatus;
   public string action;

   public GameMessage(string actionIn, string opcodeIn)
   {
      this.action = actionIn;
      this.opcode = opcodeIn;
   }
}
