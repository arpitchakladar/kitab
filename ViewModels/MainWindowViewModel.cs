using ReactiveUI;
using PdfLibCore;
using System;
using System.Linq;
using System.Reactive;
using System.Collections.Generic;
using System.IO;

using KiTab.Models;

namespace KiTab.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	private PdfDocument _pdfDocument;
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
		PDFViewer[0].LoadPage(_pdfDocument, content.Start);
		PDFViewer[1].LoadPage(_pdfDocument, content.Start + 1);
	}

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
		_pdfDocument = new PdfDocument(File.Open("./Tests/PDFs/IMO2022SL.pdf", FileMode.Open));
		LoadPages();
	}
}
