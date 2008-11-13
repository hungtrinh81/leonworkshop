using System;

namespace Chess
{
	/// <summary>
	/// �ϥΩ�إߦX�k�ѨB�O���ҥΪ����|���O
	/// </summary>
	public class gen_rec
	{
		/// <summary>
		/// �X�k�ѨB
		/// </summary>
		private move m_move;
		/// <summary>
		/// �����u���v��
		/// </summary>
		private int m_prior;
		/// <summary>
		/// ���o�γ]�w�X�k�ѨB
		/// </summary>
		public move Move
		{
			get{return m_move;}
			set{m_move = value;}
		}
		/// <summary>
		/// ���o�γ]�w�����u���v��
		/// </summary>
		public int Prior
		{
			get{return m_prior;}
			set{m_prior = value;}
		}
		/// <summary>
		/// �w�]�غc�l
		/// </summary>
		public gen_rec()
		{
			m_move = new move();
			m_prior = 0;
		}
		/// <summary>
		/// �ǤJ�ѨB���غc�l
		/// </summary>
		/// <param name="m">�ǤJ���X�k�ѨB</param>
		public gen_rec(move m)
		{
			m_move = m;
			m_prior = 0;
		}
		/// <summary>
		/// �ǤJ�ѨB���u���v�ƪ��غc�l
		/// </summary>
		/// <param name="m">�ǤJ���X�k�ѨB</param>
		/// <param name="p">�ǤJ���u���v��</param>
		public gen_rec(move m, int p)
		{
			m_move = m;
			m_prior = p;
		}
	}
}
