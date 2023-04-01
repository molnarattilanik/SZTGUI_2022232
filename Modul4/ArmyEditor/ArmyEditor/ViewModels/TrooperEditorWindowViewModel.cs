using ArmyEditor.Models;

namespace ArmyEditor.ViewModels
{
    public class TrooperEditorWindowViewModel
    {
        public Trooper Actual { get; set; }

        public void Setup(Trooper trooper)
        {
            this.Actual = trooper;
        }

        public TrooperEditorWindowViewModel() { }
    }
}
