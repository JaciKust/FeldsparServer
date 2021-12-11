namespace FeldsparServer.DataObjects
{
	public static class DataObjectTopic
	{
		public static string ButtonPress { get; } = nameof(ButtonPress);
		public static string LifxCommand { get; } = nameof(LifxCommand);
		public static string RelayCommand { get; } = nameof(RelayCommand);
		public static string ControlPanelState { get; } = nameof(ControlPanelState);
	}
}
