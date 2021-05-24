using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FedoraDev.PanelTabber.Implementations
{
	public class CategoryTabber : ITabPanel
    {
		TabToPanelTabber _simpleTabPanel = new TabToPanelTabber();

		public int ActiveTab => _simpleTabPanel.ActiveTab;
		public int TabQuantity => _simpleTabPanel.TabQuantity;

		[SerializeField] Transform _tabParent;
		[SerializeField] Transform _panelParent;

		public void Initialize()
		{
			List<Button> tabs = new List<Button>();
			for (int i = 0; i < _tabParent.childCount; i++)
				tabs.Add(_tabParent.GetChild(i).GetComponent<Button>());

			List<GameObject> panels = new List<GameObject>();
			for (int i = 0; i < _panelParent.childCount; i++)
				panels.Add(_panelParent.GetChild(i).gameObject);

			if (_simpleTabPanel == null)
				_simpleTabPanel = new TabToPanelTabber();
			_simpleTabPanel.SetTabsAndPanels(tabs, panels);
			_simpleTabPanel.Initialize();
		}

		public void GoToTab(int tabIndex) => _simpleTabPanel.GoToTab(tabIndex);
	}
}
