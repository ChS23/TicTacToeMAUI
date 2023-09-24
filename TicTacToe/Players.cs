namespace TicTacToe;

public class Players
{
    public State currentPlayer;
    
    public Players()
    {
        Random random = new Random();
        currentPlayer = random.Next(0, 2) == 0 ? State.X : State.O;
    }
    
    public void SwitchPlayer()
    {
        currentPlayer = currentPlayer == State.X ? State.O : State.X;
    }
    
    public State GetPlayer()
    {
        return currentPlayer;
    }
    
    public void ResetPlayer()
    {
        Random random = new Random();
        currentPlayer = random.Next(0, 2) == 0 ? State.X : State.O;
    }
    
    public void SetPlayer(State player)
    {
        currentPlayer = player;
    }
}