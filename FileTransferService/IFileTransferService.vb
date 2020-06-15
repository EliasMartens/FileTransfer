<ServiceContract()>
Public Interface IFileTransferService

    <OperationContract()>
    Sub UploadFile(bytes As Byte())

End Interface