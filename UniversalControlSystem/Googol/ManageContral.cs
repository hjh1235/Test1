using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TReturn = System.Int16;
namespace UniversalControlSystem
{
     public static class ManageContral
    {
        /// <summary>
        /// io输出控制
        /// </summary>
        /// <param name="_IO_Name"></param>
        /// <param name="bOn"></param>
        /// <returns></returns>
        /// o
        /// 

        static object lok = new object();
        public static int SetOutBit(string _IO_Name, bool bOn)
        {
            try
            {
                lock (lok)
                {
                    string name = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].hard_IO_Name;
                    ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                    IFC.SetOutBit(_IO_Name, bOn);
                }
            }
            catch (Exception ex)
            {

            
            }
      
           
            return 0;
        }
        /// <summary>
        /// 获取输出状态
        /// </summary>
        /// <param name="_IO_Name"></param>
        /// <returns></returns>
        public static bool GetOutOn(string _IO_Name)
        {
            string name = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].hard_IO_Name;
            ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
            return IFC.GetOutOn(_IO_Name); 
        }
        /// <summary>
        /// 获取输入状态
        /// </summary>
        /// <param name="_IO_Name"></param>
        /// <returns></returns>
        public static bool GetInOn(string _IO_Name)
        {
            bool sta = false;
            try
            {
                string name = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[_IO_Name].hard_IO_Name;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                sta= IFC.GetInOn(_IO_Name);
            }
            catch (Exception ex)
            {

          
            }
            return sta;
        }
        /// <summary>
        /// 单轴相对运动
        /// </summary>
        /// <param name="Aisx_Name"></param>
        /// <param name="postion"></param>
        /// <returns></returns>
        public static int AxisPrfTrapRel(string Aisx_Name, double postion)
        { 
            string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
           string sd= Hard_Ward_Contral.hardDoc.m_HardWareDictionary[name].sCardName;
            ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
            return IFC.AxisPrfTrapRel(Aisx_Name, postion);
        }
        /// <summary>
        /// Jog模试运动  
        /// </summary>
        /// <param name="Aisx_Name">轴名</param>
        /// <param name="bAir">方向</param>
        /// <returns></returns>
        public static int AxisPrfJogHome(string Aisx_Name, bool bAir)
        {
            string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
            ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
            return IFC.AxisPrfJogHome(Aisx_Name, bAir);
        }
        /// <summary>
        /// Jog模试运动  
        /// </summary>
        /// <param name="Aisx_Name">轴名</param>
        /// <param name="bAir">方向</param>
        /// <returns></returns>
        public static int AxisPrfJog(string Aisx_Name, bool bAir)
        {
            string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
            ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
            return IFC.AxisPrfJog(Aisx_Name, bAir);
        }
        /// <summary>
        /// 指定轴停止运动
        /// </summary>
        /// <param name="Aisx_Name">轴硬件配置名字</param>
        /// <param name="option">停止方式</param>
        /// <returns></returns>
        public static TReturn StopAxis(string Aisx_Name, int option = 0)
        {
            string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
            ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
            return IFC.StopAxis(Aisx_Name);
        }

        /// <summary>
        /// 单多轴运动
        /// </summary>
        /// <param name="CardDateDictionary"> 自定义流程控制数据</param>
        /// <returns></returns>
        public static int AxisPMoveAbsoluteToStop(Moves moves)
        {
            int[] iResult = new int[20]; ;
            int Ref = -1;
            string[] Aisx_Name = new string[20];
            for (int i = 0; i < moves.ListAxis.Count; i++)
            {
                if (moves.ListAxis[i].AxisName != "")
                {
                    Aisx_Name[i] = moves.ListAxis[i].AxisName;
                }
               
            }
            for (int i = 0; i < Aisx_Name.Length; i++)
            {
                if (Aisx_Name[i] != null)
                {
                    string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name[i]].MainCradBinding;
                    ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                    iResult[i] = IFC.AxisPMoveAbsoluteToStop(moves);
                }
            }          
            return 0;
        }
        public static int Go_home(string[] Asix_Name)
        {
            return 0;
            //string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name[i]].MainCradBinding;
            //ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
            //iResult[i] = IFC.AxisPMoveAbsoluteToStop(moves);
        }
        public static int GO_Home(string Aisx_Name)
        {
            string _name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
            ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[_name];
             IFC.GO_Home(Aisx_Name);
            return 0;
        }
        static object Lock = new object();
        /// <summary>
        /// 单轴绝对运动
        /// </summary>
        /// <param name="CardDateDictionary"> </param>
        /// <returns></returns>
        public static int AxisPMoveAbsoluteToStop(string Aisx_Name, double postion)
        {
            lock (Lock)
            {
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                IFC.AxisPMoveAbsoluteToStop(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Axis_hardwareName, postion, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Dec);
                return 0;

            }
          
        }
        /// <summary>
        /// 轴运动
        /// </summary>
        /// <param name="Aisx_Name">轴名称</param>
        /// <param name="postion">轴位置</param>
        /// <param name="Acc">加速度</param>
        /// <param name="Dec">减速度</param>
        /// <param name="Speed">速度</param>
        /// <returns></returns>
        public static int AxisPMoveAbsoluteToStop(string Aisx_Name, double postion, double Acc, double Dec, double Speed)
        {
            lock (Lock)
            {
                HiperTimer pt = new HiperTimer();
                if (Acc == 0)
                {
                    Acc = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Acc;
                }            
                if (Dec == 0)
                {
                    Dec = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Dec;
                }
                if (Speed == 0)
                {
                    Speed= Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Auto_Speed;
                }
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                IFC.AxisPMoveAbsoluteToStop(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Axis_hardwareName, postion, Speed, Acc, Dec);
                return 0;
            }
        }
        static object _LockPrint = new object();
        /// <summary>
        /// 单轴绝对运动指定速度
        /// </summary>
        /// <param name="CardDateDictionary"> </param>
        /// <returns></returns>
        public static int PrintAxisPMoveAbsoluteToStop(string Aisx_Name, double postion, double  speed)
        {
            lock (_LockPrint)
            {
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                IFC.AxisPMoveAbsoluteToStop(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Axis_hardwareName, postion, speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Dec);
                return 0;

            }

        }

        static object lockDetectingAxis = new object(); 
        public static int DetectingAxis(string Aisx_Name)
        {
            int res = -1;
            lock (lockDetectingAxis)
            {
                try
                {
                  
                  //  HiperTimer pt = new HiperTimer();
                    string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
                    ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                    Thread.Sleep(5);
                    //int P=    IFC.GETAxisP(Aisx_Name);

                    double P = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].AisxCurrentPosition;

                    if (IFC.DetectingAxis(Aisx_Name) == 1/*&& P==*/)
                    {
                        res = 0;
                    }
                }
                catch (Exception ee)
                {

               
                }
                
                return res;
            }
        }

        public static double  GETAxisp(string Aisx_Name)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                Thread.Sleep(5);
                return IFC.GETAxisP(Aisx_Name);
            }
        }
        public static int _ArcXYC(ArcXYC _ArcXYC)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                double acc = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].Acc;
                double dec = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].Dec;
                res= IFC.InsertArc(_ArcXYC);
                return res;
            }
        }

        public static int _LnXY(LnXY _LnXY)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXY._轴1Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                double acc = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXY._轴1Name].Acc;
                double dec = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXY._轴1Name].Dec;
                res = IFC.InsertLine(_LnXY);
                return res;
            }
        }
        public static int _LnXYZ(LnXYZ _LnXYZ)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZ._轴1Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                res = IFC.InsertLineLnXYZ(_LnXYZ);
                return res;
            }
        }
        public static int _LnXYZA(LnXYZA _LnXYZA)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴1Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                res = IFC.InsertLineLnXYZA(_LnXYZA);
                return res;
            }
        }

        public static int BuildCor(BufferArea _BufferArea)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_BufferArea._轴1Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                res = IFC.BuildCor(_BufferArea);
                return res;
            }
        }
        public static int ClearBuff(BufferArea _BufferArea)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_BufferArea._轴1Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                res = IFC.ClearBuff(_BufferArea);
                return res;
            }
        }
        public static int BuffAddStart(BufferArea _BufferArea)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_BufferArea._轴1Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                res = IFC.BuffAddStart(_BufferArea);
                return res;
            }
        }
        public static int BuffRun(BufferArea _BufferArea)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_BufferArea._轴1Name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                res = IFC.BuffRun(_BufferArea);
                return res;
            }
        }
        public static int AddOtherBuffFun(AddOtherBuff _AddOtherBuff)
        {
            lock (lockDetectingAxis)
            {
                int res = -1;
                HiperTimer pt = new HiperTimer();
                string _name = "";
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    if (_AddOtherBuff.CardNum== item.Value.m_CardNo)
                    {
                        _name = item.Value.Axis_hardwareName;

                    }

                }
                string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_name].MainCradBinding;
                ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                res = IFC.AddOtherBuffFun(_AddOtherBuff);
                return res;
            }
        }

        public static int StartManualPulser(int Aisx,int Time )
        {
            lock (lockDetectingAxis)
            {
                int res = 0;
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    if (item.Value.m_AxisNo== Aisx)
                    {
                   
                        string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].MainCradBinding;
                        ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                        IFC.StartManualPulserOperation(Aisx, Time);
                    }
                }
                return res;
            }
        }

        public static int StopManualPulser(int Aisx)
        {
            lock (lockDetectingAxis)
            {
                int res = 0;
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    if (item.Value.m_AxisNo == Aisx)
                    {

                        string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].MainCradBinding;
                        ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
                        IFC.StopManualPulserOperation(Aisx);
                    }
                }
                return res;
            }


        }
        public static bool CirRun(Cir CirRun)
        {
            string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CirRun._轴1Name].MainCradBinding;
            ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
            return  IFC.CirRun(CirRun);
        }
        public static bool MoveRec(Dimetric Dimetric)
        {
            string name = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].MainCradBinding;
            ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[name];
            return IFC.MoveRec(Dimetric);
        }
        
    }
}
