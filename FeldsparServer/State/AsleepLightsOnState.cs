using System;
using Common;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AsleepLightsOnState : BaseState
	{
		public override string Name => "Asleep on";
		protected override IState ChildHandleButtonPress(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					return new AsleepLightsOffState();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					return new AwakeLightsOnState();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{

				}
			}
			else if (buttonPressData.Category == ButtonGroup.Accessory)
			{
				HandleAccessories(buttonPressData);
			}
			else if (buttonPressData.Category == ButtonGroup.Special)
			{
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
			LifxBulbs.AllLamps.TurnOff();
			LifxBulbs.BedsideBlackLamp.TurnOn(Colors.GetWhite(Kelvin.Incandesant, 102));
			OutletSwitches.Fan.SetOn();
			OutletSwitches.PlantLights.SetOff();
			OutletSwitches.Monitors.SetOff();

			ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.DarkRed, Colors.DimRed, Colors.Blue });
			ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.DarkBlue, Colors.DimBlue, Colors.Blue });
			ControlPanels.SetSpecialButtonColors(new Color[] { Colors.DarkGreen, Colors.DimGreen, Colors.Green });
		}

		public override void OnStateLeave(IState newState)
		{
			
		}

		public override void OnTick(DateTime currentTime)
		{
			
		}
	}
}
