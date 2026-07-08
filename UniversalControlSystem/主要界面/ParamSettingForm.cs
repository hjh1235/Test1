using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class ParamSettingForm : Form
    {
        private PointSetting_Form pointForm = new PointSetting_Form();
        public ParamSettingForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParamSettingForm_Load(object sender, EventArgs e)
        {
            cb_CloseLaser.Checked = Properties.Settings.Default.bGratingEStopDeal;
            checkB_Door.Checked = Properties.Settings.Default.bDoorOpenEStopDeal;
            chooseAisx.Checked = Properties.Settings.Default.chooseAisx;
            checkBox_回原选择.Checked = Properties.Settings.Default.回原选择;
            checkBox_屏蔽AGV.Checked = Properties.Settings.Default.屏蔽小车;
            cb_IgnoreScanner.Checked = Properties.Settings.Default.屏蔽扫码;
            if (Properties.Settings.Default.屏蔽mes == true)
            {
                cb_IgnoreMES.Checked = true;
            }
            else
            {
                cb_IgnoreMES.Checked = false;
            }
            //更新主页状态
            SerialPortCom.updateInfo += (p1, p2) =>
            {
                this.Invoke(new Action(() =>
                {
                    if (p1 == 1 && p2 == "复位小车")
                    {
                        checkBox_屏蔽AGV.Checked = false;
                    }
                }));
            };
            txtMsg.Text = "提示:" + "\r\n     光栅、门禁：急停模式即轴断使能解除报警后恢复使能，需重新回原点。暂停则是待设备将当前流程运行完毕后再停止，不断使能，重新启动即可。";
            if (Properties.Settings.Default.bDoorOpenEStopDeal)
            {
                rbtn_DoorOpenEStop.Checked = true;
            }
            else
            {
                rbtn_DoorOpenStop.Checked = true;
            }
            if (Properties.Settings.Default.bGratingEStopDeal)
            {
                rbtn_GratingEStop.Checked = true;
            }
            else
            {
                rbtn_GratingStop.Checked = true;
            }
            cbo_GetSNWay.Text = Properties.Settings.Default.GetSNWay;
            cbo_MESSetting.Text = Properties.Settings.Default.MESSetting;
            cb_CloseLaser.Checked = Properties.Settings.Default.bRightIsUsed;
            checkB_Door.Checked = Properties.Settings.Default.bMiddleIsUsed;

            //点位列表
            List<string> pointArrLeft = getPointLeftData();
            List<string> pointArrRight = getPointRightData();
            List<string> pointArr = getPointData();
            foreach (var item in pointArrLeft)
            {
                com_pointListLeft.Items.Add(item);
            }
            foreach (var item in pointArrRight)
            {
                com_pointListRight.Items.Add(item);
            }
            foreach (var item in pointArr)
            {
                com_singleTaskList.Items.Add(item);
            }
            //流程数据
            foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
            {
                if (item.Value.配方是否为默认 == "默认")
                {
                    com_flow1.Items.Add(item.Key);
                    COM_flow2.Items.Add(item.Key);
                } 
            }
            com_singleTaskList.SelectedItem = Properties.Settings.Default.PointList;
            com_pointListRight.SelectedItem = Properties.Settings.Default.RightPointTask;
            com_pointListLeft.SelectedItem = Properties.Settings.Default.LeftPointTask;
            com_flow1.SelectedItem = Properties.Settings.Default.流程1;

        }
        /// <summary>
        /// 门禁模式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_DoorOpenEStop_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.bDoorOpenEStopDeal = rbtn_DoorOpenEStop.Checked;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// 光栅模式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_GratingEStop_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.bGratingEStopDeal = rbtn_GratingEStop.Checked;
            Properties.Settings.Default.Save();
        }

        private void rbtn_DoorOpenStop_CheckedChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default.bDoorOpenEStopDeal = rbtn_DoorOpenEStop.Checked;
        }

        private void rbtn_GratingStop_CheckedChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default.bGratingEStopDeal = rbtn_GratingEStop.Checked;
        }
        /// <summary>
        /// 获取条码方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_GetSNWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GetSNWay = cbo_GetSNWay.Text;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// 获取MES模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_MESSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MESSetting = cbo_MESSetting.Text;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// 是否启用双工位设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_RightUsed_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.bGratingEStopDeal = cb_CloseLaser.Checked;
            Properties.Settings.Default.Save();
        }

        private void txtMsg_TextChanged(object sender, EventArgs e)
        {
            txtMsg.Text = "提示:" + "\r\n光栅、门禁：急停模式即轴断使能解除报警后恢复使能，需重新回原点。暂停则是待设备将当前流程运行完毕后再停止，不断使能，重新启动即可。";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.bDoorOpenEStopDeal = checkB_Door.Checked;
            Properties.Settings.Default.Save();
        }

        private void btn_MESLoad_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.OutChannel4);
        }

        private void com_flow1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.流程1 = com_flow1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        //获取左点位数据
        private List<string> getPointLeftData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "流程点位/左工位";
            List<string> pointList = new List<string>();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var files = Directory.GetFiles(path, "*.csv");
            foreach (var file in files)
            {
                string fileNameExt = file.Substring(file.LastIndexOf("\\") + 1); //获取文件名，不带路径
                string filePath = file.Substring(0, file.LastIndexOf("\\"));//获取文件路径，不带文件名   
                string name = fileNameExt.Substring(0, fileNameExt.LastIndexOf(".")); //获取文件名，不带后缀
                pointList.Add(name);
            }
            return pointList;
        }
        
        //获取右点位数据
        private List<string> getPointRightData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "流程点位/右工位";
            List<string> pointList = new List<string>();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var files = Directory.GetFiles(path, "*.csv");
            foreach (var file in files)
            {
                string fileNameExt = file.Substring(file.LastIndexOf("\\") + 1); //获取文件名，不带路径
                string filePath = file.Substring(0, file.LastIndexOf("\\"));//获取文件路径，不带文件名   
                string name = fileNameExt.Substring(0, fileNameExt.LastIndexOf(".")); //获取文件名，不带后缀
                pointList.Add(name);
            }
            return pointList;
        }


        //获取右点位数据
        private List<string> getPointData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "流程点位/单工位";
            List<string> pointList = new List<string>();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var files = Directory.GetFiles(path, "*.csv");
            foreach (var file in files)
            {
                string fileNameExt = file.Substring(file.LastIndexOf("\\") + 1); //获取文件名，不带路径
                string filePath = file.Substring(0, file.LastIndexOf("\\"));//获取文件路径，不带文件名   
                string name = fileNameExt.Substring(0, fileNameExt.LastIndexOf(".")); //获取文件名，不带后缀
                pointList.Add(name);
            }
            return pointList;
        }

        //左工位流程点位选择
        private void com_pointListLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LeftPointTask = com_pointListLeft.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }
        //右工位流程点位选择
        private void com_pointListRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RightPointTask = com_pointListRight.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        
        private void COM_flow2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.流程1 = COM_flow2.SelectedItem.ToString();
            Properties.Settings.Default.Save();           
        }

        //单工位流程点位选择
        private void com_singleTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PointList = com_singleTaskList.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void checkBox_BIZZ_CheckedChanged(object sender, EventArgs e)
        {
            Program.noBizz = checkBox_BIZZ.Checked;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cb_IgnoreMES.Checked == true)
            {
                Properties.Settings.Default.屏蔽mes = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.屏蔽mes = false;
                Properties.Settings.Default.Save();
            }
        }

        private void checkBox_屏蔽AGV_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.屏蔽小车 = checkBox_屏蔽AGV.Checked;
            Properties.Settings.Default.Save();
        }


        private void cb_IgnoreScanner_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.屏蔽扫码 = cb_IgnoreScanner.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox_锁光_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.允许出红光 = checkBox_锁光.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox_回原选择_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.回原选择 = checkBox_回原选择.Checked;
            Properties.Settings.Default.Save();
        }
        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (chooseAisx.Checked == true)
            {
                Properties.Settings.Default.chooseAisx = chooseAisx.Checked;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.chooseAisx = chooseAisx.Checked;
                Properties.Settings.Default.Save();
            }
        }
    }
}
