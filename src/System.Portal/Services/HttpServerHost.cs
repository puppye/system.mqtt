using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace System.Portal.Services
{
    public class HttpServerHost : IHostedService
    {

        private Socket workSocket;
        private readonly ILogger<HttpServerHost> logger;

        public HttpServerHost(ILogger<HttpServerHost> logger)
        {
            workSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("socket is starting...");
            InitService();
            logger.LogInformation("socket started...");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("socket is stopping...");
            workSocket.Close();

            workSocket.Dispose();

            logger.LogInformation("socket stopped...");

            return Task.CompletedTask;
        }

        private void InitService()
        {
            workSocket.Bind(new IPEndPoint(IPAddress.Any, 15001));

            workSocket.Listen(100);

            workSocket.BeginAccept(callback, workSocket);
        }

        private void callback(IAsyncResult ar)
        {
            var listener = (Socket)ar.AsyncState;

            // End the operation and display the received data on the console.
            byte[] Buffer;
            int bytesTransferred;
            Socket handler = listener.EndAccept(out Buffer, out bytesTransferred, ar);

            logger.LogInformation(handler.RemoteEndPoint.AddressFamily.ToString());
            // string stringTransferred = Encoding.ASCII.GetString(Buffer, 0, bytesTransferred);

            // handler.Send(Encoding.UTF8.GetBytes("Hello from http server via TCP/IP!"));
        }
    }
}
