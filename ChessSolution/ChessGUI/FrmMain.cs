using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Chess
{
	public class FrmMain : System.Windows.Forms.Form
	{
		#region Inner Variables
		/// <summary>
		/// ���F����Paint�ƥ����Human, Computer, Refresh�T�ئӳ]�m���X��
		/// </summary>
		private int Flag = 0;
		/// <summary>
		/// ���a�ѨB������A�^���γ~
		/// </summary>
		private PlayerMoveTypeEnum PlayerMoveType;
		/// <summary>
		/// ��s�Ѥl�����ܼƬO�_����.. �Ϊ̬O�w�����G(�³өά���)
		/// </summary>
		private bool bUpdate = false;
		/// <summary>
		/// �ѩ�ComputerThink�b�����l�Ĥ@�����ʮɦ��G�w�b������s�Lxside��side
		/// �G�[�W�o��Flag�ӱ����o���o�ӯS��
		/// </summary>
		private bool bFirstCompmove = true;
		#endregion
		
		#region Layout Variables
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboBoardStyle;
		private System.Windows.Forms.Label lblInformation;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label lblPieceType01;
		private System.Windows.Forms.Label lblPieceType02;
		private System.Windows.Forms.Label lblPieceColor01;
		private System.Windows.Forms.Label lblPieceColor02;
		private System.Windows.Forms.TextBox MetaEventInvoke;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.ComponentModel.Container components = null;
		#endregion

		#region System Block
		/// <summary>
		/// ���ε{�����D�i�J�I�C
		/// </summary>
		[STAThread]
		static void Main() 
		{
			#region �ѽL�����l�ưʧ@
			controller.InitGen();
			controller.side = (int)PieceColorEnum.DARK;
			controller.xside = (int)PieceColorEnum.LIGHT;
			controller.computerside = (int)PieceColorEnum.DARK;
			#endregion
			Application.Run(new FrmMain());
		}

		public FrmMain()
		{
			InitializeComponent();

			#region �ѽL����U�Կﶵ����l�ưʧ@
			for(int i=0;i<10;i++)
			{
				cboBoardStyle.Items.Add("����"+(i+1).ToString());
			}
			cboBoardStyle.SelectedIndex = 5;	//�w�]���謰��6��
			#endregion

			#region ���A�C����l�ưʧ@
			StatusBarPanel[] oSBPs = new StatusBarPanel[5];
			for(int i=0;i<oSBPs.Length;i++)
			{
				oSBPs[i] = new StatusBarPanel();
				oSBPs[i].Width = 145;
				statusBar1.Panels.Add(oSBPs[i]);
			}
			#endregion
		}

		/// <summary>
		/// �M������ϥΤ����귽�C
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form �]�p�u�㲣�ͪ��{���X
		/// <summary>
		/// �����]�p�u��䴩�ҥ�������k - �ФŨϥε{���X�s�边�ק�
		/// �o�Ӥ�k�����e�C
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cboBoardStyle = new System.Windows.Forms.ComboBox();
			this.lblInformation = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.MetaEventInvoke = new System.Windows.Forms.TextBox();
			this.lblPieceType01 = new System.Windows.Forms.Label();
			this.lblPieceType02 = new System.Windows.Forms.Label();
			this.lblPieceColor01 = new System.Windows.Forms.Label();
			this.lblPieceColor02 = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(500, 550);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("�s�ө���", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.label1.Location = new System.Drawing.Point(504, 528);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "��ܴѽL�G";
			// 
			// cboBoardStyle
			// 
			this.cboBoardStyle.Location = new System.Drawing.Point(592, 528);
			this.cboBoardStyle.Name = "cboBoardStyle";
			this.cboBoardStyle.Size = new System.Drawing.Size(168, 20);
			this.cboBoardStyle.TabIndex = 2;
			this.cboBoardStyle.SelectedIndexChanged += new System.EventHandler(this.cboBoardStyle_SelectedIndexChanged);
			// 
			// lblInformation
			// 
			this.lblInformation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblInformation.Font = new System.Drawing.Font("�s�ө���", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.lblInformation.Location = new System.Drawing.Point(504, 0);
			this.lblInformation.Name = "lblInformation";
			this.lblInformation.Size = new System.Drawing.Size(256, 184);
			this.lblInformation.TabIndex = 3;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 557);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(774, 22);
			this.statusBar1.TabIndex = 4;
			// 
			// MetaEventInvoke
			// 
			this.MetaEventInvoke.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.MetaEventInvoke.Location = new System.Drawing.Point(504, 560);
			this.MetaEventInvoke.Name = "MetaEventInvoke";
			this.MetaEventInvoke.ReadOnly = true;
			this.MetaEventInvoke.Size = new System.Drawing.Size(256, 22);
			this.MetaEventInvoke.TabIndex = 5;
			this.MetaEventInvoke.Text = "";
			this.MetaEventInvoke.Visible = false;
			this.MetaEventInvoke.TextChanged += new System.EventHandler(this.MetaEventInvoke_TextChanged);
			// 
			// lblPieceType01
			// 
			this.lblPieceType01.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblPieceType01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPieceType01.Font = new System.Drawing.Font("�s�ө���", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.lblPieceType01.Location = new System.Drawing.Point(504, 192);
			this.lblPieceType01.Name = "lblPieceType01";
			this.lblPieceType01.Size = new System.Drawing.Size(128, 160);
			this.lblPieceType01.TabIndex = 9;
			// 
			// lblPieceType02
			// 
			this.lblPieceType02.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblPieceType02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPieceType02.Font = new System.Drawing.Font("�s�ө���", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.lblPieceType02.Location = new System.Drawing.Point(632, 192);
			this.lblPieceType02.Name = "lblPieceType02";
			this.lblPieceType02.Size = new System.Drawing.Size(128, 160);
			this.lblPieceType02.TabIndex = 10;
			// 
			// lblPieceColor01
			// 
			this.lblPieceColor01.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblPieceColor01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPieceColor01.Font = new System.Drawing.Font("�s�ө���", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.lblPieceColor01.Location = new System.Drawing.Point(504, 360);
			this.lblPieceColor01.Name = "lblPieceColor01";
			this.lblPieceColor01.Size = new System.Drawing.Size(128, 160);
			this.lblPieceColor01.TabIndex = 11;
			// 
			// lblPieceColor02
			// 
			this.lblPieceColor02.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblPieceColor02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPieceColor02.Font = new System.Drawing.Font("�s�ө���", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.lblPieceColor02.Location = new System.Drawing.Point(632, 360);
			this.lblPieceColor02.Name = "lblPieceColor02";
			this.lblPieceColor02.Size = new System.Drawing.Size(128, 160);
			this.lblPieceColor02.TabIndex = 12;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "�]�w";
			// 
			// FrmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(774, 579);
			this.Controls.Add(this.lblPieceColor02);
			this.Controls.Add(this.lblPieceColor01);
			this.Controls.Add(this.lblPieceType02);
			this.Controls.Add(this.lblPieceType01);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.lblInformation);
			this.Controls.Add(this.cboBoardStyle);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MetaEventInvoke);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "���C�_�N";
			this.Activated += new System.EventHandler(this.FrmMain_Activated);
			this.Deactivate += new System.EventHandler(this.FrmMain_Deactivate);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		#region Event Handle
		private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			#region �ѽL���������sø�s
			controller.DrawBoard(e.Graphics);
			#endregion

			#region �Y�|����l�ƹL�Ѥl����, �|�i��Ѥl����l�ưʧ@
			if(!controller.ChessInitialized){controller.InitializeChess(e.Graphics);}
			#endregion
			
			switch(Flag)
			{
				case 0:
					#region ���e�L��
					controller.ReDrawChess(e.Graphics);
					#endregion
					break;
				case 1:
					controller.ReDrawChess(e.Graphics);
					#region Human Move
					if(controller.side!=controller.computerside)
					{
						PlayerMoveType = controller.DoHumanMove(e.Graphics);
						statusBar1.Panels[3].Text = PlayerMoveType.ToString();
						switch(PlayerMoveType)
						{
							case PlayerMoveTypeEnum.Normal:
								//save 4 symmetrical forms
								if(!controller.BookDataHasRetire)
								{
									for(int x=0;x<4;x++){controller.History_For_BookCheck[x][controller.NumberOfTotalMoves] = move.GetSymmetryMove(controller.newmove, (MoveSymmetryTypeEnum)x);}
									controller.NumberOfTotalMoves++;
								}
								//�����ܼ�-����
								controller.side = controller.xside;
								controller.xside = 1 - controller.xside;

								//��s�L��
								bUpdate = controller.UpdateNewMove(e.Graphics);
								lblInformation.Text = controller.Infos;
								lblPieceColor02.Text = controller.ColorInfos;
								lblPieceType02.Text = controller.PieceInfos;

								//��s�L�����\��, ���sĲ�oTextChanged Event
								if(!bUpdate)
								{
									MetaEventInvoke.Text = "";
									statusBar1.Panels[0].Text = "�ثe�� : �¤�(�q��)";
									statusBar1.Panels[1].Text += controller.side.ToString();
									statusBar1.Panels[2].Text += "R";
								}
								else
								{
									MessageBox.Show("�����!");
									Application.Exit();
								}
								Flag = 2;
								pictureBox1.Invalidate();
								break;
							case PlayerMoveTypeEnum.FirstSelectingChess:
								break;
							case PlayerMoveTypeEnum.SamePositionAndReSelectSame:
								break;
							case PlayerMoveTypeEnum.SameColorAndReSelectNew:
								break;
							case PlayerMoveTypeEnum.OtherIllegalMove:
								break;
						}
					}
					#endregion
					break;
				case 2:
					controller.ReDrawChess(e.Graphics);
					#region Computer Move
					if(controller.side==controller.computerside)
					{	
						if(!controller.GetBook())
						{
							//�}���w�藍��ѨB��, �~�ϥΫ�ҷj�M
							controller.ComputerThink();
							//if(!bFirstCompmove)
							//{
								//�����ܼ�-����
								controller.side = controller.xside;
								controller.xside = 1 - controller.xside;
							//}
							//else
							//{
							//	bFirstCompmove = false;
						//	}
						}
						else
						{
							//save 4 symmetrical forms
							for(int x=0;x<4;x++){controller.History_For_BookCheck[x][controller.NumberOfTotalMoves] = move.GetSymmetryMove(controller.newmove, (MoveSymmetryTypeEnum)x);}
							controller.NumberOfTotalMoves++;
							controller.side = controller.xside;
							controller.xside = 1 - controller.xside;
							bFirstCompmove = false;
						}

						lblInformation.Text = controller.Infos;
						lblPieceColor01.Text = controller.ColorInfos;
						lblPieceType01.Text = controller.PieceInfos;

						//��s�L��
						bUpdate = controller.UpdateNewMove(e.Graphics);
						lblInformation.Text = controller.Infos;
						lblPieceColor02.Text = controller.ColorInfos;
						lblPieceType02.Text = controller.PieceInfos;

						//��s�L�����\��, ���sĲ�oTextChanged Event
						if(!bUpdate)
						{
							statusBar1.Panels[0].Text = "�ثe�� : ����(���a)";
							statusBar1.Panels[1].Text += controller.side.ToString();
							statusBar1.Panels[2].Text += "B";
						}
						else
						{
							MessageBox.Show("�¤��!");
							Application.Exit();
						}
					}
					Flag = 0;
					pictureBox1.Invalidate();
					#endregion
					break;
			}
		}
		
		private void cboBoardStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboBoardStyle.SelectedIndex != -1)
			{
				string BoardBGPath = @"\sys\"+"BK"+cboBoardStyle.Items[cboBoardStyle.SelectedIndex].ToString().Replace("����", string.Empty)+".BMP";
				string LoadMapPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName) + BoardBGPath;
				Bitmap oBit = new Bitmap(LoadMapPath);
				pictureBox1.BackgroundImage = oBit;
			}
		}

		private void FrmMain_Activated(object sender, System.EventArgs e)
		{
			if(MetaEventInvoke.Text == string.Empty)
			{
				MetaEventInvoke.Text = controller.side.ToString();
			}
		}

		private void FrmMain_Deactivate(object sender, System.EventArgs e)
		{
			Flag = 0;
		}

		private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			switch(e.Button)
			{
				case MouseButtons.Left:
					int target = controller.MouseClick_To_BoardCode(new Point(e.X, e.Y));
					if(target!=-1)
					{
						statusBar1.Panels[4].Text = "(" + e.X.ToString() + "," + e.Y.ToString() + ")" + " " + ((BoardCodeEnum)target).ToString();
						if(controller.side!=controller.computerside)
						{
							controller.HumanMove_Dest = target;
							Flag = 1;
							pictureBox1.Invalidate();
						}
					}
					break;
				case MouseButtons.Right:
					break;
				case MouseButtons.None:
					break;
			}
		}
		private void MetaEventInvoke_TextChanged(object sender, System.EventArgs e)
		{
			if(controller.side==controller.computerside)
			{
				Flag = 2;
				pictureBox1.Invalidate();
			}
		}
		#endregion
	}
}
