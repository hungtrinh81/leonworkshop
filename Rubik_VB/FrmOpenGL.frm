VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.Form FrmOpenGL 
   Caption         =   "OpenGL 3D Model"
   ClientHeight    =   6795
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   12675
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6795
   ScaleWidth      =   12675
   StartUpPosition =   2  '�ù�����
   Begin VB.CommandButton cmdClearHistory 
      Caption         =   "�M�����{"
      Height          =   375
      Left            =   4920
      TabIndex        =   35
      Top             =   1320
      Width           =   1215
   End
   Begin VB.ListBox List1 
      Height          =   2580
      Left            =   6240
      TabIndex        =   34
      Top             =   120
      Width           =   3615
   End
   Begin VB.Frame fraFace 
      Height          =   3735
      Left            =   6240
      TabIndex        =   15
      Top             =   2880
      Width           =   3615
      Begin VB.CommandButton cmdMN 
         Caption         =   "M -"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   5
         Left            =   2190
         TabIndex        =   47
         Top             =   3038
         Width           =   615
      End
      Begin VB.CommandButton cmdMP 
         Caption         =   "M +"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   5
         Left            =   2805
         TabIndex        =   41
         Top             =   3038
         Width           =   615
      End
      Begin VB.CommandButton cmdPositive 
         Caption         =   "+"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   5
         Left            =   1575
         TabIndex        =   28
         Top             =   3038
         Width           =   615
      End
      Begin VB.CommandButton cmdNegative 
         Caption         =   "-"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   5
         Left            =   960
         TabIndex        =   33
         Top             =   3038
         Width           =   615
      End
      Begin VB.CommandButton cmdMN 
         Caption         =   "M -"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   4
         Left            =   2190
         TabIndex        =   46
         Top             =   2483
         Width           =   615
      End
      Begin VB.CommandButton cmdMP 
         Caption         =   "M +"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   4
         Left            =   2805
         TabIndex        =   40
         Top             =   2483
         Width           =   615
      End
      Begin VB.CommandButton cmdPositive 
         Caption         =   "+"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   4
         Left            =   1575
         TabIndex        =   27
         Top             =   2483
         Width           =   615
      End
      Begin VB.CommandButton cmdNegative 
         Caption         =   "-"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   4
         Left            =   960
         TabIndex        =   32
         Top             =   2483
         Width           =   615
      End
      Begin VB.CommandButton cmdMN 
         Caption         =   "M -"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   3
         Left            =   2190
         TabIndex        =   45
         Top             =   1928
         Width           =   615
      End
      Begin VB.CommandButton cmdMP 
         Caption         =   "M +"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   3
         Left            =   2805
         TabIndex        =   39
         Top             =   1928
         Width           =   615
      End
      Begin VB.CommandButton cmdPositive 
         Caption         =   "+"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   3
         Left            =   1575
         TabIndex        =   26
         Top             =   1928
         Width           =   615
      End
      Begin VB.CommandButton cmdNegative 
         Caption         =   "-"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   3
         Left            =   960
         TabIndex        =   31
         Top             =   1928
         Width           =   615
      End
      Begin VB.CommandButton cmdMN 
         Caption         =   "M -"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   2
         Left            =   2190
         TabIndex        =   44
         Top             =   1373
         Width           =   615
      End
      Begin VB.CommandButton cmdMP 
         Caption         =   "M +"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   2
         Left            =   2805
         TabIndex        =   38
         Top             =   1373
         Width           =   615
      End
      Begin VB.CommandButton cmdPositive 
         Caption         =   "+"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   2
         Left            =   1575
         TabIndex        =   25
         Top             =   1373
         Width           =   615
      End
      Begin VB.CommandButton cmdNegative 
         Caption         =   "-"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   2
         Left            =   960
         TabIndex        =   30
         Top             =   1373
         Width           =   615
      End
      Begin VB.CommandButton cmdMN 
         Caption         =   "M -"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   1
         Left            =   2190
         TabIndex        =   43
         Top             =   818
         Width           =   615
      End
      Begin VB.CommandButton cmdMP 
         Caption         =   "M +"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   1
         Left            =   2805
         TabIndex        =   37
         Top             =   818
         Width           =   615
      End
      Begin VB.CommandButton cmdPositive 
         Caption         =   "+"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   1
         Left            =   1575
         TabIndex        =   24
         Top             =   818
         Width           =   615
      End
      Begin VB.CommandButton cmdNegative 
         Caption         =   "-"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   1
         Left            =   960
         TabIndex        =   29
         Top             =   818
         Width           =   615
      End
      Begin VB.CommandButton cmdMN 
         Caption         =   "M -"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   0
         Left            =   2190
         TabIndex        =   42
         Top             =   263
         Width           =   615
      End
      Begin VB.CommandButton cmdMP 
         Caption         =   "M +"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   0
         Left            =   2805
         TabIndex        =   36
         Top             =   263
         Width           =   615
      End
      Begin VB.CommandButton cmdPositive 
         Caption         =   "+"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   0
         Left            =   1575
         TabIndex        =   22
         Top             =   263
         Width           =   615
      End
      Begin VB.CommandButton cmdNegative 
         Caption         =   "-"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   0
         Left            =   960
         TabIndex        =   23
         Top             =   263
         Width           =   615
      End
      Begin VB.Label lblInner 
         AutoSize        =   -1  'True
         Caption         =   "�ح��G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   21
         Top             =   2550
         Width           =   765
      End
      Begin VB.Label lblOuter 
         AutoSize        =   -1  'True
         Caption         =   "�~���G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   20
         Top             =   3105
         Width           =   765
      End
      Begin VB.Label lblTop 
         AutoSize        =   -1  'True
         Caption         =   "�W���G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   19
         Top             =   1440
         Width           =   765
      End
      Begin VB.Label lblBottom 
         AutoSize        =   -1  'True
         Caption         =   "�����G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   18
         Top             =   1995
         Width           =   765
      End
      Begin VB.Label lblLeft 
         AutoSize        =   -1  'True
         Caption         =   "�����G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   17
         Top             =   330
         Width           =   765
      End
      Begin VB.Label lblRignt 
         AutoSize        =   -1  'True
         Caption         =   "�k���G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   16
         Top             =   885
         Width           =   765
      End
   End
   Begin VB.OptionButton optLightOff 
      Caption         =   "��������"
      BeginProperty Font 
         Name            =   "�s�ө���"
         Size            =   9.75
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4920
      TabIndex        =   14
      Top             =   960
      Value           =   -1  'True
      Width           =   1215
   End
   Begin VB.OptionButton optLightOn 
      Caption         =   "�}�ҥ���"
      BeginProperty Font 
         Name            =   "�s�ө���"
         Size            =   9.75
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4920
      TabIndex        =   13
      Top             =   600
      Width           =   1215
   End
   Begin VB.Frame fraZoom 
      Height          =   4695
      Left            =   5040
      TabIndex        =   10
      Top             =   1920
      Width           =   1095
      Begin MSComctlLib.Slider SliderZoom 
         Height          =   3975
         Left            =   195
         TabIndex        =   11
         Top             =   600
         Width           =   615
         _ExtentX        =   1085
         _ExtentY        =   7011
         _Version        =   393216
         Orientation     =   1
         Min             =   -400
         Max             =   -100
         SelStart        =   -150
         TickStyle       =   2
         TickFrequency   =   10
         Value           =   -150
      End
      Begin VB.Label lblZoom 
         AutoSize        =   -1  'True
         Caption         =   "�Y��"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   240
         TabIndex        =   12
         Top             =   240
         Width           =   510
      End
   End
   Begin VB.Frame fraSlider 
      Height          =   1695
      Left            =   0
      TabIndex        =   3
      Top             =   4920
      Width           =   4815
      Begin MSComctlLib.Slider SliderX 
         Height          =   435
         Left            =   480
         TabIndex        =   4
         Top             =   120
         Width           =   4215
         _ExtentX        =   7435
         _ExtentY        =   767
         _Version        =   393216
         Max             =   360
         TickFrequency   =   10
      End
      Begin MSComctlLib.Slider SliderY 
         Height          =   435
         Left            =   480
         TabIndex        =   5
         Top             =   555
         Width           =   4215
         _ExtentX        =   7435
         _ExtentY        =   767
         _Version        =   393216
         Max             =   360
         TickFrequency   =   10
      End
      Begin MSComctlLib.Slider SliderZ 
         Height          =   435
         Left            =   480
         TabIndex        =   6
         Top             =   990
         Width           =   4215
         _ExtentX        =   7435
         _ExtentY        =   767
         _Version        =   393216
         Max             =   360
         TickFrequency   =   10
      End
      Begin VB.Label lblX 
         AutoSize        =   -1  'True
         Caption         =   "X�G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   9
         Top             =   217
         Width           =   435
      End
      Begin VB.Label lblY 
         AutoSize        =   -1  'True
         Caption         =   "Y�G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   8
         Top             =   652
         Width           =   435
      End
      Begin VB.Label lblZ 
         AutoSize        =   -1  'True
         Caption         =   "Z�G"
         BeginProperty Font 
            Name            =   "�s�ө���"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   7
         Top             =   1087
         Width           =   405
      End
   End
   Begin VB.CommandButton cmdOpenGL 
      Caption         =   "���J�ϧ�"
      Height          =   375
      Left            =   4920
      TabIndex        =   1
      Top             =   120
      Width           =   1215
   End
   Begin VB.PictureBox pctTextureLoader 
      AutoRedraw      =   -1  'True
      AutoSize        =   -1  'True
      Height          =   1515
      Left            =   3240
      ScaleHeight     =   97
      ScaleMode       =   3  '����
      ScaleWidth      =   97
      TabIndex        =   0
      Top             =   0
      Visible         =   0   'False
      Width           =   1515
   End
   Begin VB.PictureBox PicBlock 
      Height          =   4800
      Left            =   0
      ScaleHeight     =   4740
      ScaleWidth      =   4740
      TabIndex        =   2
      Top             =   0
      Width           =   4800
   End
