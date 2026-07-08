using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;


namespace UniversalControlSystem
{
    [Serializable]
    public partial class frm_AcqFifo : Form
    {
        //static frm_AcqFifo frm;
        //CameraDAL camera = new CameraDAL();
        AcqFifoTool acqFifoTool /*= new AcqFifoTool()*/;
        //public delegate void HandleaCanel();
        //public static event HandleaCanel eventCancel;
        //public delegate void HandledSetVal(AcqFifoTool acqFifoTool);
       // HandledSetVal handledSetVal;
        string imgPath;
        string _RunFlowData_ControlDataName = "";
        string _FlowChar_StepControlStepName = "";
        int Num = 0;
        /// <summary>
        ///  单实例
        /// </summary>
        /// <param name="am"></param>
        /// <param name="setVal"></param>
        /// <returns></returns>
        //public static frm_AcqFifo SingleShow(AcqFifoTool acqFifoTool/*, HandledSetVal setVal*/)
        //{
        //    if (frm == null)//
        //    {
        //        frm = new frm_AcqFifo(acqFifoTool/* setVal*/);
        //    }
        //    return frm;
        //}
        public frm_AcqFifo(/*AcqFifoTool acqFifoTool*//*, HandledSetVal handledSetVal*/)
        {
            InitializeComponent();
            //this.handledSetVal = handledSetVal;

        }
        public void ShowMesage(string Name, string StepName, int num)
        {
            TOOLName.Text = StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            //AcqFifoTool _AcqFifoTool;
            List<ImageTool> tools;

            tools = LoadData._ImageToolRun[TOOLName.Text];
            acqFifoTool = (AcqFifoTool)tools[Num];

            cbxInterface.Text = acqFifoTool.CameraInterface;//相机接口
            cbxDevice.Text = acqFifoTool.Device;//相机设备
   
            nudExposureTime.Value = Convert.ToDecimal(acqFifoTool.ExposureTime.D);//曝光



            HObject Image=null;

            try
            {
                acqFifoTool.run();
                DispImage(acqFifoTool.OutImage, false);
                Image = FitImage();
                DataManage.SetData(acqFifoTool.DataGroup, acqFifoTool.DataGroupName, Image);
            }
            catch (Exception  )
            {

              
            }





          
    
      
            存入数据组.Text = acqFifoTool.DataGroup;
            存入数据名.Text = acqFifoTool.DataGroupName;
            tbxToolName.Text = acqFifoTool.Names;
            if (acqFifoTool.IsUseImg==true)
            {
                cebxUseImg.Checked = true;
            }
            if (acqFifoTool.IsUseLoopImg == true)
            {
                cebkUseLoopImg.Checked = true;
            }
            if (acqFifoTool.IsGrabAsync == true)
            {
                cebxGrab.Checked = true;
                cebxGrab.Text = "同步采集";
            }
            else
            {
                if (acqFifoTool.IsGrabAsync)
                    cebxGrab.Text = "异步采集";
            }
            DisplayVal(acqFifoTool);//显示参数
       //     SetVal(ref this.acqFifoTool);//设置参数
      

            try
            {
                acqFifoTool.OutImage = DataManage._StrValue(acqFifoTool.DataGroup, acqFifoTool.DataGroupName);

            }
            catch (Exception ws)
            {

              
            }
 

            try
            {
                if (cebxUseImg.Checked == true)
                {
                 
                    int imageIndex = lbx_Image.SelectedIndex;
                   // string listBox1_path = lbx_Image.Items[imageIndex].ToString();
                    //acqFifoTool.ImgPath = imgPath /*+ "\\" + listBox1_path*/;
                    acqFifoTool.run();


                    DispImage(acqFifoTool.OutImage, false);
                    FitImage();
                }
                else
                {

                    acqFifoTool.run();
                    DispImage(acqFifoTool.OutImage, false);
                    Image = FitImage();
                }
                //HSystem.SetSystem("flush_graphic", "true");
                //HOperatorSet.DispObj(acqFifoTool.OutImage, HW.Instance().HalconWindow);
                //HSystem.SetSystem("flush_graphic", "false");


            }
            catch (Exception es )
            {

          
            }


            //HW.Instance().DispImage(acqFifoTool.OutImage, false);
            //HObject Image = HW.Instance().FitImage();
        }
        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="acqFifoTool">参数</param>
        void DisplayVal(AcqFifoTool acqFifoTool)
        {
            try
            {
                int nameIndex = acqFifoTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = acqFifoTool.Names.Substring(nameIndex + 1, acqFifoTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;//工具名
                }
                else
                {
                    this.Text = acqFifoTool.Names;
                    tbxToolName.Text = acqFifoTool.Names;//工具名
                }
                cbxInterface.Text = acqFifoTool.CameraInterface;//相机接口
                cbxDevice.Text = acqFifoTool.Device;//相机设备
                cebxUseImg.Checked = acqFifoTool.IsUseImg;//使用本地图片
                cebkUseLoopImg.Checked = acqFifoTool.IsUseLoopImg;//本地图片循环
               nudExposureTime.Value = Convert.ToDecimal(acqFifoTool.ExposureTime.D);//曝光
                cebxGrab.Checked = acqFifoTool.IsGrabAsync;


                tbxImgPath.Text = acqFifoTool.ImgPath;//图片文件路径
                //tbxImgPath.Text = acqFifoTool.ImgPath;//图片文件路径
                //if (acqFifoTool.ImgPath != null)
                //{
                //    int Index = acqFifoTool.ImgPath.LastIndexOf("\\");
                //    imgPath = acqFifoTool.ImgPath.Substring(0, Index);//截取图片文件路径
                //    tbxImgPath.Text = imgPath;//图片文件路径
                //    addListImg(acqFifoTool.ImgPath);//图片加载到列表中
                //}
            }
            catch { }
        }
        void SetVal(ref AcqFifoTool acqFifoTool)
        {
            acqFifoTool.Names = AcqFifoTool.Tool.采集图像.ToString() + "_" + tbxToolName.Text;
            acqFifoTool.CameraInterface = cbxInterface.Text;
            acqFifoTool.Device = cbxDevice.Text;
            acqFifoTool.IsUseImg = cebxUseImg.Checked;
            acqFifoTool.IsUseLoopImg = cebkUseLoopImg.Checked;
            acqFifoTool.ExposureTime = (double)nudExposureTime.Value;
            acqFifoTool.IsGrabAsync = cebxGrab.Checked;
            acqFifoTool.ImgPath = tbxImgPath.Text;
            cebxGrab.Text = "同步采集";
            if (acqFifoTool.IsGrabAsync)
                cebxGrab.Text = "异步采集";
        }
        private void frm_AcqFifo_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CenterToScreen();
            //hWindowControl1.TopLevel = false;
            //panel1.Controls.Add(HW.Instance());
            //hWindowControl1.Size = panel1.Size;
            //HW.Instance().Show();
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            CameraDAL.Instance().GetDeviceEvent += camera_GetDeviceEvent;//注册获取相机事件
            acqFifoTool.hWindowControl1 = hWindowControl1;
            /* HW.Instance().*/
            DispImage(acqFifoTool.OutImage, false);
            if (lbx_Image.Items.Count > 1)
                lbx_Image.SelectedIndex = 0;
            hwin1= hWindowControl1.HalconWindow;
            foreach (var item in DataManage.m_Doc.m_dataDictionary)
            {
                存入数据组.Items.Add(item.Value.strGroupName);
            }

        }
        void frm_AcqFifo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.acqFifoTool.CloseCamera();//关闭当前实例相机
        }
        // 获取相机事件
        void acqFifoTool_GrapImageEvent(object sender, EventArgsDAL e)
        {
            if (e.AcqHandle)
            {
                btnOpenCamera.Text = "关闭相机";
                HW.Instance().DispImage(e.Image, false);
                //halconView1.FitImage();
            }
        }
        // 采集图像事件
        void camera_GetDeviceEvent(object sender, EventArgsDAL e)
        {
            try
            {
                cbxDevice.Items.Clear();
                lbxDevInfo.Items.Clear();
                string[] devinfo = e.InfoList;
                string[] device = e.DeviceList;
                for (int i = 0; i < devinfo.Length; i++)
                {
                    lbxDevInfo.Items.Add(devinfo[i]);//相机信息
                }
                if (device != null)
                {
                    for (int i = 0; i < device.Length; i++)
                    {
                        cbxDevice.Items.Add(device[i]);
                        cbxDevice.Text = device[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_OpenCamera_Click(object sender, EventArgs e)
        {
            if (btnOpenCamera.Text == "打开相机" && cbxInterface.Text != "" && cbxDevice.Text != "")
            {
                acqFifoTool.CameraInterface = cbxInterface.Text;
                acqFifoTool.Device = cbxDevice.Text;
                acqFifoTool.OpenCamera();
                btnOpenCamera.Text = "关闭相机";
            }
            else
            {
                btnOpenCamera.Text = "打开相机";
                acqFifoTool.CloseCamera();
            }
        }
        private void btn_GrapImage_Click(object sender, EventArgs e)
        {
            acqFifoTool.CameraInterface = cbxInterface.Text;
            acqFifoTool.Device = cbxDevice.Text;
            acqFifoTool.Run();
            btnOpenCamera.Text = "关闭相机";
        }
        private void btn_SnapImage_Click(object sender, EventArgs e)
        {
            acqFifoTool.CameraInterface = cbxInterface.Text;
            acqFifoTool.Device = cbxDevice.Text;
            acqFifoTool.OnceRun();
            btnOpenCamera.Text = "关闭相机";
        }
        private void btn_getCamera_Click(object sender, EventArgs e)
        {
            CameraDAL.Instance().CameraInterface = cbxInterface.Text;
            CameraDAL.Instance().Device = cbxDevice.Text;
            CameraDAL.Instance().GetDevice();
        }
        private void btn_selectdir_Click(object sender, EventArgs e)
        {
            if (cebxUseImg.Checked == false)
            {
                MessageBox.Show("使用本地图片,请打钩！");
                return;
            }
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = Application.StartupPath;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(fb.SelectedPath))
                {
                    imgPath = fb.SelectedPath;
                    tbxImgPath.Text = fb.SelectedPath;
                    addListImg(fb.SelectedPath);
                }
                else
                {
                    MessageBox.Show("打开无图片！");
                }
            }
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            if (cebxUseImg.Checked == false)
            {
                MessageBox.Show("使用本地图片,请打钩！");
                return;
            }
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "图片(*.bmp)|*.bmp|图片(*.jpg)|*.jpg|图片(*.jp2)|*.jp2|图片(*.gif)|*.gif|图片(*.png)|*.png|图片(*.tif)|*.tif";
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                acqFifoTool.ImgPath = openImage.FileName;
                acqFifoTool.run();
                DispImage(acqFifoTool.OutImage, false);
                HObject Image= FitImage();
                DataManage.SetData(acqFifoTool.DataGroup, acqFifoTool.DataGroupName, Image);
             
            }
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="img">图像</param>
        /// <param name="b">是否显示</param>
        /// 
        public void DispImage(HObject img, bool b)
        {
            try
            {
                if (ho_img != null)
                    ho_img.Dispose();//释放图片内存
                                     //if (cbxImage.Text !="")
                                     //{
                                     //    ho_img = (HObject)Image[cbxImage.Text];
                                     //    HOperatorSet.GetImageSize(ho_img, out width, out height);
                                     //}
                                     //else
                                     //{
                HOperatorSet.CopyImage(img, out ho_img);
                HOperatorSet.GetImageSize(img, out width, out height);
                //}
                if (b)
                {
                    HSystem.SetSystem("flush_graphic", "true");
                    hwin1.DispObj(ho_img);
                    HSystem.SetSystem("flush_graphic", "false");
                }
            }
            catch (HalconException)
            {

            }
        }
        private HWindow hwin1;
        private HTuple width, height;
        public HObject ho_img;//显示图片
                              // 窗口和图像的宽高比
        private double ratio_win, ratio_img;
        /// <summary>
        ///  适应图片
        /// </summary>
        public HObject FitImage()
        {
            try
            {
                if (ho_img != null)
                {
                    HOperatorSet.GetImageSize(ho_img, out width, out height);
                    ratio_win = (double)hWindowControl1.WindowSize.Width / (double)hWindowControl1.WindowSize.Height;
                    ratio_img = (double)width / (double)height;
                    int _beginRow, _begin_Col, _endRow, _endCol;
                    if (ratio_win >= ratio_img)
                    {
                        _beginRow = 0;
                        _endRow = (int)height.D - 1;
                        _begin_Col = (int)(-width.D * (ratio_win / ratio_img - 1d) / 2d);
                        _endCol = (int)(width.D + width.D * (ratio_win / ratio_img - 1d) / 2d);
                    }
                    else
                    {
                        _begin_Col = 0;
                        _endCol = (int)width.D - 1;
                        _beginRow = (int)(-height.D * (ratio_img / ratio_win - 1d) / 2d);
                        _endRow = (int)(height.D + height.D * (ratio_img / ratio_win - 1d) / 2d);
                    }
              
                    hwin1.SetPart(_beginRow, _begin_Col, _endRow, _endCol);
                    hwin1.ClearWindow();
                    HSystem.SetSystem("flush_graphic", "true");
                    hwin1.DispObj(ho_img);
                    HSystem.SetSystem("flush_graphic", "false");


                }
            }
            catch (HalconException)
            {
            }
            return ho_img;
        }
        void addListImg(string path)
        {
            int Debug = path.LastIndexOf("Debug");//是否是debug下的文件
            try
            {
                if (Debug != -1)
                {
                    string bugPath = path.Substring(Debug + 5, path.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
                    string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
                    if (bugPath.LastIndexOf(".") > 0)
                    {
                        int Index = NewImagePath.LastIndexOf("\\");
                        string tempImgPath = NewImagePath.Substring(0, Index);
                        path = tempImgPath;
                    }
                    else
                        path = NewImagePath;
                }
                else
                {
                    if (path.LastIndexOf(".") > 0)
                    {
                        int Index = path.LastIndexOf("\\");
                        string tempImgPath = path.Substring(0, Index);
                        path = tempImgPath;
                    }
                }
                string imgtype = "*.BMP|*.JPG|*.JP2|*.GIF|*.PNG|*.TIF";
                lbx_Image.Items.Clear();
                string[] ImageType = imgtype.Split('|');
                for (int i = 0; i < ImageType.Length; i++)
                {
                    string[] dirs = Directory.GetFiles(path, ImageType[i]);
                    foreach (string s in dirs)
                    {
                        lbx_Image.Items.Add(new FileInfo(s).Name);
                    }
                }
                foreach (TabPage tp in tabControl1.TabPages)
                {
                    if (tp.Text == "本地图片")
                    {
                        tabControl1.SelectedTab = tp;
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("文件夹不存在图片！");
            }
        }
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                acqFifoTool.CloseCamera();//关闭当前实例相机
                SetVal(ref acqFifoTool);
                int imageIndex = lbx_Image.SelectedIndex;
                if (imageIndex != -1)
                {
                    string listBox1_path = lbx_Image.Items[imageIndex].ToString();
                    acqFifoTool.ImgPath = imgPath + "\\" + listBox1_path;
                }
                else
                {
                    string listBox1_path = lbx_Image.Items[0].ToString();
                    acqFifoTool.ImgPath = imgPath + "\\" + listBox1_path;
                }
                this.Hide();
            }
            catch
            {
               acqFifoTool.CloseCamera();//关闭当前实例相机
                SetVal(ref acqFifoTool);
                this.Hide();
            }
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = acqFifoTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
            HW.Instance().ToolLable2.Text = "FAIL";
            HW.Instance().ToolLable2.ForeColor = Color.Red;
            if (acqFifoTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
                HW.Instance().ToolLable2.Text = "PASS";
                HW.Instance().ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            HW.Instance().ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            HW.Instance().DispImage(acqFifoTool.OutImage, true);
            DataManage.SetData(acqFifoTool.DataGroup, acqFifoTool.DataGroupName, acqFifoTool.OutImage);
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            acqFifoTool.CloseCamera();
            this.Hide();
            //frm = null;
            //eventCancel();
        }
        private void cbx_interface_SelectedIndexChanged(object sender, EventArgs e)
        {
            acqFifoTool.CameraInterface = cbxInterface.Text;
        }
        private void cbx_device_SelectedIndexChanged(object sender, EventArgs e)
        {
            acqFifoTool.Device = cbxDevice.Text;
        }
        private void cek_boxUseImg_CheckedChanged(object sender, EventArgs e)
        {
            acqFifoTool.IsUseImg = cebxUseImg.Checked;
        }
        private void cek_useLoopImg_CheckedChanged(object sender, EventArgs e)
        {
            acqFifoTool.IsUseLoopImg = cebkUseLoopImg.Checked;
        }
        private void tbx_toolName_TextChanged(object sender, EventArgs e)
        {
            acqFifoTool.Names = ImageTool.Tool.采集图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void lbx_Image_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int imageIndex = lbx_Image.SelectedIndex;
                string listBox1_path = lbx_Image.Items[imageIndex].ToString();
                acqFifoTool.ImgPath = imgPath + "\\" + listBox1_path;
                acqFifoTool.run();


                DispImage(acqFifoTool.OutImage, false);
                FitImage();
            }
            catch { }
        }



        private void nudExposureTime_ValueChanged(object sender, EventArgs e)
        {
            acqFifoTool.ExposureTime = (double)nudExposureTime.Value;
            acqFifoTool._ExposureTime();
        }

        private void ceboxGrab_CheckedChanged(object sender, EventArgs e)
        {
            acqFifoTool.IsGrabAsync = cebxGrab.Checked;
            cebxGrab.Text = "同步采集";
            if (acqFifoTool.IsGrabAsync)
                cebxGrab.Text = "异步采集";

        }

        private void btnRegisterImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("是否注册当前图像", "注册前图像", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    write_image(acqFifoTool.OutImage);
                    MessageBox.Show("注册当前图像成功!");
                }
            }
            catch
            {
                MessageBox.Show("注册当前图像失败");
            }
        }
        /// <summary>
        ///  写图片
        /// </summary>
        /// <param name="ho_Image">图片变量</param>
        public void write_image(HObject ho_Image)
        {
            string AppPath = Application.StartupPath;
            string savepath = AppPath + @"\" + "RegisterImg";
            string filepath = savepath + @"\" + "Register.bmp";
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            if (ho_Image != null)
                HOperatorSet.WriteImage(ho_Image, "bmp", 0, filepath);

        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {

            if (btnOpenCamera.Text == "打开相机" && cbxInterface.Text != "" && cbxDevice.Text != "")
            {
                acqFifoTool.CameraInterface = cbxInterface.Text;
                acqFifoTool.Device = cbxDevice.Text;
                acqFifoTool.OpenCamera();
                btnOpenCamera.Text = "关闭相机";
            }
            else
            {
                btnOpenCamera.Text = "打开相机";
                acqFifoTool.CloseCamera();
            }
        }

        private void toolLabel1_Click(object sender, EventArgs e)
        {

        }

        private void 存入数据组_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AcqFifoTool acqFifoTool;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                acqFifoTool = (AcqFifoTool)tools[Step];
                acqFifoTool.DataGroup = 存入数据组.Text;
                存入数据名.Text = "";
                存入数据名.Items.Clear();
                foreach (var item in DataManage.m_Doc.m_dataDictionary[存入数据组.Text].m_dataDictionary)
                {
                    存入数据名.Items.Add(item.Value.strName);
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void 存入数据名_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AcqFifoTool acqFifoTool;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                acqFifoTool = (AcqFifoTool)tools[Step];
                acqFifoTool.DataGroupName = 存入数据名.Text;
            }
            catch (Exception ex)
            {
            }
        }
        //   AcqFifoTool acqFifoTool = new AcqFifoTool();
        //   static frm_AcqFifo frm;
        //   //CameraDAL camera = new CameraDAL();
        //   //AcqFifoTool acqFifoTool = new AcqFifoTool();
        //   public delegate void HandleaCanel();
        //   public static event HandleaCanel eventCancel;
        // //  public delegate void HandledSetVal(AcqFifoTool acqFifoTool);
        ////   HandledSetVal handledSetVal;
        //   string imgPath;
        //   /// <summary>
        //   ///  单实例
        //   /// </summary>
        //   /// <param name="am"></param>
        //   /// <param name="setVal"></param>
        //   /// <returns></returns>
        //   //public static frm_AcqFifo SingleShow(AcqFifoTool acqFifoTool, HandledSetVal setVal)
        //   //{
        //   //    if (frm == null)//
        //   //    {
        //   //        frm = new frm_AcqFifo(acqFifoTool, setVal);
        //   //    }
        //   //    return frm;
        //   //}
        //   public frm_AcqFifo(/*AcqFifoTool acqFifoTool*//*, HandledSetVal handledSetVal*/)
        //   {
        //       InitializeComponent();
        //       //this.handledSetVal = handledSetVal;
        //       //DisplayVal(acqFifoTool);//显示参数
        //       //SetVal(ref this.acqFifoTool);//设置参数
        //   }
        //   /// <summary>
        //   /// 显示参数
        //   /// </summary>
        //   /// <param name="acqFifoTool">参数</param>
        //   //void DisplayVal(AcqFifoTool acqFifoTool)
        //   //{
        //   //    try
        //   //    {
        //   //        int nameIndex = acqFifoTool.Names.LastIndexOf("_");
        //   //        if (nameIndex != -1)
        //   //        {
        //   //            string name = acqFifoTool.Names.Substring(nameIndex + 1, acqFifoTool.Names.Length - (nameIndex + 1));
        //   //            this.Text = name;
        //   //            tbxToolName.Text = name;//工具名
        //   //        }
        //   //        else
        //   //        {
        //   //            this.Text = acqFifoTool.Names;
        //   //            tbxToolName.Text = acqFifoTool.Names;//工具名
        //   //        }
        //   //        cbxInterface.Text = acqFifoTool.CameraInterface;//相机接口
        //   //        cbxDevice.Text = acqFifoTool.Device;//相机设备
        //   //        cebxUseImg.Checked = acqFifoTool.IsUseImg;//使用本地图片
        //   //        cebkUseLoopImg.Checked = acqFifoTool.IsUseLoopImg;//本地图片循环
        //   //        nudExposureTime.Value = Convert.ToDecimal(acqFifoTool.ExposureTime.D);//曝光
        //   //        cebxGrab.Checked = acqFifoTool.IsGrabAsync;
        //   //        //tbxImgPath.Text = acqFifoTool.ImgPath;//图片文件路径
        //   //        if (acqFifoTool.ImgPath != null)
        //   //        {
        //   //            int Index = acqFifoTool.ImgPath.LastIndexOf("\\");
        //   //            imgPath = acqFifoTool.ImgPath.Substring(0, Index);//截取图片文件路径
        //   //            tbxImgPath.Text = imgPath;//图片文件路径
        //   //            addListImg(acqFifoTool.ImgPath);//图片加载到列表中
        //   //        }
        //   //    }
        //   //    catch { }
        //   //}
        //   //void SetVal(ref AcqFifoTool acqFifoTool)
        //   //{
        //   //    acqFifoTool.Names = AcqFifoTool.Tool.采集图像.ToString() + "_" + tbxToolName.Text;
        //   //    acqFifoTool.CameraInterface = cbxInterface.Text;
        //   //    acqFifoTool.Device = cbxDevice.Text;
        //   //    acqFifoTool.IsUseImg = cebxUseImg.Checked;
        //   //    acqFifoTool.IsUseLoopImg = cebkUseLoopImg.Checked;
        //   //    acqFifoTool.ExposureTime = (double)nudExposureTime.Value;
        //   //    acqFifoTool.IsGrabAsync = cebxGrab.Checked;
        //   //    //acqFifoTool.ImgPath = tbxImgPath.Text;
        //   //    cebxGrab.Text = "同步采集";
        //   //    if (acqFifoTool.IsGrabAsync)
        //   //        cebxGrab.Text = "异步采集";
        //   //}
        //   private void frm_AcqFifo_Load(object sender, EventArgs e)
        //   {
        //       this.MinimizeBox = false;
        //       this.MaximizeBox = false;
        //       this.CenterToScreen();

        //       HW.Instance().TopLevel = false;
        //       panel1.Controls.Add(HW.Instance());
        //       HW.Instance().Size = panel1.Size;
        //       HW.Instance().Show();



        //       //HOperatorSet.SetWindowParam(halconView1.HalconWindow, "background_color", "blue");
        //       this.FormClosing += frm_AcqFifo_FormClosing;//注册窗口关闭事件
        //       //this.camera.GetDeviceEvent += camera_GetDeviceEvent;//注册获取相机事件
        //       //this.acqFifoTool.GrapImageEvent += acqFifoTool_GrapImageEvent; //注册采集图像事件
        //        this.acqFifoTool.hWindowControl1 = HW.Instance().hWindowControl1;
        //       //this.halconView1.DispImage(acqFifoTool.OutImage, false);
        //       //if (lbx_Image.Items.Count > 1)
        //       //    lbx_Image.SelectedIndex = 0;
        //   }
        //   void frm_AcqFifo_FormClosing(object sender, FormClosingEventArgs e)
        //   {
        //  //     this.acqFifoTool.CloseCamera();//关闭当前实例相机
        //       frm = null;
        //       eventCancel();
        //   }
        //   // 获取相机事件
        //   //void acqFifoTool_GrapImageEvent(object sender, EventArgsDAL e)
        //   //{
        //   //    if (e.AcqHandle)
        //   //    {
        //   //        btnOpenCamera.Text = "关闭相机";
        //   //        halconView1.DispImage(e.Image, false);
        //   //        //halconView1.FitImage();
        //   //    }
        //   //}
        //   // 采集图像事件
        //   //void camera_GetDeviceEvent(object sender, EventArgsDAL e)
        //   //{
        //   //    try
        //   //    {
        //   //        cbxDevice.Items.Clear();
        //   //        lbxDevInfo.Items.Clear();
        //   //        string[] devinfo = e.InfoList;
        //   //        string[] device = e.DeviceList;
        //   //        for (int i = 0; i < devinfo.Length; i++)
        //   //        {
        //   //            lbxDevInfo.Items.Add(devinfo[i]);//相机信息
        //   //        }
        //   //        if (device != null)
        //   //        {
        //   //            for (int i = 0; i < device.Length; i++)
        //   //            {
        //   //                cbxDevice.Items.Add(device[i]);
        //   //                cbxDevice.Text = device[0];
        //   //            }
        //   //        }
        //   //    }
        //   //    catch (Exception ex)
        //   //    {
        //   //        MessageBox.Show(ex.Message);
        //   //    }
        //   //}
        //   private void btn_OpenCamera_Click(object sender, EventArgs e)
        //   {
        //       if (btnOpenCamera.Text == "打开相机" && cbxInterface.Text != "" && cbxDevice.Text != "")
        //       {
        //         acqFifoTool.CameraInterface = cbxInterface.Text;
        //           acqFifoTool.Device = cbxDevice.Text;
        //          acqFifoTool.OpenCamera();
        //           btnOpenCamera.Text = "关闭相机";
        //       }
        //       else
        //       {
        //           btnOpenCamera.Text = "打开相机";
        //          // acqFifoTool.CloseCamera();
        //       }
        //   }
        //   private void btn_GrapImage_Click(object sender, EventArgs e)
        //   {
        //       acqFifoTool.CameraInterface = cbxInterface.Text;
        //       acqFifoTool.Device = cbxDevice.Text;
        //       acqFifoTool.Run();
        //       btnOpenCamera.Text = "关闭相机";
        //   }
        //   private void btn_SnapImage_Click(object sender, EventArgs e)
        //   {
        //       acqFifoTool.CameraInterface = cbxInterface.Text;
        //       acqFifoTool.Device = cbxDevice.Text;
        //       acqFifoTool.OnceRun();
        //       btnOpenCamera.Text = "关闭相机";
        //   }
        //   string cameraInterface, device;
        //   EventArgsDAL _EventArgs = new EventArgsDAL();
        //   private void btn_getCamera_Click(object sender, EventArgs e)
        //   {
        //       HTuple hv_InfoList = null;
        //       HTuple hv_deviceList = null;
        //       GetDevice(cameraInterface, out hv_InfoList, out hv_deviceList);
        //       _EventArgs.InfoList = hv_InfoList;
        //       _EventArgs.DeviceList = hv_deviceList;
        //       OnGetDeviceEvent(_EventArgs);
        //   }
        //   public delegate void GetDeviceDelegate(object sender, EventArgsDAL e);
        //   public event GetDeviceDelegate GetDeviceEvent;
        //   private void OnGetDeviceEvent(EventArgsDAL e)
        //   {   //定义一个局部变量，将事件对象赋值给该变量，防止多线程情况取消事件
        //       GetDeviceDelegate mEvent = this.GetDeviceEvent;
        //       if (mEvent != null)
        //       {
        //           mEvent(this, e);//事件触发
        //       }
        //   }

        //   /// <summary>
        //   /// 获取相机设备
        //   /// </summary>
        //   /// <param name="cameraInterface">相机接口</param>
        //   /// <param name="hv_Information">相机信息</param>
        //   /// <param name="hv_deviceList">相机列表</param>
        //   void GetDevice(string cameraInterface, out HTuple hv_InfoList, out HTuple hv_deviceList)
        //   {
        //       HTuple hv_Information = null;
        //       hv_InfoList = null;
        //       hv_deviceList = null;
        //       if (cameraInterface == "")
        //       {
        //           MessageBox.Show("请选获取相机");
        //           return;
        //       }

        //       try
        //       {
        //           HOperatorSet.InfoFramegrabber(cameraInterface, "info_boards", out hv_Information, out hv_InfoList);
        //           HOperatorSet.InfoFramegrabber(cameraInterface, "device", out hv_Information, out hv_deviceList);
        //       }
        //       catch
        //       { MessageBox.Show(" 获取相机异常"); }
        //   }


        //   private void btn_selectdir_Click(object sender, EventArgs e)
        //   {
        //       if (cebxUseImg.Checked == false)
        //       {
        //           MessageBox.Show("使用本地图片,请打钩！");
        //           return;
        //       }
        //       FolderBrowserDialog fb = new FolderBrowserDialog();
        //       fb.SelectedPath = Application.StartupPath;
        //       if (fb.ShowDialog() == DialogResult.OK)
        //       {
        //           if (Directory.Exists(fb.SelectedPath))
        //           {
        //               imgPath = fb.SelectedPath;
        //               tbxImgPath.Text = fb.SelectedPath;
        //               addListImg(fb.SelectedPath);
        //           }
        //           else
        //           {
        //               MessageBox.Show("打开无图片！");
        //           }
        //       }
        //   }

        //   private void btnOpenImage_Click(object sender, EventArgs e)
        //   {
        //       if (cebxUseImg.Checked == false)
        //       {
        //           MessageBox.Show("使用本地图片,请打钩！");
        //           return;
        //       }
        //       OpenFileDialog openImage = new OpenFileDialog();
        //       openImage.Filter = "图片(*.bmp)|*.bmp|图片(*.jpg)|*.jpg|图片(*.jp2)|*.jp2|图片(*.gif)|*.gif|图片(*.png)|*.png|图片(*.tif)|*.tif";
        //       if (openImage.ShowDialog() == DialogResult.OK)
        //       {
        //           this.acqFifoTool.ImgPath = openImage.FileName;
        //           this.acqFifoTool.run();
        //           HW.Instance (). DispImage(acqFifoTool.OutImage, false);
        //           HW.Instance().FitImage();
        //       }

        //   }
        //   private HWindow hwin1;
        //   private HObject ho_img;//显示图片
        //   private HTuple width, height;
        //   // 窗口和图像的宽高比
        //   private double ratio_win, ratio_img;
        //   /// <summary>
        //   ///  适应图片
        //   /// </summary>
        //   public void FitImage()
        //   {
        //       try
        //       {
        //           if (ho_img != null)
        //           {
        //               HOperatorSet.GetImageSize(ho_img, out width, out height);
        //               ratio_win = (double)HW.Instance().hWindowControl1.WindowSize.Width / (double)HW.Instance().hWindowControl1.WindowSize.Height;
        //               ratio_img = (double)width / (double)height;
        //               int _beginRow, _begin_Col, _endRow, _endCol;
        //               if (ratio_win >= ratio_img)
        //               {
        //                   _beginRow = 0;
        //                   _endRow = (int)height.D - 1;
        //                   _begin_Col = (int)(-width.D * (ratio_win / ratio_img - 1d) / 2d);
        //                   _endCol = (int)(width.D + width.D * (ratio_win / ratio_img - 1d) / 2d);
        //               }
        //               else
        //               {
        //                   _begin_Col = 0;
        //                   _endCol = (int)width.D - 1;
        //                   _beginRow = (int)(-height.D * (ratio_img / ratio_win - 1d) / 2d);
        //                   _endRow = (int)(height.D + height.D * (ratio_img / ratio_win - 1d) / 2d);
        //               }
        //               hwin1 = HW.Instance().hWindowControl1.HalconWindow;            
        //               hwin1.SetPart(_beginRow, _begin_Col, _endRow, _endCol);
        //               hwin1.ClearWindow();
        //               HSystem.SetSystem("flush_graphic", "true");
        //               hwin1.DispObj(ho_img);
        //               HSystem.SetSystem("flush_graphic", "false");
        //           }
        //       }
        //       catch (HalconException ES )
        //       {
        //       }
        //   }
        //   /// <summary>
        //   /// 显示图片
        //   /// </summary>
        //   /// <param name="img">图像</param>
        //   /// <param name="b">是否显示</param>
        //   public void DispImage(HObject img, bool b)
        //   {
        //       try
        //       {
        //           if (ho_img != null)
        //               ho_img.Dispose();//释放图片内存
        //                                //if (cbxImage.Text !="")
        //                                //{
        //                                //    ho_img = (HObject)Image[cbxImage.Text];
        //                                //    HOperatorSet.GetImageSize(ho_img, out width, out height);
        //                                //}
        //                                //else
        //                                //{
        //           ho_img = new HObject();
        //           HOperatorSet.CopyImage(img, out ho_img);
        //           HOperatorSet.GetImageSize(img, out width, out height);
        //           //}
        //           if (b)
        //           {
        //               HSystem.SetSystem("flush_graphic", "true");
        //               hwin1.DispObj(ho_img);
        //               HSystem.SetSystem("flush_graphic", "false");
        //           }
        //       }
        //       catch (HalconException EX)
        //       {

        //       }
        //   }
        //   void addListImg(string path)
        //   {
        //       int Debug = path.LastIndexOf("Debug");//是否是debug下的文件
        //       try
        //       {
        //           if (Debug != -1)
        //           {
        //               string bugPath = path.Substring(Debug + 5, path.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
        //               string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
        //               if (bugPath.LastIndexOf(".") > 0)
        //               {
        //                   int Index = NewImagePath.LastIndexOf("\\");
        //                   string tempImgPath = NewImagePath.Substring(0, Index);
        //                   path = tempImgPath;
        //               }
        //               else
        //                   path = NewImagePath;
        //           }
        //           else
        //           {
        //               if (path.LastIndexOf(".") > 0)
        //               {
        //                   int Index = path.LastIndexOf("\\");
        //                   string tempImgPath = path.Substring(0, Index);
        //                   path = tempImgPath;
        //               }
        //           }
        //           string imgtype = "*.BMP|*.JPG|*.JP2|*.GIF|*.PNG|*.TIF";
        //           lbx_Image.Items.Clear();
        //           string[] ImageType = imgtype.Split('|');
        //           for (int i = 0; i < ImageType.Length; i++)
        //           {
        //               string[] dirs = Directory.GetFiles(path, ImageType[i]);
        //               foreach (string s in dirs)
        //               {
        //                   lbx_Image.Items.Add(new FileInfo(s).Name);
        //               }
        //           }
        //           foreach (TabPage tp in tabControl1.TabPages)
        //           {
        //               if (tp.Text == "本地图片")
        //               {
        //                   tabControl1.SelectedTab = tp;
        //                   break;
        //               }
        //           }
        //       }
        //       catch
        //       {
        //           MessageBox.Show("文件夹不存在图片！");
        //       }
        //   }
        //   private void btn_sure_Click(object sender, EventArgs e)
        //   {
        //      // AcqFifoTool acqFifoTool = new AcqFifoTool();// 参数传出,必须实例,this.acqFifoTool参数传出报错
        //       try
        //       {
        //         //  this.acqFifoTool.CloseCamera();//关闭当前实例相机
        //         //  SetVal(ref acqFifoTool);
        //           int imageIndex = lbx_Image.SelectedIndex;
        //           if (imageIndex != -1)
        //           {
        //               string listBox1_path = lbx_Image.Items[imageIndex].ToString();
        //              // acqFifoTool.ImgPath = imgPath + "\\" + listBox1_path;
        //           }
        //           else
        //           {
        //               string listBox1_path = lbx_Image.Items[0].ToString();
        //            //   acqFifoTool.ImgPath = imgPath + "\\" + listBox1_path;
        //             //acqFifoTool.ImgPath = this.acqFifoTool.ImgPath;
        //           }
        //          // handledSetVal(acqFifoTool);//
        //           this.Hide();
        //           frm = null;
        //       }
        //       catch
        //       {
        //       //    this.acqFifoTool.CloseCamera();//关闭当前实例相机
        //         //  SetVal(ref acqFifoTool);
        //        //   handledSetVal(acqFifoTool);//参数传出
        //           this.Hide();
        //           frm = null;
        //       }
        //   }

        //   private void btn_run_Click(object sender, EventArgs e)
        //   {
        //      // long timer = this.acqFifoTool.set_after();
        //       lblResult.Text = "FAIL";
        //       lblResult.BackColor = Color.Red;
        //      // halconView1.ToolLable2.Text = "FAIL";
        //     //  halconView1.ToolLable2.ForeColor = Color.Red;
        //      // if (this.acqFifoTool.ResultLogic)
        //       {
        //           lblResult.Text = "PASS";
        //           lblResult.BackColor = Color.LimeGreen;
        //          // halconView1.ToolLable2.Text = "PASS";
        //          // halconView1.ToolLable2.ForeColor = Color.Lime;
        //       }
        //    ///   lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        //     //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        //      // halconView1.DispImage(acqFifoTool.OutImage, true);
        //   }
        //   private void btn_cancel_Click(object sender, EventArgs e)
        //   {
        //     //  this.acqFifoTool.CloseCamera();
        //       this.Hide();
        //       frm = null;
        //       eventCancel();
        //   }
        //   private void cbx_interface_SelectedIndexChanged(object sender, EventArgs e)
        //   {
        //      // this.acqFifoTool.CameraInterface = cbxInterface.Text;
        //   }
        //   private void cbx_device_SelectedIndexChanged(object sender, EventArgs e)
        //   {
        //       //this.acqFifoTool.Device = cbxDevice.Text;
        //   }
        //   private void cek_boxUseImg_CheckedChanged(object sender, EventArgs e)
        //   {
        //       this.acqFifoTool.IsUseImg = cebxUseImg.Checked;
        //   }
        //   private void cek_useLoopImg_CheckedChanged(object sender, EventArgs e)
        //   {
        //       //this.acqFifoTool.IsUseLoopImg = cebkUseLoopImg.Checked;
        //   }
        //   private void tbx_toolName_TextChanged(object sender, EventArgs e)
        //   {
        //      // this.acqFifoTool.Names = ImageTool.Tool.采集图像.ToString() + "_" + tbxToolName.Text;
        //       this.Text = tbxToolName.Text;
        //   }
        //   private void lbx_Image_SelectedIndexChanged(object sender, EventArgs e)
        //   {
        //       try
        //       {
        //           int imageIndex = lbx_Image.SelectedIndex;
        //           string listBox1_path = lbx_Image.Items[imageIndex].ToString();
        //         this.acqFifoTool.ImgPath = imgPath + "\\" + listBox1_path;
        //           this.acqFifoTool.run();
        //          //this.halconView1.DispImage(acqFifoTool.OutImage, false);
        //          //halconView1.FitImage();



        //           this.acqFifoTool.run();
        //           DispImage(acqFifoTool.OutImage, false);
        //           FitImage();
        //       }
        //       catch { }
        //   }



        //   private void nudExposureTime_ValueChanged(object sender, EventArgs e)
        //   {
        //     //  acqFifoTool.ExposureTime = (double)nudExposureTime.Value;
        //      // acqFifoTool._ExposureTime();
        //   }

        //   private void ceboxGrab_CheckedChanged(object sender, EventArgs e)
        //   {
        //      // acqFifoTool.IsGrabAsync = cebxGrab.Checked;
        //       cebxGrab.Text = "同步采集";
        //      // if (acqFifoTool.IsGrabAsync)
        //           cebxGrab.Text = "异步采集";

        //   }

        //   private void btnRegisterImg_Click(object sender, EventArgs e)
        //   {
        //       try
        //       {
        //           if (DialogResult.Yes == MessageBox.Show("是否注册当前图像", "注册前图像", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
        //           {
        //             //  write_image(acqFifoTool.OutImage);
        //               MessageBox.Show("注册当前图像成功!");
        //           }
        //       }
        //       catch
        //       {
        //           MessageBox.Show("注册当前图像失败");
        //       }
        //   }
        //   /// <summary>
        //   ///  写图片
        //   /// </summary>
        //   /// <param name="ho_Image">图片变量</param>
        //   public void write_image(HObject ho_Image)
        //   {
        //       string AppPath = Application.StartupPath;
        //       string savepath = AppPath +  @"\" +"RegisterImg";
        //       string filepath = savepath + @"\" + "Register.bmp";
        //       if (!Directory.Exists(savepath))
        //           Directory.CreateDirectory(savepath);
        //       if (ho_Image != null)
        //           HOperatorSet.WriteImage(ho_Image, "bmp", 0, filepath);

        //   }


    }
    public class EventArgsDAL : EventArgs
    {
        public EventArgsDAL()
        { }
        /// <summary>
        /// 图像
        /// </summary>
        public HObject Image
        { get; set; }
        /// <summary>
        /// 图像句柄
        /// </summary>
        public HTuple AcqHandle
        { get; set; }
        public HTuple InfoList
        { get; set; }
        public HTuple DeviceList
        { get; set; }
        public HTuple FrameRate
        { get; set; }

    }
}
