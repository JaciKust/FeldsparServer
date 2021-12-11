using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;

namespace FeldsparServer.State
{
	public abstract class BaseState : IState
	{
		public abstract void OnStateEnter(IState oldState);
		public abstract void OnStateLeave(IState newState);

		public abstract void OnTick(DateTime currentTime);

		public abstract IState HandleMessage(ButtonPressedDataObject buttonPressData);
	}
}
