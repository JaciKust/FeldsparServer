using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeldsparServer.State
{
	public abstract class BaseState : IState
	{
		public abstract void OnStateEnter();
		public abstract void OnStateLeave();

		public abstract void OnTick(DateTime currentTime);

		public abstract void HandleMessage();
	}
}
