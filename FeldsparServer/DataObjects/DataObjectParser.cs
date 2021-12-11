using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FeldsparServer.DataObjects
{
	public static class DataObjectParser
	{
		public static T FromJson<T>(string json) where T : IDataObject {
			return JsonSerializer.Deserialize<T>(json);
		}
	}
}
