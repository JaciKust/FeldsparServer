using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Communication.DataObject;
using FeldsparServer.Interactable;

namespace FeldsparServer.State.Rainbow
{
	public class RainbowState : BaseState
	{
		public override string Name => "Rainbow";
		private MenuLocation Location = MenuLocation.Base;
		public override void OnStateEnter(IState oldState)
		{
			SetLights();
			SetDefaultAccessories();
			SetDefaultButtonColors();
			StartShow();
		}

		public override IState HandleButtonPress(DataObjectButtonPressed buttonPressData)
		{
			return ChildHandleButtonPress(buttonPressData);
		}

		public override void OnStateLeave(IState newState)
		{
			CancelShow();
		}

		protected override IState ChildHandleButtonPress(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.ControlPanelName == ButtonControlPanel.Door)
			{
				return new AwakeLightsOnState();
			}

			if (buttonPressData.GetPressTime() == ButtonTime.Long && buttonPressData.Category == ButtonCategory.Primary){
				return new AwakeLightsOnState();
			}

			switch (Location)
			{
				case MenuLocation.Base:
					return ProcessBaseMenueClick(buttonPressData);
				case MenuLocation.Wait:
					return ProcessWaitMenuClick(buttonPressData);
				case MenuLocation.Scene:
					return ProcessSceneMenuClick(buttonPressData);
				case MenuLocation.Transition:
					return ProcessTransitionMenuClick(buttonPressData);
				case MenuLocation.Locked:
					return ProcessLockMenuClick(buttonPressData);
				case MenuLocation.Accessory:
					return ProcessAccessoryMenuClick(buttonPressData);
				default:
					break;

			}
			return null;
		}

		private void SetBase(bool restartShow)
		{
			Location = MenuLocation.Base;
			SetDefaultButtonColors();
			if (restartShow)
			{
				StartShow();
			}
		}

		private void SetWait()
		{
			Location = MenuLocation.Wait;
			ControlPanels.SetSpecialButtonColors(Colors.Black, Colors.DarkRed, Colors.Black);
			ControlPanels.SetAccessoryButtonColors(Colors.Red, Colors.DarkRed, Colors.Magenta);
			ControlPanels.SetPrimaryButtonColors(WaitTime.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);
		}

		private void SetScene()
		{
			Location = MenuLocation.Scene;
			ControlPanels.SetSpecialButtonColors(Colors.Black, Colors.DarkRed, Colors.Black);
			ControlPanels.SetAccessoryButtonColors(Colors.Yellow, Colors.DarkYellow, Colors.Red);
			ControlPanels.SetPrimaryButtonColors(Scene.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);
		}

		private void SetTransition()
		{
			Location = MenuLocation.Transition;
			ControlPanels.SetSpecialButtonColors(Colors.Black, Colors.DarkRed, Colors.Black);
			ControlPanels.SetAccessoryButtonColors(Colors.Green, Colors.DarkGreen, Colors.Yellow);
			ControlPanels.SetPrimaryButtonColors(TransitionSpeed.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);
		}

		private void SetLocked()
		{
			Location = MenuLocation.Locked;
			ControlPanels.SetSpecialButtonColors(Colors.Black, Colors.DarkRed, Colors.Black);
			ControlPanels.SetAccessoryButtonColors(Colors.Black, Colors.DarkRed, Colors.Black);
			ControlPanels.SetPrimaryButtonColors(Colors.Black, Colors.DarkRed, Colors.Black);
		}

		private void SetAccessory()
		{
			Location = MenuLocation.Accessory;
			ControlPanels.SetSpecialButtonColors(Colors.Black, Colors.DarkRed, Colors.Black);
			ControlPanels.SetAccessoryButtonColors(Colors.Blue, Colors.DarkBlue, Colors.Cyan);
			ControlPanels.SetPrimaryButtonColors(Colors.Black, Colors.DarkRed, Colors.Blue);
		}



		private IState ProcessBaseMenueClick(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					SetTransition();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					SetScene();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{

				}

			}
			else if (buttonPressData.Category == ButtonGroup.Accessory)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					SetWait();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					SetAccessory();
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{
					SetLocked();
				}
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

