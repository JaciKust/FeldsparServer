using LifxColor = LifxNet.Color;

namespace FeldsparServer
{
	public class Color
	{
		public Color(byte red, byte green, byte blue, Kelvin kelvin = Kelvin.BlueIce) : this(new LifxColor() { R = red, G = green, B = blue }, kelvin) { }

		public Color(LifxColor lifxColor, Kelvin kelvin = Kelvin.BlueIce)
		{
			LifxColor = lifxColor;
			Kelvin = kelvin;
		}

		public LifxColor LifxColor { get; private set; }

		public Kelvin Kelvin { get; private set; }
	}
}
