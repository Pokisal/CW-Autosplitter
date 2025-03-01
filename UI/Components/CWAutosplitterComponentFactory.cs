using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CWAutosplitter.UI.Components
{
    public class CWAutosplitterFactory : IComponentFactory
    {
        public string ComponentName => "CW Autosplitter";

        public string Description => "Component based autosplitter";

        public ComponentCategory Category => ComponentCategory.Control;

        public string UpdateName => ComponentName;

        public string XMLURL => String.Empty;

        public string UpdateURL => String.Empty;

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public IComponent Create(LiveSplitState state) => new CWAutosplitter(state);
    }
}
