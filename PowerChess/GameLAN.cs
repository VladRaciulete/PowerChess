using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerChess
{
    internal class GameLAN
    {
        public Piece[,] board;
        public Player player1;
        public Player player2;
        public Player playerTurn;
        public List<Move> movesMade;
        public bool isCheck;
        public bool isCheckMate;


        public GameLAN(string name1, string name2)
        {
            this.board = new Piece[10, 10];
            Random randomNr = new Random();
            movesMade = new List<Move>();
            this.isCheck = false;
            this.isCheckMate = false;
            randomNr.Next(2);

            if (randomNr.Next(2) == 0)
            {
                this.player1 = new Player(name1, PieceColor.White);
                this.player2 = new Player(name2, PieceColor.Black);
                this.playerTurn = this.player1;

                GeneratePiecesWhiteDown();
            }
            else
            {
                this.player1 = new Player(name1, PieceColor.Black);
                this.player2 = new Player(name2, PieceColor.White);
                this.playerTurn = this.player2;

                GeneratePiecesBlackDown();
            }
        }

        public int MakeMove(Move move, ref PictureBox[,] P)
        {
            //return 0 - no check
            //return 1 - check
            //return 2 - checkmate

            Point source = move.GetSource();
            Point destination = move.GetDestination();

            List<Point> legalMoves = board[source.X, source.Y].CalculateLegalPositions(board, source);

            if (listContains(legalMoves, destination))//NOT NEEDED
            {
                if (board[destination.X, destination.Y] != null)
                {
                    playerTurn.AddCapturedPiece(board[destination.X, destination.Y]);
                }
                movesMade.Add(move);


                board[destination.X, destination.Y] = board[source.X, source.Y];
                board[destination.X, destination.Y].PieceHasMoved();
                board[source.X, source.Y] = null;

                P[destination.X, destination.Y].Image = P[source.X, source.Y].Image;
                P[source.X, source.Y].Image = null;

                SwitchPlayer();
            }

            if (IsCheck(board,playerTurn.GetPlayerColor())) {
                return 1;
            }

            return 0;// no check after the move
        }


        public void SwitchPlayer()
        {
            if (playerTurn == player1)
            {
                player1 = playerTurn;
                playerTurn = player2;
            }
            else
            {
                player2 = playerTurn;
                playerTurn = player1;
            }
        }



        public bool IsCheck(Piece[,] board, PieceColor color)
        {
            List<Point> attackedSquares = new List<Point>();
            int xCoord = 0, yCoord = 0;

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (board[x, y] != null)
                    {
                        if (board[x, y].GetPieceColor() != color)
                        {
                            attackedSquares.AddRange(board[x, y].CalculateAttackedPositions(board, new Point(x, y)));
                        }
                        if (board[x, y].GetPieceType() == PieceType.King && board[x, y].GetPieceColor() == color)
                        {
                            xCoord = x;
                            yCoord = y;
                        }
                    }
                }
            }

            if (listContains(attackedSquares, new Point(xCoord, yCoord)))
            {
                return true;
            }

            return false;
        }



        public bool listContains(List<Point> positions, Point dest)
        {
            foreach (Point pos in positions)
            {
                if (pos.X == dest.X && pos.Y == dest.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void GeneratePiecesWhiteDown()
        {
            board[0, 0] = new Rook(PieceColor.Black, PieceType.Rook, Properties.Resources.BlackRook);
            board[0, 1] = new Knight(PieceColor.Black, PieceType.Knight, Properties.Resources.BlackKnight);
            board[0, 2] = new Bishop(PieceColor.Black, PieceType.Bishop, Properties.Resources.BlackBishop);
            board[0, 3] = new Queen(PieceColor.Black, PieceType.Queen, Properties.Resources.BlackQueen);
            board[0, 4] = new King(PieceColor.Black, PieceType.King, Properties.Resources.BlackKing);
            board[0, 5] = new Commander(PieceColor.Black, PieceType.Commander, Properties.Resources.BlackCommander);
            board[0, 6] = new Queen(PieceColor.Black, PieceType.Queen, Properties.Resources.BlackQueen);
            board[0, 7] = new Bishop(PieceColor.Black, PieceType.Bishop, Properties.Resources.BlackBishop);
            board[0, 8] = new Knight(PieceColor.Black, PieceType.Knight, Properties.Resources.BlackKnight);
            board[0, 9] = new Rook(PieceColor.Black, PieceType.Rook, Properties.Resources.BlackRook);

            board[9, 0] = new Rook(PieceColor.White, PieceType.Rook, Properties.Resources.WhiteRook);
            board[9, 1] = new Knight(PieceColor.White, PieceType.Knight, Properties.Resources.WhiteKnight);
            board[9, 2] = new Bishop(PieceColor.White, PieceType.Bishop, Properties.Resources.WhiteBishop);
            board[9, 3] = new Queen(PieceColor.White, PieceType.Queen, Properties.Resources.WhiteQueen);
            board[9, 4] = new King(PieceColor.White, PieceType.King, Properties.Resources.WhiteKing);
            board[9, 5] = new Commander(PieceColor.White, PieceType.Commander, Properties.Resources.WhiteCommander);
            board[9, 6] = new Queen(PieceColor.White, PieceType.Queen, Properties.Resources.WhiteQueen);
            board[9, 7] = new Bishop(PieceColor.White, PieceType.Bishop, Properties.Resources.WhiteBishop);
            board[9, 8] = new Knight(PieceColor.White, PieceType.Knight, Properties.Resources.WhiteKnight);
            board[9, 9] = new Rook(PieceColor.White, PieceType.Rook, Properties.Resources.WhiteRook);

            for (int col = 0; col < 10; col++)
            {
                board[1, col] = new Pawn(PieceColor.Black, PieceType.Pawn, Properties.Resources.BlackPawn, -1);
                board[8, col] = new Pawn(PieceColor.White, PieceType.Pawn, Properties.Resources.WhitePawn, 1);
            }
        }
        public void GeneratePiecesBlackDown()
        {
            board[9, 0] = new Rook(PieceColor.Black, PieceType.Rook, Properties.Resources.BlackRook);
            board[9, 1] = new Knight(PieceColor.Black, PieceType.Knight, Properties.Resources.BlackKnight);
            board[9, 2] = new Bishop(PieceColor.Black, PieceType.Bishop, Properties.Resources.BlackBishop);
            board[9, 3] = new Queen(PieceColor.Black, PieceType.Queen, Properties.Resources.BlackQueen);
            board[9, 4] = new King(PieceColor.Black, PieceType.King, Properties.Resources.BlackKing);
            board[9, 5] = new Commander(PieceColor.Black, PieceType.Commander, Properties.Resources.BlackCommander);
            board[9, 6] = new Queen(PieceColor.Black, PieceType.Queen, Properties.Resources.BlackQueen);
            board[9, 7] = new Bishop(PieceColor.Black, PieceType.Bishop, Properties.Resources.BlackBishop);
            board[9, 8] = new Knight(PieceColor.Black, PieceType.Knight, Properties.Resources.BlackKnight);
            board[9, 9] = new Rook(PieceColor.Black, PieceType.Rook, Properties.Resources.BlackRook);

            board[0, 0] = new Rook(PieceColor.White, PieceType.Rook, Properties.Resources.WhiteRook);
            board[0, 1] = new Knight(PieceColor.White, PieceType.Knight, Properties.Resources.WhiteKnight);
            board[0, 2] = new Bishop(PieceColor.White, PieceType.Bishop, Properties.Resources.WhiteBishop);
            board[0, 3] = new Queen(PieceColor.White, PieceType.Queen, Properties.Resources.WhiteQueen);
            board[0, 4] = new King(PieceColor.White, PieceType.King, Properties.Resources.WhiteKing);
            board[0, 5] = new Commander(PieceColor.White, PieceType.Commander, Properties.Resources.WhiteCommander);
            board[0, 6] = new Queen(PieceColor.White, PieceType.Queen, Properties.Resources.WhiteQueen);
            board[0, 7] = new Bishop(PieceColor.White, PieceType.Bishop, Properties.Resources.WhiteBishop);
            board[0, 8] = new Knight(PieceColor.White, PieceType.Knight, Properties.Resources.WhiteKnight);
            board[0, 9] = new Rook(PieceColor.White, PieceType.Rook, Properties.Resources.WhiteRook);

            for (int col = 0; col < 10; col++)
            {
                board[1, col] = new Pawn(PieceColor.White, PieceType.Pawn, Properties.Resources.WhitePawn, -1);
                board[8, col] = new Pawn(PieceColor.Black, PieceType.Pawn, Properties.Resources.BlackPawn, 1);
            }
        }

    }
}
