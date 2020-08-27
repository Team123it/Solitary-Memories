Imports System.Windows.Forms
Imports System.Threading

''' <summary>
''' WinForm窗体特效相关方法的模块。
''' </summary>
Public Module FormEffects
	''' <summary>
	''' 淡入或淡出指定窗体。
	''' </summary>
	''' <param name="CurrentForm">必需。要显示特效的窗体实例。</param>
	''' <param name="FType">必需。要显示的特效类型。值参见 <see cref="FadeType"/> 。</param>
	Public Sub FormFade(ByRef CurrentForm As Form, ByVal FType As FadeType)
		Select Case FType
			Case FadeType.FadeIn
				Dim FadeCount As Integer
				For FadeCount = 0 To 90 Step 5
					CurrentForm.Opacity = FadeCount / 100 '更改透明度
					CurrentForm.Refresh()
					CurrentForm.Invoke(New Action(Sub()
													  Thread.Sleep(5)
												  End Sub)
									  ) '线程，50毫秒
				Next
				CurrentForm.Opacity = 98%
			Case FadeType.FadeOut
				Dim FadeCount As Integer
				For FadeCount = 90 To 0 Step -5
					CurrentForm.Opacity = FadeCount / 100 '更改透明度
					CurrentForm.Refresh()
					CurrentForm.Invoke(New Action(Sub()
													  Thread.Sleep(5)
												  End Sub)
									  ) '线程，50毫秒
				Next
		End Select
	End Sub

	''' <summary>
	''' 窗体淡化特效类型的枚举。
	''' </summary>
	Public Enum FadeType
		''' <summary>
		''' 窗体淡入。
		''' </summary>
		FadeIn = 0
		''' <summary>
		''' 窗体淡出。
		''' </summary>
		FadeOut = 1
	End Enum
End Module
