using System;
using FeldsparServer.DataObjects;
using FeldsparServer.Interactable;
using FeldsparServer.Messaging;

namespace FeldsparServer.State
{
	public class AwakeLightsOnState : BaseState
	{
		public override IState HandleMessage(ButtonPressedDataObject buttonPressData)
		{
			return new AwakeLightsOffState();
		}

		public override void OnStateEnter(IState oldState, IMessageBus messageBus)
		{
			LifxBulbs.AllLamps.TurnOn(Colors.WhiteDaylight, 0.1);
			var controlPanelState = new PanelStateDataObject(PanelState.On);
			messageBus.Send(controlPanelState);
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
