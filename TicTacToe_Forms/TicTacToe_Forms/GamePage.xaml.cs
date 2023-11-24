using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
        }
        public static bool symbol = true;
        public char[,] board = new char[6,3];

        protected override void OnAppearing()
        {
            char symbolChar = symbol ? 'X' : 'O';
            if (symbolChar == 'X')
            {
                FrameO.BackgroundColor = Color.FromHex("#61D89F");
                FrameX.BackgroundColor = Color.FromHex("#FF9773");
            }
            else
            {
                FrameX.BackgroundColor = Color.FromHex("#61D89F");
                FrameO.BackgroundColor = Color.FromHex("#FF9773");
            }
            
            // Рисуем игровое поле 
            Button btn = null;
            for (int j = 2; j < 5; j++)     // Номер строки
            {
                for (int i = 0; i < 3; i++) // Номер колонки
                {
                    btn = new Button();
                    btn.BackgroundColor = Color.FromHex("#61D89F");
                    btn.CornerRadius = 5;
                    btn.FontSize = 50;
                    Grid.SetRow(btn, j);
                    Grid.SetColumn(btn, i);

                    btn.Clicked += Button_Clicked;

                    Grid1.Children.Add(btn);
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            board[Grid.GetRow(sender as Button), Grid.GetColumn(sender as Button)] = !symbol ? 'X' : 'O';
            char symbolChar = !symbol ? 'X' : 'O';
            var t = symbolChar;
            if (t == 'X')
            {
                FrameO.BackgroundColor = Color.FromHex("#61D89F");
                FrameX.BackgroundColor = Color.FromHex("#FF9773");
            }
            else
            {
                FrameX.BackgroundColor = Color.FromHex("#61D89F");
                FrameO.BackgroundColor = Color.FromHex("#FF9773");
            }
            ((Button)sender).Text = Convert.ToString(board[Grid.GetRow(sender as Button), Grid.GetColumn(sender as Button)]);
            ((Button)sender).BackgroundColor = Color.Bisque;
            //await DisplayAlert($"{board[Grid.GetRow(sender as Button), Grid.GetColumn(sender as Button)]}", "sd", "OK");
            symbol = !symbol;
            
            //-------Проверка игрового поля на выполнение победной комбинации------//
            if ((board[2, 0] == t && board[2, 1] == t && board[2, 2] == t) || // 1
                (board[3, 0] == t && board[3, 1] == t && board[3, 2] == t) || // 2
                (board[4, 0] == t && board[4, 1] == t && board[4, 2] == t) || // 3
                (board[2, 0] == t && board[3, 0] == t && board[4, 0] == t) || // 4
                (board[2, 1] == t && board[3, 1] == t && board[4, 1] == t) || // 5
                (board[2, 2] == t && board[3, 2] == t && board[4, 2] == t) || // 6
                (board[2, 0] == t && board[3, 1] == t && board[4, 2] == t) || // 7
                (board[2, 2] == t && board[3, 1] == t && board[4, 0] == t))
            {
                var winner = symbol ? 'X' : 'O';
                await DisplayAlert("Winner!", $"Player {winner} is win!!", "End");
                await Navigation.PushAsync(new MainPage());
            }  
            
            /*if (CheckBoard(board))
            {
                await DisplayAlert("Ooooops", "no winner this game", "End");
                await Navigation.PushAsync(new MainPage());
            }*/
                
        }


        /*private static bool CheckBoard(char[,] board)
        {
            for (int j = 2; j < 5; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[j,i] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }*/
    }
}