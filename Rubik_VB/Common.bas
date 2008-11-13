Attribute VB_Name = "Common"
Public LBL(1 To 9, 1 To 6) As Label
Public BlockColor(1 To 6) As ColorConstants
Public Const LabelWidth = 600
Public Const LabelHeight = 600
Public Total As Integer
Public LeftBase(1 To 9) As Integer
Public TopBase(1 To 9) As Integer
Public LabelBaseLeft(1 To 6) As Integer
Public LabelBaseTop(1 To 6) As Integer

Public Const Totalnum = "5,17,12,11,23,6,4,16,8,1,13,9,2,14,10,3,15,7,16,22,2,7,19,3,8,20,4,9,21,1"

Private Sub Main()
    BlockColor(1) = vbRed
    BlockColor(2) = vbWhite
    BlockColor(3) = vbBlue
    BlockColor(4) = &HCC9966
    BlockColor(5) = vbGreen
    BlockColor(6) = vbYellow
    
    Load FrmMain
    FrmMain.Show
End Sub

'重設整個方塊回到原始狀態
Public Sub ResetBlock()
    Total = 1
    For n = 1 To 6         '六種顏色
        For m = 1 To 9      '九格
            LBL(m, n).Caption = Total
            LBL(m, n).BackColor = BlockColor(n)
            Total = Total + 1
        Next m
    Next n
    
End Sub

'載入整個方塊(54格)
Public Sub InitialBlock()
    
    LeftBase(1) = 0
    LeftBase(2) = LabelWidth
    LeftBase(3) = LabelWidth * 2
    LeftBase(4) = 0
    LeftBase(5) = LabelWidth
    LeftBase(6) = LabelWidth * 2
    LeftBase(7) = 0
    LeftBase(8) = LabelWidth
    LeftBase(9) = LabelWidth * 2
    
    TopBase(1) = 0
    TopBase(2) = 0
    TopBase(3) = 0
    TopBase(4) = LabelHeight
    TopBase(5) = LabelHeight
    TopBase(6) = LabelHeight
    TopBase(7) = LabelHeight * 2
    TopBase(8) = LabelHeight * 2
    TopBase(9) = LabelHeight * 2
    
    Dim PointX, PointY As Integer
    Dim Offset As Integer
    PointX = 2500
    PointY = 2500
    Offset = 1800
    
    LabelBaseLeft(1) = PointX
    LabelBaseTop(1) = PointY
    LabelBaseLeft(2) = PointX + Offset
    LabelBaseTop(2) = PointY
    LabelBaseLeft(3) = PointX + Offset * 2
    LabelBaseTop(3) = PointY
    LabelBaseLeft(4) = PointX + Offset * 3
    LabelBaseTop(4) = PointY
    LabelBaseLeft(5) = PointX + Offset
    LabelBaseTop(5) = PointY - Offset
    LabelBaseLeft(6) = PointX + Offset
    LabelBaseTop(6) = PointY + Offset
    
        
    Dim m, n As Integer
        
    For n = 1 To 6         '六種顏色
        For m = 1 To 9      '九格
            LoadLabel m, n, BlockColor(n), "DynaLabel" & n & "_" & m, LabelBaseTop(n) + TopBase(m), LabelBaseLeft(n) + LeftBase(m)
            '0000,0000      0600,0000       1200,0000               1       2       3
            '0000,0600      0600,0600       1200,0600               4       5       6
            '0000,1200      0600,1200       1200,1200               7       8       9
        Next m
    Next n
    
End Sub

Public Sub LoadLabel(ByVal X As Integer, ByVal Y As Integer, ByVal BlockColor As ColorConstants, ByVal LabelID As String, ByVal LabelTop As Integer, ByVal LabelLeft As Integer)
    
    Dim DynaObj As Object
    Set DynaObj = FrmMain.Controls.Add("vb.label", LabelID)
    
    '位置
    DynaObj.Top = LabelTop
    DynaObj.Left = LabelLeft
    
    '大小
    DynaObj.Width = LabelWidth
    DynaObj.Height = LabelHeight
    
    '框線
    DynaObj.BorderStyle = 1
    
    '對齊
    DynaObj.Alignment = 2
    
    '字型
    Dim FontObj As StdFont
    Set FontObj = New StdFont
    FontObj.Size = 24
    FontObj.Bold = True
    Set DynaObj.Font = FontObj
    
    '背景色
    DynaObj.BackColor = BlockColor
    
    '文字內容
    DynaObj.Caption = Total
    If (Total < 10) Then
        DynaObj.Caption = "0" & DynaObj.Caption
    End If
    
    DynaObj.Visible = True
    
    Total = Total + 1
    Set LBL(X, Y) = DynaObj
    
