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
				HandleAccessories(buttonPressData);
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

		protected override void SetLights()
		{
			LifxBulbs.AllLamps.TurnOn(Colors.WhiteDaylight, 1);
		}

		protected override void SetDefaultButtonColors()
		{
			ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.DimWhite, Colors.WhiteNeutral, Colors.Red });
			ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.DimBlue, Colors.Blue, Colors.Red });
			ControlPanels.SetSpecialButtonColors(new Color[] { Colors.DimGreen, Colors.Green, Colors.Red });
		}

		protected override void SetDefaultAccessories()
		{
			OutletSwitches.Fan.SetOff();
			OutletSwitches.Monitors.SetOn();
			OutletSwitches.PlantLights.SetOff();
		}

		public override void OnStateEnter(IState oldState)
		{
			if (oldState is AsleepLightsOffState || oldState is AsleepLightsOnState){
				LifxBulbs.AllLamps.TurnOn(Colors.WhiteDaylight, 5);
			}
			else {
				SetLights();
			}

			SetDefaultAccessories();
			SetDefaultButtonColors();
		}
	}
}
