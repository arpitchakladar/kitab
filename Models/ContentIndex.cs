namespace KiTab.Models;

public class ContentIndex {
	public int Index { get; }
	public string Title { get; }
	public int StartPage { get; }
	public int EndPage { get; }

	public ContentIndex(int Index, string Title, int StartPage, int EndPage)
	{
		this.Index = Index;
		this.Title = Title;
		this.StartPage = StartPage;
		this.EndPage = EndPage;
	}
}
