Public Class NodeConnection
    Private Weight As Double
    Sub New(RndWeightDouble As Double)
        Me.Weight = RndWeightDouble
    End Sub

    Public Sub SetWeight(val As Double)
        Me.Weight = val
    End Sub

    Public Function GetWeight() As Double
        Return Me.Weight
    End Function

End Class