		private IState ProcessSceneMenuClick(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				SetBase(restartShow: true);
				//if (buttonPressData.GetPressTime() == ButtonTime.Short)
				//{
				//}
				//else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				//{

				//}
				//else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				//{
				//}

			}
			else if (buttonPressData.Category == ButtonGroup.Accessory)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					Scene.Increment();
					ControlPanels.SetPrimaryButtonColors(Scene.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);

				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					Scene.Decrement();
					ControlPanels.SetPrimaryButtonColors(Scene.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{
				}
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

		private IState ProcessWaitMenuClick(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				SetBase(restartShow: true);
				//if (buttonPressData.GetPressTime() == ButtonTime.Short)
				//{
				//}
				//else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				//{

				//}
				//else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				//{
				//}
			}
			else if (buttonPressData.Category == ButtonGroup.Accessory)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					WaitTime.Increment();
					ControlPanels.SetPrimaryButtonColors(WaitTime.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);

				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					WaitTime.Decrement();
					ControlPanels.SetPrimaryButtonColors(WaitTime.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{
				}
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

		private IState ProcessTransitionMenuClick(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				SetBase(restartShow: true);
				//if (buttonPressData.GetPressTime() == ButtonTime.Short)
				//{
				//}
				//else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				//{

				//}
				//else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				//{
				//}
			}
			else if (buttonPressData.Category == ButtonGroup.Accessory)
			{
				if (buttonPressData.GetPressTime() == ButtonTime.Short)
				{
					TransitionSpeed.Increment();
					ControlPanels.SetPrimaryButtonColors(TransitionSpeed.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				{
					TransitionSpeed.Decrement();
					ControlPanels.SetPrimaryButtonColors(TransitionSpeed.Value.ButtonColor, Colors.DimWhite, Colors.WhietBrightDaylight);
				}
				else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				{
				}
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

		private IState ProcessAccessoryMenuClick(DataObjectButtonPressed buttonPressData)
		{
			if (buttonPressData.Category == ButtonGroup.Primary)
			{
				SetBase(restartShow: false);
				//if (buttonPressData.GetPressTime() == ButtonTime.Short)
				//{
				//}
				//else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
				//{

				//}
				//else if (buttonPressData.GetPressTime() == ButtonTime.Long)
				//{
				//}

			}
			else if (buttonPressData.Category == ButtonGroup.Accessory)
			{
				try
				{
					HandleAccessories(buttonPressData);
				}
				catch (SetNavigationException) { }
			}
			else if (buttonPressData.Category == ButtonGroup.Special)
			{
				SetBase(restartShow: false);
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

		private IState ProcessLockMenuClick(DataObjectButtonPressed buttonPressData)
		{
			SetBase(restartShow: false);
			//if (buttonPressData.Category == ButtonGroup.Primary)
			//{
			//	if (buttonPressData.GetPressTime() == ButtonTime.Short)
			//	{

			//	}
			//	else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
			//	{

			//	}
			//	else if (buttonPressData.GetPressTime() == ButtonTime.Long)
			//	{
			//	}

			//}
			//else if (buttonPressData.Category == ButtonGroup.Accessory)
			//{
			//	if (buttonPressData.GetPressTime() == ButtonTime.Short)
			//	{

			//	}
			//	else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
			//	{

			//	}
			//	else if (buttonPressData.GetPressTime() == ButtonTime.Long)
			//	{
			//	}
			//}
			//else if (buttonPressData.Category == ButtonGroup.Special)
			//{
			//	if (buttonPressData.GetPressTime() == ButtonTime.Short)
			//	{

			//	}
			//	else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
			//	{

			//	}
			//	else if (buttonPressData.GetPressTime() == ButtonTime.Long)
			//	{

			//	}
			//}

			return null;
		}


		protected override void SetDefaultAccessories()
		{
			OutletSwitches.Fan.SetOff();
			OutletSwitches.PlantLights.SetOff();
			OutletSwitches.AirFilter.SetOff();
			OutletSwitches.Monitors.SetOff();
		}

		protected override void SetDefaultButtonColors()
		{
			ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.DimMagenta, Colors.Red, Colors.Magenta });
			ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.DimCyan, Colors.Blue, Colors.Cyan });
			ControlPanels.SetSpecialButtonColors(new Color[] { Colors.Black, Colors.DarkRed, Colors.Black });
		}

		protected override void SetLights()
		{
			LifxBulbs.AllLamps.TurnOn(Colors.Magenta, 1);
		}

		private enum MenuLocation
		{
			Base,
			Scene,
			Transition,
			Wait,
			Locked,
			Accessory,
		}

		private RainbowControl WaitTime = new RainbowControl(
			new RainbowSetting[]
			{
				new RainbowSetting(Colors.DimRed, 0),
				new RainbowSetting(Colors.DimGreen, 1),
				new RainbowSetting(Colors.DimBlue, 5),
				new RainbowSetting(Colors.DimCyan, 10),
				new RainbowSetting(Colors.DimMagenta, 30),
				new RainbowSetting(Colors.DimYellow)
			},
			0
		);

		private RainbowControl TransitionSpeed = new RainbowControl(
			new RainbowSetting[]
			{
				new RainbowSetting(Colors.DimRed, 0),
				new RainbowSetting(Colors.DimGreen, 1),
				new RainbowSetting(Colors.DimBlue, 5),
				new RainbowSetting(Colors.DimCyan, 10),
				new RainbowSetting(Colors.DimMagenta, 30),
				new RainbowSetting(Colors.DimYellow)
			},
			2
		);

		private RainbowControl Scene = new RainbowControl(
			new RainbowSetting[]
			{
				new RainbowSetting(Colors.DimRed, 0),
				new RainbowSetting(Colors.DimBlue, 1)
			},
			0
		);
		private LightShow LightShow = null;
		private void StartShow()
		{
			CancelShow();
			LightShow = new LightShow(TransitionSpeed.Value.Value, WaitTime.Value.Value, Scene.Value.Value);
			LightShow.Start();
		}

		private void CancelShow()
		{
		if (LightShow == null){
				return;
		}
			LightShow.Stop();
		}

	}

}
