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
					SetLights();
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

		public override void OnStateEnter(IState oldState)
		{
			SetLights();
			SetDefaultAccessories();
			SetDefaultButtonColors();
		}

		protected override void SetLights()
		{
			LifxBulbs.AllLamps.TurnOff();
			LifxBulbs.BedsideBlackLamp.TurnOn(Colors.GetWhite(Kelvin.Incandesant, 102));
		}

		protected override void SetDefaultButtonColors()
		{
			ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.DarkRed, Colors.DimRed, Colors.Blue });
			ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.DarkBlue, Colors.DimBlue, Colors.Blue });
			ControlPanels.SetSpecialButtonColors(new Color[] { Colors.DarkGreen, Colors.DimGreen, Colors.Green });
		}

		protected override void SetDefaultAccessories()
		{
			OutletSwitches.Fan.SetOn();
			OutletSwitches.PlantLights.SetOff();
			OutletSwitches.Monitors.SetOff();
		}
	}
}
