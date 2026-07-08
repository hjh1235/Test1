using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using netDxf;
using netDxf.Entities;
using netDxf.Tables;
using System.Reflection;
using System.Windows.Markup;
using System.Windows.Input;
namespace UniversalControlSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DxfDocument dxf;
        private void button1_Click(object sender, EventArgs e)
        {
          
            dxf = new DxfDocument();
            dxf.Load(@"C:\Users\HXP\Desktop\Drawing1.dxf");
            //Insert insert = dxf.Inserts.ElementAt(0);
            showFrom(dxf);
        }
        public void showFrom(DxfDocument dxf)
        {
            Graphics gra = this.pictureBox1.CreateGraphics();

            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Red);//画笔颜色         

 
            Graphics g = pictureBox1.CreateGraphics();
            if (dxf.Lines.Count!=0)
            {
                foreach (var item in dxf.Lines)
                {
                   int zc= pictureBox1.Height;

                    float StartX = 0;
                    float StartY = 0;
                    float EndX = 0;
                    float EndY = 0;
                    Vector3f vdf =   item.StartPoint;
                    StartX= vdf[0];
                    StartY = vdf[1];
                    Vector3f vdf1 = item.EndPoint;
                    EndX = vdf1[0];
                    EndY = vdf1[1];
                    //item.StartPoint;

                    //   gra.DrawLine(pen, (float)zc - ((float)zc- StartX), (float)zc-((float)zc - StartY), (float)zc - ((float)zc - EndX) , (float)zc - ((float)zc - EndY));
                    //gra.DrawLine(pen, 74, 114, 146, 114);
                    gra.DrawLine(pen, StartX,  StartY, EndX,  EndY);
                }
            }
            if (dxf.Circles.Count != 0)
            {
                foreach (var item in dxf.Circles)
                {
                    int zc = pictureBox1.Height;
                    float CenterX = 0;
                    float CenterY = 0;
                    Vector3f vdf = item.Center;
                    CenterX = vdf[0];
                    CenterY = vdf[1];
                    gra.DrawEllipse(pen, CenterX, CenterY, item.Radius, item.Radius);//画椭圆的方法，x坐标、y坐
                }
            }
            if (dxf.Polylines.Count != 0)
            {
                int zc = pictureBox1.Height;
                foreach (var p in dxf.Polylines)
                {
                    if (p.Flags == PolylineTypeFlags.OpenPolyline || p.Flags == PolylineTypeFlags.ClosedPolylineOrClosedPolygonMeshInM)
                    {
                        float CenterX = 0;
                        float CenterY = 0;
                        LightWeightPolyline polygon = (LightWeightPolyline)p;
                        foreach (var item in polygon.Vertexes)
                        {
                            Vector2f vdf = item.Location;

                            CenterX = vdf[0];
                            CenterY = vdf[1];

                            //gra.DrawRectangle(pen, item.Location, leftY, width, height);
                        }
                        Vector2f vdf1 = polygon.Vertexes[0].Location;
                        float CenterX1 = 0;
                        float CenterY1 = 0;
                        CenterX1 = vdf1[0];
                        CenterY1 = vdf1[1];
                        Vector2f vdf2 = polygon.Vertexes[1].Location;
                        float CenterX2 = 0;
                        float CenterY2 = 0;
                        CenterX2 = vdf2[0];
                        CenterY2 = vdf2[1];
                        Vector2f vdf3 = polygon.Vertexes[2].Location;
                        float CenterX3 = 0;
                        float CenterY3 = 0;
                        CenterX3 = vdf3[0];
                        CenterY3 = vdf3[1];
                        Vector2f vdf4 = polygon.Vertexes[3].Location;
                        float CenterX4 = 0;
                        float CenterY4 = 0;
                        CenterX4 = vdf4[0];
                        CenterY4 = vdf4[1];


                        float width = Math.Abs(CenterX1 - CenterX2);
                        float height = Math.Abs(CenterY1 - CenterY3);
                        gra.DrawRectangle(pen, CenterX, CenterY, width, height);
                    }

                }
            }
            if (dxf.Points.Count != 0)
            {

                foreach (var item in dxf.Points)
                {
                    Vector3f vdf = item.Location;
                    float CenterX = 0;
                    float CenterY = 0;
                    CenterX = vdf[0];
                    CenterY = vdf[1];
                }
            }
            //g.DrawLine(pen, startPoint, currentPoint);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics gra = this.pictureBox1.CreateGraphics();

            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Red);//画笔颜色                                
            gra.DrawLine(pen, 10, 10, 80, 20);
            //gra.DrawEllipse(pen, 250, 10, 100, 100);//画椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50
        }
  
        private void button3_Click(object sender, EventArgs e)
        {
            Layer layer = new Layer("netLayer");//新建图层
            layer.Color = AciColor.Yellow;//设置图层默认颜色
            Vector3f vdf =new Vector3f (20, 40,20);
            Vector3f vdf1 = new Vector3f(100, 200,100);
            Line line = new Line(vdf, vdf1);//绘制图像
            line.Layer = layer;//设置图像所在图层
            dxf.AddEntity(line);//向DxfDocument对象添加图像元素
            dxf.Save(@"C:\Users\HXP\Desktop\Drawing1.dxf", dxf.Version);//保存文件


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.MouseWheel += Form3_MouseWheel;

        }
        Size size;
        /// <summary>
        /// 鼠标的滚动轮向上下的滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form3_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)//鼠标的滚动轮向上的滚动
            {
                size.Width += (int)(((float)e.Delta / (float)size.Width) * size.Width);
                size.Height += (int)(((float)e.Delta / (float)size.Height) * size.Height);
                if (size.Width > pictureBox1.Parent.Size.Width || size.Height > pictureBox1.Parent.Size.Height)
                {
                    size = pictureBox1.Size;
                }
                pictureBox1.Size = size;
            }
            else //鼠标的滚动轮向下的滚动
            {
                size.Width -= (int)(((float)-e.Delta / (float)size.Width) * size.Width);
                size.Height -= (int)(((float)-e.Delta / (float)size.Height) * size.Height);
                if (size.Width <= 0 || size.Height <= 0)
                {
                    size = new Size(60, 60);
                }
                pictureBox1.Size = size;
            }
        }
        //实现锚点缩放(以鼠标所指位置为中心缩放)；
        //步骤：
        //①先改picturebox长宽，长宽改变量一样；
        //②获取缩放后picturebox中实际显示图像的长宽，这里长宽是不一样的；
        //③将picturebox的长宽设置为显示图像的长宽；
        //④补偿picturebox因缩放产生的位移，实现锚点缩放。
        //  注释：为啥要②③步？由于zoom模式的机制，把picturebox背景设为黑就知道为啥了。
        //这里需要获取zoom模式下picturebox所显示图像的大小信息，添加 using System.Reflection；
        //pictureBox1_MouseWheel事件没找到。。。手动添加，别忘在Form1.Designer.cs的“Windows 窗体设计器生成的代码”里加入：        
        //this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel)。
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
      
            int x = e.Location.X;
            int y = e.Location.Y;
            int ow = pictureBox1.Width;
            int oh = pictureBox1.Height;
            int VX, VY;     //因缩放产生的位移矢量
            if (e.Delta > 0)    //放大
            {
                //第①步
                //pictureBox1.Width += zoomStep;
                //pictureBox1.Height += zoomStep;
                //第②步
                PropertyInfo pInfo = pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                    BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox1, null);
                //第③步
                pictureBox1.Width = rect.Width;
                pictureBox1.Height = rect.Height;
            }
            if (e.Delta < 0)    //缩小
            {
                //防止一直缩成负值
                //if (pictureBox1.Width < myBmp.Width / 10)
                //    return;

                //pictureBox1.Width -= zoomStep;
                //pictureBox1.Height -= zoomStep;
                PropertyInfo pInfo = pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                    BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox1, null);
                pictureBox1.Width = rect.Width;
                pictureBox1.Height = rect.Height;
            }
            //第④步，求因缩放产生的位移，进行补偿，实现锚点缩放的效果
            VX = (int)((double)x * (ow - pictureBox1.Width) / ow);
            VY = (int)((double)y * (oh - pictureBox1.Height) / oh);
           // pictureBox1.Location = new Point(pictureBox1.Location.X + VX, pictureBox1.Location.Y + VY);
        }
    }
}
