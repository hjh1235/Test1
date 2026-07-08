using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    using System.Drawing;
    using E3_POINTER = Int64;
    public struct Box2d
    {
        Pt2d a;
        Pt2d b;
        public Pt2d A
        {
            get { return a; }
            set { a = value; }
        }
        public Pt2d B
        {
            get { return b; }
            set { b = value; }
        }
    }
    public struct Pt2d
    {
        double x;
        double y;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
    }
    public class EzdKernel : Object
    {
        public class E3_ID
        {
            private Int64 value = 0;
            public const Int64 INVALID = 0;

            public E3_ID(Int64 p)
            {
                value = p;
            }

            public static implicit operator E3_ID(Int64 v)
            {
                return new E3_ID(v);
            }

            public static implicit operator Int64(E3_ID id)
            {
                if (id == null)
                {
                    return 0;
                }
                return id.value;
            }
        }

        ////错误ID返回错误
        public enum E3_ERR
        {
            SUCCESS = 0,
            FAIL = 1,
            ERRORPARAM = 2,//错误输入参数
            OPENFILE = 3,//打开文件失败 
            NOENTITY = 4,//没有加工对象
            EZCADRUN = 5,//ezcad已经运行
            NOLICENSE = 6,//无license
            NOCARD = 7,//无连接板卡
            NOFUNCTION = 8//没开功能
        }


        #region 开发库
        /// <summary>
        /// 初始化函数库
        /// PathName 是Ezcad3kernel.dll所在的目录
        /// <summary>     
        [DllImport("Ezcad3kernel", EntryPoint = "E3_Initial", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_Initial(string PathName, int nFlag);
        /// <summary>
        /// 检查激光器状态
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="bIsOK"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerCheckLaserState", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerCheckLaserState(E3_POINTER idMarker, ref bool bIsOK);
        public static E3_ERR E3_MarkerCheckLaserState(E3_ID idMarker, ref bool bIsOK)
        {
            return e3_MarkerCheckLaserState(idMarker, ref bIsOK);
        }
        /// <summary>
        /// 设置是否提示控制卡丢失信息
        /// </summary>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_DisableInitialPrompt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void E3_DisableInitialPrompt();
        /// <summary>
        /// 关闭函数库 
        /// </summary>     
        [DllImport("Ezcad3kernel", EntryPoint = "E3_Close", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_Close();

        //E3_API int E3_InitCamera();
        //E3_API int E3_CloseCamera();
        /// <summary>
        /// 初始化相机
        /// </summary>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_InitCamera", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_InitCamera();
        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CloseCamera", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_CloseCamera();
        #endregion
        #region 板卡
        //得到Marker的ID
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetFirstValidId", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_POINTER e3_MarkerGetFirstValidId();
        public static E3_ID E3_MarkerGetFirstValidId()
        {
            return e3_MarkerGetFirstValidId();
        }
        /// <summary>
        /// 获取控制卡SN序号
        /// </summary>     
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetMarkerSN", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetMarkerSN(E3_POINTER idMarker, ref int Sn);
        public static E3_ERR E3_GetMarkerSN(E3_ID idMarker, ref int Sn)
        {
            return e3_GetMarkerSN(idMarker, ref Sn);
        }
        /// <summary>
        /// 获取控制卡的硬件信息.
        /// </summary>
        /// <param name="idMarker">控制器句柄</param>
        /// <param name="szType">主板类型.</param>
        /// <param name="szVersion">主板硬件版本.</param>
        /// <param name="szFunInfo">主板功能信息.</param>
        /// <param name="szID">主板ID号.</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetHardInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_MarkerGetHardInfo(E3_ID idMarker, StringBuilder szType, StringBuilder szVersion, StringBuilder szFunInfo, StringBuilder szID);
        /// <summary>
        /// 关闭控制卡
        /// </summary>
        /// <param name="idMarker"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CloseMarker", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CloseMarker(E3_POINTER idMarker);
        public static E3_ERR E3_CloseMarker(E3_ID idMarker)
        {
            return e3_CloseMarker(idMarker);
        }

        #endregion
        #region 对象管理器
        /// <summary>
        /// 创建对象管理器 
        /// </summary>     
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateEntMgr", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_POINTER e3_CreateEntMgr(int nUnitType);
        public static E3_ID E3_CreateEntMgr(int nUnitType)
        {
            return (E3_ID)e3_CreateEntMgr(nUnitType);
        }
        /// <summary>
        /// 释放对象管理器 
        /// </summary>     
        [DllImport("Ezcad3kernel", EntryPoint = "E3_FreeEntMgr", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_FreeEntMgr(E3_POINTER idEM);
        public static E3_ERR E3_FreeEntMgr(E3_ID idEM)
        {
            return e3_FreeEntMgr(idEM);
        }
        #endregion
        #region 文件
        //打开文件到对象管理器
        [DllImport("Ezcad3kernel", EntryPoint = "E3_OpenFileToEntMgr", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_OpenFileToEntMgr(string pStrFileName, E3_POINTER idEM, bool bAddMode, bool bUndo);
        public static E3_ERR E3_OpenFileToEntMgr(string pStrFileName, E3_ID idEM, bool bAddMode, bool bUndo)
        {
            return e3_OpenFileToEntMgr(pStrFileName, idEM, bAddMode, bUndo);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="pStrFileName"></param>
        /// <param name="idEM"></param>
        /// <param name="bSelect"></param>
        /// <param name="bPreImage"></param>
        /// <param name="strAuthor"></param>
        /// <param name="strTime"></param>
        /// <param name="strNotes"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SaveEntMgrToFile", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SaveEntMgrToFile(string pStrFileName, E3_POINTER idEM, bool bSelect, bool bPreImage, string strAuthor, string strTime, string strNotes);
        public static E3_ERR E3_SaveEntMgrToFile(string pStrFileName, E3_ID idEM, bool bSelect, bool bPreImage, string strAuthor, string strTime, string strNotes)
        {
            return e3_SaveEntMgrToFile(pStrFileName, idEM, bSelect, bPreImage, strAuthor, strTime, strNotes);
        }
        #endregion
        [DllImport("gdi32.dll")]
        internal static extern bool DeleteObject(IntPtr hObject);

        //句柄
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        #region 预览
        // <summary>
        /// <summary>
        /// 在DC里绘制对象
        /// </summary>  
        [DllImport("Ezcad3kernel", EntryPoint = "E3_DrawEnt2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_DrawEnt2(IntPtr hdc, E3_POINTER idEnt, int nParam, int bmpwidth, int bmpheight, double dLogOriginX, double dLogOriginY, double dLogScale);
        public static E3_ERR E3_DrawEnt(IntPtr hdc, E3_ID idEnt, int nParam, int bmpwidth, int bmpheight, double dLogOriginX, double dLogOriginY, double dLogScale)
        {
            return e3_DrawEnt2(hdc, idEnt, nParam, bmpwidth, bmpheight, dLogOriginX, dLogOriginY, dLogScale);
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct BackBmpParam
        {
            /// int
            public int nWidth;
            /// int
            public int nHeight;
            /// int
            public int nBitCount;
            /// BYTE*
            public System.IntPtr pBits;
            /// double
            public double dShowPosLB_X;
            /// double
            public double dShowPosLB_Y;
            /// double
            public double dShowPosRT_X;
            /// double
            public double dShowPosRT_Y;
        }
        //struct BackBmpParam
        //{
        //    int nWidth;//位图宽度
        //    int nHeight;//位图高度
        //    int nBitCount;//位图位数
        //    byte[] pBits;//m_pBMI中像素数据位置

        //    double dShowPosLB_X;//图像显示的位置的左下角X坐标
        //    double dShowPosLB_Y;//图像显示的位置的左下角Y坐标
        //    double dShowPosRT_X;//图像显示的位置的右上角X坐标
        //    double dShowPosRT_Y;//图像显示的位置的右上角Y坐标
        //};
        //E3_API int E3_DrawEnt3(HDC hDC, E3_ID idEnt, int nParam, int bmpwidth, int bmpheight, double dLogOriginX, double dLogOriginY, double dLogScale, BackBmpParam* pBackBmpParam);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_DrawEnt3", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_DrawEnt3(IntPtr hdc, E3_POINTER idEnt, int nParam, int bmpwidth, int bmpheight, double dLogOriginX, double dLogOriginY, double dLogScale, BackBmpParam BackBmpData);
        public static E3_ERR E3_DrawEnt3(IntPtr hdc, E3_ID idEnt, int nParam, int bmpwidth, int bmpheight, double dLogOriginX, double dLogOriginY, double dLogScale, BackBmpParam BackBmpData)
        {
            return e3_DrawEnt3(hdc, idEnt, nParam, bmpwidth, bmpheight, dLogOriginX, dLogOriginY, dLogScale, BackBmpData);
        }

        #endregion

        #region 设备参数
        /// <summary>
        /// 设备参数
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="bReturnOk"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerDlgSetCfg", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerDlgSetCfg(E3_POINTER idMarker, ref bool bReturnOk);
        public static E3_ERR E3_MarkerDlgSetCfg(E3_ID idMarker, ref bool bReturnOk)
        {
            return e3_MarkerDlgSetCfg(idMarker, ref bReturnOk);
        }
        //E3_API int E3_MarkerGetCfgParamInt(E3_ID idMarker, int nIndex, int& nParam);
        //E3_API int E3_MarkerSetCfgParamInt(E3_ID idMarker, int nIndex, int nParam);
        //E3_API int E3_MarkerGetCfgParamDouble(E3_ID idMarker, int nIndex, double& dParam);
        //E3_API int E3_MarkerSetCfgParamDouble(E3_ID idMarker, int nIndex, double dParam);
        //得到CFGint参数
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetCfgParamInt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetCfgParamInt(E3_POINTER idMarker, int nIndex, ref int nParam);
        public static E3_ERR E3_MarkerGetCfgParamInt(E3_ID idMarker, int nIndex, ref int nParam)
        {
            return e3_MarkerGetCfgParamInt(idMarker, nIndex, ref nParam);
        }
        /// <summary>
        /// 设置int型cfg
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="nIndex"></param>
        /// <param name="nParam"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerSetCfgParamInt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerSetCfgParamInt(E3_POINTER idMarker, int nIndex, int nParam);
        public static E3_ERR E3_MarkerSetCfgParamInt(E3_ID idMarker, int nIndex, int nParam)
        {
            return e3_MarkerSetCfgParamInt(idMarker, nIndex, nParam);
        }
        /// <summary>
        /// 得到double型cfg
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="nIndex"></param>
        /// <param name="nParam"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetCfgParamDouble", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetCfgParamDouble(E3_POINTER idMarker, int nIndex, ref double nParam);
        public static E3_ERR E3_MarkerGetCfgParamDouble(E3_ID idMarker, int nIndex, ref double nParam)
        {
            return e3_MarkerGetCfgParamDouble(idMarker, nIndex, ref nParam);
        }
        /// <summary>
        /// 设置double型cfg参数
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="nIndex"></param>
        /// <param name="nParam"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerSetCfgParamDouble", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerSetCfgParamDouble(E3_POINTER idMarker, int nIndex, double nParam);
        public static E3_ERR E3_MarkerSetCfgParamDouble(E3_ID idMarker, int nIndex, double nParam)
        {
            return e3_MarkerSetCfgParamDouble(idMarker, nIndex, nParam);
        }

        /// <summary>
        /// 设置语言文件
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetLanguageFile", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_SetLanguageFile(string strFile);
        #endregion 

        #region 图层
        //得到指定数据管理器中的图层数和当前层ID
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetLayerCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetLayerCount(E3_POINTER idEM, ref int nLayerCount, ref int nCurLayerIndex);
        public static E3_ERR E3_GetLayerCount(E3_ID idEM, ref int nLayerCount, ref int nCurLayerIndex)
        {
            return e3_GetLayerCount(idEM, ref nLayerCount, ref nCurLayerIndex);
        }

        //得到对象管理器中指定序号的图层ID
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetLayerId", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetLayerId(E3_POINTER idEM, int nLayerIndex, ref E3_POINTER idLayer);
        public static E3_ERR E3_GetLayerId(E3_ID idEM, int nLayerIndex, ref E3_ID idLayer)
        {
            E3_POINTER id = idLayer;
            E3_ERR err = e3_GetLayerId(idEM, nLayerIndex, ref id);
            idLayer = id;
            return err;
        }
        /// <summary>
        /// 删除层
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nLayerIndex"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_DeleteLayer", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_DeleteLayer(E3_POINTER idEM, int nLayerIndex, bool bUndo, string strUndoName);
        public static E3_ERR E3_DeleteLayer(E3_ID idEM, int nLayerIndex, bool bUndo, string strUndoName)
        {
            return e3_DeleteLayer(idEM, nLayerIndex, bUndo, strUndoName);
        }

        /// <summary>
        /// 设置当前层
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nLayerIndex"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetCurLayer", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetCurLayer(E3_POINTER idEM, int nLayerIndex);
        public static E3_ERR E3_SetCurLayer(E3_ID idEM, int nLayerIndex)
        {
            return e3_SetCurLayer(idEM, nLayerIndex);
        }
        /// <summary>
        /// 添加图层
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_AddLayer", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_AddLayer(E3_POINTER idEM, bool bUndo, string strUndoName);
        public static E3_ERR E3_AddLayer(E3_ID idEM, bool bUndo, string strUndoName)
        {
            return e3_AddLayer(idEM, bUndo, strUndoName);
        }

        /// <summary>
        /// 得到指定图层对象数
        /// </summary>
        /// <param name="idLayer"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetEntCountInLayer", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntCountInLayer(E3_POINTER idLayer, ref int nCount);
        public static E3_ERR E3_GetEntCountInLayer(E3_ID idLayer, ref int nCount)
        {
            return e3_GetEntCountInLayer(idLayer, ref nCount);
        }
        /// <summary>
        /// 得到指定图层指定索引的对象id
        /// </summary>
        /// <param name="idLayer"></param>
        /// <param name="nEntIndex"></param>
        /// <param name="idEnt"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_FindEntInLayerByIndex", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_FindEntInLayerByIndex(E3_POINTER idLayer, int nEntIndex, ref E3_POINTER idEnt);
        public static E3_ERR E3_FindEntInLayerByIndex(E3_ID idLayer, int nEntIndex, ref E3_ID idEnt)
        {
            E3_POINTER id = idLayer;
            E3_ERR err = e3_FindEntInLayerByIndex(idLayer, nEntIndex, ref id);
            idEnt = id;
            return err;
        }

        /// <summary>
        /// 得到指定图层指定对象名称的id
        /// </summary>
        /// <param name="idLayer"></param>
        /// <param name="strEntName"></param>
        /// <param name="idEnt"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_FindEntInLayerByName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_FindEntInLayerByName(E3_POINTER idLayer, string strEntName, ref E3_POINTER idEnt);
        public static E3_ERR E3_FindEntInLayerByName(E3_ID idLayer, string strEntName, ref E3_ID idEnt)
        {
            E3_POINTER id = idLayer;
            E3_ERR err = e3_FindEntInLayerByName(idLayer, strEntName, ref id);  //此接口异常，模板中无指定对象名，获取ID返回成功
            idEnt = id;
            return err;
        }
        #endregion
        #region 添加对象
        //idEntMgr可以为空，如果不为空会自动刷新对象信息表
        //bToHead=TRUE表示dEntNew添加到idEntNewParent子对象尾
        //bToHead=FALSE表示dEntNew添加到idEntNewParent子对象头
        //int E3_AddEntityToChild(E3_ID idEntMgr, E3_ID idEntNew, E3_ID idEntNewParent, BOOL bToHead)
        [DllImport("Ezcad3kernel", EntryPoint = "E3_AddEntityToChild", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_AddEntityToChild(E3_POINTER idEntMgr, E3_POINTER idEntNew, E3_POINTER idEntNewParent, bool bToHead);
        public static E3_ERR E3_AddEntityToChild(E3_ID idEntMgr, E3_ID idEntNew, E3_ID idEntNewParent, bool bToHead)
        {
            return e3_AddEntityToChild(idEntMgr, idEntNew, idEntNewParent, bToHead);
        }
        /// <summary>
        /// 添加点
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="ptLines"></param>
        /// <param name="nPointCount"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreatePoints", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreatePoints(E3_POINTER idEM, int nPen, Pt2d[] ptLines, int nPointCount, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreatePoints(E3_ID idEM, int nPen, Pt2d[] ptLines, int nPointCount, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreatePoints(idEM, nPen, ptLines, nPointCount, bPick, bUndo, strUndoName);
        }


        /// <summary>
        /// 添加多段线，可以设置创建曲线,但是不更新对象列表信息,最后更新,避免大量创建时由于更新对象列表导致的卡顿
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="ptLines"></param>
        /// <param name="nPointCount"></param>
        /// <param name="bUpdateParentInfo"></param>
        /// <param name="idEnt"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateLines_2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateLines_2(E3_POINTER idEM, int nPen, Pt2d[] ptLines, int nPointCount, bool bUpdateParentInfo, ref E3_POINTER idEnt);
        public static E3_ERR E3_CreateLines_2(E3_ID idEM, int nPen, Pt2d[] ptLines, int nPointCount, bool bUpdateParentInfo, ref E3_ID idEnt)
        {
            E3_POINTER id = idEM;
            E3_ERR err = e3_CreateLines_2(idEM, nPen, ptLines, nPointCount, bUpdateParentInfo, ref id);
            idEnt = id;
            return err;
        }
        /// <summary>
        /// 添加线段
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="ptLines"></param>
        /// <param name="nPointCount"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateLines", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateLines(E3_POINTER idEM, int nPen, Pt2d[] ptLines, int nPointCount, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreateLines(E3_ID idEM, int nPen, Pt2d[] ptLines, int nPointCount, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreateLines(idEM, nPen, ptLines, nPointCount, bPick, bUndo, strUndoName);
        }
        /// <summary>
        /// 添加矩形
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateRect", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateRect(E3_POINTER idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreateRect(E3_ID idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreateRect(idEM, nPen, pt1, pt2, bPick, bUndo, strUndoName);
        }

        /// <summary>
        /// 添加圆
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateCircle", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateCircle(E3_POINTER idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreateCircle(E3_ID idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreateCircle(idEM, nPen, pt1, pt2, bPick, bUndo, strUndoName);
        }


        /// <summary>
        /// 添加螺旋线
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateSpiral", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateSpiral(E3_POINTER idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreateSpiral(E3_ID idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreateSpiral(idEM, nPen, pt1, pt2, bPick, bUndo, strUndoName);
        }
        /// <summary>
        /// 添加椭圆
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateEllipse", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateEllipse(E3_POINTER idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreateEllipse(E3_ID idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreateEllipse(idEM, nPen, pt1, pt2, bPick, bUndo, strUndoName);
        }
        //添加多边型
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreatePolygon", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreatePolygon(E3_POINTER idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreatePolygon(E3_ID idEM, int nPen, Pt2d pt1, Pt2d pt2, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreatePolygon(idEM, nPen, pt1, pt2, bPick, bUndo, strUndoName);
        }

        //添加矢量文件到对象管理器
        [DllImport("Ezcad3kernel", EntryPoint = "E3_ImportFileToEntMgr", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_ImportFileToEntMgr(string pStrFileName, E3_POINTER idEM, bool bUndo, string strUndoName);
        public static E3_ERR E3_ImportFileToEntMgr(string pStrFileName, E3_ID idEM, bool bUndo, string strUndoName)
        {
            return e3_ImportFileToEntMgr(pStrFileName, idEM, bUndo, strUndoName);
        }
        public const int BMPSCAN_INVERT = 0x0001;//图像反转
        public const int BMPSCAN_GRAY = 0x0002;//图像灰度
        public const int BMPSCAN_LIGHT = 0x0004;//图像亮度
        public const int BMPSCAN_DITHER = 0x0010;//网点处理

        public const int BMPSCAN_BIDIR = 0x1000;//双向扫描
        public const int BMPSCAN_YDIR = 0x2000;//Y向扫描
        public const int BMPSCAN_DRILL = 0x4000;//打点模式
        public const int BMPSCAN_POWER = 0x8000;//调整功率


        public const int BMPATTRIB_DYNFILE = 0x1000;//动态文件
        public const int BMPATTRIB_IMPORTFIXED_WIDTH = 0x2000;//固定文件输入宽 
        public const int BMPATTRIB_IMPORTFIXED_HEIGHT = 0x4000;//固定文件输入高
        public const int BMPATTRIB_IMPORTFIXED_DPI = 0x8000;//固定DPI
        public const int BMPSCAN_OFFSETPT = 0x0100;//隔行错位
        public const int BMPSCAN_OPTIMIZE = 0x0200;//优化模式
        public const int MAX_DPI = 4000;//最高DPI
        public const int MIN_DPI = 10;//最低DPI
        public const int MAX_GRAYCURVEPT_NUM = 20;//功率曲线节点数量    
        /// <summary>
        /// 添加位图
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="strBmpFile"></param>
        /// <param name="nBmpAttrib"></param>
        /// <param name="nScanAttrib"></param>
        /// <param name="ptBase"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateBitmap", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateBitmap(E3_POINTER idEM, int nPen, string strBmpFile, int nBmpAttrib, int nScanAttrib, Pt2d ptBase, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreateBitmap(E3_ID idEM, int nPen, string strBmpFile, int nBmpAttrib, int nScanAttrib, Pt2d ptBase, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreateBitmap(idEM, nPen, strBmpFile, nBmpAttrib, nScanAttrib, ptBase, bPick, bUndo, strUndoName);
        }
        /// <summary>
        /// 添加控制器
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="nControlType"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndoName"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateControl", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateControl(E3_POINTER idEM, int nPen, int nControlType, bool bPick, bool bUndo, string strUndoName);
        public static E3_ERR E3_CreateControl(E3_ID idEM, int nPen, int nControlType, bool bPick, bool bUndo, string strUndoName)
        {
            return e3_CreateControl(idEM, nPen, nControlType, bPick, bUndo, strUndoName);
        }
        /// <summary>
        /// 添加文本条码
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="nPen"></param>
        /// <param name="ptBase"></param>
        /// <param name="str"></param>
        /// <param name="nFontId"></param>
        /// <param name="dTextHeight"></param>
        /// <param name="dTextWidthRatio"></param>
        /// <param name="nTextSpaceType"></param>
        /// <param name="dTextSpace"></param>
        /// <param name="dTextAngle"></param>
        /// <param name="nAlignType"></param>
        /// <param name="dNullCharWidthRatio"></param>
        /// <param name="dLineSpace"></param>
        /// <param name="bVerText"></param>
        /// <param name="bBold"></param>
        /// <param name="bItalic"></param>
        /// <param name="bPick"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateText", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateText(E3_POINTER idEM, int nPen, Pt2d ptBase, string str, int nFontId, double dTextHeight, double dTextWidthRatio, int nTextSpaceType, double dTextSpace, double dTextAngle,
         int nAlignType, double dNullCharWidthRatio, double dLineSpace, bool bVerText, bool bBold, bool bItalic, bool bPick, bool bUndo, string strUndo);
        public static E3_ERR E3_CreateText(E3_ID idEM, int nPen, Pt2d ptBase, string str, int nFontId, double dTextHeight, double dTextWidthRatio, int nTextSpaceType, double dTextSpace, double dTextAngle,
      int nAlignType, double dNullCharWidthRatio, double dLineSpace, bool bVerText, bool bBold, bool bItalic, bool bPick, bool bUndo, string strUndo)
        {
            return e3_CreateText(idEM, nPen, ptBase, str, nFontId, dTextHeight, dTextWidthRatio, nTextSpaceType, dTextSpace, dTextAngle,
          nAlignType, dNullCharWidthRatio, dLineSpace, bVerText, bBold, bItalic, bPick, bUndo, strUndo);
        }
        /// <summary>
        /// 删除指定对象
        /// </summary>
        /// <param name="idEnt"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_DeleteEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_DeleteEnt(E3_POINTER idEnt);
        public static E3_ERR E3_DeleteEnt(E3_ID idEnt)
        {
            return e3_DeleteEnt(idEnt);
        }

        /// <summary>
        /// 删除一个集合ID下的所有对象，例如一个图层内的所有子对象
        /// </summary>
        /// <param name="idEnt"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_DeleteAllChildOfEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_DeleteAllChildOfEnt(E3_POINTER idEnt);
        public static E3_ERR E3_DeleteAllChildOfEnt(E3_ID idEnt)
        {
            return e3_DeleteAllChildOfEnt(idEnt);
        }

        #endregion

        #region 对象操作
        /// <summary>
        /// 得到最新的子对象头对象ID.
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="idEntChild1"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetEntParam1", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntParam1(E3_POINTER idEnt, ref E3_POINTER idEntChild1);
        public static E3_ERR E3_GetEntParam1(E3_ID idEnt, ref E3_ID idEntChild1)
        {

            E3_POINTER id = 0;
            E3_ERR err = e3_GetEntParam1(idEnt, ref id);
            idEntChild1 = id;
            return err;
        }
        /// <summary>
        ///得到对象的下一个兄弟ID.
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="idEntChild2"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetEntParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntParam2(E3_POINTER idEnt, ref E3_POINTER idEntChild2);
        public static E3_ERR E3_GetEntParam2(E3_ID idEnt, ref E3_ID idEntChild2)
        {

            E3_POINTER id = 0;
            E3_ERR err = e3_GetEntParam2(idEnt, ref id);
            idEntChild2 = id;
            return err;
        }
        /// <summary>
        /// 得到对象基础信息
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="nType"></param>
        /// <param name="nPen"></param>
        /// <param name="sbName"></param>
        /// <param name="box"></param>
        /// <param name="dz"></param>
        /// <param name="da"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetEntBaseInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntBaseInfo(E3_POINTER idEnt, ref int nType, ref int nPen, StringBuilder sbName, ref Box2d box, ref double dz, ref double da);
        public static E3_ERR E3_GetEntBaseInfo(E3_ID idEnt, ref int nType, ref int nPen, StringBuilder sbName, ref Box2d box, ref double dz, ref double da)
        {
            return e3_GetEntBaseInfo(idEnt, ref nType, ref nPen, sbName, ref box, ref dz, ref da);
        }
        /// <summary>
        ///  得到指定对象的参数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="nFlag"></param>
        /// <param name="np1"></param>
        /// <param name="np2"></param>
        /// <param name="np3"></param>
        /// <param name="np4"></param>
        /// <param name="np5"></param>
        /// <param name="np6"></param>
        /// <param name="dp1"></param>
        /// <param name="dp2"></param>
        /// <param name="dp3"></param>
        /// <param name="dp4"></param>
        /// <param name="dp5"></param>
        /// <param name="dp6"></param>
        /// <param name="str1"></param>
        /// <param name="pParam1"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetEntInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntInfo(E3_POINTER idEnt, int nFlag, ref int np1, ref int np2, ref int np3, ref int np4, ref int np5, ref int np6,
    ref double dp1, ref double dp2, ref double dp3, ref double dp4, ref double dp5, ref double dp6, StringBuilder str1, byte[] pParam1);


        public static E3_ERR E3_GetEntInfo(E3_ID idEnt, ref int np1, ref int np2, ref int np3, ref int np4, ref int np5, ref int np6,
    ref double dp1, ref double dp2, ref double dp3, ref double dp4, ref double dp5, ref double dp6, StringBuilder str1, byte[] pParam1)
        {

            E3_ERR err = e3_GetEntInfo(idEnt, 0, ref np1, ref np2, ref np3, ref np4, ref np5, ref np6, ref dp1, ref dp2, ref dp3, ref dp4, ref dp5, ref dp6, str1, pParam1);
            return err;
        }
        /// <summary>
        /// 获取矩形对象参数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="nCornerLT"></param>
        /// <param name="nCornerRT"></param>
        /// <param name="nCornerLB"></param>
        /// <param name="nCornerRB"></param>
        /// <returns></returns>
        public static E3_ERR E3_GetEntRectInfo(E3_ID idEnt, ref int nCornerLT, ref int nCornerRT, ref int nCornerLB, ref int nCornerRB)
        {
            int np1 = 0;
            int np2 = 0;
            int np3 = 0;
            int np4 = 0;
            int np5 = 0;
            int np6 = 0;
            double dp1 = 0;
            double dp2 = 0;
            double dp3 = 0;
            double dp4 = 0;
            double dp5 = 0;
            double dp6 = 0;

            E3_ERR err = E3_GetEntInfo(idEnt, ref np1, ref np2, ref np3, ref np4, ref np5, ref np6, ref dp1, ref dp2, ref dp3, ref dp4, ref dp5, ref dp6, null, null);
            nCornerLB = (int)dp1;
            nCornerRB = (int)dp2;
            nCornerRT = (int)dp3;
            nCornerLT = (int)dp4;
            return err;
        }


        /// <summary>
        /// 获取圆对象参数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="dDiameter"></param>
        /// <param name="dStartAng"></param>
        /// <param name="bDirCW"></param>
        /// <returns></returns>
        public static E3_ERR E3_GetEntCircleInfo(E3_ID idEnt, ref double dDiameter, ref double dStartAng, ref bool bDirCW)
        {
            int np1 = 0;
            int np2 = 0;
            int np3 = 0;
            int np4 = 0;
            int np5 = 0;
            int np6 = 0;
            double dp1 = 0;
            double dp2 = 0;
            double dp3 = 0;
            double dp4 = 0;
            double dp5 = 0;
            double dp6 = 0;

            E3_ERR err = E3_GetEntInfo(idEnt, ref np1, ref np2, ref np3, ref np4, ref np5, ref np6, ref dp1, ref dp2, ref dp3, ref dp4, ref dp5, ref dp6, null, null);
            dDiameter = dp1 * 2;
            dStartAng = (180 / Math.PI) * dp2;
            bDirCW = np1 == 0 ? false : true;
            return err;
        }


        /// <summary>
        /// 获取螺旋线对象参数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="nSpiralMode"></param>
        /// <param name="bInsideToOutside"></param>
        /// <param name="nOutsideLoop"></param>
        /// <param name="nInsideLoop"></param>
        /// <param name="dSpiralPitchDistMin"></param>
        /// <param name="dSpiralPitchDistMax"></param>
        /// <param name="dSpiralPitchDistInc"></param>
        /// <param name="dMinRadius"></param>
        /// <param name="dTolError"></param>
        /// <returns></returns>
        public static E3_ERR E3_GetEntSpiralInfo(E3_ID idEnt, ref int nSpiralMode, ref int bInsideToOutside, ref int nOutsideLoop, ref int nInsideLoop, ref double dSpiralPitchDistMin, ref double dSpiralPitchDistMax, ref double dSpiralPitchDistInc, ref double dMinRadius, ref double dTolError)
        {
            int np1 = 0;
            int np2 = 0;
            int np3 = 0;
            int np4 = 0;
            int np5 = 0;
            int np6 = 0;
            double dp1 = 0;
            double dp2 = 0;
            double dp3 = 0;
            double dp4 = 0;
            double dp5 = 0;
            double dp6 = 0;


            E3_ERR err = E3_GetEntInfo(idEnt, ref np1, ref np2, ref np3, ref np4, ref np5, ref np6, ref dp1, ref dp2, ref dp3, ref dp4, ref dp5, ref dp6, null, null);
            nSpiralMode = np1;//填充属性 0=等间距  1=外疏内密  2=外密内疏  
            bInsideToOutside = np2;
            nOutsideLoop = np3;//外环数
            nInsideLoop = np4;//内环数 

            dSpiralPitchDistMin = dp1;//最小螺旋线间距
            dSpiralPitchDistMax = dp2;//最大螺旋线间距
            dSpiralPitchDistInc = dp3;//螺旋线间距增量 
            dMinRadius = dp4;
            dTolError = dp5;
            return err;
        }

        /// <summary>
        /// 获取椭圆对象参数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="dStartAng"></param>
        /// <param name="dEndAng"></param>
        /// <param name="bDirCW"></param>
        /// <returns></returns>
        public static E3_ERR E3_GetEntEllipseInfo(E3_ID idEnt, ref double dStartAng, ref double dEndAng, ref bool bDirCW)
        {
            int np1 = 0;
            int np2 = 0;
            int np3 = 0;
            int np4 = 0;
            int np5 = 0;
            int np6 = 0;
            double dp1 = 0;
            double dp2 = 0;
            double dp3 = 0;
            double dp4 = 0;
            double dp5 = 0;
            double dp6 = 0;

            E3_ERR err = E3_GetEntInfo(idEnt, ref np1, ref np2, ref np3, ref np4, ref np5, ref np6, ref dp1, ref dp2, ref dp3, ref dp4, ref dp5, ref dp6, null, null);
            dStartAng = (180 / Math.PI) * dp1;
            dEndAng = (180 / Math.PI) * dp2;
            bDirCW = np1 == 0 ? false : true;
            return err;
        }

        /// <summary>
        /// 获取多边形对象参数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="nEdge"></param>
        /// <param name="bStar"></param>
        /// <returns></returns>
        public static E3_ERR E3_GetEntPolygonInfo(E3_ID idEnt, ref int nEdge, ref bool bStar)
        {
            int np1 = 0;
            int np2 = 0;
            int np3 = 0;
            int np4 = 0;
            int np5 = 0;
            int np6 = 0;
            double dp1 = 0;
            double dp2 = 0;
            double dp3 = 0;
            double dp4 = 0;
            double dp5 = 0;
            double dp6 = 0;

            E3_ERR err = E3_GetEntInfo(idEnt, ref np1, ref np2, ref np3, ref np4, ref np5, ref np6, ref dp1, ref dp2, ref dp3, ref dp4, ref dp5, ref dp6, null, null);
            nEdge = np2;
            bStar = np1 == 0 ? false : true;
            return err;
        }

        /// <summary>
        /// 设置对象参数
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="nFlag"></param>
        /// <param name="np1"></param>
        /// <param name="np2"></param>
        /// <param name="np3"></param>
        /// <param name="np4"></param>
        /// <param name="np5"></param>
        /// <param name="np6"></param>
        /// <param name="dp1"></param>
        /// <param name="dp2"></param>
        /// <param name="dp3"></param>
        /// <param name="dp4"></param>
        /// <param name="dp5"></param>
        /// <param name="dp6"></param>
        /// <param name="str1"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetEntInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetEntInfo(E3_POINTER idEM, E3_POINTER idEnt, int nFlag, int np1, int np2, int np3, int np4, int np5, int np6,
           double dp1, double dp2, double dp3, double dp4, double dp5, double dp6, string str1, bool bUndo, string strUndo);

        public static E3_ERR E3_SetEntInfo(E3_ID idEM, E3_ID idEnt, int np1, int np2, int np3, int np4, int np5, int np6,
   double dp1, double dp2, double dp3, double dp4, double dp5, double dp6, string str1, bool bUndo, string strUndo)
        {
            E3_ERR err = e3_SetEntInfo(idEM, idEnt, 0, np1, np2, np3, np4, np5, np6, dp1, dp2, dp3, dp4, dp5, dp6, str1, bUndo, strUndo);
            return err;
        }
        /// <summary>
        /// 设置矩形参数
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="nCornerLT"></param>
        /// <param name="nCornerRT"></param>
        /// <param name="nCornerLB"></param>
        /// <param name="nCornerRB"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        public static E3_ERR E3_SetEntRectInfo(E3_ID idEM, E3_ID idEnt, int nCornerLT, int nCornerRT, int nCornerLB, int nCornerRB, bool bUndo, string strUndo)
        {
            E3_ERR err = E3_SetEntInfo(idEM, idEnt, 0, 0, 0, 0, 0, 0, (double)nCornerLB, (double)nCornerRB, (double)nCornerRT, (double)nCornerLT, 0.0, 0.0, "", bUndo, strUndo);
            return err;
        }
        /// <summary>
        /// 设置圆参数
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="dRadius"></param>
        /// <param name="dStartAng"></param>
        /// <param name="bDirCW"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        public static E3_ERR E3_SetEntCircleInfo(E3_ID idEM, E3_ID idEnt, double dRadius, double dStartAng, bool bDirCW, bool bUndo, string strUndo)
        {
            E3_ERR err = E3_SetEntInfo(idEM, idEnt, bDirCW ? 1 : 0, 0, 0, 0, 0, 0, dRadius, dStartAng, 0, 0, 0.0, 0.0, "", bUndo, strUndo);
            return err;
        }
        /// <summary>
        /// 设置螺旋线
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="nSpiralMode"></param>
        /// <param name="bInsideToOutside"></param>
        /// <param name="nOutsideLoop"></param>
        /// <param name="nInsideLoop"></param>
        /// <param name="dSpiralPitchDistMin"></param>
        /// <param name="dSpiralPitchDistMax"></param>
        /// <param name="dSpiralPitchDistInc"></param>
        /// <param name="dMinRadius"></param>
        /// <param name="dTolError"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        public static E3_ERR E3_SetEntSpiralInfo(E3_ID idEM, E3_ID idEnt, int nSpiralMode, int bInsideToOutside, int nOutsideLoop, int nInsideLoop,
            double dSpiralPitchDistMin, double dSpiralPitchDistMax, double dSpiralPitchDistInc, double dMinRadius, double dTolError, bool bUndo, string strUndo)
        {
            E3_ERR err = E3_SetEntInfo(idEM, idEnt, nSpiralMode, bInsideToOutside, nOutsideLoop, nInsideLoop, 0, 0, dSpiralPitchDistMin, dSpiralPitchDistMax, dSpiralPitchDistInc, dMinRadius, dTolError, 0.0, "", bUndo, strUndo);
            return err;
        }

        /// <summary>
        /// 设置椭圆参数
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="dStartAng"></param>
        /// <param name="dEndAng"></param>
        /// <param name="bDirCW"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        public static E3_ERR E3_SetEntEllipseInfo(E3_ID idEM, E3_ID idEnt, double dStartAng, double dEndAng, bool bDirCW, bool bUndo, string strUndo)
        {
            E3_ERR err = E3_SetEntInfo(idEM, idEnt, bDirCW ? 1 : 0, 0, 0, 0, 0, 0, dStartAng, dEndAng, 0, 0, 0.0, 0.0, "", bUndo, strUndo);
            return err;
        }
        /// <summary>
        /// 设置六边形参数
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="nEdge"></param>
        /// <param name="bStar"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        public static E3_ERR E3_SetEntPolygonInfo(E3_ID idEM, E3_ID idEnt, int nEdge, bool bStar, bool bUndo, string strUndo)
        {
            E3_ERR err = E3_SetEntInfo(idEM, idEnt, bStar ? 1 : 0, nEdge, 0, 0, 0, 0, 0, 0, 0, 0, 0.0, 0.0, "", bUndo, strUndo);
            return err;
        }
        //E3_API int E3_SetEntityA(E3_ID idEnt, double a, BOOL bChangeAllChildA);
        /// <summary>
        /// ,设置对象的A值（层ID，则bChangeAllChildA必须为true才可设置该层所有对象A值，若是对象ID,bChangeAllChildA此值设置为true/false均可）
        /// </summary>
        /// <param name="idEnt">层或对象ID</param>
        /// <param name="a"></param>
        /// <param name="bChangeAllChildA"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetEntityA", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetEntityA(E3_POINTER idEnt, double a, bool bChangeAllChildA);
        public static E3_ERR E3_SetEntityA(E3_ID idEnt, double a, bool bChangeAllChildA)
        {
            return e3_SetEntityA(idEnt, a, bChangeAllChildA);
        }
        //int E3_MoveEntZ(E3_ID idEnt, double dMoveZ)
        //移动Z 
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MoveEntZ", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MoveEntZ(E3_POINTER idEnt, double dMoveZ);
        public static E3_ERR E3_MoveEntZ(E3_ID idEnt, double dMoveZ)
        {
            return e3_MoveEntZ(idEnt, dMoveZ);

        }
        //获取对象名称
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetEntityName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntityName(E3_POINTER idEnt, StringBuilder strEntName);
        public static E3_ERR E3_GetEntityName(E3_ID idEnt, StringBuilder strEntName)
        {
            return e3_GetEntityName(idEnt, strEntName);
        }

        //设置对象名称
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetEntityName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetEntityName(E3_POINTER idEnt, string strEntName);
        public static E3_ERR E3_SetEntityName(E3_ID idEnt, string strEntName)
        {
            return e3_SetEntityName(idEnt, strEntName);
        }
        //得到指定对象ID的文本内容
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetTextByID", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetTextByID(E3_POINTER idEnt, ref StringBuilder strEntName);
        public static E3_ERR E3_GetTextByID(E3_ID idEnt, ref StringBuilder strEntName)
        {
            return e3_GetTextByID(idEnt, ref strEntName);
        }

        //更改当前数据库里的指定文本对象的文本
        //输入参数: strTextName     要更改内容的文本对象的名称
        //          strTextNew      新的文本内容 
        [DllImport("Ezcad3kernel", EntryPoint = "E3_ChangeTextByName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_ChangeTextByName(E3_POINTER idLayer, string strTextName, string strTextNew);
        public static E3_ERR E3_ChangeTextByName(E3_ID idLayer, string strTextName, string strTextNew)
        {
            return e3_ChangeTextByName(idLayer, strTextName, strTextNew);
        }


        //更改当前数据库里的指定文本对象的文本
        //输入参数:  strTextNew      新的文本内容 
        [DllImport("Ezcad3kernel", EntryPoint = "E3_ChangeTextById", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_ChangeTextById(E3_POINTER idEnt, string strTextNew);
        public static E3_ERR E3_ChangeTextById(E3_ID idEnt, string strTextNew)
        {
            return e3_ChangeTextById(idEnt, strTextNew);
        }
        //得到对象的尺寸
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetEntityRange", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntityRange(E3_POINTER idEnt, ref double dMinx, ref double dMiny, ref double dMaxx, ref double dMaxy, ref bool bIsEmpty);
        public static E3_ERR E3_GetEntityRange(E3_ID idEnt, ref double dMinx, ref double dMiny, ref double dMaxx, ref double dMaxy, ref bool bIsEmpty)
        {
            return e3_GetEntityRange(idEnt, ref dMinx, ref dMiny, ref dMaxx, ref dMaxy, ref bIsEmpty);
        }
        //造形
        //nMode=0 焊接对象 求idEnt1和idEnt2焊接区域
        //nMode=1 修剪对象 idEnt1为边界去修剪idEnt2
        //nMode=2 交叉对象 求idEnt1和idEnt2的交叉区域
        //E3_API int E3_DistortionEntity(E3_ID idEM, E3_ID idEnt1, E3_ID idEnt2, int nMode, int nPen, BOOL bUndo, TCHAR* strUndoName);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_DistortionEntity", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern int e3_DistortionEntity(E3_POINTER idEM, E3_POINTER idEnt1, E3_POINTER idEnt2, int nMode, int nPen, bool bUndo, string strUndoName);
        public static int E3_DistortionEntity(E3_ID idEM, E3_ID idEnt1, E3_ID idEnt2, int nMode, int nPen, bool bUndo, string strUndoName)
        {
            return e3_DistortionEntity(idEM, idEnt1, idEnt2, nMode, nPen, bUndo, strUndoName);
        }

        //设置所有对象的先绕旋转中心旋转指定角度，然后平移指定距离
        //输入参数: dMoveX   为x平移的距离
        //          dMoveY   为y平移的距离
        //          dCenterX 旋转中心x坐标 
        //          dCenterY 旋转中心y坐标 
        //          dRotateAng 旋转角度(弧度值), 
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerSetRotateMoveParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerSetRotateMoveParam(E3_POINTER idMarker, double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng);
        public static E3_ERR E3_MarkerSetRotateMoveParam(E3_ID idMarker, double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng)
        {
            return e3_MarkerSetRotateMoveParam(idMarker, dMoveX, dMoveY, dCenterX, dCenterY, dRotateAng);
        }
        //移动指定对象
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MoveRotateEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MoveRotateEnt(E3_POINTER idEnt, double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng);
        public static E3_ERR E3_MoveRotateEnt(E3_ID idEnt, double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng)
        {
            return e3_MoveRotateEnt(idEnt, dMoveX, dMoveY, dCenterX, dCenterY, dRotateAng);
        }
        //拉伸指定对象
        [DllImport("Ezcad3kernel", EntryPoint = "E3_ScaleEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_ScaleEnt(E3_POINTER idEnt, double dCenx, double dCeny, double dScaleX, double dScaleY);
        public static E3_ERR E3_ScaleEnt(E3_ID idEnt, double dCenx, double dCeny, double dScaleX, double dScaleY)
        {
            return e3_ScaleEnt(idEnt, dCenx, dCeny, dScaleX, dScaleY);
        }
        /// <summary>
        /// 组合一组对象
        /// </summary>
        //E3_API int E3_GroupEnt(E3_ID* idEnts, int nEntCount, E3_ID&  idEntGroup);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GroupEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GroupEnt(E3_POINTER[] idEnts, int nEntCount, ref E3_POINTER idEntGroup);
        public static E3_ERR E3_GroupEnt(E3_ID[] idEnts, int nEntCount, ref E3_ID idEntGroup)
        {
            E3_POINTER id = 0;
            E3_POINTER[] idList = new E3_POINTER[idEnts.Length];
            for (int i = 0; i < idEnts.Length; i++)
            {
                idList[i] = idEnts[i];
            }
            E3_ERR err = e3_GroupEnt(idList, nEntCount, ref id);
            idEntGroup = id;
            return err;
        }

        /// <summary>
        /// 解散群组（解散到曲线后再调用此接口时返回值为2）
        /// </summary>
        //E3_API int E3_GroupEnt(E3_ID* idEnts, int nEntCount, E3_ID&  idEntGroup);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_UnGroupEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_UnGroupEnt(E3_POINTER idEnt);
        public static E3_ERR E3_UnGroupEnt(E3_ID idEnt)
        {
            return e3_UnGroupEnt(idEnt);
        }
        /// <summary>
        /// 设置图像参数.
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="nParamBuf"></param>
        /// <param name="dParamBuf"></param>
        /// <param name="bGrayScaleBuf"></param>
        /// <param name="str1"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetBmpFileInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR E3_SetBmpFileInfo(E3_POINTER idEM, E3_POINTER idEnt, int[] nParamBuf, double[] dParamBuf, byte[] bGrayScaleBuf, string str1, bool bUndo, string strUndo);


        /// <summary>
        /// 设置位图对象参数
        /// </summary>
        /// <param name="idEM">对象管理器</param>
        /// <param name="idEnt">对象ID</param>
        /// <param name="strFileName">位图文件</param>
        /// <param name="bBidir">双向扫描</param>
        /// <param name="dBiDirOffset">双向扫描补偿</param>
        /// <param name="bDrillmode">打点模式</param>
        /// <param name="dDrillTime">打点模式单点最大时间</param>
        /// <param name="bScanY">Y向扫描</param>
        /// <param name="bPixelPower">调整点功率</param>
        /// <param name="bFixedDPI">固定DPI</param>
        /// <param name="nDpiX">XDPI</param>
        /// <param name="nDpiY">YDPI</param>
        /// <param name="bDynFile">动态文件</param>
        /// <param name="bFixedX">固定X尺寸</param>
        /// <param name="bFixedY">固定Y尺寸</param>
        /// <param name="dSizeX">X尺寸</param>
        /// <param name="dSizeY">Y尺寸</param>
        /// <param name="nFixedPosition">固定参考点序号</param>
        /// <param name="bGray">灰度处理</param>
        /// <param name="bInvert">反转处理</param>
        /// <param name="bDither">网点处理</param>
        /// <param name="bOptimize">优化模式</param>
        /// <param name="bLineOffset">隔行错位</param>
        /// <param name="bLineIncrement">位图扫描增量模式1TRUE 0FALSE</param>
        /// <param name="nLineIncrement">位图扫描增量值</param>
        /// <param name="nMinLowGrayPt">阈值灰度</param>
        /// <param name="bDisableMarkLowGrayPt">低于阈值灰度数据不加工</param>
        /// <param name="dAccDist">加速距离</param>
        /// <param name="dDecDist">减速距离</param>
        /// <param name="nGrayCurvePt">灰度功率曲线节点数</param>
        /// <param name="ptGrayCurveBuf">灰度功率曲线列表</param>
        /// <param name="bGrayScaleBuf">灰度功率表</param>
        /// <param name="bUndo">是否支持复位 false</param>
        /// <param name="strUndo">操作名称 null</param>
        /// <returns></returns>
        public static E3_ERR E3_SetEntBmpFileInfo(E3_ID idEM, EzdKernel.E3_ID idEnt, string strFileName, bool bBidir, double dBiDirOffset, bool bDrillmode, double dDrillTime, bool bScanY, bool bPixelPower, bool bFixedDPI, int nDpiX, int nDpiY,
 bool bDynFile, bool bFixedX, bool bFixedY, double dSizeX, double dSizeY, int nFixedPosition, bool bGray, bool bInvert, bool bDither, bool bOptimize, bool bLineOffset, bool bLineIncrement, int nLineIncrement,
            int nMinLowGrayPt, bool bDisableMarkLowGrayPt, double dAccDist, double dDecDist, int nGrayCurvePt, Point[] ptGrayCurveBuf, byte[] bGrayScaleBuf, bool bUndo, string strUndo)
        {
            int nBmpAttrib = 0;
            if (bDynFile) nBmpAttrib |= BMPATTRIB_DYNFILE;
            if (bFixedX) nBmpAttrib |= BMPATTRIB_IMPORTFIXED_WIDTH;
            if (bFixedY) nBmpAttrib |= BMPATTRIB_IMPORTFIXED_HEIGHT;
            if (bFixedDPI) nBmpAttrib |= BMPATTRIB_IMPORTFIXED_DPI;

            int nScanAttrib = 0;
            if (bInvert) nScanAttrib |= BMPSCAN_INVERT;
            if (bGray) nScanAttrib |= BMPSCAN_GRAY;
            if (bDither) nScanAttrib |= BMPSCAN_DITHER;
            if (bBidir) nScanAttrib |= BMPSCAN_BIDIR;
            if (bDrillmode) nScanAttrib |= BMPSCAN_DRILL;
            if (bPixelPower) nScanAttrib |= BMPSCAN_POWER;
            if (bOptimize) nScanAttrib |= BMPSCAN_OPTIMIZE;
            if (bScanY) nScanAttrib |= BMPSCAN_YDIR;
            if (bLineOffset) nScanAttrib |= BMPSCAN_OFFSETPT;

            int[] nParamBuf = new int[10 + 2 * MAX_GRAYCURVEPT_NUM];
            nParamBuf[0] = nBmpAttrib;
            nParamBuf[1] = nScanAttrib;
            nParamBuf[2] = nFixedPosition;
            nParamBuf[3] = nDpiX;
            nParamBuf[4] = nDpiY;
            nParamBuf[5] = bLineIncrement ? 1 : 0;
            nParamBuf[6] = nLineIncrement;
            nParamBuf[7] = bDisableMarkLowGrayPt ? 1 : 0;
            nParamBuf[8] = nMinLowGrayPt;
            nParamBuf[9] = nGrayCurvePt;
            for (int i = 0; i < MAX_GRAYCURVEPT_NUM; i++)
            {//i=1,x=255,y=255 ,i!=1 ,x=0,y=0
                nParamBuf[10 + i * 2] = ptGrayCurveBuf[i].X;
                nParamBuf[10 + i * 2 + 1] = ptGrayCurveBuf[i].Y;
            }

            double[] dParamBuf = new double[10];
            dParamBuf[0] = dSizeX;
            dParamBuf[1] = dSizeY;
            dParamBuf[2] = dDrillTime;
            dParamBuf[3] = dBiDirOffset;
            dParamBuf[4] = dAccDist;
            dParamBuf[5] = dDecDist;

            E3_ERR err = E3_SetBmpFileInfo(idEM, idEnt, nParamBuf, dParamBuf, bGrayScaleBuf, strFileName, bUndo, strUndo);
            return err;
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <param name="idEnt"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CopyEntity", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_POINTER e3_CopyEntity(E3_POINTER idEnt);
        public static E3_ID E3_CopyEntity(E3_ID idEnt)
        {
            return e3_CopyEntity(idEnt);

        }
        #endregion

        #region 文本对象
        /// <summary>
        /// 获取文本对象的参数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="nMaxParamN"></param>
        /// <param name="nParam"></param>
        /// <param name="nMaxParamD"></param>
        /// <param name="dParam"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetTextInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntTextInfo(E3_POINTER idEnt, int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam);
        public static E3_ERR E3_GetEntTextInfo(E3_ID idEnt, int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam)
        {
            return e3_GetEntTextInfo(idEnt, nMaxParamN, nParam, nMaxParamD, dParam);
        }
        /// <summary>
        /// 设置文本对象的参数
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="nMaxParamN"></param>
        /// <param name="nParam"></param>
        /// <param name="nMaxParamD"></param>
        /// <param name="dParam"></param>
        /// <param name="strText"></param>
        /// <param name="strExtFile"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetEntTextInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetEntTextInfo(E3_POINTER idEM, E3_POINTER idEnt, int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam, StringBuilder strText, StringBuilder strExtFile, bool bUndo, string strUndo);
        public static E3_ERR E3_SetEntTextInfo(E3_ID idEM, E3_ID idEnt, int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam, StringBuilder strText, StringBuilder strExtFile, bool bUndo, string strUndo)
        {
            return e3_SetEntTextInfo(idEM, idEnt, nMaxParamN, nParam, nMaxParamD, dParam, strText, strExtFile, bUndo, strUndo);
        }
        /// <summary>
        /// 获取文本对象中的字符串信息
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="index"></param>
        /// <param name="nMaxCharLen"></param>
        /// <param name="strData"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetTextStringInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetTextStringInfo(E3_POINTER idEnt, int index, int nMaxCharLen, StringBuilder strData);
        public static E3_ERR E3_GetTextStringInfo(E3_ID idEnt, int index, int nMaxCharLen, StringBuilder strData)
        {
            return e3_GetTextStringInfo(idEnt, index, nMaxCharLen, strData);
        }
        #endregion

        #region 条码
        /// <summary>
        /// 验证当前条码内容是否有效
        /// </summary>
        /// <param name="nMaxParamN"></param>
        /// <param name="nParam"></param>
        /// <param name="nMaxParamD"></param>
        /// <param name="dParam"></param>
        /// <param name="strBarcodeFontName"></param>
        /// <param name="strText"></param>
        /// <param name="bValid"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_IsBarcodeTextValid", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public extern static E3_ERR E3_IsBarcodeTextValid(int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam, string strBarcodeFontName, string strText, ref bool bValid);
        /// <summary>
        /// 获取指定文本对象的字体类型，以及是否是条码
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="strFontName"></param>
        /// <param name="bIsbarcode"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetTextFontName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetTextFontName(E3_POINTER idEnt, StringBuilder strFontName, ref bool bIsbarcode);
        public static E3_ERR E3_GetTextFontName(E3_ID idEnt, StringBuilder strFontName, ref bool bIsbarcode)
        {
            return e3_GetTextFontName(idEnt, strFontName, ref bIsbarcode);
        }
        /// <summary>
        /// 查询二维码行列数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="str">条码数据内容</param>
        /// <param name="nSizeMode">条码版本号</param>
        /// <param name="nRow"></param>
        /// <param name="nCol"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetTextBarcodeInfo2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetTextBarcodeInfo2(E3_POINTER idEnt, string str, ref int nSizeMode, ref int nRow, ref int nCol);
        public static E3_ERR E3_GetTextBarcodeInfo2(E3_ID idEnt, string str, ref int nSizeMode, ref int nRow, ref int nCol)
        {
            return e3_GetTextBarcodeInfo2(idEnt, str, ref nSizeMode, ref nRow, ref nCol);
        }
        ///条码参数结构体，包含了条码的所有参数
        public struct BarcodeParam
        {
            public string m_strBarcodeFontName;//文本字体名称

            public Int32 m_bBarcodeType;//条码类型 1 是1维，2是2维条码
            public bool m_bBarcodeCheckNum;
            public bool m_bBarcodeReverse;//条码反转


            public double m_dHeight;//整个条码的高	
            public double m_dNarrowWidth;//最窄模块宽	

            public bool m_bFixedSize;
            public double m_dFixedSizeX;
            public double m_dFixedSizeY;


            //1维码参数
            public double m_dBarWidthScale0;//条宽比例	(与最窄模块宽相比)
            public double m_dBarWidthScale1;
            public double m_dBarWidthScale2;
            public double m_dBarWidthScale3;

            public double m_dSpaceWidthScale0;//空宽比例(与最窄模块宽相比)
            public double m_dSpaceWidthScale1;
            public double m_dSpaceWidthScale2;
            public double m_dSpaceWidthScale3;

            public double m_dMidCharSpaceScale;//字符间隔比例(与最窄模块宽相比)

            public bool m_nEnableInterHatch;//1维条码内部填充 qy
            public double m_dHatchLineSpace;//填充线间距
            public double m_dLaserBeamDiameter;//激光光斑直径


            //二维码参数
            public Int32 m_n2DBarMode;//二维码条码模式
            public bool m_n2DBarReverseMode;//二维码条码反转模式

            public double m_d2DBarSize;//尺寸 

            public Int32 m_nRow;//行数
            public Int32 m_nCol;//列数
            public Int32 m_nCheckLevel;//错误纠正级别	
            public Int32 m_nSizeMode;//DataMatrix尺寸模式
            public Int32 m_nMaskPattern;//QRCode掩模图形参考	

            public bool m_nDmEnableeTilde;
            public bool m_nPdfShortMode;

            public double m_dOptimizCompt;//优化补偿
            public Int32 m_nPointTimesN;//20140324点倍数，用于GM码

            //空白参数
            public double m_dQuietLeftScale;//条码左空白宽度比例(与最窄模块宽相比)
            public double m_dQuietMidScale;//条码中空白宽度比例(与最窄模块宽相比)
            public double m_dQuietRightScale;//条码右空白宽度比例(与最窄模块宽相比)	
            public double m_dQuietTopScale;//条码上空白宽度比例(与最窄模块宽相比)
            public double m_dQuietBottomScale;//条码下空白宽度比例(与最窄模块宽相比)


            //人识别字符 
            public bool m_nShowText;
            public Int32 m_nTextPen;
            public bool m_bShowCheckNum;
            public double m_dTextHeight;
            public double m_dTextWidth;
            public double m_dTextOffsetX;
            public double m_dTextOffsetY;
            public double m_dTextSpace;

            public string m_strTextFontName;//文本字体名称


            public bool m_bEnableHatchText;
            public bool m_bEnableContour;
            public bool m_bContourFirst;
            public HatchParam m_HatchFillParam1;
            public HatchParam m_HatchFillParam2;
            public HatchParam m_HatchFillParam3;

            public bool m_bTextFixedSize;
            public double m_dTextFixedSizeX;
            public double m_dTextFixedSizeY;

            public BarcodeParam(string strFontName)
            {

                m_strBarcodeFontName = strFontName;
                m_bBarcodeType = 1;//条码类型 1 是1维，2是2维条码 

                m_bBarcodeCheckNum = false;
                m_bBarcodeReverse = false;//条码反转


                m_dHeight = 10;//整个条码的高	
                m_dNarrowWidth = 1;//最窄模块宽	

                m_bFixedSize = false;
                m_dFixedSizeX = 10;
                m_dFixedSizeY = 10;


                //1维码参数
                m_dBarWidthScale0 = 1;//条宽比例	(与最窄模块宽相比)
                m_dBarWidthScale1 = 2;
                m_dBarWidthScale2 = 3;
                m_dBarWidthScale3 = 4;

                m_dSpaceWidthScale0 = 1;//空宽比例(与最窄模块宽相比)
                m_dSpaceWidthScale1 = 2;
                m_dSpaceWidthScale2 = 3;
                m_dSpaceWidthScale3 = 4;

                m_dMidCharSpaceScale = 1;//字符间隔比例(与最窄模块宽相比)

                m_nEnableInterHatch = false;//1维条码内部填充 qy
                m_dHatchLineSpace = 0.1;//填充线间距
                m_dLaserBeamDiameter = 0.05;//激光光斑直径


                //二维码参数
                m_n2DBarMode = 0;//二维码条码模式
                m_n2DBarReverseMode = false;//二维码条码反转模式

                m_d2DBarSize = 1;//尺寸 

                m_nRow = 5;//行数
                m_nCol = 5;//列数
                m_nCheckLevel = 0;//错误纠正级别	
                m_nSizeMode = 0;//DataMatrix尺寸模式
                m_nMaskPattern = 0;//QRCode掩模图形参考	

                m_nPdfShortMode = false;
                m_nDmEnableeTilde = false;

                m_dOptimizCompt = 0;//优化补偿
                m_nPointTimesN = 1;//20140324点倍数，用于GM码

                //空白参数
                m_dQuietLeftScale = 10;//条码左空白宽度比例(与最窄模块宽相比)
                m_dQuietMidScale = 10;//条码中空白宽度比例(与最窄模块宽相比)
                m_dQuietRightScale = 10;//条码右空白宽度比例(与最窄模块宽相比)	
                m_dQuietTopScale = 10;//条码上空白宽度比例(与最窄模块宽相比)
                m_dQuietBottomScale = 10;//条码下空白宽度比例(与最窄模块宽相比)


                //人识别字符 
                m_nShowText = false;
                m_nTextPen = 0;
                m_bShowCheckNum = false;
                m_dTextHeight = 2;
                m_dTextWidth = 1;
                m_dTextOffsetX = 0;
                m_dTextOffsetY = 0;
                m_dTextSpace = 0;
                m_strTextFontName = "Arial";

                m_bEnableHatchText = false;
                m_bEnableContour = true;
                m_bContourFirst = false;
                m_HatchFillParam1 = new HatchParam();
                m_HatchFillParam2 = new HatchParam();
                m_HatchFillParam3 = new HatchParam();

                m_bTextFixedSize = false;
                m_dTextFixedSizeX = 10;
                m_dTextFixedSizeY = 10;
            }

            public string FontName()
            {
                return m_strBarcodeFontName;
            }

            public void SetFontName(string str)
            {
                m_strBarcodeFontName = str;
            }

            public string TextFontName()
            {
                return m_strTextFontName;
            }
            public void SetTextFontName(string str)
            {
                m_strTextFontName = str;
            }

            public bool Is1D()
            {
                return m_bBarcodeType == 1 ? true : false;
            }
            public bool Is2D()
            {
                return m_bBarcodeType == 2 ? true : false;
            }

            public int[] GetParamN()
            {
                int[] nParam = new int[22];

                nParam[0] = m_bBarcodeType;//一维码==1，二维码==2
                nParam[1] = m_bBarcodeCheckNum ? 1 : 0;
                nParam[2] = m_bBarcodeReverse ? 1 : 0;//反转
                nParam[3] = m_bFixedSize ? 1 : 0;//条码固定尺寸
                nParam[4] = m_nEnableInterHatch ? 1 : 0;//使能内部填充线
                nParam[5] = m_n2DBarMode;//条码模式 3=点 1=矩形 2=圆 0=标准模式
                nParam[6] = m_n2DBarReverseMode ? 1 : 0;//黑白反转
                nParam[7] = m_nRow;//行数
                nParam[8] = m_nCol;//列数
                nParam[9] = m_nCheckLevel;//错误纠正级别
                nParam[10] = m_nSizeMode;//条码版本号
                nParam[11] = m_nMaskPattern;
                nParam[12] = m_nPdfShortMode ? 1 : 0;//PDF417码缩短模式
                nParam[13] = m_nPointTimesN;//点倍数
                nParam[14] = m_nShowText ? 1 : 0;//显示人可识别字符
                nParam[15] = m_nTextPen;//可识别字符笔号
                nParam[16] = m_bShowCheckNum ? 1 : 0;//显示校验码
                nParam[17] = m_bEnableHatchText ? 1 : 0;//是否填充可识别字符
                nParam[18] = m_bEnableContour ? 1 : 0;//是否使能轮廓
                nParam[19] = m_bContourFirst ? 1 : 0; //轮廓是否优先加工
                nParam[20] = m_bTextFixedSize ? 1 : 0;//可识别字符固定尺寸
                nParam[21] = m_nDmEnableeTilde ? 1 : 0;//使能转义字符

                return nParam;
            }

            public double[] GetParamD()
            {
                double[] dParam = new double[28];

                dParam[0] = m_dHeight;//一维码条码高
                dParam[1] = m_dNarrowWidth;//窄条模块宽
                dParam[2] = m_dFixedSizeX;//固定尺寸X
                dParam[3] = m_dFixedSizeY;//固定尺寸Y
                dParam[4] = m_dBarWidthScale0;
                dParam[5] = m_dBarWidthScale1;
                dParam[6] = m_dBarWidthScale2;
                dParam[7] = m_dBarWidthScale3;
                dParam[8] = m_dSpaceWidthScale0;
                dParam[9] = m_dSpaceWidthScale1;
                dParam[10] = m_dSpaceWidthScale2;
                dParam[11] = m_dSpaceWidthScale3;
                dParam[12] = m_dMidCharSpaceScale;
                dParam[13] = m_dHatchLineSpace;//内部填充线间距
                dParam[14] = m_dLaserBeamDiameter;//激光光斑直径
                dParam[15] = m_d2DBarSize;

                dParam[16] = m_dQuietLeftScale;//左静区比例
                dParam[17] = m_dQuietMidScale;//中间静区比例
                dParam[18] = m_dQuietRightScale;//右静区比例
                dParam[19] = m_dQuietTopScale; //顶部静区比例
                dParam[20] = m_dQuietBottomScale;//底部静区比例

                dParam[21] = m_dTextHeight;//人可识别字符高度
                dParam[22] = m_dTextWidth;//人可识别字符宽度
                dParam[23] = m_dTextOffsetX;//文本X偏移
                dParam[24] = m_dTextOffsetY;//文本Y偏移
                dParam[25] = m_dTextSpace;//文本间距
                dParam[26] = m_dTextFixedSizeX;//人可识别字符固定尺寸X
                dParam[27] = m_dTextFixedSizeY;//人可识别字符固定尺寸Y
                return dParam;
            }

            public void SetParamN(int[] nParam)
            {
                m_bBarcodeType = nParam[0];
                m_bBarcodeCheckNum = nParam[1] != 0 ? true : false;
                m_bBarcodeReverse = nParam[2] != 0 ? true : false;
                m_bFixedSize = nParam[3] != 0 ? true : false;
                m_nEnableInterHatch = nParam[4] != 0 ? true : false;

                m_n2DBarMode = nParam[5];
                m_n2DBarReverseMode = nParam[6] != 0 ? true : false;//黑白反转
                m_nRow = nParam[7];
                m_nCol = nParam[8];
                m_nCheckLevel = nParam[9];
                m_nSizeMode = nParam[10];
                m_nMaskPattern = nParam[11];
                m_nPdfShortMode = nParam[12] != 0 ? true : false;
                m_nPointTimesN = nParam[13];

                m_nShowText = nParam[14] != 0 ? true : false;

                m_nTextPen = nParam[15];
                m_bShowCheckNum = nParam[16] != 0 ? true : false;

                m_bEnableHatchText = nParam[17] != 0 ? true : false;
                m_bEnableContour = nParam[18] != 0 ? true : false;
                m_bContourFirst = nParam[19] != 0 ? true : false;

                m_bTextFixedSize = nParam[20] != 0 ? true : false;
                m_nDmEnableeTilde = nParam[21] != 0 ? true : false;
            }

            public void SetParamD(double[] dParam)
            {
                m_dHeight = dParam[0];
                m_dNarrowWidth = dParam[1];
                m_dFixedSizeX = dParam[2];
                m_dFixedSizeY = dParam[3];
                m_dBarWidthScale0 = dParam[4];
                m_dBarWidthScale1 = dParam[5];
                m_dBarWidthScale2 = dParam[6];
                m_dBarWidthScale3 = dParam[7];
                m_dSpaceWidthScale0 = dParam[8];
                m_dSpaceWidthScale1 = dParam[9];
                m_dSpaceWidthScale2 = dParam[10];
                m_dSpaceWidthScale3 = dParam[11];
                m_dMidCharSpaceScale = dParam[12];
                m_dHatchLineSpace = dParam[13];
                m_dLaserBeamDiameter = dParam[14];
                m_d2DBarSize = dParam[15];

                m_dQuietLeftScale = dParam[16];
                m_dQuietMidScale = dParam[17];
                m_dQuietRightScale = dParam[18];
                m_dQuietTopScale = dParam[19];
                m_dQuietBottomScale = dParam[20];

                m_dTextHeight = dParam[21];
                m_dTextWidth = dParam[22];
                m_dTextOffsetX = dParam[23];
                m_dTextOffsetY = dParam[24];
                m_dTextSpace = dParam[25];
                m_dTextFixedSizeX = dParam[26];
                m_dTextFixedSizeY = dParam[27];
            }
        }
        /// <summary>
        /// 查询条码详细信息
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="nMaxParamN"></param>
        /// <param name="nParam"></param>
        /// <param name="nMaxParamD"></param>
        /// <param name="dParam"></param>
        /// <param name="strBarTypeName"></param>
        /// <param name="strTextTypeName"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetTextBarcodeInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetTextBarcodeInfo(E3_POINTER idEnt, int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam, StringBuilder strBarTypeName, StringBuilder strTextTypeName, ref HatchParam param1, ref HatchParam param2, ref HatchParam param3);
        public static E3_ERR E3_GetTextBarcodeInfo(E3_ID idEnt, int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam, StringBuilder strBarTypeName, StringBuilder strTextTypeName, ref HatchParam param1, ref HatchParam param2, ref HatchParam param3)
        {
            return e3_GetTextBarcodeInfo(idEnt, nMaxParamN, nParam, nMaxParamD, dParam, strBarTypeName, strTextTypeName, ref param1, ref param2, ref param3);
        }

        /// <summary>
        /// 设置条码参数
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="nMaxParamN"></param>
        /// <param name="nParam"></param>
        /// <param name="nMaxParamD"></param>
        /// <param name="dParam"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="strText"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetTextBarcodeInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        extern static E3_ERR e3_SetTextBarcodeInfo(E3_POINTER idEM, E3_POINTER idEnt, int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam, StringBuilder str1, StringBuilder str2, HatchParam param1, HatchParam param2, HatchParam param3, string strText, bool bUndo, string strUndo);
        public static E3_ERR E3_SetTextBarcodeInfo(E3_ID idEM, E3_ID idEnt, int nMaxParamN, int[] nParam, int nMaxParamD, double[] dParam, StringBuilder str1, StringBuilder str2, HatchParam param1, HatchParam param2, HatchParam param3, string strText, bool bUndo, string strUndo)
        {
            return e3_SetTextBarcodeInfo(idEM, idEnt, nMaxParamN, nParam, nMaxParamD, dParam, str1, str2, param1, param2, param3, strText, bUndo, strUndo);
        }

        public EzdKernel.E3_ID m_idEM;

        public bool GetTextBarcodeParam(EzdKernel.E3_ID idEntText, ref BarcodeParam barcodeParam)
        {
            int[] nParamBuf = new int[22];
            double[] dParamBuf = new double[28];
            StringBuilder str1 = new StringBuilder("", 256);
            StringBuilder str2 = new StringBuilder("", 256);

            if (EzdKernel.E3_GetTextBarcodeInfo(idEntText, nParamBuf.Length, nParamBuf, dParamBuf.Length, dParamBuf, str1, str2, ref barcodeParam.m_HatchFillParam1, ref barcodeParam.m_HatchFillParam2, ref barcodeParam.m_HatchFillParam3) != EzdKernel.E3_ERR.SUCCESS)
            {
                return false;
            }
            barcodeParam.SetParamN(nParamBuf);
            barcodeParam.SetParamD(dParamBuf);
            barcodeParam.m_strBarcodeFontName = str1.ToString();
            barcodeParam.m_strTextFontName = str2.ToString();
            return true;
        }
        #endregion

        #region Hatch

        public struct HatchParam
        {

            int m_nHatchParamSize;//HatchParam的尺寸（默认是120即可）
            int m_bEnableHatch;//填充使能
            int m_bAllCalc;  //整体计算
            int m_bFollowEdge;//绕边
            int m_bAverageLine;//平均分布填充线
            int m_bLoopReverse;//反转
            int m_bCross;//交叉填充  

            int m_nHatchType; //填充类型（0-6依次对应填充类型中从单向填充开始依次对应）
            int m_nPenNo;//填充笔号  
            public double m_dHatchLineDist;//填充线间距
            double m_dHatchAngle;//填充线角度
            double m_dHatchEdgeDist;//填充线边距 
            double m_dHatchStartOffset;//填充线起始偏移距离
            double m_dHatchEndOffset;//填充线结束偏移距离

            int m_bEnableAutoRotate;//使能自动旋转
            double m_dHatchRotateAngle;//旋转角度

            double m_dHatchLineReduction;//直线缩进
            double m_dHatchLoopDist;//环间距
            int m_nEdgeLoop;//边界环数


            public HatchParam(int BaseParam)
            {
                m_nHatchParamSize = 120;
                m_bEnableHatch = 1;//填充使能
                m_bAllCalc = 1;  //整体计算
                m_bFollowEdge = 1;//绕边
                m_bAverageLine = 1;//平均分布填充线
                m_bLoopReverse = 0;//反转
                m_bCross = 0;
                m_nHatchType = 1; //填充类型
                m_nPenNo = 0;//填充笔	 
                m_dHatchLineDist = 0.01;//填充线间距
                m_dHatchAngle = 0;//填充线角度
                m_dHatchEdgeDist = 0;//填充线边距 
                m_dHatchStartOffset = 0;//填充线起始偏移距离
                m_dHatchEndOffset = 0;//填充线结束偏移距离

                m_bEnableAutoRotate = 0;//使能自动旋转
                m_dHatchRotateAngle = 0;//旋转角度

                m_dHatchLineReduction = 0;//直线缩进
                m_dHatchLoopDist = 0;//环间距
                m_nEdgeLoop = 0;//边界环数
            }

        };
        /// <summary>
        /// 获取填充参数（得到已有填充的填充参数）
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="bEnableContour"></param>
        /// <param name="bContourFirst"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetHatchParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetHatchParam(E3_POINTER idEnt, ref bool bEnableContour, ref bool bContourFirst, ref HatchParam param1, ref HatchParam param2, ref HatchParam param3);
        public static E3_ERR E3_GetHatchParam(E3_ID idEnt, ref bool bEnableContour, ref bool bContourFirst, ref HatchParam param1, ref HatchParam param2, ref HatchParam param3)
        {
            return e3_GetHatchParam(idEnt, ref bEnableContour, ref bContourFirst, ref param1, ref param2, ref param3);
        }
        /// <summary>
        /// 设置填充参数（此对象已有填充的情况下使用其修改填充参数）
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="bEnableContour"></param>
        /// <param name="bContourFirst"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetHatchParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetHatchParam(E3_POINTER idEM, E3_POINTER idEnt, bool bEnableContour, bool bContourFirst, HatchParam param1, HatchParam param2, HatchParam param3);
        public static E3_ERR E3_SetHatchParam(E3_ID idEM, E3_ID idEnt, bool bEnableContour, bool bContourFirst, HatchParam param1, HatchParam param2, HatchParam param3)
        {
            return e3_SetHatchParam(idEM, idEnt, bEnableContour, bContourFirst, param1, param2, param3);
        }
        //E3_API int E3_EnableShowHatchProcess(BOOL b);
        /// <summary>
        /// 显示填充进度条
        /// </summary>
        /// <param name="EnShow"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_EnableShowHatchProcess", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_EnableShowHatchProcess(bool EnShow);
        public static E3_ERR E3_EnableShowHatchProcess(bool EnShow)
        {
            return e3_EnableShowHatchProcess(EnShow);
        }
        /// <summary>
        /// 删除指定对象填充
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="idEnt"></param>
        /// <param name="bUndo"></param>
        /// <param name="strUndo"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_DelEntHatchParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_DelEntHatchParam(E3_POINTER idEM, E3_POINTER idEnt, bool bUndo, string strUndo);
        public static E3_ERR E3_DelEntHatchParam(E3_ID idEM, E3_ID idEnt, bool bUndo, string strUndo)
        {
            return e3_DelEntHatchParam(idEM, idEnt, bUndo, strUndo);
        }

        /// <summary>
        /// 填充指定对象（3组填充参数
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="bEnableContour"></param>
        /// <param name="bContourFirst"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_HatchEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_HatchEnt(E3_POINTER idEnt, bool bEnableContour, bool bContourFirst, HatchParam param1, HatchParam param2, HatchParam param3);
        public static E3_ERR E3_HatchEnt(E3_ID idEnt, bool bEnableContour, bool bContourFirst, HatchParam param1, HatchParam param2, HatchParam param3)
        {
            return e3_HatchEnt(idEnt, bEnableContour, bContourFirst, param1, param2, param3);
        }
        /// <summary>
        /// 填充指定对象（8组填充参数）
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="bEnableContour"></param>
        /// <param name="bContourFirst"></param>
        /// <param name="nHatchParamCount"></param>
        /// <param name="paramList"></param>
        /// <param name="idHatchEnt"></param>
        /// <returns></returns>
        //int E3_HatchEnt2(E3_ID idEnt, BOOL bEnableContour, BOOL bContourFirst, int nHatchParamCount, HatchParam* pParam, E3_ID& idEntHatch)
        [DllImport("Ezcad3kernel", EntryPoint = "E3_HatchEnt2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_HatchEnt2(E3_POINTER idEnt, bool bEnableContour, bool bContourFirst, int nHatchParamCount, HatchParam[] paramList, ref E3_POINTER idHatchEnt);
        public static E3_ERR E3_HatchEnt2(E3_ID idEnt, bool bEnableContour, bool bContourFirst, int nHatchParamCount, HatchParam[] paramList, ref E3_ID idHatchEnt)
        {
            E3_POINTER id = 0;
            E3_ERR err = e3_HatchEnt2(idEnt, bEnableContour, bContourFirst, nHatchParamCount, paramList, ref id);
            idHatchEnt = id;
            return err;
        }


        /// <summary>
        /// 背景填充功能（需要开通背景填充功能）
        /// </summary>
        /// <param name="idEnt"></param>
        /// <param name="idEntBack"></param>
        /// <param name="bEnableContour"></param>
        /// <param name="bContourFist"></param>
        /// <param name="bDeleteOldEnt"></param>
        /// <param name="idNewEnt"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_HatchEntByBack", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_HatchEntByBack(E3_POINTER idEnt, E3_POINTER idEntBack, bool bEnableContour, bool bContourFist, bool bDeleteOldEnt, ref E3_POINTER idNewEnt);
        public static E3_ERR E3_HatchEntByBack(E3_ID idEnt, E3_ID idEntBack, bool bEnableContour, bool bContourFist, bool bDeleteOldEnt, ref E3_ID idNewEnt)
        {
            E3_POINTER id = idEntBack;
            E3_ERR err = e3_HatchEntByBack(idEnt, idEntBack, bEnableContour, bContourFist, bDeleteOldEnt, ref id);
            idNewEnt = id;
            return err;
        }




        #endregion
        #region 笔参数

        /// 设置匀速笔标刻参数.
        /// </summary>
        /// <param name="idEM">管理器句柄.</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="bSkyWrite">使能.</param>
        /// <param name="nSkyWriteMode">匀速模式,默认为3.</param>
        /// <param name="dSkyWriteLimitAngle">极限角度.</param>
        /// <param name="nSkyWriteNprev">导入周期,默认10us</param>
        /// <param name="nSkyWriteNpost">导出周期,默认10us</param>
        /// <param name="dSkyWriteTimelag">滞后时间us</param>
        /// <param name="nSkyWriteLaserOnShift">漂移时间us</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetPenParamSkyWriting", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetPenParamSkyWriting(E3_POINTER idEM, int nPenNo, bool bSkyWrite, int nSkyWriteMode, double dSkyWriteLimitAngle, int nSkyWriteNprev, int nSkyWriteNpost, double dSkyWriteTimelag, int nSkyWriteLaserOnShift);
        public static E3_ERR E3_SetPenParamSkyWriting(E3_ID idEM, int nPenNo, bool bSkyWrite, int nSkyWriteMode, double dSkyWriteLimitAngle, int nSkyWriteNprev, int nSkyWriteNpost, double dSkyWriteTimelag, int nSkyWriteLaserOnShift)
        {
            return e3_SetPenParamSkyWriting(idEM, nPenNo, bSkyWrite, nSkyWriteMode, dSkyWriteLimitAngle, nSkyWriteNprev, nSkyWriteNpost, dSkyWriteTimelag, nSkyWriteLaserOnShift);
        }
        /// <summary>
        /// 获取匀速笔标刻参数.
        /// </summary>
        /// <param name="idEM">管理器句柄.</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="bSkyWrite">使能.</param>
        /// <param name="nSkyWriteMode">匀速模式,默认为3.</param>
        /// <param name="dSkyWriteLimitAngle">极限角度.</param>
        /// <param name="nSkyWriteNprev">导入周期,默认10us</param>
        /// <param name="nSkyWriteNpost">导出周期,默认10us</param>
        /// <param name="dSkyWriteTimelag">滞后时间us</param>
        /// <param name="nSkyWriteLaserOnShift">漂移时间us</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetPenParamSkyWriting", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetPenParamSkyWriting(E3_POINTER idEM, int nPenNo, ref bool bSkyWrite, ref int nSkyWriteMode, ref double dSkyWriteLimitAngle, ref int nSkyWriteNprev, ref int nSkyWriteNpost, ref double dSkyWriteTimelag, ref int nSkyWriteLaserOnShift);

        public static E3_ERR E3_GetPenParamSkyWriting(E3_ID idEM, int nPenNo, ref bool bSkyWrite, ref int nSkyWriteMode, ref double dSkyWriteLimitAngle, ref int nSkyWriteNprev, ref int nSkyWriteNpost, ref double dSkyWriteTimelag, ref int nSkyWriteLaserOnShift)
        {
            return e3_GetPenParamSkyWriting(idEM, nPenNo, ref bSkyWrite, ref nSkyWriteMode, ref dSkyWriteLimitAngle, ref nSkyWriteNprev, ref nSkyWriteNpost, ref dSkyWriteTimelag, ref nSkyWriteLaserOnShift);

        }
        /// <summary>
        /// 获取步距标刻参数
        /// </summary>
        /// <param name="idEM">管理器句柄.</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="bEnbleStepMode">步距模式</param>
        /// <param name="dMarkStep">优化长度.</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetPenParamStep", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetPenParamStep(E3_POINTER idEM, int nPenNo, ref bool bEnbleStepMode, ref double dMarkStep);

        public static E3_ERR E3_GetPenParamStep(E3_ID idEM, int nPenNo, ref bool bEnbleStepMode, ref double dMarkStep)
        {
            return e3_GetPenParamStep(idEM, nPenNo, ref bEnbleStepMode, ref dMarkStep);

        }

        /// <summary>
        /// 设置步距标刻参数
        /// </summary>
        /// <param name="idEM">管理器句柄.</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="bEnbleStepMode">步距模式</param>
        /// <param name="dMarkStep">优化长度.</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetPenParamStep", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetPenParamStep(E3_POINTER idEM, int nPenNo, bool bEnbleStepMode, double dMarkStep);

        public static E3_ERR E3_SetPenParamStep(E3_ID idEM, int nPenNo, bool bEnbleStepMode, double dMarkStep)
        {
            return e3_SetPenParamStep(idEM, nPenNo, bEnbleStepMode, dMarkStep);

        }
        /// <summary>
        /// 设置功率渐变参数。
        /// </summary>
        /// <param name="idEM">管理器ID</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="bAccSegEnable">使能起始</param>
        /// <param name="dAccSegStartRatio">起始功率比例%;实际出光功率为当前加工参数功率乘此百分比</param>
        /// <param name="dAccSegLen">起始长度;起始功率渐变的长度</param>
        /// <param name="bDecSegEnable">使能结束</param>
        /// <param name="dDecSegStartRatio">结束功率比例%;实际出光功率为当前加工参数功率乘此百分比</param>
        /// <param name="dDecSegLen">结束长度;结束功率渐变的长度</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetPenParamPowerRamp", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetPenParamPowerRamp(E3_POINTER idEM, int nPenNo, bool bAccSegEnable, double dAccSegStartRatio, double dAccSegLen, bool bDecSegEnable, double dDecSegStartRatio, double dDecSegLen);

        public static E3_ERR E3_SetPenParamPowerRamp(E3_ID idEM, int nPenNo, bool bAccSegEnable, double dAccSegStartRatio, double dAccSegLen, bool bDecSegEnable, double dDecSegStartRatio, double dDecSegLen)
        {
            return e3_SetPenParamPowerRamp(idEM, nPenNo, bAccSegEnable, dAccSegStartRatio, dAccSegLen, bDecSegEnable, dDecSegStartRatio, dDecSegLen);

        }
        /// <summary>
        /// 获取功率渐变参数。
        /// </summary>
        /// <param name="idEM">管理器ID</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="bAccSegEnable">使能起始</param>
        /// <param name="dAccSegStartRatio">起始功率比例%;实际出光功率为当前加工参数功率乘此百分比</param>
        /// <param name="dAccSegLen">起始长度;起始功率渐变的长度</param>
        /// <param name="bDecSegEnable">使能结束</param>
        /// <param name="dDecSegStartRatio">结束功率比例%;实际出光功率为当前加工参数功率乘此百分比</param>
        /// <param name="dDecSegLen">结束长度;结束功率渐变的长度</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetPenParamPowerRamp", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetPenParamPowerRamp(E3_POINTER idEM, int nPenNo, ref bool bAccSegEnable, ref double dAccSegStartRatio, ref double dAccSegLrefen, ref bool bDecSegEnable, ref double dDecSegStartRatio, ref double dDecSegLen);

        public static E3_ERR E3_GetPenParamPowerRamp(E3_ID idEM, int nPenNo, ref bool bAccSegEnable, ref double dAccSegStartRatio, ref double dAccSegLrefen, ref bool bDecSegEnable, ref double dDecSegStartRatio, ref double dDecSegLen)
        {
            return e3_GetPenParamPowerRamp(idEM, nPenNo, ref bAccSegEnable, ref dAccSegStartRatio, ref dAccSegLrefen, ref bDecSegEnable, ref dDecSegStartRatio, ref dDecSegLen);

        }
        //  E3_API int E3_GetPenParamWobble(E3_ID idEM, int nPenNo, BOOL& bWobbleMode, int& nWobbleType, double& dWobbleDiameter, double& dWobbleDiameterB, double& dWobbleDist);
        //  E3_API int E3_SetPenParamWobble(E3_ID idEM, int nPenNo, BOOL bWobbleMode, int nWobbleType, double dWobbleDiameter, double dWobbleDiameterB, double dWobbleDist);
        //获取笔参数抖动
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetPenParamWobble", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetPenParamWobble(E3_POINTER idEM, int nPenNo, ref bool bWobbleMode, ref int nWobbleType, ref double dWobbleDiameter, ref double dWobbleDiameterB, ref double dWobbleDist);
        public static E3_ERR E3_GetPenParamWobble(E3_ID idEM, int nPenNo, ref bool bWobbleMode, ref int nWobbleType, ref double dWobbleDiameter, ref double dWobbleDiameterB, ref double dWobbleDist)
        {
            return e3_GetPenParamWobble(idEM, nPenNo, ref bWobbleMode, ref nWobbleType, ref dWobbleDiameter, ref dWobbleDiameterB, ref dWobbleDist);
        }
        //设置笔参数抖动
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetPenParamWobble", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetPenParamWobble(E3_POINTER idEM, int nPenNo, bool bWobbleMode, int nWobbleType, double dWobbleDiameter, double dWobbleDiameterB, double dWobbleDist);
        public static E3_ERR E3_SetPenParamWobble(E3_ID idEM, int nPenNo, bool bWobbleMode, int nWobbleType, double dWobbleDiameter, double dWobbleDiameterB, double dWobbleDist)
        {
            return e3_SetPenParamWobble(idEM, nPenNo, bWobbleMode, nWobbleType, dWobbleDiameter, dWobbleDiameterB, dWobbleDist);
        }
        /// <summary>
        /// 设置速度渐变参数.
        /// </summary>
        /// <param name="idEM">管理器句柄</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="bAccSegEnable">使能起始</param>
        /// <param name="dAccSegStartRatio">起始速度比例%;实际振镜摆动为当前加工参数速度乘此百分比</param>
        /// <param name="dAccSegLen">起始长度;起始速度渐变的长度</param>
        /// <param name="bDecSegEnable">使能结束</param>
        /// <param name="dDecSegStartRatio">结束速度比例;实际振镜摆动速度为当前加工参数速度乘此百分比</param>
        /// <param name="dDecSegLen">结束长度;结束速度渐变的长度</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetPenParamSpeedRamp", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetPenParamSpeedRamp(E3_POINTER idEM, int nPenNo, bool bAccSegEnable, double dAccSegStartRatio, double dAccSegLen, bool bDecSegEnable, double dDecSegStartRatio, double dDecSegLen);

        public static E3_ERR E3_SetPenParamSpeedRamp(E3_ID idEM, int nPenNo, bool bAccSegEnable, double dAccSegStartRatio, double dAccSegLen, bool bDecSegEnable, double dDecSegStartRatio, double dDecSegLen)
        {
            return e3_SetPenParamSpeedRamp(idEM, nPenNo, bAccSegEnable, dAccSegStartRatio, dAccSegLen, bDecSegEnable, dDecSegStartRatio, dDecSegLen);

        }
        /// <summary>
        /// 读取速度渐变参数.
        /// </summary>
        /// <param name="idEM">管理器句柄</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="bAccSegEnable">使能起始</param>
        /// <param name="dAccSegStartRatio">起始速度比例%;实际振镜摆动为当前加工参数速度乘此百分比</param>
        /// <param name="dAccSegLen">起始长度;起始速度渐变的长度</param>
        /// <param name="bDecSegEnable">使能结束</param>
        /// <param name="dDecSegStartRatio">结束速度比例;实际振镜摆动速度为当前加工参数速度乘此百分比</param>
        /// <param name="dDecSegLen">结束长度;结束速度渐变的长度</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetPenParamSpeedRamp", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetPenParamSpeedRamp(E3_POINTER idEM, int nPenNo, ref bool bAccSegEnable, ref double dAccSegStartRatio, ref double dAccSegLen, ref bool bDecSegEnable, ref double dDecSegStartRatio, ref double dDecSegLen);

        public static E3_ERR E3_GetPenParamSpeedRamp(E3_ID idEM, int nPenNo, ref bool bAccSegEnable, ref double dAccSegStartRatio, ref double dAccSegLen, ref bool bDecSegEnable, ref double dDecSegStartRatio, ref double dDecSegLen)
        {
            return e3_GetPenParamSpeedRamp(idEM, nPenNo, ref bAccSegEnable, ref dAccSegStartRatio, ref dAccSegLen, ref bDecSegEnable, ref dDecSegStartRatio, ref dDecSegLen);

        }
        /// </summary> 
        /// <summary>
        /// 得到标记笔参数
        /// </summary>   
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetPenParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetPenParam(E3_POINTER idEM,
                                            int nPenNo,
                                            StringBuilder pStrName,
                                            ref int clr,
                                            ref bool bDisableMark,
                                            ref bool bUseDefParam,
                                            ref int nMarkLoop,
                                            ref double dMarkSpeed,
                                            ref double dPowerRatio,
                                            ref double dCurrent,
                                            ref double dFreq,
                                            ref double dQPulseWidth,
                                            ref int nStartTC,
                                            ref int nLaserOffTC,
                                            ref int nEndTC,
                                            ref int nPolyTC,
                                            ref double dJumpSpeed,
                                            ref int nMinJumpDelayTCUs,
                                            ref int nMaxJumpDelayTCUs,
                                            ref double dJumpLengthLimit,
                                            ref double dPointTimeMs,
                                            ref bool nSpiSpiContinueMode,
                                            ref int nSpiWave,
                                            ref int nYagMarkMode,
                                            ref bool bPulsePointMode,
                                            ref int nPulseNum,
                                            ref bool bEnableACCMode,
                                            ref double dEndComp,
                                            ref double dAccDist,
                                            ref double dBreakAngle,
                                            ref bool bWobbleMode,
                                            ref double bWobbleDiameter,
                                            ref double bWobbleDist);

        public static E3_ERR E3_GetPenParam(E3_ID idEM,
                                             int nPenNo,
                                             StringBuilder pStrName,
                                             ref int clr,
                                             ref bool bDisableMark,
                                             ref bool bUseDefParam,
                                             ref int nMarkLoop,
                                             ref double dMarkSpeed,
                                             ref double dPowerRatio,
                                             ref double dCurrent,
                                             ref double dFreq,
                                             ref double dQPulseWidth,
                                             ref int nStartTC,
                                             ref int nLaserOffTC,
                                             ref int nEndTC,
                                             ref int nPolyTC,
                                             ref double dJumpSpeed,
                                             ref int nMinJumpDelayTCUs,
                                             ref int nMaxJumpDelayTCUs,
                                             ref double dJumpLengthLimit,
                                             ref double dPointTimeMs,
                                             ref bool nSpiSpiContinueMode,
                                             ref int nSpiWave,
                                             ref int nYagMarkMode,
                                             ref bool bPulsePointMode,
                                             ref int nPulseNum,
                                             ref bool bEnableACCMode,
                                             ref double dEndComp,
                                             ref double dAccDist,
                                             ref double dBreakAngle,
                                             ref bool bWobbleMode,
                                             ref double bWobbleDiameter,
                                             ref double bWobbleDist)
        {
            return e3_GetPenParam(idEM,
            nPenNo,
            pStrName,
            ref clr,
            ref bDisableMark,
            ref bUseDefParam,
            ref nMarkLoop,
            ref dMarkSpeed,
            ref dPowerRatio,
            ref dCurrent,
            ref dFreq,
            ref dQPulseWidth,
            ref nStartTC,
            ref nLaserOffTC,
            ref nEndTC,
            ref nPolyTC,
            ref dJumpSpeed,
            ref nMinJumpDelayTCUs,
            ref nMaxJumpDelayTCUs,
            ref dJumpLengthLimit,
            ref dPointTimeMs,
            ref nSpiSpiContinueMode,
            ref nSpiWave,
            ref nYagMarkMode,
            ref bPulsePointMode,
            ref nPulseNum,
            ref bEnableACCMode,
            ref dEndComp,
            ref dAccDist,
            ref dBreakAngle,
            ref bWobbleMode,
            ref bWobbleDiameter,
            ref bWobbleDist);
        }


        /// </summary> 
        /// <summary>
        /// 设置标记笔参数
        /// </summary>   
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetPenParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetPenParam(E3_POINTER idEM, int nPenNo,
                                                            string pStrName,
                                                            int clr,
                                                            bool bDisableMark,
                                                            bool bUseDefParam,
                                                            int nMarkLoop,
                                                            double dMarkSpeed,
                                                            double dPowerRatio,
                                                            double dCurrent,
                                                            double dFreq,
                                                            double dQPulseWidth,
                                                            int nStartTC,
                                                            int nLaserOffTC,
                                                            int nEndTC,
                                                            int nPolyTC,
                                                            double dJumpSpeed,
                                                            int nMinJumpDelayTCUs,
                                                            int nMaxJumpDelayTCUs,
                                                            double dJumpLengthLimit,
                                                            double dPointTimeMs,
                                                            bool nSpiSpiContinueMode,
                                                            int nSpiWave,
                                                            int nYagMarkMode,
                                                            bool bPulsePointMode,
                                                            int nPulseNum,
                                                            bool bEnableACCMode,
                                                            double dEndComp,
                                                            double dAccDist,
                                                            double dBreakAngle,
                                                            bool bWobbleMode,
                                                            double bWobbleDiameter,
                                                            double bWobbleDist);

        public static E3_ERR E3_SetPenParam(E3_ID idEM, int nPenNo,
                                                        string pStrName,
                                                        int clr,
                                                        bool bDisableMark,
                                                        bool bUseDefParam,
                                                        int nMarkLoop,
                                                        double dMarkSpeed,
                                                        double dPowerRatio,
                                                        double dCurrent,
                                                        double dFreq,
                                                        double dQPulseWidth,
                                                        int nStartTC,
                                                        int nLaserOffTC,
                                                        int nEndTC,
                                                        int nPolyTC,
                                                        double dJumpSpeed,
                                                        int nMinJumpDelayTCUs,
                                                        int nMaxJumpDelayTCUs,
                                                        double dJumpLengthLimit,
                                                        double dPointTimeMs,
                                                        bool nSpiSpiContinueMode,
                                                        int nSpiWave,
                                                        int nYagMarkMode,
                                                        bool bPulsePointMode,
                                                        int nPulseNum,
                                                        bool bEnableACCMode,
                                                        double dEndComp,
                                                        double dAccDist,
                                                        double dBreakAngle,
                                                        bool bWobbleMode,
                                                        double bWobbleDiameter,
                                                        double bWobbleDist)
        {
            return e3_SetPenParam(idEM, nPenNo,
            pStrName,
            clr,
            bDisableMark,
            bUseDefParam,
            nMarkLoop,
            dMarkSpeed,
            dPowerRatio,
            dCurrent,
            dFreq,
            dQPulseWidth,
            nStartTC,
            nLaserOffTC,
            nEndTC,
            nPolyTC,
            dJumpSpeed,
            nMinJumpDelayTCUs,
            nMaxJumpDelayTCUs,
            dJumpLengthLimit,
            dPointTimeMs,
            nSpiSpiContinueMode,
            nSpiWave,
            nYagMarkMode,
            bPulsePointMode,
            nPulseNum,
            bEnableACCMode,
            dEndComp,
            dAccDist,
            dBreakAngle,
            bWobbleMode,
            bWobbleDiameter,
            bWobbleDist);
        }
        //获取对象的笔号。
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetEntPen", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetEntPen(E3_POINTER idMarker, ref int nPen);

        public static E3_ERR E3_GetEntPen(E3_ID idMarker, ref int nPen)
        {
            return e3_GetEntPen(idMarker, ref nPen);

        }
        //设置对象的笔号。
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetEntPen", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetEntPen(E3_POINTER idMarker, int nPen);

        public static E3_ERR E3_SetEntPen(E3_ID idMarker, int nPen)
        {
            return e3_SetEntPen(idMarker, nPen);

        }
        #endregion

        #region 加工参数
        /// <summary>
		/// 获取加工参数库中的参数的数量
		/// </summary>
		/// <param name="nCount">参数的数量</param>
		/// <returns></returns>
		[DllImport("Ezcad3kernel", EntryPoint = "E3_GetParamLibCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_GetParamLibCount(ref int nCount);
        /// <summary>
        /// 获取加工参数库中的指定位置的参数名
        /// </summary>
        /// <param name="nIndex">将要获取参数名的从0开始的下标.</param>
        /// <param name="strName">获取到对应下标参数的参数名.</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetParamLibName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_GetParamLibName(int nIndex, StringBuilder strName);
        /// <summary>
        /// 删除加工参数库中指定名称的参数.
        /// </summary>
        /// <param name="strName">将要删除参数的名称.</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_ParamLibDeleteName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_ParamLibDeleteName(string strName);
        /// <summary>
        /// 将指定笔号的加工参数保存到加工参数库中
        /// </summary>
        /// <param name="idEM">管理器句柄</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="strName">参数的参数名.</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_ParamLibSavePenToName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_ParamLibSavePenToName(E3_ID idEM, int nPenNo, string strName);
        /// <summary>
        /// 将加工参数库中指定名称的参数信息设置给指定的笔号
        /// </summary>
        /// <param name="idEM">管理器句柄</param>
        /// <param name="nPenNo">笔号</param>
        /// <param name="strName">要设置给指定笔号的参数名.</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_ParamLibSetPenFromName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_ParamLibSetPenFromName(E3_ID idEM, int nPenNo, string strName);
        #endregion

        #region 加工

        public const int MAKRFLAG_REDLIGHT = 0x000000002;  //红光指示 

        public const int MAKRFLAG_FLYMODE = 0x000000400;  //飞行标刻      

        public const int MAKRFLAG_CALCTIMEMODE = 0x01000000;  //计算模式
        public const int MAKRFLAG_DISABLEAUTORUN = 0x000008000;  //禁止自动运行(前一个markflag是发送数据时使用。  //仅发送数据，不加工)

        /// <summary>
        /// 获取上次计算的加工时间
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="TimeMs"></param>
        /// <returns></returns>
        // E3_API int E3_MarkerGetCalcMarkTime(E3_ID idMarker, int& nTimeMs);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetCalcMarkTime", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetCalcMarkTime(E3_POINTER idMarker, ref int TimeMs);
        public static E3_ERR E3_MarkerGetCalcMarkTime(E3_ID idMarker, ref int TimeMs)
        {
            return e3_MarkerGetCalcMarkTime(idMarker, ref TimeMs);
        }

        /// <summary>
        /// 获取上次实际加工时间
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="nTimeMs"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetMakingTime", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetMakingTime(E3_POINTER idMarker, ref int nTimeMs);
        public static E3_ERR E3_MarkerGetMakingTime(E3_ID idMarker, ref int nTimeMs)
        {
            return e3_MarkerGetMakingTime(idMarker, ref nTimeMs);
        }
        //单独控制激光开关
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerLaserOn", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerLaserOn(E3_POINTER idMarker, int nPenNo, bool bOpen);
        public static E3_ERR E3_MarkerLaserOn(E3_ID idMarker, int nPenNo, bool bOpen)
        {
            return e3_MarkerLaserOn(idMarker, nPenNo, bOpen);
        }
        /// <summary>
        /// 停止加工
        /// </summary>
        /// <param name="idMarker"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerStop", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerStop(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerStop(E3_ID idMarker)
        {
            return e3_MarkerStop(idMarker);
        }
        /// <summary>
        /// 后面的接口仅加工不发送数据
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="bWaitForFinish"></param>
        /// <param name="nMarkFlag"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerExecuteAndWaitFinish", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerExecuteAndWaitFinish(E3_POINTER idMarker, bool bWaitForFinish, int nMarkFlag);
        public static E3_ERR E3_MarkerExecuteAndWaitFinish(E3_ID idMarker, bool bWaitForFinish, int nMarkFlag)
        {
            return e3_MarkerExecuteAndWaitFinish(idMarker, bWaitForFinish, nMarkFlag);
        }
        /// <summary>
        /// 加工
        /// </summary>
        /// <param name="idMarker DLC板卡ID"></param>
        /// <param name="idEM 管理器ID"></param>
        /// <param name="idEnt 对象ID或层ID"></param>
        /// <param name="nMarkFlag 0x0000:静态标刻; 0x0002:红光指示;0x0400:飞行标刻;0x01000000计算模式（用于预估加工时间）;0x000008000（只下发数据不加工）"></param>
        /// <param name="nStartPartNum 从第几个对象开始标刻"></param>
        /// <param name="nMaxPartCount 标刻最大个数"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerMarkEnt2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkEnt2(E3_POINTER idMarker, E3_POINTER idEM, E3_POINTER idEnt, int nMarkFlag, int nStartPartNum, int nMaxPartCount);
        public static E3_ERR E3_MarkEnt2(E3_ID idMarker, E3_ID idEM, E3_ID idEnt, int nMarkFlag, int nStartPartNum, int nMaxPartCount)
        {
            return e3_MarkEnt2(idMarker, idEM, idEnt, nMarkFlag, nStartPartNum, nMaxPartCount);
        }

        #endregion

        #region 开启红光
        
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerSwitchRedLight", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerSwitchRedLight(E3_POINTER idMarker,bool bOn);
        public static E3_ERR E3_MarkerSwitchRedLight(E3_ID idMarker, bool bOn)
        {
            return e3_MarkerSwitchRedLight(idMarker, bOn);
        }

        #endregion


        #region 列表加工
        //输入口是否脉冲模式，高低有效
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetInputPortWorkMode", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetInputPortWorkMode(E3_POINTER idMarker, bool bPulseMode, bool bLowVaild);
        public static E3_ERR E3_SetInputPortWorkMode(E3_ID idMarker, bool bPulseMode, bool bLowVaild)
        {
            return e3_SetInputPortWorkMode(idMarker, bPulseMode, bLowVaild);
        }
        /// <summary>
        /// 列表准备
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="idEM"></param>
        /// <param name="nFlag"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerListReady", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerListReady(E3_POINTER idMarker, E3_POINTER idEM, int nFlag);
        public static E3_ERR E3_MarkerListReady(E3_ID idMarker, E3_ID idEm, int nFlag)
        {
            return e3_MarkerListReady(idMarker, idEm, nFlag);
        }
        // 设置输入信号参数
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerWaitForInputToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerWaitForInputToList(E3_POINTER idMarker, ushort uMask, ushort uLevel);
        public static E3_ERR E3_MarkerWaitForInputToList(E3_ID idMarker, ushort uMask, ushort uLevel)
        {
            return e3_MarkerWaitForInputToList(idMarker, uMask, uLevel);
        }
        //确保当前数据缓存区的数据已经发送到卡里，并且卡里已经执行列表
        // int E3_MarkerSentBufToCardAndRunList(E3_ID idMarker)
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerSentBufToCardAndRunList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerSentBufToCardAndRunList(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerSentBufToCardAndRunList(E3_ID idMarker)
        {
            return e3_MarkerSentBufToCardAndRunList(idMarker);
        }
        /// <summary>
        /// 列表插入等待视觉位置到位
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="dFlyDistance"></param>
        /// <param name="bIsFollowAvail"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_FlyWaitCameraPositioningToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_FlyWaitCameraPositioningToList(E3_POINTER idMarker, double dFlyDistance, bool bIsFollowAvail);
        public static E3_ERR E3_FlyWaitCameraPositioningToList(E3_ID idMarker, double dFlyDistance, bool bIsFollowAvail)
        {
            return e3_FlyWaitCameraPositioningToList(idMarker, dFlyDistance, bIsFollowAvail);
        }
        //设置对象变换的使能
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerSelectTransMatirxToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerSelectTransMatirxToList(E3_POINTER idMarker, int n, bool bEnable);
        public static E3_ERR E3_MarkerSelectTransMatirxToList(E3_ID idMarker, int n, bool bEnable)
        {
            return e3_MarkerSelectTransMatirxToList(idMarker, n, bEnable);
        }
        /// <summary>
        /// 脱机模式自动选择矩阵
        /// </summary>
        /// <param name="idMarker"></param>
        /// <returns></returns>
        //E3_API int E3_MarkerAutoSelectListMatirxToList(E3_ID idMarker);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerAutoSelectListMatirxToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerAutoSelectListMatirxToList(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerAutoSelectListMatirxToList(E3_ID idMarker)
        {
            return e3_MarkerAutoSelectListMatirxToList(idMarker);
        }

        /// <summary>
        /// 设置当前序号的移动旋转量
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="n"></param>
        /// <param name="dMoveX"></param>
        /// <param name="dMoveY"></param>
        /// <param name="dCenterX"></param>
        /// <param name="dCenterY"></param>
        /// <param name="dRotateAng"></param>
        /// <returns></returns>
        //E3_API int E3_MarkerSetTransformMatrixByIndex2(E3_ID idMarker, int n, double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerSetTransformMatrixByIndex2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerSetTransformMatrixByIndex2(E3_POINTER idMarker, int n, double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng);
        public static E3_ERR E3_MarkerSetTransformMatrixByIndex2(E3_ID idMarker, int n, double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng)
        {
            return e3_MarkerSetTransformMatrixByIndex2(idMarker, n, dMoveX, dMoveY, dCenterX, dCenterY, dRotateAng);
        }
        //E3_API int E3_StartMainLoopIOCheckProcess(E3_ID idMarker, unsigned int PortMask, unsigned int PortValue, unsigned char bEnable, double dIOAvailTime);
        //PortMask：端口掩模，
        //PortValue：端口满足条件之后的比较值
        //IOAvailTime:输入口电平有效时间,单位:ms
        //bEnable:
        //0x1 启动主循环IO检测流程
        //0x0  关闭主循环IO检测流程
        [DllImport("Ezcad3kernel", EntryPoint = "E3_StartMainLoopIOCheckProcess", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_StartMainLoopIOCheckProcess(E3_POINTER idMarker, uint PortMask, uint PortValue, byte bEnable, double dIOAvailTime);
        public static E3_ERR E3_StartMainLoopIOCheckProcess(E3_ID idMarker, uint PortMask, uint PortValue, byte bEnable, double dIOAvailTime)
        {
            return e3_StartMainLoopIOCheckProcess(idMarker, PortMask, PortValue, bEnable, dIOAvailTime);
        }
        //E3_API int E3_MarkerSendOfflineMainProgram(E3_ID pMarker, int nFileCount);
        /// <summary>
        /// 脱机下传
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="nFileCount"></param> 图层个数
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerSendOfflineMainProgram", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerSendOfflineMainProgram(E3_POINTER idMarker, int nFileCount);
        public static E3_ERR E3_MarkerSendOfflineMainProgram(E3_ID idMarker, int nFileCount)
        {
            return e3_MarkerSendOfflineMainProgram(idMarker, nFileCount);
        }

        public const int MAKRFLAG_OFFLINEMODE = 0x002000000;  //脱机模式
        public const int MAKRFLAG_DISFLYSORT = 0x00200000;//禁止飞行打标自动排序  


        /// <summary>
        /// 脱机使能
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="bOffline"></param>
        /// <returns></returns>
        //E3_API int E3_MarkerEnableOffLineMode(E3_ID pMarker, BOOL bOffline);

        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerEnableOffLineMode", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerEnableOffLineMode(E3_POINTER idMarker, bool bOffline);
        public static E3_ERR E3_MarkerEnableOffLineMode(E3_ID idMarker, bool bOffline)
        {
            return e3_MarkerEnableOffLineMode(idMarker, bOffline);
        }

        /// <summary>
        /// 脱机开始标志
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="nFileIndex"></param>
        /// <returns></returns>
        //E3_API int E3_MarkerOffLineModeStart(E3_ID pMarker, int nFileIndex);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerOffLineModeStart", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerOffLineModeStart(E3_POINTER idMarker, int nFileIndex);
        public static E3_ERR E3_MarkerOffLineModeStart(E3_ID idMarker, int nFileIndex)
        {
            return e3_MarkerOffLineModeStart(idMarker, nFileIndex);
        }
        /// <summary>
        /// 脱机结束标志
        /// </summary>
        /// <param name="idMarker"></param>
        /// <returns></returns>
        //E3_API int E3_MarkerOffLineModeStop(E3_ID pMarker);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerOffLineModeStop", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerOffLineModeStop(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerOffLineModeStop(E3_ID idMarker)
        {
            return e3_MarkerOffLineModeStop(idMarker);
        }
        //列表设置循环开始标志
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkertSetLoopStartToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkertSetLoopStartToList(E3_POINTER idMarker);
        public static E3_ERR E3_MarkertSetLoopStartToList(E3_ID idMarker)
        {
            return e3_MarkertSetLoopStartToList(idMarker);
        }
        //列表开始循环
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerDoLoopToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerDoLoopToList(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerDoLoopToList(E3_ID idMarker)
        {
            return e3_MarkerDoLoopToList(idMarker);
        }
        /// <summary>
        /// 列表加工时的输出口
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerWritePortToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerWritePortToList(E3_POINTER idMarker, ushort data);
        public static E3_ERR E3_MarkerWritePortToList(E3_ID idMarker, ushort data)
        {
            return e3_MarkerWritePortToList(idMarker, data);
        }
        //修改加工计数
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerChangeMarkCountToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerChangeMarkCountToList(E3_POINTER idMarker, int n);
        public static E3_ERR E3_MarkerChangeMarkCountToList(E3_ID idMarker, int n)
        {
            return e3_MarkerChangeMarkCountToList(idMarker, n);
        }
        //按笔号标刻指定对象，添加到列表
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerMarkEntToListByPen", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerMarkEntToListByPen(E3_POINTER idMarker, E3_POINTER idEnt, int nPenNo);
        public static E3_ERR E3_MarkerMarkEntToListByPen(E3_ID idMarker, E3_ID idEnt, int nPenNo)
        {
            return e3_MarkerMarkEntToListByPen(idMarker, idEnt, nPenNo);
        }
        //复位加工计数
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerResetMarkCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerResetMarkCount(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerResetMarkCount(E3_ID idMarker)
        {
            return e3_MarkerResetMarkCount(idMarker);
        }
        /// <summary>
        /// 插入延时到列表
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="us">延时时间单位US</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerDelayUsToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerDelayUsToList(E3_POINTER idMarker, double us);
        public static E3_ERR E3_MarkerDelayUsToList(E3_ID idMarker, double us)
        {
            return e3_MarkerDelayUsToList(idMarker, us);
        }
        //得到当前加工计数
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetMarkCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetMarkCount(E3_POINTER idMarker, ref int n);
        public static E3_ERR E3_MarkerGetMarkCount(E3_ID idMarker, ref int n)
        {
            return e3_MarkerGetMarkCount(idMarker, ref n);
        }
        /// <summary>
        /// 标刻一条2D曲线
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="type"></param>
        /// <param name="pen"></param>
        /// <param name="ptNum"></param>
        /// <param name="nFlag"></param>
        /// <param name="ptBuf"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerOneCurveToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerOneCurveToList(Int64 idMarker, int type, int pen, int ptNum, int nFlag, double[,] ptBuf);
        public static E3_ERR E3_MarkerOneCurveToList(Int64 idMarker, int type, int pen, int ptNum, int nFlag, double[,] ptBuf)
        {
            return e3_MarkerOneCurveToList(idMarker, type, pen, ptNum, nFlag, ptBuf);
        }
        /// <summary>
        /// 标刻一条3D曲线
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="type"></param>
        /// <param name="pen"></param>
        /// <param name="ptNum"></param>
        /// <param name="nFlag"></param>
        /// <param name="ptBuf"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerMarkCurveToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerMarkCurveToList(E3_POINTER idMarker, int type, int pen, int ptNum, int nFlag, double[,] ptBuf);
        public static E3_ERR E3_MarkerMarkCurveToList(E3_ID idMarker, int type, int pen, int ptNum, int nFlag, double[,] ptBuf)
        {
            return e3_MarkerMarkCurveToList(idMarker, type, pen, ptNum, nFlag, ptBuf);
        }

        //标刻指定对象，添加到列表
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerMarkEntToList2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerMarkEntToList2(E3_POINTER idMarker, E3_POINTER idEnt);
        public static E3_ERR E3_MarkerMarkEntToList2(E3_ID idMarker, E3_ID idEnt)
        {
            return e3_MarkerMarkEntToList2(idMarker, idEnt);
        }
        //列表下发结束
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerListEnd", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerListEnd(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerListEnd(E3_ID idMarker)
        {
            return e3_MarkerListEnd(idMarker);
        }
        //飞行距离复位   
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerFlyResetDistanceToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerFlyResetDistanceToList(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerFlyResetDistanceToList(E3_ID idMarker)
        {
            return e3_MarkerFlyResetDistanceToList(idMarker);
        }
        //使能列表飞行模式
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerFlyEnableToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerFlyEnableToList(E3_POINTER idMarker, bool bEnable);
        public static E3_ERR E3_MarkerFlyEnableToList(E3_ID idMarker, bool bEnable)
        {
            return e3_MarkerFlyEnableToList(idMarker, bEnable);
        }
        //飞行补偿复位  
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerResetDistanceToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerResetDistanceToList(E3_POINTER idMarker, bool x, bool y);
        public static E3_ERR E3_MarkerResetDistanceToList(E3_ID idMarker, bool x, bool y)
        {
            return e3_MarkerResetDistanceToList(idMarker, x, y);
        }

        //飞行等待指定距离  
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerFlyWaitForDistToList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerFlyWaitForDistToList(E3_POINTER idMarker, double dFlyDist, bool bIsFollowAvail);
        public static E3_ERR E3_MarkerFlyWaitForDistToList(E3_ID idMarker, double dFlyDist, bool bIsFollowAvail)
        {
            return e3_MarkerFlyWaitForDistToList(idMarker, dFlyDist, bIsFollowAvail);
        }
        //等待标刻结束
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerWaitForFinish", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerWaitForFinish(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerWaitForFinish(E3_ID idMarker)
        {
            return e3_MarkerWaitForFinish(idMarker);
        }

        #endregion

        #region Axis


        //初始化所有扩展轴
        [DllImport("Ezcad3kernel", EntryPoint = "E3_InitAllAxis", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_InitAllAxis(E3_POINTER idMarker);
        public static E3_ERR E3_InitAllAxis(E3_ID idMarker)
        {
            return e3_InitAllAxis(idMarker);
        }


        //扩展轴移动到指定坐标位置 axis=0，1，2，3
        [DllImport("Ezcad3kernel", EntryPoint = "E3_AxisMoveTo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_AxisMoveTo(E3_POINTER idMarker, int axis, double dGoalCoor, bool bWaitForMoveFinish);
        public static E3_ERR E3_AxisMoveTo(E3_ID idMarker, int axis, double dGoalCoor, bool bWaitForMoveFinish)
        {
            return e3_AxisMoveTo(idMarker, axis, dGoalCoor, bWaitForMoveFinish);
        }


        //扩展轴回零
        [DllImport("Ezcad3kernel", EntryPoint = "E3_AxisHome", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_AxisHome(E3_POINTER idMarker, int axis, bool bWaitForMoveFinish);
        public static E3_ERR E3_AxisHome(E3_ID idMarker, int axis, bool bWaitForMoveFinish)
        {
            return e3_AxisHome(idMarker, axis, bWaitForMoveFinish);
        }

        //得到扩展轴的当前坐标 
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetAxisCoor", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetAxisCoor(E3_POINTER idMarker, int axis, ref double dCoor);
        public static E3_ERR E3_GetAxisCoor(E3_ID idMarker, int axis, ref double dCoor)
        {
            return e3_GetAxisCoor(idMarker, axis, ref dCoor);
        }
        /// <summary>
        /// 新加
        /// </summary>
        /// <param name="idMarker"></param>
        /// <param name="axis"></param>
        /// <param name="dCoor"></param>
        /// <returns></returns>
        //获取指定轴运动参数
        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetAxisParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetAxisParam(E3_POINTER idMarker,
                    int axis,
                    ref bool bEnable,
                   ref bool bInvert,
                    ref bool bOutNeg,//1=共阴极输出	
                    ref bool bRotaryAxis,
                     ref double dDistPerRound,//转一圈的距离
                     ref double dPulsePerRound,//电机一转脉冲数
                     ref double dMinVel,//最小速度
                     ref double dMaxVel,//最大速度 
                     ref double dAcceleration,
                     ref double dDeceleration,
                     ref double dBacklash,//反向间隙
                   ref bool bEnFeedback,//是否使能编码器
                     ref double dPosErrFollow,//跟随误差	
                   ref bool bSAcc,
                     ref double dJerk,
                   ref bool bEnableSoftLimit,
                     ref double dMinSoftLimit,
                    ref double dMaxSoftLimit,
                 ref bool bEnableHome,
                  ref bool bHomeLowValid,
                  ref bool bHomeDirPos,//正向回零
                    ref bool bHomeFindIndex,
                    ref double dHomePos,//零点的坐标
                     ref double dHomingFindVel,//找零点速度
                   ref double dHomingLeaveVel,//离开零点速度
                    ref bool bHomeFinishGotoPos,
                     ref double dHomeFinishGotoPos,
                    ref bool bEnableLimit,
                    ref bool bLimitLowValid,
                    ref bool bMarkFinishGotoStartPoint
);
        public static E3_ERR E3_GetAxisParam(E3_ID idMarker,
                    int axis,
                    ref bool bEnable,
                   ref bool bInvert,
                    ref bool bOutNeg,//1=共阴极输出	
                    ref bool bRotaryAxis,
                     ref double dDistPerRound,//转一圈的距离
                     ref double dPulsePerRound,//电机一转脉冲数
                     ref double dMinVel,//最小速度
                     ref double dMaxVel,//最大速度 
                     ref double dAcceleration,
                     ref double dDeceleration,
                     ref double dBacklash,//反向间隙
                   ref bool bEnFeedback,//是否使能编码器
                     ref double dPosErrFollow,//跟随误差	
                   ref bool bSAcc,
                     ref double dJerk,
                   ref bool bEnableSoftLimit,
                     ref double dMinSoftLimit,
                    ref double dMaxSoftLimit,
                 ref bool bEnableHome,
                  ref bool bHomeLowValid,
                  ref bool bHomeDirPos,//正向回零
                    ref bool bHomeFindIndex,
                    ref double dHomePos,//零点的坐标
                     ref double dHomingFindVel,//找零点速度
                   ref double dHomingLeaveVel,//离开零点速度
                    ref bool bHomeFinishGotoPos,
                     ref double dHomeFinishGotoPos,
                    ref bool bEnableLimit,
                    ref bool bLimitLowValid,
                    ref bool bMarkFinishGotoStartPoint)
        {
            return e3_GetAxisParam(idMarker,
                    axis,
                    ref bEnable,
                   ref bInvert,
                    ref bOutNeg,//1=共阴极输出	
                    ref bRotaryAxis,
                     ref dDistPerRound,//转一圈的距离
                     ref dPulsePerRound,//电机一转脉冲数
                     ref dMinVel,//最小速度
                     ref dMaxVel,//最大速度 
                     ref dAcceleration,
                     ref dDeceleration,
                     ref dBacklash,//反向间隙
                   ref bEnFeedback,//是否使能编码器
                     ref dPosErrFollow,//跟随误差	
                   ref bSAcc,
                     ref dJerk,
                   ref bEnableSoftLimit,
                     ref dMinSoftLimit,
                    ref dMaxSoftLimit,
                 ref bEnableHome,
                  ref bHomeLowValid,
                  ref bHomeDirPos,//正向回零
                    ref bHomeFindIndex,
                    ref dHomePos,//零点的坐标
                     ref dHomingFindVel,//找零点速度
                   ref dHomingLeaveVel,//离开零点速度
                    ref bHomeFinishGotoPos,
                     ref dHomeFinishGotoPos,
                    ref bEnableLimit,
                    ref bLimitLowValid,
                    ref bMarkFinishGotoStartPoint);
        }

        //获取指定轴运动参数
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetAxisParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetAxisParam(E3_POINTER idMarker,
                    int axis,
                     bool bEnable,
                    bool bInvert,
                     bool bOutNeg,//1=共阴极输出	
                     bool bRotaryAxis,
                      double dDistPerRound,//转一圈的距离
                      double dPulsePerRound,//电机一转脉冲数
                      double dMinVel,//最小速度
                      double dMaxVel,//最大速度 
                     double dAcceleration,
                      double dDeceleration,
                      double dBacklash,//反向间隙
                    bool bEnFeedback,//是否使能编码器
                      double dPosErrFollow,//跟随误差	
                    bool bSAcc,
                      double dJerk,
                    bool bEnableSoftLimit,
                    double dMinSoftLimit,
                    double dMaxSoftLimit,
                bool bEnableHome,
                  bool bHomeLowValid,
                  bool bHomeDirPos,//正向回零
                     bool bHomeFindIndex,
                  double dHomePos,//零点的坐标
                      double dHomingFindVel,//找零点速度
                    double dHomingLeaveVel,//离开零点速度
                    bool bHomeFinishGotoPos,
                     double dHomeFinishGotoPos,
                     bool bEnableLimit,
                    bool bLimitLowValid,
                    bool bMarkFinishGotoStartPoint
);
        public static E3_ERR E3_SetAxisParam(E3_ID idMarker,
                    int axis,
                     bool bEnable,
                  bool bInvert,
                     bool bOutNeg,//1=共阴极输出	
                    bool bRotaryAxis,
                      double dDistPerRound,//转一圈的距离
                     double dPulsePerRound,//电机一转脉冲数
                    double dMinVel,//最小速度
                      double dMaxVel,//最大速度 
                     double dAcceleration,
                     double dDeceleration,
                     double dBacklash,//反向间隙
                   bool bEnFeedback,//是否使能编码器
                      double dPosErrFollow,//跟随误差	
                    bool bSAcc,
                      double dJerk,
                  bool bEnableSoftLimit,
                     double dMinSoftLimit,
                    double dMaxSoftLimit,
                  bool bEnableHome,
                   bool bHomeLowValid,
                  bool bHomeDirPos,//正向回零
                    bool bHomeFindIndex,
                    double dHomePos,//零点的坐标
                    double dHomingFindVel,//找零点速度
                   double dHomingLeaveVel,//离开零点速度
                     bool bHomeFinishGotoPos,
                    double dHomeFinishGotoPos,
                     bool bEnableLimit,
                   bool bLimitLowValid,
                    bool bMarkFinishGotoStartPoint)
        {
            return e3_SetAxisParam(idMarker,
                    axis,
                    bEnable,
                    bInvert,
                     bOutNeg,//1=共阴极输出	
                     bRotaryAxis,
                      dDistPerRound,//转一圈的距离
                      dPulsePerRound,//电机一转脉冲数
                      dMinVel,//最小速度
                      dMaxVel,//最大速度 
                      dAcceleration,
                      dDeceleration,
                      dBacklash,//反向间隙
                    bEnFeedback,//是否使能编码器
                      dPosErrFollow,//跟随误差	
                    bSAcc,
                      dJerk,
                    bEnableSoftLimit,
                      dMinSoftLimit,
                     dMaxSoftLimit,
                  bEnableHome,
                   bHomeLowValid,
                   bHomeDirPos,//正向回零
                     bHomeFindIndex,
                     dHomePos,//零点的坐标
                      dHomingFindVel,//找零点速度
                    dHomingLeaveVel,//离开零点速度
                     bHomeFinishGotoPos,
                      dHomeFinishGotoPos,
                     bEnableLimit,
                     bLimitLowValid,
                     bMarkFinishGotoStartPoint);
        }

        //设置轴点位运动参数
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetAxisSpeedParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SetAxisSpeedParam(E3_POINTER idMarker, int axis, double dStartSpeed, double dMaxSpeed, double dAccSpeed);
        public static E3_ERR E3_SetAxisSpeedParam(E3_ID idMarker, int axis, double dStartSpeed, double dMaxSpeed, double dAccSpeed)
        {
            return e3_SetAxisSpeedParam(idMarker, axis, dStartSpeed, dMaxSpeed, dAccSpeed);
        }


        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetAxisFBCoor", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetAxisFBCoor(E3_POINTER idMarker, int axis, ref double dCoor);
        public static E3_ERR E3_GetAxisFBCoor(E3_ID idMarker, int axis, ref double dCoor)
        {
            return e3_GetAxisFBCoor(idMarker, axis, ref dCoor);
        }

        //判断扩展轴正在运动
        [DllImport("Ezcad3kernel", EntryPoint = "E3_IsAxisMoving", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_IsAxisMoving(E3_POINTER idMarker, int axis, ref bool bIsMoving);
        public static E3_ERR E3_IsAxisMoving(E3_ID idMarker, int axis, ref bool bIsMoving)
        {
            return e3_IsAxisMoving(idMarker, axis, ref bIsMoving);
        }


        //得到扩展轴是否有原点信号(bIsHaveHome),是否已经找过原点（bIsAlreadyFindHome）
        [DllImport("Ezcad3kernel", EntryPoint = "E3_IsAxisHaveHome", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_IsAxisHaveHome(E3_POINTER idMarker, int axis, ref bool bIsHaveHome, ref bool bIsAlreadyFindHome);
        public static E3_ERR E3_IsAxisHaveHome(E3_ID idMarker, int axis, ref bool bIsHaveHome, ref bool bIsAlreadyFindHome)
        {
            return e3_IsAxisHaveHome(idMarker, axis, ref bIsHaveHome, ref bIsAlreadyFindHome);
        }

        //得到扩展轴当前是否有故障
        [DllImport("Ezcad3kernel", EntryPoint = "E3_IsAxisHaveFault", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_IsAxisHaveFault(E3_POINTER idMarker, int axis, ref bool bIsFault);
        public static E3_ERR E3_IsAxisHaveFault(E3_ID idMarker, int axis, ref bool bIsFault)
        {
            return e3_IsAxisHaveFault(idMarker, axis, ref bIsFault);
        }

        public const UInt32 FONT_ATB_TYPE_JSF = 0x0001;       //JczSingle字型
        public const UInt32 FONT_ATB_TYPE_TTF = 0x0002;       //TrueType字型   
        public const UInt32 FONT_ATB_TYPE_DMF = 0x0004;       //DotMatrix字型   
        public const UInt32 FONT_ATB_TYPE_BCF = 0x0008;       //BarCode字型   
        public const UInt32 FONT_ATB_TYPE_SHX = 0x0010;       //shx字型   

        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetAllFontCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR E3_GetAllFontCount(ref int nEntCount);

        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetAllFontRecord", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR E3_GetFontRecord(int id, StringBuilder strName, ref UInt32 attrib);
        #endregion
        #region 连续文本打标模式


        //设置零件补齐标志
        [DllImport("Ezcad3kernel", EntryPoint = "E3_ContinueBufferSetAddMode", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_ContinueBufferSetAddMode(E3_POINTER idMarker, bool b);
        public static E3_ERR E3_ContinueBufferSetAddMode(E3_ID idMarker, bool b)
        {
            return e3_ContinueBufferSetAddMode(idMarker, b);
        }

        //nNum=后面有几个字符串有效
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerContinueBufferSetTextName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerContinueBufferSetTextName(E3_POINTER idMarker, int nNum, string pStr1, string pStr2, string pStr3, string pStr4, string pStr5, string pStr6);
        public static E3_ERR E3_MarkerContinueBufferSetTextName(E3_ID idMarker, int nNum, string pStr1, string pStr2, string pStr3, string pStr4, string pStr5, string pStr6)
        {
            return e3_MarkerContinueBufferSetTextName(idMarker, nNum, pStr1, pStr2, pStr3, pStr4, pStr5, pStr6);
        }

        //nBufferLeftCount 当前缓存区剩余中未开始处理的个数（有可能数据已经处理，当时还未开始加工）,缓存区数据数最大为8
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerContinueBufferGetParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerContinueBufferGetParam(E3_POINTER idMarker, ref int nTotalMarkCount, ref int nBufferLeftCount);
        public static E3_ERR E3_MarkerContinueBufferGetParam(E3_ID idMarker, ref int nTotalMarkCount, ref int nBufferLeftCount)
        {
            return e3_MarkerContinueBufferGetParam(idMarker, ref nTotalMarkCount, ref nBufferLeftCount);
        }
        //增加缓存数据，
        //pStr1=TEXT1对应的字符串
        //pStr2=TEXT2对应的字符串
        //。。。。
        //pStr6=TEXT6对应的字符串
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerContinueBufferAdd", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerContinueBufferAdd(E3_POINTER idMarker, string pStr1, string pStr2, string pStr3, string pStr4, string pStr5, string pStr6);
        public static E3_ERR E3_MarkerContinueBufferAdd(E3_ID idMarker, string pStr1, string pStr2, string pStr3, string pStr4, string pStr5, string pStr6)
        {
            return e3_MarkerContinueBufferAdd(idMarker, pStr1, pStr2, pStr3, pStr4, pStr5, pStr6);
        }
        //设置发送零件数已经结束的标志
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerContinueBufferPartFinish", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerContinueBufferPartFinish(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerContinueBufferPartFinish(E3_ID idMarker)
        {
            return e3_MarkerContinueBufferPartFinish(idMarker);
        }
        //开始缓存区加工，如何缓存区没数据会一直等待数据, 
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerContinueBufferStart", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerContinueBufferStart(E3_POINTER idMarker, E3_POINTER idEM, E3_POINTER idEntParent);
        public static E3_ERR E3_MarkerContinueBufferStart(E3_ID idMarker, E3_ID idEM, E3_ID idEntParent)
        {
            return e3_MarkerContinueBufferStart(idMarker, idEM, idEntParent);
        }

        [DllImport("Ezcad3kernel", EntryPoint = "E3_GetTextByID", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_GetTextByID(E3_POINTER idEnt, StringBuilder strEntName);
        public static E3_ERR E3_GetTextByID(E3_ID idEnt, StringBuilder strEntName)
        {
            return e3_GetTextByID(idEnt, strEntName);
        }
        //清除缓存区
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerContinueBufferClear", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerContinueBufferClear(E3_POINTER idMarker);
        public static E3_ERR E3_MarkerContinueBufferClear(E3_ID idMarker)
        {
            return e3_MarkerContinueBufferClear(idMarker);
        }
        #endregion

        #region 状态信息
        // int E3_MarkerGetSpeedOfFly(E3_ID idMarker, int index, double& dSpeed)
        //获取流水线速度
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetSpeedOfFly", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetSpeedOfFly(E3_POINTER idMarker, int index, ref double dSpeed);
        public static E3_ERR E3_MarkerGetSpeedOfFly(E3_ID idMarker, int index, ref double dSpeed)
        {
            return e3_MarkerGetSpeedOfFly(idMarker, index, ref dSpeed);
        }
        #endregion

        #region 振镜控制
        //跳转到指定坐标
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerJumpTo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerJumpTo(E3_POINTER idMarker, double x, double y, double z, double spd);
        public static E3_ERR E3_MarkerJumpTo(E3_ID idMarker, double x, double y, double z, double spd)
        {
            return e3_MarkerJumpTo(idMarker, x, y, z, spd);
        }

        /// <summary>
        /// 得到振镜坐标
        /// </summary>
        /// <param name="idMarker">板卡Id</param>
        /// <param name="x">当前振镜x坐标</param>
        /// <param name="y">当前振镜y坐标</param>
        /// <param name="z">当前振镜z坐标</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetPos", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetPos(E3_POINTER idMarker, ref double x, ref double y, ref double z);
        public static E3_ERR E3_MarkerGetPos(E3_ID idMarker, ref double x, ref double y, ref double z)
        {
            return e3_MarkerGetPos(idMarker, ref x, ref y, ref z);
        }
        /// <summary>
        /// 得到振镜信息
        /// </summary>
        /// <param name="idMarker">板卡id</param>
        /// <param name="nStatus">状态信息</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetScannerStatus", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetScannerStatus(E3_POINTER idMarker, ref uint nStatus);
        public static E3_ERR E3_MarkerGetScannerStatus(E3_ID idMarker, ref uint nStatus)
        {
            return e3_MarkerGetScannerStatus(idMarker, ref nStatus);
        }

        /// <summary>
        /// 得到反馈的点数
        /// </summary>
        /// <param name="idMarker">卡id</param>
        /// <param name="nCount">反馈的点数量</param>
        /// <returns></returns>
        //E3_API int E3_MarkerGetTracePointCount(E3_ID idMarker, int& nCount);
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetTracePointCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetTracePointCount(E3_POINTER idMarker, ref int nCount);
        public static E3_ERR E3_MarkerGetTracePointCount(E3_ID idMarker, ref int nCount)
        {
            return e3_MarkerGetTracePointCount(idMarker, ref nCount);
        }

        /// <summary>
        /// 得到反馈的点的实际与理论坐标
        /// </summary>
        /// <param name="idMarker">卡ID</param>
        /// <param name="nPos">点索引</param>
        /// <param name="ptWrite">理论坐标</param>
        /// <param name="ptRead">实际坐标</param>
        /// <returns></returns>
        //E3_API int E3_MarkerGetTracePointPos(E3_ID idMarker, int nPos, Pt2d& ptWrite, Pt2d& ptRead);

        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetTracePointPos", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetTracePointPos(E3_POINTER idMarker, int nPos, ref Pt2d ptWrite, ref Pt2d ptRead);
        public static E3_ERR E3_MarkerGetTracePointPos(E3_ID idMarker, int nPos, ref Pt2d ptWrite, ref Pt2d ptRead)
        {
            return e3_MarkerGetTracePointPos(idMarker, nPos, ref ptWrite, ref ptRead);
        }
        #endregion

        #region IO

        //读输入口
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerReadPort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerReadPort(E3_POINTER idMarker, ref ushort data);
        public static E3_ERR E3_MarkerReadPort(E3_ID idMarker, ref ushort data)
        {
            return e3_MarkerReadPort(idMarker, ref data);
        }

        //读输出口状态
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerGetWritePort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerGetWritePort(E3_POINTER idMarker, ref ushort data);
        public static E3_ERR E3_MarkerGetWritePort(E3_ID idMarker, ref ushort data)
        {
            return e3_MarkerGetWritePort(idMarker, ref data);
        }

        //置输出口
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkerWritePort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_MarkerWritePort(E3_POINTER idMarker, ushort data);
        static object lock1 = new object();
        public static E3_ERR E3_MarkerWritePort(E3_ID idMarker, ushort data)
        {

            return e3_MarkerWritePort(idMarker, data);



        }

        #endregion

        #region 3D
        /// <summary>
        /// 分割STL文件
        /// </summary>
        /// <param name="idLayer"></param>
        /// <param name="strStlFile"></param>
        /// <param name="strName"></param>
        /// <param name="bZUpToDown"></param>
        /// <param name="dMinZ"></param>
        /// <param name="dMaxZ"></param>
        /// <param name="dThickness"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SliceStlFile", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SliceStlFile(E3_POINTER idLayer, string strStlFile, string strName, bool bZUpToDown, double dMinZ, double dMaxZ, double dThickness);

        public static E3_ERR E3_SliceStlFile(E3_ID idLayer, string strStlFile, string strName, bool bZUpToDown, double dMinZ, double dMaxZ, double dThickness)
        {
            return e3_SliceStlFile(idLayer, strStlFile, strName, bZUpToDown, dMinZ, dMaxZ, dThickness);
        }


        // int E3_TransormEnt3dRotate(E3_ID idEnt, double dMoveX, double dMoveY, double dMoveZ, double ptAxisX, double ptAxisY, double ptAxisZ, double fRadAngle, double dTol, E3_ID& idNewEnt)
        //3D对象移动旋转
        [DllImport("Ezcad3kernel", EntryPoint = "E3_TransormEnt3dRotate", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_TransormEnt3dRotate(E3_POINTER idEnt, double dMoveX, double dMoveY, double dMoveZ, double ptAxisX, double ptAxisY, double ptAxisZ, double fRadAngle, double dTol, ref E3_POINTER idNewEnt);
        public static E3_ERR E3_TransormEnt3dRotate(E3_ID idEnt, double dMoveX, double dMoveY, double dMoveZ, double ptAxisX, double ptAxisY, double ptAxisZ, double fRadAngle, double dTol, ref E3_ID idNewEnt)
        {

            E3_POINTER id = idEnt;
            E3_ERR err = e3_TransormEnt3dRotate(idEnt, dMoveX, dMoveY, dMoveZ, ptAxisX, ptAxisY, ptAxisZ, fRadAngle, dTol, ref id);
            idNewEnt = id;
            return err;
        }
        /// <summary>
        /// 添加STL文件模型（3D或者2.5D切片使用）
        /// </summary>
        /// <param name="idEM"></param>
        /// <param name="strFile"></param>
        /// <param name="bAddMode"></param>
        /// <param name="bPick"></param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_CreateAddStlFile", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_CreateAddStlFile(E3_POINTER idEM, string strFile, bool bAddMode, bool bPick);
        public static E3_ERR E3_CreateAddStlFile(E3_ID idEM, string strFile, bool bAddMode, bool bPick)
        {
            return e3_CreateAddStlFile(idEM, strFile, bAddMode, bPick);
        }
        #endregion

        #region 用户
        /// <summary>
		/// 获取用户自定义信息
		/// </summary>
		/// <param name="byteInfo">用户自定义信息字节数组.</param>
		/// <param name="bUpdateOnline">是否在线更新.</param>
		/// <returns></returns>
		[DllImport("Ezcad3kernel", EntryPoint = "E3_GetCustomInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_GetCustomInfo(ref byte[] byteInfo, bool bUpdateOnline);
        /// <summary>
        /// 设置用户自定义信息
        /// </summary>
        /// <param name="byteInfo">用户自定义信息字节数组.</param>
        /// <param name="bUpdateOnline">是否在线更新.</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetCustomInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern E3_ERR E3_SetCustomInfo(byte[] byteInfo, bool bUpdateOnline);
        #endregion
        #region 分割
        //nBox表示pBoxs有多少个矩形
        //dSplitErr表示边界计算误差，一般为0.001就行
        //dArcTol表示曲线离散误差，一般为0.01就行
        //E3_API int E3_SplitEntByBox(E3_ID idEnt, SplitBox* pBoxs, int nBoxCount, double dSplitErr, double dArcTol, TCHAR* strNewEntNamePrefix);
        public struct SplitBox
        {
            public double x1;
            public double y1;
            public double x2;
            public double y2;
            public void Build(double dx1, double dy1, double dx2, double dy2)
            {
                x1 = dx1; x2 = dx2; y1 = dy1; y2 = dy2;
            }
        }

        /// <summary>
        /// 分割接口
        /// </summary>
        /// <param name="idEnt">需要分割的对象名称</param>
        /// <param name="pBoxs">分割盒列表</param>
        /// <param name="nBoxCount">分割盒数量</param>
        /// <param name="dSplitErr">边界计算误差</param>
        /// <param name="dArcTol">曲线离散误差</param>
        /// <param name="strNewEntNamePrefix">分割后对象名标识</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SplitEntByBox", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SplitEntByBox(E3_POINTER idEnt, SplitBox[] pBoxs, int nBoxCount, double dSplitErr, double dArcTol, string strNewEntNamePrefix);
        public static E3_ERR E3_SplitEntByBox(E3_ID idEnt, SplitBox[] pBoxs, int nBoxCount, double dSplitErr, double dArcTol, string strNewEntNamePrefix)
        {
            return e3_SplitEntByBox(idEnt, pBoxs, nBoxCount, dSplitErr, dArcTol, strNewEntNamePrefix);
        }



        /// <summary>
        /// 把文本对象分离成一个个字符对象(分离后的一个个对象以这个对象字符命名)
        /// </summary>
        /// <param name="idEnt">指定对象ID</param>
        /// <param name="idEntParent">文本对象分离后放到的层ID（不可以是对象ID）</param>
        /// <param name="bTextLeftToRight">是否从左到右分离</param>
        /// <param name="dArcTol">分离精确度默认0.01即可</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SplitTextToChars", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern E3_ERR e3_SplitTextToChars(E3_POINTER idEnt, E3_POINTER idEntParent, bool bTextLeftToRight, double dArcTol);
        public static E3_ERR E3_SplitTextToChars(E3_ID idEnt, E3_ID idEntParent, bool bTextLeftToRight, double dArcTol)
        {
            return e3_SplitTextToChars(idEnt, idEntParent, bTextLeftToRight, dArcTol);
        }

        #endregion

        #region 校正

        // 标记9点校正标准点，使用默认表刻参数
        //dFieldSize是理论区域尺寸
        //dBoxSize是希望标刻的矩形尺寸
        [DllImport("Ezcad3kernel", EntryPoint = "E3_MarkCorStdPoint2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern int e3_MarkCorStdPoint2(E3_POINTER idMarker, double dFieldSize, double dBoxSize);
        public static int E3_MarkCorStdPoint2(E3_ID idMarker, double dFieldSize, double dBoxSize)
        {
            return e3_MarkCorStdPoint2(idMarker, dFieldSize, dBoxSize);
        }



        /// <summary>
        /// 生成九点校正文件
        /// </summary>
        /// <param name="idMarker"></param> 卡ID
        /// <param name="strNewFile"></param>需要保存的校正文本名字
        /// <param name="nPointMode"></param>九点的排列模式 0-7
        /// <param name="dPts"></param>是九点坐标
        /// <param name="dFieldSize"></param>理论区域尺寸
        /// <param name="dBoxSize"></param>希望标刻的矩形尺寸
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_FunCF9", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        static extern bool e3_FunCF9(E3_POINTER idMarker, string strNewFile, int nPointMode, Pt2d[] dPts, double dFieldSize, double dBoxSize);
        public static bool E3_FunCF9(E3_ID idMarker, string strNewFile, int nPointMode, Pt2d[] dPts, double dFieldSize, double dBoxSize)
        {
            return e3_FunCF9(idMarker, strNewFile, nPointMode, dPts, dFieldSize, dBoxSize);
        }

        /// <summary>
        /// 生成多点校正文件
        /// </summary>
        /// <param name="strOldCorFile"></param> 老的校正文件路径
        /// <param name=strNewCorFile"></param>新的校正文件路径
        /// <param name="gridrealPt"></param> 多点坐标
        /// <param name="nCountX"></param> 多点X方向个数
        /// <param name="nCountY"></param> 多点Y方向个数
        /// <param name="dGridLBX"></param> 点阵理论坐标左下角X坐标
        /// <param name="dGridLBY"></param>点阵理论坐标左下角Y坐标
        /// <param name="dGridDisX"></param> 点阵理论X方向间距
        /// <param name="dGridDisY"></param>  点阵理论X方向间距
        /// <returns></returns>
        [DllImport("Ezcad3Kernel", EntryPoint = "E3_FunCF", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool E3_MultiCor2(string strOldCorFile, string strNewCorFile, Pt2d[] gridrealPt, int nCountX, int nCountY, double dGridLBX, double dGridLBY, double dGridDisX, double dGridDisY);
        #endregion

        #region 多头同步
        /// <summary>
        /// 设置多头同步
        /// </summary>
        /// <param name="b">TRUE 使能多头同步</param>
        /// <param name="input">同步输入端口</param>
        /// <param name="output">同步输出端口</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetMultiCardSyn", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int E3_SetMultiCardSyn(bool b, int input, int output);

        /// <summary>
        /// 设置是否逐个曲线同步
        /// </summary>
        /// <param name="b">TRUE 按曲线同步 FALSE 按对象同步</param>
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetMultiCardSynEveryCurve", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int E3_SetMultiCardSynEveryCurve(bool b);

        /// <summary>
        /// 设置完成同步
        /// </summary>
        /// <param name="b">TRUE 使能完成同步</param>       
        /// <returns></returns>
        [DllImport("Ezcad3kernel", EntryPoint = "E3_SetMultiCardSynWhenFinish", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int E3_SetMultiCardSynWhenFinish(bool b);
        #endregion
    }
}
