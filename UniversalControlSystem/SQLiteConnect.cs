using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI;
using NPOI.POIFS.FileSystem;

namespace UniversalControlSystem
{


    public static class SQLiteConnect
    {
        public static SQLiteConnection scWebshop;
        public static SQLiteDataReader sqlReader;
        public static DataSet ds;
        public static SQLiteDataAdapter myAdapter;
        public static SQLiteCommand myCommand;

        public static void OpenSqliteConnection()
        {
            string strConString = @"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Productiondata.db" + ";Version=3";
            try
            {
                scWebshop = new SQLiteConnection(strConString);
                scWebshop.Open();

            }
            catch (Exception error)
            {
               // MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.连接数据库异常.ToString() + "\r\n" + error);
            }
        }
        public static int InsertoData(string Table_Name, string sn)
        {
            object intoPro = new object();
            lock (intoPro)
            {
                DateTime time = DateTime.Now;
                try
                {
                    string str = "INSERT INTO " + Table_Name + "('SN') values('" + sn + "')";
                    // string strd = "INSERT INTO  L_Clear_Data('SN')VALUES('335335')";
                    if (executeSQL(str) == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                
                }
                catch (Exception error)
                {
                    return -1;
                    //  MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.改变数据库数据异常.ToString() + "\r\n" + error);
                }
            }

        }
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sql"></param>
        ///// <returns></returns>
        public static DataSet getDataSet(string sql)
        {
            object objget = new object();
            lock (objget)
            {
                OpenSqliteConnection();
                myAdapter = new SQLiteDataAdapter(sql, scWebshop);
                ds = new DataSet();
                int i = myAdapter.Fill(ds);
                try
                {
                    myAdapter.Dispose();
                    scWebshop.Close();
                }
                catch (Exception error)
                {
                    //MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
                }
                if (i >= 0)
                    return ds;
                else
                    return null;
            }
          
        }
        /// <summary>
        /// 数据增删
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public static int executeSQL(string Sql)
        {
            object obj = new object();
            SQLiteCommand MyCommand=null;
            lock (obj)
            {
                int intRows = 0;
                try
                {
                    OpenSqliteConnection();
                    MyCommand = new SQLiteCommand(Sql, scWebshop);                 
                    intRows = MyCommand.ExecuteNonQuery();
                    MyCommand.Dispose();
                    scWebshop.Close();
                    intRows = 0;
                }
                catch (Exception error)
                {
                    MyCommand.Dispose();
                    scWebshop.Close();
                    intRows = -1;
                    //MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.改变数据库数据异常.ToString() + "\r\n" + error);
                }
                return intRows;
            }
        }
        /// <summary>
        /// 数据按条件查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public  static string  getQuery(string sql,string res)
        {
            string result = "";
            object obj = new object();
            lock(obj)
            {
                try
                {
                    OpenSqliteConnection();
                    myCommand = new SQLiteCommand(sql, scWebshop);
                    sqlReader = myCommand.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        result = sqlReader[res].ToString();
                    }
                    myCommand.Dispose();
                    scWebshop.Close();
                    return result;
                }
                catch (Exception error)
                {
                   // MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
                    myCommand.Dispose();
                    scWebshop.Close();
                    return result;
                }
            }
           
           
        }
        /// <summary>
        /// 数据按条件查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<string> _getQuery(string sql, string res)
        {
            List<string> resultS = new List<string>();
            string result = "";
            object obj = new object();
            lock (obj)
            {
                try
                {
                    OpenSqliteConnection();
                    myCommand = new SQLiteCommand(sql, scWebshop);
                    sqlReader = myCommand.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        result = sqlReader[res].ToString();
                        resultS.Add(result);
                    }
                    myCommand.Dispose();
                    scWebshop.Close();
                    return resultS;
                }
                catch (Exception error)
                {
                    //  MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
                    myCommand.Dispose();
                    scWebshop.Close();
                    return resultS;
                }
            }


        }
        public static List<string> getQueryList(string sql, string res)
        {
            List<string> resultList=new List<string> { };

            object obj = new object();
            lock (obj)
            {
                try
                {
                    OpenSqliteConnection();
                    myCommand = new SQLiteCommand(sql, scWebshop);
                    sqlReader = myCommand.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        resultList.Add(sqlReader[res].ToString());
                    }
                    myCommand.Dispose();
                    scWebshop.Close();
                    return resultList;
                }
                catch (Exception error)
                {
                    resultList.Clear();
                   // MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
                    myCommand.Dispose();
                    scWebshop.Close();
                    return resultList;
                }
            }


        }
        public static List<string> getQueryList(string sql, string res, out bool _RunRes)
        {
            List<string> resultList = new List<string> { };
            _RunRes = false;
            object obj = new object();
            lock (obj)
            {
                try
                {
                    OpenSqliteConnection();
                    myCommand = new SQLiteCommand(sql, scWebshop);
                    sqlReader = myCommand.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        resultList.Add(sqlReader[res].ToString());
                    }
                    myCommand.Dispose();
                    scWebshop.Close();
                    _RunRes = true;
                    return resultList;
                }
                catch (Exception error)
                {
                    _RunRes = false;
                    resultList.Clear();
                    // MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
                    myCommand.Dispose();
                    scWebshop.Close();
                    return resultList;
                }
            }
        }
        public static bool getResult(string txt)
        {
            bool result = false;
            try
            {
                string str = "select Enable from InterfaceManage where InterfaceName='" + txt + "' and Permissions='" + FormUserLogoin.userpermissions + "'";
                result =Convert.ToBoolean(getQuery(str, "Enable"));
                return result;              
            }
            catch (Exception ex)
            {               
                return false;
            }
        }
        public static void InsertoProducion(string sn, string state, string workstation)
        {
            object intoPro = new object();
            lock (intoPro)
            {
                DateTime time = DateTime.Now;
                try
                {
                    string str = "insert into productiondata (SN,State,WorkStation,Time) value('" + sn + "','" + state + "','" + workstation + "','" + time.ToString("s") + "')";
                    int i = executeSQL(str);
                    //if (!(i > 0))
                    //{
                    //    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.改变数据库数据异常.ToString());
                    //}
                }
                catch (Exception error)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.改变数据库数据异常.ToString() + "\r\n" + error);
                }
            }

        }
        /// <summary>
        /// 添加报警信息到数据库
        /// </summary>
        /// <param name="Alarmlevel"></param>
        /// <param name="AlarmMessage"></param>
        public static void InsertoAlarm(string Alarmlevel, string AlarmMessage)
        {
            object intoAlaram = new object();
            lock (intoAlaram)
            {
                DateTime time = DateTime.Now;
                try
                {
                    string str = "insert into Alarm(AlarmLevel,AlarmMessage,StartTime)values('" + Alarmlevel + "','" + AlarmMessage + "','" + time.ToString("s") + "')";
                    int i = executeSQL(str);
                    if (!(i > 0))
                    {
                        MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.改变数据库数据异常.ToString());
                    }
                }
                catch (Exception error)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.改变数据库数据异常.ToString() + "\r\n" + error);
                }
            }

        }
    }
    public static class Excelhelper
    {
      
        private static IWorkbook workbook = null;
        private static FileStream fs = null;
        private static bool disposed;

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>      
        /// <param name="fileName">要导入的excel的sheet的路径</param>      
        public static int DataTableToExcel(List<string> listHeard, List<string> list, string Path, string fileName)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            bool isColumnWritten = false;
            IRow Rows;
            try
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                string creatPath = Path + "\\" + fileName;
                if (!File.Exists(creatPath))
                {
                    isColumnWritten = true;
                }
                if (isColumnWritten == true)
                {
                    using (fs = new FileStream(creatPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {

                        if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                            workbook = new XSSFWorkbook();
                        else if (fileName.IndexOf(".xls") > 0) // 2003版本
                            workbook = new HSSFWorkbook();

                        if (workbook != null)
                        {
                            sheet = workbook.CreateSheet("生产信息");
                        }
                        else
                        {
                            return -1;
                        }
                        IRow rows = sheet.CreateRow(0);
                        for (j = 0; j < listHeard.Count; ++j)
                        {
                            rows.CreateCell(j).SetCellValue(listHeard[j]);
                        }
                        count = 1;
                        Rows = sheet.CreateRow(sheet.LastRowNum + 1);
                        for (j = 0; j < list.Count; ++j)
                        {
                            Rows.CreateCell(j).SetCellValue(list[j].ToString());
                        }
                        workbook.Write(fs); //写入到excel
                        return count;

                    }
                }
                else
                {
                    //读取流
                    using (FileStream fs = new FileStream(creatPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        POIFSFileSystem ps = new POIFSFileSystem(fs);//需using NPOI.POIFS.FileSystem;
                        IWorkbook workbook = new HSSFWorkbook(ps);
                        sheet = workbook.GetSheetAt(0);//获取工作表
                        IRow row = sheet.GetRow(0); //得到表头
                        //写入流
                        using (FileStream fout = new FileStream(creatPath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                        {
                            row = sheet.CreateRow((sheet.LastRowNum + 1));//在工作表中添加一行
                            for (j = 0; j < list.Count; ++j)
                            {
                                row.CreateCell(j).SetCellValue(list[j].ToString());
                            }
                            workbook.Write(fout);//写入文件
                            workbook = null;
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public static int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten, string fileName)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            try
            {

                fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();


                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
