using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerChess
{
    public partial class FormGameLAN : Form
    {
        GameLAN game;
        PictureBox[,] P;
        Piece[,] board;
        int cellSize;

        Color lightColor = Color.FromArgb(255, 255, 220, 220);
        Color darkColor = Color.FromArgb(255, 50, 40, 50);

        Color lightMoveColor = Color.FromArgb(255, 69, 191, 103);
        Color darkMoveColor = Color.FromArgb(255, 44, 122, 66);
        Color selectedColor = Color.FromArgb(255, 116, 78, 136);

        public FormGameLAN()
        {
            InitializeComponent();

            game = new GameLAN("player1", "player2");
            board = game.board;


            this.BackColor = Color.Gray;

        }

        private void FormGameLAN_Load(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            panel.BackColor = Color.Red;

            P = new PictureBox[10, 10];

            this.WindowState = FormWindowState.Maximized;

            int windowWidth = ClientRectangle.Width;
            int windowHeight = ClientRectangle.Height;

            cellSize = (int)(windowHeight - cellSize) / 10;

            int xFormLocation = (windowWidth - cellSize * 10) / 2;
            int yFormLocation = (windowHeight - cellSize * 10) / 2;

            panel.Location = new Point(xFormLocation, yFormLocation);

            panel.Size = new Size(cellSize * 10, cellSize * 10);

            this.Controls.Add(panel);

            int top = 0, left = 0;
            Color nextColor;

            for (int x = 0; x < 10; x++)
            {
                left = 0;

                for (int y = 0; y < 10; y++)
                {

                    if ((x + y) % 2 == 0)
                        nextColor = lightColor;
                    else
                        nextColor = darkColor;


                    P[x, y] = new PictureBox();
                    P[x, y].BackColor = nextColor;
                    P[x, y].Location = new Point(left, top);
                    P[x, y].Size = new Size(cellSize, cellSize);
                    P[x, y].SizeMode = PictureBoxSizeMode.StretchImage;
                    P[x, y].Click += PictureBox_Click;

                    if (board[x, y] != null)
                    {
                        P[x, y].Image = board[x, y].GetPieceImage();
                    }

                        panel.Controls.Add(P[x, y]);

                    left = left + cellSize;
                }
                top = top + cellSize;
            }
        }

        PictureBox clickedPictureBox1 = new PictureBox();
        PictureBox clickedPictureBox2 = new PictureBox();

        List<Point> legalMoves = new List<Point>();

        Point clickedPosition1;
        Point clickedPosition2;
        bool clicked = false;
        Color beforeClickColor;
        int moveResult;

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (!clicked )
            {
                clickedPictureBox1 = (PictureBox)sender;
                if (clickedPictureBox1.Image != null)
                {
                    clickedPosition1 = GetPointOfLastClickedPictureBox(clickedPictureBox1);
                    if (board[clickedPosition1.X, clickedPosition1.Y] != null && game.playerTurn.GetPlayerColor() == board[clickedPosition1.X, clickedPosition1.Y].GetPieceColor())
                    {
                        legalMoves = board[clickedPosition1.X, clickedPosition1.Y].CalculateLegalPositions(board, clickedPosition1);


                        foreach (Point p in legalMoves)
                        {
                            //if () {
                                if ((p.X + p.Y) % 2 == 0)
                                    P[p.X, p.Y].BackColor = lightMoveColor;
                                else
                                    P[p.X, p.Y].BackColor = darkMoveColor;
                            //}
                        }

                        beforeClickColor = clickedPictureBox1.BackColor;
                        clickedPictureBox1.BackColor = selectedColor;
                        clicked = true;
                    }
                }
            }
            else
            {
                clickedPictureBox2 = (PictureBox)sender;
                if (clickedPictureBox1 != clickedPictureBox2)
                {
                    clickedPosition2 = GetPointOfLastClickedPictureBox(clickedPictureBox2);



                    moveResult = game.MakeMove(new Move(clickedPosition1, clickedPosition2), ref P);
                    if (moveResult == 0)
                    {
                        label1.Text = "move was made";
                    }
                    else if (moveResult == 1)
                    {
                        label1.Text = "check";
                    }
                }


                UndoColoredSquares();
                clicked = false;
                clickedPictureBox1.BackColor = beforeClickColor;
            }
        }

        public void UndoColoredSquares() {
            foreach (Point p in legalMoves)
            {
                if ((p.X + p.Y) % 2 == 0)
                    P[p.X, p.Y].BackColor = lightColor;
                else
                    P[p.X, p.Y].BackColor = darkColor;
            }
        }

        public Point GetPointOfLastClickedPictureBox(PictureBox pictureBox)
        {
            Point position = new Point(0,0);
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (pictureBox == P[x, y])
                    {
                        position = new Point(x, y);
                    }
                }
            }
            return position;
        }
    }
}
