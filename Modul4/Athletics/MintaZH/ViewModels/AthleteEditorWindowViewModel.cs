using MintaZH.Models;

namespace MintaZH.ViewModels
{
    public class AthleteEditorWindowViewModel
    {
        public Athlete Athlete { get; set; }

        public void SetUp(Athlete athlete)
        {
            this.Athlete = athlete;
        }

        public AthleteEditorWindowViewModel()
        {
        }
    }
}