End Sub

'編號之移動方塊動作(24種動作)
Public Sub Action(ActionNo As Integer)
    Select Case (ActionNo)
    
        Case 1:
            Rotate 1, 1
        Case 2:
            Rotate 2, 1
        Case 3:
            Rotate 3, 1
        Case 4:
            Rotate 4, 1
        Case 5:
            Rotate 5, 1
        Case 6:
            Rotate 6, 1
        Case 7:
            Rotate 1, -1
        Case 8:
            Rotate 2, -1
        Case 9:
            Rotate 3, -1
        Case 10:
            Rotate 4, -1
        Case 11:
            Rotate 5, -1
        Case 12:
            Rotate 6, -1
        Case 13:
            RotateMiddle 1, 1
        Case 14:
            RotateMiddle 2, 1
        Case 15:
            RotateMiddle 3, 1
        Case 16:
            RotateMiddle 4, 1
        Case 17:
            RotateMiddle 5, 1
        Case 18:
            RotateMiddle 6, 1
        Case 19:
            RotateMiddle 1, -1
        Case 20:
            RotateMiddle 2, -1
        Case 21:
            RotateMiddle 3, -1
        Case 22:
            RotateMiddle 4, -1
        Case 23:
            RotateMiddle 5, -1
        Case 24:
            RotateMiddle 6, -1
    End Select
    
End Sub

Public Sub GetMatrix(ByVal GetX As Integer, ByVal GetY As Integer, mWord As String, mColor As ColorConstants)
    '取出
    mWord = Mid(LBL(GetX, GetY).Caption, 1, 2)
    mColor = LBL(GetX, GetY).BackColor
End Sub

Public Sub SwapMatrix(ByVal GetX As Integer, ByVal GetY As Integer, ByVal SetX As Integer, ByVal SetY As Integer)
    '取出
    mWord = Mid(LBL(GetX, GetY).Caption, 1, 2)
    mColor = LBL(GetX, GetY).BackColor
    '寫入
    LBL(SetX, SetY).Caption = mWord
    LBL(SetX, SetY).BackColor = mColor
End Sub

Public Sub SetMatrix(ByVal mWord As String, ByVal mColor As ColorConstants, ByVal SetX As Integer, ByVal SetY As Integer)
    '寫入
    LBL(SetX, SetY).Caption = mWord
    LBL(SetX, SetY).BackColor = mColor
End Sub

