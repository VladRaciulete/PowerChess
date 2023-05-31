using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerChess
{
    public enum PieceColor
    {
        None,
        White,
        Black
    }

    public enum PieceType
    {
        None,
        Pawn = 1,
        Bishop = 3,
        Knight = 3,
        Rook = 5,
        Queen = 9,
        Commander = 12,
        King = 100
    }

    internal abstract class Piece
    {
        PieceColor color;
        PieceType type;
        Image image;


        public Piece(PieceColor color, PieceType type, Image image)
        {
            this.color = color;
            this.type = type;
            this.image = image;
        }


        public abstract List<Point> CalculateLegalPositions(Piece[,] board, Point position);
        public virtual List<Point> CalculateAttackedPositions(Piece[,] board, Point position) { 
            return CalculateLegalPositions(board, position);
        }

        public bool isValidPosition(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
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

        public virtual void PieceHasMoved() { }

        public Image GetPieceImage()
        {
            return this.image;
        }

        public PieceColor GetPieceColor()
        {
            return this.color;
        }

        public PieceType GetPieceType()
        {
            return this.type;
        }

    }
}
