﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTBQuestGame.S2.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
	{

		GameSessionViewModel _gameSessionViewModel;

		public GameSessionView(GameSessionViewModel gameSessionViewModel)
		{
			_gameSessionViewModel = gameSessionViewModel;
			InitializeComponent();
		}

		private void NorthButton_Click(object sender, RoutedEventArgs e)
		{
			_gameSessionViewModel.MoveNorth();
		}

		private void SouthButton_Click(object sender, RoutedEventArgs e)
		{
			_gameSessionViewModel.MoveSouth();
		}

		private void WestButton_Click(object sender, RoutedEventArgs e)
		{
			_gameSessionViewModel.MoveWest();
		}
		private void EastButton_Click(object sender, RoutedEventArgs e)
		{
			_gameSessionViewModel.MoveEast();
		}
        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.AddItemToInventory();
            }
            else
            {
                _gameSessionViewModel.UnableToPickUp();
            }
        }

        private void PutDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.RemoveItemFromInventory();
            }
            else
            {
                _gameSessionViewModel.UnableToPutDown();
            }
        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnUseGameItem();
            }
            else
            {
                _gameSessionViewModel.UnableToUse();
            }
        }

        private void TalkToButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnPlayerTalkTo();
            }
            else
            {
                _gameSessionViewModel.UnableToTalkTo();
            }
            if (LocationShrinesDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnShrineTalkTo();
            }
        }

        private void RecruitButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnPlayerRecruit();
            }
            else
            {
                _gameSessionViewModel.UnableToRecruit();
            }

        }

        private void InteractButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationShrinesDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnInteractWithShrine();
            }
            else
            {
                _gameSessionViewModel.UnableToInteract();
            }
        }
    }
}
