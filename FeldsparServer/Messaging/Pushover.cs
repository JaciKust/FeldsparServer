using System.Collections.Specialized;
using System.Net;

namespace FeldsparServer.Messaging
{
	public class Pushover
	{
		public void Send(string message)
		{
			var parameters = new NameValueCollection {
				{ "token", "agqui287q27ha4iown3dsrxtv3zovc" },
				{ "user", "uooy74z4276zq22zu39g1zgbaxzj1a" },
				{ "device", "JaciScribe" },
				{ "message", message }
			};

			using (var client = new WebClient())
			{
				client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
			}
		}
	}
}
