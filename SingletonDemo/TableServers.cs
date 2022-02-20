using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public class TableServers
    {
        private static readonly TableServers instance = new();
        private List<string> servers = new();
        private int serverNum = 0;
        public TableServers()
        {
            servers.Add("Johnny");
            servers.Add("Marry");
            servers.Add("David");
        }

        public static TableServers GetTableServer()
        {
            return instance;
        }

        public string GetWhoIsServer()
        {
            string result = servers[serverNum];

            serverNum++;

            if(serverNum >= servers.Count) serverNum = 0;

            return result;
        }
    }
}
