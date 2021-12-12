using System;
using Communication.DataObject;
using Communication.MessageBus;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOnState : BaseState
	{
		public override IState HandleMessage(DataObjectButtonPressed buttonPressData)
		{
			return new AwakeLightsOffState();
		}

		public override void OnStateEnter(IState oldState, IMessageBus messageBus)
		{
			LifxBulbs.AllLamps.TurnOn(Colors.WhiteDaylight, 0.1);
			var controlPanelState = new PanelStateDataObject(PanelState.On);
			messageBus.Send(controlPanelState);
			OutletSwitches.Fan.SetOff();
			OutletSwitches.PlantLights.SetOff();
			OutletSwitches.Monitors.SetOff();
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
