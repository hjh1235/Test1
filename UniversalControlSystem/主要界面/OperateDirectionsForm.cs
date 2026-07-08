using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace UniversalControlSystem
{
    public partial class OperateDirectionsForm : Form
    {
        public OperateDirectionsForm()
        {
            InitializeComponent();
        }

        private void OperateDirectionsForm_Load(object sender, EventArgs e)
        {
            ReadPDF();
        }
        /// <summary>
        /// C#读取PDF文件 
        /// </summary>
        private void ReadPDF()
        {
            //实例化一个PdfDocument对象
            PdfDocument doc = new PdfDocument();

            //加载PDF文档
            doc.LoadFromFile("软件系统操作说明书.pdf");

            //实例化一个StringBuilder 对象
            StringBuilder content = new StringBuilder();

            //提取PDF所有页面的文本
            foreach (PdfPageBase page in doc.Pages)
            {
                content.Append(page.ExtractText());
                richTextBox1.Text += (page.ExtractText());
            }

            //将提取到的文本写为.txt格式并保存到本地路径
            //String fileName = "软件系统操作说明书.txt";
            //File.WriteAllText(fileName, content.ToString());

        }
        /// <summary>
        /// 读取PDF中的图片
        /// </summary>
        private void ReadPDFPic()
        {
            //创建一个PdfDocument类对象，加载PDF测试文档     
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("软件系统操作说明书.pdf");
            //声明List类对象            
            List<Image> ListImage = new List<Image>();
            //遍历PDF文档所有页面            
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                //获取文档所有页，并提取页面中的所有图片    
                PdfPageBase page = doc.Pages[i];
                Image[] images = page.ExtractImages();
                if (images != null && images.Length > 0)
                {
                    ListImage.AddRange(images);
                }
            }
        }
        private void CreatePDF()
        {
            //初始化一个PdfDocument类实例            
            PdfDocument document = new PdfDocument();
            //声明 PdfUnitConvertor和PdfMargins类对象      
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margins = new PdfMargins();
            //设置页边距            
            margins.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margins.Bottom = margins.Top;
            margins.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margins.Right = margins.Left;
            //新添加一个A4大小的页面         
            PdfPageBase page = document.Pages.Add(PdfPageSize.A4, margins);
            //自定义PdfTrueTypeFont、PdfPen实例，设置字体类型、字号和字体颜色  
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("楷体", 11f), true);
            PdfPen pen = new PdfPen(Color.Black);
            //调用DrawString()方法在指定位置写入文本         
            string text = ("《蝶恋花 送春》 \n 楼外垂杨千万缕，欲系青春，少住春还去。犹自风前飘柳絮，随春且看归何处？\n 绿满山川闻");
            page.Canvas.DrawString(text, font, pen, 15, 13);
            //加载图片，并调用DrawImage()方法在指定位置绘入图片   
            PdfImage image = PdfImage.FromFile("image1.jpg");
            float width = image.Width * 0.55f;
            float height = image.Height * 0.55f;
            float y = (page.Canvas.ClientSize.Width - width) / 3;
            page.Canvas.DrawImage(image, y, 60, width, height);
            //保存并打开文档            
            document.SaveToFile("PDF创建.pdf");
            System.Diagnostics.Process.Start("PDF创建.pdf");
        }
    }
}
