﻿using GameOfNim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNim.GameProcesses
{
    public class NimGame
    {
        public Player player1;
        public Player player2;
        public Board gameBoard;
        public int turnCounter = 0;
        int difficulty;
        bool isPVP;
        Random randold = new Random();
        public NimGame(int difficulty, bool isPVP)
        {
            gameBoard = new Board(difficulty);

            if (!isPVP)
            {
                this.isPVP = false;
                player1 = new Player(true);
                player1.InitializePlayer();
                player2 = new Player(false);
                player2.InitializePlayer();
            }
            else if (isPVP)
            {
                this.isPVP = true;
                player1 = new Player(true);
                player1.InitializePlayer();
                player2 = new Player(true);
                player2.InitializePlayer();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void PlayerTurn()
        {
            this.turnCounter += 1;
            if(!isPVP)
            {
                CompPlayerMove();
            }
        }
        public void CompPlayerMove()
        {
            bool valid = true;
            do
            {
                int numOfHeaps = gameBoard.numOfHeaps;
                int heapToRemove = randold.Next(0, numOfHeaps);
                int objectsInHeap = gameBoard.heaps[heapToRemove];
                int objectsToRemove = randold.Next(1, objectsInHeap + 1);
                if (GameOfNimRules.IsMoveLegal(heapToRemove, objectsToRemove, gameBoard))
                {
                    gameBoard.heaps[heapToRemove] = -objectsToRemove;
                    this.turnCounter += 1;
                }
                else
                {
                    valid = false;
                }
            }
            while (!valid);
        }
        public int CheckObjectTotal()
        {
            int totalObjects = 0;
            foreach(int i in gameBoard.heaps)
            {
                totalObjects += i;
            }
            return totalObjects;
        }
        public int CheckHeap()
        {
            return 1;
        }
    }
}