End
Attribute VB_Name = "FrmOpenGL"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'�}��OpenGLø�Ͼ��O�_���\
Dim OpenGL_Initial_Status As Boolean

'���J�ϧΧ��豱��νs��
Dim bitmapImage_1() As GLubyte
Dim bitmapImage_2() As GLubyte
Dim bitmapImage_3() As GLubyte
Dim bitmapImage_4() As GLubyte
Dim bitmapImage_5() As GLubyte
Dim bitmapImage_6() As GLubyte

'���J�ϧΧ���ɨ��o�e�����Ȧs�ܼ�
Dim bitmapHeight As GLfloat
Dim bitmapWidth As GLfloat

'���J�ϧΧ���ɨ��o�~���ɮצW�٤��Ȧs�ܼ�
Dim bitmapFilename(1 To 6) As String

'OpenGL DrawList �����
Const CORE_LIST = 99999                 '�֤�

Const CORNER_LIST_1 = 1000              '26�Ӥ��
Const CORNER_LIST_2 = 2000
Const CORNER_LIST_3 = 3000
Const CORNER_LIST_4 = 4000
Const CORNER_LIST_5 = 5000
Const CORNER_LIST_6 = 6000
Const CORNER_LIST_7 = 7000
Const CORNER_LIST_8 = 8000
Const CORNER_LIST_9 = 9000
Const CORNER_LIST_10 = 10000
Const CORNER_LIST_11 = 11000
Const CORNER_LIST_12 = 12000
Const CORNER_LIST_13 = 13000
Const CORNER_LIST_14 = 14000
Const CORNER_LIST_15 = 15000
Const CORNER_LIST_16 = 16000
Const CORNER_LIST_17 = 17000
Const CORNER_LIST_18 = 18000
Const CORNER_LIST_19 = 19000
Const CORNER_LIST_20 = 20000
Const CORNER_LIST_21 = 21000
Const CORNER_LIST_22 = 22000
Const CORNER_LIST_23 = 23000
Const CORNER_LIST_24 = 24000
Const CORNER_LIST_25 = 25000
Const CORNER_LIST_26 = 26000

Dim LightAmbient(0 To 3) As GLfloat     '���ҥ�
Dim LightDiffuse(0 To 3) As GLfloat     '���g��
Dim LightPosition(0 To 2) As GLfloat    '�O����m

Dim CornerList(1 To 26) As String                   '����R�A��m�s��
Dim CornerSymbol(1 To 26) As String                 '����ʺA��m�Ÿ�
Dim SurfaceRing(1 To 6) As String                   '���ӭ��Y����������ʺA��m�Ÿ�
Dim SurfaceMiddleRing(1 To 6) As String             '���ӭ��Y�������������ߤ���ʺA��m�Ÿ�
Dim RotateVectex(1 To 6) As String                  '���b����ΦV�q�ȼȦs��
Dim ArrRotateVectex(1 To 6, 1 To 256) As String     '�x�s�C������ҨϥΤ����b�V�q��
Dim RotateStatus(1 To 26, 1 To 256) As Boolean      '�x�s�C�Ӥ���b�C������ɬO�_���Q����(�@���̦h���ʤ@�ӭ�..�@9�Ӥ��)

'�S�O�s��(�ѥ����ҵ������W�� - �k�W�� - �k�U�� - ���U�� -- �W - �k - �U - �� �K�Ӧ�m���ʺA�s���}�C)
Dim SpecialBlockNumber(1 To 12, 1 To 8) As String

'�M��������{
'�M���x�s��
Private Sub cmdClearHistory_Click()
    List1.Clear
    InitialRotateVectex
End Sub

'�ϦV�������ʫ��s
Private Sub cmdMN_Click(Index As Integer)
    List1.AddItem 12 + (Index * 2 + 2)
    Form_Paint
End Sub

'���V�������ʫ��s
Private Sub cmdMP_Click(Index As Integer)
    List1.AddItem 12 + (Index * 2 + 1)
    Form_Paint
End Sub

'�ϦV���ʫ��s
Private Sub cmdNegative_Click(Index As Integer)
    List1.AddItem Index * 2 + 2
    Form_Paint
End Sub

'���JOpenGLø�Ͼ���ø�X3D�ϧ�
Private Sub CmdOpenGL_Click()
    
    Dim ScrW, ScrH, FOV
    ScrW = 320 'PicBlock.Width
    ScrH = 320 'PicBlock.Height
    FOV = 45
    
    If Not OpenGL_Initial_Status Then
        '�Ұ�OpenGL
        If VBGLCreate(PicBlock.hDC, 16) = 0 Then
            VBGLReSizeScene ScrW, ScrH, FOV, 0.1, 200
            VBGLInit
            OpenGL_Initial_Status = True
        Else
            MsgBox "�L�k�Ұ�OPENGL"
            VBGLRelease
            End
        End If
    End If

    '�o�̩�m��lø�ϵ{���X
    DrawWorld
    
    '�}�ҫ������s
    cmdOpenGL.Enabled = False
    
    '��ø�����
    Form_Paint
    
