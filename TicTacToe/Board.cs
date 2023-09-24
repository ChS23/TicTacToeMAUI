namespace TicTacToe;

public class Board
{
    private State[] _board = new []
    {
        State.Empty, State.Empty, State.Empty,
        State.Empty, State.Empty, State.Empty,
        State.Empty, State.Empty, State.Empty
    };
    
    public State[] GetBoard()
    {
        return _board;
    }
    
    public bool SetState(int cellId, State state)
    {
        if (_board[cellId - 1] == State.Empty)
        {
            _board[cellId - 1] = state;
            return true;
        }

        return false;
    }
    
    public void ResetBoard()
    {
        _board = new []
        {
            State.Empty, State.Empty, State.Empty,
            State.Empty, State.Empty, State.Empty,
            State.Empty, State.Empty, State.Empty
        };
    }

    public bool CheckIsFill()
    {
        foreach (State cellState in _board)
        {
            if (cellState == State.Empty)
            {
                return false;
            }
        }

        return true;
    }
    
    public State CheckIsWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (_board[i * 3] != State.Empty && _board[i * 3] == _board[i * 3 + 1] && _board[i * 3 + 1] == _board[i * 3 + 2])
            {
                return _board[i * 3];
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            if (_board[i] != State.Empty && _board[i] == _board[i + 3] && _board[i + 3] == _board[i + 6])
            {
                return _board[i];
            }
        }
        
        if (_board[0] != State.Empty && _board[0] == _board[4] && _board[4] == _board[8])
        {
            return _board[0];
        }
        
        if (_board[2] != State.Empty && _board[2] == _board[4] && _board[4] == _board[6])
        {
            return _board[2];
        }
        
        return State.Empty;
    }

    public void SetEmptyToDisable()
    {
        for (int cellIndex = 0; cellIndex < _board.Length; cellIndex++)
        {
            if (_board[cellIndex] == State.Empty)
            {
                _board[cellIndex] = State.Disable;
            }
        }
    }
}