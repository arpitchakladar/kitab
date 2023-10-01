using Avalonia;
using Avalonia.Media;
using Avalonia.Svg.Skia;
using Avalonia.Logging;
using Avalonia.ReactiveUI;
using System;

namespace KiTab;

class Program
{
	// Initialization code. Don't use any Avalonia, third-party APIs or any
	// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
	// yet and stuff might break.
	[STAThread]
	public static void Main(string[] args) => BuildAvaloniaApp()
		.StartWithClassicDesktopLifetime(args);

	// Avalonia configuration, don't remove; also used by visual designer.
	public static AppBuilder BuildAvaloniaApp()
	{
		GC.KeepAlive(typeof(SvgImageExtension).Assembly);
		GC.KeepAlive(typeof(Avalonia.Svg.Skia.Svg).Assembly);
		var fontOptions = new FontManagerOptions();

		if (OperatingSystem.IsLinux())
			fontOptions.DefaultFamilyName = "FiraCode Nerd Font Mono";
		else if (OperatingSystem.IsMacOS())
			fontOptions.DefaultFamilyName = "Helvetica";
		else
			fontOptions.DefaultFamilyName = "Arial";

		return AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.WithInterFont()
			.LogToTrace(LogEventLevel.Verbose)
			.UseReactiveUI()
			.With(fontOptions);
	}
}
