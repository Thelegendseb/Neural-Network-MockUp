Public Class Network
    Private Layers As List(Of Layer)
    Private LearningRate As Double
    Private Rnd As Random
    Sub New(LearningRate As Double, nLayers As List(Of Integer))
        If nLayers.Count < 2 Then Exit Sub

        Me.LearningRate = LearningRate

        Me.Rnd = New Random

        Me.Layers = New List(Of Layer)

        For ii As Integer = 0 To nLayers.Count - 1

            Dim l As Layer = New Layer(nLayers(ii) - 1)
            Me.Layers.Add(l)

            For jj As Integer = 0 To nLayers(ii) - 1
                l.GetNodes.Add(New Node(Me.Rnd.NextDouble))
            Next

            For Each n As Node In l.GetNodes
                If ii = 0 Then n.SetBias(0)

                If ii > 0 Then
                    For k As Integer = 0 To nLayers(ii - 1) - 1
                        n.GetConnections.Add(New NodeConnection(Me.Rnd.NextDouble))
                    Next
                End If

            Next

        Next
    End Sub

    Public Function Execute(inputs As List(Of Double)) As List(Of Double)
        If inputs.Count <> Me.Layers(0).GetNodes.Count Then
            Return Nothing
        End If

        For ii As Integer = 0 To Me.Layers.Count - 1
            Dim curLayer As Layer = Me.Layers(ii)

            For jj As Integer = 0 To curLayer.GetNodes.Count - 1
                Dim curNode As Node = curLayer.GetNodes(jj)

                If ii = 0 Then
                    curNode.SetValue(inputs(jj))
                Else
                    curNode.SetValue(0)
                    For k = 0 To Me.Layers(ii - 1).GetNodes.Count - 1
                        curNode.SetValue(curNode.GetValue + Me.Layers(ii - 1).GetNodes(k).GetValue * curNode.GetConnections(k).GetWeight)
                    Next k

                    curNode.SetValue(sigmoid(curNode.GetValue + curNode.GetBias))
                End If

            Next
        Next

        Dim outputs As New List(Of Double)
        Dim la As Layer = Me.Layers(Me.Layers.Count - 1)
        For ii As Integer = 0 To la.GetNodes.Count - 1
            outputs.Add(la.GetNodes(ii).GetValue)
        Next

        Return outputs
    End Function

    Public Function Train(inputs As List(Of Double), outputs As List(Of Double)) As Boolean
        If inputs.Count <> Me.Layers(0).GetNodes.Count Or outputs.Count <> Me.Layers(Me.Layers.Count - 1).GetNodes.Count Then
            Return False
        End If

        Execute(inputs)

        For ii = 0 To Me.Layers(Me.Layers.Count - 1).GetNodes.Count - 1
            Dim curNode As Node = Me.Layers(Me.Layers.Count - 1).GetNodes(ii)

            curNode.SetDelta(curNode.GetValue * (1 - curNode.GetValue) * (outputs(ii) - curNode.GetValue))

            For jj = Me.Layers.Count - 2 To 1 Step -1
                For kk = 0 To Me.Layers(jj).GetNodes.Count - 1
                    Dim iNode As Node = Me.Layers(jj).GetNodes(kk)

                    iNode.SetDelta(iNode.GetValue *
                            (1 - iNode.GetValue) * Me.Layers(jj + 1).GetNodes(ii).GetConnections(kk).GetWeight *
                            Me.Layers(jj + 1).GetNodes(ii).GetDelta)
                Next kk
            Next jj
        Next ii


        For ii = Me.Layers.Count - 1 To 0 Step -1
            For jj = 0 To Me.Layers(ii).GetNodes.Count - 1
                Dim iNode As Node = Me.Layers(ii).GetNodes(jj)
                iNode.SetBias(iNode.GetBias + (Me.LearningRate * iNode.GetDelta))

                For kk = 0 To iNode.GetConnections.Count - 1
                    iNode.GetConnections(kk).SetWeight(iNode.GetConnections(kk).GetWeight + (Me.LearningRate * Me.Layers(ii - 1).GetNodes(kk).GetValue * iNode.GetDelta))
                Next kk
            Next jj
        Next ii

        Return True
    End Function

    Private Function sigmoid(x As Double) As Double
        Return 1 / (1 + Math.Exp(-x))
    End Function

End Class
