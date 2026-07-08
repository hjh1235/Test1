using HalconDotNet;
using HOperatorSet_EX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UniversalControlSystem
{
    [Serializable]
    public class FixtureTool : ImageTool
    {

        string modelName;
        /// <summary>
        /// 模板名
        /// </summary>
        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names{ get; set; }
        public bool ResultLogic{ get; set; }
        public HTuple OrgRow { get; set; }
        public HTuple OrgCol { get; set; }
        public HTuple OrgPhi { get; set; }
        [NonSerialized]
        List<HTuple> hv_phi = new List<HTuple>();
        public List<HTuple> Phi
        {
            get { return hv_phi; }
            set { hv_phi = value; }
        }
        [NonSerialized]
        List<HTuple> hv_HomMat2D = new List<HTuple>();
        public List<HTuple> HomMat2D
        {
            get { return hv_HomMat2D; }
            set { hv_HomMat2D = value; }
        }
        [NonSerialized]
        List<HTuple> hv_HomMat2D1 = new List<HTuple>();
        public List<HTuple> HomMat2D1
        {
            get { return hv_HomMat2D1; }
            set { hv_HomMat2D1 = value; }
        }

        [NonSerialized]
         Dictionary<string, HTuple> htRow = new  Dictionary<string, HTuple>();
        public  Dictionary<string, HTuple>  HtRow
        {
            get { return htRow; }
            set { htRow = value; }
        }
        [NonSerialized]
         Dictionary<string, HTuple> htCol = new  Dictionary<string, HTuple>();
        public  Dictionary<string, HTuple> HtCol
        {
            get { return htCol; }
            set { htCol = value; }
        }
         Dictionary<string, HTuple> htPhi = new  Dictionary<string, HTuple>();
        public  Dictionary<string, HTuple> HtPhi
        {
            get { return htPhi; }
            set { htPhi = value; }
        }
        public override string toolName()
        { 
            return Names;
        }
        public override long toolTimer()
        {
            return timer;
        }
        public override void ini()
        {
            Names = Tool.位置定位.ToString();
            modelName = "模板匹配0";
            OrgRow = 0;
            OrgCol = 0;
            OrgPhi  = 0;
        }
        public override void recon()
        {
            List<HTuple> hv_HomMat2D = new List<HTuple>();
            List<HTuple> hv_HomMat2D1 = new List<HTuple>();
            List<HTuple> hv_phi = new List<HTuple>();
            this.hv_HomMat2D = hv_HomMat2D;
            this.hv_HomMat2D1 = hv_HomMat2D1;
            this.hv_phi = hv_phi;
        }
        public override void draw_roi()
        { }
        /// <summary>
        /// 运行一次
        /// </summary>
        public override void run()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            toolRun();
            dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
        }
        private void toolRun()
        {
            HSystem.SetSystem("flush_graphic", "true");
            try
            {
                ResultLogic = true;//结果异常
                HTuple hv_HomMat2D = new HTuple();
                HTuple hv_HomMat2D1 = new HTuple();

                if (htRow.Count < 1)
                    return;
                for (int i = 0; i < ((HTuple)htRow[modelName]).Length; i++)// 开始仿射转换
                {
                    //原图坐标跟随当前图坐标（仿射转换）
                    HOperatorSet.VectorAngleToRigid(OrgRow, OrgCol, OrgPhi,
                                                            ((HTuple)htRow[modelName])[i], ((HTuple)htCol[modelName])[i], ((HTuple)htPhi[modelName])[i], out hv_HomMat2D);
                    this.hv_HomMat2D.Add(hv_HomMat2D); //仿射转换添加到集合中

                    //当前图坐标跟随原图坐标（仿射转换）
                    HOperatorSet.VectorAngleToRigid(((HTuple)htRow[modelName])[i], ((HTuple)htCol[modelName])[i], ((HTuple)htPhi[modelName])[i], OrgRow, OrgCol, OrgPhi,
                                                             out hv_HomMat2D1);
                    this.hv_HomMat2D1.Add(hv_HomMat2D1);//仿射转换添加到集合中
                    this.hv_phi.Add(((HTuple)htPhi[modelName])[i]);
                }
            }
            catch (HalconException ex)
            {
                HTuple hv_Exception;
                ex.ToHTuple(out  hv_Exception);
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
            }
        }
        public override void dispresult()
        { }
        public override long set_after()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            run();
            dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
            return watch.ElapsedMilliseconds;
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
        /// <summary>
        /// 注册原图坐标
        /// </summary>
        public void getOrginCoord()
        {
            OrgRow = ((HTuple)htRow[modelName])[0];
            OrgCol = ((HTuple)htCol[modelName])[0];
            OrgCol = ((HTuple)htPhi[modelName])[0];
        }
    }
}
