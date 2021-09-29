using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeldsparServer.State
{
	public interface IState
	{
		public void OnTick(DateTime currentTime);
		public void OnStateEnter();
		public void OnStateLeave();

		public void HandleMessage();
	}
}
