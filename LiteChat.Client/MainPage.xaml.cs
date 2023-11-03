using LiteChat.Chess.Implementations;
using LiteChat.Chess.Models;

namespace LiteChat.Client
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        IChessState chessState;

        public MainPage()
        {
            InitializeComponent();
            chessState = new ChessState();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count = chessState.Version;
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
