using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Interactivity;
using ReactiveUI;

using KiTab.Models;

namespace KiTab.ViewModels;

public class ContentPaneViewModel : ViewModelBase
{
	public ReactiveCommand<Unit, Unit> TogglePaneCommand { get; }
	public Action<object?> UpdateCurrentContent { get; }
	private bool _showPane = true;
	private int _currentContentIndex = 0;
	public int CurrentContentIndex
	{
		get => _currentContentIndex;
		set
		{
			_currentContentIndex = value;
			UpdateCurrentContent(null);
			this.RaisePropertyChanged("CurrentContentIndex");
		}
	}
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

	public ContentPaneViewModel(ReactiveCommand<Unit, Unit> TogglePaneCommand, Action<object?> UpdateCurrentContent, IEnumerable<ContentIndex> ContentIndexes)
	{
		this.TogglePaneCommand = TogglePaneCommand;
		this.UpdateCurrentContent = UpdateCurrentContent;
		this.ContentIndexes = new ObservableCollection<ContentIndex>(ContentIndexes);
	}
}
