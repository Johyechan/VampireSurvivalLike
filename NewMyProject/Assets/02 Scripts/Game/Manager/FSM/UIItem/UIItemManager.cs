using MyUI.Item;
using MyUI.Struct;
using MyUtil;
using System.Collections.Generic;

namespace Manager.UI
{
    public class UIItemManager : Singleton<UIItemManager>
    {
        public Dictionary<string, UIItemFSMInformation> UIItemInformations { get { return _uiItemInformations; } }
        private Dictionary<string, UIItemFSMInformation> _uiItemInformations = new Dictionary<string, UIItemFSMInformation>();

        public UIItem CurrentUIItem { get; set; }
    }
}