End Sub

'���V���ʫ��s
Private Sub cmdPositive_Click(Index As Integer)
    List1.AddItem Index * 2 + 1
    Form_Paint
End Sub

'����l��
Private Sub Form_Load()

    '�O�_�w���\�Ұ�OpenGL�Ҧ�
    OpenGL_Initial_Status = False

    '�]�w�����j�p
    Me.Width = 12800
    Me.Height = 7200
    
    '���J����ϧΩ�J�ܼƤ�
    LoadImage
    
    '��l�ƥ����Ѽ�
    LightAmbient(0) = 0.5
    LightAmbient(1) = 0.5
    LightAmbient(2) = 0.5
    LightAmbient(3) = 1
    
    LightDiffuse(0) = 1
    LightDiffuse(1) = 1
    LightDiffuse(2) = 1
    LightDiffuse(3) = 1
    
    LightPosition(0) = 0
    LightPosition(1) = 0
    LightPosition(2) = -6
    
    '�]�mCornerList�POpenGL�I�s��DrawList���X
    CornerList(1) = CORNER_LIST_1
    CornerList(2) = CORNER_LIST_2
    CornerList(3) = CORNER_LIST_3
    CornerList(4) = CORNER_LIST_4
    CornerList(5) = CORNER_LIST_5
    CornerList(6) = CORNER_LIST_6
    CornerList(7) = CORNER_LIST_7
    CornerList(8) = CORNER_LIST_8
    CornerList(9) = CORNER_LIST_9
    CornerList(10) = CORNER_LIST_10
    CornerList(11) = CORNER_LIST_11
    CornerList(12) = CORNER_LIST_12
    CornerList(13) = CORNER_LIST_13
    CornerList(14) = CORNER_LIST_14
    CornerList(15) = CORNER_LIST_15
    CornerList(16) = CORNER_LIST_16
    CornerList(17) = CORNER_LIST_17
    CornerList(18) = CORNER_LIST_18
    CornerList(19) = CORNER_LIST_19
    CornerList(20) = CORNER_LIST_20
    CornerList(21) = CORNER_LIST_21
    CornerList(22) = CORNER_LIST_22
    CornerList(23) = CORNER_LIST_23
    CornerList(24) = CORNER_LIST_24
    CornerList(25) = CORNER_LIST_25
    CornerList(26) = CORNER_LIST_26
    
    
    '����ѼƳ]�w
    ResetCornerSymbol
    
    '���R�A����s���M�ΤW
    '����ʧ@�ᤧ�ʺA������s��
    ReGenSurfaceRing
    
    '�N����V�q�Ȫ�l�ƥH�K�p��U�@�Ӥ�������{
    InitialRotateVectex
    
    '��l�ƯS�O�s��, �H�KAnimateAction�ϥ�
    InitialSpecialBlockNumber
        
End Sub

'����ѼƳ]�w
Private Sub ResetCornerSymbol()
    
    '�]�w�C�Ӥ���@�ӥi�ܰʤ��ѧO�Ÿ�
    '�ثe���w�ѧO�Ÿ������lINDEX
    CornerSymbol(1) = "1"
    CornerSymbol(2) = "2"
    CornerSymbol(3) = "3"
    CornerSymbol(4) = "4"
    CornerSymbol(5) = "5"
    CornerSymbol(6) = "6"
    CornerSymbol(7) = "7"
    CornerSymbol(8) = "8"
    CornerSymbol(9) = "9"
    CornerSymbol(10) = "10"
    CornerSymbol(11) = "11"
    CornerSymbol(12) = "12"
    CornerSymbol(13) = "13"
    CornerSymbol(14) = "14"
    CornerSymbol(15) = "15"
    CornerSymbol(16) = "16"
    CornerSymbol(17) = "17"
    CornerSymbol(18) = "18"
    CornerSymbol(19) = "19"
    CornerSymbol(20) = "20"
    CornerSymbol(21) = "21"
    CornerSymbol(22) = "22"
    CornerSymbol(23) = "23"
    CornerSymbol(24) = "24"
    CornerSymbol(25) = "25"
    CornerSymbol(26) = "26"
    
End Sub

'��l�ƭ��]���ӭ�������Ҧb��m
Private Sub ReGenSurfaceRing()
    
    '--�@�ӭ�..9�Ӥ��--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '����
    SurfaceRing(1) = CornerSymbol(1) & "," & CornerSymbol(18) & "," & CornerSymbol(24) & "," & CornerSymbol(7) & "," & CornerSymbol(10) & "," & CornerSymbol(21) & "," & CornerSymbol(15) & "," & CornerSymbol(4) & "," & CornerSymbol(13)
    '�k��
    SurfaceRing(2) = CornerSymbol(20) & "," & CornerSymbol(3) & "," & CornerSymbol(9) & "," & CornerSymbol(26) & "," & CornerSymbol(12) & "," & CornerSymbol(6) & "," & CornerSymbol(17) & "," & CornerSymbol(23) & "," & CornerSymbol(14)
    '�W��
    SurfaceRing(3) = CornerSymbol(1) & "," & CornerSymbol(3) & "," & CornerSymbol(20) & "," & CornerSymbol(18) & "," & CornerSymbol(2) & "," & CornerSymbol(12) & "," & CornerSymbol(19) & "," & CornerSymbol(10) & "," & CornerSymbol(11)
    '�U��
    SurfaceRing(4) = CornerSymbol(24) & "," & CornerSymbol(26) & "," & CornerSymbol(9) & "," & CornerSymbol(7) & "," & CornerSymbol(25) & "," & CornerSymbol(17) & "," & CornerSymbol(8) & "," & CornerSymbol(15) & "," & CornerSymbol(16)
    '�̭�
    SurfaceRing(5) = CornerSymbol(3) & "," & CornerSymbol(1) & "," & CornerSymbol(7) & "," & CornerSymbol(9) & "," & CornerSymbol(2) & "," & CornerSymbol(4) & "," & CornerSymbol(8) & "," & CornerSymbol(6) & "," & CornerSymbol(5)
    '�~��
    SurfaceRing(6) = CornerSymbol(18) & "," & CornerSymbol(20) & "," & CornerSymbol(26) & "," & CornerSymbol(24) & "," & CornerSymbol(19) & "," & CornerSymbol(23) & "," & CornerSymbol(25) & "," & CornerSymbol(21) & "," & CornerSymbol(22)
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    '--�@����..8�Ӥ��--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '�������V�ݪ�������
    SurfaceMiddleRing(1) = CornerSymbol(2) & "," & CornerSymbol(19) & "," & CornerSymbol(25) & "," & CornerSymbol(8) & "," & CornerSymbol(11) & "," & CornerSymbol(22) & "," & CornerSymbol(16) & "," & CornerSymbol(5)
    '�k�����V�ݪ�������
    SurfaceMiddleRing(2) = CornerSymbol(19) & "," & CornerSymbol(2) & "," & CornerSymbol(8) & "," & CornerSymbol(25) & "," & CornerSymbol(11) & "," & CornerSymbol(5) & "," & CornerSymbol(16) & "," & CornerSymbol(22)
    '�W�����V�ݪ�������
    SurfaceMiddleRing(3) = CornerSymbol(4) & "," & CornerSymbol(6) & "," & CornerSymbol(23) & "," & CornerSymbol(21) & "," & CornerSymbol(5) & "," & CornerSymbol(14) & "," & CornerSymbol(22) & "," & CornerSymbol(13)
    '�U�����V�ݪ�������
    SurfaceMiddleRing(4) = CornerSymbol(21) & "," & CornerSymbol(23) & "," & CornerSymbol(6) & "," & CornerSymbol(4) & "," & CornerSymbol(22) & "," & CornerSymbol(14) & "," & CornerSymbol(5) & "," & CornerSymbol(13)
    '�̭����V�ݪ�������
    SurfaceMiddleRing(5) = CornerSymbol(12) & "," & CornerSymbol(10) & "," & CornerSymbol(15) & "," & CornerSymbol(17) & "," & CornerSymbol(11) & "," & CornerSymbol(13) & "," & CornerSymbol(16) & "," & CornerSymbol(14)
    '�~�����V�ݪ�������
    SurfaceMiddleRing(6) = CornerSymbol(10) & "," & CornerSymbol(12) & "," & CornerSymbol(17) & "," & CornerSymbol(15) & "," & CornerSymbol(11) & "," & CornerSymbol(14) & "," & CornerSymbol(16) & "," & CornerSymbol(13)
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
End Sub

