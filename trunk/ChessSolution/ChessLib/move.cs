using System;

namespace Chess
{
	/// <summary>
	/// �ѨB���O
	/// </summary>
	public class move
	{
		/// <summary>
		/// �ѨB�ӷ��I�Ѯ�s��
		/// </summary>
		private int m_from;
		/// <summary>
		/// �ѨB�ت��I�Ѯ�s��
		/// </summary>
		private int m_dest;
		/// <summary>
		/// ���o�γ]�w�ѨB�ӷ��I�Ѯ�s��
		/// </summary>
		public int From
		{
			get{return m_from;}
			set{m_from = value;}
		}
		/// <summary>
		/// ���o�γ]�w�ѨB�ت��I�Ѯ�s��
		/// </summary>
		public int Dest
		{
			get{return m_dest;}
			set{m_dest = value;}
		}
		/// <summary>
		/// �w�]�غc�l
		/// </summary>
		public move()	
		{
			m_from = 0;
			m_dest = 0;
		}
		/// <summary>
		/// ���ǤJ�ӷ��I�Υت��I���غc�l
		/// </summary>
		/// <param name="from">�ѨB�ӷ��I�Ѯ�s��</param>
		/// <param name="dest">�ѨB�ت��I�Ѯ�s��</param>
		public move(int from, int dest)
		{
			m_from = from;
			m_dest = dest;
		}
		/// <summary>
		/// �iŪ�������Ѯ�y�Шt�ΥN���Ӳ��͹����ѨB���غc�l
		/// �i�H�ϥΨ�خ榡 1.BoardCodeEnum(�۳�), 2.VSCCP_BoardCodeEnum(VSCCP�Ҩϥ�)
		/// </summary>
		/// <param name="CodeString">�Ѯ�y�Шt�ΥN��</param>
		/// <param name="BoardCodeType">�y�Шt��[BoardCodeEnum | VSCCP_BoardCodeEnum]</param>
		public move(string CodeString, System.Type BoardCodeType)
		{
			if(CodeString==null){throw new Exception("CodeString null!");}
			if(CodeString.Trim().Length!=4){throw new Exception("CodeString Length Error!");}
			switch(BoardCodeType.Name)
			{
				case "BoardCodeEnum":
					m_from = (int)Enum.Parse(typeof(BoardCodeEnum), CodeString.Substring(0, 2));
					m_dest = (int)Enum.Parse(typeof(BoardCodeEnum), CodeString.Substring(2, 2));
					break;
				case "VSCCP_BoardCodeEnum":
					m_from = (int)Enum.Parse(typeof(VSCCP_BoardCodeEnum), CodeString.Substring(0, 2));
					m_dest = (int)Enum.Parse(typeof(VSCCP_BoardCodeEnum), CodeString.Substring(2, 2));
					break;
			}
		}
		/// <summary>
		/// �p���ٴѨB(�ӷ��Υت�)�Ҩϥ�, �@�ӴѨB�b�ѽL�i�H��4�չ�ٮy��
		/// ���O�� ���`*1, �������*1, �������*1, ��g���*1
		/// �D�n���}���w�b�ϥ�****�åB�n�`�N�什�w�ثe�O�ϥ�VSCCP�y��
		/// </summary>
		/// <param name="m">�n�p�⪺�ѨB</param>
		/// <param name="mType">��٫��A</param>
		/// <returns>�p��X����ٴѨB</returns>
		public static move GetSymmetryMove(move m, MoveSymmetryTypeEnum mType)
		{
			int Origin_From = m.From;
			int Origin_Dest = m.Dest;
			int Symmetry_From = 0;
			int Symmetry_Dest = 0;

			switch(mType)
			{
				case MoveSymmetryTypeEnum.Normal:
					Symmetry_From = Origin_From;
					Symmetry_Dest = Origin_Dest;
					break;
				case MoveSymmetryTypeEnum.VerticalAxial:
					Symmetry_From = Origin_From + (constChess.SIZE_X - 1) - 2 * (Origin_From % constChess.SIZE_X);
					Symmetry_Dest = Origin_Dest + (constChess.SIZE_X - 1) - 2 * (Origin_Dest % constChess.SIZE_X);
					break;
				case MoveSymmetryTypeEnum.HorizontalAxial:
					Symmetry_From = Origin_From + ((constChess.SIZE_Y - 1) - 2 * (Origin_From / constChess.SIZE_X)) * constChess.SIZE_X;
					Symmetry_Dest = Origin_Dest + ((constChess.SIZE_Y - 1) - 2 * (Origin_Dest / constChess.SIZE_X)) * constChess.SIZE_X;
					break;
				case MoveSymmetryTypeEnum.Central:
					Symmetry_From = (constChess.BOARD_SIZE - 1) - Origin_From;
					Symmetry_Dest = (constChess.BOARD_SIZE - 1) - Origin_Dest;
					break;
			}

			return new move(Symmetry_From, Symmetry_Dest);
		}
		/// <summary>
		/// �����մѨB�O�_�۵�(�ӷ��I=�ӷ��I, �ت��I=�ت��I)
		/// </summary>
		/// <param name="m1">�ѨB1</param>
		/// <param name="m2">�ѨB2</param>
		/// <returns>bool</returns>
		public static bool Compare(move m1, move m2)
		{
			bool bReturn = false;
			if((m1.From == m2.From) && (m1.Dest == m2.Dest)){bReturn = true;}
			return bReturn;
		}
	}
}
