using System;

namespace Chess
{
	public class hist_rec
	{
		private move m_move;
		private int m_capture;
		public move Move
		{
			get{return m_move;}
			set{m_move = value;}
		}
		public int Capture
		{
			get{return m_capture;}
			set{m_capture = value;}
		}

		public hist_rec()
		{
			m_move = new move();
			m_capture = 0;
		}

		public hist_rec(move Move, int Capture)
		{
			m_move = Move;
			m_capture = Capture;
		}
	}
}
