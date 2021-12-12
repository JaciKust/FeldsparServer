using System;
using System.Collections.Generic;
using System.Text.Json;
using Common;

namespace Communication.DataObject
{
	public class DataObjectButtonColorSet : DataObjectBase
	{
		private static readonly int colorLength = 3;
		public DataObjectButtonColorSet(
		Color defaultColor,
		Color pressColor,
		Color longPressColor
		) : base(nameof(DataObjectButtonColorSet), DataTopic.ControlPanel)
		{
			if (defaultColor == null)
			{
				throw new ArgumentNullException(nameof(defaultColor));
			}

			if (pressColor == null)
			{
				throw new ArgumentNullException(nameof(pressColor));
			}

			if (longPressColor == null)
			{
				throw new ArgumentNullException(nameof(longPressColor));
			}

			DefaultColor = defaultColor.ToRGBArray();
			PressColor = pressColor.ToRGBArray();
			LongPressColor = longPressColor.ToRGBArray();
		}

		public int[] DefaultColor { get; }
		public int[] PressColor { get; }
		public int[] LongPressColor { get; }

		public IEnumerable<string> Names { get; set; }
		public IEnumerable<string> ControlPanelNames { get; set; }
		public IEnumerable<string> Categories { get; set; }

		public override string ToJsonString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
