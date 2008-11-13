using System;
using NHibernate;
using NUnit.Framework;
using JSONSample.Model;
using JSONSample.DAL;

namespace JSONSample.Test
{
	[TestFixture]
	public class TestDataAccesser
	{
		private DataAccesser da;
		public TestDataAccesser(){}

		[SetUp]
		public void Init()
		{
			da = new DataAccesser();
		}

		[TearDown]
		public void Terminate()
		{
			da = null;
		}

		[Test]
		public void Test_BuyNewComputer()
		{
			Computer c = new Computer("Bill Gates", "Microsoft-NB", "50GHz", "75GB", 88888);

			//skip check
			Assert.IsTrue(da.BuyNewComputer(c));
		}

		[Test]
		public void Test_BuyNewComputers()
		{
			Computer[] cts = new Computer[2];
			cts[0] = new Computer("NewTon", "MacBook", "10GHz", "30GB", 16888);
			cts[1] = new Computer("DarWin", "PowerBook", "20GHz", "15GB", 36888);

			//skip check
			Assert.IsTrue(da.BuyNewComputers(cts));
		}

		[Test]
		public void Test_GetComputersByOwner()
		{
            Computer[] cts = da.GetComputersByOwner("Allen");
			Assert.AreEqual(cts[0].Owner, "Allen");
			Assert.AreEqual(cts[0].HostName, "Allen_NB");
			Assert.AreEqual(cts[0].CPU, "2.0GHz");
			Assert.AreEqual(cts[0].RAM, "1.0GB");
			Assert.AreEqual(cts[0].Cost, 43000);
		}
	}
}
