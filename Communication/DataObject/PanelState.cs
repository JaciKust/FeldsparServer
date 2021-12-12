namespace Communication.DataObject
{
	public static class PanelState
	{
		public static string PreInit { get; } = nameof(PreInit);
		public static string On { get; } = nameof(On);
		public static string Dim { get; } = nameof(Dim);
		public static string Minimal { get; } = nameof(Minimal);
		public static string Darkened { get; } = nameof(Darkened);
		public static string Off { get; } = nameof(Off);
		public static string Main { get; } = nameof(Main);
	}
}
