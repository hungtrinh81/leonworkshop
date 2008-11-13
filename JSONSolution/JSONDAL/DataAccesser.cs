using System;
using System.Collections;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using JSONSample.Model;

namespace JSONSample.DAL
{
	public class DataAccesser
	{
		//static
		private static NHibernate.Cfg.Configuration config;
		private static ISessionFactory sessionFactory;

		//instance
		private ISession session;
		private ITransaction tx;
		private IQuery qry;

		static DataAccesser()
		{
			//NHibernate's Config Initialize
			config = new NHibernate.Cfg.Configuration();
			config.Configure();
			config.AddClass(typeof(Computer));

			//SessionFactory Initialize
			sessionFactory = config.BuildSessionFactory();
		}


		public DataAccesser()
		{
			//Session Instance
			
		}

		public bool BuyNewComputer(Computer c)
		{
			bool bReturn = true;
			try
			{
				session = sessionFactory.OpenSession();
				tx = session.BeginTransaction();
			
				session.Save(c);
			
				tx.Commit();
			}
			catch(Exception ex)
			{
				bReturn = false;
			}
			finally
			{
				session.Flush();
				session.Disconnect();
			}
			return bReturn;
		}

		public bool BuyNewComputers(Computer[] cts)
		{
			bool bReturn = true;
			try
			{
				session = sessionFactory.OpenSession();
				tx = session.BeginTransaction();
				
				for(int i=0;i<cts.Length;i++)
				{
					session.Save(cts[i]);
				}
			
				tx.Commit();
			}
			catch(Exception ex)
			{
				bReturn = false;
			}
			finally
			{
				session.Flush();
				session.Disconnect();
			}
			return bReturn;
		}

		public Computer[] GetComputersByOwner(string Owner)
		{
			Computer[] computers = null;
			IList list = null;
			try
			{
				session = sessionFactory.OpenSession();
				qry = session.CreateQuery("from Computer where Owner='"+Owner+"'");
				list = qry.List();
				computers = new Computer[list.Count];
				list.CopyTo(computers, 0);
			}
			finally
			{
				session.Flush();
				session.Disconnect();
			}
			return computers;
		}

	}
}
