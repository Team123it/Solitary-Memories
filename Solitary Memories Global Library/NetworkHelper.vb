Imports System.Net
Imports System.Net.NetworkInformation

''' <summary>
''' 提供网络相关的方法的模块。
''' </summary>
Public Module NetworkHelper
	''' <summary>
	''' 检查指定的端口是否被占用。
	''' </summary>
	''' <param name="PortType">必需。要检查的端口类型。值参见 <see cref="NetworkPortType"/> 。</param>
	''' <param name="Port">必需。要检查的端口号。范围从1至65535。</param>
	''' <returns></returns>
	Public Function IsPortInUse(ByVal PortType As NetworkPortType, ByVal Port As UShort) As Boolean
		Dim ipProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties
		Try
			Select Case PortType
				Case NetworkPortType.TCP
					Dim ipEndTcpPoints As IPEndPoint() = ipProperties.GetActiveTcpListeners
					For Each tcpEndPoint As IPEndPoint In ipEndTcpPoints
						If tcpEndPoint.Port = Port Then
							Return True
						End If
					Next tcpEndPoint
					Return False
				Case NetworkPortType.UDP
					Dim ipEndUdpPoints As IPEndPoint() = ipProperties.GetActiveUdpListeners
					For Each udpEndPoint As IPEndPoint In ipEndUdpPoints
						If udpEndPoint.Port = Port Then
							Return True
						End If
					Next udpEndPoint
					Return False
				Case Else
					Return False
			End Select
		Catch ex As Exception
			Return False
		End Try
	End Function

	''' <summary>
	''' 定义网络端口的类型枚举。
	''' </summary>
	Public Enum NetworkPortType
		''' <summary>
		''' <para>TCP端口。</para>
		''' <para>HTTP, WebSocket协议均使用此端口类型。</para>
		''' </summary>
		TCP = 0
		''' <summary>
		''' UDP端口。
		''' </summary>
		UDP = 1
	End Enum
End Module
