using System;

namespace Chess
{
	/// <summary>
	/// 棋盤格線位置表
	/// </summary>
	public enum BoardCodeEnum
	{
		A1,A2,A3,A4,A5,A6,A7,A8,A9,
		B1,B2,B3,B4,B5,B6,B7,B8,B9,
		C1,C2,C3,C4,C5,C6,C7,C8,C9,
		D1,D2,D3,D4,D5,D6,D7,D8,D9,
		E1,E2,E3,E4,E5,E6,E7,E8,E9,
		F1,F2,F3,F4,F5,F6,F7,F8,F9,
		G1,G2,G3,G4,G5,G6,G7,G8,G9,
		H1,H2,H3,H4,H5,H6,H7,H8,H9,
		I1,I2,I3,I4,I5,I6,I7,I8,I9,
		J1,J2,J3,J4,J5,J6,J7,J8,J9
	}
	/// <summary>
	/// 棋盤格線位置表(VSCCP使用的座標)
	/// </summary>
	public enum VSCCP_BoardCodeEnum
	{
		A9,B9,C9,D9,E9,F9,G9,H9,I9,
		A8,B8,C8,D8,E8,F8,G8,H8,I8,
		A7,B7,C7,D7,E7,F7,G7,H7,I7,
		A6,B6,C6,D6,E6,F6,G6,H6,I6,
		A5,B5,C5,D5,E5,F5,G5,H5,I5,
		A4,B4,C4,D4,E4,F4,G4,H4,I4,
		A3,B3,C3,D3,E3,F3,G3,H3,I3,
		A2,B2,C2,D2,E2,F2,G2,H2,I2,
		A1,B1,C1,D1,E1,F1,G1,H1,I1,
		A0,B0,C0,D0,E0,F0,G0,H0,I0
	}
	/// <summary>
	/// 棋步的變動座標對稱型態
	/// </summary>
	public enum MoveSymmetryTypeEnum
	{
		/// <summary>
		/// 正常不變動座標型態
		/// </summary>
		Normal,
		/// <summary>
		/// 垂直變動座標對稱型態
		/// </summary>
		VerticalAxial,
		/// <summary>
		/// 水平變動座標對稱型態
		/// </summary>
		HorizontalAxial,
		/// <summary>
		/// 垂直+水平變動座標對稱型態
		/// </summary>
		Central
	}
	/// <summary>
	/// 棋子選擇狀態
	/// </summary>
	public enum PieceStateEnum
	{
		/// <summary>
		/// 正常
		/// </summary>
		NORMAL,
		/// <summary>
		/// 選擇中
		/// </summary>
		SELECT
	}
	/// <summary>
	/// 棋子顏色
	/// </summary>
	public enum PieceColorEnum
	{
		/// <summary>
		/// 黑方
		/// </summary>
		DARK = 0,
		/// <summary>
		/// 紅方
		/// </summary>
		LIGHT = 1,
		/// <summary>
		/// 無棋子
		/// </summary>
		EMPTY = 7
	}
	/// <summary>
	/// 棋子型態
	/// </summary>
	public enum PieceTypeEnum
	{
		/// <summary>
		/// 兵(卒)
		/// </summary>
		PAWN,
		/// <summary>
		/// 仕(士)
		/// </summary>
		BISHOP = 1,
		/// <summary>
		/// 相(象)
		/// </summary>
		ELEPHAN = 2,
		/// <summary>
		/// 傌(馬)
		/// </summary>
		KNIGHT = 3,
		/// <summary>
		/// 炮(包)
		/// </summary>
		CANNON = 4,
		/// <summary>
		/// 俥(車)
		/// </summary>
		ROOK = 5,
		/// <summary>
		/// 帥(將)
		/// </summary>
		KING = 6,
		/// <summary>
		/// 無棋子
		/// </summary>
		EMPTY = 7
	}

	/// <summary>
	/// 玩家走子結果
	/// </summary>
	public enum PlayerMoveTypeEnum
	{
		/// <summary>
		/// 正常走子
		/// </summary>
		Normal,
		/// <summary>
		/// 初次選子狀態
		/// </summary>
		FirstSelectingChess,
		/// <summary>
		/// 走子錯誤(起點與終點座標相同,維持己方原棋子選擇狀態)
		/// </summary>
		SamePositionAndReSelectSame,
		/// <summary>
		/// 走子錯誤(終點座標有己方棋子,改為己方新棋子選擇狀態)
		/// </summary>
		SameColorAndReSelectNew,
		/// <summary>
		/// 走子錯誤(在Gen內對應不到合法的棋步,維持己方原棋子選擇狀態)
		/// </summary>
		OtherIllegalMove
	}
	
	public class constChess
	{
		/// <summary>
		/// Alpha-Beta Search Depth
		/// </summary>
		public const int MAX_PLY = 4;
		/// <summary>
		/// 棋盤X軸棋格數
		/// </summary>
		public const int SIZE_X = 9;
		/// <summary>
		/// 棋盤Y軸棋格數
		/// </summary>
		public const int SIZE_Y = 10;
		/// <summary>
		/// 棋盤平面棋格數 = SIZE_X * SIZE_Y
		/// </summary>
		public const int BOARD_SIZE = SIZE_X * SIZE_Y;
		/// <summary>
		/// 電腦思考棋步時所搜尋之暫存棋步堆疊上限值(Gen Max Move's Count)
		/// </summary>
		public const int MOVE_STACK = 4096;
		/// <summary>
		/// 電腦思考棋步時所搜尋之暫存歷史棋步堆疊上限值(History Max Move's Count)
		/// </summary>
		public const int HIST_STACK = 50;
		/// <summary>
		/// Alpha-Beta Search所使用的無限大假值
		/// </summary>
		public const int INFINITY = 20000;
		/// <summary>
		/// 開局庫所留存的比對棋步堆疊上限值(以一種對稱棋步為一個單位)
		/// </summary>
		public const int HISTORY_TO_OPENING_BOOK_STACK = 52;
		/// <summary>
		/// 限制pv思考的時限
		/// </summary>
		public const long MOVETIME = (long)182*6;
		/// <summary>
		/// 新加上的棋步判斷, 在這個棋步數量限制內不可重覆移動同樣的步法(長將, 長和, 長捉)
		/// </summary>
		public const int MAXREP = 30;
	}
}
