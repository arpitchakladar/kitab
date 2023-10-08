using ReactiveUI;
using PdfLibCore;
using PdfLibCore.Enums;
using System;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace KiTab.ViewModels;

public class PDFViewerViewModel : ViewModelBase
{
	private Bitmap? _pageBitmap;
	public Bitmap? PageBitmap
	{
		get => _pageBitmap;
	}

	public void LoadPage(Bitmap? pageBitmap)
	{
		_pageBitmap = pageBitmap;
		this.RaisePropertyChanged("PageBitmap");
	}
}
