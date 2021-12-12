using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;
using FeldsparServer.Interactable;
using FeldsparServer.Messaging;

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
