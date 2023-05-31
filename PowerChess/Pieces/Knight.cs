using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PowerChess
{
    internal class Knight : Piece
    {

        public Knight(PieceColor color, PieceType type, Image image) : base(color, type, image) { }


        public override List<Point> CalculateLegalPositions(Piece[,] board, Point position)
        {
            List<Point> positions = new List<Point>();

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
