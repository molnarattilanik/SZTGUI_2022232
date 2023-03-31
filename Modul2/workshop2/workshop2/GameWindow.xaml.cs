using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace workshop2
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        static readonly Random random = new();
        readonly string correctAnswer;
        readonly Question question;
        int seconds = 60;

        public GameWindow(Question question)
        {
            InitializeComponent();

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();

            this.question = question;
            correctAnswer = question.Answers[0];
            lbl_time.Content = seconds;

            string[] answersCopy = new string[4];
            for (int i = 0; i < question.Answers.Length; i++)
            {
                answersCopy[i] = question.Answers[i];
            }

            //keverés
            for (int i = 0; i < 100; i++)
            {
                int a = random.Next(0, 4);
                int b = random.Next(0, 4);
                string tmp = answersCopy[a];
                answersCopy[a] = answersCopy[b];
                answersCopy[b] = tmp;
            }

            btn1.Content = answersCopy[0];
            btn2.Content = answersCopy[1];
            btn3.Content = answersCopy[2];
            btn4.Content = answersCopy[3];

            lbl_question.Content = question.QuestionText;
        }

        private void Dt_Tick(object? sender, EventArgs e)
        {
            seconds--;
            Dispatcher.Invoke(() =>
            {
                lbl_time.Content = seconds;
            });
            if (seconds == 0)
            {
                DialogResult = false;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label label)
            {
                if (label.Content.ToString() == correctAnswer)
                {
                    question.Correct = true;
                    DialogResult = true;
                }
                else
                {
                    question.Correct = false;
                    DialogResult = false;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (question.Correct is null) 
            {
                var result = MessageBox.Show("Biztosan bezárod?", "Erősítsd meg", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
