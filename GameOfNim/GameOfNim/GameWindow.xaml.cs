﻿using GameOfNim.GameProcesses;
using GameOfNim.Models;
using System;
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

namespace GameOfNim
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        //All these text boxes are for values for the remove button event to read
        TextBox removeBoxZero = new TextBox();
        TextBox removeBoxOne = new TextBox();
        TextBox removeBoxTwo = new TextBox();
        TextBox removeBoxThree = new TextBox();
        //The grids containing the labels that correspond to heap objects
        Grid heapOne = new Grid();
        Grid heapTwo = new Grid();
        Grid heapThree = new Grid();
        Grid heapZero = new Grid();
        //The current instance of the game
        private NimGame currentGame;
        public GameWindow(int difficulty, bool isPVP)
        {
            currentGame = new NimGame(difficulty, isPVP);
            InitializeComponent();
            DisplayName();
            //This if statement holds all difficulty cases
            if(difficulty == 1)
            {
                //Dynamically create the gui for easy mode
                for(int i = 0; i < 2; i++)
                {
                    StackPanel stack = new StackPanel();
                    Button removeButton = new Button();
                    removeButton.Content = "R E M O V E";
                    if(i == 0)
                    {
                        removeButton.Click += RemoveButtonZero_Click;
                        stack.Children.Add(removeBoxZero);
                    }
                    else
                    {
                        removeButton.Click += RemoveButtonOne_Click;
                        stack.Children.Add(removeBoxOne);
                    }
                    stack.Children.Add(removeButton);
                    GameBoard.Children.Add(stack);
                    Grid.SetRow(stack, 1);
                    Grid.SetColumn(stack, i);
                }
            }
            else if (difficulty == 2)
            {
                GameBoard.ColumnDefinitions.Add(new ColumnDefinition());
                //Dynamically create the gui for medium mode
                for (int i = 0; i < 3; i++)
                {
                    StackPanel stack = new StackPanel();
                    Button removeButton = new Button();
                    removeButton.Content = "R E M O V E";
                    if (i == 0)
                    {
                        removeButton.Click += RemoveButtonZero_Click;
                        stack.Children.Add(removeBoxZero);
                    }
                    else if(i == 1)
                    {
                        removeButton.Click += RemoveButtonOne_Click;
                        stack.Children.Add(removeBoxOne);
                    }
                    else
                    {
                        removeButton.Click += RemoveButtonTwo_Click;
                        stack.Children.Add(removeBoxTwo);
                    }
                    stack.Children.Add(removeButton);
                    GameBoard.Children.Add(stack);
                    Grid.SetRow(stack, 1);
                    Grid.SetColumn(stack, i);
                }
            }
            else
            {
                GameBoard.ColumnDefinitions.Add(new ColumnDefinition());
                GameBoard.ColumnDefinitions.Add(new ColumnDefinition());
                //Dynamically create the gui for hard mode 
                for (int i = 0; i < 4; i++)
                {
                    StackPanel stack = new StackPanel();
                    Button removeButton = new Button();
                    removeButton.Content = "R E M O V E";
                    if (i == 0)
                    {
                        removeButton.Click += RemoveButtonZero_Click;
                        stack.Children.Add(removeBoxZero);
                    }
                    else if (i == 1)
                    {
                        removeButton.Click += RemoveButtonOne_Click;
                        stack.Children.Add(removeBoxOne);
                    }
                    else if (i == 2)
                    {
                        removeButton.Click += RemoveButtonTwo_Click;
                        stack.Children.Add(removeBoxTwo);
                    }
                    else
                    {
                        removeButton.Click += RemoveButtonThree_Click;
                        stack.Children.Add(removeBoxThree);
                    }
                    stack.Children.Add(removeButton);
                    GameBoard.Children.Add(stack);
                    Grid.SetRow(stack, 1);
                    Grid.SetColumn(stack, i);
                }                
            }
            //Make the game board and populate the heaps with objects
            //based on which difficulty was picked.
            for (int i = 0; i < GameBoard.ColumnDefinitions.Count; i++)
            {
                //A temporary grid that contains heap objects the be transferred
                //over to specific heaps.
                Grid tempGrid = new Grid();
                for (int j = 0; j < 10; j++)
                {
                    tempGrid.RowDefinitions.Add(new RowDefinition());
                }
                for (int j = 0; j < currentGame.gameBoard.heaps[i]; j++)
                {
                    //The creation of an object
                    Label tempLabel = new Label();
                    tempLabel.Background = Brushes.Firebrick;
                    tempLabel.BorderThickness = new Thickness(2);
                    tempGrid.Children.Add(tempLabel);
                    Grid.SetRow(tempLabel, 9 - j);
                }
                if (i == 0)
                {
                    heapZero = tempGrid;
                    GameBoard.Children.Add(tempGrid);
                    Grid.SetColumn(heapZero, i);
                }
                else if (i == 1)
                {
                    heapOne = tempGrid;
                    GameBoard.Children.Add(tempGrid);
                    Grid.SetColumn(heapOne, i);
                }
                else if (i == 2)
                {
                    heapTwo = tempGrid;
                    GameBoard.Children.Add(tempGrid);
                    Grid.SetColumn(heapTwo, i);
                }
                else
                {
                    heapThree = tempGrid;
                    GameBoard.Children.Add(tempGrid);
                    Grid.SetColumn(heapThree, i);
                }
            }
        }
        /// <summary>
        /// Removes objects from the first heap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButtonZero_Click(object sender, RoutedEventArgs e)
        {
            int objectAmountRemoved;
            int.TryParse(removeBoxZero.Text, out objectAmountRemoved);
            if(GameOfNimRules.IsMoveLegal(0, objectAmountRemoved, currentGame.gameBoard))
            {
                currentGame.gameBoard.heaps[0] -= objectAmountRemoved;
                currentGame.PlayerTurn();
                RepopulateBoard();
                DisplayName();
            }
            else
            {
                MessageBox.Show("Invalid move. Try again.", "E R R O R");
            }
        }
        /// <summary>
        /// Removes objects from the second heap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButtonOne_Click(object sender, RoutedEventArgs e)
        {
            int objectAmountRemoved;
            int.TryParse(removeBoxOne.Text, out objectAmountRemoved);
            if (GameOfNimRules.IsMoveLegal(1, objectAmountRemoved, currentGame.gameBoard))
            {
                currentGame.gameBoard.heaps[1] -= objectAmountRemoved;
                currentGame.PlayerTurn();
                RepopulateBoard();
                DisplayName();
            }
            else
            {
                MessageBox.Show("Invalid move. Try again.", "E R R O R");
            }
        }
        /// <summary>
        /// Removes objects from the third heap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            int objectAmountRemoved;
            int.TryParse(removeBoxTwo.Text, out objectAmountRemoved);
            if (GameOfNimRules.IsMoveLegal(2, objectAmountRemoved, currentGame.gameBoard))
            {
                currentGame.gameBoard.heaps[2] -= objectAmountRemoved;
                currentGame.PlayerTurn();
                RepopulateBoard();
                DisplayName();
            }
            else
            {
                MessageBox.Show("Invalid move. Try again.", "E R R O R");
            }
        }
        /// <summary>
        /// Removes objects from the fourth heap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButtonThree_Click(object sender, RoutedEventArgs e)
        {
            int objectAmountRemoved;
            int.TryParse(removeBoxThree.Text, out objectAmountRemoved);
            if (GameOfNimRules.IsMoveLegal(3, objectAmountRemoved, currentGame.gameBoard))
            {
                currentGame.gameBoard.heaps[3] -= objectAmountRemoved;
                currentGame.PlayerTurn();
                RepopulateBoard();
                DisplayName();
            }
            else
            {
                MessageBox.Show("Invalid move. Try again.", "E R R O R");
            }
        }

        /// <summary>
        /// Makes the instructions window popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            Instructions instructionsWindow = new Instructions();
            instructionsWindow.ShowDialog();
        }

        /// <summary>
        /// Exits out of the entire game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Repopulate the board after a turn is made to present an
        /// updated GUI
        /// </summary>
        private void RepopulateBoard()
        {
            //Checks if anyone has lost yet
            if (GameOfNimRules.PlayerLoses(currentGame.CheckObjectTotal()))
            { 
                if((currentGame.turnCounter-1)%2 == 0)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                    MessageBox.Show($"{currentGame.player1.Name} loses! {currentGame.player2.Name} wins!");
                }
                else
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                    MessageBox.Show($"{currentGame.player2.Name} loses! {currentGame.player1.Name} wins!");                   
                }
            }
            //Clear all heaps in preparation for repopulation
            heapZero.Children.Clear();
            heapOne.Children.Clear();
            heapTwo.Children.Clear();
            heapThree.Children.Clear();
            //Follows the same logic as before for repopulating individual heaps
            //based on objects contained in the board class
            for (int i = 0; i < GameBoard.ColumnDefinitions.Count; i++)
            {
                Grid tempGrid = new Grid();
                for (int j = 0; j < 10; j++)
                {
                    tempGrid.RowDefinitions.Add(new RowDefinition());
                }
                for (int j = 0; j < currentGame.gameBoard.heaps[i]; j++)
                {
                    Label tempLabel = new Label();
                    tempLabel.Background = Brushes.Firebrick;
                    tempLabel.BorderThickness = new Thickness(2);
                    tempGrid.Children.Add(tempLabel);
                    Grid.SetRow(tempLabel, 9 - j);
                }
                if (i == 0)
                {
                    heapZero = tempGrid;
                    GameBoard.Children.Add(tempGrid);
                    Grid.SetColumn(heapZero, i);
                }
                else if (i == 1)
                {
                    heapOne = tempGrid;
                    GameBoard.Children.Add(tempGrid);
                    Grid.SetColumn(heapOne, i);
                }
                else if (i == 2)
                {
                    heapTwo = tempGrid;
                    GameBoard.Children.Add(tempGrid);
                    Grid.SetColumn(heapTwo, i);
                }
                else
                {
                    heapThree = tempGrid;
                    GameBoard.Children.Add(tempGrid);
                    Grid.SetColumn(heapThree, i);
                }
            }
        }

        /// <summary>
        /// Displays the name of the user whose current
        /// turn it is
        /// </summary>
        private void DisplayName()
        {
            if (currentGame.turnCounter % 2 == 0)
            {
                TurnLabel.Content = $"{currentGame.player1.Name}'s turn!";
            }
            else
            {
                TurnLabel.Content = $"{currentGame.player2.Name}'s turn!";
            }
        }
    }
}
