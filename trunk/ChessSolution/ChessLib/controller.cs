using System;
using System.Collections;
using System.Drawing;
using System.IO;

namespace Chess
{
	public class controller
	{
		static controller()
		{
			ZeroPoint = new PointF(20f, 20f);
			htPieceMap = new Hashtable(12);
			newmove = new move();
			for(int i=0;i<gen_dat.Length;i++){gen_dat[i] = new gen_rec();}
			for(int i=0;i<hist_dat.Length;i++){hist_dat[i] = new hist_rec();}
		}


		#region Controller Variables
		/// <summary>
		/// 是否使用事件記錄器
		/// </summary>
		private static bool LogSwitch = false;
		/// <summary>
		/// 棋格的寬(高)
		/// </summary>
		private static int GridWidth = 54;
		/// <summary>
		/// 棋盤外框和內框的軸向距離差
		/// </summary>
		private static float GridSpacing = 2f;
		/// <summary>
		/// 陣地寬(高)
		/// </summary>
		private static int CampWidth = 9;
		/// <summary>
		/// 陣地與陣地中心點的軸向距離差
		/// </summary>
		private static float CampSpacing = 3f;
		/// <summary>
		/// 畫面座標零點(位置指向棋盤外框左上角的中心點)
		/// </summary>
		private static PointF ZeroPoint;
		/// <summary>
		/// 放置棋子GIF的Memory Cache
		/// </summary>
		private static Hashtable htPieceMap;
		/// <summary>
		/// 資訊收集器(電腦方走子所產生棋步數據)
		/// </summary>
		public static string Infos = string.Empty;
		/// <summary>
		/// 顯示目前棋子內部變數piece的現況(反映實體棋子所在位置)
		/// </summary>
		public static string PieceInfos = string.Empty;
		/// <summary>
		/// 顯示目前棋子顏色變數color的現況(反映實體棋子顏色對應位置)
		/// </summary>
		public static string ColorInfos = string.Empty;
		/// <summary>
		/// 初次初始化畫面上之棋子的檢查旗標
		/// </summary>
		public static bool ChessInitialized = false;
		/// <summary>
		/// 玩家走子期間之資訊(是否已擇子)
		/// </summary>
		public static bool HumanMove_Selecting = false;
		/// <summary>
		/// 玩家走子期間之資訊(棋子起點)
		/// </summary>
		public static int HumanMove_From = -1;
		/// <summary>
		/// 玩家走子期間之資訊(棋子終點)
		/// </summary>
		public static int HumanMove_Dest = -1;
		/// <summary>
		/// 記錄目前所走過的所有棋步, 會存成四種symmetry格式
		/// </summary>
		public static move[][] History_For_BookCheck;
		/// <summary>
		/// 記錄目前所走過的棋步總數(包括電腦方及玩家方)
		/// </summary>
		public static int NumberOfTotalMoves;
		/// <summary>
		/// 開局庫(BOOK.DAT)的Memory Cache
		/// </summary>
		public static book BookData;
		/// <summary>
		/// 所有開局庫都已經對應不到相同的棋步時為True
		/// </summary>
		public static bool BookDataHasRetire = false;
		#endregion
		
		#region Initialize Block
		/// <summary>
		/// 將棋子圖像載入記憶體 Hashtable: htPieceMap
		/// </summary>
		private static void LoadPieceMap()
		{
			//主要目的是把棋子的圖像放入Hashtable內方便取用
			//htPieceMap[1] 表示要取 CHESS01.GIF
			//htPieceMap[2] 表示要取 CHESS02.GIF ... 依此類推
			//不過到開發後期發現其實可以使用ImageList這種控制項
			//也可達到相同功能.. 不過不想改變原本的做法
			htPieceMap.Clear();
			string PieceGifPath = string.Empty;
			string LoadPieceMapPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName) + PieceGifPath;

			for(int i=1;i<16;i++)
			{
				string indexStr = ((i<10) ? "0" : string.Empty) + i.ToString();
				PieceGifPath = @"\sys\"+"CHESS"+indexStr+".GIF";
				LoadPieceMapPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName) + PieceGifPath;
				Bitmap oBit = new Bitmap(LoadPieceMapPath);
				htPieceMap.Add(i, oBit);
			}

