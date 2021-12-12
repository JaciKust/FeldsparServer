using System;
using FeldsparServer.DataObjects;

namespace FeldsparServer.Messaging
{
	public class ButtonPressEventArgs : EventArgs
	{
		public ButtonPressEventArgs(DataObjectButtonPressed buttonPressedDataObject)
		{
			ButtonPressedData = buttonPressedDataObject;
		}

		public DataObjectButtonPressed ButtonPressedData { get; }
	}
}
