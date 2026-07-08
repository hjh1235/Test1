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
    public partial class frm_Fixture : Form
    {
        static frm_Fixture frm;
        FixtureTool fixtureTool = new FixtureTool();
        public delegate void HandledSetVal(FixtureTool fixtureTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_Fixture SingleShow(FixtureTool fixtureTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_Fixture(fixtureTool, handleSetval);
            }
            return frm;
        }
        public frm_Fixture()
        {
            InitializeComponent();
        }
         public frm_Fixture(FixtureTool fixtureTool, HandledSetVal handleSetval)
        {
               InitializeComponent();
               this.handleSetval = handleSetval;
               DisplayVal(fixtureTool);
               this.fixtureTool.HtRow = fixtureTool.HtRow;
               this.fixtureTool.HtCol = fixtureTool.HtCol;
               this.fixtureTool.HtPhi = fixtureTool.HtPhi;
               SetVal(ref this.fixtureTool);
        }
         void DisplayVal(FixtureTool fixtureTool)
         {
             try
             {
                 int nameIndex = fixtureTool.Names.LastIndexOf("_");
                 if (nameIndex != -1)
                 {
                     string name = fixtureTool.Names.Substring(nameIndex + 1, fixtureTool.Names.Length - (nameIndex + 1));
                     this.Text = name;
                     tbxToolName.Text = name;
                 }
                 else
                 {
                     this.Text = fixtureTool.Names;
                     tbxToolName.Text = fixtureTool.Names;
                 }
                 lblOrgRow.Text = fixtureTool.OrgRow.D.ToString("0.000");
                 lblOrgCol.Text = fixtureTool.OrgCol.D.ToString("0.00");
                 lblOrgAngle.Text = fixtureTool.OrgPhi.D.ToString("0.00");

                 cbxModelName.Text = fixtureTool.ModelName;
                 cbxModelName.Items.Clear();
                 foreach (var item in fixtureTool.HtRow.Keys)
                 {
                     cbxModelName.Items.Add(item); //加载图像到下拉箱
                 }
             }
             catch { }
          }
        void SetVal(ref FixtureTool fixtureTool )
        {
            fixtureTool.Names = FixtureTool.Tool.位置定位.ToString() + "_" + tbxToolName.Text;
             fixtureTool.ModelName = cbxModelName.Text;

             fixtureTool.OrgRow = double.Parse(lblOrgRow.Text);
             fixtureTool.OrgCol = double.Parse(lblOrgCol.Text);
             fixtureTool.OrgPhi = double.Parse(lblOrgAngle.Text);

        }
        void Cancel()
        { }
         void Register()
        { }
        private void frm_Fixture_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.FormClosing += frm_Fixture_FormClosing;
        }
        void frm_Fixture_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.fixtureTool.Names = FixtureTool.Tool.位置定位.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void cbxPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblNowRow.Text = ((HTuple)fixtureTool.HtRow[cbxModelName.Text]).D.ToString("0.00");
                lblNowCol.Text = ((HTuple)fixtureTool.HtCol[cbxModelName.Text]).D.ToString("0.00");
                lblNowAngle.Text = ((HTuple)fixtureTool.HtPhi[cbxModelName.Text]).D.ToString("0.00");
            }
            catch { }
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = fixtureTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
            if (fixtureTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.fixtureTool);
                this.Hide();
                frm = null;
                handleSetval(this.fixtureTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.fixtureTool);
            }

        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void btnGetPosion_Click(object sender, EventArgs e)
        {
            lblOrgRow.Text = lblNowRow.Text;
            lblOrgCol.Text = lblNowCol.Text;
            lblOrgAngle.Text = lblNowAngle.Text;
            fixtureTool.OrgRow = double.Parse(lblOrgRow.Text);
            fixtureTool.OrgCol = double.Parse(lblNowCol.Text);
            fixtureTool.OrgPhi = double.Parse(lblOrgAngle.Text);
         }


    }
}
