using System;
using FeldsparServer.DataObjects;

namespace FeldsparServer.Messaging
{
	public class ButtonPressEventArgs : EventArgs
	{
		public ButtonPressEventArgs(ButtonPressedDataObject buttonPressedDataObject)
		{
			ButtonPressedData = buttonPressedDataObject;
		}

		public ButtonPressedDataObject ButtonPressedData { get; }
	}
}
