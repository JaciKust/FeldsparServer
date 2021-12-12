using FeldsparServer.Messaging;

namespace FeldsparServer.Interactable
{
	public static class OutletSwitches
	{
		public static OutletSwitch Fan { get; } = new OutletSwitch(1, nameof(Fan), "1010111111101010110011001", "1010111111101010110000111", MessageBus.Instance);
		public static OutletSwitch PlantLights { get; } = new OutletSwitch(2, nameof(PlantLights), "1010111111101010001111001", "1010111111101010001100111", MessageBus.Instance);
		//public static OutletSwitch Unused3 { get; } = new OutletSwitch(3, nameof(Unused3), "1010111111101000111111001", "1010111111101000111100111", MessageBus.Instance);
		public static OutletSwitch Monitors { get; } = new OutletSwitch(4, nameof(Monitors), "1010111111100010111111001", "1010111111100010111100111", MessageBus.Instance);
		//public static OutletSwitch Unused5 { get; } = new OutletSwitch(5, nameof(Unused5), "1010111111001010111111001", "1010111111001010111100111", MessageBus.Instance);
	}
}
