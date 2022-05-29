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
		protected override IState ChildHandleButtonPress(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					return new AwakeLightsOffState();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					return new AsleepLightsOffState();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{

				}
			}
			else if (buttonPressData.Category == ButtonGroup.Accessory)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					OutletSwitches.Fan.Toggle();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					OutletSwitches.PlantLights.Toggle();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{
					OutletSwitches.Monitors.Toggle();
				}
			}
			else if (buttonPressData.Category == ButtonGroup.Special) {
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{

				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{

				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{

				}
			}
			return null;
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
