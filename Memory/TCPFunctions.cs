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
        public static byte[] RequestMemory(uint address, uint baselength, dynamic variable)
        {
            try
            {
                if (!ParseIP(AutosplitterSettings.SavedIP)) return new byte[baselength];
                uint divisions = baselength / 1024;
                uint remainder = baselength % 1024;
                byte[] data = new byte[baselength];
                for (uint i = 0; i <= divisions; ++i)
                {
                    uint length;
                    var tcp = new TcpClient();
                    tcp.ReceiveTimeout = 1000;
                    tcp.SendTimeout = 1000;
                    if (!tcp.Client.ConnectAsync(AutosplitterSettings.SavedIP, 730).Wait(1000))
                    {
                        tcp.Close();
                        return variable;
                    }
                    if (i == divisions)
                    {
                        length = remainder;
                    }
                    else
                    {
                        length = 1024;
                    }
                    var response1 = new byte[1024];
                    var response2 = new byte[1024];
                    tcp.Client.Receive(response1);
                    tcp.Client.Send(Encoding.ASCII.GetBytes(string.Format("GETMEMEX ADDR={0} LENGTH={1}\r\n", address + (0x400 * i), 1024)));
                    tcp.Client.Receive(response2);
                    byte[] data2 = new byte[length + 2];
                    tcp.Client.Receive(data2);
                    Array.Copy(data2, 2, data, 0 + (1024 * i), length);
                    tcp.Close();
                }
                return data;
            }
            catch (SocketException)
            {
                return variable;
            }
        }
    }
}
