using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDClass
{
    public abstract  class RFIDReader:IRFIDReader
    {
        #region IRFIDReader 成員

        private Factory _RFIDFactory;
        public Factory RFIDFactory
        {
            get
            {
               // throw new NotImplementedException();
                return _RFIDFactory;
            }
            set
            {
              //  throw new NotImplementedException();
                _RFIDFactory = value;
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
                //throw new NotImplementedException();
            }
            set
            {
                _Name = value;
                //throw new NotImplementedException();
            }
        }

        private int _nodeID;
        public int NodeID
        {
            get
            {
                return _nodeID;
               // throw new NotImplementedException();
            }
            set
            {
                _nodeID = value;
                //throw new NotImplementedException();
            }
        }

        private bool _IsConnected=false;
        public  bool IsConnected
        {
            get
            {
                return _IsConnected;
               // throw new NotImplementedException();
            }

        }
        private RFIDconnection _Connection;
        public RFIDconnection Connection
        {
            get
            {
                return _Connection;
              //  throw new NotImplementedException();
            }
            set
            {
                _Connection = value;
                //throw new NotImplementedException();
            }
        }

        public bool Command(byte[ ] cmd)
        {
          //  throw new NotImplementedException();
           var result= RelayCommand(cmd);
           return result.Any() ? true : false;
        }

        public byte[ ] RelayCommand(byte[ ] cmd)
        {
            //TODO:撰寫RFID函式
            throw new NotImplementedException();
        }

        

        public RFIDReader(Connection_Type type)
        {
            this.Connection =RFIDconnection.GetConn(type);
        }

        public void connect()
        {
            switch ( this._Connection.TYPE )
            {
                case Connection_Type.TCPIP:
                    if (this._Connection.ServerIP==null)
                    {
                        throw new RFIDClass.NoServerIPException();
                    }
                    this._Connection.TCP.Connect(this._Connection.ServerIP);
                    break;
                case Connection_Type.COM:
                    this._Connection.COM.Open();
                    break;
                default:
                    break;
            }
          //  throw new NotImplementedException();
        }

        #endregion
    }
}
