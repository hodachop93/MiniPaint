using System;
using System.Drawing;
using System.Windows.Forms;
using MyGraphics;

namespace MiniPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = pnl_Draw.CreateGraphics();
        }
        bool startPaint = false;
        Graphics g;
        //nullable int for storing Null value
        int? initX = null;
        int? initY = null;
       
        bool drawSquare = false;
        bool drawRectangle = false;
        bool drawCircle = false;
        bool drawEllipse = false;
        bool drawStar = false;
        bool drawCloud = false;
        bool drawFlag = false;
        bool drawSmile = false;
        bool drawCar = false;
        bool drawNoelTree = false;

        //Event fired when the mouse pointer is moved over the Panel(pnl_Draw).
        private void pnl_Draw_MouseMove(object sender, MouseEventArgs e)
        {
            
            if(startPaint)
            {
                //Setting the Pen BackColor and line Width
                Pen p = new Pen(btn_PenColor.BackColor,float.Parse(cmb_PenSize.Text));
                //Drawing the line.
                g.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                initX = e.X;
                initY = e.Y;
            }
             
        }
        //Event Fired when the mouse pointer is over Panel and a mouse button is pressed
        private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            String s = "";
            s = cmb_Shapes.Text;
            if (s == "Square")
                drawSquare = true;
            else if (s == "Rectangle")
                drawRectangle = true;
            else if (s == "Ellipse")
                drawEllipse = true;
            else if (s == "Circle")
                drawCircle = true;
            else if (s == "Star")
                drawStar = true;
            else if (s == "Cloud")
                drawCloud = true;
            else if (s == "FlagVietNam")
                drawFlag = true;
            else if (s == "SmileyFace")
                drawSmile = true;
            else if (s == "NoelTree")
                drawNoelTree = true;
            else if (s == "Car")
                drawCar = true;

            if (drawSquare)
            {
                SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                MyShape.MySquare(g, sb, e.X, e.Y, int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawSquare = false;
            }
            if(drawRectangle)
            {
                SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                MyShape.MyRectangle(g, sb, e.X, e.Y, 2 * int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawRectangle = false;
            }
            if (drawEllipse)
            {
                SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                MyShape.MyEllipse(g, sb, e.X, e.Y, int.Parse(txt_ShapeSize.Text), 2 * int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawEllipse = false;
            }
            if(drawCircle)
            {
                SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                MyShape.MyCircle(g, sb, e.X, e.Y, int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawCircle = false;
            }
            if (drawStar)
            {
                SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                MyShape.MyStar(g, sb, e.X, e.Y, int.Parse(txt_ShapeSize.Text));

                startPaint = false;
                drawStar = false;
            }
            if (drawCloud)
            {
                SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                MyShape.MyCloud(g, sb, e.X, e.Y, float.Parse(txt_ShapeSize.Text) / 50);
                startPaint = false;
                drawCloud = false;
            }
            if (drawFlag)
            {
                SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                MyShape.MyFlagVietNam(g, e.X, e.Y, 2 * int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawFlag = false;
            }
            if (drawSmile)
            {
                Pen p = new Pen(Brushes.Black);
                MyShape.MySmileyFace(g, p, e.X, e.Y, 2 * int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawSmile = false;
            }
            if (drawNoelTree)
            {
                MyShape.MyNoelTree(g, e.X, e.Y, float.Parse(txt_ShapeSize.Text) / 100);
                startPaint = false;
                drawNoelTree = false;
            }
            if (drawCar)
            {
                Pen p = new Pen(Brushes.Black);
                MyShape.MyCar(g, e.X, e.Y, float.Parse(txt_ShapeSize.Text) / 100);
                startPaint = false;
                drawCar = false;
            }
            
        }
        //Fired when the mouse pointer is over the pnl_Draw and a mouse button is released.
        private void pnl_Draw_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            initX = null;
            initY = null;
        }
        //Button for Setting pen Color
        private void button1_Click(object sender, EventArgs e)
        {
            //Open Color Dialog and Set BackColor of btn_PenColor if user click on OK
            ColorDialog c = new ColorDialog();
            if(c.ShowDialog()==DialogResult.OK)
            {
                btn_PenColor.BackColor = c.Color;
            }
        }
        //New 
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clearing the graphics from the Panel(pnl_Draw)
            g.Clear(pnl_Draw.BackColor);
            //Setting the BackColor of pnl_draw and btn_CanvasColor to White on Clicking New under File Menu
            pnl_Draw.BackColor = Color.White;
            btn_CanvasColor.BackColor = Color.White;
        }
       //Setting the Canvas Color
        private void btn_CanvasColor_Click_1(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if(c.ShowDialog()==DialogResult.OK)
            {
                pnl_Draw.BackColor = c.Color;
                btn_CanvasColor.BackColor = c.Color;
            }
        }

    
        //Exit under File Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to Exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //About under Help Menu
        private void aboutMiniPaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }




    }
}