'��l�ƭ��]���b�V�q��
Private Sub InitialRotateVectex()

    RotateVectex(1) = "1,0,0"   '��X
    RotateVectex(2) = "-1,0,0"  '�kX
    RotateVectex(3) = "0,1,0"   '�WY
    RotateVectex(4) = "0,-1,0"  '�UY
    RotateVectex(5) = "0,0,1"   '��Z
    RotateVectex(6) = "0,0,-1"  '�~Z
    
    For YY = 1 To 6
        For ZZ = 1 To 256
            ArrRotateVectex(YY, ZZ) = "0,0,0"
        Next
    Next
    
    For YY = 1 To 26
        For ZZ = 1 To 256
            RotateStatus(YY, ZZ) = False
        Next
    Next
    
    ArrRotateVectex(1, 1) = RotateVectex(1)
    ArrRotateVectex(2, 1) = RotateVectex(2)
    ArrRotateVectex(3, 1) = RotateVectex(3)
    ArrRotateVectex(4, 1) = RotateVectex(4)
    ArrRotateVectex(5, 1) = RotateVectex(5)
    ArrRotateVectex(6, 1) = RotateVectex(6)
    
End Sub

'��l�ƯS�O�s��
Private Sub InitialSpecialBlockNumber()
    Dim XX, YY As Integer
    Dim TmpVar(1 To 12) As String
    Dim aTmpVar
    '��
    TmpVar(1) = "1,18,24,7,10,21,15,4"
    TmpVar(2) = "20,3,9,26,12,6,17,23"
    TmpVar(3) = "1,3,20,18,2,12,19,10"
    TmpVar(4) = "24,26,9,7,25,17,8,15"
    TmpVar(5) = "3,1,7,9,2,4,8,6"
    TmpVar(6) = "18,20,26,24,19,23,25,21"
    '��
    TmpVar(7) = "2,19,25,8,11,22,16,5"
    TmpVar(8) = "19,2,8,25,11,5,16,22"
    TmpVar(9) = "4,6,23,21,5,14,22,13"
    TmpVar(10) = "21,23,6,4,22,14,5,13"
    TmpVar(11) = "12,10,15,17,11,13,16,14"
    TmpVar(12) = "10,12,17,15,11,14,16,13"
    
    For XX = 1 To 12
        aTmpVar = Split(TmpVar(XX), ",")
        For YY = 1 To 8
            SpecialBlockNumber(XX, YY) = aTmpVar(YY - 1)
        Next
    Next
    
End Sub

'���oCurrentElementNo�����, �bCurrentRing������ڲ��ʤ�����s��, CurrentHistory����{�p���ĴX�B
'��X�ֶi�������ثe���A�����b�V�q�ȥH�K�����~�����p��ϥ�
Private Sub ReGetRotateVectex(ByVal CurrentHistoryNo As Integer, ByVal CurrentRing As String, ByVal CurrentElementNo As Integer)

    '���]�w����l���A
    RotateVectex(1) = "1,0,0"   '��X
    RotateVectex(2) = "-1,0,0"  '�kX
    RotateVectex(3) = "0,-1,0"  '�WY
    RotateVectex(4) = "0,1,0"   '�UY
    RotateVectex(5) = "0,0,1"   '��Z
    RotateVectex(6) = "0,0,-1"  '�~Z

    Dim ActionType As Integer
    Dim TmpEnd As String
    Dim II As Integer
    
    If UBound(Split(CurrentRing, ",")) = 8 Then
    
        RotateStatus(Split(CurrentRing, ",")(0), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(1), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(2), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(3), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(4), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(5), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(6), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(7), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(8), CurrentHistoryNo + 1) = True
        
    ElseIf UBound(Split(CurrentRing, ",")) = 7 Then
    
        RotateStatus(Split(CurrentRing, ",")(0), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(1), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(2), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(3), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(4), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(5), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(6), CurrentHistoryNo + 1) = True
        RotateStatus(Split(CurrentRing, ",")(7), CurrentHistoryNo + 1) = True
        
    End If
    
    For II = 0 To CurrentHistoryNo
        
        If RotateStatus(CurrentElementNo, II + 1) Then
            
            ActionType = List1.List(II)
        
            Select Case (ActionType)
                
                Case 1, 13: '������
                    TmpEnd = RotateVectex(5)
                    RotateVectex(5) = RotateVectex(4)
                    RotateVectex(4) = RotateVectex(6)
                    RotateVectex(6) = RotateVectex(3)
                    RotateVectex(3) = TmpEnd
                
                Case 2, 14: '������
                    TmpEnd = RotateVectex(6)
                    RotateVectex(6) = RotateVectex(4)
                    RotateVectex(4) = RotateVectex(5)
                    RotateVectex(5) = RotateVectex(3)
                    RotateVectex(3) = TmpEnd
                
                Case 3, 15: '�k����
                    TmpEnd = RotateVectex(6)
                    RotateVectex(6) = RotateVectex(4)
                    RotateVectex(4) = RotateVectex(5)
                    RotateVectex(5) = RotateVectex(3)
                    RotateVectex(3) = TmpEnd
                
                Case 4, 16: '�k����
                    TmpEnd = RotateVectex(5)
                    RotateVectex(5) = RotateVectex(4)
                    RotateVectex(4) = RotateVectex(6)
                    RotateVectex(6) = RotateVectex(3)
                    RotateVectex(3) = TmpEnd
                
                Case 5, 17: '�W����
                    TmpEnd = RotateVectex(6)
                    RotateVectex(6) = RotateVectex(2)
                    RotateVectex(2) = RotateVectex(5)
                    RotateVectex(5) = RotateVectex(1)
                    RotateVectex(1) = TmpEnd
                
                Case 6, 18: '�W����
                    TmpEnd = RotateVectex(5)
                    RotateVectex(5) = RotateVectex(2)
                    RotateVectex(2) = RotateVectex(6)
                    RotateVectex(6) = RotateVectex(1)
                    RotateVectex(1) = TmpEnd
                
                Case 7, 19: '������
                    TmpEnd = RotateVectex(5)
                    RotateVectex(5) = RotateVectex(2)
                    RotateVectex(2) = RotateVectex(6)
                    RotateVectex(6) = RotateVectex(1)
                    RotateVectex(1) = TmpEnd
                
                Case 8, 20: '������
                    TmpEnd = RotateVectex(6)
                    RotateVectex(6) = RotateVectex(2)
                    RotateVectex(2) = RotateVectex(5)
                    RotateVectex(5) = RotateVectex(1)
                    RotateVectex(1) = TmpEnd
                
                Case 9, 21: '�̥���
                    TmpEnd = RotateVectex(3)
                    RotateVectex(3) = RotateVectex(2)
                    RotateVectex(2) = RotateVectex(4)
                    RotateVectex(4) = RotateVectex(1)
                    RotateVectex(1) = TmpEnd
                
                Case 10, 22: '�̤���
                    TmpEnd = RotateVectex(4)
                    RotateVectex(4) = RotateVectex(2)
                    RotateVectex(2) = RotateVectex(3)
                    RotateVectex(3) = RotateVectex(1)
                    RotateVectex(1) = TmpEnd
                
                Case 11, 23: '�~����
                    TmpEnd = RotateVectex(4)
                    RotateVectex(4) = RotateVectex(2)
                    RotateVectex(2) = RotateVectex(3)
                    RotateVectex(3) = RotateVectex(1)
                    RotateVectex(1) = TmpEnd
                
                Case 12, 24: '�~����
                    TmpEnd = RotateVectex(3)
                    RotateVectex(3) = RotateVectex(2)
                    RotateVectex(2) = RotateVectex(4)
                    RotateVectex(4) = RotateVectex(1)
                    RotateVectex(1) = TmpEnd
                
            End Select
            
        End If
        
    Next
        
