using System;
using Communication.DataObject;
using Communication.MessageBus;

namespace FeldsparServer.State
{
	public interface IState
	{
		public string Name { get; }
		public void OnTick(DateTime currentTime);
		public void OnStateEnter(IState oldState, IMessageBus messageBus);
		public void OnStateLeave(IState newState);

		public IState HandleMessage(DataObjectButtonPressed buttonPressData);
	}
}
