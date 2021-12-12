namespace FeldsparServer.DataObjects
{
	public static class DataTopic
	{
		public static string ButtonPress { get; } = nameof(ButtonPress);
		public static string LifxCommand { get; } = nameof(LifxCommand);
		public static string RelayCommand { get; } = nameof(RelayCommand);
		public static string ControlPanel { get; } = nameof(ControlPanel);
		public static string Transmitter443 { get; } = nameof(Transmitter443);
	}
}