End Sub

'����ѧO�s��������T�w��m������
Private Sub AnimateAction(ActionType As Integer)
    
    'Z = -2
    '1  2  3
    '4  5  6
    '7  8  9
    
    'Z = 0
    '10  11  12
    '13  --  14
    '15  16  17
    
    'Z = 2
    '18  19  20
    '21  22  23
    '24  25  26
    
    Dim Number As Integer       '����s��
    Dim Direction As Boolean    'True����, False�����
    
    If InStr(CStr(ActionType / 2), ".") <> 0 Then
        Number = ((ActionType / 2) - 0.5) + 1
        Direction = True
    Else
        Number = ActionType / 2
        Direction = False
    End If
    
    AnimateActionUnit SpecialBlockNumber(Number, 1), SpecialBlockNumber(Number, 2), _
                      SpecialBlockNumber(Number, 3), SpecialBlockNumber(Number, 4), _
                      SpecialBlockNumber(Number, 5), SpecialBlockNumber(Number, 6), _
                      SpecialBlockNumber(Number, 7), SpecialBlockNumber(Number, 8), _
                      Direction
End Sub

'����洫�|�Ө�����Υ|��������m��--���ʳ椸�ʧ@--
Private Sub AnimateActionUnit(ByVal C1 As Integer, ByVal C2 As Integer, ByVal C3 As Integer, ByVal C4 As Integer, ByVal E1 As Integer, ByVal E2 As Integer, ByVal E3 As Integer, ByVal E4 As Integer, ByVal IsPositiveDirection As Boolean)
    
    Dim SourceRing As Variant
    Dim TargetRing As Variant
    Dim ArrTargetRing As Variant
    
    '������ܴ�
    SourceRing = CornerSymbol(C1) & "," & CornerSymbol(C2) & "," & CornerSymbol(C3) & "," & CornerSymbol(C4)
    TargetRing = TransferUnit(SourceRing, IsPositiveDirection)
    ArrTargetRing = Split(TargetRing, ",")
    CornerSymbol(C1) = ArrTargetRing(0)
    CornerSymbol(C2) = ArrTargetRing(1)
    CornerSymbol(C3) = ArrTargetRing(2)
    CornerSymbol(C4) = ArrTargetRing(3)
    
    '�����ܴ�
    SourceRing = CornerSymbol(E1) & "," & CornerSymbol(E2) & "," & CornerSymbol(E3) & "," & CornerSymbol(E4)
    TargetRing = TransferUnit(SourceRing, IsPositiveDirection)
    ArrTargetRing = Split(TargetRing, ",")
    CornerSymbol(E1) = ArrTargetRing(0)
    CornerSymbol(E2) = ArrTargetRing(1)
    CornerSymbol(E3) = ArrTargetRing(2)
    CornerSymbol(E4) = ArrTargetRing(3)

End Sub

'�N��C���V�ΤϦV��@��
Private Function TransferUnit(ActiveRing As Variant, IsPositiveDirection As Boolean) As String
    
    Dim ArrActiveRing
    Dim TargetRing As String
    Dim i As Integer
    Dim TmpEnd, TmpBegin As String
    
    ArrActiveRing = Split(ActiveRing, ",")
    
    If (IsPositiveDirection) Then
    
        TmpEnd = ArrActiveRing(UBound(ArrActiveRing))
        For i = UBound(ArrActiveRing) To 0 Step -1
            If (i >= 1) Then
                ArrActiveRing(i) = ArrActiveRing(i - 1)
            Else
                ArrActiveRing(i) = TmpEnd
            End If
        Next
        
    Else
    
        TmpBegin = ArrActiveRing(0)
        For i = 0 To UBound(ArrActiveRing)
            If (i <= UBound(ArrActiveRing) - 1) Then
                ArrActiveRing(i) = ArrActiveRing(i + 1)
            Else
                ArrActiveRing(i) = TmpBegin
            End If
        Next
    
    End If
    
    TargetRing = Join(ArrActiveRing, ",")
    TransferUnit = TargetRing
    
End Function

'�e�@�ӳ椸�ߤ���, �������C��T�w
'�ǤJ��XYZ���۹���I��ø�Ϧ�m
'ø�ϧ�����m�|�^�ܭ��I
Private Sub GenOneBlock(Angle_SX As Single, Angle_SY As Single, Angle_SZ As Single)
    
    glTranslatef Angle_SX, Angle_SY, Angle_SZ
    
    glBindTexture glTexture2D, 1
    glBegin GL_QUADS
        '���w�k�V�q, �����շǥ�
        glNormal3f 0, 0, 1
        
        glTexCoord2f 0, 0
        glVertex3f -1, 1, 1
        glTexCoord2f 1, 0
        glVertex3f 1, 1, 1
        glTexCoord2f 1, 1
        glVertex3f 1, -1, 1
        glTexCoord2f 0, 1
        glVertex3f -1, -1, 1
    glEnd
        
    glBindTexture glTexture2D, 2
    glBegin GL_QUADS
        '���w�k�V�q, �����շǥ�
        glNormal3f 0, 0, -1
        
        glTexCoord2f 0, 0
        glVertex3f -1, 1, -1
        glTexCoord2f 1, 0
        glVertex3f 1, 1, -1
        glTexCoord2f 1, 1
        glVertex3f 1, -1, -1
        glTexCoord2f 0, 1
        glVertex3f -1, -1, -1
    glEnd
    
    glBindTexture glTexture2D, 3
    glBegin GL_QUADS
        '���w�k�V�q, �����շǥ�
        glNormal3f 0, 1, 0
        
        glTexCoord2f 0, 0
        glVertex3f -1, 1, -1
        glTexCoord2f 1, 0
        glVertex3f 1, 1, -1
        glTexCoord2f 1, 1
        glVertex3f 1, 1, 1
        glTexCoord2f 0, 1
        glVertex3f -1, 1, 1
    glEnd
       
    glBindTexture glTexture2D, 4
    glBegin GL_QUADS
        '���w�k�V�q, �����շǥ�
        glNormal3f 0, -1, 0
        
        glTexCoord2f 0, 0
        glVertex3f -1, -1, -1
        glTexCoord2f 1, 0
        glVertex3f 1, -1, -1
        glTexCoord2f 1, 1
        glVertex3f 1, -1, 1
        glTexCoord2f 0, 1
        glVertex3f -1, -1, 1
    glEnd
    
    glBindTexture glTexture2D, 5
    glBegin GL_QUADS
        '���w�k�V�q, �����շǥ�
        glNormal3f 1, 0, 0
        
        glTexCoord2f 0, 0
        glVertex3f 1, 1, -1
        glTexCoord2f 1, 0
        glVertex3f 1, 1, 1
        glTexCoord2f 1, 1
        glVertex3f 1, -1, 1
        glTexCoord2f 0, 1
        glVertex3f 1, -1, -1
    glEnd
    
    glBindTexture glTexture2D, 6
    glBegin GL_QUADS
        '���w�k�V�q, �����շǥ�
        glNormal3f -1, 0, 0
    
        glTexCoord2f 0, 0
        glVertex3f -1, 1, -1
        glTexCoord2f 1, 0
        glVertex3f -1, 1, 1
        glTexCoord2f 1, 1
        glVertex3f -1, -1, 1
        glTexCoord2f 0, 1
        glVertex3f -1, -1, -1
    glEnd
    
    glTranslatef -Angle_SX, -Angle_SY, -Angle_SZ
    
