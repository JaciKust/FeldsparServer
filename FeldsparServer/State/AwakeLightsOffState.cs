using System;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOffState : BaseState
	{
		public override IState HandleMessage(DataObjectButtonPressed buttonPressData)
		{
			return new AwakeLightsOnState();
		}

		public override void OnStateEnter(IState oldState, IMessageBus messageBus)
		{
			LifxBulbs.AllLamps.TurnOff();
			var controlPanelState = new PanelStateDataObject(PanelState.Minimal);
			messageBus.Send(controlPanelState);
			OutletSwitches.Fan.SetOn();
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
