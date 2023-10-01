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
	private string _paneToggleButtonIcon = "left";
	public string PaneToggleButtonIcon { get => _paneToggleButtonIcon; }
	private string _contentVisibility = "NaN";
	public string ContentVisibility { get => _contentVisibility; }
	private CornerRadius _togglePaneButtonCorners = new CornerRadius(20, 3, 3, 20);
	public CornerRadius TogglePaneButtonCorners { get => _togglePaneButtonCorners; }
	public ObservableCollection<ContentIndex> ContentIndexes { get; set; }

	public void OnPaneToggle(bool showPane) {
		if (showPane)
		{
			_paneToggleButtonIcon = "left";
			_contentVisibility = "NaN";
			_togglePaneButtonCorners = new CornerRadius(20, 3, 3, 20);
		}
		else
		{
			_paneToggleButtonIcon = "right";
			_contentVisibility = "0";
			_togglePaneButtonCorners = new CornerRadius(3, 20, 20, 3);
		}
		this.RaisePropertyChanged("PaneToggleButtonIcon");
		this.RaisePropertyChanged("ContentVisibility");
		this.RaisePropertyChanged("TogglePaneButtonCorners");
	}

	public ContentPaneViewModel(ReactiveCommand<Unit, Unit> TogglePaneCommand)
	{
		this.TogglePaneCommand = TogglePaneCommand;
		this.ContentIndexes = new ObservableCollection<ContentIndex>(
			Enumerable.Repeat(
				new ContentIndex(1, "Introduction", 1, 4),
				50
			)
		);
	}
}
