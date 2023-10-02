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

	private const double dpiX = 300D;
	private const double dpiY = 300D;

	public void LoadPage(PdfDocument pdfDocument, int pageNumber)
	{
		using var pdfPage = pdfDocument.Pages[pageNumber];
		var pageWidth = (int) (dpiX * pdfPage.Size.Width / 72);
		var pageHeight = (int) (dpiY * pdfPage.Size.Height / 72);
		using var bitmap = new PdfiumBitmap(pageWidth, pageHeight, true);
		pdfPage.Render(bitmap, PageOrientations.Normal, RenderingFlags.LcdText);
		using var stream = bitmap.AsBmpStream(dpiX, dpiY);
		using var memory = new MemoryStream();
		stream.CopyTo(memory);
		memory.Position = 0;
		_pageBitmap = new Bitmap(memory);
		this.RaisePropertyChanged("PageBitmap");
	}
}
