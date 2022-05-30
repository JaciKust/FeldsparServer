using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeldsparServer.State
{
	public class SetNavigationException : Exception
	{
		public SetNavigationException() : base("I set the navigation")
		{

		}
	}
}
