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
	public Bitmap? _page;
	public Bitmap? Page
	{
		get => _page;
		private set => this.RaiseAndSetIfChanged(ref _page, value);
	}

	public void LoadPage(PdfDocument pdfDocument, int PageNumber)
	{
		var dpiX = 300D;
		var dpiY = 300D;

		using var pdfPage = pdfDocument.Pages[PageNumber];
		var pageWidth = (int) (dpiX * pdfPage.Size.Width / 72);
		var pageHeight = (int) (dpiY * pdfPage.Size.Height / 72);
		using var bitmap = new PdfiumBitmap(pageWidth, pageHeight, true);
		pdfPage.Render(bitmap, PageOrientations.Normal, RenderingFlags.LcdText);
		using var stream = bitmap.AsBmpStream(dpiX, dpiY);
		using (MemoryStream ms = new MemoryStream())
		{
			stream.CopyTo(ms);
			ms.Position = 0;
			Page = new Bitmap(ms);
		}
	}
}