'=====心旋=====
'給定一旋轉中心座標, 及旋轉方向(-1:逆時針, +1:順時針), 只移中間9格
Public Sub RotateMiddle(ByVal CN As Integer, ByVal Direction As Integer)

    Select Case (Direction)
    
        Case 1:
        
            Select Case (CN)
            
                Case 1:
                    
                    '=========================
                    MatrixMoveStep 2, 5, 8, 4, 2, 6, 2, 2
                    '=========================
                    MatrixMoveStep 5, 5, 5, 4, 5, 6, 5, 2
                    '=========================
                    MatrixMoveStep 8, 5, 2, 4, 8, 6, 8, 2
                    '=========================
                    
                Case 2:
                
                    '=========================
                    MatrixMoveStep 4, 5, 8, 1, 6, 6, 2, 3
                    '=========================
                    MatrixMoveStep 5, 5, 5, 1, 5, 6, 5, 3
                    '=========================
                    MatrixMoveStep 6, 5, 2, 1, 4, 6, 8, 3
                    '=========================
                
                Case 3:
                
                    '=========================
                    MatrixMoveStep 8, 5, 8, 2, 8, 6, 2, 4
                    '=========================
                    MatrixMoveStep 5, 5, 5, 2, 5, 6, 5, 4
                    '=========================
                    MatrixMoveStep 2, 5, 2, 2, 2, 6, 8, 4
                    '=========================
                
                Case 4:
                
                    '=========================
                    MatrixMoveStep 6, 5, 8, 3, 4, 6, 2, 1
                    '=========================
                    MatrixMoveStep 5, 5, 5, 3, 5, 6, 5, 1
                    '=========================
                    MatrixMoveStep 4, 5, 2, 3, 6, 6, 8, 1
                    '=========================
                
                Case 5:
                
                    '=========================
                    MatrixMoveStep 6, 4, 6, 1, 6, 2, 6, 3
                    '=========================
                    MatrixMoveStep 5, 4, 5, 1, 5, 2, 5, 3
                    '=========================
                    MatrixMoveStep 4, 4, 4, 1, 4, 2, 4, 3
                    '=========================
                
                Case 6:
                
                    '=========================
                    MatrixMoveStep 4, 2, 4, 1, 4, 4, 4, 3
                    '=========================
                    MatrixMoveStep 5, 2, 5, 1, 5, 4, 5, 3
                    '=========================
                    MatrixMoveStep 6, 2, 6, 1, 6, 4, 6, 3
                    '=========================
                
            End Select
        
        Case -1:
        
            Select Case (CN)
            
                Case 1:
                    
                    '=========================
                    MatrixMoveStep 2, 5, 2, 2, 2, 6, 8, 4
                    '=========================
                    MatrixMoveStep 5, 5, 5, 2, 5, 6, 5, 4
                    '=========================
                    MatrixMoveStep 8, 5, 8, 2, 8, 6, 2, 4
                    '=========================
                    
                Case 2:
                
                    '=========================
                    MatrixMoveStep 4, 5, 2, 3, 6, 6, 8, 1
                    '=========================
                    MatrixMoveStep 5, 5, 5, 3, 5, 6, 5, 1
                    '=========================
                    MatrixMoveStep 6, 5, 8, 3, 4, 6, 2, 1
                    '=========================
                
                Case 3:
                
                    '=========================
                    MatrixMoveStep 8, 5, 2, 4, 8, 6, 8, 2
                    '=========================
                    MatrixMoveStep 5, 5, 5, 4, 5, 6, 5, 2
                    '=========================
                    MatrixMoveStep 2, 5, 8, 4, 2, 6, 2, 2
                    '=========================
                
                Case 4:
                
                    '=========================
                    MatrixMoveStep 6, 5, 2, 1, 4, 6, 8, 3
                    '=========================
                    MatrixMoveStep 5, 5, 5, 1, 5, 6, 5, 3
                    '=========================
                    MatrixMoveStep 4, 5, 8, 1, 6, 6, 2, 3
                    '=========================
                
                Case 5:
                
                    '=========================
                    MatrixMoveStep 6, 4, 6, 3, 6, 2, 6, 1
                    '=========================
                    MatrixMoveStep 5, 4, 5, 3, 5, 2, 5, 1
                    '=========================
                    MatrixMoveStep 4, 4, 4, 3, 4, 2, 4, 1
                    '=========================
                
                Case 6:
                
                    '=========================
                    MatrixMoveStep 4, 2, 4, 3, 4, 4, 4, 1
                    '=========================
                    MatrixMoveStep 5, 2, 5, 3, 5, 4, 5, 1
                    '=========================
                    MatrixMoveStep 6, 2, 6, 3, 6, 4, 6, 1
                    '=========================
                
            End Select
    
    End Select

End Sub

