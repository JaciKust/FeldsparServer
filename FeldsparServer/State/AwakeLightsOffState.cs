﻿using System;
using Common;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOffState : BaseState
	{
		public override string Name => "Awake OFF";
		protected override IState ChildHandleButtonPress(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					return new AwakeLightsOnState();
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
			Console.WriteLine(Name);
			LifxBulbs.AllLamps.TurnOff(2);

			ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.DarkWhite, Colors.DimWhite, Colors.DimRed });
			ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.Black, Colors.DimBlue, Colors.DimRed });
			ControlPanels.SetSpecialButtonColors(new Color[] { Colors.Black, Colors.DimGreen, Colors.DimRed });

			OutletSwitches.Fan.SetOff();
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
