
using LiteChat.Common.Models.Games.Chess;

namespace LiteChat.Client;

public partial class MainPage : ContentPage
{
    int count = 0;
    ChessState chessState;

    public MainPage()
    {
        InitializeComponent();
        chessState = new ChessState();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count = chessState.Version;
        count++;

        CounterBtn.Text = count == 1 ? $"Clicked {count} time" : $"Clicked {count} times";
        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
