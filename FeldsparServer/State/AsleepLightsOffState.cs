using System;
using Communication.DataObject;
using Communication.MessageBus;

namespace FeldsparServer.State
{
	public class AsleepLightsOffState : BaseState
	{
		public override IState HandleMessage(DataObjectButtonPressed buttonPressData)
		{
			throw new NotImplementedException();
		}

		public override void OnStateEnter(IState oldState, IMessageBus messageBus)
		{
			throw new NotImplementedException();
		}

		public override void OnStateLeave(IState newState)
		{
			throw new NotImplementedException();
		}

		public override void OnTick(DateTime currentTime)
		{
			throw new NotImplementedException();
		}
	}
}
