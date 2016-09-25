Public Class FinancialStuff
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Amount() As Integer
        Get
            Return m_Amount
        End Get
        Set
            m_Amount = Value
        End Set
    End Property
    Private m_Amount As Integer
End Class