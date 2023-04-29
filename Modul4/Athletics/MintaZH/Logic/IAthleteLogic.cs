using MintaZH.Models;
using System.Collections.Generic;

namespace MintaZH.Logic
{
    public interface IAthleteLogic
    {
        int AllAthlete { get; }
        double AthleteSumMarketValue { get; }

        void AddAthelete(Athlete trooper);
        void EditAthlete(Athlete trooper);
        void RemoveFromCompetetion(Athlete trooper);
        void SaveCompetetion(string fileName, string when);
        void SetUpCollections(IList<Athlete> athletes, IList<Athlete> competetion);
        void LoadAthletes(IList<Athlete> athletes, IList<Athlete> competetion);
    }
}