using Common;
using Communication.DataObject;
using FeldsparServer.Interactable;
using FeldsparServer.State.Rainbow;

namespace FeldsparServer.State
{
	public class AwakeLightsOnState : BaseState
	{
		public AwakeLightsOnState(double transitionTime = 1.0)
		{
			_transitionTime = transitionTime;
		}

		private double _transitionTime;

		public override string Name => "Awake on";
		protected override IState ChildHandleButtonPress(DataObjectButtonPressed buttonPressData)
		{
			const double transitionTimeS = 5.0;
			if (_inSceneNavigation)
			{
				if (buttonPressData.ControlPanelName == ButtonControlPanel.Door)
				{
					SetLights();
				}
				else if (buttonPressData.Category == ButtonGroup.Primary)
				{
					if (buttonPressData.GetPressTime() == ButtonTime.Short)
					{
						LifxBulbs.AllLamps.TurnOff(transitionTimeS);
						var incandesant = Colors.GetWhite(Kelvin.Incandesant, 90);
						LifxBulbs.Hotel.TurnOn(incandesant, transitionTimeS);
						LifxBulbs.India.TurnOn(incandesant, transitionTimeS);
						var daylight = Colors.GetWhite(Kelvin.Daylight, 255);
						LifxBulbs.Papa.TurnOn(daylight, transitionTimeS);
						LifxBulbs.Quebec.TurnOn(daylight, transitionTimeS);
						SetAccessoriesForScene();
						_inScene = true;
					}
					else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
					{
						LifxBulbs.AllLamps.TurnOn(Colors.Blue, 5);
						SetAccessoriesForScene();
						_inScene = true;
					}
					else if (buttonPressData.GetPressTime() == ButtonTime.Long)
					{
						return new RainbowState();
					}
				}
				else if (buttonPressData.Category == ButtonGroup.Special)
				{
					if (buttonPressData.GetPressTime() == ButtonTime.Short)
					{
						LifxBulbs.AllLamps.TurnOff(transitionTimeS);
						var daylight = Colors.GetWhite(Kelvin.BlueDaylight, 255);
						LifxBulbs.DeskLamps.TurnOn(daylight, transitionTimeS);
						LifxBulbs.BedsideBlackLamp.TurnOn(daylight, transitionTimeS);
						LifxBulbs.BedsideWhiteLamp.TurnOn(daylight, transitionTimeS);
						SetAccessoriesForScene();
						_inScene = true;
					}
					else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
					{
						LifxBulbs.AllLamps.TurnOn(Colors.GetWhite(Kelvin.BrightDaylight, 255), 1);
						_inScene = true;
					}
					else if (buttonPressData.GetPressTime() == ButtonTime.Long)
					{
						// TBD;
					}
				}

				ClearNavigation();
				return null;
			}
			else
			{
				if (buttonPressData.Category == ButtonGroup.Primary)
				{
					if (buttonPressData.GetPressTime() == ButtonTime.Short)
					{
						if (_inScene)
						{
							return new AwakeLightsOnState();
						}
						return new AwakeLightsOffState();
					}
					else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
					{
						return new AsleepLightsOffState();
					}
					else if (buttonPressData.GetPressTime() == ButtonTime.Long)
					{
						_inSceneNavigation = true;
						ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.Black, Colors.DarkRed, Colors.Black });
						ControlPanels.SetSpecialButtonColors(new Color[] { Colors.Green, Colors.DarkRed, Colors.Black });
						ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.Red, Colors.Blue, Colors.Green });
						throw new SetNavigationException();
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
		}

		private bool _inSceneNavigation = false;
		private bool _inScene = false;

		protected override void ClearNavigation()
		{
			base.ClearNavigation();
			_inSceneNavigation = false;
		}

		protected override void SetLights()
		{
			LifxBulbs.AllLamps.TurnOn(_dailyWhite, _transitionTime);
			if (_transitionTime != 1.0) {
				_transitionTime = 1.0;
			}
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

		private static Color _dailyWhite { get; } = Colors.GetWhite(Kelvin.Neutral, 135);

		public override void OnStateEnter(IState oldState)
		{
			SetLights();

			SetDefaultAccessories();
			SetDefaultButtonColors();
		}
	}
}
