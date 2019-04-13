using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTBQuestGame.S2.Models;
using System.Collections.ObjectModel;

namespace WpfTBQuestGame.S2.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {

        #region FIELDS

        private Player _player;
        private List<string> _messages;

        private Map _gameMap;
        private Location _currentLocation;
		private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private string _currentLocationInformation;




        private GameItem _currentGameItem;  




        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set
			{
				_player = value;
			}
        }

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
			set
			{
				_currentLocation = value;
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
		}

		public Location NorthLocation
		{
			get { return _northLocation; }
			set
			{
				_northLocation = value;
				OnPropertyChanged(nameof(NorthLocation));
				OnPropertyChanged(nameof(HasNorthLocation));
			}
		}

		public Location EastLocation
		{
			get { return _eastLocation; }
			set
			{
				_eastLocation = value;
				OnPropertyChanged(nameof(EastLocation));
				OnPropertyChanged(nameof(HasEastLocation));
			}
		}

		public Location SouthLocation
		{
			get { return _southLocation; }
			set
			{
				_southLocation = value;
				OnPropertyChanged(nameof(SouthLocation));
				OnPropertyChanged(nameof(HasSouthLocation));
			}
		}

		public Location WestLocation
		{
			get { return _westLocation; }
			set
			{
				_westLocation = value;
				OnPropertyChanged(nameof(WestLocation));
				OnPropertyChanged(nameof(HasWestLocation));
			}
		}

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

		public bool HasNorthLocation { get { return NorthLocation != null; } }
		public bool HasEastLocation { get { return EastLocation != null; } }
		public bool HasSouthLocation { get { return SouthLocation != null; } }
		public bool HasWestLocation { get { return WestLocation != null; } }

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

		#endregion

		#region METHODS

		#endregion

		#region CONSTRUCTORS

		public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates
            )
        {
            _player = player;
            _messages = initialMessages;

            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
			InitializeView();
		}

		private void InitializeView()
		{
			UpdateAvailableTravelPoints();
            _player.UpdateInventoryCategories();
		}

        #region MOVEMENT METHODS

		/// <summary>
		/// calculate travel points
		/// </summary>

		private void UpdateAvailableTravelPoints()
		{
			//
			// reset travel location information
			//
			NorthLocation = null;
			EastLocation = null;
			SouthLocation = null;
			WestLocation = null;

			if (_gameMap.NorthLocation(_player) != null)
			{
				NorthLocation = _gameMap.NorthLocation(_player);
			}

			if (_gameMap.EastLocation(_player) != null)
			{
				EastLocation = _gameMap.EastLocation(_player);
			}

			if (_gameMap.SouthLocation(_player) != null)
			{
				SouthLocation = _gameMap.SouthLocation(_player);
			}

			if (_gameMap.WestLocation(_player) != null)
			{
				WestLocation = _gameMap.WestLocation(_player);
			}
		}

		/// <summary>
		/// player move event handler
		/// </summary>
		private void OnPlayerMove()
		{
			//
			// update player stats
			//
				_player.Traveled += _currentLocation.ModifyTraveled;
                _player.Health = _player.Health - 10;

			if (!_player.HasVisited(_currentLocation))
			{
				_player.LocationsVisited.Add(_currentLocation);
				_player.Exp += _currentLocation.ModifyExp;
			}
            if (_player.Health <= 0)
            {
                _player.Lives = _player.Lives - 1;
                _player.Health = _player.Health + 100;
            }
		}

		/// <summary>
		/// travel north
		/// </summary>
		public void MoveNorth()
        {
            _gameMap.MoveNorth();
            CurrentLocation = _gameMap.CurrentLocation;
			UpdateAvailableTravelPoints();
			OnPlayerMove();

        }

        /// <summary>
        /// travel east
        /// </summary>
        public void MoveEast()
        {
            _gameMap.MoveEast();
            CurrentLocation = _gameMap.CurrentLocation;
			UpdateAvailableTravelPoints();
			OnPlayerMove();
        }

        /// <summary>
        /// travel south
        /// </summary>
        public void MoveSouth()
        {
            _gameMap.MoveSouth();
            CurrentLocation = _gameMap.CurrentLocation;
			UpdateAvailableTravelPoints();
			OnPlayerMove();
        }

        /// <summary>
        /// travel west
        /// </summary>
        public void MoveWest()
        {
            _gameMap.MoveWest();
            CurrentLocation = _gameMap.CurrentLocation;
			UpdateAvailableTravelPoints();
			OnPlayerMove();
        }

        #endregion

        #region ACTION METHODS

        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }

        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                OnPlayerPutDown(selectedGameItem);
            }
        }

        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.Exp += gameItem.Exp;
        }

        private void OnPlayerPutDown(GameItem gameItem)
        {
        }

        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case Food food:
                    ProcessFoodUse(food);
                    break;
                case Ship ship:
                    ProcessShipUse(ship);
                    break;
                default:
                    break;
            }
        }

        private void ProcessFoodUse(Food food)
        {
            _player.Health += food.HealthChange;
            _player.RemoveGameItemFromInventory(_currentGameItem);
        }

        private void ProcessShipUse(Ship ship)
        {
            string message;

            switch (ship.UseAction)
            {
                case Ship.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByShip(ship.Id);
                    CurrentLocationInformation = ship.UseMessage;
                    break;
                case Ship.UseActionType.CREWNEEDED:
                    CheckForCrew(ship.UseMessage);
                    break;
                default:
                    break;
            }
        }

        private void CheckForCrew(string useMessage)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
