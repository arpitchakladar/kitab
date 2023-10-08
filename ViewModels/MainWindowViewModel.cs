using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using PdfLibCore;
using PdfLibCore.Enums;
using Avalonia.Media.Imaging;

using KiTab.Models;

namespace KiTab.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	private Bitmap?[] _pdfDocumentPagesBitmap;
	private bool _showPane = true;

	public bool ShowPane
	{
		get => _showPane;
		set
		{
			ContentPane.ShowPane = value;
			this.RaiseAndSetIfChanged(ref _showPane, value);
		}
	}

	public ContentPaneViewModel ContentPane { get; }
	public PDFViewerViewModel[] PDFViewer { get; }

	private void LoadPages()
	{
		var content = ContentPane.ContentIndexes[ContentPane.CurrentContentIndex];
		PDFViewer[0].LoadPage(_pdfDocumentPagesBitmap[content.Start]);
		PDFViewer[1].LoadPage(_pdfDocumentPagesBitmap[content.Start + 1]);
	}

	private static double dpiX = 300D;
	private static double dpiY = 300D;

	private Task GetBitmapOfPDFFromBytes(string pdfFilePath) =>
		Task.Run(() => {
			byte[] pdfData = File.ReadAllBytes(pdfFilePath);
			var pdfDocument = new PdfDocument(pdfData);
			_pdfDocumentPagesBitmap = new Bitmap[pdfDocument.Pages.Count];

			for (var i = 0; i < pdfDocument.Pages.Count; i++)
			{
				using var pdfPage = pdfDocument.Pages[i];
				var pageWidth = (int) (dpiX * pdfPage.Size.Width / 72);
				var pageHeight = (int) (dpiY * pdfPage.Size.Height / 72);
				using var bitmap = new PdfiumBitmap(pageWidth, pageHeight, true);
				pdfPage.Render(bitmap, PageOrientations.Normal, RenderingFlags.LcdText);
				using var stream = bitmap.AsBmpStream(dpiX, dpiY);
				using var memory = new MemoryStream();
				stream.CopyTo(memory);
				memory.Position = 0;
				_pdfDocumentPagesBitmap[i] = new Bitmap(memory);
			}
		});

	public MainWindowViewModel()
	{
		PDFViewer = new PDFViewerViewModel[2] {
			new PDFViewerViewModel(),
			new PDFViewerViewModel()
		};
		var RandomData = new List<ContentIndex>();
		for (int i = 0; i <= 20; i++)
			RandomData.Add(new ContentIndex(i + 1, "Introduction Introduction Introduction Introduction", i * 2, i * 2 + 1));
		ContentPane = new ContentPaneViewModel(
			ReactiveCommand.Create(() =>
				{
					ShowPane = !_showPane;
				}
			),
			delegate(object? _)
			{
				LoadPages();
			},
			RandomData
		);
		GetBitmapOfPDFFromBytes("./Tests/PDFs/IMO2022SL.pdf")
			.ContinueWith((Task _) => Task.Run(LoadPages));
	}
}
