using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDClass;

namespace RFIDClass
{

    public interface IRFIDReader
    {
        Factory RFIDFactory { get; set; }
        string Name { get; set; }
        int NodeID { get; set; }                              
        RFIDClass.RFIDconnection Connection { get; set; }
        bool Command(byte[ ] cmd);
        byte[ ] RelayCommand(byte[ ] cmd);
        void connect();

    }
}