'=====邊旋=====
'給定一旋轉中心座標, 及旋轉方向(-1:逆時針, +1:順時針), 移外邊9格,帶12格
Public Sub Rotate(ByVal CN As Integer, ByVal Direction As Integer)
    
    Select Case (Direction)
    
        Case 1:
        
            '順時針
            '1,2,3      7,4,1
            '4,5,6      8,5,2
            '7,8,9      9,6,3
            
            MatrixMoveStep 1, CN, 7, CN, 9, CN, 3, CN
            MatrixMoveStep 2, CN, 4, CN, 8, CN, 6, CN
            
            Select Case (CN)
            
                Case 1:
                    
                    '=========================
                    MatrixMoveStep 1, 5, 9, 4, 1, 6, 1, 2
                    '=========================
                    MatrixMoveStep 4, 5, 6, 4, 4, 6, 4, 2
                    '=========================
                    MatrixMoveStep 7, 5, 3, 4, 7, 6, 7, 2
                    '=========================
                    
                Case 2:
                
                    '=========================
                    MatrixMoveStep 7, 5, 9, 1, 3, 6, 1, 3
                    '=========================
                    MatrixMoveStep 8, 5, 6, 1, 2, 6, 4, 3
                    '=========================
                    MatrixMoveStep 9, 5, 3, 1, 1, 6, 7, 3
                    '=========================
                
                Case 3:
                
                    '=========================
                    MatrixMoveStep 9, 5, 9, 2, 9, 6, 1, 4
                    '=========================
                    MatrixMoveStep 6, 5, 6, 2, 6, 6, 4, 4
                    '=========================
                    MatrixMoveStep 3, 5, 3, 2, 3, 6, 7, 4
                    '=========================
                
                Case 4:
                
                    '=========================
                    MatrixMoveStep 3, 5, 9, 3, 7, 6, 1, 1
                    '=========================
                    MatrixMoveStep 2, 5, 6, 3, 8, 6, 4, 1
                    '=========================
                    MatrixMoveStep 1, 5, 3, 3, 9, 6, 7, 1
                    '=========================
                
                Case 5:
                
                    '=========================
                    MatrixMoveStep 3, 4, 3, 1, 3, 2, 3, 3
                    '=========================
                    MatrixMoveStep 2, 4, 2, 1, 2, 2, 2, 3
                    '=========================
                    MatrixMoveStep 1, 4, 1, 1, 1, 2, 1, 3
                    '=========================
                
                Case 6:
                
                    '=========================
                    MatrixMoveStep 7, 2, 7, 1, 7, 4, 7, 3
                    '=========================
                    MatrixMoveStep 8, 2, 8, 1, 8, 4, 8, 3
                    '=========================
                    MatrixMoveStep 9, 2, 9, 1, 9, 4, 9, 3
                    '=========================
                
            End Select
    
        Case -1:
    
            '逆時針
            '1,2,3      3,6,9
            '4,5,6      2,5,8
            '7,8,9      1,4,7
            
            MatrixMoveStep 1, CN, 3, CN, 9, CN, 7, CN
            MatrixMoveStep 2, CN, 6, CN, 8, CN, 4, CN
            
            Select Case (CN)
            
                Case 1:
                    
                    '=========================
                    MatrixMoveStep 1, 5, 1, 2, 1, 6, 9, 4
                    '=========================
                    MatrixMoveStep 4, 5, 4, 2, 4, 6, 6, 4
                    '=========================
                    MatrixMoveStep 7, 5, 7, 2, 7, 6, 3, 4
                    '=========================
                    
                Case 2:
                
                    '=========================
                    MatrixMoveStep 7, 5, 1, 3, 3, 6, 9, 1
                    '=========================
                    MatrixMoveStep 8, 5, 4, 3, 2, 6, 6, 1
                    '=========================
                    MatrixMoveStep 9, 5, 7, 3, 1, 6, 3, 1
                    '=========================
                
                Case 3:
                
                    '=========================
                    MatrixMoveStep 9, 5, 1, 4, 9, 6, 9, 2
                    '=========================
                    MatrixMoveStep 6, 5, 4, 4, 6, 6, 6, 2
                    '=========================
                    MatrixMoveStep 3, 5, 7, 4, 3, 6, 3, 2
                    '=========================
                
                Case 4:
                
                    '=========================
                    MatrixMoveStep 3, 5, 1, 1, 7, 6, 9, 3
                    '=========================
                    MatrixMoveStep 2, 5, 4, 1, 8, 6, 6, 3
                    '=========================
                    MatrixMoveStep 1, 5, 7, 1, 9, 6, 3, 3
                    '=========================
                
                Case 5:
                
                    '=========================
                    MatrixMoveStep 3, 4, 3, 3, 3, 2, 3, 1
                    '=========================
                    MatrixMoveStep 2, 4, 2, 3, 2, 2, 2, 1
                    '=========================
                    MatrixMoveStep 1, 4, 1, 3, 1, 2, 1, 1
                    '=========================
                
                Case 6:
                
                    '=========================
                    MatrixMoveStep 7, 2, 7, 3, 7, 4, 7, 1
                    '=========================
                    MatrixMoveStep 8, 2, 8, 3, 8, 4, 8, 1
                    '=========================
                    MatrixMoveStep 9, 2, 9, 3, 9, 4, 9, 1
                    '=========================
                
            End Select
            
    End Select
    
End Sub

'旋轉內交換動作(同幾何位置, 4格為1單位)
Private Sub MatrixMoveStep(ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer, ByVal X3 As Integer, ByVal Y3 As Integer, ByVal X4 As Integer, ByVal Y4 As Integer)
    Dim TmpWord As String
    Dim TmpColor As ColorConstants
    GetMatrix X1, Y1, TmpWord, TmpColor
    SwapMatrix X2, Y2, X1, Y1
    SwapMatrix X3, Y3, X2, Y2
    SwapMatrix X4, Y4, X3, Y3
    SetMatrix TmpWord, TmpColor, X4, Y4
End Sub
