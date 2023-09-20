﻿using Avalonia;
using Avalonia.Media;
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
			.LogToTrace()
			.With(fontOptions);
	}
}