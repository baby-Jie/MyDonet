using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin.Common;

namespace WinformTest.Views
{
    public partial class GraphicsTestWInfom : Form
    {
        public GraphicsTestWInfom()
        {
            InitializeComponent();
            //_path.AddRectangle(new Rectangle(100, 100, 100, 100));
            System.Collections.Generic.List<Point> points = new List<Point>();
            points.Add(new Point(50, 50));
            points.Add(new Point(100, 50));
            //points.Add(new Point(100, 100));
            ////points.Add(new Point(50,100));
            //////points.Add(new Point(50, 50));

            ////_path.AddLines(points.ToArray());
            //_path.AddLine(50, 50, 100, 100);
            //_path.CloseFigure();
            //PointF[] points = GetPentagonPoints(new PointF(200, 200), 30);
            //_path.AddLine(new PointF(50, 50), new PointF(100, 100));
            //_path.CloseFigure();
            //_path.AddLine(new PointF(50, 100), new PointF(100, 50));
            //_path.CloseFigure();
            //_path.AddLines(new PointF[]{ points[0], points[2], points[4], points[1], points[3], points[0] });

            //pentagram(50, 200, 200);

            GraphicsPath path = new GraphicsPath();
            SetMarks(_path);
        }

        private void GraphicsTestWInfom_Paint(object sender, PaintEventArgs e)
        {
            //Test1(e);
            //NextSubpathExample2(e);
            //SetMarkersExample(e);
            DrawPath(e);

            //DrawStar(5, e);

            //DrawStar2(new PointF(100,100), e);
        }

        private void SetMarkersExample(PaintEventArgs e)
        {

            // Create a path and set two markers.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(new Point(0, 0), new Point(50, 50));
            myPath.SetMarkers();
            Rectangle rect = new Rectangle(50, 50, 50, 50);
            myPath.AddRectangle(rect);
            myPath.SetMarkers();
            myPath.AddEllipse(100, 100, 100, 50);



            // Draw the path to screen.
            e.Graphics.DrawPath(new Pen(Color.Black, 2), myPath);
        }

        private void Test1(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //using (Pen pen = new Pen(Color.Aqua))
            //{
            //    g.DrawLine(pen, new Point(10, 10), new Point(100, 100));
            //}

            GraphicsPath path = new GraphicsPath();
            path.AddLine(new Point(10, 100), new Point(100, 100));
            path.AddLine(new Point(50, 50), new Point(50, 150));
            path.CloseFigure();
            //path.CloseFigure();
            //path.AddLine(new Point(50, 100), new Point(10, 10));
            //path.AddArc(50,50,20,20, 10, 70);
            //path.SetMarkers();

            int pointCount = path.PointCount;
            Console.WriteLine("pointCount:{0}", pointCount);

            GraphicsPath myPath = new GraphicsPath();

            // Set up primitives to add to myPath.
            Point[] myPoints = {new Point(20, 20), new Point(120, 120),
                new Point(20, 120),new Point(20, 20) };
            Rectangle myRect = new Rectangle(120, 120, 100, 100);

            // Add 3 lines, a rectangle, an ellipse, and 2 markers.
            myPath.AddLines(myPoints);
            myPath.SetMarkers();
            myPath.AddRectangle(myRect);
            myPath.SetMarkers();
            myPath.AddEllipse(220, 220, 100, 100);

            using (Pen pen = new Pen(Color.Aqua))
            {
                g.DrawPath(pen, myPath);
            }


            //using (HatchBrush brush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Aqua, Color.Aqua))
            //{
            //    //g.FillPath(brush, myPath);
            //}
        }


        public void NextSubpathExample2(PaintEventArgs e)
        {

            // Create a graphics path.
            GraphicsPath myPath = new GraphicsPath();

            // Set up primitives to add to myPath.
            Point[] myPoints = {new Point(20, 20), new Point(120, 120),
        new Point(20, 120),new Point(20, 20) };
            Rectangle myRect = new Rectangle(120, 120, 100, 100);

            // Add 3 lines, a rectangle, an ellipse, and 2 markers.
            myPath.AddLines(myPoints);
            //myPath.SetMarkers();
            myPath.AddRectangle(myRect);
            myPath.SetMarkers();
            myPath.AddEllipse(220, 220, 100, 100);

            // Get the total number of points for the path,

            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;

            // Set up variables for listing all of the path's

            // points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);

            // List the values of all the path points and types to the screen.
            for (i = 0; i < myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString() +
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),
                    myFont,
                    myBrush,
                    20,
                    j);
                j += 20;
            }

            // Create a GraphicsPathIterator for myPath.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);

            // Rewind the iterator.
            myPathIterator.Rewind();

            // Create the GraphicsPath section.
            GraphicsPath myPathSection = new GraphicsPath();

            // Iterate to the 3rd subpath and list the number of points therein

