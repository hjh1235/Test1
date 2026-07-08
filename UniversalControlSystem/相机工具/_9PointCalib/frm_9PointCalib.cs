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
    public partial class frm_9PointCalib : Form
    {

        static frm_9PointCalib frm;
        _9PointCalibTool _9pointCalibTool = new _9PointCalibTool();
        public delegate void HandledSetVal(_9PointCalibTool _9pointCalibTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_9PointCalib SingleShow(_9PointCalibTool _9pointCalibTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_9PointCalib(_9pointCalibTool, handleSetval);
            }
            return frm;
        }
        public frm_9PointCalib()
        {
            InitializeComponent();
        }
        public frm_9PointCalib(_9PointCalibTool _9pointCalibTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(_9pointCalibTool);
            this._9pointCalibTool.HtRow = _9pointCalibTool.HtRow;
            this._9pointCalibTool.HtCol = _9pointCalibTool.HtCol;
            this._9pointCalibTool.Image = _9pointCalibTool.Image;
            this._9pointCalibTool.SetdrawShape = _9pointCalibTool.SetdrawShape;
            this._9pointCalibTool.Circle = _9pointCalibTool.Circle;
            this._9pointCalibTool.Rectangle1 = _9pointCalibTool.Rectangle1;
            this._9pointCalibTool.Rectangle2 = _9pointCalibTool.Rectangle2;
            this._9pointCalibTool.HomMat2D = _9pointCalibTool.HomMat2D;
            this._9pointCalibTool.PixelX = _9pointCalibTool.PixelX;
            this._9pointCalibTool.PixelY = _9pointCalibTool.PixelY;
            this._9pointCalibTool.AxisX = _9pointCalibTool.AxisX;
            this._9pointCalibTool.AxisY = _9pointCalibTool.AxisY;

            //this.fixtureTool.HtPhi = _9pointCalibTool.HtPhi;
            SetVal(ref this._9pointCalibTool);
        }

        void DisplayVal(_9PointCalibTool _9pointCalibTool)
        {
            try
            {
                int nameIndex = _9pointCalibTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = _9pointCalibTool.Names.Substring(nameIndex + 1, _9pointCalibTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = _9pointCalibTool.Names;
                    tbxToolName.Text = _9pointCalibTool.Names;
                }
                cbxImage.Text = _9pointCalibTool.ImageName;
                cbxModelName.Text = _9pointCalibTool.ModelName;
                cebxIsSelectedRegions.Checked = _9pointCalibTool.IsSelectedRegions;
                cebxIsRectangle.Checked = _9pointCalibTool.IsRectangle;
                cbxSetdraw.Text = _9pointCalibTool.Setdraw;
                lblCalib.Text = "未标定!";
                if (_9pointCalibTool.HomMat2D != null)
                {
                    lblCalib.Text = "标定成功!";
                    lblCalib.BackColor = Color.Green;
                }
                //listview数据刷新
                listView1.BeginUpdate();
                listView1.Items.Clear();
                for (int i = 0; i < _9pointCalibTool.PixelX.Length; i++)
                {
                    ListViewItem i_Item = listView1.Items.Add("第" + (listView1.Items.Count + 1) + "点");
                    i_Item.SubItems.Add(_9pointCalibTool.PixelX[i].D.ToString());
                    i_Item.SubItems.Add(_9pointCalibTool.PixelY[i].D.ToString());
                    i_Item.SubItems.Add(_9pointCalibTool.AxisX[i].D.ToString());
                    i_Item.SubItems.Add(_9pointCalibTool.AxisY[i].D.ToString());
                }
                listView1.EndUpdate();

                if (_9pointCalibTool.Image != null)
                {
                    foreach (var item in _9pointCalibTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                HW.Instance().DispImage((HObject)_9pointCalibTool.Image[cbxImage.Text], true);
                HW.Instance().FitImage();
                //
                foreach (var item in _9pointCalibTool.HtRow.Keys)
                {
                    cbxModelName.Items.Add(item); //加载图像到下拉箱
                }
            }
            catch
            {

                if (_9pointCalibTool.Image != null)
                {
                    foreach (var item in _9pointCalibTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                HW.Instance().DispImage((HObject)_9pointCalibTool.Image[cbxImage.Text], true);
                HW.Instance().FitImage();
                foreach (var item in _9pointCalibTool.HtRow.Keys)
                {
                    cbxModelName.Items.Add(item); //加载图像到下拉箱
                }

            }
        }
        void SetVal(ref _9PointCalibTool _9pointCalibTool)
        {
             _9pointCalibTool.Names = FixtureTool.Tool.九点标定.ToString() + "_" + tbxToolName.Text;
            _9pointCalibTool.ImageName = cbxImage.Text;
            _9pointCalibTool.ModelName = cbxModelName.Text;
            _9pointCalibTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            _9pointCalibTool.IsRectangle = cebxIsRectangle.Checked;
            _9pointCalibTool.Setdraw = cbxSetdraw.Text;
          
            int i = 0;
            foreach (ListViewItem i_Item in listView1.Items)
            {
                _9pointCalibTool.PixelX[i] = Convert.ToDouble(i_Item.SubItems[1].Text);
                _9pointCalibTool.PixelY[i] = Convert.ToDouble(i_Item.SubItems[2].Text);
                _9pointCalibTool.AxisX[i] = Convert.ToDouble(i_Item.SubItems[3].Text);
                _9pointCalibTool.AxisY[i] = Convert.ToDouble(i_Item.SubItems[4].Text);
                i++;
            }
           
        }
        void Cancel()
        { }
        void Register()
        { }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this._9pointCalibTool.Names = _9PointCalibTool.Tool.九点标定.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            HW.Instance().DispImage((HObject)this._9pointCalibTool.Image[cbxImage.Text], true);
            HW.Instance().FitImage();
            _9pointCalibTool.ImageName = cbxImage.Text;
        }
        private void tbxWorldX_TextChanged(object sender, EventArgs e)
        {

        }
        private void tbxWorldY_TextChanged(object sender, EventArgs e)
        {

        }
        private void btndrawRoi_Click(object sender, EventArgs e)
        {
            HW.Instance().ContextMenuStripHide();
            HW.Instance().Focus();
            _9pointCalibTool.draw_roi();
        }

        private void btnPLC_Click(object sender, EventArgs e)
        {

        }
        private void btnGetImageCoord_Click(object sender, EventArgs e)
        {
            try
            {
                //查找模板并获取图像坐标
                tbxImageY.Text = _9pointCalibTool.CenterRow.ToString();
                tbxImageX.Text = _9pointCalibTool.CenterCol.ToString();
            }
            catch (System.Exception ex)
            {

            }
        }
        //添加坐标
        private void btnAddImageCoord_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxImageX.Text == "" || tbxImageY.Text == "" || tbxWorldX.Text.Trim() == "" || tbxWorldY.Text.Trim() == "")
                {
                    MessageBox.Show("坐标不能为空！", "提示信息");
                    return;
                }

                ListViewItem i_Item = listView1.Items.Add("第" + (listView1.Items.Count + 1) + "点");
                i_Item.SubItems.Add(tbxImageX.Text);
                i_Item.SubItems.Add(tbxImageY.Text);
                i_Item.SubItems.Add(tbxWorldX.Text);
                i_Item.SubItems.Add(tbxWorldY.Text);
                i_Item.EnsureVisible();
            }
            catch (System.Exception ex)
            {

            }
        }
        //标定
        private void btnCalib_Click(object sender, EventArgs e)
        {
            try
            {
                //判断图像是否为空

                //MessageBox.Show("图像为空!");
                //return;

                //导出listview坐标数据
                int i = 0;
                foreach (ListViewItem i_Item in listView1.Items)
                {
                    _9pointCalibTool.PixelX[i] = Convert.ToDouble(i_Item.SubItems[1].Text);
                    _9pointCalibTool.PixelY[i] = Convert.ToDouble(i_Item.SubItems[2].Text);
                    _9pointCalibTool.AxisX[i] = Convert.ToDouble(i_Item.SubItems[3].Text);
                    _9pointCalibTool.AxisY[i] = Convert.ToDouble(i_Item.SubItems[4].Text);
                    i++;
                }
                //计算仿射变换矩阵
                _9pointCalibTool.gen_calib_data();
                if (_9pointCalibTool.HomMat2D != null)
                {
                    lblCalib.Text = "标定成功!";
                    lblCalib.BackColor = Color.Green;
                    MessageBox.Show("标定成功!");
                   
                }
            }
            catch
            {
                MessageBox.Show("标定异常");
                lblCalib.Text = "未标定!";
                lblCalib.BackColor = Color.Red;
            }
        }
        //删除选中
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)       //判断选择行
                {
                    listView1.SelectedItems[0].Remove();     //删除选定行

                    //坐标重新赋值
                    _9pointCalibTool.PixelX = 0;
                    _9pointCalibTool.PixelY = 0;
                    _9pointCalibTool.AxisX = 0;
                    _9pointCalibTool.AxisY = 0;
                    int i = 0;
                    foreach (ListViewItem i_Item in listView1.Items)
                    {
                        _9pointCalibTool.PixelX[i] = Convert.ToDouble(i_Item.SubItems[1].Text);
                        _9pointCalibTool.PixelY[i] = Convert.ToDouble(i_Item.SubItems[2].Text);
                        _9pointCalibTool.AxisX[i] = Convert.ToDouble(i_Item.SubItems[3].Text);
                        _9pointCalibTool.AxisY[i] = Convert.ToDouble(i_Item.SubItems[4].Text);
                        i++;
                    }
                    //listview数据刷新
                    listView1.BeginUpdate();
                    listView1.Items.Clear();
                    for (i = 0; i < _9pointCalibTool.PixelX.Length; i++)
                    {
                        ListViewItem i_Item = listView1.Items.Add("第" + (listView1.Items.Count + 1) + "点");
                        i_Item.SubItems.Add(_9pointCalibTool.PixelX[i].D.ToString());
                        i_Item.SubItems.Add(_9pointCalibTool.PixelY[i].D.ToString());
                        i_Item.SubItems.Add(_9pointCalibTool.AxisX[i].D.ToString());
                        i_Item.SubItems.Add(_9pointCalibTool.AxisY[i].D.ToString());
                    }
                    listView1.EndUpdate();
                }
            }
            catch (System.Exception ex)
            {

            }
        }
        //删除所有
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            _9pointCalibTool.PixelX = 0;
            _9pointCalibTool.PixelY = 0;
            _9pointCalibTool.AxisX = 0;
            _9pointCalibTool.AxisY = 0;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this._9pointCalibTool.set_after();

            HW.Instance().ToolLable2.Text = "FAIL";
            HW.Instance().ToolLable2.ForeColor = Color.Red;
            if (this._9pointCalibTool.ResultLogic)
            {
                HW.Instance().ToolLable2.Text = "PASS";
                HW.Instance().ToolLable2.ForeColor = Color.Lime;
            }
            HW.Instance().ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
         }
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this._9pointCalibTool);
                this.Hide();
                frm = null;
                handleSetval(this._9pointCalibTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this._9pointCalibTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void cbxModelName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void frm_9PointCalib_Load(object sender, EventArgs e)
        {
            this.FormClosing += Frm_9PointCalib_FormClosing;
            this.MinimizeBox = false;
            this.MaximizeBox = false;


            HW.Instance().TopLevel = false;
            panel1.Controls.Add(HW.Instance());
            HW.Instance().Size = panel1.Size;
            HW.Instance().Show();

            HOperatorSet.SetWindowParam(HW.Instance().HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            string[] roi = new string[] { CaliperTool.Roi.方向矩形.ToString() };
            this._9pointCalibTool.hWindowControl1 = HW.Instance().HWindowControl;
        }

        private void Frm_9PointCalib_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
        {
            _9pointCalibTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
        }

        private void cebxIsRectangle_CheckedChanged(object sender, EventArgs e)
        {
            _9pointCalibTool.IsRectangle = cebxIsRectangle.Checked;
        }

        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            _9pointCalibTool.Setdraw = cbxSetdraw.Text;
        }
    }
}
