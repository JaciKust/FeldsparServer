using System.Collections.Generic;
using Common;
using Communication.DataObject;
using Communication.MessageBus;

namespace FeldsparServer.Interactable
{
	public class ControlPanel
	{
		public ControlPanel(string name)
		{
			Name = name;
		}

		public string Name { get; set; }

		public void SetPrimaryButtonColors(Color[] colors)
		{
			var dataObjectButtonColorSet = new DataObjectButtonColorSet(colors[0], colors[1], colors[2])
			{
				ControlPanelNames = new List<string> { Name },
				Categories = new List<string> { ButtonCategory.Primary }
			};

			NetMQMessageBus.Instance.Send(dataObjectButtonColorSet);
		}

		public void SetAccessoryButtonColors(Color[] colors)
		{
			var dataObjectButtonColorSet = new DataObjectButtonColorSet(colors[0], colors[1], colors[2])
			{
				ControlPanelNames = new List<string> { Name },
				Categories = new List<string> { ButtonCategory.Accessory }
			};

			NetMQMessageBus.Instance.Send(dataObjectButtonColorSet);
		}
	}
}
