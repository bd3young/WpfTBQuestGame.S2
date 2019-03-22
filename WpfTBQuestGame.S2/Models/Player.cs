using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTBQuestGame.S2.Models
{
    public class Player : Character
    {
        #region ENUM

        public enum JobTitleName
        {
            Theif,
            ShipWright,
            Engineer
        }

        #endregion

        #region FIELDS

        protected int _lives;
        protected int _health;
        private int _exp;
        private JobTitleName _jobTitle;
		private List<Location> _locationsVisited;
		private int _traveled;




		#endregion

		#region PROPERTIES

		public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Exp
        {
            get { return _exp; }
            set
			{
				_exp = value;
				OnPropertyChanged(nameof(Exp));
			}
        }

        public JobTitleName JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

		public List<Location> LocationsVisited
		{
			get { return _locationsVisited; }
			set { _locationsVisited = value; }
		}

		public int Traveled
		{
			get { return _traveled; }
			set
			{
				_traveled = value;
				OnPropertyChanged(nameof(Traveled));
			}
		}

		#endregion

		#region METHODS

		public Player()
		{
			_locationsVisited = new List<Location>();
		}

		public bool HasVisited(Location location)
		{
			return _locationsVisited.Contains(location);
		}

		#endregion

		#region CONSTRUCTORS

		#endregion
	}
}
