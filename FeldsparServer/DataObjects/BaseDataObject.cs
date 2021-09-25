using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeldsparServer.DataObjects
{
	public abstract class BaseDataObject
	{
		public BaseDataObject(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
