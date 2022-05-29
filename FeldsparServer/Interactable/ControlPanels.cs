using System.Collections.Generic;
using Common;

namespace FeldsparServer.Interactable
{
	public static class ControlPanels
	{
		public static ControlPanel Door { get; } = new ControlPanel(nameof(Door));
		public static ControlPanel BlackBedside { get; } = new ControlPanel(nameof(BlackBedside));
		public static ControlPanel Desk { get; } = new ControlPanel(nameof(Desk));

		public static IEnumerable<ControlPanel> AllPanels { get; } = new List<ControlPanel>(){
			Door,
			BlackBedside,
			Desk
		};

		public static void SetPrimaryButtonColors(Color[] colors)
		{
			foreach (var panel in AllPanels)
			{
				panel.SetPrimaryButtonColors(colors);
			}
		}

		public static void SetAccessoryButtonColors(Color[] colors)
		{
			foreach (var panel in AllPanels)
			{
				panel.SetAccessoryButtonColors(colors);
			}
		}

		public static void SetSpecialButtonColors(Color[] colors)
		{
			foreach (var panel in AllPanels)
			{
				panel.SetSpecialButtonColors(colors);
			}
		}
	}
}
