using MintaZH.Models;
using MintaZH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MintaZH
{
    /// <summary>
    /// Interaction logic for AthleteEditor.xaml
    /// </summary>
    public partial class AthleteEditor : Window
    {
        public AthleteEditor(Athlete athlete)
        {
            InitializeComponent();
            this.DataContext = new AthleteEditorWindowViewModel();
            (this.DataContext as AthleteEditorWindowViewModel).SetUp(athlete);
        }
    }
}
