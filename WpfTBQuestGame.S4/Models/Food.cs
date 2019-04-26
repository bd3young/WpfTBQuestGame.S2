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
				return $"{Name}: {Description}\nHealth: {HealthChange}";
		}
	}
}
