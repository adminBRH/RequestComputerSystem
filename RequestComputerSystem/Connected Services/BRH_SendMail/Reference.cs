﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RequestComputerSystem.BRH_SendMail {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BRH_SendMail.ServiceSoap")]
    public interface ServiceSoap {
        
        // CODEGEN: Generating message contract since element name To from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MailSendList", ReplyAction="*")]
        RequestComputerSystem.BRH_SendMail.MailSendListResponse MailSendList(RequestComputerSystem.BRH_SendMail.MailSendListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MailSendList", ReplyAction="*")]
        System.Threading.Tasks.Task<RequestComputerSystem.BRH_SendMail.MailSendListResponse> MailSendListAsync(RequestComputerSystem.BRH_SendMail.MailSendListRequest request);
        
        // CODEGEN: Generating message contract since element name mail_to from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MailSend", ReplyAction="*")]
        RequestComputerSystem.BRH_SendMail.MailSendResponse MailSend(RequestComputerSystem.BRH_SendMail.MailSendRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MailSend", ReplyAction="*")]
        System.Threading.Tasks.Task<RequestComputerSystem.BRH_SendMail.MailSendResponse> MailSendAsync(RequestComputerSystem.BRH_SendMail.MailSendRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MailSendListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MailSendList", Namespace="http://tempuri.org/", Order=0)]
        public RequestComputerSystem.BRH_SendMail.MailSendListRequestBody Body;
        
        public MailSendListRequest() {
        }
        
        public MailSendListRequest(RequestComputerSystem.BRH_SendMail.MailSendListRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MailSendListRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public RequestComputerSystem.BRH_SendMail.ArrayOfString To;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Body;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string From;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string FromAliasName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public RequestComputerSystem.BRH_SendMail.ArrayOfString Cc;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public RequestComputerSystem.BRH_SendMail.ArrayOfString Bcc;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Signature;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public bool Authentication;
        
        public MailSendListRequestBody() {
        }
        
        public MailSendListRequestBody(RequestComputerSystem.BRH_SendMail.ArrayOfString To, string Subject, string Body, string From, string FromAliasName, RequestComputerSystem.BRH_SendMail.ArrayOfString Cc, RequestComputerSystem.BRH_SendMail.ArrayOfString Bcc, string Signature, bool Authentication) {
            this.To = To;
            this.Subject = Subject;
            this.Body = Body;
            this.From = From;
            this.FromAliasName = FromAliasName;
            this.Cc = Cc;
            this.Bcc = Bcc;
            this.Signature = Signature;
            this.Authentication = Authentication;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MailSendListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MailSendListResponse", Namespace="http://tempuri.org/", Order=0)]
        public RequestComputerSystem.BRH_SendMail.MailSendListResponseBody Body;
        
        public MailSendListResponse() {
        }
        
        public MailSendListResponse(RequestComputerSystem.BRH_SendMail.MailSendListResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MailSendListResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool MailSendListResult;
        
        public MailSendListResponseBody() {
        }
        
        public MailSendListResponseBody(bool MailSendListResult) {
            this.MailSendListResult = MailSendListResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MailSendRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MailSend", Namespace="http://tempuri.org/", Order=0)]
        public RequestComputerSystem.BRH_SendMail.MailSendRequestBody Body;
        
        public MailSendRequest() {
        }
        
        public MailSendRequest(RequestComputerSystem.BRH_SendMail.MailSendRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MailSendRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string mail_to;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string mail_subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string mail_body;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string mail_from;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string mail_from_aliasname;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string mail_cc;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string mail_bcc;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string mail_signature;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public bool useAuthen;
        
        public MailSendRequestBody() {
        }
        
        public MailSendRequestBody(string mail_to, string mail_subject, string mail_body, string mail_from, string mail_from_aliasname, string mail_cc, string mail_bcc, string mail_signature, bool useAuthen) {
            this.mail_to = mail_to;
            this.mail_subject = mail_subject;
            this.mail_body = mail_body;
            this.mail_from = mail_from;
            this.mail_from_aliasname = mail_from_aliasname;
            this.mail_cc = mail_cc;
            this.mail_bcc = mail_bcc;
            this.mail_signature = mail_signature;
            this.useAuthen = useAuthen;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MailSendResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MailSendResponse", Namespace="http://tempuri.org/", Order=0)]
        public RequestComputerSystem.BRH_SendMail.MailSendResponseBody Body;
        
        public MailSendResponse() {
        }
        
        public MailSendResponse(RequestComputerSystem.BRH_SendMail.MailSendResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MailSendResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool MailSendResult;
        
        public MailSendResponseBody() {
        }
        
        public MailSendResponseBody(bool MailSendResult) {
            this.MailSendResult = MailSendResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceSoapChannel : RequestComputerSystem.BRH_SendMail.ServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSoapClient : System.ServiceModel.ClientBase<RequestComputerSystem.BRH_SendMail.ServiceSoap>, RequestComputerSystem.BRH_SendMail.ServiceSoap {
        
        public ServiceSoapClient() {
        }
        
        public ServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RequestComputerSystem.BRH_SendMail.MailSendListResponse RequestComputerSystem.BRH_SendMail.ServiceSoap.MailSendList(RequestComputerSystem.BRH_SendMail.MailSendListRequest request) {
            return base.Channel.MailSendList(request);
        }
        
        public bool MailSendList(RequestComputerSystem.BRH_SendMail.ArrayOfString To, string Subject, string Body, string From, string FromAliasName, RequestComputerSystem.BRH_SendMail.ArrayOfString Cc, RequestComputerSystem.BRH_SendMail.ArrayOfString Bcc, string Signature, bool Authentication) {
            RequestComputerSystem.BRH_SendMail.MailSendListRequest inValue = new RequestComputerSystem.BRH_SendMail.MailSendListRequest();
            inValue.Body = new RequestComputerSystem.BRH_SendMail.MailSendListRequestBody();
            inValue.Body.To = To;
            inValue.Body.Subject = Subject;
            inValue.Body.Body = Body;
            inValue.Body.From = From;
            inValue.Body.FromAliasName = FromAliasName;
            inValue.Body.Cc = Cc;
            inValue.Body.Bcc = Bcc;
            inValue.Body.Signature = Signature;
            inValue.Body.Authentication = Authentication;
            RequestComputerSystem.BRH_SendMail.MailSendListResponse retVal = ((RequestComputerSystem.BRH_SendMail.ServiceSoap)(this)).MailSendList(inValue);
            return retVal.Body.MailSendListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RequestComputerSystem.BRH_SendMail.MailSendListResponse> RequestComputerSystem.BRH_SendMail.ServiceSoap.MailSendListAsync(RequestComputerSystem.BRH_SendMail.MailSendListRequest request) {
            return base.Channel.MailSendListAsync(request);
        }
        
        public System.Threading.Tasks.Task<RequestComputerSystem.BRH_SendMail.MailSendListResponse> MailSendListAsync(RequestComputerSystem.BRH_SendMail.ArrayOfString To, string Subject, string Body, string From, string FromAliasName, RequestComputerSystem.BRH_SendMail.ArrayOfString Cc, RequestComputerSystem.BRH_SendMail.ArrayOfString Bcc, string Signature, bool Authentication) {
            RequestComputerSystem.BRH_SendMail.MailSendListRequest inValue = new RequestComputerSystem.BRH_SendMail.MailSendListRequest();
            inValue.Body = new RequestComputerSystem.BRH_SendMail.MailSendListRequestBody();
            inValue.Body.To = To;
            inValue.Body.Subject = Subject;
            inValue.Body.Body = Body;
            inValue.Body.From = From;
            inValue.Body.FromAliasName = FromAliasName;
            inValue.Body.Cc = Cc;
            inValue.Body.Bcc = Bcc;
            inValue.Body.Signature = Signature;
            inValue.Body.Authentication = Authentication;
            return ((RequestComputerSystem.BRH_SendMail.ServiceSoap)(this)).MailSendListAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RequestComputerSystem.BRH_SendMail.MailSendResponse RequestComputerSystem.BRH_SendMail.ServiceSoap.MailSend(RequestComputerSystem.BRH_SendMail.MailSendRequest request) {
            return base.Channel.MailSend(request);
        }
        
        public bool MailSend(string mail_to, string mail_subject, string mail_body, string mail_from, string mail_from_aliasname, string mail_cc, string mail_bcc, string mail_signature, bool useAuthen) {
            RequestComputerSystem.BRH_SendMail.MailSendRequest inValue = new RequestComputerSystem.BRH_SendMail.MailSendRequest();
            inValue.Body = new RequestComputerSystem.BRH_SendMail.MailSendRequestBody();
            inValue.Body.mail_to = mail_to;
            inValue.Body.mail_subject = mail_subject;
            inValue.Body.mail_body = mail_body;
            inValue.Body.mail_from = mail_from;
            inValue.Body.mail_from_aliasname = mail_from_aliasname;
            inValue.Body.mail_cc = mail_cc;
            inValue.Body.mail_bcc = mail_bcc;
            inValue.Body.mail_signature = mail_signature;
            inValue.Body.useAuthen = useAuthen;
            RequestComputerSystem.BRH_SendMail.MailSendResponse retVal = ((RequestComputerSystem.BRH_SendMail.ServiceSoap)(this)).MailSend(inValue);
            return retVal.Body.MailSendResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RequestComputerSystem.BRH_SendMail.MailSendResponse> RequestComputerSystem.BRH_SendMail.ServiceSoap.MailSendAsync(RequestComputerSystem.BRH_SendMail.MailSendRequest request) {
            return base.Channel.MailSendAsync(request);
        }
        
        public System.Threading.Tasks.Task<RequestComputerSystem.BRH_SendMail.MailSendResponse> MailSendAsync(string mail_to, string mail_subject, string mail_body, string mail_from, string mail_from_aliasname, string mail_cc, string mail_bcc, string mail_signature, bool useAuthen) {
            RequestComputerSystem.BRH_SendMail.MailSendRequest inValue = new RequestComputerSystem.BRH_SendMail.MailSendRequest();
            inValue.Body = new RequestComputerSystem.BRH_SendMail.MailSendRequestBody();
            inValue.Body.mail_to = mail_to;
            inValue.Body.mail_subject = mail_subject;
            inValue.Body.mail_body = mail_body;
            inValue.Body.mail_from = mail_from;
            inValue.Body.mail_from_aliasname = mail_from_aliasname;
            inValue.Body.mail_cc = mail_cc;
            inValue.Body.mail_bcc = mail_bcc;
            inValue.Body.mail_signature = mail_signature;
            inValue.Body.useAuthen = useAuthen;
            return ((RequestComputerSystem.BRH_SendMail.ServiceSoap)(this)).MailSendAsync(inValue);
        }
    }
}
