using System;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public abstract class BaseState : IState
	{
		public abstract string Name { get; }
		public abstract void OnStateEnter(IState oldState, IMessageBus messageBus);
		public abstract void OnStateLeave(IState newState);

		public abstract void OnTick(DateTime currentTime);

		protected abstract IState ChildHandleButtonPress(DataObjectButtonPressed buttonPressData);

		public IState HandleButtonPress(DataObjectButtonPressed buttonPressData){
			return ChildHandleButtonPress(buttonPressData);
		}

		protected static void HandleAccessories(DataObjectButtonPressed buttonPressData)
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
	}
}
