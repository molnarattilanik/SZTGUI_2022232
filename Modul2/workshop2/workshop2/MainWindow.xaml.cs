using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace workshop2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<Question> questions;

        public MainWindow()
        {
            InitializeComponent();
            questions = new List<Question>
            {
                new Question()
                {
                    QuestionText = "Melyik megyében van Pécs?",
                    Answers = new string[] { "Baranya", "Békés", "Bács-Kiskun", "Nógrád" }
                },
                new Question()
                {
                    QuestionText = "Mi a legjobb kaja?",
                    Answers = new string[] { "Hambi", "Pizza", "Fagyi", "Péksüti" }
                }
            };

            questions.ForEach(x =>
            {
                Label label = new()
                {
                    Tag = x,
                    Content = new Image()
                    {
                        Name = "pic",
                        Source = new BitmapImage(new Uri("https://picsum.photos/70")),
                        Stretch = Stretch.None,
                        Width = 70,
                        Height = 70
                    },
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Width = 130,
                    Height = 130,
                    Margin = new Thickness(20),
                    Background = Brushes.LightBlue
                };

                wrap.Children.Add(label);
            });
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label label)
            {
                if (label.Tag is Question question)
                {
                    GameWindow gw = new(question);
                    if (gw.ShowDialog() == true)
                    {
                        label.Background = Brushes.LightGreen;
                        label.IsEnabled = false;
                    }
                    else
                    {
                        label.Background = Brushes.LightPink;
                        label.IsEnabled = false;
                    }
                }
            }
        }
    }
}
