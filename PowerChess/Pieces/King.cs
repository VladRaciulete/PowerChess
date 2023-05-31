using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PowerChess
{
    internal class King : Piece
    {

        public King(PieceColor color, PieceType type, Image image) : base(color, type, image) { }

        public override List<Point> CalculateLegalPositions(Piece[,] board, Point position)
        {
            List<Point> positions = new List<Point>();
            List<Point> underAttack = new List<Point>();
            PieceColor color = board[position.X, position.Y].GetPieceColor();

            //verify if this positions are under attack
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (board[x, y] != null)
                    {
                        if (board[x, y].GetPieceType() != PieceType.King && board[x, y].GetPieceColor() != color)
                        {
                            underAttack.AddRange(board[x, y].CalculateAttackedPositions(board,new Point(x,y)));
                        }
                    }

                }
            }


            //verificare daca sunt la un patrat distanta de celalalt rege



            if (VerifyPosition(board, position.X + 1, position.Y + 1) && !listContains(underAttack, new Point(position.X + 1, position.Y + 1)))
            {
                positions.Add(new Point(position.X + 1, position.Y + 1));
            }

            if (VerifyPosition(board, position.X, position.Y + 1) && !listContains(underAttack, new Point(position.X, position.Y + 1)))
            {
                positions.Add(new Point(position.X, position.Y + 1));
            }

            if (VerifyPosition(board, position.X - 1, position.Y + 1) && !listContains(underAttack, new Point(position.X - 1, position.Y + 1)))
            {
                positions.Add(new Point(position.X - 1, position.Y + 1));
            }

            if (VerifyPosition(board, position.X + 1, position.Y) && !listContains(underAttack, new Point(position.X + 1, position.Y)))
            {
                positions.Add(new Point(position.X + 1, position.Y));
            }

            if (VerifyPosition(board, position.X - 1, position.Y) && !listContains(underAttack, new Point(position.X - 1, position.Y)))
            {
                positions.Add(new Point(position.X - 1, position.Y));
            }

            if (VerifyPosition(board, position.X + 1, position.Y - 1) && !listContains(underAttack, new Point(position.X + 1, position.Y - 1)))
            {
                positions.Add(new Point(position.X + 1, position.Y - 1));
            }

            if (VerifyPosition(board, position.X, position.Y - 1) && !listContains(underAttack, new Point(position.X, position.Y - 1)))
            {
                positions.Add(new Point(position.X, position.Y - 1));
            }

            if (VerifyPosition(board, position.X - 1, position.Y - 1) && !listContains(underAttack, new Point(position.X - 1, position.Y - 1)))
            {
                positions.Add(new Point(position.X - 1, position.Y - 1));
            }

            return positions;
        }

        public bool VerifyPosition(Piece[,] board, int x, int y)
        {
            if (isValidPosition(x, y))
            {
                if (board[x, y] == null)
                {
                    return true;
                }

                if (board[x, y].GetPieceColor() != GetPieceColor() && board[x, y].GetPieceType() != PieceType.King)
                {
                    return true;
                }

            }
            return false;
        }


    }
}
