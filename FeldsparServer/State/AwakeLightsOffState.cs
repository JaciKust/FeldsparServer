using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOffState : BaseState
	{
		public override IState HandleMessage(ButtonPressedDataObject buttonPressData)
		{
			return new AwakeLightsOnState();
		}

		public override void OnStateEnter(IState oldState)
		{
			LifxBulbs.AllLamps.TurnOff();
		}

		public override void OnStateLeave(IState newState)
		{

		}

		public override void OnTick(DateTime currentTime)
		{
			// No-op
		}
	}
}
