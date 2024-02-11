using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace c3_pwork1_krest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] but;
        string player = "X";
        string bot = "O";
        public MainWindow()
        {
            InitializeComponent();
        }

        string[] number = new string[9] { " ", " ", " ", " ", " ", " ", " ", " ", " " };

        private void click(int num, Button[] but, string[] number)
        {
            but = new Button[9] {b0, b1, b2, b3, b4, b5, b6, b7, b8};
            but[num].Content = player;
            but[num].IsEnabled = false;
            number[num] = player;
            robotd();
        }

        private void robotd()
        {
            proverka();
            but = new Button[9] { b0, b1, b2, b3, b4, b5, b6, b7, b8 };
            Random rnd = new Random();
            while (true)
            {
                int n = rnd.Next(8);
                if (number[n] == " ")
                {
                    but[n].Content = bot;
                    but[n].IsEnabled = false;
                    number[n] = bot;
                    break;
                }
            }
            proverka();
        }

        private void proverka()
        {
            if (number[0] == number[1] && number[1] == number[2] && number[0] != " ")
            {
                win(number[0]);
            }
            else if (number[3] == number[4] && number[4] == number[5] && number[3] != " ")
            {
                win(number[3]);
            }
            else if (number[6] == number[7] && number[7] == number[8] && number[6] != " ")
            {
                win(number[6]);
            }
            else if (number[0] == number[3] && number[3] == number[6] && number[0] != " ")
            {
                win(number[0]);
            }
            else if (number[4] == number[1] && number[1] == number[7] && number[4] != " ")
            {
                win(number[4]);
            }
            else if (number[2] == number[5] && number[5] == number[8] && number[2] != " ")
            {
                win(number[2]);
            }
            else if (number[0] == number[4] && number[4] == number[8] && number[0] != " ")
            {
                win(number[0]);
            }
            else if (number[2] == number[4] && number[4] == number[6] && number[2] != " ")
            {
                win(number[2]);
            }
            int pusto = 0;
            foreach (string i in number) 
            {
                if (i == " ")
                {
                    pusto++;
                }
            }
            if (pusto == 0)
            {
                win(" ");
            }
        }

        private void win(string w)
        {
            but = new Button[9] { b0, b1, b2, b3, b4, b5, b6, b7, b8 };
            foreach (Button i in but)
            {
                i.IsEnabled = false;
            }
            if (w == " ")
            {
                textb.Text = "Ничья";
            }
            else 
            {
                textb.Text = "победа игрока играющего за " + w;
            }
        }

    private void b0_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            click(num, but, number);
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            int num = 1;
            click(num, but, number);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            int num = 2;
            click(num, but, number);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            int num = 3;
            click(num, but, number  );
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            int num = 4;
            click(num, but, number);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            int num = 5;
            click(num, but, number);
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            int num = 6;
            click(num, but, number);
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            int num = 7;
            click(num, but, number);
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            int num = 8;
            click(num, but, number);
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                but[i].IsEnabled = true;
                but[i].Content = " ";
                number[i] = " ";
                if (player == "X")
                {
                    player = "O";
                    bot = "X";
                }
                else if (player == "O")
                {
                    player = "X";
                    bot = "O";
                }
                textb.Text = "Вы играете за " + player;
            }
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            if (player == "X")
            {
                player = "O";
                bot = "X";
            }
            else if (player == "O")
            {
                player = "X";
                bot = "O";
            }
            textb.Text = "Вы играете за " + player;
        }
    }
}
