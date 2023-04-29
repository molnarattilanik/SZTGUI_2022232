using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MintaZH.Models
{
    public class Athlete : ObservableObject
    {
        private string name;
        private string @event;
        private double personalBest;
        private double seasonBest;

        private bool isValid;

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }


        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Event { get => @event; set => SetProperty(ref @event, value); } //100, 200, 400

        public double PersonalBest { get => personalBest; set => SetProperty(ref personalBest, value); }
        public double SeasonBest { get => seasonBest; set => seasonBest = value; }
        public double ActualMarketValue
        {
            get
            {
                return PersonalBest * SeasonBest;
            }
        }
    }
}
