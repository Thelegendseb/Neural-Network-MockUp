Public Class Node
	Private Connections As List(Of NodeConnection)
	Private Bias As Double
	Private Value As Double
	Private Delta As Double
	Sub New(RndBiasDouble As Double)
		Me.Connections = New List(Of NodeConnection)
		Me.Bias = RndBiasDouble
	End Sub

	Public Sub SetBias(val As Double)
		Me.Bias = val
	End Sub

	Public Function GetBias() As Double
		Return Me.Bias
	End Function

	Public Sub SetValue(val As Double)
		Me.Value = val
	End Sub

	Public Function GetValue() As Double
		Return Me.Value
	End Function

	Public Sub SetDelta(val As Double)
		Me.Delta = val
	End Sub

	Public Function GetDelta() As Double
		Return Me.Delta
	End Function

	Public Sub SetConnections(val As List(Of NodeConnection))
		Me.Connections = val
	End Sub

	Public Function GetConnections() As List(Of NodeConnection)
		Return Me.Connections
	End Function

End Class
