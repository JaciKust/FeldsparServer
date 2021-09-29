namespace FeldsparServer
{
	public static class Colors
	{
		public static int Dim { get; } = 50;
		public static int Dark { get; } = 1;
		public static int ColorMaximum { get; } = 255;
		public static int ColorMinimum { get; } = 0;

		public static Color Red { get; } = new Color(ColorMaximum, ColorMinimum, ColorMinimum);
		public static Color Green { get; } = new Color(ColorMinimum, ColorMaximum, ColorMinimum);
		public static Color Blue { get; } = new Color(ColorMinimum, ColorMinimum, ColorMaximum);
		public static Color DimRed { get; } = new Color(Dim, ColorMinimum, ColorMinimum);
		public static Color DimGreen { get; } = new Color(ColorMinimum, Dim, ColorMinimum);
		public static Color DimBlue { get; } = new Color(ColorMinimum, ColorMinimum, Dim);
		public static Color DarkRed { get; } = new Color(Dark, ColorMinimum, ColorMinimum);
		public static Color DarkGreen { get; } = new Color(ColorMinimum, Dark, ColorMinimum);
		public static Color DarkBlue { get; } = new Color(ColorMinimum, ColorMinimum, Dark);
		public static Color Cyan { get; } = new Color(ColorMinimum, ColorMaximum, ColorMaximum);
		public static Color Magenta { get; } = new Color(ColorMaximum, ColorMinimum, ColorMaximum);
		public static Color Yellow { get; } = new Color(ColorMaximum, ColorMaximum, ColorMinimum);
		public static Color DimCyan { get; } = new Color(ColorMinimum, Dim, Dim);
		public static Color DimMagenta { get; } = new Color(Dim, ColorMinimum, Dim);
		public static Color DimYellow { get; } = new Color(Dim, Dim, ColorMinimum);
		public static Color DarkCyan { get; } = new Color(ColorMinimum, Dark, Dark);
		public static Color DarkMagenta { get; } = new Color(Dark, ColorMinimum, Dark);
		public static Color DarkYellow { get; } = new Color(Dark, Dark, ColorMinimum);
		public static Color DarkWhite { get; } = new Color(Dark, Dark, Dark);
		public static Color DimWhite { get; } = new Color(Dim, Dim, Dim);
		public static Color Black { get; } = new Color(ColorMinimum, ColorMinimum, ColorMinimum);

		public static Color GetWhite(Kelvin kelvin, int whitePercent)
		{
			return new Color(whitePercent, whitePercent, whitePercent, kelvin);
		}

		#region All Whites

		public static Color WhiteUltraWarm { get; } = GetWhite(Kelvin.UltraWarm, ColorMaximum);
		public static Color WhiteIncandesant { get; } = GetWhite(Kelvin.Incandesant, ColorMaximum);
		public static Color WhiteWarm { get; } = GetWhite(Kelvin.Warm, ColorMaximum);
		public static Color WhiteNeutralWarm { get; } = GetWhite(Kelvin.NeutralWarm, ColorMaximum);
		public static Color WhiteNeutral { get; } = GetWhite(Kelvin.Neutral, ColorMaximum);
		public static Color WhiteCool { get; } = GetWhite(Kelvin.Cool, ColorMaximum);
		public static Color WhiteCoolDaylight { get; } = GetWhite(Kelvin.CoolDaylight, ColorMaximum);
		public static Color WhiteSoftDaylight { get; } = GetWhite(Kelvin.SoftDaylight, ColorMaximum);
		public static Color WhiteDaylight { get; } = GetWhite(Kelvin.Daylight, ColorMaximum);
		public static Color WhiteNoonDaylight { get; } = GetWhite(Kelvin.NoonDaylight, ColorMaximum);
		public static Color WhietBrightDaylight { get; } = GetWhite(Kelvin.BrightDaylight, ColorMaximum);
		public static Color whiteCloudyDaylight { get; } = GetWhite(Kelvin.CloudyDaylight, ColorMaximum);
		public static Color WhiteBlueDaylight { get; } = GetWhite(Kelvin.BlueDaylight, ColorMaximum);
		public static Color WhiteBlueOvercast { get; } = GetWhite(Kelvin.BlueOvercast, ColorMaximum);
		public static Color WhiteBlueWater { get; } = GetWhite(Kelvin.BlueWater, ColorMaximum);
		public static Color WhiteBlueIce { get; } = GetWhite(Kelvin.BlueIce, ColorMaximum);

		public static Color[] WhiteKelvinCycle = new Color[] {
			WhiteUltraWarm,
			WhiteNeutral,
			WhiteDaylight,
			WhiteBlueDaylight,
			WhiteBlueIce
		};

		public static Color[] AllWhites { get; } = new Color[] {
			WhiteUltraWarm,
			WhiteIncandesant,
			WhiteWarm,
			WhiteNeutralWarm,
			WhiteNeutral,
			WhiteCool,
			WhiteCoolDaylight,
			WhiteSoftDaylight,
			WhiteDaylight,
			WhiteNoonDaylight,
			WhietBrightDaylight,
			whiteCloudyDaylight,
			WhiteBlueDaylight,
			WhiteBlueOvercast,
			WhiteBlueWater,
			WhiteBlueIce
		};

		#endregion

		public static Color[] PrimaryColors { get; } = new Color[] {
			Red,
			Green,
			Blue,
		};

		public static Color[] SecondaryColors { get; } = new Color[] {
			Cyan,
			Magenta,
			Yellow,
		};
	}
}
