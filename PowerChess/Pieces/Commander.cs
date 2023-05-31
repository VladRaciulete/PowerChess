using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PowerChess
{
    internal class Commander : Piece
    {

        public Commander(PieceColor color, PieceType type, Image image) : base(color, type, image) { }


        public override List<Point> CalculateLegalPositions(Piece[,] board, Point position)
        {
            List<Point> positions = new List<Point>();

            //ROOK
            #region 
            //X
            for (int x = position.X + 1; x < 10; x++)
            {
                if (board[x, position.Y] != null)
                {
                    if (board[x, position.Y].GetPieceColor() != board[position.X, position.Y].GetPieceColor())
                    {
                        positions.Add(new Point(x, position.Y));
                    }
                    break;
                }

                positions.Add(new Point(x, position.Y));
            }

            for (int x = position.X - 1; x >= 0; x--)
            {
                if (board[x, position.Y] != null)
                {
                    if (board[x, position.Y].GetPieceColor() != board[position.X, position.Y].GetPieceColor())
                    {
                        positions.Add(new Point(x, position.Y));
                    }
                    break;
                }

                positions.Add(new Point(x, position.Y));
            }


            //Y
            for (int y = position.Y + 1; y < 10; y++)
            {
                if (board[position.X, y] != null)
                {
                    if (board[position.X, y].GetPieceColor() != board[position.X, position.Y].GetPieceColor())
                    {
                        positions.Add(new Point(position.X, y));
                    }
                    break;
                }
                positions.Add(new Point(position.X, y));
            }

            for (int y = position.Y - 1; y >= 0; y--)
            {
                if (board[position.X, y] != null)
                {
                    if (board[position.X, y].GetPieceColor() != board[position.X, position.Y].GetPieceColor())
                    {
                        positions.Add(new Point(position.X, y));
                    }
                    break;
                }
                positions.Add(new Point(position.X, y));
            }
            #endregion


            //BISHOP
            #region
            int dy = position.Y;

            for (int x = position.X + 1; x < 10; x++)
            {
                dy += 1;
                if (isValidPosition(x, dy))
                {
                    if (board[x, dy] != null)
                    {
                        if (board[x, dy].GetPieceColor() != board[position.X, position.Y].GetPieceColor())
                        {
                            positions.Add(new Point(x, dy));
                        }
                        break;
                    }
                    else
                    {
                        positions.Add(new Point(x, dy));
                    }
                }
            }

            dy = position.Y;
            for (int x = position.X - 1; x >= 0; x--)
            {
                dy -= 1;
                if (isValidPosition(x, dy))
                {
                    if (board[x, dy] != null)
                    {
                        if (board[x, dy].GetPieceColor() != board[position.X, position.Y].GetPieceColor())
                        {
                            positions.Add(new Point(x, dy));
                        }
                        break;
                    }
                    else
                    {
                        positions.Add(new Point(x, dy));
                    }
                }
            }

            dy = position.Y;
            for (int x = position.X - 1; x >= 0; x--)
            {
                dy += 1;
                if (isValidPosition(x, dy))
                {
                    if (board[x, dy] != null)
                    {
                        if (board[x, dy].GetPieceColor() != board[position.X, position.Y].GetPieceColor())
                        {
                            positions.Add(new Point(x, dy));
                        }
                        break;
                    }
                    else
                    {
                        positions.Add(new Point(x, dy));
                    }
                }
            }

            dy = position.Y;
            for (int x = position.X + 1; x < 10; x++)
            {
                dy -= 1;
                if (isValidPosition(x, dy))
                {
                    if (board[x, dy] != null)
                    {
                        if (board[x, dy].GetPieceColor() != board[position.X, position.Y].GetPieceColor())
                        {
                            positions.Add(new Point(x, dy));
                        }
                        break;
                    }
                    else
                    {
                        positions.Add(new Point(x, dy));
                    }
                }
            }
            #endregion


            //KNIGHT
            #region
            if (VerifyKnightPosition(board, position.X + 2, position.Y - 1))
            {
                positions.Add(new Point(position.X + 2, position.Y - 1));
            }
            if (VerifyKnightPosition(board, position.X + 2, position.Y + 1))
            {
                positions.Add(new Point(position.X + 2, position.Y + 1));
            }
            if (VerifyKnightPosition(board, position.X - 2, position.Y - 1))
            {
                positions.Add(new Point(position.X - 2, position.Y - 1));
            }
            if (VerifyKnightPosition(board, position.X - 2, position.Y + 1))
            {
                positions.Add(new Point(position.X - 2, position.Y + 1));
            }

            if (VerifyKnightPosition(board, position.X + 1, position.Y + 2))
            {
                positions.Add(new Point(position.X + 1, position.Y + 2));
            }
            if (VerifyKnightPosition(board, position.X - 1, position.Y + 2))
            {
                positions.Add(new Point(position.X - 1, position.Y + 2));
            }
            if (VerifyKnightPosition(board, position.X + 1, position.Y - 2))
            {
                positions.Add(new Point(position.X + 1, position.Y - 2));
            }
            if (VerifyKnightPosition(board, position.X - 1, position.Y - 2))
            {
                positions.Add(new Point(position.X - 1, position.Y - 2));
            }
            #endregion

            return positions;
        }
        public bool VerifyKnightPosition(Piece[,] board, int x, int y)
        {
            if (isValidPosition(x, y) && (board[x, y] == null || board[x, y].GetPieceColor() != GetPieceColor()))
            {
                return true;
            }
            return false;
        }
    }
}
