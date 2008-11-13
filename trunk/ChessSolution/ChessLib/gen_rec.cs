using System;

namespace Chess
{
	/// <summary>
	/// 使用於建立合法棋步記錄所用的堆疊類別
	/// </summary>
	public class gen_rec
	{
		/// <summary>
		/// 合法棋步
		/// </summary>
		private move m_move;
		/// <summary>
		/// 內部優先權數
		/// </summary>
		private int m_prior;
		/// <summary>
		/// 取得或設定合法棋步
		/// </summary>
		public move Move
		{
			get{return m_move;}
			set{m_move = value;}
		}
		/// <summary>
		/// 取得或設定內部優先權數
		/// </summary>
		public int Prior
		{
			get{return m_prior;}
			set{m_prior = value;}
		}
		/// <summary>
		/// 預設建構子
		/// </summary>
		public gen_rec()
		{
			m_move = new move();
			m_prior = 0;
		}
		/// <summary>
		/// 傳入棋步的建構子
		/// </summary>
		/// <param name="m">傳入的合法棋步</param>
		public gen_rec(move m)
		{
			m_move = m;
			m_prior = 0;
		}
		/// <summary>
		/// 傳入棋步及優先權數的建構子
		/// </summary>
		/// <param name="m">傳入的合法棋步</param>
		/// <param name="p">傳入的優先權數</param>
		public gen_rec(move m, int p)
		{
			m_move = m;
			m_prior = p;
		}
	}
}
