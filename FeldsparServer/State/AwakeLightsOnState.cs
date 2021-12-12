using System;
using Common;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOnState : BaseState
	{
		public override IState HandleMessage(DataObjectButtonPressed buttonPressData)
		{
			return new AwakeLightsOffState();
		}

		public override void OnStateEnter(IState oldState, IMessageBus messageBus)
		{
			LifxBulbs.AllLamps.TurnOn(Colors.WhiteDaylight, 1);

			ControlPanels.Desk.SetAccessoryButtonColors(new Color[] { Colors.DimBlue, Colors.Blue, Colors.Black });
			ControlPanels.Desk.SetPrimaryButtonColors(new Color[] { Colors.DimWhite, Colors.WhiteNeutral, Colors.Red });

			ControlPanels.BlackBedside.SetAccessoryButtonColors(new Color[] { Colors.DimBlue, Colors.Blue, Colors.Black });
			ControlPanels.BlackBedside.SetPrimaryButtonColors(new Color[] { Colors.DimWhite, Colors.WhiteNeutral, Colors.Red });
			
			ControlPanels.Door.SetPrimaryButtonColors(new Color[] { Colors.DimWhite, Colors.WhiteNeutral, Colors.Red });



			OutletSwitches.Fan.SetOff();
			OutletSwitches.PlantLights.SetOff();
			OutletSwitches.Monitors.SetOff();
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
