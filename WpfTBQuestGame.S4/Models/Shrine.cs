using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTBQuestGame.S2.Models
{
	public class Shrine: Character, ISpeak, IReward
	{
        Random r = new Random();

        public string Description { get; set; }
        public List<string> Messages { get; set; }
        public Treasure CurrentTreasure { get; set; }

        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        public Shrine()
        {
        }

		public Shrine(int id, string name, RaceType race, string description, List<string> messages, Treasure CurrentTreasure)
			: base(id, name, race)
		{
            Id = id;
            Name = Name;
            Race = race;
            Description = description;
            Messages = messages;
//            CurrentTreasure = currentTreasure;
		}

        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        private string GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        public Treasure TreasureNeeded()
        {
            throw new NotImplementedException();
        }

        public bool WillReward(List<GameItem> LocationGameItem)
        {
            if (GameItemsNeeded() == LocationGameItem)
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }

        protected string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public List<GameItem> GameItemsNeeded()
        {
            return new List<GameItem>()
            {
                new Ship(1001, "Bender", "A four man vessel", 40, "You need a crew to saile this ship.", Ship.UseActionType.OPENLOCATION, true),
                new Ship(1002, "Row Boat", "A Kreeky old row boat", 0, "", Ship.UseActionType.OPENLOCATION, false),
                new Treasure(3001, "Duchmens Chest", "Who know what this chest contains", 20, "", Treasure.TreasureType.Chest),
                new Treasure(3002, "Gold Bar", "Gold bar that has been left behind", 20, "", Treasure.TreasureType.Gold),
                new Treasure(3003, "Crystal Skull", "A primape Skull made entirely of crystal", 30, "", Treasure.TreasureType.Gem)
            };
        }
    }
}
