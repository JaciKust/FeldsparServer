using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;
using FeldsparServer.Messaging;

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
