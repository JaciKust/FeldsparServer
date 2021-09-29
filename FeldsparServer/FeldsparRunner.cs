using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.Messaging;
using FeldsparServer.State;

namespace FeldsparServer
{
	public class FeldsparRunner
	{
		private IState _currentState;
		private IMessageBus _messageBus;
		public FeldsparRunner(IMessageBus messageBus)
		{
			_messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
			Init();
		}

		public void Init()
		{
			_currentState = new AwakeLightsOnState();
		}

		public void OnTick(DateTime currentTime)
		{
			_currentState.OnTick(currentTime);
		}

		private void OnReceiveMessage(object sender, EventArgs e)
		{
			_currentState.HandleMessage();
		}
	}
}
