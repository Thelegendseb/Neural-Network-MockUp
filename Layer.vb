Public Class Layer
    Private Nodes As List(Of Node)
    Private NodeCount As Integer
    Sub New(NodeCountIn As Integer)
        Me.Nodes = New List(Of Node)
        Me.NodeCount = NodeCountIn
    End Sub
    Public Sub SetNodes(val As List(Of Node))
        Me.Nodes = val
    End Sub

    Public Function GetNodes() As List(Of Node)
        Return Me.Nodes
    End Function

    Public Sub SetNodeCount(val As Integer)
        Me.NodeCount = val
    End Sub

    Public Function GetNodeCount() As Integer
        Return Me.NodeCount
    End Function

End Class
