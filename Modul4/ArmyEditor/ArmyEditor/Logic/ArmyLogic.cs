using ArmyEditor.Models;
using ArmyEditor.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArmyEditor.Logic
{
    public class ArmyLogic : IArmyLogic
    {
        IList<Trooper> barracks;
        IList<Trooper> army;
        readonly IMessenger messenger;
        readonly ITrooperEditorService editorService;

        public ArmyLogic(IMessenger messenger, ITrooperEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }

        public int AllCost
        {
            get
            {
                return army.Count == 0 ? 0 : army.Sum(t => t.Cost);
            }
        }

        public double AVGPower
        {
            get
            {
                return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Power), 2);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Speed), 2);
            }
        }

        public void SetupCollections(IList<Trooper> barracks, IList<Trooper> army)
        {
            this.barracks = barracks;
            this.army = army;
        }

        public void AddToArmy(Trooper trooper)
        {
            army.Add(trooper.GetCopy());
            messenger.Send("Trooper added", "TrooperInfo");
        }

        public void RemoveFromArmy(Trooper trooper)
        {
            army.Remove(trooper);
            messenger.Send("Trooper removed", "TrooperInfo");
        }

        public void EditTrooper(Trooper trooper)
        {
            editorService.Edit(trooper);
        }
    }
}
