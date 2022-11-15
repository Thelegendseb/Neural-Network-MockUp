# NeuralNetworkX

--- Example Implementation

        Dim N As Network
        Dim NStructure As New List(Of Integer)
        NStructure.AddRange({2, 4, 2})
        N = New Network(21.5, NStructure)

        Dim inputs As New List(Of Double)
        Dim outputs As New List(Of Double)

        inputs.AddRange({1, 10})
        outputs.AddRange({0, 1})

        Dim trainingres As Boolean = N.Train(inputs, outputs)

        Dim testinputs As New List(Of Double)
        testinputs.AddRange({2, 9})
        Dim testouputs As List(Of Double) = N.Execute(testinputs)
