using LifxColor = LifxNet.Color;

namespace Common
{
	public class Color
	{
		public Color(byte red, byte green, byte blue, Kelvin kelvin = Kelvin.BlueIce) : this(new LifxColor() { R = red, G = green, B = blue }, kelvin) { }

		public Color(LifxColor lifxColor, Kelvin kelvin = Kelvin.BlueIce)
		{
			_lifxColor = lifxColor;
			Kelvin = kelvin;
		}

		private LifxColor _lifxColor;

		public Kelvin Kelvin { get; private set; }

		public byte Red => _lifxColor.R;
		public byte Green => _lifxColor.G;
		public byte Blue => _lifxColor.B;

		public LifxColor ToLifxColor() => _lifxColor;
		public int[] ToRGBArray() => new int[] { Red, Green, Blue };
	}
}
