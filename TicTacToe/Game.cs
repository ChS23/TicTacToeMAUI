namespace TicTacToe;

public class Game
{
    public Players players;
    public Board board;
    
    public Game()
    {
        players = new Players();
        board = new Board();
    }

    public GameState Move(int id)
    {
        if (board.SetState(id, players.currentPlayer))
        {
            players.SwitchPlayer();
            if (board.CheckIsWin() != State.Empty)
            {
                return State.X == board.CheckIsWin() ? GameState.XWin : GameState.OWin;
            }
            else if (board.CheckIsFill())
            {
                return GameState.Draw;
            }
        }

        return GameState.InProgress;
        // ошибка   
    }

    public void EndGame()
    {
        board.SetEmptyToDisable();
    }
    
    public void PlayAgain()
    {
        players.ResetPlayer();
        board.ResetBoard();
    }
}