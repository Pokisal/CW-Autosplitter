using CWAutosplitter.Memory;
using LiveSplit.Options;
using LiveSplit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CWAutosplitter.UI.Components
{
    public partial class AutosplitterSettings : UserControl
    {
        public readonly Dictionary<string, bool> DefaultSettings = new Dictionary<string, bool>()
        {
            { "Splits", true },
            { "Case1-1", true },
            { "Case1-2", true },
            { "Case2-1", true },
            { "Case2-2", true },
            { "Case2-3", true },
            { "Case3-1", true },
            { "Case3-2", true },
            { "Harjit", true }
        };

        public bool Start => cbxStart.Checked;
        public bool Split => cbxSplit.Checked;
        public bool Reset => cbxReset.Checked;

        public static string SavedIP;

        public bool this[string name]
        {
            get
            {
                foreach (TreeNode tnd in GetAllNodes(tvwSettings))
                {
                    if (tnd.Name == name)
                    {
                        return GetNodeValue(tnd);
                    }
                }
                return default;
            }
        }

        public AutosplitterSettings()
        {
            InitializeComponent();
        }

        public LayoutMode Mode { get; set; }

        public bool ContainsSplit(string input)
        {
            return this[input];
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settings = document.CreateElement("Settings");

            settings.AppendChild(GetSetting(document, "Start", cbxStart));
            settings.AppendChild(GetSetting(document, "Split", cbxSplit));
            settings.AppendChild(GetSetting(document, "Reset", cbxReset));
            settings.AppendChild(GetSetting(document, "Settings", tvwSettings));
            settings.AppendChild(GetSetting(document, "SavedIP", SavedIP));
            return settings;
        }

        public void SetSettings(XmlNode settings)
        {
            SuspendLayout();
            SetSetting(settings.SelectSingleNode(".//Start"), cbxStart);
            SetSetting(settings.SelectSingleNode(".//Split"), cbxSplit);
            SetSetting(settings.SelectSingleNode(".//Reset"), cbxReset);
            SetSetting(settings.SelectSingleNode(".//Settings"), tvwSettings);
            SetSetting(settings.SelectSingleNode(".//Settings"), tvwSettings);
            SetSetting(settings.SelectSingleNode(".//SavedIP"));
            ResumeLayout(true);
        }

        private XmlElement GetSetting(XmlDocument document, string name, CheckBox control)
        {
            var element = document.CreateElement(name ?? control.Name);
            element.SetAttribute("Value", control.Checked.ToString());
            return element;
        }

        private XmlElement GetSetting(XmlDocument document, string name, TreeView control)
        {
            var element = document.CreateElement(name ?? control.Name);
            foreach (TreeNode node in GetAllNodes(control))
            {
                element.AppendChild(GetSetting(document, node.Name, node));
            }
            return element;
        }

        private XmlElement GetSetting(XmlDocument document, string name, string value)
        {
            var element = document.CreateElement(name ?? value);
            element.SetAttribute("Value", value);
            return element;
        }

        private XmlElement GetSetting(XmlDocument document, string name, TreeNode control)
        {
            var element = document.CreateElement(name ?? control.Name);
            element.SetAttribute("Value", control.Checked.ToString());
            return element;
        }

        private void SetSetting(XmlNode setting, CheckBox control)
        {
            control.Checked = false;
            if (!bool.TryParse(setting.Attributes["Value"].Value, out var value)) return;
            control.Checked = value;
        }

        private void SetSetting(XmlNode setting)
        {
            SavedIP = setting.Attributes["Value"].Value;
            textBox1.Text = SavedIP;
        }

        private void SetSetting(XmlNode setting, TreeView control)
        {
            foreach (TreeNode node in GetAllNodes(control))
            {
                SetSetting(setting.SelectSingleNode(".//" + node.Name), node);
            }
        }

        private void SetSetting(XmlNode setting, TreeNode control)
        {
            control.Checked = false;
            if (!bool.TryParse(setting.Attributes["Value"].Value, out var value)) return;
            control.Checked = value;
        }

        private IEnumerable<TreeNode> GetAllNodes(TreeView tvw)
        {
            foreach (TreeNode tnd in tvw.Nodes)
            {
                yield return tnd;
                if (tnd.Nodes != null && tnd.Nodes.Count > 0)
                    foreach (TreeNode child in GetAllNodes(tnd))
                        yield return child;
            }
        }

        private IEnumerable<TreeNode> GetAllNodes(TreeNode parent)
        {
            foreach (TreeNode tnd in parent.Nodes)
            {
                yield return tnd;
                if (tnd.Nodes != null && tnd.Nodes.Count > 0)
                    foreach (TreeNode child in GetAllNodes(tnd))
                        yield return child;
            }
        }

        private bool GetNodeValue(TreeNode tnd)
        {
            bool value = true;

            while (value && tnd != null)
            {
                value = tnd.Checked;
                tnd = tnd.Parent;
            }

            return value;
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tnd in GetAllNodes(tvwSettings))
            {
                tnd.Checked = true;
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tnd in GetAllNodes(tvwSettings))
            {
                tnd.Checked = false;
            }
        }

        private void btnResetToDefault_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tnd in GetAllNodes(tvwSettings))
            {
                tnd.Checked = DefaultSettings[tnd.Name];
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SavedIP = textBox1.Text;
        }
    }
}
