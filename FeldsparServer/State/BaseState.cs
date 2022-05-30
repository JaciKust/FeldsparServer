using System;
using Common;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public abstract class BaseState : IState
	{
		public abstract string Name { get; }
		public abstract void OnStateEnter(IState oldState);

		protected abstract void SetLights();
		protected abstract void SetDefaultButtonColors();
		protected abstract void SetDefaultAccessories();

		public virtual void OnStateLeave(IState newState) { }

		public virtual void OnTick(DateTime currentTime) { }

		protected abstract IState ChildHandleButtonPress(DataObjectButtonPressed buttonPressData);

		public virtual void ClearNavigation()
		{
			_inAccessoryNavigation = false;
		}

		public IState HandleButtonPress(DataObjectButtonPressed buttonPressData)
		{
			try
			{
				if (_inAccessoryNavigation)
				{
					if (buttonPressData.Category == ButtonGroup.Accessory){
						if (buttonPressData.GetPressTime() == ButtonTime.Short)
						{
							OutletSwitches.AirFilter.Toggle();
						}
						else if (buttonPressData.GetPressTime() == ButtonTime.Medium)
						{
							OutletSwitches.Monitors.Toggle();
						}
					}
					ClearNavigation();
					SetDefaultButtonColors();
					return null;
				}
				else
				{
					var newState = ChildHandleButtonPress(buttonPressData);
					return newState;
				}
			}
			catch (SetNavigationException)
			{
				return null;
			}
		}

		private bool _inAccessoryNavigation = false;

		protected void HandleAccessories(DataObjectButtonPressed buttonPressData)
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
				_inAccessoryNavigation = true;
				ControlPanels.SetPrimaryButtonColors(new Color[] { Colors.Black, Colors.DarkRed, Colors.Black });
				ControlPanels.SetSpecialButtonColors(new Color[] { Colors.Black, Colors.DarkRed, Colors.Black });
				ControlPanels.SetAccessoryButtonColors(new Color[] { Colors.Red, Colors.Blue, Colors.Green });

				throw new SetNavigationException();
			}
		}
	}
}
