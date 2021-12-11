using System.Linq;
using LifxNet;

namespace FeldsparServer.Interactable
{
	public static class LifxBulbs
	{
		// Red Lamp
		public static LifxLightBulb alpha { get; } = new LifxLightBulb("d0:73:d5:2b:5b:08", "192.168.0.200", "Alpha");
		public static LifxLightBulb foxtrot { get; } = new LifxLightBulb("D0:73:D5:40:15:4C", "192.168.0.205", "Foxtrot");
		public static LifxLightBulb echo { get; } = new LifxLightBulb("D0:73:D5:40:31:1D", "192.168.0.204", "Echo");

		// Yellow Lamp
		public static LifxLightBulb bravo { get; } = new LifxLightBulb("d0:73:d5:2a:69:0c", "192.168.0.201", "Bravo");
		public static LifxLightBulb charlie { get; } = new LifxLightBulb("D0:73:D5:2B:BA:14", "192.168.0.202", "Charlie");
		public static LifxLightBulb delta { get; } = new LifxLightBulb("D0:73:D5:2B:96:41", "192.168.0.203", "Delta");

		// Silver
		public static LifxLightBulb golf { get; } = new LifxLightBulb("D0:73:D5:2A:93:0C", "192.168.0.206", "Golf");

		// White bedside
		public static LifxLightBulb hotel { get; } = new LifxLightBulb("D0:73:D5:2B:F7:AB", "192.168.0.207", "Hotel");

		//Black bedside
		public static LifxLightBulb india { get; } = new LifxLightBulb("D0:73:D5:2C:09:DD", "192.168.0.208", "India");

		public static LifxLightBulb[] all_lights = new LifxLightBulb[] {
			alpha,
			bravo,
			charlie,
			delta,
			echo,
			foxtrot,
			golf,
			hotel,
			india
		};

		public static LifxLightBulb[] black_bedside_lamp = new LifxLightBulb[] {
			india
		};

		public static LifxLightBulb[] white_bedside_lamp = new LifxLightBulb[] {
			hotel
		};

		public static LifxLightBulb[] red_lights = new LifxLightBulb[] {
			alpha,
			foxtrot,
			echo
		};

		public static LifxLightBulb[] yellow_lights = new LifxLightBulb[] {
			bravo,
			charlie,
			delta
		};

		public static LifxLightBulb[] bedside_lamps = white_bedside_lamp.Concat(black_bedside_lamp).ToArray();
		public static LifxLightBulb[] desk_lamps = yellow_lights.Concat(red_lights).ToArray();

		public static LifxLightBulb[] silver_lamp = new LifxLightBulb[] {
			golf
		};

		public static LifxLamp red_lamp = new LifxLamp(red_lights, "Red");
		public static LifxLamp yellow_lamp = new LifxLamp(yellow_lights, "Yellow");
		public static LifxLamp entry_lamp = new LifxLamp(silver_lamp, "Entry");
		public static LifxLamp jaci_bedside_lamp = new LifxLamp(bedside_lamps, "BedSide");
		public static LifxLamp all_lamp = new LifxLamp(all_lights, "All");
		public static LifxLamp desk_lamp = new LifxLamp(desk_lamps, "Desk");
		public static LifxLamp bed_black_lamp = new LifxLamp(black_bedside_lamp, "Black");
		public static LifxLamp bed_white_lamp = new LifxLamp(white_bedside_lamp, "White");
	}
}
