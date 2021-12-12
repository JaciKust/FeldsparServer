using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;
using FeldsparServer.Messaging;

namespace FeldsparServer.State
{
	public class AsleepLightsOnState : BaseState
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
