using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTBQuestGame.S2.Models
{
	public class Citizen : Npc, ISpeak, IRecruit
	{
		Random r = new Random();

		public List<string> Messages { get; set; }
        public bool willRecruit { get; set; }

        protected override string InformationText()
		{
			return $"{Name} - {Description} - {Race}";
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

		public Citizen()
		{
		}

		public Citizen( int id, string name, RaceType race, string description, List<string> messages, bool WillRecruit)
			:base(id, name, race, description)
		{
			Messages = messages;
            WillRecruit = willRecruit;
		}



		private string GetMessage()
		{
			int messageIndex = r.Next(0, Messages.Count());
			return Messages[messageIndex];
		}

        public bool WillRecruit(Character.RaceType characterRace, Player.RaceType playerRace)
        {
            if (characterRace == playerRace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
