Imports System.Drawing
Imports System.Drawing.Imaging

''' <summary>
''' 提供图像效果方法的模块。
''' </summary>
Public Module ImageEffects
	''' <summary>
	''' 改变指定 <see cref="Graphics"/> 对象中已绘制完毕的 <see cref="Image"/> 对象的 Alpha 值。
	''' </summary>
	''' <param name="G2d">必需。指定的 <see cref="Graphics"/> 来源对象。</param>
	''' <param name="Source">必需。对应 <see cref="Graphics"/> 对象中已绘制完毕的 <see cref="Image"/> 对象。</param>
	''' <param name="AlphaValue">必需。要将 <see cref="Image"/> 对象更改到的Alpha值(范围0.0-1.0)。</param>
	''' <exception cref="ArgumentException" />
	Public Sub ChangeAlpha(ByRef G2d As Graphics, ByRef Source As Image, ByVal AlphaValue As Single)
		If (AlphaValue > 1.0) Or (AlphaValue < 0.0) Then
			Throw New ArgumentException("Invalid AlphaValue. AlphaValue must from 0.0 to 1.0.")
		End If
		Dim width As Int32 = Source.Width
		Dim height As Int32 = Source.Height
		Dim imageattr As New ImageAttributes()
		Dim matrix As New ColorMatrix({New Single() {1, 0, 0, 0, 0},
									  New Single() {0, 1, 0, 0, 0},
									  New Single() {0, 0, 1, 0, 0},
									  New Single() {0, 0, 0, 1 - AlphaValue, 0},
									  New Single() {0, 0, 0, 0, 1}})
		' matrix矩阵信息:
		' [[ 1 0 0 0 0 ]
		' [ 0 1 0 0 0 ]
		' [ 0 0 1 0 0 ]
		' [ 0 0 0 {1 - AlphaValue} 0 ]
		' [ 0 0 0 0 1 ]]
		imageattr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)
		G2d.Clear(Color.FromArgb(100, 0, 0, 0))
		G2d.DrawImage(Source, New Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel, imageattr)
	End Sub
End Module
