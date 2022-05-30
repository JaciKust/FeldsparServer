using System.Linq;

namespace FeldsparServer.Interactable
{
	public static class LifxBulbs
	{
		// Red Lamp
		public static readonly LifxLightBulb Alpha = new LifxLightBulb("d0:73:d5:2b:5b:08", "192.168.2.200", "Alpha");
		public static readonly LifxLightBulb Foxtrot = new LifxLightBulb("D0:73:D5:40:15:4C", "192.168.2.205", "Foxtrot");
		public static readonly LifxLightBulb Echo = new LifxLightBulb("D0:73:D5:40:31:1D", "192.168.2.204", "Echo");

		// Yellow Lamp
		public static readonly LifxLightBulb Bravo = new LifxLightBulb("d0:73:d5:2a:93:0c", "192.168.2.201", "Bravo");
		public static readonly LifxLightBulb Charlie = new LifxLightBulb("D0:73:D5:2B:BA:14", "192.168.2.202", "Charlie");
		public static readonly LifxLightBulb Delta = new LifxLightBulb("D0:73:D5:2B:96:41", "192.168.2.203", "Delta");

		// Silver
		public static readonly LifxLightBulb Golf = new LifxLightBulb("D0:73:D5:2A:93:0C", "192.168.2.206", "Golf");

		// White bedside
		public static readonly LifxLightBulb Hotel = new LifxLightBulb("D0:73:D5:2B:F7:AB", "192.168.2.207", "Hotel");

		//Black bedside
		public static readonly LifxLightBulb India = new LifxLightBulb("D0:73:D5:2C:09:DD", "192.168.2.208", "India");

		// Light Bar
		public static readonly LifxLightBulb Juliet = new LifxLightBulb("D0:73:D5:59:E4:BE", "192.168.2.209", "Juliet");
		public static readonly LifxLightBulb Kilo = new LifxLightBulb("D0:73:D5:57:A1:C7", "192.168.2.210", "Kilo");

		public static readonly LifxLightBulb Lima = new LifxLightBulb("D0:73:D5:51:FF:5C", "192.168.2.211", "Lima");
		public static readonly LifxLightBulb Mike = new LifxLightBulb("D0:73:D5:3E:73:4C", "192.168.2.212", "Mike");

		// Ledge
		public static readonly LifxLightBulb November = new LifxLightBulb("D0:73:D5:65:10:44", "192.168.2.213", "November");
		public static readonly LifxLightBulb Oscar = new LifxLightBulb("D0:73:D5:65:72:EE", "192.168.2.214", "Oscar");

		// Window
		public static readonly LifxLightBulb Papa = new LifxLightBulb("D0:73:D5:64:96:20", "192.168.2.215", "Papa");
		public static readonly LifxLightBulb Quebec = new LifxLightBulb("D0:73:D5:65:54:5C", "192.168.2.216", "Quebec");

		public static readonly LifxLightBulb Romeo = new LifxLightBulb("D0:73:D5:68:2D:6C", "192.168.2.217", "Romeo");
		public static readonly LifxLightBulb Sierra = new LifxLightBulb("D0:73:D5:68:39:F9", "192.168.2.218", "Sierra");

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
			Lima,
			November,
			Oscar,
			Papa,
			Quebec,
			Romeo,
			Sierra
		};

		private static readonly LifxLightBulb[] BlackBedsideLights = new LifxLightBulb[] {
			Hotel
		};

		private static readonly LifxLightBulb[] BlackBarLights = new LifxLightBulb[] {
			Juliet,
			Kilo,
			Romeo,
		};

		private static readonly LifxLightBulb[] WhiteBedsideLights = new LifxLightBulb[] {
			India
		};

		private static readonly LifxLightBulb[] WhiteBarLights = new LifxLightBulb[] {
			Mike,
			Lima,
			Sierra
		};

		private static readonly LifxLightBulb[] BlackLights = BlackBarLights.Concat(BlackBedsideLights).ToArray();
		private static readonly LifxLightBulb[] WhiteLights = WhiteBarLights.Concat(WhiteBedsideLights).ToArray();
		private static readonly LifxLightBulb[] BarLights = BlackBarLights.Concat(WhiteBarLights).ToArray();

		private static readonly LifxLightBulb[] RedLights = new LifxLightBulb[] {
			Alpha,
			Foxtrot,
			Echo,
			Oscar,
			Quebec
		};

		private static readonly LifxLightBulb[] YellowLights = new LifxLightBulb[] {
			Charlie,
			Delta,
			November,
			Papa,
			Golf
		};

		private static readonly LifxLightBulb[] BedsideLights = WhiteBedsideLights.Concat(BlackBedsideLights).ToArray();
		private static readonly LifxLightBulb[] DeskLights = YellowLights.Concat(RedLights).ToArray();

		private static readonly LifxLightBulb[] SilverLights = new LifxLightBulb[] {
			Bravo,
		};

		private static readonly LifxLightBulb[] WindowLights = new LifxLightBulb[] {
			Papa,
			Quebec
		};

		private static readonly LifxLightBulb[] LedgeLights = new LifxLightBulb[] {
			November,
			Oscar
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

		public static readonly LifxLamp WindowLamp = new LifxLamp(WindowLights, "Window");
		public static readonly LifxLamp LedgeLamp = new LifxLamp(LedgeLights, "Ledge");
	}
}
