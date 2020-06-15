<ServiceContract()>
Public Interface IFileTransferService

    <OperationContract()>
    Sub UploadFile(pFullName As String, pBytes As Byte())

    <OperationContract()>
    Function DownloadLastFile() As ResponseFile

End Interface

<DataContract>
Public Class ResponseFile
    <DataMember>
    Property FullName As String
    <DataMember>
    Property Bytes As Byte()
End Class