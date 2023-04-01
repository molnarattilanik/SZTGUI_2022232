using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ArmyEditor.Models
{
    public class Trooper : ObservableObject
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private int power;
        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        public int Cost
        {
            get
            {
                return speed * power;
            }
        }

        public Trooper GetCopy()
        {
            return new Trooper()
            {
                Type = this.Type,
                Power = this.Power,
                Speed = this.Speed
            };
        }
    }
}
