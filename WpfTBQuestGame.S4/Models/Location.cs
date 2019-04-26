using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        private ObservableCollection<GameItem> _gameItems;
        private ObservableCollection<Npc> _citizens;

        private int _requiredShipId;

		private ObservableCollection<Npc> _npcs;
        private ObservableCollection<Shrine> _shrines;




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

        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        public int RequiredShipId
        {
            get { return _requiredShipId; }
            set { _requiredShipId = value; }
        }

		public ObservableCollection<Npc> Npcs
		{
			get { return _npcs; }
			set { _npcs = value; }
		}

        public ObservableCollection<Npc> Citizens
        {
            get { return _citizens; }
            set { _citizens = value; }
        }

        public ObservableCollection<Shrine> Shrines
        {
            get { return _shrines; }
            set { _shrines = value; }
        }

		#endregion

		#region METHODS

		public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();

            foreach (GameItem GameItem in _gameItems)
            {
                updatedLocationGameItems.Add(GameItem);
            }

            GameItems.Clear();

            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
        }

        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Add(selectedGameItem);
            }

            UpdateLocationGameItems();
        }

        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Remove(selectedGameItem);
            }

            UpdateLocationGameItems();
        }

        public void UpdateLocationNpcs()
        {
            ObservableCollection<Npc> updateLocationNpcs = new ObservableCollection<Npc>();

            foreach (Npc Npc in _npcs)
            {
                updateLocationNpcs.Add(Npc);
            }
            Npcs.Clear();

            foreach (Npc npc in updateLocationNpcs)
            {
                Npcs.Add(npc);
            }
        }

        public void RemoveNpcFromLocation(Npc selectedNpc)
        {
            if (selectedNpc != null)
            {
                _npcs.Remove(selectedNpc);
            }

            UpdateLocationNpcs();
        }

        #endregion

        #region CONSTRUCTORS

        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
            _citizens = new ObservableCollection<Npc>();
        }

		#endregion
	}
}
