using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTBQuestGame.S2.Models
{
	public interface IRecruit
	{
        bool WillRecruit(Character.RaceType CharacterRace, Player.RaceType playerRace);
    }
}
