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
    public partial class frm_2DSymbol : Form
    {
        public frm_2DSymbol()
        {
            InitializeComponent();
        }
        static frm_2DSymbol frm;
        _2DSymbolTool _2dSymbolTool = new _2DSymbolTool();
        public delegate void HandledSetVal(_2DSymbolTool _2dSymbolTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fd"></param>
        public static frm_2DSymbol SingleShow(_2DSymbolTool _2dSymbolTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_2DSymbol(_2dSymbolTool, handleSetval);
            }
            return frm;
        }
        public frm_2DSymbol(_2DSymbolTool _2dSymbolTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(_2dSymbolTool);
            this._2dSymbolTool.Image = _2dSymbolTool.Image;
            this._2dSymbolTool.Circle = _2dSymbolTool.Circle;
            this._2dSymbolTool.Rectangle1 = _2dSymbolTool.Rectangle1;
            this._2dSymbolTool.Rectangle2 = _2dSymbolTool.Rectangle2;
            this._2dSymbolTool.DicHomMat2D = _2dSymbolTool.DicHomMat2D;
            this._2dSymbolTool.DicPhi = _2dSymbolTool.DicPhi;
            this.SetVal(ref this._2dSymbolTool);
        }


        void DisplayVal(_2DSymbolTool _2dSymbolTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = _2dSymbolTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = _2dSymbolTool.Names.Substring(nameIndex + 1, _2dSymbolTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = _2dSymbolTool.Names;
                    tbxToolName.Text = _2dSymbolTool.Names;
                }
                cbxImage.Text = _2dSymbolTool.ImageName;//
                cbxFixture.Text = _2dSymbolTool.FixNames;
                cebxFixture.Checked = _2dSymbolTool.IsFixture;//定位 
                cbxGrayType.Text = _2dSymbolTool.GrayType;   //灰度形态处理类型 
                cbxType.Text = _2dSymbolTool.SymbolType;   //二维吗类型
                nudResultMaxNum.Value = Convert.ToDecimal(_2dSymbolTool.ResultMaxNum);
                nudTimerOut.Value = Convert.ToDecimal(_2dSymbolTool.TimerOut.I);
                cbxRoi.Text = _2dSymbolTool.SetdrawShape;


                nudMaskHeight.Value = Convert.ToDecimal(_2dSymbolTool.MaskHeight.I);
                nudMaskWidth.Value = Convert.ToDecimal(_2dSymbolTool.MaskWidth.I);
                cebxGrayOpenShape.Checked = _2dSymbolTool.IsGrayShape;
                cebxIsScale.Checked = _2dSymbolTool.IsScale;
                cebxAutoGrayShape.Checked = _2dSymbolTool.IsAutoGrayShape;
                cbxMaskShape.Text = _2dSymbolTool.MaskShape;

                nudLowNum.Value = Convert.ToDecimal(_2dSymbolTool.LowNums.I);
                nudHigNum.Value = Convert.ToDecimal(_2dSymbolTool.HigNums.I);
                cebxNums.Checked = _2dSymbolTool.IsNums;

                cbxImage.Items.Clear();
                if (_2dSymbolTool.Image != null)
                {
                    foreach (var item in _2dSymbolTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
             //   halconView1.DispImage((HObject)_2dSymbolTool.Image[cbxImage.Text], true);
           //     halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (_2dSymbolTool.DicHomMat2D != null)
                {
                    foreach (var item in _2dSymbolTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件
            }
            catch
            {
                cbxImage.Items.Clear();
                if (_2dSymbolTool.Image != null)
                {
                    foreach (var item in _2dSymbolTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (_2dSymbolTool.DicHomMat2D != null)
                {
                    foreach (var item in _2dSymbolTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件
            }

        }

        void Cancel()
        {
            nudResultMaxNum.ValueChanged -= new EventHandler(nudResultMaxNum_ValueChanged);
            nudTimerOut.ValueChanged -= new EventHandler(nudTimerOut_ValueChanged);
            cbxGrayType.SelectedIndexChanged -= new EventHandler(cbxGrayType_SelectedIndexChanged);
            cbxType.SelectedIndexChanged -= new EventHandler(cbxType_SelectedIndexChanged);
            nudLowNum.ValueChanged -= new EventHandler(nudLowNum_ValueChanged);
            nudHigNum.ValueChanged -= new EventHandler(nudHigNum_ValueChanged);
            cebxNums.CheckedChanged -= new EventHandler(cebxNums_CheckedChanged);
        }
        void Register()
        {
            nudResultMaxNum.ValueChanged += new EventHandler(nudResultMaxNum_ValueChanged);
            nudTimerOut.ValueChanged += new EventHandler(nudTimerOut_ValueChanged);
            cbxGrayType.SelectedIndexChanged += new EventHandler(cbxGrayType_SelectedIndexChanged);
            cbxType.SelectedIndexChanged += new EventHandler(cbxType_SelectedIndexChanged);
            nudLowNum.ValueChanged += new EventHandler(nudLowNum_ValueChanged);
            nudHigNum.ValueChanged += new EventHandler(nudHigNum_ValueChanged);
            cebxNums.CheckedChanged += new EventHandler(cebxNums_CheckedChanged);
        }
        void SetVal(ref _2DSymbolTool _2dSymbolTool)
        {
            try
            {
                _2dSymbolTool.Names = ImageTool.Tool.二维码识别.ToString() + "_" + tbxToolName.Text;
                _2dSymbolTool.ImageName = cbxImage.Text;
                _2dSymbolTool.FixNames = cbxFixture.Text;
                _2dSymbolTool.IsFixture = cebxFixture.Checked;
                _2dSymbolTool.GrayType = cbxGrayType.Text;   //灰度形态处理类型
                _2dSymbolTool.SymbolType = cbxType.Text;   //二维吗类型

                _2dSymbolTool.MaskHeight = (int)nudMaskHeight.Value;
                _2dSymbolTool.MaskWidth = (int)nudMaskWidth.Value;
                _2dSymbolTool.IsGrayShape = cebxGrayOpenShape.Checked;
                _2dSymbolTool.IsScale = cebxIsScale.Checked;
                _2dSymbolTool.IsAutoGrayShape = cebxAutoGrayShape.Checked;
                _2dSymbolTool.MaskShape = cbxMaskShape.Text;

                _2dSymbolTool.ResultMaxNum = (int)nudResultMaxNum.Value;
                _2dSymbolTool.TimerOut = (int)nudTimerOut.Value;
                _2dSymbolTool.SetdrawShape = cbxRoi.Text;
                _2dSymbolTool.LowNums = (int)nudLowNum.Value;
                _2dSymbolTool.HigNums = (int)nudHigNum.Value;
                _2dSymbolTool.IsNums = cebxNums.Checked;
            }
            catch
            {

            }

        }


        private void frm_2DSymbol_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_2DSymbol_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this._2dSymbolTool.hWindowControl1 = hWindowControl1;


        }

        void frm_2DSymbol_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this._2dSymbolTool.Names = ImageTool.Tool.二维码识别.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this._2dSymbolTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            this._2dSymbolTool.ImageName = cbxImage.Text;
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._2dSymbolTool.FixNames = cbxFixture.Text;
        }

        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.IsFixture = cebxFixture.Checked;
        }

        private void nudMaskWidth_ValueChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.MaskWidth = (int)nudMaskWidth.Value;

        }

        private void nudMaskHeight_ValueChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.MaskHeight = (int)nudMaskHeight.Value;


        }

        private void cebxGrayOpenShape_CheckedChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.IsGrayShape = cebxGrayOpenShape.Checked;

        }
        private void cebxIsScale_CheckedChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.IsScale = cebxIsScale.Checked;
        }

        private void cebxAutoGrayShape_CheckedChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.IsAutoGrayShape = cebxAutoGrayShape.Checked;
        }
        private void cbxMaskShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.MaskShape = cbxMaskShape.Text;   //二维吗类型

        }


        private void nudResultMaxNum_ValueChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.ResultMaxNum = (int)nudResultMaxNum.Value;

        }
        private void nudTimerOut_ValueChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.TimerOut = (int)nudTimerOut.Value;


        }
        private void cbxGrayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.GrayType = cbxGrayType.Text;   //灰度形态处理类型\
            _2dSymbolTool.set_after();
        }
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.SymbolType = cbxType.Text;   //二维吗类型
            _2dSymbolTool.set_after();
        }

        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._2dSymbolTool.SetdrawShape = cbxRoi.Text;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == _2DSymbolTool.Roi.方向矩形.ToString())
                this._2dSymbolTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == _2DSymbolTool.Roi.矩形.ToString())
                this._2dSymbolTool.SetdrawShape = _2DSymbolTool.Roi.矩形.ToString();
            if (cbxRoi.Text == _2DSymbolTool.Roi.圆.ToString())
                this._2dSymbolTool.SetdrawShape = _2DSymbolTool.Roi.圆.ToString();
          //  halconView1.ContextMenuStripHide();
           // halconView1.Focus();
            this._2dSymbolTool.draw_roi();
        }

        private void nudLowNum_ValueChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.LowNums = (int)nudLowNum.Value;

        }

        private void nudHigNum_ValueChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.HigNums = (int)nudHigNum.Value;

        }

        private void cebxNums_CheckedChanged(object sender, EventArgs e)
        {
            _2dSymbolTool.IsNums = cebxNums.Checked;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this._2dSymbolTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
          //  halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (_2dSymbolTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
                //halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
         //   halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, _2dSymbolTool.ResultDecodedData, _2dSymbolTool.ResultHandles);
        }
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this._2dSymbolTool);
                this.Hide();
                frm = null;
                handleSetval(this._2dSymbolTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this._2dSymbolTool);
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
            _2dSymbolTool.dispresult();

        }


    }
}
