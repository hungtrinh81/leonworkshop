using System;

namespace JSONSample.Model
{
	public class Computer
	{
		private string _UID;
		private string _Owner;
		private string _HostName;
		private string _CPU;
		private string _RAM;
		private int _Cost;

		public Computer(){}
		public Computer(string Owner, string HostName, string CPU, string RAM, int Cost)
		{
			_Owner = Owner;
			_HostName = HostName;
			_CPU = CPU;
			_RAM = RAM;
			_Cost = Cost;
		}

		public virtual string UID
		{
			get {return _UID;}
			set {_UID = value;}
		}

		public virtual string Owner
		{
			get {return _Owner;}
			set {_Owner = value;}
		}

		public virtual string HostName
		{
			get {return _HostName;}
			set {_HostName = value;}
		}

		public virtual string CPU
		{
			get {return _CPU;}
			set {_CPU = value;}
		}

		public virtual string RAM
		{
			get {return _RAM;}
			set {_RAM = value;}
		}

		public virtual int Cost
		{
			get {return _Cost;}
			set {_Cost = value;}
		}
	}
}
