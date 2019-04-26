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
				"You are a pirate that just lost his ship and his crew. You have washed ashore on an island you have never been before. " +
				"You have a strange feeling in your head that feels as if your life is being consumed.",
				"All you have is a row boat to get you through the archipelago."
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
				Description = "You arrive at an island that does not look that big but has an immense cave system. You begin your trek through the caves.",
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
				Description = "You arrive to a tropical island that has an amazing vibe. The sandy beaches stretch as far as the eye can see.",
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
				Description = "The island you washed ashore on is home to a couple villages. The inhabitants of the island are curious of where you came from.",
				Accessible = true,
				ModifyExp = 10,
				ModifyTraveled = 1,
				GameItems = new ObservableCollection<GameItem>
				{
					GameItemById(3003),
                    GameItemById(2001)
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
				Description = "You have arrived on an island that has a volcano directly in the center. Upon exploring you come across a shrine located at the top of the volcano. ",
				Accessible = false,
				ModifyExp = 10,
				ModifyTraveled = 1,
				RequiredShipId = 1001,
				GameItems = new ObservableCollection<GameItem>
				{
					
				},
				Shrines = new ObservableCollection<Shrine>()
				{
					ShrineById(1001)
				}
			};

			//
			// row 3
			//
			gameMap.MapLocations[2, 1] = new Location()
			{
				Id = 3,
				Name = "Pellow Island",
				Description = "You have arrived on an island that is covered in snow. All the inhabitants live in igloos. You begin to explore the island to find somewhere warm.",
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

			};

			return gameMap;
		}

		public static List<GameItem> StandardGameItems()
		{
			return new List<GameItem>()
			{
				new Ship(1001, "Bender", "A Three man vessel", 40, "You need a crew to sail this ship.", Ship.UseActionType.CREWNEEDED, true),
				new Ship(1002, "Row Boat", "A Kreeky old row boat", 0, "", Ship.UseActionType.OPENLOCATION, false),
				new Food(2001, "Chicken Leg", "A chicken leg cooked to perfection", 10, "You eat the chicken leg and gain 10 health", 10),
				new Food(2002, "Steak", "The tastiest steak ever made", 10, "You eat the steak and 20 gain Helth", 20),
				new Food(2003, "Rum", "Barrel of rum", 20, "You drink the entire barrel and 30 gain health", 30),
				new Treasure(3001, "Duchmens Chest", "Who know what this chest contains", 20, "", Treasure.TreasureType.Chest),
				new Treasure(3002, "Gold Bar", "Gold bar that has been left behind", 20, "", Treasure.TreasureType.Gold),
				new Treasure(3003, "Crystal Skull", "A primape Skull made entirely of crystal", 30, "", Treasure.TreasureType.Gem),
				new Treasure(3004, "Chest of Caishen", "You have recieved a chest that contains enough gold to live 1000 life times.",1000, "",Treasure.TreasureType.Chest)
			};
		}

		public static List<GameItem> DefaultInventoryGameItems()
		{
			return new List<GameItem>()
			{
				GameItemById(1002)
			};
		}

		public static List<GameItem> ItemsNeededForShrine()
		{
			return new List<GameItem>()
			{
				GameItemById(1001),
                GameItemById(1002),
                GameItemById(3001),
                GameItemById(3002),
                GameItemById(3003)
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
							"Hello what brings you to my island.",
                            "A lot of folks take only to their kind around these islands"
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
							"Where are you traveling to?"
						}
					},
					new Citizen()
					{
						Id = 1003,
						Name = "Felina Sanchez",
						Race = Character.RaceType.Human,
						Description = "A woman packing snow on her igloo.",
						Messages = new List<string>()
						{
							"You look cold want to go in the igloo to warm up.",
                            "Some say there is a treasure hidden on a faraway island."
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
                            "If you want to sail to Neaver Island you will need a crew and ship"
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
							"Who are you?",
                            "Some say there is a shrine that will give you its treasure if place all nonperishable items at its feet."
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
					Description = "A shrine that sits at the top of the valcano.",
					Messages = new List<string>()
					{
						"If you desire What I have you must give everything you and the world have to offer.",
					},
					CurrentTreasure = GameItemById(3004) as Treasure

				}
			};
		}
	}
}
