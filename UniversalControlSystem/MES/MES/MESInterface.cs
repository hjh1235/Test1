using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface MESInterface
    {
        string Login(string sn,string code);
        string CheckStation();
        string UploadStation();
        string getResult();
        string getSn();
        string UploadImage();
    }
}
