using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class DataGroup : ImageTool
    {
        public string _DataGroup { set; get; }
        public object Data { set; get; }
        public string Choose { set; get; }
        private static Object o = new object();
        public bool DataGroupFun(string Name, object Data, string Choose)
        {
            bool sta = false;
            lock (o)
            {
                if (Choose == "检测")
                {
                    if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Group_ControlDataTpye == "BOOL")
                    {
                        Data = bool.Parse(Data.ToString());
                        bool _stas = Convert.ToBoolean(Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Date);
                        bool stas = (bool)_stas;
                        if (stas == (bool)Data)
                        {
                            sta = true;
                        }
                        else
                        {
                            // sta = false;
                        }
                    }
                    else if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Group_ControlDataTpye == "STRING")
                    {
                        if ((string)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Date == Data.ToString())
                        {
                            sta = true;
                            // break;
                        }
                        else
                        {
                            sta = false;
                        }
                    }
                    else if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Group_ControlDataTpye == "DOUBLE")
                    {
                        Data = double.Parse(Data.ToString());
                        double _Data = double.Parse(Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Date.ToString());
                        if (_Data == (double)Data)
                        {
                            sta = true;
                            //  break;
                        }
                        else
                        {
                            sta = false;
                        }
                    }
                    else if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Group_ControlDataTpye == "SHORT")
                    {
                        Data = short.Parse(Data.ToString());
                        if ((short)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Date == (short)Data)
                        {
                            sta = true;
                            //   break;
                        }
                        else
                        {
                            sta = false;
                        }
                    }
                    else if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Group_ControlDataTpye == "LONG")
                    {
                        Data = long.Parse(Data.ToString());
                        long _Data = long.Parse(Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Date.ToString());
                        if (_Data == (long)Data)
                        {
                            sta = true;
                            //  break;
                        }
                        else
                        {
                            sta = false;
                        }
                    }
                    if (!Program.bAuto || Program.bStop || Program.bEStop)
                    {
                        sta = true;
                        //  break;
                    }
                    if (Program.bInt == true)
                    {
                        return true;

                    }

                }
                else
                {
                    if (Data.ToString().ToLower() == "true")
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Date = true;
                    }

                    else
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[Name].Date = false;
                    }
                    sta = true;
                }
            }
            return sta;
        }
    }
}
