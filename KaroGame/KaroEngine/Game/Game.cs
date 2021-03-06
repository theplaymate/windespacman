﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;

namespace Karo
{
    /// <summary>
    /// Kind of world to contain much
    /// </summary>
    public class Game
    {
        public AIPlayer playerA;
        public AIPlayer playerB;
        private Boolean turnPlayerA;
        private Board board;
        private static Game instance;

        /// <summary>
        /// Show log information in console
        /// </summary>
        public bool ShowDebug { get; set; }
         
        private Game() 
        {
            ShowDebug = false;
        }

        /// <summary>
        /// returns an instance of game
        /// </summary>
        /// <returns>game</returns>
        public static Game Instance
        {
            get
            {
                if (instance == null)
                    instance = new Game();
                return instance;
            }
        }

        /// <summary>
        /// gets the current board
        /// </summary>
        /// <returns>current board</returns>
        public Board GetBoard()
        {
            if (playerA.PlayerSettings.IsAI && playerB.PlayerSettings.IsAI)
            {
                MakeAIMove();
            }
            return (Board)board.Clone();
        }

        /// <summary>
        /// gets the current player
        /// </summary>
        /// <returns>bool turn of PlayerA</returns>
        public Boolean GetTurn()
        {
            return turnPlayerA;
        }

        /// <summary>
        /// sets the board
        /// </summary>
        /// <param name="board">the new board</param>
        public void SetBoard(Board board)
        {
            if (IsEqual(this.board, board))
                throw new Exception();
            this.board = board;
        }

