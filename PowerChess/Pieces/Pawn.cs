using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PowerChess
{
    internal class Pawn : Piece
    {
        bool hasMoved;
        int direction;

        public Pawn(PieceColor color, PieceType type, Image image, int direction) : base(color, type, image)
        {
            this.hasMoved = false;
            this.direction = direction;
        }

        public override List<Point> CalculateLegalPositions(Piece[,] board, Point position)
        {
            List<Point> positions = new List<Point>();

            if (this.direction == 1)
            {
                if (isValidPosition(position.X - 1, position.Y))
                {
                    if (board[position.X - 1, position.Y] == null)
                    {
                        positions.Add(new Point(position.X - 1, position.Y));
                    }
                }

                if (!this.hasMoved)
                {
                    if (isValidPosition(position.X - 2, position.Y))
                    {
                        if (board[position.X - 2, position.Y] == null)
                        {
                            positions.Add(new Point(position.X - 2, position.Y));
                        }
                    }

                    if (isValidPosition(position.X - 3, position.Y))
                    {
                        if (board[position.X - 3, position.Y] == null)
                        {
                            positions.Add(new Point(position.X - 3, position.Y));
                        }
                    }
                }

                if (isValidPosition(position.X - 1, position.Y + 1))
                {
                    if (board[position.X - 1, position.Y + 1] != null && board[position.X - 1, position.Y + 1].GetPieceColor() != this.GetPieceColor())
                    {
                        positions.Add(new Point(position.X - 1, position.Y + 1));
                    }
                }

                if (isValidPosition(position.X - 1, position.Y - 1))
                {
                    if (board[position.X - 1, position.Y - 1] != null && board[position.X - 1, position.Y - 1].GetPieceColor() != this.GetPieceColor())
                    {
                        positions.Add(new Point(position.X - 1, position.Y - 1));
                    }
                }
            }

            else
            {
                if (isValidPosition(position.X + 1, position.Y))
                {
                    if (board[position.X + 1, position.Y] == null)
                    {
                        positions.Add(new Point(position.X + 1, position.Y));
                    }
                }

                if (!this.hasMoved)
                {
                    if (isValidPosition(position.X + 2, position.Y))
                    {
                        if (board[position.X + 2, position.Y] == null)
                        {
                            positions.Add(new Point(position.X + 2, position.Y));
                        }
                    }

                    if (isValidPosition(position.X + 3, position.Y))
                    {
                        if (board[position.X + 3, position.Y] == null)
                        {
                            positions.Add(new Point(position.X + 3, position.Y));
                        }
                    }
                }


                if (isValidPosition(position.X + 1, position.Y + 1))
                {
                    if (board[position.X + 1, position.Y + 1] != null && board[position.X + 1, position.Y + 1].GetPieceColor() != this.GetPieceColor())
                    {
                        positions.Add(new Point(position.X + 1, position.Y + 1));
                    }
                }

                if (isValidPosition(position.X + 1, position.Y - 1))
                {
                    if (board[position.X + 1, position.Y - 1] != null && board[position.X + 1, position.Y - 1].GetPieceColor() != this.GetPieceColor())
                    {
                        positions.Add(new Point(position.X + 1, position.Y - 1));
                    }
                }
            }

            return positions;
        }

        public override List<Point> CalculateAttackedPositions(Piece[,] board, Point position)
        {
            List<Point> positions = new List<Point>();

            if (this.direction == 1)
            {

                if (isValidPosition(position.X - 1, position.Y + 1))
                {
                    positions.Add(new Point(position.X - 1, position.Y + 1));
                }

                if (isValidPosition(position.X - 1, position.Y - 1))
                {
                    positions.Add(new Point(position.X - 1, position.Y - 1));
                }
            }

            else
            {
                if (isValidPosition(position.X + 1, position.Y + 1))
                {
                    positions.Add(new Point(position.X + 1, position.Y + 1));
                }

                if (isValidPosition(position.X + 1, position.Y - 1))
                {
                    positions.Add(new Point(position.X + 1, position.Y - 1));
                }
            }

            return positions;
        }

        public override void PieceHasMoved()
        {
            this.hasMoved = true;
        }
    }
}
