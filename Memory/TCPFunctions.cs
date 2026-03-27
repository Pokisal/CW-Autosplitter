using CWAutosplitter;
using CWAutosplitter.UI.Components;
using LiveSplit.ComponentUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CWAutosplitter.Memory
{
    public class TCPFunctions
    {
        public static TcpClient tcp;
        public static bool ParseIP(string input)
        {
            IPAddress address;
            return IPAddress.TryParse(input, out address) && address.ToString() == input;
        }
        public static byte[] RequestMemory(uint Address, uint BaseLength, dynamic OldValue)
        {
            try
            {
                if (!ParseIP(AutosplitterSettings.SavedIP)) return new byte[BaseLength];
                uint Chunks = BaseLength / 1024;
                uint Remainder = BaseLength % 1024;
                byte[] Data = new byte[BaseLength];
                for (uint i = 0; i <= Chunks; ++i)
                {
                    uint Length;
                    tcp = new TcpClient();
                    tcp.SendTimeout = 1000;
                    tcp.ReceiveTimeout = 1000;
                    tcp.Client.Connect(AutosplitterSettings.SavedIP, 730);
                    if (i == Chunks)
                    {
                        Length = Remainder;
                    }
                    else
                    {
                        Length = 1024;
                    }
                    // Get response and flush the connection
                    var ConnectionStatusResponse = new byte[65536];
                    tcp.Client.Receive(ConnectionStatusResponse);
                    tcp.Client.Send(Encoding.ASCII.GetBytes(string.Format("GETMEMEX ADDR={0} LENGTH={1}\r\n", Address + (0x400 * i), 1024)));
                    var MemoryStatusResponse = new byte[1024];
                    tcp.Client.Receive(MemoryStatusResponse);
                    byte[] Buffer = new byte[Length + 2];
                    tcp.Client.Receive(Buffer);
                    Array.Copy(Buffer, 2, Data, 0 + (1024 * i), Length);
                    tcp.Client.Send(Encoding.UTF8.GetBytes("\r\nBYE"));
                    tcp.Close();
                }
                return Data;
            }
            catch (Exception err)
            {
                if (tcp.Connected) { tcp.Close(); }
                Utility.Log(err);
                return OldValue;
            }
        }
    }
}