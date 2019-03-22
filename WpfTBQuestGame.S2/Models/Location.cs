using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTBQuestGame.S2.Models
{
    public class Location
    {
        #region FIELDS

        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _modifyExp;
		private int _modifyHealth;
		private int _modifyLives;
		private int _modifyTraveled;

		#endregion

		#region PROPERTIES

		public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int ModifyExp
        {
            get { return _modifyExp; }
            set { _modifyExp = value; }
        }

        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }

		public int ModifyLives
		{
			get { return _modifyLives; }
			set { _modifyLives = value; }
		}

		public int ModifyHealth
		{
			get { return _modifyHealth; }
			set { _modifyHealth = value; }
		}

		public int ModifyTraveled
		{
			get { return _modifyTraveled; }
			set { _modifyTraveled = value; }
		}

		#endregion

		#region METHODS

		#endregion

		#region CONSTRUCTORS

		#endregion
	}
}
