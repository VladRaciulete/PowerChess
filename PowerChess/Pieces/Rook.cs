using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PowerChess
{
    internal class Rook : Piece
    {

        public Rook(PieceColor color, PieceType type, Image image) : base(color, type, image) { }

        public override List<Point> CalculateLegalPositions(Piece[,] board, Point position)
        {
            List<Point> positions = new List<Point>();

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


            return positions;
        }
    }
}
