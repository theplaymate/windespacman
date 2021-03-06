﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Karo;

namespace Karo.Gui
{
    public partial class KaroGui : Form
    {
        private DialogResult ds;
        public KaroGui()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyUp += new KeyEventHandler(KaroGui_KeyUp);

            newGame();

            InitBGW();
        }


        #region Backgroundworker for invalidate

        private BackgroundWorker bgw;
        private Boolean runBgw = true;
        private int bgwRefresh = 1000;

        private void InitBGW()
        {
            // so we can stop the bgw
            if (runBgw)
            {
                bgw = new BackgroundWorker();
                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                bgw.RunWorkerAsync();
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            // wait for a second
            Thread.Sleep(bgwRefresh);
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // invalidate screen, and rework
            mDrawPanel.Invalidate();
            InitBGW();
        }

        #endregion

        /// <summary>
        /// Average tile width, setted in the drawfunction, also used by MouseUp
        /// </summary>
        private float tileWidth = 0;

        /// <summary>
        /// Average tile height, setted in the drawfunction, also used by MouseUp
        /// </summary>
        private float tileHeight = 0;

        /// <summary>
        /// Big draw method for the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mDrawPanel_Paint(object sender, PaintEventArgs e)
        {
            if (ds == DialogResult.Abort)
                this.Close();
            else
            {
                // get graphics
                Graphics g = e.Graphics;

                // get currentboard from the game
                Board currentBoard = UIConnector.Instance.GetBoard();

                // calculate width and height of the tiles
                tileWidth = mDrawPanel.Width / 21;
                tileHeight = mDrawPanel.Height / 20;

                // if we got a current board, continue
                if (currentBoard != null)
                {
                    // Get the board state
                    BoardPosition[,] board = currentBoard.BoardSituation;

                    // loop trough X positions
                    for (int x = 0; x < 21; x++)
                    {
                        // loop trough Y positions
                        for (int y = 0; y < 20; y++)
                        {
                            // Get current position
                            BoardPosition bp = board[x, y];

                            // standard brush for empty space
                            Brush brush = Brushes.White;

                            // if not empty, there is a tile beneath
                            if (bp != BoardPosition.Empty)
                            {
                                brush = Brushes.Black;

                                if (bp == BoardPosition.Tile)
                                {
                                    if (UIConnector.Instance.IsMovable(x, y))
                                        brush = Brushes.Green;
                                }
                            }

                            // if tile is clicked, show as gray
                            if (mClickedPosition != null)
                                if (mClickedPosition.X == x && mClickedPosition.Y == y && bp == BoardPosition.Tile)
                                    brush = Brushes.Lime;

                            if (bp != BoardPosition.Empty)
                            {
                                // draw tile and raster
                                g.FillRectangle(brush,
                                    x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                            }
                            g.DrawRectangle(Pens.Gray,
                                x * tileWidth, y * tileHeight, tileWidth, tileHeight);


                            // if tile is more then empty or just a tile continue here
                            if (bp != BoardPosition.Empty && bp != BoardPosition.Tile)
                            {
                                // there is a piece, standard red
                                Brush pieceColor = Brushes.Red;

                                // if not red, change now
                                if (bp == BoardPosition.WhiteHead || bp == BoardPosition.WhiteTail)
                                    pieceColor = Brushes.White;

                                // if we clicked once, continue
                                if (mClickedPosition != null)
                                {
                                    // did we clicked here?
                                    if (mClickedPosition.X == x && mClickedPosition.Y == y)
                                    {
                                        // if red, show now as gold instead of red
                                        // if white, show now as deep pink instead of white
                                        if (bp == BoardPosition.RedHead || bp == BoardPosition.RedTail)
                                        {
                                            pieceColor = Brushes.Gold;
                                        }
                                        else if (bp == BoardPosition.WhiteHead || bp == BoardPosition.WhiteTail)
                                        {
                                            pieceColor = Brushes.DeepPink;
                                        }
                                    }
                                }

                                // drawing of the piece
                                // piece is round, so the Math.Min of height and weight is the width and heigt
                                // also make it a big smaller then the tile
                                float maxPieceWidth = Math.Min(tileHeight, tileWidth) * 0.75f;

                                // because it is a bit smaller, calculate offset
                                float pieceX = (tileWidth - maxPieceWidth) / 2f;
                                float pieceY = (tileHeight - maxPieceWidth) / 2f;

                                // draw the ellipse of the piece
                                g.FillEllipse(pieceColor,
                                    x * tileWidth + pieceX, y * tileHeight + pieceY, maxPieceWidth, maxPieceWidth);

                                // if piece has head up, draw a round on top which is a bit smaller
                                if (bp == BoardPosition.RedHead || bp == BoardPosition.WhiteHead)
                                {
                                    // calculate the width
                                    float maxHeadWidth = (Math.Min(tileHeight, tileWidth) * 0.50f);

                                    // calculate offset
                                    float headX = (tileWidth - maxHeadWidth) / 2f;
                                    float headY = (tileHeight - maxHeadWidth) / 2f;

                                    // draw the ellipse
                                    g.DrawEllipse(Pens.Black,
                                        x * tileWidth + headX, y * tileHeight + headY, maxHeadWidth, maxHeadWidth);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Happens when resizing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mDrawPanel_Resize(object sender, EventArgs e)
        {
            mDrawPanel.Invalidate();
        }

        /// <summary>
        /// Stores the clicked position
        /// </summary>
        private Point mClickedPosition = new Point();

        /// <summary>
        /// When mouse released, save clicked position and invalidate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mDrawPanel_MouseUp(object sender, MouseEventArgs e)
        {

            int x = (int)Math.Truncate(e.X / tileWidth);
            int y = (int)Math.Truncate(e.Y / tileHeight);

            Logger.AddLine(UIConnector.Instance.GetCurrentPlayerNumber() + "-> Clicked at column: " + x + " row: " + y);

            if (!UIConnector.Instance.IsTwoAI())
            {
                if (mClickedPosition == new Point())
                {
                    if (UIConnector.Instance.CurrentPlayerNumPieces() < 6)
                    {
                        UIConnector.Instance.PlacePiece(new Point(x, y));
                        mClickedPosition = new Point();
                    }
                    else
                        mClickedPosition = new Point(x, y);
                }
                else if (mClickedPosition == new Point(x, y))
                {
                    // reset clicked position (clicked twice)
                    mClickedPosition = new Point();
                }
                else
                {
                    BoardPosition bp = UIConnector.Instance.AtPosition(mClickedPosition);
                    
                    Point temp = mClickedPosition;
                    mClickedPosition = new Point(x, y);

                    if (bp == BoardPosition.Tile)
                    {
                        UIConnector.Instance.MoveTile(temp, new Point(x, y));
                        mClickedPosition = new Point();
                    }
                    else if (bp != BoardPosition.Empty)
                    {
                        UIConnector.Instance.MovePiece(temp, new Point(x, y));
                        mClickedPosition = new Point();
                    }

                }
            }

            mCurrentPlayerLabel.Text = "Current player: " + UIConnector.Instance.GetCurrentPlayer();

            mDrawPanel.Invalidate();

            if (UIConnector.Instance.IsWon())
            {
                DialogResult ok = MessageBox.Show((UIConnector.Instance.GetCurrentPlayerNumber() == 2 ? "Player A " : "Player B ") + "has won");
                if (ok == DialogResult.OK)
                {
                    newGame();
                }
            }
        }

        #region "Event handling"

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.ClearLog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.ShowLog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.CloseLog();
        }

        #endregion

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private int maxMoves = 100;
        private bool paused = false;

        private void newGame()
        {
            PlayerSetup ps = new PlayerSetup();
            ds = ps.ShowDialog();

            if (ds != DialogResult.Abort)
            {
                PlayerSettings playerA = ps.PlayerA;
                PlayerSettings playerB = ps.PlayerB;

                bgwRefresh = ps.RefreshRate;

                // check to disable bgw
                if (!playerA.IsAI || !playerB.IsAI)
                {
                    runBgw = false;
                }
                maxMoves = ps.MaxAIMoves;
                UIConnector.Instance.MaxAIMoves(maxMoves);
                UIConnector.Instance.StartGame(playerA, playerB);

                mDrawPanel.Invalidate();
                BringToFront();
                Logger.BringToFront();
            }

            mCurrentPlayerLabel.Text = "Current player: " + UIConnector.Instance.GetCurrentPlayer();

            Logger.ShowLog();

            this.SetDesktopLocation(0, 0);
            this.StartPosition = FormStartPosition.Manual;
        }

        void KaroGui_KeyUp(object sender, KeyEventArgs e)
        {
            mClickedPosition = new Point(20, 19);

            if (e.KeyCode == Keys.Space)
            {
                if (paused)
                {
                    if (UIConnector.Instance.IsTwoAI())
                        UIConnector.Instance.DoAiMove(maxMoves);

                    paused = false;
                }
                else
                {
                    if (UIConnector.Instance.IsTwoAI())
                        UIConnector.Instance.DoAiMove(0);

                    paused = true;
                }
            }

            mCurrentPlayerLabel.Text = "Current player: " + UIConnector.Instance.GetCurrentPlayer();

            if (UIConnector.Instance.IsWon())
            {
                DialogResult ok = MessageBox.Show((UIConnector.Instance.GetCurrentPlayerNumber() == 2 ? "Player B " : "Player A ") + "has won");
                if (ok == DialogResult.OK)
                {
                    newGame();
                }
            }
        }
    }
}
