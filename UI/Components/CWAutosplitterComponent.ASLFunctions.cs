using CWAutosplitter.Memory;
using LiveSplit.ComponentUtil;
using LiveSplit.Options;
using LiveSplit.Web.Share;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWAutosplitter.UI.Components
{
    public partial class CWAutosplitter : LiveSplit.UI.Components.IComponent
    {
        private static ProcessMemory GameMemory;
        private static Process GameProcess;

        public long RamBase = 0x200000000;

        public byte[] CutsceneID = new byte[4] { 0, 0, 0, 0 };
        public bool InLoad;
        public bool InCutscene;
        public bool OldInLoad;
        public bool OldInCutscene;
        public string CutsceneIDString;
        public string OldCutsceneIDString;

        public HashSet<string> Splits = new HashSet<string>();
        public Dictionary<string, string> Cutscenes = new Dictionary<string, string>
          {{"807_",  "Case1-1"},
           {"808_",  "Case1-2"},
           {"809_",  "Case2-1"},
           {"811_",  "Case2-2"},
           {"812_",  "Case2-3"},
           {"813_",  "Case3-1"},
           {"814_",  "Case3-2"},
           {"816_",  "Harjit"} };
        public void Startup()
        {
        }

        public void Init()
        {
        }

        public IntPtr GetIntPtr(long input)
        {
            if (input >= 0xC0000000)
            {
                input += 0x4E000;
            }
            return (IntPtr)(RamBase + input);
        }

        public void StartProcessActions()
        {
            if (GameMemory != null && !GameMemory.CheckProcess())
            {
                GameMemory = null;
                return;
            }
            if (GameMemory == null)
            {
                GameMemory = new ProcessMemory(GameProcess);
            }
            if (!GameMemory.IsProcessStarted())
            {
                GameMemory.StartProcess();
            }
        }

        public void Update()
        {
            OldCutsceneIDString = CutsceneIDString;
            Process[] processesByName = Process.GetProcessesByName("xenia");
            Process[] processesByName2 = Process.GetProcessesByName("xenia_canary");
            processesByName = processesByName.Concat(processesByName2).ToArray();

            if (processesByName.Length != 0 && (GameProcess == null || processesByName[0].Id.ToString("X8") != GameProcess.Id.ToString("X8")))
            {
                GameProcess = processesByName[0];
            }

            if (processesByName.Length == 0)
            {
                CutsceneID = TCPFunctions.RequestMemory(0xC809393C, 4, CutsceneID);
                InLoad = TCPFunctions.RequestMemory(0xC8093A38, 1, BitConverter.GetBytes(InLoad)).ElementAt(0) != 0;
                InCutscene = TCPFunctions.RequestMemory(0xC837336C, 1, BitConverter.GetBytes(InCutscene)).ElementAt(0) != 0;
                CutsceneIDString = Encoding.UTF8.GetString(CutsceneID);
            }
            else
            {
                StartProcessActions();
                try
                {
                    var offset = GameMemory.ReadShort(GetIntPtr(0x82000000));

                    if (offset != 23117)
                    {
                        RamBase = 0x100000000;
                    }

                    CutsceneIDString = GameMemory.ReadStringAscii(GetIntPtr(0xC809393C), 4);
                    InLoad = GameMemory.ReadByte(GetIntPtr(0xC8093A38)) != 0;
                    InCutscene = GameMemory.ReadByte(GetIntPtr(0xC837336C)) != 0;
                }
                catch (NullReferenceException)
                {
                    return;
                }
            }
        }

        public bool Start()
        {
            if (OldCutsceneIDString == "801_" && CutsceneIDString != "801_")
            {
                return true;
            }
            return false;
        }

        public void OnStart()
        {
        }

        public bool IsLoading()
        {
            if (InCutscene || InLoad)
            {
                return true;
            }
            return false;
        }

        public TimeSpan? GameTime()
        {
            return null;
        }

        public bool Reset()
        {
            if ((CutsceneIDString == "800_" && OldCutsceneIDString != "800_") || (CutsceneIDString == "800a" && OldCutsceneIDString != "800a"))
            {
                return true;
            }
            return false;
        }

        public void OnReset()
        {
            Splits.Clear();
        }

        public bool Split()
        {
            for (int i = 0; i < Cutscenes.Count; ++i)
            {
                if (CutsceneIDString == Cutscenes.Keys.ElementAt(i) && Settings.ContainsSplit(Cutscenes.Values.ElementAt(i)) && !Splits.Contains(Cutscenes.Values.ElementAt(i)))
                {
                    Splits.Add(Cutscenes.Values.ElementAt(i));
                    return true;
                }
            }
            return false;
        }

        public void OnSplit()
        {
        }

        public void Exit()
        {
        }

        public void Shutdown()
        {
        }

    }
}
