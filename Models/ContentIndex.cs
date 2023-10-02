namespace KiTab.Models;

public class ContentIndex {
	public int Index { get; }
	public string Title { get; }
	public int Start { get; }
	public int End { get; }

	public ContentIndex(int Index, string Title, int Start, int End)
	{
		this.Index = Index;
		this.Title = Title;
		this.Start = Start;
		this.End = End;
	}
}
