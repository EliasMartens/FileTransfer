<ServiceContract()>
Public Interface IFileTransferService

    <OperationContract()>
    Function InitializeFileUpload(pFullName As String, pFirstHundredBytes As Byte()) As Integer

    <OperationContract()>
    Sub ContinueFileUpload(pHeaderID As Integer, pHundredBytes As Byte())

    <OperationContract()>
    Sub FinalizeFileUpload(pHeaderID As Integer, pHundredBytes As Byte())

    <OperationContract()>
    Function InitializeDownload(pHeaderID As Integer) As BeginDownloadResponse

    <OperationContract()>
    Function ContinueDownload(pPartID As Integer) As ContinueDownloadResponse

    '<OperationContract()>
    'Function DownloadLastFile() As ResponseFile

End Interface

<DataContract>
Public Class ResponseFile
    <DataMember>
    Property FullName As String
    <DataMember>
    Property Bytes As Byte()
End Class

<DataContract>
Public Class BeginDownloadResponse
    <DataMember>
    Property FullName As String
    <DataMember>
    Property Bytes As Byte()
    <DataMember>
    Property Complete As Boolean
    <DataMember>
    Property NextPartID As Integer
    <DataMember>
    Property PartCount As Integer
End Class

<DataContract>
Public Class ContinueDownloadResponse
    <DataMember>
    Property Bytes As Byte()
    <DataMember>
    Property Complete As Boolean
    <DataMember>
    Property NextPartID As Integer
End Class