        private bool IsEqual(Board boardA, Board boardB)
        {
            for (int x = 0; x < 21; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (boardA.BoardSituation[x, y] != boardB.BoardSituation[x, y])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Will return what is at position
        /// </summary>
        /// <param name="column">X value of tile</param>
        /// <param name="row">Y value of tile</param>
        /// <returns>BoardPosition</returns>
        public BoardPosition AtPosition(int column, int row)
        {
            return board.BoardSituation[column, row];
        }

        /// <summary>
        /// Will return what is at position
        /// </summary>
        /// <param name="point">Point of tile</param>
        /// <returns></returns>
        public BoardPosition AtPosition(Point point)
        {
            return AtPosition(point.X, point.Y);
        }

        /// <summary>
        /// move tile to a new point
        /// </summary>
        /// <param name="a">from point</param>
        /// <param name="b">to point</param>
        public void MoveTile(Point a, Point b)
        {
            Board cloneBoard = (Board)board.Clone();

            cloneBoard.BoardSituation[b.X, b.Y] = BoardPosition.Tile;
            cloneBoard.BoardSituation[a.X, a.Y] = BoardPosition.Empty;
            cloneBoard.IsTileMoved = true;
            cloneBoard.MovedTilePosition = new Point(b.X, b.Y);
            cloneBoard.CalculateMovableTiles();

            List<Board> possibleMoves = board.GenerateMoves(turnPlayerA);
            bool isInList = false;

            foreach (Board pm in possibleMoves)
            {
                if (pm.CompareTo(cloneBoard) == 0)
                    isInList = true;
            }

            if (isInList)
            {
                Logger.AddLine(GetCurrentPlayerNumber() + "-> Moved tile from: " + a.X + ", " + a.Y + " to " + b.X + ", " + b.Y);
       
                board = cloneBoard;
            }
            else
            {
                Logger.AddLine(GetCurrentPlayerNumber() + "-> It's not possible to move tile from: " + a.X + ", " + a.Y + " to " + b.X + ", " + b.Y);
            }
        }

        public bool ValidateMoveTile(Point a, Point b)
        {
            Board cloneBoard = (Board)board.Clone();

            cloneBoard.BoardSituation[b.X, b.Y] = BoardPosition.Tile;
            cloneBoard.BoardSituation[a.X, a.Y] = BoardPosition.Empty;
            cloneBoard.IsTileMoved = true;
            cloneBoard.MovedTilePosition = new Point(b.X, b.Y);
            cloneBoard.CalculateMovableTiles();

            List<Board> possibleMoves = board.GenerateMoves(turnPlayerA);
            bool isInList = false;

            foreach (Board pm in possibleMoves)
            {
                if (pm.CompareTo(cloneBoard) == 0)
                    isInList = true;
            }
            return isInList;
        }

        /// <summary>
        /// move piece to a new point and switches the turn
        /// </summary>
        /// <param name="a">from point</param>
        /// <param name="b">to point</param>
        public void MovePiece(Point a, Point b)
        {
            Board cloneBoard = (Board)board.Clone();

            BoardPosition old = cloneBoard.BoardSituation[a.X, a.Y];
            cloneBoard.IsTileMoved = false;
            if(Math.Abs(a.X - b.X)==2 || Math.Abs(a.Y - b.Y) == 2)
            {
                switch (old)
                {
                    case BoardPosition.RedTail:
                        old = BoardPosition.RedHead;
                        break;
                    case BoardPosition.RedHead:
                        old = BoardPosition.RedTail;
                        break;
                    case BoardPosition.WhiteTail:
                        old = BoardPosition.WhiteHead;
                        break;
                    case BoardPosition.WhiteHead:
                        old = BoardPosition.WhiteTail;
                        break;
                }
            }

            cloneBoard.BoardSituation[b.X, b.Y] = old;
            cloneBoard.BoardSituation[a.X, a.Y] = BoardPosition.Tile;
            cloneBoard.CalculateMovableTiles();
            List<Board> possibleMoves = board.GenerateMoves(turnPlayerA);
            bool isInList = false;

            foreach (Board pm in possibleMoves)
            {
                if (pm.CompareTo(cloneBoard) == 0)
                    isInList = true;
            }

            if(isInList)
            {
                Logger.AddLine(GetCurrentPlayerNumber() + "-> Moved piece from: " + a.X + ", " + a.Y + " to " + b.X + ", " + b.Y);
                board = cloneBoard;
                ChangePlayer();
            }
            else
            {
                Logger.AddLine(GetCurrentPlayerNumber() + " -> It's not possible to move piece from: " + a.X + ", " + a.Y + " to " + b.X + ", " + b.Y);
            }
        }

        public bool ValidateMovePiece(Point a, Point b)
        {
            Board cloneBoard = (Board)board.Clone();

            BoardPosition old = cloneBoard.BoardSituation[a.X, a.Y];
            cloneBoard.IsTileMoved = false;
            if (Math.Abs(a.X - b.X) == 2 || Math.Abs(a.Y - b.Y) == 2)
            {
                switch (old)
                {
                    case BoardPosition.RedTail:
                        old = BoardPosition.RedHead;
                        break;
                    case BoardPosition.RedHead:
                        old = BoardPosition.RedTail;
                        break;
                    case BoardPosition.WhiteTail:
                        old = BoardPosition.WhiteHead;
                        break;
                    case BoardPosition.WhiteHead:
                        old = BoardPosition.WhiteTail;
                        break;
                }
            }

            cloneBoard.BoardSituation[b.X, b.Y] = old;
            cloneBoard.BoardSituation[a.X, a.Y] = BoardPosition.Tile;
            cloneBoard.CalculateMovableTiles();
            List<Board> possibleMoves = board.GenerateMoves(turnPlayerA);
            bool isInList = false;

            foreach (Board pm in possibleMoves)
            {
                if (pm.CompareTo(cloneBoard) == 0)
                    isInList = true;
            }
            return isInList;
        }

        /// <summary>
        /// place pace to a point and switches the turn
        /// </summary>
        /// <param name="point">point for piece</param>
        public void PlacePiece(Point point)
        {
            Board b = (Board)board.Clone();
            b.BoardSituation[point.X, point.Y] = (turnPlayerA ? BoardPosition.RedTail : BoardPosition.WhiteTail);

            if (turnPlayerA)
                b.RedItems++;
            else
                b.WhiteItems++;

            bool isInList = false;
            b.CalculateMovableTiles();
            List<Board> possibleMoves = board.GenerateMoves(turnPlayerA);

            foreach (Board pm in possibleMoves)
            {
                if(pm.CompareTo(b)==0)
                    isInList = true;
            }

            if (isInList)
            {
                board = b;

                Logger.AddLine(GetCurrentPlayerNumber() + "-> Placed piece on: " + point.X + ", " + point.Y);
                Logger.AddLine("Board -> Evaluationvalue: " + board.Evaluation(turnPlayerA, turnPlayerA));

                ChangePlayer();
            }
            else
            {
                Logger.AddLine(GetCurrentPlayerNumber() + "-> Placing piece on: " + point.X + ", " + point.Y + " is not a valid move");
            }

        }

        public bool ValidatePlacePiece(Point point)
        {
            Board b = (Board)board.Clone();
            b.BoardSituation[point.X, point.Y] = (turnPlayerA ? BoardPosition.RedTail : BoardPosition.WhiteTail);

            if (turnPlayerA)
                b.RedItems++;
            else
                b.WhiteItems++;

            bool isInList = false;
            b.CalculateMovableTiles();
            List<Board> possibleMoves = board.GenerateMoves(turnPlayerA);

            foreach (Board pm in possibleMoves)
            {
                if (pm.CompareTo(b) == 0)
                    isInList = true;
            }
            return isInList;
        }

        /// <summary>
        /// starts a new game with a startboard and a turningplayer
        /// </summary>
        /// <param name="playerA">playersettings of player A</param>
        /// <param name="playerB">playersettings of player B</param>
        /// <param name="startBoard">a board to start with</param>
        /// <param name="startPlayer">player that turns first</param>
        public void StartGame(PlayerSettings playerA, PlayerSettings playerB, Board startBoard, int startPlayer)
        {
            this.playerA = new AIPlayer(playerA);
            this.playerB = new AIPlayer(playerB);
            NumMovesA = 0;
            NumMovesB = 0;
            this.board = startBoard;
            this.turnPlayerA = (startPlayer == 0 ? true : false);

            Logger.AddLine("Start new game, with startboard and turningPlayer");

            MakeAIMove();
        }

        /// <summary>
        /// starts a new game with a starboard
        /// </summary>
        /// <param name="playerA">playersettings of player A</param>
        /// <param name="playerB">playersettings of player B</param>
        /// <param name="startBoard">a board to start with</param>
        public void StartGame(PlayerSettings playerA, PlayerSettings playerB, Board startBoard)
        {
            this.playerA = new AIPlayer(playerA);
            this.playerB = new AIPlayer(playerB);
            NumMovesA = 0;
            NumMovesB = 0;
            this.board = startBoard;
            
            // random first player
            System.Random r = new System.Random();
            int player = r.Next(1, 3);
            
            turnPlayerA = true;
            if(player == 2)
                turnPlayerA = false;

            Logger.AddLine("Start new game, with startboard");

            MakeAIMove();
        }

        /// <summary>
        /// starts a new game
        /// </summary>
        /// <param name="playerA">playersettings of player A</param>
        /// <param name="playerB">playersettings of player B</param>
        public void StartGame(PlayerSettings playerA, PlayerSettings playerB)
        {
            this.playerA = new AIPlayer(playerA);
            this.playerB = new AIPlayer(playerB);
            
            NumMovesA = 0;
            NumMovesB = 0;

            // random first player
            System.Random r = new System.Random();
            int player = r.Next(1, 3);

            turnPlayerA = true;
            if (player == 2)
                turnPlayerA = false;

            board = new Board();

            Logger.AddLine("Start new game");

            MakeAIMove();
        }

        public AIPlayer GetCurrentPlayer()
        {
            if (turnPlayerA)
                return playerA;
            else
                return playerB;
        }

        /// <summary>
        /// Returns the amount of pieces of the current player
        /// </summary>
        /// <returns>Min 0, max 6</returns>
        public int CurrentPlayerNumPieces()
        {
            if (turnPlayerA)
                return board.RedItems;
            else
                return board.WhiteItems;
        }

        /// <summary>
        /// Changes the current player and checks if he want to do something
        /// </summary>
        public void ChangePlayer()
        {
            turnPlayerA = (turnPlayerA ? false : true);
            if(!(playerA.PlayerSettings.IsAI && playerB.PlayerSettings.IsAI))
                MakeAIMove();            
        }

        private int NumMovesA;
        private int NumMovesB;

        private int maxMoves = 1;
        
        /// <summary>
        /// Max moves that can be done by a AI player
        /// </summary>
        public int MaxMoves
        {
            get
            {
                if (maxMoves < 0)
                    maxMoves = 0;
                return maxMoves;
            }
            set
            {
                if (value < 0)
                    maxMoves = 0;
                else
                    maxMoves = value;
            }
        }

        /// <summary>
        /// Checks if currentplayer is AI and if, then execute move
        /// </summary>
        public void MakeAIMove()
        {
            Board boardClone = (Board)board.Clone();
            if (!boardClone.IsWon())
            {
                DateTime beforeFunction = DateTime.Now;

                if ((NumMovesA >= MaxMoves && NumMovesB >= MaxMoves) && IsTwoAI())
                {
                    // max moves reached
                    
                }
                else
                {
                    // Check if turn of player a and if so if he is AI driven, else check the same for b
                    if (turnPlayerA && playerA.PlayerSettings.IsAI)
                    {
                        // execute ai move
                        playerA.Execute(boardClone);
                        Board boardCloneClone = (Board)board.Clone();
                        if (boardCloneClone.IsTileMoved)
                            playerA.Execute(boardCloneClone);
                        // change player
                        NumMovesA++;
                        NumMovesB++;


                        // Elapsed time
                        DateTime afterFunction = DateTime.Now;
                        TimeSpan elapsedTime = afterFunction - beforeFunction;

                        int num = NumMovesA;
                        Logger.AddLine(Game.Instance.GetCurrentPlayerNumber() + "-> AI calculated in: " + elapsedTime.TotalMilliseconds.ToString() + " ms (move: " + num + " / " + maxMoves + ")");

                        ChangePlayer();
                    }
                    else if (!turnPlayerA && playerB.PlayerSettings.IsAI)
                    {
                        playerB.Execute(boardClone);
                        Board boardCloneClone = (Board)board.Clone();
                        if (boardCloneClone.IsTileMoved)
                            playerB.Execute(boardCloneClone);
                        // change player
                        NumMovesA++;
                        NumMovesB++;

                        // Elapsed time
                        DateTime afterFunction = DateTime.Now;
                        TimeSpan elapsedTime = afterFunction - beforeFunction;

                        int num = NumMovesB;
                        Logger.AddLine(Game.Instance.GetCurrentPlayerNumber() + "-> AI calculated in: " + elapsedTime.TotalMilliseconds.ToString() + " ms (move: " + num + " / " + maxMoves + ")");

                        ChangePlayer();
                    }
                }
            }
        }

        public void DoAIMove(int moves)
        {
            NumMovesA = 0;
            NumMovesB = 0;

            maxMoves = moves;
            //MakeAIMove();
        }

        public bool IsTwoAI()
        {
            if (playerA.PlayerSettings.IsAI && playerB.PlayerSettings.IsAI)
                return true;

            return false;
        }

        /// <summary>
        /// Returns current player number
        /// </summary>
        /// <returns>1 or 2</returns>
        public int GetCurrentPlayerNumber()
        {
            if (GetTurn())
                return 1;
            else
                return 2;
        }

        /// <summary>
        /// Gets movable points
        /// </summary>
        /// <returns>List of movable points</returns>
        public List<Point> GetMovablePoints()
        {

            return board.MovablePoints;
        }
    }
}
