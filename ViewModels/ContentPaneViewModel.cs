using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia;
using Avalonia.ReactiveUI;
using ReactiveUI;

using KiTab.Models;

namespace KiTab.ViewModels;

public class ContentPaneViewModel : ViewModelBase
{
	public ReactiveCommand<Unit, Unit> TogglePaneCommand { get; set; }
	private bool _showPane = true;
	public bool ShowPane
	{
		get => _showPane;
		set
		{
			this.RaiseAndSetIfChanged(ref _showPane, value);
			this.RaisePropertyChanged("PaneToggleButtonIcon");
			this.RaisePropertyChanged("TogglePaneButtonCorners");
		}
	}
	public string PaneToggleButtonIcon
	{
		get => _showPane ? "left" : "right";
	}
	public CornerRadius TogglePaneButtonCorners
	{
		get => _showPane ? new CornerRadius(50, 3, 3, 50) : new CornerRadius(3, 50, 50, 3);
	}
	public ObservableCollection<ContentIndex> ContentIndexes { get; }

	public ContentPaneViewModel(ReactiveCommand<Unit, Unit> TogglePaneCommand)
	{
		this.TogglePaneCommand = TogglePaneCommand;
		this.ContentIndexes = new ObservableCollection<ContentIndex>(
			Enumerable.Repeat(
				new ContentIndex(1, "Introduction Introduction Introduction Introduction", 1, 4),
				50
			)
		);
	}
}
