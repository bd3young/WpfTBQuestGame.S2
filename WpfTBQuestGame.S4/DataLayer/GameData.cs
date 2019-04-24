using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTBQuestGame.S2.Models;
using System.Collections.ObjectModel;

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
				Traveled = 0,
				Inventory = new ObservableCollection<GameItem>
				{
					GameItemById(1002)
				},
                Crew = new ObservableCollection<Npc>
                {

                }
			};
		}

		private static GameItem GameItemById(int id)
		{
			return StandardGameItems().FirstOrDefault(i => i.Id == id);
		}

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        private static Shrine ShrineById(int id)
        {
            return Shrines().FirstOrDefault(i => i.Id == id);
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

			gameMap.StandardGameItems = StandardGameItems();
            gameMap.StandardNpcs = Npcs();

			//
			// row 1
			//
			gameMap.MapLocations[0, 0] = new Location()
			{
				Id = 4,
				Name = "Kelime Island",
				Description = "Island with the Navy Headquarters on it",
				Accessible = true,
				ModifyExp = 10,
				ModifyTraveled = 1,
				GameItems = new ObservableCollection<GameItem>
				{
					GameItemById(3002),
					GameItemById(2003)
				},
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1006)
                }
			};
			gameMap.MapLocations[0, 1] = new Location()
			{
				Id = 1,
				Name = "Jenun Island",
				Description = "Caves",
				Accessible = true,
				ModifyExp = 10,
				ModifyTraveled = 1,
				GameItems = new ObservableCollection<GameItem>
				{
					GameItemById(1001)
				},
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1002),
                    NpcById(1005),
                }
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
				ModifyTraveled = 1,
				GameItems = new ObservableCollection<GameItem>
				{
					GameItemById(3003)
				},
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1004)
                }
            };
			gameMap.MapLocations[1, 2] = new Location()
			{
				Id = 2,
				Name = "Neaver Island",
				Description = "Volcano in the center",
				Accessible = false,
				ModifyExp = 10,
				ModifyTraveled = 1,
				RequiredShipId = 1001,
				GameItems = new ObservableCollection<GameItem>
				{
					GameItemById(2001)
				},
                Shrines = new ObservableCollection<Shrine>()
                {
                    ShrineById(1001)
                }
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
				ModifyTraveled = 1,
				GameItems = new ObservableCollection<GameItem>
				{
					GameItemById(3001),
					GameItemById(2002)
				},
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1001),
                    NpcById(1003)
                }
                //ModifyHealth = 50,
                //Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions."
            };

			return gameMap;
		}

		public static List<GameItem> StandardGameItems()
		{
			return new List<GameItem>()
			{
				new Ship(1001, "Bender", "A four man vessel", 40, "You need a crew to saile this ship.", Ship.UseActionType.CREWNEEDED, true),
				new Ship(1002, "Row Boat", "A Kreeky old row boat", 0, "", Ship.UseActionType.OPENLOCATION, false),
				new Food(2001, "Chicken Leg", "A chicken leg cooked to perfection", 10, "You eat the chicken leg and gain health", 10),
				new Food(2002, "Steak", "The tastiest steak ever made", 10, "You eat the steak and gain Helth", 20),
				new Food(2003, "Rum", "Barrel of rum", 20, "You dring the entire barrel and gain health", 30),
				new Treasure(3001, "Duchmens Chest", "Who know what this chest contains", 20, "", Treasure.TreasureType.Chest),
				new Treasure(3002, "Gold Bar", "Gold bar that has been left behind", 20, "", Treasure.TreasureType.Gold),
				new Treasure(3003, "Crystal Skull", "A primape Skull made entirely of crystal", 30, "", Treasure.TreasureType.Gem),
                new Treasure(3004, "Chest of Caishen", "A chest that contains enough gold to live 1000 life times.",1000, "",Treasure.TreasureType.Chest)
			};
		}

        public static List<GameItem> ItemsNeededForShrine()
        {
            return new List<GameItem>()
            {
                new Ship(1001, "Bender", "A four man vessel", 40, "You need a crew to saile this ship.", Ship.UseActionType.CREWNEEDED, true),
                new Ship(1002, "Row Boat", "A Kreeky old row boat", 0, "", Ship.UseActionType.OPENLOCATION, false),
                new Treasure(3001, "Duchmens Chest", "Who know what this chest contains", 20, "", Treasure.TreasureType.Chest),
                new Treasure(3002, "Gold Bar", "Gold bar that has been left behind", 20, "", Treasure.TreasureType.Gold),
                new Treasure(3003, "Crystal Skull", "A primape Skull made entirely of crystal", 30, "", Treasure.TreasureType.Gem)
            };
        }

        public static List<Npc> Npcs()
			{
				return new List<Npc>()
				{
					new Citizen()
					{
						Id = 1001,
						Name = "Helgan Duncar",
						Race = Character.RaceType.FishMan,
						Description = "A man that resembles a great white shark.",
						Messages = new List<string>()
						{
							"Hello what bring you to my Island.",
							"I love the sea."
						}
					},
                    new Citizen()
                    {
                        Id = 1002,
                        Name = "Jelen Halbart",
                        Race = Character.RaceType.FishMan,
                        Description = "A man that resembles a Mantaray.",
                        Messages = new List<string>()
                        {
                            "I love going fishing.",
                            "Where are you traveling to."
                        }
                    },
                    new Citizen()
                    {
                        Id = 1003,
                        Name = "Felina Sanchez",
                        Race = Character.RaceType.Human,
                        Description = "A woman hiding behind a rock on the side of the road.",
                        Messages = new List<string>()
                        {
                            "How did you see me?",
                            "What do you want?"
                        }
                    },
                    new Citizen()
                    {
                        Id = 1004,
                        Name = "Ceasar Denada",
                        Race = Character.RaceType.Human,
                        Description = "A man working on a boat",
                        Messages = new List<string>()
                        {
                            "What a beautiful day.",
                            "I am the only shipwright on thei island."
                        }
                    },
                    new Citizen()
                    {
                        Id = 1005,
                        Name = "Demetrius Taltar",
                        Race = Character.RaceType.BeastMan,
                        Description = "A man that resembles a wolf",
                        Messages = new List<string>()
                        {
                            "Who are you.",
                            "Why are you talking to me?"
                        }
                    },
                    new Citizen()
                    {
                        Id = 1006,
                        Name = "Koami Nelour",
                        Race = Character.RaceType.BeastMan,
                        Description = "A woman that resemble a lion.",
                        Messages = new List<string>()
                        {
                            "I am a BeastMan, what are you?",
                            "I am getting very hungry."
                        }
                    },
                };
			}
        public static List<Shrine> Shrines()
        {
            return new List<Shrine>()
            {
                new Shrine()
                {
                    Id = 1001,
                    Name = "Shrine of Gorosan",
                    Race = Character.RaceType.FishMan,
                    Description = "A that sits at the center of the island.",
                    Messages = new List<string>()
                    {
                        "If you Desire What I have you Must give everything you and the world have to offer.",
                    },
                    CurrentTreasure = GameItemById(3004) as Treasure
                    
                }
            };
        }
	}
}
