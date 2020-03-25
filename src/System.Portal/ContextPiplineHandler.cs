using Microsoft.AspNetCore.Connections;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Portal
{
    public class ContextPiplineHandler
    {

        private readonly ConnectionContext connection;

        public ContextPiplineHandler(ConnectionContext @connection)
        {
            this.connection = @connection;

        }

        public delegate void ConnectionAbortHandler(ConnectionContext connection);

        public event ConnectionAbortHandler OnConnectionAbort;



    }
}
