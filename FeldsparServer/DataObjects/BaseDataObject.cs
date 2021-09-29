using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeldsparServer.DataObjects
{
	public abstract class BaseDataObject
	{
		public BaseDataObject(string name, string topic)
		{
			Name = name;
			Topic = topic;
		}

		public string Name { get; set; }

		public string Topic { get; set; }

	}
}
