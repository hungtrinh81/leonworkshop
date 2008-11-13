<%@ WebHandler Class="JSONWeb.Provider" Language="C#" %>

namespace JSONWeb
{
    using System;
    using System.Web;
    using Jayrock.Json;
    using Jayrock.JsonRpc;
    using Jayrock.JsonRpc.Web;
    using NHibernate;
	using JSONSample.Model;
	using JSONSample.DAL;

    public class Provider : JsonRpcHandler
    {
        [ JsonRpcMethod("getComputer") ]
        public Computer[] GetComputer(string s)
        {
            DataAccesser da = new DataAccesser();
            Computer[] cts = da.GetComputersByOwner(s);
            da = null;
            
            return cts;
        }
    }
}

