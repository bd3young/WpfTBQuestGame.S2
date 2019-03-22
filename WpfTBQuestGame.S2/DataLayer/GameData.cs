using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTBQuestGame.S2.Models;

namespace WpfTBQuestGame.S2.DataLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Henry",
                Age = 26,
                JobTitle = Player.JobTitleName.Theif,
                Race = Character.RaceType.FishMan,
                Health = 100,
                Lives = 3,
                Exp = 0,
                LocationId = 0,
				Traveled = 0
            };
        }
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "You are a pirate that just lost his ship and his crew that has been washed ashore on an island you have never been before. " +
                "Your goal was to find the treasue said to be on a near by island. Your task is to find a ship and crew to get you on your journey again.",
                "You will begin your journey by picking from the diferent locations on the island."
            };
        }
        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates()
            {
                Row = 1,
                Column = 1
            };
        }
        public static Map GameMapData()
        {
            int rows = 3;
            int columns = 3;

            Map gameMap = new Map(rows, columns);

            //
            // row 1
            //
            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 4,
                Name = "Kelime Island",
                Description = "Island witht he Navy Headquarters on it",
                Accessible = true,
                ModifyExp = 10,
				ModifyTraveled = 1
            };
            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 1,
                Name = "Jenun Island",
                Description = "Caves",
                Accessible = true,
                ModifyExp = 10,
				ModifyTraveled = 1
            };

            //
            // row 2
            //
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 2,
                Name = "Gurunga Island",
                Description = "The Island you washed ashore on is home to a couple villages." +
                "The inhabitants of the island are curious of where you came from.",
                Accessible = true,
                ModifyExp = 10,
				ModifyTraveled = 1
			};
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 2,
                Name = "Neaver Island",
                Description = "Volcano in the center",
                Accessible = true,
                ModifyExp = 10,
				ModifyTraveled = 1
				//ModifyLives = -1,
				//RequiredExperiencePoints = 40
			};

            //
            // row 3
            //
            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 3,
                Name = "Pellow Island",
                Description = "Frozen Island",
                Accessible = true,
                ModifyExp = 10,
				ModifyTraveled = 1
				//ModifyHealth = 50,
				//Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions."
			};

            return gameMap;
        }
    }
}