End Sub

'��lø���󪺰ʧ@
Private Sub DrawWorld()
    
   glPushMatrix
        
        '�֤�
        glNewList CORE_LIST, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, 0, 0
        glEndList
        
        'Z = -2 ����
        '--------------------------------------------------------------------------------
        glNewList CORNER_LIST_1, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, 2, -2
        glEndList
        
        glNewList CORNER_LIST_2, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, 2, -2
        glEndList
        
        glNewList CORNER_LIST_3, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, 2, -2
        glEndList
        
        glNewList CORNER_LIST_4, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, 0, -2
        glEndList
        
        glNewList CORNER_LIST_5, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, 0, -2
        glEndList
        
        glNewList CORNER_LIST_6, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, 0, -2
        glEndList
        
        glNewList CORNER_LIST_7, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, -2, -2
        glEndList
        
        glNewList CORNER_LIST_8, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, -2, -2
        glEndList
        
        glNewList CORNER_LIST_9, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, -2, -2
        glEndList
        '--------------------------------------------------------------------------------
        
        'Z = -2 ����
        '--------------------------------------------------------------------------------
        glNewList CORNER_LIST_10, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, 2, 0
        glEndList
        
        glNewList CORNER_LIST_11, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, 2, 0
        glEndList
        
        glNewList CORNER_LIST_12, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, 2, 0
        glEndList
        
        glNewList CORNER_LIST_13, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, 0, 0
        glEndList
        
        'glNewList CORNER_LIST_14, GL_COMPILE_AND_EXECUTE
        '    GenOneBlock 0, 0, 0
        'glEndList
        
        glNewList CORNER_LIST_14, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, 0, 0
        glEndList
        
        glNewList CORNER_LIST_15, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, -2, 0
        glEndList
        
        glNewList CORNER_LIST_16, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, -2, 0
        glEndList
        
        glNewList CORNER_LIST_17, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, -2, 0
        glEndList
        '--------------------------------------------------------------------------------
        
        'Z = -2 ����
        '--------------------------------------------------------------------------------
        glNewList CORNER_LIST_18, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, 2, 2
        glEndList
        
        glNewList CORNER_LIST_19, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, 2, 2
        glEndList
        
        glNewList CORNER_LIST_20, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, 2, 2
        glEndList
        
        glNewList CORNER_LIST_21, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, 0, 2
        glEndList
        
        glNewList CORNER_LIST_22, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, 0, 2
        glEndList
        
        glNewList CORNER_LIST_23, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, 0, 2
        glEndList
        
        glNewList CORNER_LIST_24, GL_COMPILE_AND_EXECUTE
            GenOneBlock -2, -2, 2
        glEndList
        
        glNewList CORNER_LIST_25, GL_COMPILE_AND_EXECUTE
            GenOneBlock 0, -2, 2
        glEndList
        
        glNewList CORNER_LIST_26, GL_COMPILE_AND_EXECUTE
            GenOneBlock 2, -2, 2
        glEndList
        '--------------------------------------------------------------------------------
    
    glPopMatrix
    
End Sub

