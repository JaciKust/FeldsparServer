using System;
using Common;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOnState : BaseState
	{
		public override string Name => "Awake on";
		public override IState HandleMessage(DataObjectButtonPressed buttonPressData)
		{
			return new AwakeLightsOffState();
		}

		public override void OnStateEnter(IState oldState, IMessageBus messageBus)
		{
			Console.WriteLine(Name);
			LifxBulbs.AllLamps.TurnOn(Colors.WhiteDaylight, 1);
			ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.DimWhite, Colors.WhiteNeutral, Colors.Red });
			ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.DimBlue, Colors.Blue, Colors.Black });
			ControlPanels.SetSpecialButtonColors(new Color[] { Colors.DimGreen, Colors.Green, Colors.Red });
			OutletSwitches.Fan.SetOff();
			OutletSwitches.Monitors.SetOn();
			OutletSwitches.PlantLights.SetOff();
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
