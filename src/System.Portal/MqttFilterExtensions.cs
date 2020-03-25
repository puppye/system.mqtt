using Microsoft.AspNetCore.Connections;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Portal
{
    public static class MqttFilterExtensions
    {
        public static IConnectionBuilder UseMqttFilter(this IConnectionBuilder builder)
        {
            return builder.Use((connection, next) =>
            {
                /// Write code here to use the connection to filter the connection before the handshake

                Console.WriteLine(connection.ConnectionId);

                return next();
            });
        }

    }
}
