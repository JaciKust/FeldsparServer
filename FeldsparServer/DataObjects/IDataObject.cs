using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeldsparServer.DataObjects
{
	public interface IDataObject
	{
		public string Name { get; set; }
		public string Topic { get; set; }

		public string ToJson();
	}
}
