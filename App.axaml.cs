using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using KiTab.Views;
using KiTab.ViewModels;

namespace KiTab;

public partial class App : Application
{
	public override void Initialize()
	{
		AvaloniaXamlLoader.Load(this);
	}

	public override void OnFrameworkInitializationCompleted()
	{
		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			desktop.MainWindow = new MainWindow()
			{
				DataContext = new MainWindowViewModel()
			};

		base.OnFrameworkInitializationCompleted();
	}
}
