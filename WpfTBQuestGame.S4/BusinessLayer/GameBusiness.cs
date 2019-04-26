using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTBQuestGame.S2.Models;
using WpfTBQuestGame.S2.DataLayer;
using WpfTBQuestGame.S2.PresentationLayer;
using System.Collections.ObjectModel;

namespace WpfTBQuestGame.S2.BusinessLayer
{
    public class GameBusiness
    {
        bool _newPlayer = true;

        GameSessionViewModel _gameSessionViewModel;
        Player _player = new Player();
        List<string> _messages;

        PlayerSetupView _playerSetupView = null;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        public void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                //
                // setup up game based player properties
                //
                _player.Exp = 0;
                _player.Health = 100;
                _player.Lives = 3;

				_player.Inventory = new ObservableCollection<GameItem>(GameData.DefaultInventoryGameItems());
                _player.Crew = new ObservableCollection<Npc>()
                {

                };
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        private void InstantiateAndShowView()
        {
            _gameSessionViewModel = new GameSessionViewModel(_player, _messages, GameData.GameMapData(), GameData.InitialGameMapLocation());
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();
        }

        private void InitializeDataSet()
        {
            if (!_newPlayer)
            {
                _player = GameData.PlayerData();
            }

			_messages = GameData.InitialMessages();

        }
    }
}
