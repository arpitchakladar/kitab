using ReactiveUI;
using PdfLibCore;
using System;
using System.IO;

namespace KiTab.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
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

	public MainWindowViewModel()
	{
		ContentPane = new ContentPaneViewModel(
			ReactiveCommand.Create(() =>
				{
					ShowPane = !_showPane;
				}
			)
		);
		PDFViewer = new PDFViewerViewModel[2] {
			new PDFViewerViewModel(),
			new PDFViewerViewModel()
		};
		using var pdfDocument = new PdfDocument(File.Open("./Tests/PDFs/IMO2022SL.pdf", FileMode.Open));
		PDFViewer[0].LoadPage(pdfDocument, 3);
		PDFViewer[1].LoadPage(pdfDocument, 4);
	}
}
