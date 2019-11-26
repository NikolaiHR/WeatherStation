using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPProxy
{
    class Proxy
    {

        #region InstanceFields

        private const int PORT = 3019;
        private const string URI = "http://localhost:61565/api/Weathers";

        #endregion


        public void Start()
        {
            UdpClient udpClient = new UdpClient(PORT);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] bytes = udpClient.Receive(ref remote);
                string jsonStringToSend = Encoding.UTF8.GetString(bytes);

                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(jsonStringToSend, Encoding.UTF8, "application/json");

                    client.PostAsync(URI, content);


                }

            }

        }

    }
}
