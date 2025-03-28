using MyUI.Slot;
using MyUI.State;
using MyUI.Struct;
using MyUtil;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.FSM.UIItem
{
    public class UIItemManager : Singleton<UIItemManager>
    {
        public Dictionary<string, UIItemFSMInformation> UIItemInformations { get { return _uiItemInformations; } }
        private Dictionary<string, UIItemFSMInformation> _uiItemInformations = new Dictionary<string, UIItemFSMInformation>();
    }
}

