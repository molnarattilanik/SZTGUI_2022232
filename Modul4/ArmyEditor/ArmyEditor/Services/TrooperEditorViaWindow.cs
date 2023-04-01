using ArmyEditor.Models;

namespace ArmyEditor.Services
{
    public class TrooperEditorViaWindow : ITrooperEditorService
    {
        public void Edit(Trooper trooper)
        {
            new TrooperEditorWindow(trooper).ShowDialog();
        }
    }
}
