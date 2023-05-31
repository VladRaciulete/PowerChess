using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerChess
{
    internal class Move
    {
        Point source;
        Point destination;
        //MoveType ??????

        public Move(Point source, Point destination)
        {
            this.source = source;
            this.destination = destination;
        }

        public Point GetSource()
        {
            return this.source;
        }

        public Point GetDestination()
        {
            return this.destination;
        }

        public string MoveString()
        {
            return "S(" + source.X + "," + source.Y + ") - " + "D(" + destination.X + "," + destination.Y + ")";
        }
    }
}
