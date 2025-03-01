using CWAutosplitter.Memory;
using LiveSplit.ComponentUtil;
using LiveSplit.Web.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Dynamic;
using LiveSplit.Options;
using System.Windows.Forms;

namespace CWAutosplitter.UI.Components
{
    public partial class CWAutosplitter : LiveSplit.UI.Components.IComponent
    {

        public byte[] TitleID = new byte[4] { 0, 0, 0, 0 };
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

        public bool Update()
        {
            OldCutsceneIDString = CutsceneIDString;
            CutsceneID = TCPFunctions.RequestMemory(0xC809393C, 4);
            InLoad = TCPFunctions.RequestMemory(0xC8093A38, 1).ElementAt(0) != 0;
            InCutscene = TCPFunctions.RequestMemory(0xC837336C, 1).ElementAt(0) != 0;
            CutsceneIDString = Encoding.UTF8.GetString(CutsceneID);
            return true;
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
            if (CutsceneIDString == "800_" && OldCutsceneIDString != "800_")
            {
                Splits.Clear();
                return true;
            }
            return false;
        }

        public void OnReset()
        {
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
