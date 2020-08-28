Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports Newtonsoft.Json.Linq
''' <summary>
''' 提供对Json数据获取(如从API获取)的方法模块(仅支持GET)。
''' </summary>
Public Module JsonHelper
	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数据字符串。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	''' <param name="Encoding">必需。要获取的数据字符串编码。</param>
	Public Function GetAPIReturnJsonStr(ByVal ApiUrl As Uri, ByRef Encoding As Encoding) As String
		Dim APIURLStr As String = ApiUrl.AbsoluteUri
		Return GetAPIReturnJsonStr(APIURLStr, Encoding)
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数据字符串。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	Public Function GetAPIReturnJsonStr(ByVal ApiUrl As Uri) As String
		Dim APIURLStr As String = ApiUrl.AbsoluteUri
		Return GetAPIReturnJsonStr(APIURLStr, Encoding.UTF8)
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数据字符串。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	''' <param name="Encoding">必需。要获取的数据字符串编码。</param>
	Public Function GetAPIReturnJsonStr(ByVal ApiUrl As String, ByRef Encoding As Encoding) As String
		If ApiUrl.ToLower.Contains("https://") Then 'Https Api
			SetCertificatePolicy() '设置证书
		End If
		Dim request As HttpWebRequest = CType(WebRequest.Create(ApiUrl), HttpWebRequest)
		request.Method = "GET"
		request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.94 Safari/537.36"
		Dim response As HttpWebResponse = request.GetResponse()
		Dim JsonString As String
		Using stream As Stream = response.GetResponseStream()
			Dim reader As New StreamReader(stream, Encoding)
			JsonString = reader.ReadToEnd()
		End Using
		Return JsonString
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数据字符串。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	Public Function GetAPIReturnJsonStr(ByVal ApiUrl As String) As String
		Return GetAPIReturnJsonStr(ApiUrl, Encoding.UTF8)
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数据对象 <see cref="JObject"/> 。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	''' <param name="Encoding">必需。要获取的Json数据编码。</param>
	Public Function GetAPIReturnJson(ByVal ApiUrl As Uri, ByRef Encoding As Encoding) As JObject
		Dim ApiUrlStr As String = ApiUrl.AbsoluteUri
		Return GetAPIReturnJson(ApiUrlStr, Encoding)
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数据对象 <see cref="JObject"/> 。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	Public Function GetAPIReturnJson(ByVal ApiUrl As Uri) As JObject
		Dim ApiUrlStr As String = ApiUrl.AbsoluteUri
		Return GetAPIReturnJson(ApiUrlStr, Encoding.UTF8)
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数据对象 <see cref="JObject"/> 。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	''' <param name="Encoding">必需。要获取的Json数据编码。</param>
	Public Function GetAPIReturnJson(ByVal ApiUrl As String, ByRef Encoding As Encoding) As JObject
		If ApiUrl.ToLower.Contains("https://") Then 'Https Api
			SetCertificatePolicy() '设置证书
		End If
		Dim request As HttpWebRequest = WebRequest.Create(ApiUrl)
		request.Method = "GET"
		request.UserAgent = "SolimmrCore/" & My.Application.Info.Version.ToString & "(Windows NT; Win32; x32) Solitary Memories/" & My.Application.Info.Version.ToString
		Dim response As HttpWebResponse = request.GetResponse()
		Dim JsonString As String
		Using stream As Stream = response.GetResponseStream()
			Dim reader As New StreamReader(stream, Encoding)
			JsonString = reader.ReadToEnd()
		End Using
		Dim JsonObject As JObject = JObject.Parse(JsonString)
		Return JsonObject
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数据对象 <see cref="JObject"/> 。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	Public Function GetAPIReturnJson(ByVal ApiUrl As String) As JObject
		Return GetAPIReturnJson(ApiUrl, Encoding.UTF8)
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数组对象 <see cref="JArray"/> 。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	''' <param name="Encoding">必需。要获取的Json数据编码。</param>
	Public Function GetAPIReturnJsonArray(ByVal ApiUrl As Uri, ByRef Encoding As Encoding) As JArray
		Dim ApiUrlStr As String = ApiUrl.AbsoluteUri
		Return GetAPIReturnJsonArray(ApiUrlStr, Encoding)
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数组对象 <see cref="JArray"/> 。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	Public Function GetAPIReturnJsonArray(ByVal ApiUrl As Uri) As JArray
		Dim ApiUrlStr As String = ApiUrl.AbsoluteUri
		Return GetAPIReturnJsonArray(ApiUrlStr, Encoding.UTF8)
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数组对象 <see cref="JArray"/> 。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	''' <param name="Encoding">必需。要获取的Json数据编码。</param>
	Public Function GetAPIReturnJsonArray(ByVal ApiUrl As String, ByRef Encoding As Encoding) As JArray
		If ApiUrl.ToLower.Contains("https://") Then 'Https Api
			SetCertificatePolicy() '设置证书
		End If
		Dim request As HttpWebRequest = WebRequest.Create(ApiUrl)
		request.Method = "GET"
		request.UserAgent = "SolimmrCore/" & My.Application.Info.Version.ToString & "(Windows NT; Win32; x32) Solitary Memories/" & My.Application.Info.Version.ToString
		Dim response As HttpWebResponse = request.GetResponse()
		Dim JsonString As String
		Using stream As Stream = response.GetResponseStream()
			Dim reader As New StreamReader(stream, Encoding)
			JsonString = reader.ReadToEnd()
		End Using
		Dim JsonArray As JArray = JArray.Parse(JsonString)
		Return JsonArray
	End Function

	''' <summary>
	''' 访问指定HTTP/HTTPS API对应的URL并返回获得的Json数组对象 <see cref="JArray"/> 。
	''' </summary>
	''' <param name="ApiUrl">必需。要访问的API对应的URL。</param>
	Public Function GetAPIReturnJsonArray(ByVal ApiUrl As String) As JArray
		Return GetAPIReturnJsonArray(ApiUrl, Encoding.UTF8)
	End Function

	Private Sub SetCertificatePolicy()
		ServicePointManager.ServerCertificateValidationCallback = AddressOf RemoteCertificateValidate
	End Sub

	Private Function RemoteCertificateValidate(sender As Object, cert As X509Certificate, chain As X509Chain, err As SslPolicyErrors) As Boolean
		Return True
	End Function
End Module
