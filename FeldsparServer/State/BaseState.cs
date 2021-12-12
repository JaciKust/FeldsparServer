using System;
using Communication.DataObject;
using Communication.MessageBus;

namespace FeldsparServer.State
{
	public abstract class BaseState : IState
	{
		public abstract void OnStateEnter(IState oldState, IMessageBus messageBus);
		public abstract void OnStateLeave(IState newState);

		public abstract void OnTick(DateTime currentTime);

		public abstract IState HandleMessage(DataObjectButtonPressed buttonPressData);
	}
}
