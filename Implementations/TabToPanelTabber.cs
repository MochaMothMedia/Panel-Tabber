using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FedoraDev.PanelTabber.Implementations
{
	public class TabToPanelTabber : ITabPanel
    {
		public int ActiveTab => _tabs.IndexOf(_tabs.Where(tab => !tab.IsInteractable()).FirstOrDefault());
		public int TabQuantity => _tabs.Count;

        [SerializeField] List<Button> _tabs = new List<Button>();
        [SerializeField] List<GameObject> _panels = new List<GameObject>();

		public void Initialize()
		{
			for (int i = 0; i < _tabs.Count; i++)
			{
				int index = i;
				_tabs[i].onClick.AddListener(() => GoToTab(index));
			}
		}

        public void GoToTab(int tabIndex)
		{
			if (_tabs.Count <= tabIndex)
				return;

			for (int i = 0; i < _tabs.Count; i++)
				_tabs[i].interactable = true;
			for (int i = 0; i < _panels.Count; i++)
				_panels[i].SetActive(false);

			_tabs[tabIndex].interactable = false;

			if (_panels.Count > tabIndex)
				_panels[tabIndex].SetActive(true);
		}

		public void SetTabsAndPanels(List<Button> tabs, List<GameObject> panels)
		{
			_tabs = tabs;
			_panels = panels;
		}
    }
}
