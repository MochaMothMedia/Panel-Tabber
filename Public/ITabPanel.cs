namespace FedoraDev.PanelTabber
{
	public interface ITabPanel
    {
        int ActiveTab { get; }
        int TabQuantity { get; }
        void Initialize();
        void GoToTab(int tabIndex);
    }
}
