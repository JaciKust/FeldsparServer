using System;
using Communication.MessageBus;
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
			_messageBus.OnRecieve += OnReceiveMessage;
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

		private void OnReceiveMessage(object sender, ButtonPressEventArgs e)
		{
			IState newState = _currentState.HandleMessage(e.ButtonPressedData);
			if (newState == null)
			{
				// If the returned state is null no further changes are neded. 
				return;
			}

			SetState(newState);
		}

		private void SetState(IState newState)
		{
			IState oldState = _currentState;

			oldState.OnStateLeave(newState);
			newState.OnStateEnter(oldState, _messageBus);

			_currentState = newState;
		}
	}
}
