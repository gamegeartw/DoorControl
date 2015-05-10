using RFIDClass;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RFIDClass
{
    /// <summary>
    /// RFIDReader的連線工作
    /// </summary>
    public class RFIDconnection
    {
        public Connection_Type TYPE { get; set; }

        public SerialPort COM { get; set; }

        public TcpClient TCP { get; set; }

        public IPEndPoint ServerIP { get; set; }

        private static RFIDconnection _RFIDConnection;

        public RFIDconnection()
        {
        }

        /// <summary>
        /// 連線初始化
        /// </summary>
        private static void init()
        {
            _RFIDConnection = new RFIDconnection();
        }

        /// <summary>
        /// 取得Connection物件(如果指定為TCP/IP則須同步指定ServerIP)
        /// </summary>
        /// <param name="type">TCP/IP或COM</param>
        /// <param name="args">Tcpclient 或SerialPort</param>
        /// <returns>Connection</returns>

        public static RFIDconnection GetConn(Connection_Type type, params object[] args)
        {
            init();
            _RFIDConnection.TYPE = type;
            switch (type)
            {
                case Connection_Type.TCPIP:
                    try
                    {
                        _RFIDConnection.ServerIP = (IPEndPoint)args[0];
                        _RFIDConnection.TCP = new TcpClient();
                    }
                    catch (Exception)
                    {
                        throw new NoServerIPException();
                    }

                    break;

                case Connection_Type.COM:
                    if (args[0].GetType().ToString().Contains("String"))
                        _RFIDConnection.COM = new SerialPort((string)args[0]);
                    else
                        _RFIDConnection.COM = (SerialPort)args[0];

                    break;

                default:
                    break;
            }
            return _RFIDConnection;
        }

        /// <summary>
        /// 取得Connection物件
        /// </summary>
        /// <param name="serverIP">傳入ServerIP</param>
        /// <returns>Connection 連線(TCP/IP)</returns>
        public RFIDconnection GetConn(IPEndPoint serverIP)
        {
            return GetConn(RFIDClass.Connection_Type.TCPIP, serverIP);
        }

        /// <summary>
        /// 取得Connection物件
        /// </summary>
        /// <param name="COM">COM序列埠</param>
        /// <returns>Connection 連線(COM序列埠)</returns>
        public RFIDconnection GetConn(SerialPort COM)
        {
            return GetConn(RFIDClass.Connection_Type.COM);
        }
    }
}