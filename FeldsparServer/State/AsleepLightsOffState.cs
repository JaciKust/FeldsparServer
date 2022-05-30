using System;
using Common;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AsleepLightsOffState : BaseState
	{
		public override string Name => "Asleep OFF";
		protected override IState ChildHandleButtonPress(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					return new AsleepLightsOnState();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					return new AwakeLightsOnState(5);
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{
					return new AwakeLightsOnState(300);
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
			if (oldState is AsleepLightsOnState){
				SetLights();
			}
			else {
				LifxBulbs.AllLamps.TurnOff(10);
			}

			SetDefaultAccessories();
			SetDefaultButtonColors();
		}

		protected override void SetLights()
		{
			LifxBulbs.AllLamps.TurnOff();
		}

		protected override void SetDefaultButtonColors()
		{
			ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.DarkRed, Colors.DimRed, Colors.Blue });
			ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.Black, Colors.DimBlue, Colors.Blue });
			ControlPanels.SetSpecialButtonColors(new Color[] { Colors.Black, Colors.DimGreen, Colors.Green });
		}

		protected override void SetDefaultAccessories()
		{
			OutletSwitches.Fan.SetOn();
			OutletSwitches.PlantLights.SetOff();
			OutletSwitches.Monitors.SetOff();
		}
	}
}
