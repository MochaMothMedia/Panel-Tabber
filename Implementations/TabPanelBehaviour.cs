using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace FedoraDev.PanelTabber.Implementations
{
	public class TabPanelBehaviour : SerializedMonoBehaviour, ITabPanel
    {
		public int ActiveTab => _tabPanel.ActiveTab;
		public int TabQuantity => _tabPanel.TabQuantity;
		public UnityEvent<int> TabChangedEvent => _tabChangedEvent;

        [SerializeField, HideLabel, BoxGroup("Tab Panel")] private ITabPanel _tabPanel;
		[SerializeField] private UnityEvent<int> _tabChangedEvent = new UnityEvent<int>();

		private void OnEnable()
		{
			Initialize();
		}

		[Button("Next Tab")]
        public void GoToNextTab()
		{
			Initialize();
			int nextIndex = (ActiveTab + 1) % TabQuantity;
			GoToTab(nextIndex);
		}

        [Button("Previous Tab")]
        public void GoToPreviousTab()
		{
			Initialize();
			int previousIndex = (ActiveTab + TabQuantity - 1) % TabQuantity;
			GoToTab(previousIndex);
		}

		public void GoToTab(int tabIndex)
		{
			_tabPanel.GoToTab(tabIndex);
			TabChangedEvent.Invoke(tabIndex);
		}

		public void Initialize() => _tabPanel.Initialize();
	}
}
