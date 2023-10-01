using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive;

namespace KiTab.ViewModels;

public class ContentPaneViewModel : ViewModelBase
{
	public ReactiveCommand<Unit, Unit> TogglePane { get; set; }

	public ContentPaneViewModel(ReactiveCommand<Unit, Unit> TogglePane)
	{
		this.TogglePane = TogglePane;
	}
}
