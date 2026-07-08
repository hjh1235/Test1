using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace UniversalControlSystem
{

    public partial class FormIOItemSetting : Form
    {
        ////BindingSource inputSource;


        public static List<InputData> listItemCardIOInputData;

        public FormIOItemSetting()
        {
            InitializeComponent();
            //inputSource = new BindingSource();
            //formCardIOSetting = new FormIOSetting();
         

            listItemCardIOInputData = new List<InputData>();

            //if (IOManage.IODoc.m_InputDataList != null && IOManage.IODoc.m_InputDataList.Count > 0)
            //{
            //    dataGridViewInput.DataSource = IOManage.IODoc.m_InputDataList;
            //}
        }


        private void FormIOSetting_Load(object sender, EventArgs e)
        {
            try
            {
               // InitAllIOSettingForm();
                RadioButtonChecked();

                //IOOperate.IOdate();
                radioBtnCard_CheckedChanged(sender, e);
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void IOdate()
        //{
        //    throw new NotImplementedException();
        //}

        //void DrawInput()
        //{
        //    dataGridViewInput.Columns.Clear();
        //    DataGridViewTextBoxColumn ioNameColumn = new DataGridViewTextBoxColumn();
        //    ioNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    ioNameColumn.HeaderText = "输入点名称";
        //    ioNameColumn.DataPropertyName = "strIOName";

        //    DataGridViewComboBoxColumn cardNameColumn = new DataGridViewComboBoxColumn();
        //    foreach (KeyValuePair<string, IOHardwareBaseDoc> item in MainForm.pIOHardwareDoc.m_IOHardWareDictionary)
        //    {
        //        if (item.Value is IInputAction)
        //        {
        //            cardNameColumn.Items.Add(item.Key);
        //        }
        //    }
        //    cardNameColumn.HeaderText = "卡名称";
        //    cardNameColumn.DataPropertyName = "InputCardName";

        //    DataGridViewComboBoxColumn ioColumn = new DataGridViewComboBoxColumn();
        //    for (int i = 0; i < 64; i++)
        //    {
        //        ioColumn.Items.Add(i);
        //    }
        //    //ioColumn.Sorted = true;
        //    ioColumn.HeaderText = "点位";
        //    ioColumn.DataPropertyName = "iInputNo";

        //    DataGridViewCheckBoxColumn ignore = new DataGridViewCheckBoxColumn();
        //    ignore.DataPropertyName = "bignore";
        //    ignore.HeaderText = "屏蔽";

        //    DataGridViewTextBoxColumn remark = new DataGridViewTextBoxColumn();
        //    remark.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    remark.HeaderText = "备注";
        //    remark.DataPropertyName = "strRemark";

        //    dataGridViewInput.Columns.Add(ioNameColumn);
        //    dataGridViewInput.Columns.Add(cardNameColumn);
        //    dataGridViewInput.Columns.Add(ioColumn);
        //    dataGridViewInput.Columns.Add(ignore);
        //    dataGridViewInput.Columns.Add(remark);

        //    if (FormIOSetting.pIODoc.m_InputDataList != null && FormIOSetting.pIODoc.m_InputDataList.Count > 0)
        //    {
        //        dataGridViewInput.DataSource = FormIOSetting.pIODoc.m_InputDataList;
        //    }
        //}
        /*
        private void InitAllIOSettingForm()
        {
            formCardIOSetting.TopLevel = false;
            panel1.Controls.Add(formCardIOSetting);
            formCardIOSetting.Size = panel1.Size;
            formCardIOSetting.Show();

            formIOSetting1.TopLevel = false;
            panel1.Controls.Add(formIOSetting1);
            formIOSetting1.Size = panel1.Size;
            formIOSetting1.Show();

            formIOSetting2.TopLevel = false;
            panel1.Controls.Add(formIOSetting2);
            formIOSetting2.Size = panel1.Size;
            formIOSetting2.Show();

            formIOSetting3.TopLevel = false;
            panel1.Controls.Add(formIOSetting3);
            formIOSetting3.Size = panel1.Size;
            formIOSetting3.Show();

            formIOSetting4.TopLevel = false;
            panel1.Controls.Add(formIOSetting4);
            formIOSetting4.Size = panel1.Size;
            formIOSetting4.Show();

            formIOSetting5.TopLevel = false;
            panel1.Controls.Add(formIOSetting5);
            formIOSetting5.Size = panel1.Size;
            formIOSetting5.Show();

            formIOSetting6.TopLevel = false;
            panel1.Controls.Add(formIOSetting6);
            formIOSetting6.Size = panel1.Size;
            formIOSetting6.Show();

            formIOSetting7.TopLevel = false;
            panel1.Controls.Add(formIOSetting7);
            formIOSetting7.Size = panel1.Size;
            formIOSetting7.Show();

            formIOSetting8.TopLevel = false;
            panel1.Controls.Add(formIOSetting8);
            formIOSetting8.Size = panel1.Size;
            formIOSetting8.Show();
        }
        */
        private void RadioButtonChecked()
        {
            if (radioBtnCard.Checked)
            {
                //InputData inputData;
                //for (int i = 0; i < 15; i++)
                //{
                //    inputData = new InputData();
                //    inputData.strIOName = "备用" + i.ToString();
                //    inputData.InputCardName = MainForm.pHardwareDoc.sCardName + i;
                //    inputData.iInputNo = 0;
                //    FormIOSetting.pIODoc.m_InputDictionary.Add("备用" + i.ToString(), inputData);
                //    FormIOSetting.pIODoc.m_InputDataList.Add(inputData);
                //    listItemCardIOInputData.Add(inputData);
                //}
                //formCardIOSetting.Show();
                //formIOSetting1.Hide();
                //formIOSetting2.Hide();
                //formIOSetting3.Hide();
                //formIOSetting4.Hide();
                //formIOSetting5.Hide();
                //formIOSetting6.Hide();
                //formIOSetting7.Hide();
                //formIOSetting8.Hide();
            }
            else if (radioBtnModule1.Checked)
            {
                //formCardIOSetting.Hide();
                //formIOSetting1.Show();
                //formIOSetting2.Hide();
                //formIOSetting3.Hide();
                //formIOSetting4.Hide();
                //formIOSetting5.Hide();
                //formIOSetting6.Hide();
                //formIOSetting7.Hide();
                //formIOSetting8.Hide();
            }
            else if (radioBtnModule2.Checked)
            {
                //formCardIOSetting.Hide();
                //formIOSetting1.Hide();
                //formIOSetting2.Show();
                //formIOSetting3.Hide();
                //formIOSetting4.Hide();
                //formIOSetting5.Hide();
                //formIOSetting6.Hide();
                //formIOSetting7.Hide();
                //formIOSetting8.Hide();
            }
            else if (radioBtnModule3.Checked)
            {
                //formCardIOSetting.Hide();
                //formIOSetting1.Hide();
                //formIOSetting2.Hide();
                //formIOSetting3.Show();
                //formIOSetting4.Hide();
                //formIOSetting5.Hide();
                //formIOSetting6.Hide();
                //formIOSetting7.Hide();
                //formIOSetting8.Hide();
            }
            else if (radioBtnModule4.Checked)
            {
                //formCardIOSetting.Hide();
                //formIOSetting1.Hide();
                //formIOSetting2.Hide();
                //formIOSetting3.Hide();
                //formIOSetting4.Show();
                //formIOSetting5.Hide();
                //formIOSetting6.Hide();
                //formIOSetting7.Hide();
                //formIOSetting8.Hide();
            }
            else if (radioBtnModule5.Checked)
            {
                //formCardIOSetting.Hide();
                //formIOSetting1.Hide();
                //formIOSetting2.Hide();
                //formIOSetting3.Hide();
                //formIOSetting4.Hide();
                //formIOSetting5.Show();
                //formIOSetting6.Hide();
                //formIOSetting7.Hide();
                //formIOSetting8.Hide();
            }
            else if (radioBtnModule6.Checked)
            {
                //formCardIOSetting.Hide();
                //formIOSetting1.Hide();
                //formIOSetting2.Hide();
                //formIOSetting3.Hide();
                //formIOSetting4.Hide();
                //formIOSetting5.Hide();
                //formIOSetting6.Show();
                //formIOSetting7.Hide();
                //formIOSetting8.Hide();
            }
            else if (radioBtnModule7.Checked)
            {
                //formCardIOSetting.Hide();
                //formIOSetting1.Hide();
                //formIOSetting2.Hide();
                //formIOSetting3.Hide();
                //formIOSetting4.Hide();
                //formIOSetting5.Hide();
                //formIOSetting6.Hide();
                //formIOSetting7.Show();
                //formIOSetting8.Hide();
            }
            else if (radioBtnModule8.Checked)
            {
                //formCardIOSetting.Hide();
                //formIOSetting1.Hide();
                //formIOSetting2.Hide();
                //formIOSetting3.Hide();
                //formIOSetting4.Hide();
                //formIOSetting5.Hide();
                //formIOSetting6.Hide();
                //formIOSetting7.Hide();
                //formIOSetting8.Show();
            }
            else
            {

            }
        }
        bool ChangeOk = true;
        private void radioBtnCard_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCard.Checked == true)
            {
                ChangeOk = true;
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (Program.iODoc.m_InputDataList[i].InputCardName == Program.pHardwareDoc.sCardName)
                    {
                  
                         dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                        dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;                 
                        dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                        dataGridViewInput.Rows[count].Cells[2].Value = "-1";
                        dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                        count++;
                    }
                }
                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.pHardwareDoc.sCardName)
                    {

                        dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                        dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                        dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                        dataGridViewOutput.Rows[count].Cells[2].Value = "-1";
                        dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                        count++;
                    }
                }



                ChangeOk = false;
            }
        }

        private void radioBtnModule1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioBtnModule1.Checked == true)
            {
                ChangeOk = true;
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (0 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_InputDataList[i].InputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                            dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;
                         
                            dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewInput.Rows[count].Cells[2].Value = "0";
                            dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (0 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                            dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                            dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewOutput.Rows[count].Cells[2].Value = "0";
                            dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
                ChangeOk = false;
            }
        }

        private void radioBtnModule2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnModule2.Checked == true)
            {
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (1 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_InputDataList[i].InputCardName == Program.hardwareDoc.m_HardWareList[1].hardwareName)
                        {

                            dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                            dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;
                          
                            dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewInput.Rows[count].Cells[2].Value = "1";
                            dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (1 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                            dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                            dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewOutput.Rows[count].Cells[2].Value = "1";
                            dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }

            }
        }

        private void dataGridViewInput_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strName = dataGridViewInput.Rows[e.RowIndex].Cells[0].Value.ToString();
                //FormIOSetting.pIODoc.m_InputDataList[e.RowIndex].InputCardName = strName;
                // FormIOSetting.pIODoc.m_InputDictionary[strName].InputCardName = strName;
                //FormIOSetting.pIODoc.m_InputDataList1[e.RowIndex].InputCardName = strName;
            }
            catch { }
      



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioBtnCard.Checked)
            {
                //dataGridViewInput.Rows.Clear();
                //for (int j = 0; j < MainForm.pIOHardwareDoc.m_IOHardWareList.Count ;j++)
                //{

                //for (int i = 0; i < FormIOSetting.pIODoc.m_InputDataList.Count; i++)
                //{
                //    //for (int j=0;j< FormIOSetting.pIODoc.m_InputDataList)
                //    //{
                //    if (FormIOSetting.pIODoc.m_InputDataList[i].InputCardName == "0")
                //    {
                //        dataGridViewInput.Rows.Add(FormIOSetting.pIODoc.m_InputDataList[i]);
                //        dataGridViewInput.Rows[i].Cells[0].Value = FormIOSetting.pIODoc.m_InputDataList[i].strIOName;
                //        dataGridViewInput.Rows[i].Cells[1].Value = FormIOSetting.pIODoc.m_InputDataList[i].iInputNo;
                //    }
                //    //  }

                //}
                timer1.Enabled = false;
                return;
             }
            if (radioBtnModule1.Checked)
            {
                //dataGridViewInput.Rows.Clear();
                //for (int j = 0; j < MainForm.pIOHardwareDoc.m_IOHardWareList.Count ;j++)
                //{

                //for (int i = 16; i < FormIOSetting.pIODoc.m_InputDataList1.Count; i++)
                //{
                //    //for (int j=0;j< FormIOSetting.pIODoc.m_InputDataList)
                //    //{
                //    if (FormIOSetting.pIODoc.m_InputDataList1[i].InputCardName == "1")
                //    {
                //        dataGridViewInput.Rows.Add(FormIOSetting.pIODoc.m_InputDataList1[i]);
                //        dataGridViewInput.Rows[i].Cells[0].Value = FormIOSetting.pIODoc.m_InputDataList1[i].strIOName;
                //        dataGridViewInput.Rows[i].Cells[1].Value = FormIOSetting.pIODoc.m_InputDataList1[i].iInputNo;
                //    }
                //    //  }

                //}
                timer1.Enabled = false;
                return;
            }
        }

        private void radioBtnModule3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnModule3.Checked == true)
            {
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (2 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_InputDataList[i].InputCardName == Program.hardwareDoc.m_HardWareList[2].hardwareName)
                        {

                            dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                            dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;
                       
                            dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewInput.Rows[count].Cells[2].Value = "2";
                            dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }

                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (2 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                            dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                            dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewOutput.Rows[count].Cells[2].Value = "2";
                            dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
            }
        }

        private void radioBtnModule4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnModule4.Checked == true)
            {
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (3 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_InputDataList[i].InputCardName == Program.hardwareDoc.m_HardWareList[3].hardwareName)
                        {

                            dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                            dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;
                          
                            dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewInput.Rows[count].Cells[2].Value = "3";
                            dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }

                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (3 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                            dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                            dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewOutput.Rows[count].Cells[2].Value = "3";
                            dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
            }
        }

        private void radioBtnModule5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnModule5.Checked == true)
            {
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (4 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_InputDataList[i].InputCardName == Program.hardwareDoc.m_HardWareList[4].hardwareName)
                        {

                            dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                            dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;
                      
                            dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewInput.Rows[count].Cells[2].Value = "4";
                            dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }


                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (4 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                            dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                            dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewOutput.Rows[count].Cells[2].Value = "4";
                            dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
            }
        }

        private void radioBtnModule6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnModule6.Checked == true)
            {
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (5 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_InputDataList[i].InputCardName == Program.hardwareDoc.m_HardWareList[5].hardwareName)
                        {

                            dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                            dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;
                           // dataGridViewInput.Rows[count].Cells[1].Value = "0";
                            dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewInput.Rows[count].Cells[2].Value = "5";
                            dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }


                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (5 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                            dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                            dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewOutput.Rows[count].Cells[2].Value = "5";
                            dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
            }
        }

        private void radioBtnModule7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnModule7.Checked == true)
            {
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (6<Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_InputDataList[i].InputCardName == Program.hardwareDoc.m_HardWareList[6].hardwareName)
                        {

                            dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                            dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;
                           // dataGridViewInput.Rows[count].Cells[1].Value = "0";
                            dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewInput.Rows[count].Cells[2].Value = "6";
                            dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                   
                }


                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (6 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                            dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                            dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewOutput.Rows[count].Cells[2].Value = "6";
                            dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
            }
        }

        private void dataGridViewInput_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void dataGridViewInput_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (ChangeOk==false)
            {
                int CIndex = e.ColumnIndex;
                if (CIndex == 0 && e.RowIndex != -1)
                {
                    string strName = dataGridViewInput.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string iInputNo = dataGridViewInput.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string MUDLENum  = dataGridViewInput.Rows[e.RowIndex].Cells[2].Value.ToString();
                    if (MUDLENum == "-1")
                    {

                    }
                    else
                    {

                    }
                    //IOManage.OUTPUT(strName).SetOutBit(true);
                }
                else if (CIndex == 0 && e.RowIndex != -1)
                {
                    // string strName = dataGridViewInput.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //  IOManage.OUTPUT(strName).SetOutBit(false);
                }

            }
           
        }
        IoChangeName IoChangeN;
        private void ChangeName_Click(object sender, EventArgs e)
        {
            IoChangeN = new IoChangeName();
            IoChangeN.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewInput.Rows.Clear();
            dataGridViewOutput.Rows.Clear();
            Program.iODoc.m_InputDataList.Clear();
            Program.iODoc.m_InputDictionary.Clear();
            Program.iODoc.m_OutputDataList.Clear();
            Program.iODoc.m_OutputDictionary.Clear();
            IOManage.InputDrivers.drivers.Clear();
            IOManage.OutputDrivers.drivers.Clear();
            //  string d = Program.iODoc.m_InputDictionary["start"].InputCardName.ToString();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          //  string d = Program.iODoc.m_InputDictionary["start"].InputCardName.ToString();

            IOManage.OUTPUT("GoodLE备用0").SetOutBit(true);
        }

        private void radioBtnModule8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnModule8.Checked == true)
            {
                dataGridViewInput.Rows.Clear();
                int count = 0;
                for (int i = 0; i < Program.iODoc.m_InputDictionary.Count; i++)
                {
                    if (7 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_InputDataList[i].InputCardName == Program.hardwareDoc.m_HardWareList[7].hardwareName)
                        {

                            dataGridViewInput.Rows.Add(Program.iODoc.m_InputDataList[i].InputCardName);
                            dataGridViewInput.Rows[count].Cells[0].Value = Program.iODoc.m_InputDataList[i].strIOName;
                            // dataGridViewInput.Rows[count].Cells[1].Value = "0";
                            dataGridViewInput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewInput.Rows[count].Cells[2].Value = "7";
                            dataGridViewInput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }

                }


                dataGridViewOutput.Rows.Clear();
                count = 0;
                for (int i = 0; i < Program.iODoc.m_OutputDictionary.Count; i++)
                {
                    if (7 < Program.hardwareDoc.m_HardWareList.Count)
                    {
                        if (Program.iODoc.m_OutputDataList[i].OutputCardName == Program.hardwareDoc.m_HardWareList[0].hardwareName)
                        {

                            dataGridViewOutput.Rows.Add(Program.iODoc.m_OutputDataList[i].OutputCardName);
                            dataGridViewOutput.Rows[count].Cells[0].Value = Program.iODoc.m_OutputDataList[i].strIOName;
                            dataGridViewOutput.Rows[count].Cells[1].Value = Program.pHardwareDoc.iCardNo;
                            dataGridViewOutput.Rows[count].Cells[2].Value = "7";
                            dataGridViewOutput.Rows[count].Cells[3].Value = count.ToString();
                            count++;
                        }
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //private void buttonAdd_Click(object sender, EventArgs e)
        //{
        //    if (textBoxInputName.Text == "")
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        if (IOManage.IODoc.m_InputDictionary.ContainsKey(textBoxInputName.Text.Trim()))
        //        {
        //            MessageBox.Show("已存在同名输入点位！");
        //            return;
        //        }
        //        InputData data = new InputData();
        //        data.strIOName = textBoxInputName.Text;
        //        data.InputCardName = HardwareManage.hardwardDictionary.FirstOrDefault().Key.ToString();
        //        data.iInputNo = 0;
        //        IOManage.IODoc.m_InputDictionary.Add(textBoxInputName.Text, data);
        //        IOManage.IODoc.m_InputDataList.Add(data);
        //        InputDriver driver = new InputDriver();
        //        driver.Init(data);
        //        IOManage.InputDrivers.drivers.Add(data.strIOName, driver);
        //        DrawInput();

        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}

        //private void buttonRemove_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewInput.SelectedRows.Count == 1)
        //    {
        //        InputData data = dataGridViewInput.SelectedRows[0].DataBoundItem as InputData;

        //        IOManage.IODoc.m_InputDictionary.Remove(data.strIOName);
        //        IOManage.IODoc.m_InputDataList.Remove(data);
        //        DrawInput();
        //    }
        //}

        //private void dataGridViewInput_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{

        //}
        //private void dataGridViewInput_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


        //void DrawOutput()
        //{
        //    dataGridViewOutput.Columns.Clear();
        //    DataGridViewTextBoxColumn ioNameColumn = new DataGridViewTextBoxColumn();
        //    ioNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    ioNameColumn.HeaderText = "输出点名称";
        //    ioNameColumn.DataPropertyName = "strIOName";

        //    DataGridViewComboBoxColumn cardNameColumn = new DataGridViewComboBoxColumn();
        //    foreach (KeyValuePair<string, HardWareBase> item in HardwareManage.hardwardDictionary)
        //    {
        //        if (item.Value is IInputAction)
        //        {
        //            cardNameColumn.Items.Add(item.Key);
        //        }
        //    }
        //    cardNameColumn.HeaderText = "卡名称";
        //    cardNameColumn.DataPropertyName = "OutputCardName";

        //    DataGridViewComboBoxColumn ioColumn = new DataGridViewComboBoxColumn();
        //    for (int i = 0; i < 64; i++)
        //    {
        //        ioColumn.Items.Add(i);
        //    }
        //    ioColumn.HeaderText = "点位";
        //    ioColumn.DataPropertyName = "iOutputNo";

        //    DataGridViewCheckBoxColumn ignore = new DataGridViewCheckBoxColumn();
        //    ignore.DataPropertyName = "bignore";
        //    ignore.HeaderText = "屏蔽";

        //    DataGridViewTextBoxColumn remark = new DataGridViewTextBoxColumn();
        //    remark.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    remark.HeaderText = "备注";
        //    remark.DataPropertyName = "strRemark";

        //    dataGridViewOutput.Columns.Add(ioNameColumn);
        //    dataGridViewOutput.Columns.Add(cardNameColumn);
        //    dataGridViewOutput.Columns.Add(ioColumn);
        //    dataGridViewOutput.Columns.Add(ignore);
        //    dataGridViewOutput.Columns.Add(remark);

        //    if (IOManage.IODoc.m_OutputDataList!=null&& IOManage.IODoc.m_OutputDataList.Count>0)
        //    {
        //        dataGridViewOutput.DataSource = IOManage.IODoc.m_OutputDataList;
        //    }

        //}
        //private void FormIOSetting_Load(object sender, EventArgs e)
        //{
        //    DrawInput();
        //    DrawOutput();
        //}
        //private void buttonAddOutput_Click(object sender, EventArgs e)
        //{
        //    if (textBoxOutputName.Text == "")
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        OutputData data = new OutputData();
        //        data.strIOName = textBoxOutputName.Text.Trim();
        //        data.iOutputNo = 0;
        //        data.OutputCardName = "";
        //        IOManage.IODoc.m_OutputDictionary.Add(data.strIOName, data);
        //        IOManage.IODoc.m_OutputDataList.Add(data);
        //        DrawOutput();
        //    }
        //    catch
        //    {

        //    }
        //}
        //private void buttonRemoveOutput_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewOutput.SelectedRows.Count == 1)
        //    {
        //        OutputData data = dataGridViewOutput.SelectedRows[0].DataBoundItem as OutputData;
        //        IOManage.IODoc.m_OutputDictionary.Remove(data.strIOName);
        //        IOManage.IODoc.m_OutputDataList.Remove(data);
        //        DrawOutput();
        //    }
        //}
        //private void dataGridViewOutput_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //}

        //private void dataGridViewOutput_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void buttonExport_Click(object sender, EventArgs e)
        //{
        //    string strTempPath = @".//TempFile/";
        //    string strTempName = "InputName.cs";
        //    if (!Directory.Exists(strTempPath))
        //    {
        //        Directory.CreateDirectory(strTempPath);
        //    }
        //    string strConcent = MakeInputText();
        //    System.IO.File.WriteAllText((strTempPath + strTempName), strConcent);

        //    strTempPath = @".//TempFile/";
        //    strTempName = "OutputName.cs";
        //    if (!Directory.Exists(strTempPath))
        //    {
        //        Directory.CreateDirectory(strTempPath);
        //    }
        //    strConcent = MakeOutputText();
        //    System.IO.File.WriteAllText((strTempPath + strTempName), strConcent);
        //}
        //private string MakeInputText()
        //{
        //    string strReturn = "";
        //    if (IOManage.IODoc.m_InputDataList.Count < 1)
        //        return strReturn;

        //    string strTempHeader = "using System;\r\n";
        //    strTempHeader += "using System.Collections.Generic;\r\n";
        //    strTempHeader += "using System.Linq;\r\n";
        //    strTempHeader += "using System.Text;\r\n";
        //    strTempHeader += "using System.Threading.Tasks;\r\n";
        //    strTempHeader += "\r\n";
        //    strTempHeader += "namespace ControlPlatformLib\r\n";
        //    strTempHeader += "{\r\n";
        //    strTempHeader += "   public static class InputName\r\n";
        //    strTempHeader += "   {\r\n";
        //    strReturn = strTempHeader;
        //    string strItemHeader = "      public static string ";// WEIDONGYUAN = "weidongyuan";
        //    string strItemName = "";
        //    string strItemOperation = " = ";
        //    string strValue = "";
        //    string strItemEnd = " ;\r\n";
        //    foreach (InputData item in IOManage.IODoc.m_InputDataList)
        //    {
        //        strItemName = item.strIOName;
        //        strValue = "\"" + strItemName + "\"";
        //        strReturn += strItemHeader + strItemName + strItemOperation + strValue + strItemEnd;
        //    }

        //    string strTempEnd = "   }\r\n";
        //    strTempEnd += "}\r\n";
        //    strReturn += strTempEnd;
        //    return strReturn;
        //}
        //private string MakeOutputText()
        //{
        //    string strReturn = "";
        //    if (IOManage.IODoc.m_OutputDataList.Count < 1)
        //        return strReturn;

        //    string strTempHeader = "using System;\r\n";
        //    strTempHeader += "using System.Collections.Generic;\r\n";
        //    strTempHeader += "using System.Linq;\r\n";
        //    strTempHeader += "using System.Text;\r\n";
        //    strTempHeader += "using System.Threading.Tasks;\r\n";
        //    strTempHeader += "\r\n";
        //    strTempHeader += "namespace ControlPlatformLib\r\n";
        //    strTempHeader += "{\r\n";
        //    strTempHeader += "   public static class OutputName\r\n";
        //    strTempHeader += "   {\r\n";
        //    strReturn = strTempHeader;
        //    string strItemHeader = "      public static string ";// WEIDONGYUAN = "weidongyuan";
        //    string strItemName = "";
        //    string strItemOperation = " = ";
        //    string strValue = "";
        //    string strItemEnd = " ;\r\n";
        //    foreach (OutputData item in IOManage.IODoc.m_OutputDataList)
        //    {
        //        strItemName = item.strIOName;
        //        strValue = "\"" + strItemName + "\"";
        //        strReturn += strItemHeader + strItemName + strItemOperation + strValue + strItemEnd;
        //    }

        //    string strTempEnd = "   }\r\n";
        //    strTempEnd += "}\r\n";
        //    strReturn += strTempEnd;
        //    return strReturn;
        //}

        //private void dataGridViewInput_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void dataGridViewOutput_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
