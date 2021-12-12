using System;
using Communication.DataObject;

namespace Communication.MessageBus
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
