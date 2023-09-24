namespace TicTacToe;

public partial class MainPage : ContentPage
{
    Game _game = new Game();
    private bool _isEnd = false;

    public MainPage()
    {
        InitializeComponent();
    }
    
    private void _cellOnClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;

        if (_isEnd)
        {
            return;
        }
        
        var id = Grid.GetColumn(button) + 1 + Grid.GetRow(button) * 3;
        var state = _game.Move(id);
        var currentPlayer = _game.players.currentPlayer == State.O ? State.X : State.O;
        
        button.Source = currentPlayer == State.O ? "o_cell.png" : "x_cell.png";

        if (state == GameState.InProgress)
        {
            PrimaryText.Text = "Turn " + (_game.players.currentPlayer == State.O ? "Red": "Blue");
            return;
        }
        
        if (state == GameState.XWin)
        {
            PrimaryText.Text = "Blue Win!";
        }
        else if (state == GameState.OWin)
        {
            PrimaryText.Text = "Red Win!";
        }
        else
        {
            PrimaryText.Text = "Draw!";
        }
        
        _game.EndGame();
        BoardDisable();
        PlayAgain.IsVisible = true;
        _isEnd = true;
    }

    private void PlayAgain_OnClicked(object sender, EventArgs e)
    {
        _game.PlayAgain();
        PrimaryText.Text = "Turn " + (_game.players.currentPlayer == State.O ? "Red": "Blue");
        PlayAgain.IsVisible = false;
        BoardEmpty();
        _isEnd = false;
    }

    private void BoardDisable()
    {
        ImageButton[] array = new[]
        {
            C1, C2, C3, C4, C5, C6, C7, C8, C9
        };
        foreach (var btn in array)
        {
            if (btn.Source.ToString() == "File: empty.png")
            {
                btn.Source = "disabled.png";
            }
        }
    }

    private void BoardEmpty()
    {
        ImageButton[] array = new[]
        {
            C1, C2, C3, C4, C5, C6, C7, C8, C9
        };
        foreach (var btn in array)
        {
            btn.Source = "empty.png";
        }
    }
}