using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PowerChess
{
    internal class Bishop : Piece
    {

        public Bishop(PieceColor color, PieceType type, Image image) : base(color, type, image) { }

        public override List<Point> CalculateLegalPositions(Piece[,] board, Point position)
        {
            List <Point> positions = new List <Point>();

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
                    else {
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

            return positions;
        }
    }
}
