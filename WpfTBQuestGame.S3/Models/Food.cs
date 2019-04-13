using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTBQuestGame.S2.Models
{
	public class Food : GameItem
	{
		public int HealthChange { get; set; }

		public Food(int id, string name, string description, int exp, string useMessage, int healthChange)
			: base(id, name, description, exp, useMessage)
		{
			HealthChange = healthChange;
		}

		public override string InformationString()
		{
			if (HealthChange != 0)
			{
				return $"{Name}: {Description}\nHealth: {HealthChange}";
			}
			else
			{
				return $"{Name}: {Description}";
			}
		}
	}
}
