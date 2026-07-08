using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace ComboBox_Draw
    {
        //自定义组合框项
      public class MyItem
        {
            private string Text;
            public Image Img;
            //构造函数
            public MyItem(string text, Image img)
            {
                Text = text;
                Img = img;
            }
            //重写ToString函数，返回项文本
            public override string ToString()
            {
                return Text;
            }
        }
    }

