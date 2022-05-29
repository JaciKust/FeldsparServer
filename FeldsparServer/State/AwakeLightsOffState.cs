using System;
using Common;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOffState : BaseState
	{
		public override string Name => "Awake OFF";
		public override IState HandleMessage(DataObjectButtonPressed buttonPressData)
		{
			return new AwakeLightsOnState();
		}

		public override void OnStateEnter(IState oldState, IMessageBus messageBus)
		{
			Console.WriteLine(Name);
			LifxBulbs.AllLamps.TurnOff(2);

			ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.DarkWhite, Colors.DimWhite, Colors.DimRed });
			ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.Black, Colors.DimBlue, Colors.DimRed });
			ControlPanels.SetSpecialButtonColors(new Color[] { Colors.Black, Colors.DimGreen, Colors.DimRed });

			OutletSwitches.Fan.SetOff();
			OutletSwitches.PlantLights.SetOn();
			OutletSwitches.Monitors.SetOn();


			//Console.WriteLine(Name);
			//LifxBulbs.AllLamps.TurnOn(Colors.WhiteDaylight, 1);
			//ControlPanels.SetPrimaryButtonColor(new Color[] { Colors.DimWhite, Colors.WhiteNeutral, Colors.Red });
			//ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.DimBlue, Colors.Blue, Colors.Black });
			//ControlPanels.SetSpecialButtonColors(new Color[] { Colors.DimGreen, Colors.Green, Colors.Red });
			//OutletSwitches.Fan.SetOff();
			//OutletSwitches.Monitors.SetOn();
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
