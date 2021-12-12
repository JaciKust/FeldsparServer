using System;
using FeldsparServer.DataObjects;
using FeldsparServer.Messaging;

namespace FeldsparServer.State
{
	public interface IState
	{
		public void OnTick(DateTime currentTime);
		public void OnStateEnter(IState oldState, IMessageBus messageBus);
		public void OnStateLeave(IState newState);

		public IState HandleMessage(DataObjectButtonPressed buttonPressData);
	}
}
