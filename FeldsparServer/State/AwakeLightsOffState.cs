using System;
using Common;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOffState : BaseState
	{
		public override IState HandleMessage(DataObjectButtonPressed buttonPressData)
		{
			return new AwakeLightsOnState();
		}

		public override void OnStateEnter(IState oldState, IMessageBus messageBus)
		{
			LifxBulbs.AllLamps.TurnOff(2);

			ControlPanels.Desk.SetPrimaryButtonColors(new Color[] { Colors.DarkWhite, Colors.DimWhite, Colors.DimRed });
			ControlPanels.Desk.SetAccessoryButtonColors(new Color[] { Colors.Black, Colors.DimBlue, Colors.DimRed });

			ControlPanels.BlackBedside.SetPrimaryButtonColors(new Color[] { Colors.DarkWhite, Colors.DimWhite, Colors.DimRed });
			ControlPanels.BlackBedside.SetAccessoryButtonColors(new Color[] { Colors.Black, Colors.DimBlue, Colors.DimRed });

			ControlPanels.Door.SetPrimaryButtonColors(new Color[] { Colors.DarkWhite, Colors.DimWhite, Colors.DimRed });

			OutletSwitches.Fan.SetOn();
			OutletSwitches.PlantLights.SetOn();
			OutletSwitches.Monitors.SetOn();
		}

		public override void OnStateLeave(IState newState)
		{

		}

		public override void OnTick(DateTime currentTime)
		{
			// No-op
		}
	}
}
