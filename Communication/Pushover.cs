using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
	public class Pushover
	{
		public void Send(string message)
		{
			var parameters = new NameValueCollection {
				{ "token", "agqui287q27ha4iown3dsrxtv3zovc" },
				{ "user", "uooy74z4276zq22zu39g1zgbaxzj1a" },
				{ "message", message }
			};

			using (var client = new WebClient())
			{
				client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
			}
		}
	}
}
