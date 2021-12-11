using System.Linq;
using LifxNet;

namespace FeldsparServer.Interactable
{
	public static class LifxBulbs
	{
		// Red Lamp
		private static readonly LifxLightBulb Alpha = new LifxLightBulb("d0:73:d5:2b:5b:08", "192.168.0.200", "Alpha");
		private static readonly LifxLightBulb Foxtrot = new LifxLightBulb("D0:73:D5:40:15:4C", "192.168.0.205", "Foxtrot");
		private static readonly LifxLightBulb Echo = new LifxLightBulb("D0:73:D5:40:31:1D", "192.168.0.204", "Echo");

		// Yellow Lamp
		private static readonly LifxLightBulb Bravo = new LifxLightBulb("d0:73:d5:2a:69:0c", "192.168.0.201", "Bravo");
		private static readonly LifxLightBulb Charlie = new LifxLightBulb("D0:73:D5:2B:BA:14", "192.168.0.202", "Charlie");
		private static readonly LifxLightBulb Delta = new LifxLightBulb("D0:73:D5:2B:96:41", "192.168.0.203", "Delta");

		// Silver
		private static readonly LifxLightBulb Golf = new LifxLightBulb("D0:73:D5:2A:93:0C", "192.168.0.206", "Golf");

		// White bedside
		private static readonly LifxLightBulb Hotel = new LifxLightBulb("D0:73:D5:2B:F7:AB", "192.168.0.207", "Hotel");

		//Black bedside
		private static readonly LifxLightBulb India = new LifxLightBulb("D0:73:D5:2C:09:DD", "192.168.0.208", "India");

		// Light Bar
		private static readonly LifxLightBulb Juliet = new LifxLightBulb("D0:73:D5:59:E4:BE", "192.168.0.209", "Juliet");
		private static readonly LifxLightBulb Kilo = new LifxLightBulb("D0:73:D5:57:A1:C7", "192.168.0.210", "Kilo");

		private static readonly LifxLightBulb Lima = new LifxLightBulb("D0:73:D5:51:FF:5C", "192.168.0.211", "Lima");
		private static readonly LifxLightBulb Mike = new LifxLightBulb("D0:73:D5:3E:73:4C", "192.168.0.212", "Mike");

		private static readonly LifxLightBulb[] AllLights = new LifxLightBulb[] {
			Alpha,
			Bravo,
			Charlie,
			Delta,
			Echo,
			Foxtrot,
			Golf,
			Hotel,
			India,
			Juliet,
			Kilo,
			Mike,
			Lima
		};

		private static readonly LifxLightBulb[] BlackBedsideLights = new LifxLightBulb[] {
			India
		};

		private static readonly LifxLightBulb[] BlackBarLights = new LifxLightBulb[] {
			Juliet,
			Kilo
		};

		private static readonly LifxLightBulb[] WhiteBedsideLights = new LifxLightBulb[] {
			Hotel
		};

		private static readonly LifxLightBulb[] WhiteBarLights = new LifxLightBulb[] {
			Mike,
			Lima
		};

		private static readonly LifxLightBulb[] BlackLights = BlackBarLights.Concat(BlackBedsideLights).ToArray();
		private static readonly LifxLightBulb[] WhiteLights = WhiteBarLights.Concat(WhiteBedsideLights).ToArray();
		private static readonly LifxLightBulb[] BarLights = BlackBarLights.Concat(WhiteBarLights).ToArray();

		private static readonly LifxLightBulb[] RedLights = new LifxLightBulb[] {
			Alpha,
			Foxtrot,
			Echo
		};

		private static readonly LifxLightBulb[] YellowLights = new LifxLightBulb[] {
			Bravo,
			Charlie,
			Delta
		};

		private static readonly LifxLightBulb[] BedsideLights = WhiteBedsideLights.Concat(BlackBedsideLights).ToArray();
		private static readonly LifxLightBulb[] DeskLights = YellowLights.Concat(RedLights).ToArray();

		private static readonly LifxLightBulb[] SilverLights = new LifxLightBulb[] {
			Golf
		};

		public static readonly LifxLamp RedLamp = new LifxLamp(RedLights, "Red");
		public static readonly LifxLamp YellowLamp = new LifxLamp(YellowLights, "Yellow");
		public static readonly LifxLamp SilverLamp = new LifxLamp(SilverLights, "Silver");
		public static readonly LifxLamp BlackLamp = new LifxLamp(BlackLights, "Bed - Black");
		public static readonly LifxLamp WhiteLamp = new LifxLamp(WhiteLights, "Bed - White");

		public static readonly LifxLamp AllLamps = new LifxLamp(AllLights, "All");

		public static readonly LifxLamp DeskLamps = new LifxLamp(DeskLights, "Desk");
		public static readonly LifxLamp BedSideLamps = new LifxLamp(BedsideLights, "BedSide");

		public static readonly LifxLamp BedsideBlackLamp = new LifxLamp(BlackBedsideLights, "Black");
		public static readonly LifxLamp BedsideWhiteLamp = new LifxLamp(WhiteBedsideLights, "White");
		public static readonly LifxLamp BarLamp = new LifxLamp(BarLights, "Bar");
	}
}
