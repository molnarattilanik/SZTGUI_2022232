using Microsoft.Toolkit.Mvvm.Messaging;
using MintaZH.Models;
using MintaZH.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH.Logic
{
    public class AthleteLogic : IAthleteLogic
    {
        IList<Athlete> athletes;
        IList<Athlete> competetion;
        private readonly IMessenger messenger;
        private readonly IAthleteService athleteService;

        public int AllAthlete { get { return competetion != null ? competetion.Count : 0; } }

        public double AthleteSumMarketValue { get { return (competetion == null || competetion.Count == 0) ? 0 : competetion.Sum(x => x.ActualMarketValue); } }

        public AthleteLogic(IMessenger messenger, IAthleteService athleteService)
        {
            this.messenger = messenger;
            this.athleteService = athleteService;
        }

        public void SetUpCollections(IList<Athlete> athletes, IList<Athlete> competetion)
        {
            this.athletes = athletes;
            this.competetion = competetion;
        }

        public void AddAthelete(Athlete athete)
        {
            if (!competetion.Contains(athete))
            {
                competetion.Add(athete);
                messenger.Send("Athlete Added", "AthleteInfo");
            }
        }

        public void EditAthlete(Athlete athete)
        {
            //megnyitás, details lesz
            athleteService.Edit(athete);
        }

        public void RemoveFromCompetetion(Athlete athete)
        {
            competetion.Remove(athete);
            messenger.Send("Athlete Removed", "AthleteInfo");
        }

        public void SaveCompetetion(string fileName, string when)
        {
            var competitionInJson = JsonConvert.SerializeObject(competetion);
            File.WriteAllText($"{fileName}-{when}.json", competitionInJson);
        }

        public void LoadAthletes(IList<Athlete> athletes, IList<Athlete> competetion)
        {
            this.athletes = athletes;
            this.competetion = competetion;

            athletes.Add(new Athlete() { Name = "Attila", Event = "400m", PersonalBest = 48.90, SeasonBest = 49.51, IsValid = true });
            athletes.Add(new Athlete() { Name = "Gergő", Event = "100m", PersonalBest = 48.90, SeasonBest = 49.51 });
            athletes.Add(new Athlete() { Name = "Balázs", Event = "200m", PersonalBest = 48.90, SeasonBest = 49.51 });
            athletes.Add(new Athlete() { Name = "Ottó", Event = "400m", PersonalBest = 48.90, SeasonBest = 49.51 });
            athletes.Add(new Athlete() { Name = "Péter", Event = "400m", PersonalBest = 48.90, SeasonBest = 49.51 });
            messenger.Send("Athletes Added", "AthleteInfo");
        }
    }
}
