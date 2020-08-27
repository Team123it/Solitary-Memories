Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Module ImageByteConverter
	Public Function ImgToByt(img As Image) As Byte()
		Dim ms As New MemoryStream()
		Dim ImageData As Byte() = Nothing
		img.Save(ms, ImageFormat.Jpeg)
		ImageData = ms.GetBuffer()
		Return ImageData
	End Function

	Public Function BytToImg(byt As Byte()) As Image
		Dim ms As New MemoryStream(byt)
		Dim img As Image = Image.FromStream(ms)
		Return img
	End Function
End Module
