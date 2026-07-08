using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class frm_Barcode : Form
    {
        public frm_Barcode()
        {
            InitializeComponent();
        }
        static frm_Barcode frm;
        BarcodeTool barcodeTool = new BarcodeTool();
        public delegate void HandledSetVal(BarcodeTool barcodeTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fd"></param>
        public static frm_Barcode SingleShow(BarcodeTool barcodeTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_Barcode(barcodeTool, handleSetval);
            }
            return frm;
        }
        public frm_Barcode(BarcodeTool barcodeTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(barcodeTool);
            this.barcodeTool.Image = barcodeTool.Image;
            this.barcodeTool.Circle = barcodeTool.Circle;
            this.barcodeTool.Rectangle1 = barcodeTool.Rectangle1;
            this.barcodeTool.Rectangle2 = barcodeTool.Rectangle2;
            this.barcodeTool.DicHomMat2D = barcodeTool.DicHomMat2D;
            this.barcodeTool.DicPhi = barcodeTool.DicPhi;
            this.SetVal(ref this.barcodeTool);
        }


        void DisplayVal(BarcodeTool barcodeTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = barcodeTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = barcodeTool.Names.Substring(nameIndex + 1, barcodeTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = barcodeTool.Names;
                    tbxToolName.Text = barcodeTool.Names;
                }
                cbxImage.Text = barcodeTool.ImageName;//
                cbxFixture.Text = barcodeTool.FixNames;
                cebxFixture.Checked = barcodeTool.IsFixture;//定位  
                cbxType.Text = barcodeTool.SymbolType;   //条形码类型
                nudTimerOut.Value = Convert.ToDecimal(barcodeTool.TimerOut.I);
                cbxRoi.Text = barcodeTool.SetdrawShape;

                nudLowNum.Value = Convert.ToDecimal(barcodeTool.LowNums.I);
                nudHigNum.Value = Convert.ToDecimal(barcodeTool.HigNums.I);
                cebxNums.Checked = barcodeTool.IsNums;

                cbxImage.Items.Clear();
                if (barcodeTool.Image != null)
                {
                    foreach (var item in barcodeTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                HW.Instance().DispImage((HObject)barcodeTool.Image[cbxImage.Text], true);
                HW.Instance().FitImage();
                cbxFixture.Items.Clear();
                if (barcodeTool.DicHomMat2D != null)
                {
                    foreach (var item in barcodeTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件
            }
            catch
            {
                cbxImage.Items.Clear();
                if (barcodeTool.Image != null)
                {
                    foreach (var item in barcodeTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (barcodeTool.DicHomMat2D != null)
                {
                    foreach (var item in barcodeTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件
            }
          
        }

        void Cancel()
        {
    
            nudTimerOut.ValueChanged -= new EventHandler(nudTimerOut_ValueChanged);
            cbxType.SelectedIndexChanged -= new EventHandler(cbxType_SelectedIndexChanged);
            nudLowNum.ValueChanged -= new EventHandler(nudLowNum_ValueChanged);
            nudHigNum.ValueChanged -= new EventHandler(nudHigNum_ValueChanged);
            cebxNums.CheckedChanged -= new EventHandler(cebxNums_CheckedChanged);
        }
        void Register()
        {
      
            nudTimerOut.ValueChanged += new EventHandler(nudTimerOut_ValueChanged);
            cbxType.SelectedIndexChanged += new EventHandler(cbxType_SelectedIndexChanged);
            nudLowNum.ValueChanged += new EventHandler(nudLowNum_ValueChanged);
            nudHigNum.ValueChanged += new EventHandler(nudHigNum_ValueChanged);
            cebxNums.CheckedChanged += new EventHandler(cebxNums_CheckedChanged);
        }
        void SetVal(ref BarcodeTool barcodeTool)
        {
            try
            {
                barcodeTool.Names = ImageTool.Tool.条形码识别.ToString() + "_" + tbxToolName.Text;
                barcodeTool.ImageName = cbxImage.Text;
                barcodeTool.FixNames = cbxFixture.Text;
                barcodeTool.IsFixture = cebxFixture.Checked;
                barcodeTool.SymbolType = cbxType.Text;   //条维吗类型
                barcodeTool.TimerOut = (int)nudTimerOut.Value;
                barcodeTool.SetdrawShape = cbxRoi.Text;
                barcodeTool.LowNums = (int)nudLowNum.Value;
                barcodeTool.HigNums = (int)nudHigNum.Value;
                barcodeTool.IsNums = cebxNums.Checked;
            }
            catch
            {

            }

        }

        private void frm_2DSymbol_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HW.Instance().TopLevel = false;
            panel1.Controls.Add(HW.Instance());
            HW.Instance().Size = panel1.Size;
            HW.Instance().Show();

            this.FormClosing += frm_2DSymbol_FormClosing;
            HOperatorSet.SetWindowParam(HW.Instance().HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.barcodeTool.hWindowControl1 = HW.Instance().HWindowControl;

        }

        void frm_2DSymbol_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.barcodeTool.Names = ImageTool.Tool.条形码识别.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            HW.Instance().DispImage((HObject)this.barcodeTool.Image[cbxImage.Text], true);
            HW.Instance().FitImage();
            this.barcodeTool.ImageName = cbxImage.Text;
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.barcodeTool.FixNames = cbxFixture.Text;
        }

        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            barcodeTool.IsFixture = cebxFixture.Checked;
        }
     
        private void nudTimerOut_ValueChanged(object sender, EventArgs e)
        {
            barcodeTool.TimerOut = (int)nudTimerOut.Value;
            this.barcodeTool.set_after();

        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            barcodeTool.SymbolType = cbxType.Text;   //二维吗类型
            this.barcodeTool.set_after();
        }

        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.barcodeTool.SetdrawShape = cbxRoi.Text;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == _2DSymbolTool.Roi.方向矩形.ToString())
                this.barcodeTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == _2DSymbolTool.Roi.矩形.ToString())
                this.barcodeTool.SetdrawShape = _2DSymbolTool.Roi.矩形.ToString();
            if (cbxRoi.Text == _2DSymbolTool.Roi.圆.ToString())
                this.barcodeTool.SetdrawShape = _2DSymbolTool.Roi.圆.ToString();
            this.barcodeTool.draw_roi();
        }

        private void nudLowNum_ValueChanged(object sender, EventArgs e)
        {
            barcodeTool.LowNums = (int)nudLowNum.Value;
       
        }

        private void nudHigNum_ValueChanged(object sender, EventArgs e)
        {
            barcodeTool.HigNums = (int)nudHigNum.Value;
      
        }

        private void cebxNums_CheckedChanged(object sender, EventArgs e)
        {
            barcodeTool.IsNums = cebxNums.Checked;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = this.barcodeTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
                HW.Instance().ToolLable2.Text = "FAIL";
                HW.Instance().ToolLable2.ForeColor = Color.Red;
            if (barcodeTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
                    HW.Instance().ToolLable2.Text = "PASS";
                    HW.Instance().ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
                HW.Instance().ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, barcodeTool.ResultDecodedData, barcodeTool.ResultHandles);
            }
            catch
            {
                MessageBox.Show("结果输出异常,查看设定参数！");
            }
        }
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.barcodeTool);
                this.Hide();
                frm = null;
                handleSetval(this.barcodeTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.barcodeTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
        //结果输出
        private void DataGridView(DataGridView dataGridView, HTuple decodedData, HTuple resultHandle)
        {
            try
            {
                string str_Chars, str_Confidence;
                dataGridView.Columns.Clear();//
                dataGridView.Columns.Add("", "信息");//
                dataGridView.Columns.Add("", "句柄");//
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                dataGridView1.Refresh();
                for (int i = 0; i < decodedData.Length; i++)
                {
                    dataGridView.Rows.Add(1);//加载row
                    ;//row表头ID
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    ;//表格赋值
                    str_Chars = decodedData.TupleSelect(i).TupleString("0");//表格赋值col(0)
                    str_Confidence = resultHandle.TupleSelect(i).TupleString("0"); ;//表格赋值col(1)
                    dataGridView.Rows[i].Cells[0].Value = str_Chars; ;//表格赋值col(2)
                    dataGridView.Rows[i].Cells[1].Value = str_Confidence; ;//表格赋值col(0)
                }
            }
            catch { }
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            barcodeTool.dispresult();
        }

        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
