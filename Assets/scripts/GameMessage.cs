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
      action = actionIn;
      opcode = opcodeIn;
   }

   public GameMessage(string actionIn, string opcodeIn, string messageIn)
   {
      action = actionIn;
      opcode = opcodeIn;
      message = messageIn;
   }
}
