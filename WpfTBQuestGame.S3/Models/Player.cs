using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
		private ObservableCollection<GameItem> _inventory;
		private ObservableCollection<GameItem> _ship;
		private ObservableCollection<GameItem> _food;
		private ObservableCollection<GameItem> _treasure;

		#endregion

		#region PROPERTIES

		public int Lives
        {
            get { return _lives; }
            set
            {
                _lives = value;
                OnPropertyChanged(nameof(Lives));
            }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
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
            set
            {
                _jobTitle = value;
                OnPropertyChanged(nameof(JobTitle));
            }
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

		public ObservableCollection<GameItem> Inventory
		{
			get { return _inventory; }
			set { _inventory = value; }
		}

		public ObservableCollection<GameItem> Ship
		{
			get { return _ship; }
			set { _ship = value; }
		}

		public ObservableCollection<GameItem> Food
		{
			get { return _food; }
			set { _food = value; }
		}

		public ObservableCollection<GameItem> Treasure
		{
			get { return _treasure; }
			set { _treasure = value; }
		}

		#endregion

		#region METHODS

		public bool HasVisited(Location location)
		{
			return _locationsVisited.Contains(location);
		}

        public void UpdateInventoryCategories()
        {
            Ship.Clear();
            Food.Clear();
            Treasure.Clear();

            foreach (var gameItem in _inventory)
            {
                if (gameItem is Ship) Ship.Add(gameItem);
                if (gameItem is Food) Food.Add(gameItem);
                if (gameItem is Treasure) Treasure.Add(gameItem);
            }
        }

        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }

        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
		{
			_locationsVisited = new List<Location>();
            _ship = new ObservableCollection<GameItem>();
            _food = new ObservableCollection<GameItem>();
            _treasure = new ObservableCollection<GameItem>();
        }

		#endregion
	}
}
