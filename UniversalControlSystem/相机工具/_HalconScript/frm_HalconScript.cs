using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class frm_HalconScript : Form
    {

        private string fileName, saveFile;
        private string heard, body, footer;
        private string[] keywords = { "if", "else", "elseif", "endif", "return", "for", "endfor", "while", "endwhile" };//关键字
        static frm_HalconScript instance;
        HalconScriptTool halconScriptTool = new HalconScriptTool();
        public delegate void HandledSetVal(HalconScriptTool halconScriptTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_HalconScript SingleShow(HalconScriptTool halconScriptTool, HandledSetVal handleSetval)
        {
            if (instance == null)//
            {
                instance = new frm_HalconScript(halconScriptTool, handleSetval);
            }
            return instance;
        }
        public frm_HalconScript()
        {
            InitializeComponent();
        }
        public frm_HalconScript(HalconScriptTool halconScriptTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(halconScriptTool);
            this.halconScriptTool.Image = halconScriptTool.Image;
            this.halconScriptTool.Circle = halconScriptTool.Circle;
            this.halconScriptTool.Rectangle1 = halconScriptTool.Rectangle1;
            this.halconScriptTool.Rectangle2 = halconScriptTool.Rectangle2;
            this.halconScriptTool.MyEngine = halconScriptTool.MyEngine;
            this.halconScriptTool.Program = halconScriptTool.Program;
            this.halconScriptTool.Procedure = halconScriptTool.Procedure;
            this.halconScriptTool.ProcedureCall = halconScriptTool.ProcedureCall;
            this.SetVal(ref this.halconScriptTool);
        }
        void DisplayVal(HalconScriptTool halconScriptTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = halconScriptTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = halconScriptTool.Names.Substring(nameIndex + 1, halconScriptTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = halconScriptTool.Names;
                    tbxToolName.Text = halconScriptTool.Names;
                }


                cbxImage.Text = halconScriptTool.ImageName;//
                cbxRoi.Text = halconScriptTool.SetdrawShape;
                cbxSetdraw.Text = halconScriptTool.Setdraw;
                cebxIsSelectedRegions.Checked = halconScriptTool.IsSelectedRegions;
                cebxIsCross.Checked = halconScriptTool.IsCross;
                cebxIsRectangle.Checked = halconScriptTool.IsRectangle;


                int Debug = halconScriptTool.ProgramPathString.LastIndexOf("Debug");//是否是debug下的文件
                if (Debug != -1)
                {
                    string bugPath = halconScriptTool.ProgramPathString.Substring(Debug + 5, halconScriptTool.ProgramPathString.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
                    string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
                    lblFilePath.Text = halconScriptTool.ProgramPathString;
                }
                else
                    lblFilePath.Text = halconScriptTool.ProgramPathString;
                cbxProcedure.Text = halconScriptTool.ProcedureName;
                if (halconScriptTool.ProgramPathString != null)
                {
                    OpenFile(halconScriptTool.ProgramPathString);
                    this.halconScriptTool.ProgramPathString = halconScriptTool.ProgramPathString;
                    AddProcedure();
                }

                //nudLowAera.Value = Convert.ToDecimal(halconScriptTool.LowAera.I);
                //nudHigAera.Value = Convert.ToDecimal(halconScriptTool.HigAera.I);
                //nudLowNum.Value = Convert.ToDecimal(halconScriptTool.LowNums.I);
                //nudHigNum.Value = Convert.ToDecimal(halconScriptTool.HigNums.I);


                cbxImage.Items.Clear();
                if (halconScriptTool.Image != null)
                {
                    foreach (var item in halconScriptTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                 //   halconView1.DispImage((HObject)halconScriptTool.Image[cbxImage.Text], true);
                  //  halconView1.FitImage();
                }
                Register();//注册事件
            }
            catch
            {
                cbxImage.Items.Clear();
                if (halconScriptTool.Image != null)
                {
                    foreach (var item in halconScriptTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                Register();//注册事件}
            }
        }
        void SetVal(ref HalconScriptTool halconScriptTool)
        {
            halconScriptTool.Names = HalconScriptTool.Tool.视觉脚本.ToString() + "_" + tbxToolName.Text;
            halconScriptTool.ImageName = cbxImage.Text;

            halconScriptTool.ProcedureName = cbxProcedure.Text;
            halconScriptTool.ProgramPathString = lblFilePath.Text;

            halconScriptTool.SetdrawShape = cbxRoi.Text;
            halconScriptTool.Setdraw = cbxSetdraw.Text;
            halconScriptTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            halconScriptTool.IsCross = cebxIsCross.Checked;
            halconScriptTool.IsRectangle = cebxIsRectangle.Checked;

        }
        void Cancel()
        {
            cbxSetdraw.SelectedIndexChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsSelectedRegions.CheckedChanged -= new EventHandler(cebxIsSelectedRegions_CheckedChanged);
            cebxIsCross.CheckedChanged -= new EventHandler(cebxIsCross_CheckedChanged);
            cebxIsRectangle.CheckedChanged -= new EventHandler(cebxIsRectangle_CheckedChanged);
            cbxProcedure.SelectedIndexChanged -= new EventHandler(cbxProcedure_SelectedIndexChanged);

        }
        void Register()
        {

            cbxSetdraw.SelectedIndexChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsSelectedRegions.CheckedChanged += new EventHandler(cebxIsSelectedRegions_CheckedChanged);
            cebxIsCross.CheckedChanged += new EventHandler(cebxIsCross_CheckedChanged);
            cebxIsRectangle.CheckedChanged += new EventHandler(cebxIsRectangle_CheckedChanged);
            cbxProcedure.SelectedIndexChanged += new EventHandler(cbxProcedure_SelectedIndexChanged);

        }
        private void frm_Blob_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_Blob_FormClosing;
            string[] roi = new string[] { BlobTool.Roi.方向矩形.ToString(), BlobTool.Roi.矩形.ToString(), BlobTool.Roi.圆.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.halconScriptTool.hWindowControl1 = hWindowControl1;
            this.TopMost = false;
        }

        void frm_Blob_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
        private void tbx_toolName_TextChanged(object sender, EventArgs e)
        {
            this.halconScriptTool.Names = HalconScriptTool.Tool.视觉脚本.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;

        }
        private void cbx_image_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  halconView1.DispImage((HObject)this.halconScriptTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            halconScriptTool.ImageName = cbxImage.Text;
        }

        private void cbx_roi_SelectedIndexChanged(object sender, EventArgs e)
        {
            halconScriptTool.SetdrawShape = cbxRoi.Text;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = halconScriptTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
         //   halconView1.ToolLable2.Text = "FAIL";
            //halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.halconScriptTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
               // halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            //          DataGridView(dataGridView1, halconScriptTool.ResultArea, halconScriptTool.ResultRow, halconScriptTool.ResultCol);//结果输出
        }
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.halconScriptTool);
                this.Hide();
                instance = null;
                handleSetval(this.halconScriptTool);
            }
            catch
            {
                this.Hide();
                instance = null;
                handleSetval(this.halconScriptTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            instance = null;
        }
        private void btn_drawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                halconScriptTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                halconScriptTool.SetdrawShape = BlobTool.Roi.矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                halconScriptTool.SetdrawShape = BlobTool.Roi.圆.ToString();
           // halconView1.Focus();
           // halconView1.ContextMenuStripHide();
            halconScriptTool.draw_roi();
        }
        private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
        {
            halconScriptTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            halconScriptTool.set_after();
            //        DataGridView(dataGridView1, halconScriptTool.ResultArea, halconScriptTool.ResultRow, halconScriptTool.ResultCol);//结果输出
        }
        private void cebxIsCross_CheckedChanged(object sender, EventArgs e)
        {
            halconScriptTool.IsCross = cebxIsCross.Checked;
            halconScriptTool.set_after();
            //     DataGridView(dataGridView1, halconScriptTool.ResultArea, halconScriptTool.ResultRow, halconScriptTool.ResultCol);//结果输出
        }
        private void cebxIsRectangle_CheckedChanged(object sender, EventArgs e)
        {
            halconScriptTool.IsRectangle = cebxIsRectangle.Checked;
            halconScriptTool.set_after();
            //       DataGridView(dataGridView1, halconScriptTool.ResultArea, halconScriptTool.ResultRow, halconScriptTool.ResultCol);//结果输出
        }
        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            halconScriptTool.Setdraw = cbxSetdraw.Text;
            halconScriptTool.set_after();
            //      DataGridView(dataGridView1, halconScriptTool.ResultArea, halconScriptTool.ResultRow, halconScriptTool.ResultCol);//结果输出
        }
        //结果输出
        private void DataGridView(DataGridView dataGridView, HTuple result_area, HTuple result_row, HTuple result_col)
        {
            try
            {
                string str_Areas, str_Rows, str_Cols;
                dataGridView.Columns.Clear();//
                dataGridView.Columns.Add("", "ResultArea");//
                dataGridView.Columns.Add("", "ResultRow");//
                dataGridView.Columns.Add("", "ResultCol");//
                for (int i = 0; i < result_row.Length; i++)
                {
                    dataGridView.Rows.Add(1);//加载row
                    ;//row表头ID
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    ;//表格赋值
                    str_Areas = result_area.TupleSelect(i).TupleString("0.3f");//表格赋值col(0)
                    str_Rows = result_row.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(1)
                    str_Cols = result_col.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)

                    dataGridView.Rows[i].Cells[0].Value = str_Areas; ;//表格赋值col(2)
                    dataGridView.Rows[i].Cells[1].Value = str_Rows; ;//表格赋值col(0)
                    dataGridView.Rows[i].Cells[2].Value = str_Cols; ;//表格赋值col(1)
                }
            }
            catch { }
        }
        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "打开文件";
            openFileDialog1.Filter = "HDEV文件(执行脚本)|*.hdev|HDVP文件(扩展函数)|*.hdvp|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbxScript.Text = "";
                heard = "";
                body = "";
                footer = "";
                fileName = openFileDialog1.FileName;
                lblFilePath.Text = fileName;
                halconScriptTool.ProgramPathString = fileName;
                OpenFile(fileName);
                AddProcedure();

            }
        }
        private void OpenFile(string filePath)
        {
            try
            {
                string[] tmp;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        string txt = sr.ReadToEnd();
                        int sIndex = txt.IndexOf("<body>") + 6;
                        int eIndex = txt.IndexOf("</body>");
                        heard = txt.Substring(0, sIndex);
                        body = txt.Substring(sIndex, eIndex - sIndex);
                        footer = txt.Substring(eIndex, txt.Length - eIndex);
                        tmp = body.Split('\n');
                    }
                }
                int j = 0;
                rtbxScript.Text = "";
                foreach (string str in tmp)
                {
                    string strReplace = str;
                    if (str.IndexOf("&lt;") > 0)
                        strReplace = Regex.Replace(str, "&lt;", "<");
                    if (str.IndexOf("&gt;") > 0)
                        strReplace = Regex.Replace(str, "&gt;", ">");

                    if (!string.IsNullOrEmpty(strReplace))
                    {
                        bool flg = false;
                        if (keywords != null && keywords.Length > 0)
                        {   //关键字颜色
                            foreach (string key in keywords)
                            {
                                int i = strReplace.IndexOf(key);
                                if (i >= 0)
                                {
                                    if (strReplace.Length > i + key.Length)
                                    {
                                        string sTmp = strReplace.Substring(i + key.Length, 1);
                                        if (sTmp.Equals("(") || sTmp.Equals(" ") || sTmp.Equals("{") || sTmp.Equals("<"))
                                        {
                                            flg = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (flg)
                            {
                                RichTextBoxEx.AppendTextColor(rtbxScript, $"{strReplace}", Color.FromArgb(158, 92, 96));
                            }
                            else if (strReplace.IndexOf(":=") > 0 || strReplace.IndexOf("dev") > 0)
                            {
                                RichTextBoxEx.AppendTextColor(rtbxScript, $"{strReplace}", Color.FromArgb(158, 60, 30));
                            }

                            else if (strReplace.Contains("<c>") && strReplace.Contains("</c>")) //注释颜色
                            {
                                RichTextBoxEx.AppendTextColor(rtbxScript, $"{strReplace}", Color.FromArgb(64, 165, 64));
                            }
                            else
                            {
                                //  RichTextBoxExt.AppendTextColor(rtbxScript, $"{strReplace}", Color.FromArgb(64, 64, 153));
                                RichTextBoxEx.AppendTextColor(rtbxScript, $"{strReplace}", Color.Blue);
                            }
                        }
                        else
                        {
                            //没有关键字时
                            if (strReplace.Contains("<c>") && strReplace.Contains("</c>")) //注释颜色
                            {
                                RichTextBoxEx.AppendTextColor(rtbxScript, $"{strReplace}", Color.FromArgb(64, 165, 64));
                            }
                            else
                            {
                                //默认颜色
                                //RichTextBoxExt.AppendTextColor(rtbxScript, $"{strReplace}", Color.FromArgb(64, 64, 153));
                                RichTextBoxEx.AppendTextColor(rtbxScript, $"{strReplace}", Color.Blue);

                            }
                        }
                        j++;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("错误:{ex.Message}", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void 另存为SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "";
            if ("main(:::)" == cbxProcedure.Text)
                sfd.Filter = "HDEV文件(执行脚本)|*.hdev|所有文件|*.*";
            else
                sfd.Filter = "HDVP文件(扩展函数)|*.hdvp|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveFile = sfd.FileName;//返回文件的完整路径 
                SaveFile(saveFile);
            }
        }
        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ("main(:::)" == cbxProcedure.Text)
                return;
            else
                 if (procedurePath != "")
            {
                SaveFile(procedurePath);
                AddProcedure();
            }
        }
        private void SaveFile(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(heard + "\n");
                        string[] tmp = rtbxScript.Text.Split('\n');
                        foreach (string str in tmp)
                        {
                            string strReplace = str;
                            if (str.IndexOf("<") > 0)
                                strReplace = Regex.Replace(str, "<", "&lt;");
                            if (str.IndexOf(">") > 0)
                                strReplace = Regex.Replace(str, ">", "&gt;");

                            if (string.IsNullOrEmpty(strReplace))
                            {
                                sw.Write("<c>" + strReplace + "</c>\n");
                            }
                            else
                            {
                                if (strReplace.Contains("*"))
                                {
                                    sw.Write("<c>" + strReplace + "</c>\n");
                                }
                                else
                                {
                                    sw.Write("<l>" + strReplace + "</l>\n");
                                }
                            }
                        }
                        sw.Write(footer);
                    }
                }

                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:{ex.Message}", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rtbxScript_TextChanged(object sender, EventArgs e)
        {

        }
        private void rtbxScript_Click(object sender, EventArgs e)
        {
            //int currentPos = rtbxScript.SelectionStart;
            //int row = rtbxScript.GetLineFromCharIndex(currentPos);
            //string[] tmp = rtbxScript.Text.Split('\n');
            //if (tmp.Length > 0 && row < tmp.Length)
            //{
            //    if (string.IsNullOrEmpty(tmp[row]))
            //    {
            //        return;
            //    }
            //    int sIndex = rtbxScript.Text.IndexOf(tmp[row]);
            //    int len = tmp[row].Length;
            //    rtbxScript.Select(sIndex, len);
            //}
        }

        string procedurePath = "";

        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbxScript.Copy();
        }

        private void 粘贴PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbxScript.Paste();
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbxScript.Undo();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbxScript.Cut();
        }
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbxScript.SelectAll();
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            halconScriptTool.dispresult();
        }

        private void cbxProcedure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("main(:::)" == cbxProcedure.Text)
            { OpenFile(halconScriptTool.ProgramPathString); }
            else
            {
                halconScriptTool.ProcedureName = cbxProcedure.Text;
                int index = cbxProcedure.Text.IndexOf("(");
                string s = cbxProcedure.Text.Substring(0, index);
                procedurePath = halconScriptTool.ProcedurePath + @"\" + s + ".hdvp";
                OpenFile(procedurePath);
            }
            //
        }


        private int GetGBKValue(string str)
        {
            byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(str);
            string code = "";
            foreach (byte b in gbk)
            {
                code += string.Format("{0:X2}", b);
            }
            int gbkValue = int.Parse(code, System.Globalization.NumberStyles.HexNumber);
            return gbkValue;

        }
        public void AddProcedure()
        {
            List<string> listProcedure = new List<string>();
            cbxProcedure.Items.Clear();
            cbxProcedure.Items.Add("main(:::)");
            //HTuple listProcedure = new HTuple();
            //listProcedure = halconScriptTool.GetUsedProcedureNames();
            listProcedure = halconScriptTool.GetLocalProcedureNames();
            if (listProcedure == null)
                return;
            for (int i = 0; i < listProcedure.Count; i++)
            {
                cbxProcedure.Items.Add(listProcedure[i]);
            }
        }
    }

    public static class RichTextBoxEx
    {
        public static void AppendTextColor(this RichTextBox rtBox, string text, Color color, bool addNewLine = true)
        {
            if (addNewLine)
            {
                text += Environment.NewLine;
            }
            rtBox.Font = new Font("宋体", 10, FontStyle.Regular);
            rtBox.SelectionStart = rtBox.TextLength;
            rtBox.SelectionLength = 0;
            rtBox.SelectionColor = color;
            rtBox.AppendText(text.Replace("<l>", "").Replace("</l>", "").Replace("<c>", "").Replace("</c>", ""));
            rtBox.SelectionColor = rtBox.ForeColor;
        }
    }
}
