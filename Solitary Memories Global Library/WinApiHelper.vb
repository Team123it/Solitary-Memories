Imports System.Runtime.InteropServices

''' <summary>
''' 提供使用Win32API实现的常用Windows NT底层方法。
''' </summary>
Public Module WinApiHelper
	Private Enum SendMessageTimeoutFlags As UInteger
		SMTO_NORMAL = &H0
		SMTO_BLOCK = &H1
		SMTO_ABORTIFHUNG = &H2
		SMTO_NOTIMEOUTIFNOTHIUNG = &H8
	End Enum
	Private Const WM_SETTINGCHANGE As Integer = &H1A
	Private Const HWND_BROADCAST As Integer = &HFFFF

	<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
	Private Function SendMessageTimeout(windowHandle As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As String, flags As SendMessageTimeoutFlags, timeout As UInteger, result As IntPtr) As IntPtr : End Function

	''' <summary>
	''' 刷新环境变量。
	''' </summary>
	Public Sub RefreshEnvironmentVariables()
		Dim result1 As IntPtr
		SendMessageTimeout(New IntPtr(HWND_BROADCAST), WM_SETTINGCHANGE, IntPtr.Zero, "Environment", SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 200, result1)
	End Sub
End Module
