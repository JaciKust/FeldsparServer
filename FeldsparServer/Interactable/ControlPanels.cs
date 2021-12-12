namespace FeldsparServer.Interactable
{
	public static class ControlPanels
	{
		public static ControlPanel Door { get; } = new ControlPanel(nameof(Door));
		public static ControlPanel BlackBedside { get; } = new ControlPanel(nameof(BlackBedside));
		public static ControlPanel Desk { get; } = new ControlPanel(nameof(Desk));
	}
}
