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
        public static string TitleID = "58410B00";

        public static bool IsGameRunning()
        {
            string Result = Encoding.ASCII.GetString(RequestMemory(0xC201F3DF, 8, (string)default));
            return Result == TitleID;
        }
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
                    var tcp = new TcpClient();
                    tcp.ReceiveTimeout = 1000;
                    tcp.SendTimeout = 1000;
                    if (!tcp.Client.ConnectAsync(AutosplitterSettings.SavedIP, 730).Wait(1000))
                    {
                        tcp.Close();
                        return OldValue;
                    }
                    if (i == Chunks)
                    {
                        Length = Remainder;
                    }
                    else
                    {
                        Length = 1024;
                    }
                    var ConnectionStatusResponse = new byte[1024];
                    tcp.Client.Receive(ConnectionStatusResponse);
                    tcp.Client.Send(Encoding.ASCII.GetBytes(string.Format("GETMEMEX ADDR={0} LENGTH={1}\r\n", Address + (0x400 * i), 1024)));
                    var MemoryStatusResponse = new byte[1024];
                    tcp.Client.Receive(MemoryStatusResponse);
                    byte[] Buffer = new byte[Length + 2];
                    tcp.Client.Receive(Buffer);
                    Array.Copy(Buffer, 2, Data, 0 + (1024 * i), Length);
                    tcp.Close();
                }
                return Data;
            }
            catch (SocketException)
            {
                return OldValue;
            }
        }
    }
}
