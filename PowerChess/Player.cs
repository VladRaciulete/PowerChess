using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerChess
{
    internal class Player
    {
        string name;
        PieceColor color;
        List<Piece> capturedPieces;

        public Player(string name, PieceColor color)
        {
            this.name = name;
            this.color = color;
            this.capturedPieces = new List<Piece>();
        }

        public void AddCapturedPiece(Piece piece)
        {
            this.capturedPieces.Add(piece);
        }

        public string GetName()
        {
            return this.name;
        }

        public PieceColor GetPlayerColor()
        {
            return this.color;
        }

        public List<Piece> GetCapturedPieces()
        {
            return this.capturedPieces;
        }

    }
}
