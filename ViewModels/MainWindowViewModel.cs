using ReactiveUI;

namespace KiTab.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	private bool _showPane = true;

	public bool ShowPane
	{
		get => _showPane;
		set => this.RaiseAndSetIfChanged(ref _showPane, value);
	}

	public ContentPaneViewModel ContentPane { get; }

	public MainWindowViewModel()
	{
		ContentPane = new ContentPaneViewModel(
			ReactiveCommand.Create(() =>
				{
					ShowPane = !_showPane;
				}
			)
		);
	}
}
