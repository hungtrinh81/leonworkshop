using System;

namespace Chess
{
	/// <summary>
	/// 棋步類別
	/// </summary>
	public class move
	{
		/// <summary>
		/// 棋步來源點棋格編號
		/// </summary>
		private int m_from;
		/// <summary>
		/// 棋步目的點棋格編號
		/// </summary>
		private int m_dest;
		/// <summary>
		/// 取得或設定棋步來源點棋格編號
		/// </summary>
		public int From
		{
			get{return m_from;}
			set{m_from = value;}
		}
		/// <summary>
		/// 取得或設定棋步目的點棋格編號
		/// </summary>
		public int Dest
		{
			get{return m_dest;}
			set{m_dest = value;}
		}
		/// <summary>
		/// 預設建構子
		/// </summary>
		public move()	
		{
			m_from = 0;
			m_dest = 0;
		}
		/// <summary>
		/// 有傳入來源點及目的點的建構子
		/// </summary>
		/// <param name="from">棋步來源點棋格編號</param>
		/// <param name="dest">棋步目的點棋格編號</param>
		public move(int from, int dest)
		{
			m_from = from;
			m_dest = dest;
		}
		/// <summary>
		/// 可讀取對應棋格座標系統代號來產生對應棋步的建構子
		/// 可以使用兩種格式 1.BoardCodeEnum(自創), 2.VSCCP_BoardCodeEnum(VSCCP所使用)
		/// </summary>
		/// <param name="CodeString">棋格座標系統代號</param>
		/// <param name="BoardCodeType">座標系統[BoardCodeEnum | VSCCP_BoardCodeEnum]</param>
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
		/// 計算對稱棋步(來源或目的)所使用, 一個棋步在棋盤可以有4組對稱座標
		/// 分別為 正常*1, 垂直對稱*1, 水平對稱*1, 鏡射對稱*1
		/// 主要為開局庫在使用****並且要注意對局庫目前是使用VSCCP座標
		/// </summary>
		/// <param name="m">要計算的棋步</param>
		/// <param name="mType">對稱型態</param>
		/// <returns>計算出的對稱棋步</returns>
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
		/// 比較兩組棋步是否相等(來源點=來源點, 目的點=目的點)
		/// </summary>
		/// <param name="m1">棋步1</param>
		/// <param name="m2">棋步2</param>
		/// <returns>bool</returns>
		public static bool Compare(move m1, move m2)
		{
			bool bReturn = false;
			if((m1.From == m2.From) && (m1.Dest == m2.Dest)){bReturn = true;}
			return bReturn;
		}
	}
}