			//判別是否已載過這些圖像進去Hashtable的旗標
			ChessInitialized = true;
		}
		#endregion
		
		#region Layout Arrangement
		/// <summary>
		/// Enum棋盤代號轉換成實際座標
		/// </summary>
		/// <param name="bCode">Enum棋盤代號</param>
		/// <returns>Point</returns>
		private static PointF GetBoardCoordinate(BoardCodeEnum bCode)
		{
			int hCoord = ((int)bCode) % constChess.SIZE_X;
			int vCoord = ((int)bCode) / constChess.SIZE_X;
			float adj_hCoord = (hCoord * GridWidth + ZeroPoint.X) + GridSpacing * 2;
			float adj_vCoord = (vCoord * GridWidth + ZeroPoint.Y) + GridSpacing * 2;
			return new PointF(adj_hCoord, adj_vCoord);
		}
		/// <summary>
		/// 追蹤座標用途
		/// </summary>
		/// <param name="g">輸出的Graphics物件</param>
		private static void DrawTraceCoordString(Graphics g)
		{
			for(int i=0;i<90;i++)
			{
				BoardCodeEnum CurrCode = (BoardCodeEnum)i;
				g.DrawString(CurrCode.ToString(), new Font("Arial", 8f), new SolidBrush(Color.Blue), GetBoardCoordinate(CurrCode));
			}
		}
		/// <summary>
		/// 簡化畫棋盤軸所用的畫線函式
		/// </summary>
		/// <param name="g">輸出的Graphics物件</param>
		/// <param name="p">使用哪種畫筆</param>
		/// <param name="Begin">起點</param>
		/// <param name="End">終點</param>
		private static void FastDrawLine(Graphics g, Pen p, BoardCodeEnum Begin, BoardCodeEnum End)
		{
			g.DrawLine(p, GetBoardCoordinate(Begin),  GetBoardCoordinate(End));
		}
		/// <summary>
		/// 簡化畫棋盤陣地符號的畫圖函式
		/// </summary>
		/// <param name="g">輸出的Graphics物件</param>
		/// <param name="p">使用哪種畫筆</param>
		/// <param name="pt">陣地中心點</param>
		private static void FastDrawCamp(Graphics g, Pen p, BoardCodeEnum pt)
		{
			/*
				示意圖
				
						*
					A	*	B
				C	D	*	E	F
			*	*	*	c.	*	*	*
				G	H	*	I	J
					K	*	L
						*
			*/

			#region Get Camp Center Point Coordinate
			PointF CampCenter = GetBoardCoordinate(pt);
			#endregion

			#region Prepare Camp Points into Hashtable
			Hashtable htCamp = new Hashtable(12);
			htCamp.Add("A", new PointF(CampCenter.X - CampSpacing, CampCenter.Y - CampSpacing - CampWidth));
			htCamp.Add("B", new PointF(CampCenter.X + CampSpacing, CampCenter.Y - CampSpacing - CampWidth));
			htCamp.Add("C", new PointF(CampCenter.X - CampSpacing - CampWidth, CampCenter.Y - CampSpacing));
			htCamp.Add("D", new PointF(CampCenter.X - CampSpacing, CampCenter.Y - CampSpacing));
			htCamp.Add("E", new PointF(CampCenter.X + CampSpacing, CampCenter.Y - CampSpacing));
			htCamp.Add("F", new PointF(CampCenter.X + CampSpacing + CampWidth, CampCenter.Y - CampSpacing));
			htCamp.Add("G", new PointF(CampCenter.X - CampSpacing - CampWidth, CampCenter.Y + CampSpacing));
			htCamp.Add("H", new PointF(CampCenter.X - CampSpacing, CampCenter.Y + CampSpacing));
			htCamp.Add("I", new PointF(CampCenter.X + CampSpacing, CampCenter.Y + CampSpacing));
			htCamp.Add("J", new PointF(CampCenter.X + CampSpacing + CampWidth, CampCenter.Y + CampSpacing));
			htCamp.Add("K", new PointF(CampCenter.X - CampSpacing, CampCenter.Y + CampSpacing + CampWidth));
			htCamp.Add("L", new PointF(CampCenter.X + CampSpacing, CampCenter.Y + CampSpacing + CampWidth));
			#endregion

			#region Draw output
			int CheckHalfNo = ((int)pt) % 9;

			//Left Size
			if(CheckHalfNo != 0)
			{
				g.DrawLine(p, (PointF)htCamp["A"], (PointF)htCamp["D"]);
				g.DrawLine(p, (PointF)htCamp["C"], (PointF)htCamp["D"]);
				g.DrawLine(p, (PointF)htCamp["G"], (PointF)htCamp["H"]);
				g.DrawLine(p, (PointF)htCamp["H"], (PointF)htCamp["K"]);
			}
			//Right Size
			if(CheckHalfNo != 8)
			{
				g.DrawLine(p, (PointF)htCamp["B"], (PointF)htCamp["E"]);
				g.DrawLine(p, (PointF)htCamp["E"], (PointF)htCamp["F"]);
				g.DrawLine(p, (PointF)htCamp["I"], (PointF)htCamp["J"]);
				g.DrawLine(p, (PointF)htCamp["I"], (PointF)htCamp["L"]);
			}
			#endregion
		}
		/// <summary>
		/// 輸出畫面棋盤用途
		/// </summary>
		/// <param name="g">輸出的Graphics物件</param>
		public static void DrawBoard(Graphics g)
		{
			//DrawTraceCoordString(g);
			#region 畫筆
			Pen wP = new Pen(Color.Black, 3f);
			Pen tP = new Pen(Color.Black, 1f);
			#endregion
			#region 棋盤外框(粗筆)
			g.DrawRectangle(wP, ZeroPoint.X, ZeroPoint.Y, 8 * GridWidth + (int)(GridSpacing * 4) , 9 * GridWidth + (int)(GridSpacing * 4));
			#endregion
			#region 橫軸
			FastDrawLine(g, tP, BoardCodeEnum.A1, BoardCodeEnum.A9);
			FastDrawLine(g, tP, BoardCodeEnum.B1, BoardCodeEnum.B9);
			FastDrawLine(g, tP, BoardCodeEnum.C1, BoardCodeEnum.C9);
			FastDrawLine(g, tP, BoardCodeEnum.D1, BoardCodeEnum.D9);
			FastDrawLine(g, tP, BoardCodeEnum.E1, BoardCodeEnum.E9);
			FastDrawLine(g, tP, BoardCodeEnum.F1, BoardCodeEnum.F9);
			FastDrawLine(g, tP, BoardCodeEnum.G1, BoardCodeEnum.G9);
			FastDrawLine(g, tP, BoardCodeEnum.H1, BoardCodeEnum.H9);
			FastDrawLine(g, tP, BoardCodeEnum.I1, BoardCodeEnum.I9);
			FastDrawLine(g, tP, BoardCodeEnum.J1, BoardCodeEnum.J9);
			#endregion
			#region 縱軸
			FastDrawLine(g, tP, BoardCodeEnum.A1, BoardCodeEnum.J1);
			FastDrawLine(g, tP, BoardCodeEnum.A2, BoardCodeEnum.E2);
			FastDrawLine(g, tP, BoardCodeEnum.F2, BoardCodeEnum.J2);
			FastDrawLine(g, tP, BoardCodeEnum.A3, BoardCodeEnum.E3);
			FastDrawLine(g, tP, BoardCodeEnum.F3, BoardCodeEnum.J3);
			FastDrawLine(g, tP, BoardCodeEnum.A4, BoardCodeEnum.E4);
			FastDrawLine(g, tP, BoardCodeEnum.F4, BoardCodeEnum.J4);
			FastDrawLine(g, tP, BoardCodeEnum.A5, BoardCodeEnum.E5);
			FastDrawLine(g, tP, BoardCodeEnum.F5, BoardCodeEnum.J5);
			FastDrawLine(g, tP, BoardCodeEnum.A6, BoardCodeEnum.E6);
			FastDrawLine(g, tP, BoardCodeEnum.F6, BoardCodeEnum.J6);
			FastDrawLine(g, tP, BoardCodeEnum.A7, BoardCodeEnum.E7);
			FastDrawLine(g, tP, BoardCodeEnum.F7, BoardCodeEnum.J7);
			FastDrawLine(g, tP, BoardCodeEnum.A8, BoardCodeEnum.E8);
			FastDrawLine(g, tP, BoardCodeEnum.F8, BoardCodeEnum.J8);
			FastDrawLine(g, tP, BoardCodeEnum.A9, BoardCodeEnum.J9);
			#endregion
			#region 九宮斜行線
			FastDrawLine(g, tP, BoardCodeEnum.A4, BoardCodeEnum.C6);
			FastDrawLine(g, tP, BoardCodeEnum.A6, BoardCodeEnum.C4);
			FastDrawLine(g, tP, BoardCodeEnum.H4, BoardCodeEnum.J6);
			FastDrawLine(g, tP, BoardCodeEnum.H6, BoardCodeEnum.J4);
			#endregion
			#region 陣地符號
			FastDrawCamp(g, tP, BoardCodeEnum.C2);
			FastDrawCamp(g, tP, BoardCodeEnum.C8);
			FastDrawCamp(g, tP, BoardCodeEnum.D1);
			FastDrawCamp(g, tP, BoardCodeEnum.D3);
			FastDrawCamp(g, tP, BoardCodeEnum.D5);
			FastDrawCamp(g, tP, BoardCodeEnum.D7);
			FastDrawCamp(g, tP, BoardCodeEnum.D9);
			FastDrawCamp(g, tP, BoardCodeEnum.G1);
			FastDrawCamp(g, tP, BoardCodeEnum.G3);
			FastDrawCamp(g, tP, BoardCodeEnum.G5);
			FastDrawCamp(g, tP, BoardCodeEnum.G7);
			FastDrawCamp(g, tP, BoardCodeEnum.G9);
			FastDrawCamp(g, tP, BoardCodeEnum.H2);
			FastDrawCamp(g, tP, BoardCodeEnum.H8);
			#endregion
			#region 楚河漢界
			PointF redPt = GetBoardCoordinate(BoardCodeEnum.E2);
			PointF blackPt = GetBoardCoordinate(BoardCodeEnum.E6);
			PointF newRedPt = new PointF(redPt.X + GridSpacing * 2, redPt.Y + GridSpacing * 4);
			PointF newBlackPt = new PointF(blackPt.X + GridSpacing * 2, blackPt.Y + GridSpacing * 4);
			g.DrawString("楚 河", new Font("標楷體", 28f), new SolidBrush(Color.Black), newRedPt);
			g.DrawString("漢 界", new Font("標楷體", 28f), new SolidBrush(Color.Black), newBlackPt);
			#endregion
			#region 釋放畫筆資源
			wP.Dispose();
			tP.Dispose();
			#endregion
		}
		/// <summary>
		/// 在指定位置畫上某種型態的棋子
		/// </summary>
		/// <param name="g">輸出的Graphics物件</param>
		/// <param name="bCode">棋格代號</param>
		/// <param name="pState">棋子選擇狀態</param>
		public static void DrawCell(Graphics g, BoardCodeEnum bCode, PieceStateEnum pState)
		{
			//get piece bitmap
			PieceColorEnum pColor = (PieceColorEnum)color[(int)bCode];
			PieceTypeEnum pType = (PieceTypeEnum)piece[(int)bCode];
			Bitmap bit = null;
			PointF p = new PointF(0f,0f);
			PointF offset_P = new PointF(0f,0f);
			switch(pColor)
			{
				case PieceColorEnum.DARK:
					bit = (Bitmap)htPieceMap[(int)pColor * 7 + (int)pType + 1];
					p = GetBoardCoordinate(bCode);
					offset_P = new PointF(p.X - (bit.Width/2), p.Y - (bit.Height/2));
					if(pState == PieceStateEnum.SELECT)
					{
						//g.DrawImage(bit, offset_P);
						Bitmap oBit = new Bitmap(bit, Size.Ceiling(new SizeF(41f,41f)));
						g.DrawImage(oBit, offset_P);
					}
					else
					{
						g.DrawImage(bit, offset_P);
					}
					break;
				case PieceColorEnum.LIGHT:
					bit = (Bitmap)htPieceMap[(int)pColor * 7 + (int)pType + 1];

					p = GetBoardCoordinate(bCode);
					offset_P = new PointF(p.X - (bit.Width/2), p.Y - (bit.Height/2));
					if(pState == PieceStateEnum.SELECT)
					{
						//g.DrawImage(bit, offset_P);
						Bitmap oBit = new Bitmap(bit, Size.Ceiling(new SizeF(41f,41f)));
						g.DrawImage(oBit, offset_P);
					}
					else
					{
						g.DrawImage(bit, offset_P);
					}
					break;
				case PieceColorEnum.EMPTY:
					break;
				default:
					break;
			}
			
			string LogMessage =
				"BoardCode = " + bCode.ToString() + "\n" +
				"State = " + pState.ToString() + "\n" +
				"pColor = " + pColor.ToString() + "\n" +
				"pType = " + pType.ToString() + "\n" +
				"P(" + p.X.ToString() + "," + p.Y.ToString() + ")\n" +
				"offset_P(" + offset_P.X.ToString() + "," + offset_P.Y.ToString() + ")";
				
			WriteLog("DrawCell", LogMessage);
		}
		/// <summary>
		/// 在指定位置畫上棋子移動完畢的符號
		/// </summary>
		/// <param name="g">輸出的Graphics物件</param>
		/// <param name="bCode">棋格代號</param>
		public static void DrawMovedSymbol(Graphics g, BoardCodeEnum bCode)
		{
			Bitmap bit = null;
			PointF p = new PointF(0f,0f);
			PointF offset_P = new PointF(0f,0f);
			bit = (Bitmap)htPieceMap[15];
			p = GetBoardCoordinate(bCode);
			offset_P = new PointF(p.X - (bit.Width/2), p.Y - (bit.Height/2));
			g.DrawImage(bit, offset_P);
		}
		/// <summary>
		/// 第一次載入棋盤棋子
		/// </summary>
		/// <param name="g">輸出的Graphics物件</param>
		public static void InitializeChess(Graphics g)
		{
			LoadPieceMap();
			for(int i=0;i<constChess.BOARD_SIZE;i++)
			{
				DrawCell(g, (BoardCodeEnum)i, PieceStateEnum.NORMAL);
			}
		}
		/// <summary>
		/// 重新依color及piece配置畫面棋盤棋子
		/// </summary>
		/// <param name="g">輸出的Graphics物件</param>
		public static void ReDrawChess(Graphics g)
		{
			for(int i=0;i<constChess.BOARD_SIZE;i++)
			{
				DrawCell(g, (BoardCodeEnum)i, PieceStateEnum.NORMAL);
			}
		}
		#endregion

		#region Very Simple Chinese Chess Program - Engine (Ref.)

		#region 棋子狀態變數
		/// <summary>
		/// 棋盤上所有棋格上對應棋子之顏色現狀
		/// 0:DARK(黑方)
		/// 1:LIGHT(紅方)
		/// 7:無棋子
		/// </summary>
		public static int[] color = {
										0, 0, 0, 0, 0, 0, 0, 0, 0,
										7, 7, 7, 7, 7, 7, 7, 7, 7,
										7, 0, 7, 7, 7, 7, 7, 0, 7,
										0, 7, 0, 7, 0, 7, 0, 7, 0,
										7, 7, 7, 7, 7, 7, 7, 7, 7,
										7, 7, 7, 7, 7, 7, 7, 7, 7,
										1, 7, 1, 7, 1, 7, 1, 7, 1,
										7, 1, 7, 7, 7, 7, 7, 1, 7,
										7, 7, 7, 7, 7, 7, 7, 7, 7,
										1, 1, 1, 1, 1, 1, 1, 1, 1
									};
		/// <summary>
		/// 棋盤上所有棋格上對應棋子之型態現狀
		/// 0:兵(卒)
		/// 1:仕(士)
		/// 2:相(象)
		/// 3:傌(馬)
		/// 4:炮(包)
		/// 5:俥(車)
		/// 6:帥(將)
		/// 7:無棋子
		/// </summary>
		public static int[] piece = {
										5, 3, 2, 1, 6, 1, 2, 3, 5,
										7, 7, 7, 7, 7, 7, 7, 7, 7,
										7, 4, 7, 7, 7, 7, 7, 4, 7,
										0, 7, 0, 7, 0, 7, 0, 7, 0,
										7, 7, 7, 7, 7, 7, 7, 7, 7,
										7, 7, 7, 7, 7, 7, 7, 7, 7,
										0, 7, 0, 7, 0, 7, 0, 7, 0,
										7, 4, 7, 7, 7, 7, 7, 4, 7,
										7, 7, 7, 7, 7, 7, 7, 7, 7,
										5, 3, 2, 1, 6, 1, 2, 3, 5
									};
		#endregion

		#region 計算及記錄用變數
		public static int[][] materialnumber = new int[2][]{
															   new int[7]{5, 2, 2, 2, 2, 2, 1},
															   new int[7]{5, 2, 2, 2, 2, 2, 1}
														   };

		public static ulong nodecount;
		public static ulong brandtotal = 0, gencount = 0;
		public static ulong capbrandtotal = 0, capgencount = 0;
		
		/// <summary>
		/// 目前執子方的棋子顏色
		/// </summary>
		public static int 	side;
		/// <summary>
		/// 目前等待方的棋子顏色
		/// </summary>
		public static int xside;
		/// <summary>
		/// 電腦所執子的顏色
		/// </summary>
		public static int computerside;
		
		public static int ply;
		public static int hdp;
		public static int[] gen_begin = new int[constChess.HIST_STACK];
		public static int[] gen_end = new int[constChess.HIST_STACK];
		public static move newmove;
		public static int[][] history;
		public static gen_rec[] gen_dat = new gen_rec[constChess.MOVE_STACK];
		public static hist_rec[] hist_dat = new hist_rec[constChess.HIST_STACK];
		public static long tickstart, tickend;

		public static int mply, follow_pv;
		public static move[] pv;
		#endregion

		#region 棋步判斷用常數
		/// <summary>
		/// 棋子移動步法的範圍陣列
		/// </summary>
		public static int[][] offset = new int[7][]{
													   new int[8]{-1, 1,13, 0, 0, 0, 0, 0},					//兵(卒)
													   new int[8]{-12,-14,12,14,0,0,0,0},					//仕(士)
													   new int[8]{-28,-24,24,28, 0, 0, 0, 0 },				//相(象)
													   new int[8]{-11,-15,-25,-27,11,15,25,27},		//傌(馬)
													   new int[8]{-1, 1,-13,13, 0, 0, 0, 0},				//炮(包)
													   new int[8]{-1, 1,-13,13, 0, 0, 0, 0},				//俥(車)
													   new int[8]{-1, 1,-13,13, 0, 0, 0, 0}					//帥(將)
												   };
		/// <summary>
		/// 為了建立合法棋步所設的邏輯計算棋盤陣列
		/// </summary>
		public static int[] mailbox182 = new int[182]{
														 -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
														 -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
														 -1,-1, 0, 1, 2, 3, 4, 5, 6, 7, 8,-1,-1,
														 -1,-1, 9,10,11,12,13,14,15,16,17,-1,-1,
														 -1,-1,18,19,20,21,22,23,24,25,26,-1,-1,
														 -1,-1,27,28,29,30,31,32,33,34,35,-1,-1,
														 -1,-1,36,37,38,39,40,41,42,43,44,-1,-1,
														 -1,-1,45,46,47,48,49,50,51,52,53,-1,-1,
														 -1,-1,54,55,56,57,58,59,60,61,62,-1,-1,
														 -1,-1,63,64,65,66,67,68,69,70,71,-1,-1,
														 -1,-1,72,73,74,75,76,77,78,79,80,-1,-1,
														 -1,-1,81,82,83,84,85,86,87,88,89,-1,-1,
														 -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
														 -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
													 };
		/// <summary>
		/// 邏輯計算棋盤陣列的內部合法棋格的索引值陣列
		/// </summary>
		public static int[] mailbox90 = new int[90]{
													   28, 29, 30, 31, 32, 33, 34, 35, 36,
													   41, 42, 43, 44, 45, 46, 47, 48, 49,
													   54, 55, 56, 57, 58, 59, 60, 61, 62,
													   67, 68, 69, 70, 71, 72, 73, 74, 75,
													   80, 81, 82, 83, 84, 85, 86, 87, 88,
													   93, 94, 95, 96, 97, 98, 99,100,101,
													   106, 107,108,109,110,111,112,113,114,
													   119, 120,121,122,123,124,125,126,127,
													   132, 133,134,135,136,137,138,139,140,
													   145, 146,147,148,149,150,151,152,153
												   };
		/// <summary>
		/// 為了判別棋盤上不同種類棋子能合法移動的棋格位置陣列
		/// 必須與maskpiece(棋子遮罩)合併計算
		/// </summary>
		public static int[] legalposition = new int[90]{
														   1, 1, 5, 3, 3, 3, 5, 1, 1,
														   1, 1, 1, 3, 3, 3, 1, 1, 1,
														   5, 1, 1, 3, 7, 3, 1, 1, 5,
														   1, 1, 1, 1, 1, 1, 1, 1, 1,
														   9, 1,13, 1, 9, 1,13, 1, 9,
														   9, 9, 9, 9, 9, 9, 9, 9, 9,
														   9, 9, 9, 9, 9, 9, 9, 9, 9,
														   9, 9, 9, 9, 9, 9, 9, 9, 9,
														   9, 9, 9, 9, 9, 9, 9, 9, 9,
														   9, 9, 9, 9, 9, 9, 9, 9, 9
													   };
		/// <summary>
		/// 棋子遮罩(計算合法移動棋格用途)
		/// </summary>
		public static int[] maskpiece = new int[7]{8, 2, 4, 1, 1, 1, 2};
		/// <summary>
		/// 拐馬腳的判別陣列
		/// </summary>
		public static int[] knightcheck = new int[8]{1,-1,-9,-9,-1,1,9,9};
		/// <summary>
		/// 尚未解析出來????????
		/// </summary>
		public static int[] knightcheck2 = new int[8]{-8,-10,-8,-10,8,10,8,10};
		/// <summary>
		/// 拐象腳的判別陣列
		/// </summary>
		public static int[] elephancheck = new int[8]{-10,-8,8,10,0,0,0,0};
		/// <summary>
		/// 黑方及紅方的九宮棋格陣列
		/// </summary>
		public static int[][] kingpalace = new int[2][]{
			new int[]{3,4,5,12,13,14,21,22,23},
			new int[]{66,67,68,75,76,77,84,85,86}
		};
		#endregion

		#region 開局庫變數
		/// <summary>
		/// 存放開局庫的所有棋譜及步法(BOOK.DAT)
		/// </summary>
		public static book oBook;
		#endregion

		#region Gen Block
		public static void InitGen()
		{
			#region 棋局必須初始化的變數
			gen_begin[0] = 0;
			ply = 0;
			hdp = 0;
			#endregion

			#region 開局庫必須初始化的變數
			NumberOfTotalMoves = 0;
			History_For_BookCheck = new move[4][]{
													 new move[constChess.HISTORY_TO_OPENING_BOOK_STACK],
													 new move[constChess.HISTORY_TO_OPENING_BOOK_STACK],
													 new move[constChess.HISTORY_TO_OPENING_BOOK_STACK],
													 new move[constChess.HISTORY_TO_OPENING_BOOK_STACK]
												 };
			for(int i=0;i<History_For_BookCheck.Length;i++)
			{
				for(int j=0;j<History_For_BookCheck[0].Length;j++)
				{
					History_For_BookCheck[i][j] = new move();
				}
			}
			#endregion

			#region QuickSort必須初始化的變數
			history = new int[constChess.BOARD_SIZE][]{
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],
														  new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE],new int[constChess.BOARD_SIZE]
													  };
			pv = new move[constChess.HIST_STACK];
			for(int i=0;i<pv.Length;i++)
			{
				pv[i] = new move();
			}
			#endregion
		}
		public static bool Attack(int pos, int side)
		{
			int j, k, x, y, fcannon;
			int sd, xsd;

			sd = side;
			xsd = 1 - sd;

			for(j=0;j<4;j++)
			{
				#region J Loop for Check ROOK, CANNON, PAWN, KING
				x = mailbox90[pos];
				fcannon = 0;
				for(k=0;k<9;k++)
				{
					#region K Loop
					x = x + offset[(int)PieceTypeEnum.ROOK][j];
					y = mailbox182[x];
					if(y==-1){break;}
					if(fcannon==0)
					{
						#region fcannon == 0
						if(color[y]==xsd)
						{
							bool LocalBoolean = false;
							switch((PieceTypeEnum)piece[y])
							{
								case PieceTypeEnum.ROOK:
									LocalBoolean = true;
									break;
								case PieceTypeEnum.KING:
									if(piece[pos]==(int)PieceTypeEnum.KING){LocalBoolean = true;}
									break;
								case PieceTypeEnum.PAWN:
									if(k==0 && ((sd==(int)PieceColorEnum.DARK && j!=2) || (sd==(int)PieceColorEnum.LIGHT && j!=3))){LocalBoolean = true;}
									break;
							}
							if(LocalBoolean){return true;}
						}
						if(color[y]!=(int)PieceColorEnum.EMPTY){fcannon = 1;}
						#endregion
					} 
					else if(color[y]!=(int)PieceColorEnum.EMPTY)
					{
						#region CANNON case
						if(color[y]==xsd && piece[y]==(int)PieceTypeEnum.CANNON){return true;}
						break;
						#endregion
					}
					#endregion
				}
				#endregion
			}

			for(j=0;j<8;j++)
			{
				#region J Loop for Check KNIGHT
				y = mailbox182[mailbox90[pos]+offset[(int)PieceTypeEnum.KNIGHT][j]];
				if(y==-1){continue;}
				if(color[y]==xsd && piece[y]==(int)PieceTypeEnum.KNIGHT && color[pos+knightcheck2[j]]==(int)PieceColorEnum.EMPTY){return true;}
				#endregion
			}

			return false;
		}
		public static bool IsInCheck(int side)
		{
			int i, pos;
			i = 0;
			do
			{
				pos=kingpalace[side][i];
				i++;
			}while(piece[pos]!=(int)PieceTypeEnum.KING);
			return Attack(pos, side);
		}
		/* 30步內不可走相同的步法 */
		public static bool CheckMoveLoop()
		{
			bool b;
			int[] hdmap = new int[constChess.MAXREP+1];
			int c, f, i, j, k, m, p;
			move cm = new move();

			/* 沒有攻擊子時, 不限制重覆走相同步數 */
			if((hdp<3) || 	(materialnumber[xside][(int)PieceTypeEnum.ROOK]+materialnumber[xside][(int)PieceTypeEnum.CANNON]+materialnumber[xside][(int)PieceTypeEnum.KNIGHT]+materialnumber[xside][(int)PieceTypeEnum.PAWN]==0)){return false;}

			for(i=0;i<constChess.MAXREP;i++){hdmap[i] = 0;}
			m = (hdp>constChess.MAXREP) ? constChess.MAXREP : hdp;
			c = 0;
			i = 0;
			k = 0;

			while(i<m)
			{
				#region While Loop i<m
				if(hist_dat[hdp-1-i].Capture!=(int)PieceTypeEnum.EMPTY){return false;}
				if(hdmap[constChess.MAXREP-i]==0)
				{
					c++;
					hdmap[constChess.MAXREP-i] = c;
					p = hist_dat[hdp-1-i].Move.Dest;
					f = hist_dat[hdp-1-i].Move.From;

					j = i+1;
					while(j<m)
					{
						#region While Loop j<m
						if(f==hist_dat[hdp-1-j].Move.Dest)
						{
							f = hist_dat[hdp-1-j].Move.From;
							hdmap[constChess.MAXREP-j] = c;
							if(p==f)
							{
								if(k<j){k = j;}
								break;
							}
						}
						j++;
						#endregion
					}
					if(j>m){break;}
				}
				i++;

				if(i>2 && i==k)
				{
					b = Attack(hist_dat[hdp-1].Move.Dest, xside);
					if(!b)
					{
						cm = hist_dat[hdp-1].Move;
						UnMakeMove();
						b = Attack(cm.From, side);
						MakeMove(cm);
						if(b){return false;}
					}
					return true;
				}
				#endregion
			}
			return false;
		}
		public static bool MoveSave(int from, int dest)
		{
			move ms;
			bool bRtnMoveSave;
			if(piece[dest]==(int)PieceTypeEnum.KING){return true;}
			ms = new move(from, dest);
			MakeMove(ms);
			bRtnMoveSave = IsInCheck(xside);
			if(!bRtnMoveSave)
			{
				bRtnMoveSave = CheckMoveLoop();
			}
			UnMakeMove();
			return !bRtnMoveSave;
		}
		
		public static void Gen_push(int from, int dest)
		{
			if(MoveSave(from, dest))
			{
				gen_dat[gen_end[ply]].Move.From = from;
				gen_dat[gen_end[ply]].Move.Dest = dest;
				if(piece[dest]!=(int)PieceTypeEnum.EMPTY)
				{
					gen_dat[gen_end[ply]].Prior = (piece[dest]+1)*100 - piece[from];
				}
				else
				{
					gen_dat[gen_end[ply]].Prior = history[from][dest];
				}
				gen_end[ply]++;
			}
		}
		public static bool Gen()
		{
			int i, j, k, n, p, x, y, t, fcannon;
			gen_end[ply] = gen_begin[ply];
			for(i=0;i<constChess.BOARD_SIZE;i++)	//搜尋所有棋格(90格)
			{
				#region Legal Move Validate
				if(color[i]==side)	//只需檢查有目前走子的一方(DARK or LIGHT)棋子的棋格
				{
					p = piece[i];
					for(j=0;j<8;j++)	//檢查常數Length為8
					{
						#region J Loop Process
						if(offset[p][j]==0){break;}		//遇到檢查常數到0之後就跳出J Loop, 等於後面部分的0是沒有用的
				
						x = mailbox90[i];	//取得Source Index......
						fcannon = 0;			//設定 F Cannon = 0
						if((p==(int)PieceTypeEnum.ROOK)||(p==(int)PieceTypeEnum.CANNON))
						{
							n = 9;	//俥, 炮 -- 檢查的層數較高
						}
						else
						{
							n = 1;
						}

						for(k=0;k<n;k++)
						{
							#region K Loop Process
							if((p==(int)PieceTypeEnum.PAWN)&&(side==(int)PieceColorEnum.LIGHT))
							{
								x -= offset[p][j];	//Only (紅)兵
							}
							else
							{
								x += offset[p][j];	//仕(士),相(象),傌(馬),炮(包),俥(車),帥(將)
							}

							y = mailbox182[x];	//取得Target Value......

							if(side==(int)PieceColorEnum.DARK)	//黑方必須取得較高Index (t)值
							{
								t = y;
							}
							else
							{
								t = 89-y;
							}

							//1.取得的y值為-1 (表示超出棋盤合理範圍)
							//2.y!=-1但是t取得的legalposition和棋子遮罩進行(邏輯且)之計算結果==0
							//就跳出 K Loop
							if((y==-1)||((legalposition[t] & maskpiece[p])==0)){break;}
							
							if(fcannon==0)
							{
								#region fcannon=0

								#region Block 01
								if(color[y]!=side)
								{
									switch((PieceTypeEnum)p) 
									{
										case PieceTypeEnum.KNIGHT:
											if(color[i+knightcheck[j]]==(int)PieceColorEnum.EMPTY){Gen_push(i, y);}
											break;
										case PieceTypeEnum.ELEPHAN:
											if(color[i+elephancheck[j]]==(int)PieceColorEnum.EMPTY){Gen_push(i, y);}
											break;
										case PieceTypeEnum.CANNON:
											if(color[y]==(int)PieceColorEnum.EMPTY){Gen_push(i, y);}
											break;
										default:
											Gen_push(i, y);
											break;
									}
								}
								#endregion
									
								#region Block 02
								if(color[y]!=(int)PieceColorEnum.EMPTY)
								{
									if(p==(int)PieceTypeEnum.CANNON)
									{
										fcannon++;
									}
									else
									{
										break;
									}
								}
								#endregion
									
								#endregion
							}
							else 
							{
								#region CANNON switch
								if(color[y]!=(int)PieceColorEnum.EMPTY) 
								{
									if(color[y]==xside){Gen_push(i, y);}
									break;
								}
								#endregion
							}
							#endregion
						}
						#endregion
					}
				}
				#endregion
			}
			gen_end[ply+1] = gen_end[ply];
			gen_begin[ply+1] = gen_end[ply];
			brandtotal += (ulong)(gen_end[ply] - gen_begin[ply]);
			gencount++;

			return (gen_end[ply]>gen_begin[ply]);
		}
		public static bool GenCapture()
		{
			int i, j, k, n, p, x, y, t, fcannon;
			gen_end[ply] = gen_begin[ply];
			for(i=0;i<constChess.BOARD_SIZE;i++)	//搜尋所有棋格(90格)
			{
				#region Legal Move Validate
				if(color[i]==side)	//只需檢查有目前走子的一方(DARK or LIGHT)棋子的棋格
				{
					p = piece[i];
					for(j=0;j<8;j++)	//檢查常數Length為8
					{
						#region J Loop Process
						if(offset[p][j]==0){break;}		//遇到檢查常數到0之後就跳出J Loop, 等於後面部分的0是沒有用的
						
						x = mailbox90[i];	//取得Source Index......
						fcannon = 0;			//設定 F Cannon = 0
						if((p==(int)PieceTypeEnum.ROOK)||(p==(int)PieceTypeEnum.CANNON))
						{
							n = 9;	//俥, 炮 -- 檢查的層數較高
						}
						else
						{
							n = 1;
						}
						
						for(k=0;k<n;k++)
						{
							#region K Loop Process
							if((p==(int)PieceTypeEnum.PAWN)&&(side==(int)PieceColorEnum.LIGHT))
							{
								x -= offset[p][j];	//Only (紅)兵
							}
							else
							{
								x += offset[p][j];	//仕(士),相(象),傌(馬),炮(包),俥(車),帥(將)
							}

							y = mailbox182[x];	//取得Target Value......

							if(side==(int)PieceColorEnum.DARK)	//黑方必須取得較高Index (t)值
							{
								t = y;
							}
							else
							{
								t = 89-y;
							}
							
							//1.取得的y值為-1 (表示超出棋盤合理範圍)
							//2.y!=-1但是t取得的legalposition和棋子遮罩進行(邏輯且)之計算結果==0
							//就跳出 K Loop
							if((y==-1)||((legalposition[t] & maskpiece[p])==0)){break;}

							if(fcannon==0)
							{
								#region fcannon=0

								#region Block 01
								if(color[y]!=side)
								{
									switch((PieceTypeEnum)p) 
									{
										case PieceTypeEnum.KNIGHT:
											if((color[i+knightcheck[j]]==(int)PieceColorEnum.EMPTY)&&(color[y]==xside)){Gen_push(i, y);}
											break;
										case PieceTypeEnum.ELEPHAN:
											if((color[i+elephancheck[j]]==(int)PieceColorEnum.EMPTY)&&(color[y]==xside)){Gen_push(i, y);}
											break;
										case PieceTypeEnum.CANNON:
											//v1.3版Mark掉這裡的CANNON檢查 ???
											//if((color[y]==(int)PieceColorEnum.EMPTY)&&(color[y]==xside)){Gen_push(i, y);}
											break;
										default:
											if(color[y]==xside){Gen_push(i, y);}
											break;
									}
								}
								#endregion
									
								#region Block 02
								if(color[y]!=(int)PieceColorEnum.EMPTY)
								{
									if(p==(int)PieceTypeEnum.CANNON)
									{
										//v1.3
										fcannon = 1;
										//v1.0, v1.1, v1.2 Marked
										//fcannon++;
									}
									else
									{
										break;
									}
								}
								#endregion
									
								#endregion
							}
							else 
							{
								#region CANNON switch
								if(color[y]!=(int)PieceColorEnum.EMPTY) 
								{
									if(color[y]==xside){Gen_push(i, y);}
									break;
								}
								#endregion
							}
							#endregion
						}
						#endregion
					}
				}
				#endregion
			}
			gen_end[ply+1] = gen_end[ply];
			gen_begin[ply+1] = gen_end[ply];
			capbrandtotal += (ulong)(gen_end[ply] - gen_begin[ply]);
			if(gen_end[ply]>gen_begin[ply]){capgencount++;}

			return  (gen_begin[ply]<gen_end[ply]);
		}
		#endregion

		#region Move Block
		public static bool MakeMove(move m)
		{
			int from, dest, p;
			//取得棋步來源點
			from = m.From;
			//取得棋步目的點
			dest = m.Dest;
			//取得棋步目的點的棋子型態
			p = piece[dest];
			if(p!=(int)PieceTypeEnum.EMPTY){materialnumber[xside][p]--;}
			//棋步存入歷史棋步記錄中(hist_dat)
			hist_dat[hdp].Move = m;
			//在更新目前要被移入棋子的目的點資料之前先將該點棋子型態記錄起來(被吃子型態)
			//顏色可由來回手判別得知.. 所以不需記錄下來
			hist_dat[hdp].Capture = p;
			//更新實際棋盤對應陣列資料
			//1.來源點棋子型態==>目的點棋子型態
			//2.來源點棋子型態設定成無棋子型態 Clear
			//3.來源點棋子顏色==>目的點棋子顏色
			//4.來源點棋子顏色設定成無棋子顏色 Clear
			piece[dest] = piece[from];
			piece[from] = (int)PieceTypeEnum.EMPTY;
			color[dest] = color[from];
			color[from] = (int)PieceColorEnum.EMPTY;
			//相關索引註標進1
			hdp++;
			ply++;
			//執子方, 等待方註標交換
			side = xside;
			xside = 1-xside;
			//傳回值加上判別是否已ChechMate(棋步目的點為KING)
			//所以若傳回True表示遊戲已結束(已有勝負出現)
			return (p == (int)PieceTypeEnum.KING);
		}
		public static void UnMakeMove()
		{
			int from, dest;
			//相關索引註標減1
			hdp--;
			ply--;
			//執子方, 等待方註標交換
			side = xside;
			xside = 1-xside;
			//由歷史棋步記錄中(hist_dat)取得最新棋步準備逆轉此棋步
			from = hist_dat[hdp].Move.From;
			dest = hist_dat[hdp].Move.Dest;
			//逆轉更新回上一棋步實際棋盤對應陣列資料
			//1.來源點棋子型態<==(歷史棋步記錄)目的點棋子型態
			//2.來源點棋子顏色<==(歷史棋步記錄)目的點棋子顏色
			//3.目的點棋子型態<==(歷史棋步記錄)吃掉的目的點棋子型態
			piece[from] = piece[dest];
			color[from] = color[dest];
			piece[dest] = hist_dat[hdp].Capture;
			//判別(歷史棋步記錄)目的點的棋子顏色
			//若為無棋子狀態==>設EMPTY
			//若不為無棋子狀態==>設為非目前執子方顏色
			if(piece[dest]==(int)PieceTypeEnum.EMPTY)
			{color[dest] = (int)PieceColorEnum.EMPTY;}
			else
			{color[dest] = xside;}
			if(piece[dest]!=(int)PieceTypeEnum.EMPTY){materialnumber[xside][piece[dest]]++;}
		}
		public static bool UpdateNewMove(Graphics g)
		{
			/*
				UpdateNewMove 與 MakeMove 的不同處
				MakeMove是在計算上使用.. 會處理到堆疊及歷史記錄等變數
				而UpdateNewMove則是最後結果.. 要真正回應到畫面UI上的動作
				所以MakeMove的換手(執子方, 等待方註標交換)是位於函式內部
				但是UpdateNewMove則外放到函式外才去進行處理..本身不處理
			*/
			int from, dest, p;
			//取得棋步來源點
			from = newmove.From;
			//取得棋步目的點
			dest = newmove.Dest;
			//取得棋步目的點的棋子型態
			p = piece[dest];
			if(from==-1){return true;}		//Add From v1.3
			if(p!=(int)PieceTypeEnum.EMPTY){materialnumber[side][p]--;}
			//更新實際棋盤對應陣列資料
			//1.來源點棋子型態==>目的點棋子型態
			//2.來源點棋子型態設定成無棋子型態 Clear
			//3.來源點棋子顏色==>目的點棋子顏色
			//4.來源點棋子顏色設定成無棋子顏色 Clear
			piece[dest] = piece[from];
			piece[from] = (int)PieceTypeEnum.EMPTY;
			color[dest] = color[from];
			color[from] = (int)PieceColorEnum.EMPTY;

			//畫面的UI回應處理動作
			//棋步來源點畫上綠色方格(處理方式待改善...)
			DrawMovedSymbol(g, (BoardCodeEnum)from);
			//DrawCell(g, (BoardCodeEnum)from, PieceStateEnum.NORMAL);
			//棋步目的點畫上該點目前已更新盤面棋子型態(應為由來源點走子過去的棋子型態)
			DrawCell(g, (BoardCodeEnum)dest, PieceStateEnum.NORMAL);
			
			//棋子型態分佈之資訊收集****
			PieceInfos = GetPieceInfos();
			//棋子顏色分佈之資訊收集****
			ColorInfos = GetColorInfos();

			//傳回值加上判別是否已ChechMate(棋步目的點為KING)
			//所以若傳回True表示遊戲已結束(已有勝負出現)
			return (p == (int)PieceTypeEnum.KING);
		}

		#endregion

		#region Evaluate Block
		public static int Bonous()
		{
			int i, s;
			int[][] bn = new int[2][]{
										 new int[7]{-2, -3, -3, -4, -4, -5, 0},
										 new int[7]{-2, -3, -3, -4, -4, -5, 0}
									 };

			for(i=0;i<2;i++)
			{
				// Scan DARK and LIGHT
				if(materialnumber[i][(int)PieceTypeEnum.BISHOP] < 2) 
				{
					bn[1-i][(int)PieceTypeEnum.ROOK] += 4;
					bn[1-i][(int)PieceTypeEnum.KNIGHT] += 2;
					bn[1-i][(int)PieceTypeEnum.PAWN] += 1;
				}

				if(materialnumber[i][(int)PieceTypeEnum.ELEPHAN] < 2) 
				{
					bn[1-i][(int)PieceTypeEnum.ROOK] += 2;
					bn[1-i][(int)PieceTypeEnum.CANNON] += 2;
					bn[1-i][(int)PieceTypeEnum.PAWN] += 1;
				}
			}

			if(color[0]==(int)PieceColorEnum.DARK && color[1]==(int)PieceColorEnum.DARK && piece[0]==(int)PieceTypeEnum.ROOK && piece[1]==(int)PieceTypeEnum.KNIGHT){bn[(int)PieceColorEnum.DARK][6] -= 10;}
			if(color[7]==(int)PieceColorEnum.DARK && color[8]==(int)PieceColorEnum.DARK && piece[8]==(int)PieceTypeEnum.ROOK && piece[7]==(int)PieceTypeEnum.KNIGHT){bn[(int)PieceColorEnum.DARK][6] -= 10;}
			if(color[81]==(int)PieceColorEnum.LIGHT && color[82]==(int)PieceColorEnum.LIGHT && piece[81]==(int)PieceTypeEnum.ROOK && piece[82]==(int)PieceTypeEnum.KNIGHT){bn[(int)PieceColorEnum.LIGHT][6] -= 10;}
			if(color[88]==(int)PieceColorEnum.LIGHT && color[89]==(int)PieceColorEnum.LIGHT && piece[89]==(int)PieceTypeEnum.ROOK && piece[88]==(int)PieceTypeEnum.KNIGHT){bn[(int)PieceColorEnum.LIGHT][6] -= 10;}

			s = bn[side][6] - bn[xside][6];

			for(i=0;i<6;i++){s += materialnumber[side][i] * bn[side][i] - materialnumber[xside][i] * bn[xside][i];}
			return s;
		}
		public static int[][][] pointtable = new int[7][][]{			
															   new int[2][]{
																			   new int[90]{
																							  0,  0,  0,  0,  0,  0,  0,  0,  0, 			/* PAWN*/
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  10,  0, 12,  0, 15,  0, 12,  0, 10,
																							  10,  0, 13,  0, 10,  0, 13,  0, 10,
																							  20, 20, 20, 20, 20, 20, 20, 20, 20,
																							  20, 21, 21, 22, 22, 22, 21, 21, 20,
																							  20, 21, 21, 23, 23, 23, 21, 21, 20,
																							  20, 21, 21, 23, 22, 23, 21, 21, 20,
																							  11, 12, 13, 14, 14, 14, 13, 12, 11
																						  },
																			   new int[90]{
																							  11, 12, 13, 14, 14, 14, 13, 12, 11,          /* PAWN*/
																							  20, 21, 21, 23, 22, 23, 21, 21, 20,
																							  20, 21, 21, 23, 23, 23, 21, 21, 20,
																							  20, 21, 21, 22, 22, 22, 21, 21, 20,
																							  20, 20, 20, 20, 20, 20, 20, 20, 20,
																							  10,  0, 13,  0, 10,  0, 13,  0, 10,
																							  10,  0, 12,  0, 15,  0, 12,  0, 10,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0
																						  }
																		   },
															   new int[2][]{
																			   new int[90]{
																							  0,  0,  0, 20,  0, 20,  0,  0,  0, 			/* BISHOP */
																							  0,  0,  0,  0, 22,  0,  0,  0,  0,
																							  0,  0,  0, 19,  0, 19,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0
																						  },
																			   new int[90]{
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,          /* BISHOP */
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0, 19,  0, 19,  0,  0,  0,
																							  0,  0,  0,  0, 22,  0,  0,  0,  0,
																							  0,  0,  0, 20,  0, 20,  0,  0,  0
																						  }
																		   },
															   new int[2][]{
																			   new int[90]{
																							  0,  0, 25,  0,  0,  0, 25,  0,  0, 			/* ELEPHAN */
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  23,  0,  0,  0, 28,  0,  0,  0, 23,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0, 22,  0,  0,  0, 22,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0
																						  },
																			   new int[90]{
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,          /* ELEPHAN */
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0, 22,  0,  0,  0, 22,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  23,  0,  0,  0, 28,  0,  0,  0, 23,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0, 25,  0,  0,  0, 25,  0,  0
																						  }
																		   },
															   new int[2][]{
																			   new int[90]{
																							  40, 35, 40, 40, 40, 40, 40, 35, 40, 		/* KNIGHT */
																							  40, 41, 42, 40, 20, 40, 42, 41, 40,
																							  40, 42, 43, 40, 40, 40, 43, 42, 40,
																							  40, 42, 43, 43, 43, 43, 43, 42, 40,
																							  40, 43, 44, 44, 44, 44, 44, 43, 40,
																							  40, 43, 44, 44, 44, 44, 44, 43, 40,
																							  40, 43, 44, 44, 44, 44, 44, 43, 40,
																							  40, 43, 44, 44, 44, 44, 44, 43, 40,
																							  40, 41, 42, 42, 42, 42, 42, 41, 40,
																							  40, 40, 40, 40, 40, 40, 40, 40, 40
																						  },
																			   new int[90]{
																							  40, 40, 40, 40, 40, 40, 40, 40, 40, 		/* KNIGHT */
																							  40, 41, 42, 42, 42, 42, 42, 41, 40,
																							  40, 43, 44, 44, 44, 44, 44, 43, 40,
																							  40, 43, 44, 44, 44, 44, 44, 43, 40,
																							  40, 43, 44, 44, 44, 44, 44, 43, 40,
																							  40, 43, 44, 44, 44, 44, 44, 43, 40,
																							  40, 42, 43, 43, 43, 43, 43, 42, 40,
																							  40, 42, 43, 40, 40, 40, 43, 42, 40,
																							  40, 41, 42, 40, 20, 40, 42, 41, 40,
																							  40, 35, 40, 40, 40, 40, 40, 35, 40
																						  }
																		   },
															   new int[2][]{
																			   new int[90]{
																							  50, 50, 50, 50, 50, 50, 50, 50, 50, 		/* CANNON */
																							  50, 50, 50, 50, 50, 50, 50, 50, 50,
																							  50, 51, 53, 53, 55, 53, 53, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 51, 51, 51, 51, 51, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 50, 50, 50, 50, 50, 50, 50, 50
																						  },
																			   new int[90]{
																							  50, 50, 50, 50, 50, 50, 50, 50, 50, 		/* CANNON */
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 51, 51, 51, 51, 51, 51, 50,
																							  50, 51, 50, 50, 50, 50, 50, 51, 50,
																							  50, 51, 53, 53, 55, 53, 53, 51, 50,
																							  50, 50, 50, 50, 50, 50, 50, 50, 50,
																							  50, 50, 50, 50, 50, 50, 50, 50, 50
																						  }
																		   },
															   new int[2][]{
																			   new int[90]{
																							  89, 92, 90, 90, 90, 90, 90, 92, 89, 		/* ROOK */
																							  91, 92, 90, 93, 90, 93, 90, 92, 91,
																							  90, 92, 90, 91, 90, 91, 90, 92, 90,
																							  90, 91, 90, 91, 90, 91, 90, 91, 90,
																							  90, 94, 90, 94, 90, 94, 90, 94, 90,
																							  90, 93, 90, 91, 90, 91, 90, 93, 90,
																							  90, 91, 90, 91, 90, 91, 90, 91, 90,
																							  90, 91, 90, 90, 90, 90, 90, 91, 90,
																							  90, 92, 91, 91, 90, 91, 91, 92, 90,
																							  90, 90, 90, 90, 90, 90, 90, 90, 90
																						  },
																			   new int[90]{
																							  90, 90, 90, 90, 90, 90, 90, 90, 90, 		/* ROOK */
																							  90, 92, 91, 91, 90, 91, 91, 92, 90,
																							  90, 91, 90, 90, 90, 90, 90, 91, 90,
																							  90, 91, 90, 91, 90, 91, 90, 91, 90,
																							  90, 93, 90, 91, 90, 91, 90, 93, 90,
																							  90, 94, 90, 94, 90, 94, 90, 94, 90,
																							  90, 91, 90, 91, 90, 91, 90, 91, 90,
																							  90, 92, 90, 91, 90, 91, 90, 92, 90,
																							  91, 92, 90, 93, 90, 93, 90, 92, 91,
																							  89, 92, 90, 90, 90, 90, 90, 92, 89
																						  }
																		   },
															   new int[2][]{
																			   new int[90]{
																							  0,  0,  0, 30, 35, 30,  0,  0,  0, 			/* KING */
																							  0,  0,  0, 15, 15, 15,  0,  0,  0,
																							  0,  0,  0,  1,  1,  1,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0
																						  },
																			   new int[90]{
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,          /* KING */
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  0,  0,  0,  0,  0,  0,
																							  0,  0,  0,  1,  1,  1,  0,  0,  0,
																							  0,  0,  0, 15, 15, 15,  0,  0,  0,
																							  0,  0,  0, 30, 35, 30,  0,  0,  0
																						  }
																		   }
														   };

		//public static int[] piecevalue = new int[7]{10, 20, 20, 40, 45, 90, 1000};	//v1.0 and v1.1
		public static int Eval()
		{	
			int i, s = 0;
			nodecount++;
			for(i=0;i<constChess.BOARD_SIZE;i++)
			{
				if(color[i]==(int)PieceColorEnum.DARK)
				{
					s += pointtable[piece[i]][(int)PieceColorEnum.DARK][i];
				}
				else if(color[i]==(int)PieceColorEnum.LIGHT)
				{
					s -= pointtable[piece[i]][(int)PieceColorEnum.LIGHT][i];
				}
			}
			if(side==(int)PieceColorEnum.LIGHT){s=-s;}
			return s;// + Bonous();
		}
		#endregion

		#region Search Block
		public static void Check_pv()
		{
			int i;
			for(follow_pv=0,i=gen_begin[ply];i<gen_end[ply];i++)
			{
				if(gen_dat[i].Move.From==pv[ply].From && gen_dat[i].Move.Dest==pv[ply].Dest) 
				{
					follow_pv = 1;
					gen_dat[i].Prior += 1000;
					return;
				}
			}
		}
		public static void Quicksort(int q, int r)
		{
			int i, j, x;
			gen_rec g = null;

			i = q;
			j = r;
			x = gen_dat[(q+r)/2].Prior;

			do 
			{
				while(gen_dat[i].Prior > x){i++;}
				while (gen_dat[j].Prior < x){j--;}
				if(i<=j)
				{
					g = gen_dat[i];
					gen_dat[i] = gen_dat[j];
					gen_dat[j] = g;
					i++;
					j--;
				}
			}while(i<=j);

			if(q<j){Quicksort(q, j);}
			if(i<r){Quicksort(i, r);}
		}
		public static void Sort()
		{
			Quicksort(gen_begin[ply], gen_end[ply]-1);
		}
		public static int Quiescence(int alpha, int beta)
		{
			int i, __value, best;

			if(mply<ply)
			{
				mply = ply;
				//gotoxy(50,13); printf("Quiescen depth   : %d  ", mply);
			}

			__value = Eval();
			if(__value>=beta){return __value;}
			if(__value>alpha){alpha = __value;}

			if(!GenCapture())
			{
				if(!IsInCheck(side)){return __value;}
				if(!Gen()){return -1000+ply;}
			}

			if(follow_pv!=0){Check_pv();}
			Sort();
			best = constChess.INFINITY * -1;

			for(i=gen_begin[ply];i<gen_end[ply] && best<beta && (DateTime.Now.Ticks-tickstart)<=constChess.MOVETIME;i++)
			{
				if(best>alpha){alpha = best;}
				if(MakeMove(gen_dat[i].Move))
				{
					__value = 1000-ply;
				}
				else
				{
					__value = -1 * (Quiescence(-1 * beta, -1 * alpha));
				}
				UnMakeMove();

				if(__value>best)
				{
					best = __value; 
					pv[ply] = gen_dat[i].Move;
				}
			}
			return best;
		}
		/* Search game tree by alpha-beta algorith */
		public static int AlphaBeta(int alpha, int beta, int depth)
		{
			int i, __value, best;
			
			if(depth==0){return Quiescence(alpha, beta);}
			if(!Gen()){return -1000+ply;}
			if(follow_pv!=0){Check_pv();}
			Sort();
			best = constChess.INFINITY * -1;

			for(i=gen_begin[ply];i<gen_end[ply] && best<beta;i++)
			{
				if(best>alpha){alpha = best;}
				if(MakeMove(gen_dat[i].Move))
				{
					__value = 1000-ply;
				}
				else
				{
					__value = -1 * (AlphaBeta(-1 * beta, -1 * alpha, depth-1));
				}
				UnMakeMove();

				if(__value>best)
				{
					history[gen_dat[i].Move.From][gen_dat[i].Move.Dest] = depth;
					best = __value;
					if(ply==0){newmove = gen_dat[i].Move;}
					pv[ply] = gen_dat[i].Move;
				}
			}
			return best;
		}
		#endregion

		#region Computer's & Human's Move Block
		public static void ComputerThink()
		{
			int best = 0, i = 0;
			nodecount = 0;
			pv[0].From = -1;
			newmove.From = -1;
			tickstart = DateTime.Now.Ticks;
			//memset(&history, 0, sizeof(history));	?????
			for(i=1;i<=constChess.MAX_PLY;i++)
			{
				follow_pv = 1;
				best = AlphaBeta(-1 * constChess.INFINITY, constChess.INFINITY, i);
			}
			tickend = DateTime.Now.Ticks;
			
			//電腦方思考棋步之資訊收集
			Infos = 
				"Depth : " + constChess.MAX_PLY.ToString() + "\n" +
				"Node total : " + nodecount.ToString() + "\n" +
				"Brand factor : " + ((float)brandtotal/gencount).ToString() + "\n" +
				"Time (second) : " + ((tickend-tickstart)/18.23).ToString() + "\n" +
				"Nodes per second : " + ((long)(nodecount*18.23/(tickend-tickstart+1))).ToString() + "\n" +
				"Score : " + best.ToString() + "\n" +
				"Computer move : " + ((BoardCodeEnum)newmove.From).ToString() + "-" + ((BoardCodeEnum)newmove.Dest).ToString() + "\n\n" +
				"Quiescen depth : " + mply.ToString() + "\n" +
				"Quie brand factor : " + ((float)capbrandtotal/capgencount).ToString() + "\n";
			
			//棋子型態分佈之資訊收集
			PieceInfos = GetPieceInfos();
			//棋子顏色分佈之資訊收集
			ColorInfos = GetColorInfos();

			//加上一個判斷... 若已進來思考棋步... 表示開局庫已沒用了.. 旗標設為 True
			BookDataHasRetire = true;
		}
		
		public static PlayerMoveTypeEnum DoHumanMove(Graphics g)
		{
			//建立合法棋步以供後續檢查用途
			Gen();

			if(!HumanMove_Selecting)
			{
				if(color[HumanMove_Dest]==side)
				{
					HumanMove_Selecting = true;
					HumanMove_From = HumanMove_Dest;
					DrawCell(g, (BoardCodeEnum)HumanMove_Dest, PieceStateEnum.SELECT);
					return PlayerMoveTypeEnum.FirstSelectingChess;
				}
				return PlayerMoveTypeEnum.OtherIllegalMove;
			}
			else
			{
				if(HumanMove_Dest!=HumanMove_From){DrawCell(g, (BoardCodeEnum)HumanMove_From, PieceStateEnum.NORMAL);}
				if(color[HumanMove_Dest]==side)
				{
					HumanMove_From = HumanMove_Dest;
					DrawCell(g, (BoardCodeEnum)HumanMove_Dest, PieceStateEnum.SELECT);
					return PlayerMoveTypeEnum.SameColorAndReSelectNew;
				}
				else
				{
					newmove = new move(HumanMove_From, HumanMove_Dest);
					for(int i=gen_begin[ply];i<gen_end[ply];i++)
					{
						if(gen_dat[i].Move.From==newmove.From && gen_dat[i].Move.Dest==newmove.Dest)
						{
							//Reset Global HumanMove Variable
							HumanMove_Selecting = false;
							HumanMove_From = -1;
							HumanMove_Dest = -1;
							return PlayerMoveTypeEnum.Normal;
						}
					}
					DrawCell(g, (BoardCodeEnum)HumanMove_From, PieceStateEnum.SELECT);
					return PlayerMoveTypeEnum.OtherIllegalMove;
				}
			}
		}
		#endregion

		#region Opening Book Block
		/// <summary>
		/// 讀取BOOK.DAT存入開局庫的Memory Cache
		/// </summary>
		/// <returns>bool (True:讀取且存入成功, False:讀取失敗)</returns>
		public static bool ReadBook()
		{
			try
			{
				if(BookData==null)
				{
					BookData = new book();
					BookData.Load();
				}
				return BookData.LoadFlag;
			}
			catch(Exception ex)
			{
				WriteLog("ReadBook", ex.Message);
				BookData = null;
				return false;
			}
		}
		/// <summary>
		/// 在開局庫內比對目前棋步組是否有相同的棋局, 若有則使用開局庫的棋步來代替
		/// 電腦方思考結果
		/// </summary>
		/// <returns>bool (True:有找到, False:沒有找到)</returns>
		public static bool GetBook()
		{
			int k=0, sk=0;
			bool MatchOpeningBook = false;
			move MatchedNextMove = null;
			
			if(BookDataHasRetire){return false;}	//開局庫已沒用處時(已對應不到相同棋步了)
			if(!ReadBook()){return false;}

			if(NumberOfTotalMoves == 0)		//第0步來查詢開局庫, 表示第一手由電腦方走子
			{
				#region 第一手由電腦方走子時之初始化動作
				if(computerside == (int)PieceColorEnum.DARK)
				{
					sk = 2;	//Dark Side
				}
				else
				{
					sk = 0;	//White Side
				}

				k = 0;
				MatchOpeningBook = true;

				MatchedNextMove = BookData.Lines[0][0];
				#endregion
			}
			else
			{
				//要比對所有開局庫的棋步與現在棋盤上走子的全部棋步
				//檢查有沒有合乎的可無電腦方走子直接套用(即不用再AlphaBeta搜尋)
				for(int i=0;i<BookData.Length;i++)	//一個Loop表示開局庫棋譜內的一行
				{
					int CurrentLine_MovesCount = BookData.Lines[i].Length;
					#region 檢查是否已走子到超出了此行開局庫棋譜所包含的棋步總數,若已超出就無法再比對此行開局庫棋譜...
					if(CurrentLine_MovesCount > NumberOfTotalMoves)
					{
						#region 四種對稱棋步座標都要比對一次
						for(sk=0;sk<4;sk++)
						{
							#region 實際最內部的比對動作
							for(k=0,MatchOpeningBook=true;k<NumberOfTotalMoves;k++)
							{
								//若中途有出現不符合的棋步, 即表示此開局庫不符合目前盤面所走步法, 不用再比對!!
								if(!move.Compare(History_For_BookCheck[sk][k], BookData.Lines[i][k]))
								{
									MatchOpeningBook = false;
									break;
								}
							}
							
							if(MatchOpeningBook){break;}	//若走完整個內部檢查迴圈後得到符合的棋步, 就可跳出整個三層迴圈了
							#endregion
						}
						#endregion
						if(MatchOpeningBook)
						{
							MatchedNextMove = BookData.Lines[i][k];
							break;
						}//若走完整個內部檢查迴圈後得到符合的棋步, 就可跳出整個三層迴圈了
					}
					#endregion
				}
			}

			#region 開局庫內若有找到符合的棋譜, 把符合的棋譜下一步棋步設定給電腦方目前要走子的步法內
			if((MatchOpeningBook)&&(MatchedNextMove!=null))
			{
				newmove = move.GetSymmetryMove(MatchedNextMove, (MoveSymmetryTypeEnum)sk);
			}
			#endregion

			return MatchOpeningBook;
		}
		#endregion

		#endregion

		#region Informations
		private static string GetPieceInfos()
		{
			string rtnInfos = string.Empty;
			string[] pInfo = new string[piece.Length];
			for(int i=0;i<piece.Length;i++)
			{
				pInfo[i] = piece[i].ToString() + ((i%9==8)?"\n":"");
			}
			rtnInfos = " " + String.Join(" ", pInfo).Replace("7", "_");
			return rtnInfos;
		}

		private static string GetColorInfos()
		{
			string rtnInfos = string.Empty;
			string[] cInfo = new string[color.Length];
			for(int i=0;i<piece.Length;i++)
			{
				cInfo[i] = color[i].ToString() + ((i%9==8)?"\n":"");
			}
			rtnInfos = " " + String.Join(" ", cInfo).Replace("7", "_");
			return rtnInfos;
		}

		public static move[] GetGenData()
		{
			ArrayList alMove = new ArrayList();
			for(int i=gen_begin[ply];i<gen_end[ply];i++)
			{
				alMove.Add(gen_dat[i].Move);
			}
			return alMove.ToArray(typeof(move)) as move[];
		}
		public static void WriteLog(string Source, string Message)
		{
			if(LogSwitch)
			{
				System.Diagnostics.EventLog.WriteEntry(Source, Message);
			}
		}
		#endregion

		#region Mouse FeedBack Action
		/// <summary>
		/// 計算畫面上滑鼠所點下的範圍是屬於哪一個棋盤格??
		/// 有可能不屬於任何棋盤格.. 此時回傳-1
		/// </summary>
		/// <param name="p">滑鼠所點下的位置</param>
		/// <returns>正常:BoardCodeEnum的對應int值, 異常:-1表不在棋子圓形範圍內</returns>
		public static int MouseClick_To_BoardCode(Point p)
		{
			PointF x_P1 = new PointF(0f, 0f);
			BoardCodeEnum x_P1_bCode = BoardCodeEnum.A1;
			PointF x_P2 = new PointF(0f, 0f);
			BoardCodeEnum x_P2_bCode = BoardCodeEnum.A9;
			PointF y_P1 = new PointF(0f, 0f);
			BoardCodeEnum y_P1_bCode = BoardCodeEnum.A1;
			PointF y_P2 = new PointF(0f, 0f);
			BoardCodeEnum y_P2_bCode = BoardCodeEnum.J1;
			
			#region X軸比對, A1.....A9
			for(int i=0;i<constChess.SIZE_X;i++)
			{
				PointF tP = GetBoardCoordinate((BoardCodeEnum)i);
				if((float)p.X>tP.X)
				{
					x_P1 = tP;
					x_P1_bCode = (BoardCodeEnum)i;
					continue;
				}
				else if((float)p.X == tP.X)
				{
					x_P1 = tP;
					x_P2 = tP;
					x_P1_bCode = (BoardCodeEnum)i;
					x_P2_bCode = (BoardCodeEnum)i;
				}
				else
				{
					x_P2 = tP;
					x_P2_bCode = (BoardCodeEnum)i;
					break;
				}
			}
			#endregion

			#region Y軸比對, A1.....J1
			for(int i=0;i<constChess.BOARD_SIZE-constChess.SIZE_X;i+=constChess.SIZE_X)
			{
				PointF tP = GetBoardCoordinate((BoardCodeEnum)i);
				if((float)p.Y>tP.Y)
				{
					y_P1 = tP;
					y_P1_bCode = (BoardCodeEnum)i;
					continue;
				}
				else if((float)p.Y == tP.Y)
				{
					y_P1 = tP;
					y_P2 = tP;
					y_P1_bCode = (BoardCodeEnum)i;
					y_P2_bCode = (BoardCodeEnum)i;
				}
				else
				{
					y_P2 = tP;
					y_P2_bCode = (BoardCodeEnum)i;
					break;
				}
			}
			#endregion

			#region 求出棋子圓形半徑...
			float radius = 9.5f;
			try
			{
				radius = ((Bitmap)htPieceMap[1]).Width/2.0f;
			}
			catch
			{}
			#endregion

			#region 外圍向內集中階段
			//第二階段:所得到的1~4個點都位於棋盤外緣, 必須要進行一次
			//集中到所求點週圍的動作
			//Ex:			x_P1 = A5, x_P2 = A6, y_P1 = E1, y_P2 = F1
			//轉換成	x_P1 = E5, x_P2 = E6, y_P1 = F5, y_P2 = F6
			//做法如下:轉換主體以BoardCodeEnum的四個變數為主
			BoardCodeEnum x_P1_bCode_Final = (BoardCodeEnum)((int)y_P1_bCode + (int)x_P1_bCode);
			BoardCodeEnum x_P2_bCode_Final = (BoardCodeEnum)((int)y_P1_bCode + (int)x_P2_bCode);
			BoardCodeEnum y_P1_bCode_Final = (BoardCodeEnum)((int)y_P2_bCode + (int)x_P1_bCode);
			BoardCodeEnum y_P2_bCode_Final = (BoardCodeEnum)((int)y_P2_bCode + (int)x_P2_bCode);
			PointF x_P1_Final = GetBoardCoordinate(x_P1_bCode_Final);
			PointF x_P2_Final = GetBoardCoordinate(x_P2_bCode_Final);
			PointF y_P1_Final = GetBoardCoordinate(y_P1_bCode_Final);
			PointF y_P2_Final = GetBoardCoordinate(y_P2_bCode_Final);
			#endregion
			
			#region Log Message
			string LogMessage =
				"P:(" + p.X.ToString() + "," + p.Y.ToString() + ")" + "\n" +
				"第一次逼近座標(走外圍方式)" + "\n" +
				x_P1_bCode.ToString() + " : (" + x_P1.X.ToString() + "," + x_P1.Y.ToString() + ")" + "\t" +
				x_P2_bCode.ToString() + " : (" + x_P2.X.ToString() + "," + x_P2.Y.ToString() + ")" + "\n" +
				y_P1_bCode.ToString() + " : (" + y_P1.X.ToString() + "," + y_P1.Y.ToString() + ")" + "\t" +
				y_P2_bCode.ToString() + " : (" + y_P2.X.ToString() + "," + y_P2.Y.ToString() + ")" + "\n" +
				"第二次逼近座標(由外圍集中至中央)" + "\n" +
				x_P1_bCode_Final.ToString() + " : (" + x_P1_Final.X.ToString() + "," + x_P1_Final.Y.ToString() + ")" + "\t" +
				x_P2_bCode_Final.ToString() + " : (" + x_P2_Final.X.ToString() + "," + x_P2_Final.Y.ToString() + ")" + "\n" +
				y_P1_bCode_Final.ToString() + " : (" + y_P1_Final.X.ToString() + "," + y_P1_Final.Y.ToString() + ")" + "\t" +
				y_P2_bCode_Final.ToString() + " : (" + y_P2_Final.X.ToString() + "," + y_P2_Final.Y.ToString() + ")" + "\n" +
				"檢查圓之半徑 : " + radius.ToString() + "\n";
			
			#endregion

			#region Final Action
			//得到最少一個點, 最多四個點座標, 以這些點座標去求取最接近的點
			//有可能四個都不符合, 就表示Mouse Click落點在棋子外部, 此時就要回傳-1
			if(ContainInCircle(radius, x_P1_Final, (PointF)p)){LogMessage += "Result : " + x_P1_bCode_Final.ToString();WriteLog("MouseClick_To_BoardCode", LogMessage);return (int)x_P1_bCode_Final;}
			if(ContainInCircle(radius, x_P2_Final, (PointF)p)){LogMessage += "Result : " + x_P2_bCode_Final.ToString();WriteLog("MouseClick_To_BoardCode", LogMessage);return (int)x_P2_bCode_Final;}
			if(ContainInCircle(radius, y_P1_Final, (PointF)p)){LogMessage += "Result : " + y_P1_bCode_Final.ToString();WriteLog("MouseClick_To_BoardCode", LogMessage);return (int)y_P1_bCode_Final;}
			if(ContainInCircle(radius, y_P2_Final, (PointF)p)){LogMessage += "Result : " + y_P2_bCode_Final.ToString();WriteLog("MouseClick_To_BoardCode", LogMessage);return (int)y_P2_bCode_Final;}
			LogMessage += "Result : " + "Not Match!!";WriteLog("MouseClick_To_BoardCode", LogMessage);return -1;
			#endregion
		}
		/// <summary>
		/// 驗證點P_dest是否在P_center為圓心, 半徑為radius的圓形範圍之內
		/// </summary>
		/// <param name="radius">半徑</param>
		/// <param name="P_center">圓心</param>
		/// <param name="P_dest">驗證點</param>
		/// <returns>bool</returns>
		public static bool ContainInCircle(float radius, PointF P_center, PointF P_dest)
		{
			float x2 = (P_dest.X - P_center.X) * (P_dest.X - P_center.X);
			float y2 = (P_dest.Y - P_center.Y) * (P_dest.Y - P_center.Y);

			if((x2 + y2) <= (radius * radius))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