Private Sub Display()

    If optLightOn.Value Then
        glEnable GL_LIGHTING
    Else
        glDisable GL_LIGHTING
    End If
    
    '�M��
    glClear GL_COLOR_BUFFER_BIT Or GL_DEPTH_BUFFER_BIT
    
    '��ø����
    glPushMatrix
        'gluLookAt 0, 0, SliderZoom.Value / 10, 0, 0, 0, 0, -1, 0
        glTranslatef 0, 0, SliderZoom.Value / 10
        glRotatef SliderX.Value, 1, 0, 0
        glRotatef SliderY.Value, 0, 1, 0
        glRotatef SliderZ.Value, 0, 0, 1
        
        glCallList CORE_LIST
        
        '----------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------
        
        Dim II, JJ As Integer
        Dim CurrentRing
        
        'List2.Clear
        'List3.Clear
        
        For JJ = 1 To 26

            ResetCornerSymbol
            glLoadIdentity
            glTranslatef 0, 0, SliderZoom.Value / 10
            glRotatef SliderX.Value, 1, 0, 0
            glRotatef SliderY.Value, 0, 1, 0
            glRotatef SliderZ.Value, 0, 0, 1

            Dim AX, BY, CZ As Single
            Dim ActionType As Integer
            Dim CompareArray
            Dim Will_Rotated As Boolean
            Dim CC As Integer
            
            For II = 0 To List1.ListCount - 1
                
                ActionType = List1.List(II)
                AnimateAction ActionType
                ReGenSurfaceRing
                Will_Rotated = False
                
                Select Case (ActionType)

                    Case 1:
                        CurrentRing = SurfaceRing(1)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(1, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(1, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(1, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                        
                    Case 2:
                        CurrentRing = SurfaceRing(1)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        
                        If Will_Rotated Then
                           AX = Split(ArrRotateVectex(1, II + 1), ",")(0)
                           BY = Split(ArrRotateVectex(1, II + 1), ",")(1)
                           CZ = Split(ArrRotateVectex(1, II + 1), ",")(2)
                           glRotatef -90, AX, BY, CZ
                        End If

                    Case 3:
                        CurrentRing = SurfaceRing(2)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(2, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(2, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(2, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                    
                    Case 4:
                        CurrentRing = SurfaceRing(2)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(2, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(2, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(2, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If

                    Case 5:
                        CurrentRing = SurfaceRing(3)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(3, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(3, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(3, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                    
                    Case 6:
                        CurrentRing = SurfaceRing(3)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(3, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(3, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(3, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If

                    
                    Case 7:
                        CurrentRing = SurfaceRing(4)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(4, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(4, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(4, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                        
                    Case 8:
                        CurrentRing = SurfaceRing(4)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(4, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(4, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(4, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If

                    Case 9:
                        CurrentRing = SurfaceRing(5)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(5, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(5, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(5, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If

                    Case 10:
                        CurrentRing = SurfaceRing(5)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(5, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(5, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(5, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If
                        
                    Case 11:
                        CurrentRing = SurfaceRing(6)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(6, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(6, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(6, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                        
                    Case 12:
                        CurrentRing = SurfaceRing(6)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(6, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(6, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(6, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If
                        
                        
                    Case 13:
                        CurrentRing = SurfaceMiddleRing(1)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(1, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(1, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(1, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                        
                    Case 14:
                        CurrentRing = SurfaceMiddleRing(1)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        
                        If Will_Rotated Then
                           AX = Split(ArrRotateVectex(1, II + 1), ",")(0)
                           BY = Split(ArrRotateVectex(1, II + 1), ",")(1)
                           CZ = Split(ArrRotateVectex(1, II + 1), ",")(2)
                           glRotatef -90, AX, BY, CZ
                        End If

                    Case 15:
                        CurrentRing = SurfaceMiddleRing(2)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(2, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(2, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(2, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                    
                    Case 16:
                        CurrentRing = SurfaceMiddleRing(2)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(2, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(2, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(2, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If

                    Case 17:
                        CurrentRing = SurfaceMiddleRing(3)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(3, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(3, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(3, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                    
                    Case 18:
                        CurrentRing = SurfaceMiddleRing(3)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(3, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(3, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(3, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If

                    
                    Case 19:
                        CurrentRing = SurfaceMiddleRing(4)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(4, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(4, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(4, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                        
                    Case 20:
                        CurrentRing = SurfaceMiddleRing(4)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(4, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(4, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(4, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If

                    Case 21:
                        CurrentRing = SurfaceMiddleRing(5)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(5, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(5, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(5, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If

                    Case 22:
                        CurrentRing = SurfaceMiddleRing(5)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(5, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(5, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(5, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If
                        
                    Case 23:
                        CurrentRing = SurfaceMiddleRing(6)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(6, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(6, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(6, II + 1), ",")(2)
                            glRotatef 90, AX, BY, CZ
                        End If
                        
                    Case 24:
                        CurrentRing = SurfaceMiddleRing(6)
                        CompareArray = Split(CurrentRing, ",")
                        For CC = 0 To UBound(CompareArray)
                            If CompareArray(CC) = JJ Then
                                Will_Rotated = True
                                Exit For
                            End If
                        Next
                        If Will_Rotated Then
                            AX = Split(ArrRotateVectex(6, II + 1), ",")(0)
                            BY = Split(ArrRotateVectex(6, II + 1), ",")(1)
                            CZ = Split(ArrRotateVectex(6, II + 1), ",")(2)
                            glRotatef -90, AX, BY, CZ
                        End If

                End Select
                
                ReGetRotateVectex II, CurrentRing, JJ
                
                ArrRotateVectex(1, II + 2) = RotateVectex(1)
                ArrRotateVectex(2, II + 2) = RotateVectex(2)
                ArrRotateVectex(3, II + 2) = RotateVectex(3)
                ArrRotateVectex(4, II + 2) = RotateVectex(4)
                ArrRotateVectex(5, II + 2) = RotateVectex(5)
                ArrRotateVectex(6, II + 2) = RotateVectex(6)
                
            Next II
            
            glCallList CornerList(JJ)


        Next JJ
        
        '----------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------
    
    glPopMatrix
    glFinish
    
    '���
    SwapBuffers PicBlock.hDC

End Sub

'��ø�������ܪ��ʧ@
Private Sub Form_Paint()
    Display
End Sub

Private Sub Form_Unload(Cancel As Integer)
    
    '�Ұ�OpenGL�X�г]�^�D�Ұ�
    OpenGL_Initial_Status = False
    
    '����OpenGL
    VBGLRelease
    
End Sub

'���J����ϧ���
Private Sub LoadImage()

    Dim i As Integer
    
    bitmapFilename(1) = "Texture\001.BMP"
    bitmapFilename(2) = "Texture\002.BMP"
    bitmapFilename(3) = "Texture\003.BMP"
    bitmapFilename(4) = "Texture\004.BMP"
    bitmapFilename(5) = "Texture\005.BMP"
    bitmapFilename(6) = "Texture\006.BMP"
    
    For i = 1 To 6
        pctTextureLoader.Picture = LoadPicture(bitmapFilename(i))
        CreateMapImage i
    Next
    
End Sub

'�N���J������ϧ��ɤ��e�ର���t�ܼ�
Private Sub CreateMapImage(nIndex As Integer)
    
    Dim X As Double, Y As Double
    Dim c As Long
    
    bitmapHeight = pctTextureLoader.ScaleHeight
    bitmapWidth = pctTextureLoader.ScaleWidth
    pctTextureLoader.ScaleMode = 3                  ' Pixels
    
    
    Select Case (nIndex)
            
        Case 1:
        
            ReDim bitmapImage_1(2, bitmapHeight - 1, bitmapWidth - 1)
            
            For X = 0 To bitmapWidth - 1
                For Y = 0 To bitmapHeight - 1
                    c = pctTextureLoader.Point(X, Y)                ' Returns in long format.
                    bitmapImage_1(0, X, bitmapHeight - Y - 1) = c Mod 256
                    bitmapImage_1(1, X, bitmapHeight - Y - 1) = (c And 65280) / 256
                    bitmapImage_1(2, X, bitmapHeight - Y - 1) = (c And 16711680) / 256 / 256
                Next
            Next
            
        Case 2:
        
            ReDim bitmapImage_2(2, bitmapHeight - 1, bitmapWidth - 1)
            
            For X = 0 To bitmapWidth - 1
                For Y = 0 To bitmapHeight - 1
                    c = pctTextureLoader.Point(X, Y)                ' Returns in long format.
                    bitmapImage_2(0, X, bitmapHeight - Y - 1) = c Mod 256
                    bitmapImage_2(1, X, bitmapHeight - Y - 1) = (c And 65280) / 256
                    bitmapImage_2(2, X, bitmapHeight - Y - 1) = (c And 16711680) / 256 / 256
                Next
            Next
            
        Case 3:
        
            ReDim bitmapImage_3(2, bitmapHeight - 1, bitmapWidth - 1)
            
            For X = 0 To bitmapWidth - 1
                For Y = 0 To bitmapHeight - 1
                    c = pctTextureLoader.Point(X, Y)                ' Returns in long format.
                    bitmapImage_3(0, X, bitmapHeight - Y - 1) = c Mod 256
                    bitmapImage_3(1, X, bitmapHeight - Y - 1) = (c And 65280) / 256
                    bitmapImage_3(2, X, bitmapHeight - Y - 1) = (c And 16711680) / 256 / 256
                Next
            Next
            
        Case 4:
        
            ReDim bitmapImage_4(2, bitmapHeight - 1, bitmapWidth - 1)
            
            For X = 0 To bitmapWidth - 1
                For Y = 0 To bitmapHeight - 1
                    c = pctTextureLoader.Point(X, Y)                ' Returns in long format.
                    bitmapImage_4(0, X, bitmapHeight - Y - 1) = c Mod 256
                    bitmapImage_4(1, X, bitmapHeight - Y - 1) = (c And 65280) / 256
                    bitmapImage_4(2, X, bitmapHeight - Y - 1) = (c And 16711680) / 256 / 256
                Next
            Next
            
        Case 5:
        
            ReDim bitmapImage_5(2, bitmapHeight - 1, bitmapWidth - 1)
            
            For X = 0 To bitmapWidth - 1
                For Y = 0 To bitmapHeight - 1
                    c = pctTextureLoader.Point(X, Y)                ' Returns in long format.
                    bitmapImage_5(0, X, bitmapHeight - Y - 1) = c Mod 256
                    bitmapImage_5(1, X, bitmapHeight - Y - 1) = (c And 65280) / 256
                    bitmapImage_5(2, X, bitmapHeight - Y - 1) = (c And 16711680) / 256 / 256
                Next
            Next
            
        Case 6:
        
            ReDim bitmapImage_6(2, bitmapHeight - 1, bitmapWidth - 1)
            
            For X = 0 To bitmapWidth - 1
                For Y = 0 To bitmapHeight - 1
                    c = pctTextureLoader.Point(X, Y)                ' Returns in long format.
                    bitmapImage_6(0, X, bitmapHeight - Y - 1) = c Mod 256
                    bitmapImage_6(1, X, bitmapHeight - Y - 1) = (c And 65280) / 256
                    bitmapImage_6(2, X, bitmapHeight - Y - 1) = (c And 16711680) / 256 / 256
                Next
            Next
    
    End Select
End Sub

'----------------------------------------------------------------------------
'�إ�OpenGL
'----------------------------------------------------------------------------

'hDC �O�n��ܪ�dc�N�X,�i�H�OForm ��PictureBox ��dc
Public Function VBGLCreate(ByVal hDC As Long, ByVal Bits As Integer) As Long
    
    Dim PixelFormat As GLuint           'Holds The Results After Searching For A Match
    Dim pfd As PIXELFORMATDESCRIPTOR    'pfd Tells Windows How We Want Things To Be

    '�]�w�榡
    pfd.nSize = Len(pfd)
    pfd.nVersion = 1
    pfd.dwFlags = PFD_SUPPORT_OPENGL Or PFD_DOUBLEBUFFER Or PFD_DRAW_TO_WINDOW
    pfd.iPixelType = PFD_TYPE_RGBA
    pfd.cColorBits = Bits
    pfd.cDepthBits = 16
    pfd.iLayerType = PFD_MAIN_PLANE
    
    PixelFormat = ChoosePixelFormat(hDC, pfd)
    
    If PixelFormat = 0 Then
        VBGLRelease
        VBGLCreate = -1
        Exit Function
    End If
    
    If SetPixelFormat(hDC, PixelFormat, pfd) = 0 Then
        VBGLRelease
        VBGLCreate = -2
        Exit Function
    End If
    
    '�إ�OpenGLø�Ͼ�
    hRC = wglCreateContext(hDC)
    If (hRC = 0) Then ' Are We Able To Get A Rendering Context?
        VBGLRelease
        VBGLCreate = -3
        Exit Function
    End If
    
    If wglMakeCurrent(hDC, hRC) = 0 Then
        VBGLRelease
        VBGLCreate = -4
        Exit Function
    End If
    
    VBGLCreate = 0
    
End Function

'----------------------------------------------------------------------------
'����OpenGL
'----------------------------------------------------------------------------

Public Sub VBGLRelease()
    
    If hRC Then
        
        '�ݧڭ̬O�_������ OpenGLø�Ͼ�
        If wglMakeCurrent(0, 0) = 0 Then
            MsgBox "Release Of DC And RC Failed.", vbInformation, "SHUTDOWN ERROR"
        End If

        If wglDeleteContext(hRC) = 0 Then
            MsgBox "Release Rendering Context Failed.", vbInformation, "SHUTDOWN ERROR"
        End If
        
        hRC = 0
        
    End If
    
End Sub

'----------------------------------------------------------------------------
'�]�w�����j�p
'�o�Ө禡�i�H�]�w�ت�ø�ϵ������j�p , ����, ���`
'----------------------------------------------------------------------------

Public Sub VBGLReSizeScene(ByVal Width As Long, ByVal Height As Long, ByVal FOV As Double, ByVal zNear As Double, ByVal zFar As Double)
    
    Dim Asp As Single
    
    '�������e
    glViewport 0, 0, Width, Height
    glMatrixMode mmProjection
    glLoadIdentity

    If Height = 0 Then Asp = 1 Else Asp = Width / Height

    'Asp�����e���
    gluPerspective FOV, Asp, zNear, zFar

    glMatrixMode mmModelView
    glLoadIdentity
    
End Sub

'----------------------------------------------------------------------------
'�]�w��l��
'----------------------------------------------------------------------------

Public Function VBGLInit() As Boolean
    
    '���J����K��
    glGenTextures 1, 1
    glBindTexture glTexture2D, 1
    glTexImage2D GL_TEXTURE_2D, 0, 3, bitmapWidth, bitmapHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, bitmapImage_1(0, 0, 0)
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR

    glGenTextures 2, 2
    glBindTexture glTexture2D, 2
    glTexImage2D GL_TEXTURE_2D, 0, 3, bitmapWidth, bitmapHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, bitmapImage_2(0, 0, 0)
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR
    
    glGenTextures 3, 3
    glBindTexture glTexture2D, 3
    glTexImage2D GL_TEXTURE_2D, 0, 3, bitmapWidth, bitmapHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, bitmapImage_3(0, 0, 0)
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR
    
    glGenTextures 4, 4
    glBindTexture glTexture2D, 4
    glTexImage2D GL_TEXTURE_2D, 0, 3, bitmapWidth, bitmapHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, bitmapImage_4(0, 0, 0)
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR
    
    glGenTextures 5, 5
    glBindTexture glTexture2D, 5
    glTexImage2D GL_TEXTURE_2D, 0, 3, bitmapWidth, bitmapHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, bitmapImage_5(0, 0, 0)
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR
    
    glGenTextures 6, 6
    glBindTexture glTexture2D, 6
    glTexImage2D GL_TEXTURE_2D, 0, 3, bitmapWidth, bitmapHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, bitmapImage_6(0, 0, 0)
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR
    glTexParameteri GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR
    
    '�ϥΧ���K��
    glEnable glcTexture2D
    
    '���Ƶۦ�
    glShadeModel smSmooth

    '�M���I����
    glClearColor 0, 0, 0, 0
    
    '�M�� depth buffer ��
    glClearDepth 1#
    
    '�ϥβ`�״���
    glEnable glcDepthTest
    glDepthFunc cfLEqual ' The Type Of Depth Test To Do

    '�ϥγ̦n����g�ץ�
    glHint htPerspectiveCorrectionHint, hmNicest
    
    '�]�w����
    glLightfv ltLight0, lpmAmbient, LightAmbient(0)
    glLightfv ltLight0, lpmDiffuse, LightDiffuse(0)
    glLightfv ltLight0, lpmPosition, LightPosition(0)
        
    '�ҥ�0������
    glEnable glcLight0

    VBGLInit = True ' Initialization Went OK

End Function

Private Sub SliderX_Click()
    Form_Paint
End Sub

Private Sub SliderX_Scroll()
    SliderX_Click
End Sub

Private Sub SliderY_Click()
    Form_Paint
End Sub

Private Sub SliderY_Scroll()
    SliderY_Click
End Sub

Private Sub SliderZ_Click()
    Form_Paint
End Sub

Private Sub SliderZ_Scroll()
    SliderZ_Click
End Sub

Private Sub SliderZoom_Click()
    Form_Paint
End Sub

Private Sub SliderZoom_Scroll()
    SliderZoom_Click
End Sub
