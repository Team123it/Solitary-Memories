Public NotInheritable Class Frm_About

	Private Sub Frm_About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		lbl_version.Text = My.Application.Info.Version.ToString
	End Sub

	Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		Me.Close()
	End Sub
End Class
