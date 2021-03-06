﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileTransferService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BeginDownloadResponse", Namespace="http://schemas.datacontract.org/2004/07/FileTransferService")]
    public partial class BeginDownloadResponse : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private byte[] BytesField;
        
        private bool CompleteField;
        
        private string FullNameField;
        
        private int NextPartIDField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Bytes
        {
            get
            {
                return this.BytesField;
            }
            set
            {
                this.BytesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Complete
        {
            get
            {
                return this.CompleteField;
            }
            set
            {
                this.CompleteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullName
        {
            get
            {
                return this.FullNameField;
            }
            set
            {
                this.FullNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NextPartID
        {
            get
            {
                return this.NextPartIDField;
            }
            set
            {
                this.NextPartIDField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ContinueDownloadResponse", Namespace="http://schemas.datacontract.org/2004/07/FileTransferService")]
    public partial class ContinueDownloadResponse : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private byte[] BytesField;
        
        private bool CompleteField;
        
        private int NextPartIDField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Bytes
        {
            get
            {
                return this.BytesField;
            }
            set
            {
                this.BytesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Complete
        {
            get
            {
                return this.CompleteField;
            }
            set
            {
                this.CompleteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NextPartID
        {
            get
            {
                return this.NextPartIDField;
            }
            set
            {
                this.NextPartIDField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IFileTransferService")]
public interface IFileTransferService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/InitializeFileUpload", ReplyAction="http://tempuri.org/IFileTransferService/InitializeFileUploadResponse")]
    int InitializeFileUpload(string pFullName, byte[] pFirstHundredBytes);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/InitializeFileUpload", ReplyAction="http://tempuri.org/IFileTransferService/InitializeFileUploadResponse")]
    System.Threading.Tasks.Task<int> InitializeFileUploadAsync(string pFullName, byte[] pFirstHundredBytes);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/ContinueFileUpload", ReplyAction="http://tempuri.org/IFileTransferService/ContinueFileUploadResponse")]
    void ContinueFileUpload(int pHeaderID, byte[] pHundredBytes);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/ContinueFileUpload", ReplyAction="http://tempuri.org/IFileTransferService/ContinueFileUploadResponse")]
    System.Threading.Tasks.Task ContinueFileUploadAsync(int pHeaderID, byte[] pHundredBytes);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/FinalizeFileUpload", ReplyAction="http://tempuri.org/IFileTransferService/FinalizeFileUploadResponse")]
    void FinalizeFileUpload(int pHeaderID, byte[] pHundredBytes);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/FinalizeFileUpload", ReplyAction="http://tempuri.org/IFileTransferService/FinalizeFileUploadResponse")]
    System.Threading.Tasks.Task FinalizeFileUploadAsync(int pHeaderID, byte[] pHundredBytes);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/InitializeDownload", ReplyAction="http://tempuri.org/IFileTransferService/InitializeDownloadResponse")]
    FileTransferService.BeginDownloadResponse InitializeDownload(int pHeaderID);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/InitializeDownload", ReplyAction="http://tempuri.org/IFileTransferService/InitializeDownloadResponse")]
    System.Threading.Tasks.Task<FileTransferService.BeginDownloadResponse> InitializeDownloadAsync(int pHeaderID);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/ContinueDownload", ReplyAction="http://tempuri.org/IFileTransferService/ContinueDownloadResponse")]
    FileTransferService.ContinueDownloadResponse ContinueDownload(int pPartID);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/ContinueDownload", ReplyAction="http://tempuri.org/IFileTransferService/ContinueDownloadResponse")]
    System.Threading.Tasks.Task<FileTransferService.ContinueDownloadResponse> ContinueDownloadAsync(int pPartID);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IFileTransferServiceChannel : IFileTransferService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class FileTransferServiceClient : System.ServiceModel.ClientBase<IFileTransferService>, IFileTransferService
{
    
    public FileTransferServiceClient()
    {
    }
    
    public FileTransferServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public FileTransferServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public FileTransferServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public FileTransferServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int InitializeFileUpload(string pFullName, byte[] pFirstHundredBytes)
    {
        return base.Channel.InitializeFileUpload(pFullName, pFirstHundredBytes);
    }
    
    public System.Threading.Tasks.Task<int> InitializeFileUploadAsync(string pFullName, byte[] pFirstHundredBytes)
    {
        return base.Channel.InitializeFileUploadAsync(pFullName, pFirstHundredBytes);
    }
    
    public void ContinueFileUpload(int pHeaderID, byte[] pHundredBytes)
    {
        base.Channel.ContinueFileUpload(pHeaderID, pHundredBytes);
    }
    
    public System.Threading.Tasks.Task ContinueFileUploadAsync(int pHeaderID, byte[] pHundredBytes)
    {
        return base.Channel.ContinueFileUploadAsync(pHeaderID, pHundredBytes);
    }
    
    public void FinalizeFileUpload(int pHeaderID, byte[] pHundredBytes)
    {
        base.Channel.FinalizeFileUpload(pHeaderID, pHundredBytes);
    }
    
    public System.Threading.Tasks.Task FinalizeFileUploadAsync(int pHeaderID, byte[] pHundredBytes)
    {
        return base.Channel.FinalizeFileUploadAsync(pHeaderID, pHundredBytes);
    }
    
    public FileTransferService.BeginDownloadResponse InitializeDownload(int pHeaderID)
    {
        return base.Channel.InitializeDownload(pHeaderID);
    }
    
    public System.Threading.Tasks.Task<FileTransferService.BeginDownloadResponse> InitializeDownloadAsync(int pHeaderID)
    {
        return base.Channel.InitializeDownloadAsync(pHeaderID);
    }
    
    public FileTransferService.ContinueDownloadResponse ContinueDownload(int pPartID)
    {
        return base.Channel.ContinueDownload(pPartID);
    }
    
    public System.Threading.Tasks.Task<FileTransferService.ContinueDownloadResponse> ContinueDownloadAsync(int pPartID)
    {
        return base.Channel.ContinueDownloadAsync(pPartID);
    }
}