            // to the screen.
            int subpathPoints;
            bool IsClosed2;

            // Iterate to the third subpath.
            subpathPoints = myPathIterator.NextSubpath(
                myPathSection, out IsClosed2);
            subpathPoints = myPathIterator.NextSubpath(
                myPathSection, out IsClosed2);
            subpathPoints = myPathIterator.NextSubpath(
                myPathSection, out IsClosed2);

            // Write the number of subpath points to the screen.
            e.Graphics.DrawString("Subpath: 3" +
                "   Num Points: " +
                subpathPoints.ToString(),
                myFont,
                myBrush,
                200,
                20);
        }

        private void MatrixTest()
        {
            //Graphics g = e.Graphics;
            //GraphicsContainer gc = g.BeginContainer();
            //g.EndContainer(gc);
            //Matrix myMatrix = new Matrix();
            //myMatrix.Translate(150.0f, 100.0f, MatrixOrder.Prepend);
            ////myMatrix.Rotate(70.0f, MatrixOrder.Append);
            //myMatrix.RotateAt(70, new PointF(95, 95), MatrixOrder.Prepend);
            //myMatrix.Scale(1.5f, 1.5f, MatrixOrder.Prepend);
            //Matrix myMatrix = new Matrix();
            //myMatrix.Rotate(30.0f);
            //myMatrix.Scale(1.0f, 2.0f, MatrixOrder.Prepend);
            //myMatrix.Translate(5.0f, 0.0f, MatrixOrder.Prepend);
            //for (int i = 0; i < 6; i++)
            //{
            //    Console.WriteLine("elements:{0}", myMatrix.Elements[i]);
            //}


            using (Bitmap bitmap = new Bitmap(768, 1024))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    using (Image image = Image.FromFile("1.png"))
                    {
                        //using (Matrix matrix = new Matrix(0.94997880462945f, 1.16083602233683f, -1.16083602233683f,
                        //    0.94997880462945f, 150.0f, 100.0f))
                        //using (Matrix matrix = new Matrix(0.5f, 0.866025403784439f, -0.866025403784439f, 0.5f, 0.0f, 0.0f))
                        using (Matrix matrix = new Matrix())
                        {

                            //matrix.Rotate(60, MatrixOrder.Append);
                            matrix.RotateAt(60, new PointF(45, 45), MatrixOrder.Append);
                            GetMatrixOffsetByRotate(60, 45, 45, out double offsetX, out double offsetY);
                            Console.WriteLine($"x:{offsetX}, y:{offsetY}");

                            ////matrix.Translate(100, 50, MatrixOrder.Append);
                            //matrix.Translate(-95, -95, MatrixOrder.Append);
                            //matrix.Scale(1.5f, 2.0f, MatrixOrder.Append);
                            //matrix.Translate(95, 95, MatrixOrder.Append);

                            //matrix.Translate(50, 100, MatrixOrder.Append);
                            //matrix.Scale(1.5f, 2.0f, MatrixOrder.Append);
                            //matrix.Scale(2.0f, 2.0f, MatrixOrder.Append);

                            PrintMatrixElements(matrix);

                            RectangleF rectangleF = new RectangleF(0, 0, 90, 90);

                            g.DrawImage(image, rectangleF);
                            g.MultiplyTransform(matrix, MatrixOrder.Append);
                            g.DrawImage(image, rectangleF);


                            bitmap.Save("test.png", ImageFormat.Png);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MatrixTest();
            //CalcBound();
        }

        private void PrintMatrixElements(Matrix matrix)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"{matrix.Elements[i]}\t");
            }

            Console.WriteLine();
        }

        private void GetMatrixOffsetByRotate(double angle, double x1, double y1, out double offsetX, out double offsetY)
        {
            offsetX = 2 * Math.Pow(Math.Sin(angle / 2), 2) * Math.Sqrt(x1 * x1 + y1 * y1);
            offsetY = Math.Sin(angle) * Math.Sqrt(x1 * x1 + y1 * y1);
        }

        private void DrawPath(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.Aqua, 4))
            {
                pen.DashStyle = DashStyle.Dash;
                pen.StartCap = LineCap.RoundAnchor;
                //pen.DashStyle = DashStyle.Custom;
                //pen.DashPattern = new float[] { 1.0f, 2.0f };
                //pen.DashCap = DashCap.Round;
                //pen.StartCap = LineCap.RoundAnchor;
                _path.Reset();
                _path.AddLine(new PointF(100, 100), new PointF(150, 150));
                g.DrawPath(pen, _path);
            }

            //using (Pen pen = new Pen(Color.Black, 4))
            //{
            //    pen.DashStyle = DashStyle.Dot;
            //    pen.DashOffset = 0;
            //    //pen.DashPattern = new float[] { 1, 2 };
            //    using (GraphicsPathIterator iter = new GraphicsPathIterator(_path))
            //    {
            //        using (GraphicsPath path1 = new GraphicsPath())
            //        {
            //            iter.NextSubpath(path1, out bool isClosed);
            //            g.DrawPath(pen, path1);
            //        }

            //        using (GraphicsPath path1 = new GraphicsPath())
            //        {
            //            //pen.DashStyle = DashStyle.DashDot;
            //            iter.NextSubpath(path1, out bool isClosed);
            //            g.DrawPath(pen, path1);
            //        }

            //        using (GraphicsPath path1 = new GraphicsPath())
            //        {
            //            iter.NextSubpath(path1, out bool isClosed);
            //            g.DrawPath(pen, path1);
            //        }
            //    }
            //}
        }

        private GraphicsPath _path = new GraphicsPath();

        protected void CalcBound()
        {

            using (GraphicsPath path = (GraphicsPath)_path.Clone())
            {
                using (Pen pen = new Pen(Color.Aqua, 20))
                {
                    path.Widen(pen);
                    RectangleF bounds = path.GetBounds();
                    MessageBox.Show(bounds.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Matrix matrix = new Matrix())
            {
                //matrix.Scale(2, 2);
                _path.Transform(matrix);
            }
            this.Invalidate();
        }

        private PointF[] GetPentagonPoints(PointF center, float radius)
        {
            PointF[] points = new PointF[5];
            double theta = -Math.PI / 2.0;
            double dtheta = 2.0 * Math.PI / 5.0;
            for (int i = 0; i < 5; i++)
            {
                points[i] = new PointF(
                    center.X + (float)(radius * Math.Cos(theta)),
                    center.Y + (float)(radius * Math.Sin(theta)));
                theta += dtheta;
            }
            return points;
        }

        private PointF[] GetPentagonPoints2(PointF center, float radius)
        {
            PointF[] points = new PointF[5];

            for (int i = 1; i < 5; i++)
            {
                // angle from vertical
                double angle = i * 4 * Math.PI / 5;
                points[i] = new PointF(center.X + radius * (float)Math.Sin(angle), center.Y + (-radius * (float)Math.Cos(angle)));
            }

            return points;
        }


        /// <summary>
        /// 获得五角星的各个点
        /// </summary>
        /// <param name="ptCenter">中心点坐标</param>
        /// <param name="length">距离中心点的长度</param>
        /// <param name="angle">和水平方向的夹角</param>
        /// <returns></returns>
        public PointF GetPoint(PointF ptCenter, double length, double angle)
        {
            return new PointF(
                (float)(ptCenter.X + length * Math.Cos(angle)),
                (float)(ptCenter.Y + length * Math.Sin(angle)));
        }

        /// <summary>
        /// 返回一个坐标的数组
        /// </summary>
        /// <param name="ptCenter">中心点</param>
        /// <param name="length">距离中心点的长度</param>
        /// <param name="angles">两点之间的夹角</param>
        /// <returns></returns>
        public PointF[] GetPoints(PointF ptCenter, double length, params double[] angles)
        {
            PointF[] points = new PointF[angles.Length];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = GetPoint(ptCenter, length, angles[i]);
            }
            return points;
        }

        /// <summary>
        /// 获得所有角度的数组
        /// </summary>
        /// <param name="startAngle">开始的角度</param>
        /// <param name="pointed">个数</param>
        /// <returns></returns>
        public double[] GetAngles(double startAngle, int pointed)
        {
            double[] angles = new double[pointed];
            angles[0] = startAngle;
            for (int i = 1; i < angles.Length; i++)
            {
                angles[i] = angles[i - 1] + GetAngleLength(pointed);
            }
            return angles;
        }
        /// <summary>
        /// 获得角度的增量
        /// </summary>
        /// <param name="pointed"></param>
        /// <returns></returns>
        public double GetAngleLength(int pointed)
        {
            return 2 * Math.PI / pointed;
        }

        /// <summary>
        /// 画五角星
        /// </summary>
        /// <param name="pointed">多少个角</param>
        /// <param name="e">Graphics参数</param>
        public void DrawStar(int pointed, PaintEventArgs e)
        {
            Graphics g = e.Graphics;//建立一个画布
            g.CompositingQuality = CompositingQuality.HighQuality;//设置图像呈现的质量
            g.SmoothingMode = SmoothingMode.HighQuality;//对图片进行平滑处理
            Pen p = new Pen(Color.Red);//画笔的颜色
            double[] angles1 = GetAngles(-Math.PI / 2, pointed);//五角星外围的点角度的一个数组
            double[] angles2 = GetAngles(-Math.PI / 2 + Math.PI / pointed, pointed);//五角星内围的点角度的一个数组
            PointF[] points1 = GetPoints(new PointF(300, 300), 100, angles1);//五角星外围的点的一个数组
            PointF[] points2 = GetPoints(new PointF(300, 300), 10, angles2);//五角星内围的点的一个数组
            PointF[] points = new PointF[points1.Length + points2.Length];//最终合成多边形所有点的数组
            for (int i = 0, j = 0; i < points.Length; i += 2, j++)
            {
                points[i] = points1[j];
                points[i + 1] = points2[j];
            }
            g.DrawPolygon(p, points);//画一个多边形
            g.FillPolygon(Brushes.Aqua, points);//填充颜色
        }


        private void DrawStar2(PointF center, PaintEventArgs e)
        {
            PointF[] points = GetStarPoints(40);
            points = TranformPoints(points, center);
            Graphics g = e.Graphics;//建立一个画布
            g.CompositingQuality = CompositingQuality.HighQuality;//设置图像呈现的质量
            g.SmoothingMode = SmoothingMode.HighQuality;//对图片进行平滑处理
            Pen p = new Pen(Color.Red);//画笔的颜色
            g.DrawPolygon(p, points);//画一个多边形
            g.FillPolygon(Brushes.Aqua, points);//填充颜色

        }
        private PointF[] GetStarPoints(float radius)
        {

            PointF[] innerPoints = new PointF[5];
            PointF[] outPoints = new PointF[5];

            PointF pointE = new PointF((float)(radius * Math.Cos(18)), (float)(-1 * radius * Math.Sin(18)));
            PointF pointB = new PointF(pointE.X * -1, pointE.Y);
            PointF pointA = new PointF(0, -radius);
            PointF pointC = new PointF((float)(-1 * radius * Math.Sin(36)), (float)(radius * Math.Cos(36)));
            PointF pointD = new PointF(-1 * pointC.X, pointC.Y);

            return new PointF[]
            {
                pointA,
                pointB,
                pointC,
                pointD,
                pointE,
            };
        }

        private PointF[] TranformPoints(PointF[] points, PointF center)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X += center.X;
                points[i].Y += center.Y;
            }

            return points;
        }

        /*
        int R:五角星的长轴
        int x, y:五角星的中心点
        int yDegree:长轴与y轴的夹角
        */
        void pentagram(int R, int x, int y, int yDegree = 0)
        {
            double rad = Math.PI / 180;                    //每度的弧度值
            double r = R * Math.Sin(18 * rad) / Math.Cos(36 * rad);    //五角星短轴的长度


            PointF[] RVertex = new PointF[5];
            PointF[] rVertex = new PointF[5];

            for (int k = 0; k < 5; k++)                      //求取坐标
            {
                RVertex[k] = new PointF(
                    (float)(x - (R * Math.Cos((90 + k * 72 + yDegree) * rad))), 
                    (float)(y - (R * Math.Sin((90 + k * 72 + yDegree) * rad))));

                rVertex[k] = new PointF(
                    (float)(x - (r * Math.Cos((90 + 36 + k * 72 + yDegree) * rad))), 
                    (float)(y - (r * Math.Sin((90 + 36 + k * 72 + yDegree) * rad))));
            }

            PointF[] points = new PointF[10];

            int count = 0;

            for (int i = 0; i < 5; i++)
            {
                points[count] = RVertex[i];
                count++;
                points[count] = rVertex[i];
                count++;
            }


            _path.AddPolygon(points);

            //for (int i = 0; i < 5; i++)
            //{
            //    Point[] polylinepoint = new Point[] { RVertex[i], rVertex[i], new Point(x, y), RVertex[i] };
            //    Point[] polylinepoint1 = { RVertex[(i + 1) % 5], rVertex[i], new Point(x, y), RVertex[(i + 1) % 5] };

            //    _path.AddPolygon(polylinepoint);
            //    _path.AddPolygon(polylinepoint1);
            //    //pDC->SelectObject(pNewBrush1);
            //    //pDC->Polygon(polylinepoint, 4);
            //    //pDC->SelectObject(pNewBrush);
            //    //pDC->Polygon(polylinepoint1, 4);

            //}

        }

        private void SetMarks(GraphicsPath path)
        {
            path.Reset();
            path.AddRectangle(new RectangleF(50, 50, 100, 100));
            path.CloseFigure();
            //path.AddRectangle(new RectangleF(50, 50, 50, 50));
            path.AddLine(new PointF(100, 50), new PointF(100, 150));
            path.CloseFigure();
            path.AddLine(new PointF(50, 100), new PointF(150, 100));
            //path.CloseFigure();
            bool isClosed;
            using (GraphicsPathIterator iter = new GraphicsPathIterator(path))
            {
                GraphicsPath path1 = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                GraphicsPath path3 = new GraphicsPath();
                iter.NextSubpath(path1, out isClosed);
                iter.NextSubpath(path2, out isClosed);
                iter.NextSubpath(path3, out isClosed);
            }
        }
    }
    }
