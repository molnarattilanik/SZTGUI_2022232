using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using MintaZH.Logic;
using MintaZH.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MintaZH.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Athlete> Athletes
        {
            get => athletes; set
            {
                athletes = value;
                (LoadAthletes as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ObservableCollection<Athlete> CompetetionEvent { get; set; }


        private Athlete selectedAthlete;
        public Athlete SelectedAthlete
        {
            get
            {
                return selectedAthlete;
            }
            set
            {
                SetProperty(ref selectedAthlete, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Athlete selectedFromComptetion;
        private readonly IAthleteLogic athleteLogic;

        public Athlete SelectedFromComptetion
        {
            get { return selectedFromComptetion; }
            set
            {
                SetProperty(ref selectedFromComptetion, value);
                (DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public int AllAthlete { get { return athleteLogic.AllAthlete; } }
        public double AthleteSumMarketValue { get { return athleteLogic.AthleteSumMarketValue; } }

        private ObservableCollection<Athlete> athletes;
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                SetProperty(ref fileName, value);
                (SaveCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string dateTime;

        public string DateTime
        {
            get { return dateTime; }
            set
            {
                SetProperty(ref dateTime, value);
                (SaveCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ICommand LoadAthletes { get; set; }

        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IAthleteLogic>())
        {
        }

        public MainWindowViewModel(IAthleteLogic athleteLogic)
        {
            this.athleteLogic = athleteLogic;

            LoadAthletes = new RelayCommand(
                () => athleteLogic.LoadAthletes(Athletes, CompetetionEvent),
                () => Athletes.Count == 0
                );

            Athletes = new ObservableCollection<Athlete>();
            CompetetionEvent = new ObservableCollection<Athlete>();

            //athleteLogic.SetUpCollections(Athletes, CompetetionEvent);

            AddCommand = new RelayCommand(
                () => athleteLogic.AddAthelete(selectedAthlete),
                () => selectedAthlete != null && selectedAthlete.IsValid);

            EditCommand = new RelayCommand(
                () => athleteLogic.EditAthlete(SelectedAthlete),
                () => SelectedAthlete != null);

            DeleteCommand = new RelayCommand(
                () => athleteLogic.RemoveFromCompetetion(SelectedFromComptetion),
                () => selectedFromComptetion != null
                );

            SaveCommand = new RelayCommand(() => athleteLogic.SaveCompetetion(FileName, DateTime), () => !string.IsNullOrWhiteSpace(FileName) && !string.IsNullOrWhiteSpace(FileName));

            Messenger.Register<MainWindowViewModel, string, string>(this, "AthleteInfo", (recepient, msg) =>
            {
                OnPropertyChanged(nameof(AllAthlete));
                OnPropertyChanged(nameof(AthleteSumMarketValue));
            });
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
