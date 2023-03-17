using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Workshop01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> notes;

        public MainWindow()
        {
            InitializeComponent();

            notes = new Dictionary<string, string>();

            if (File.Exists("notes.json"))
            {
                notes = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("notes.json"));

                foreach (var item in notes.Keys)
                {
                    lbox.Items.Add(item);
                }
            }
        }

        private void CreateNote(object sender, RoutedEventArgs e)
        {
            notes.Add(noteName_textBox.Text, "");
            RefreshList();
            noteName_textBox.Text = string.Empty;
        }

        private void RefreshList()
        {
            lbox.Items.Clear();
            foreach (string note in notes.Keys)
            {
                lbox.Items.Add(note);
            }

            lbox.SelectedItem = noteName_textBox.Text;
        }

        private void lbox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                tb_editor.Text = notes[(string)lbox.SelectedItem];
            }
        }

        private void tb_editor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                notes[(string)lbox.SelectedItem] = tb_editor.Text;
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            File.WriteAllText("notes.json", JsonConvert.SerializeObject(notes));
        }

        private void Delete(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                notes.Remove((string)lbox.SelectedItem);
                RefreshList();
            }
        }
    }
}
