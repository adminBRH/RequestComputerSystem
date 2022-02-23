<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Received.aspx.cs" Inherits="RequestComputerSystem.StrategyService.Received" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row col-12 mx-auto">

        <div class="col-12 mx-auto">
            Category : 
            <input type="text" id="txt_category" class="form-control" runat="server" disabled="disabled" />
        </div>
        <div class="col-12 mx-auto">
            Subject : 
            <input type="text" id="txt_subject" class="form-control" runat="server" disabled="disabled"  />
        </div>
        <div class="col-12 mx-auto">
            Description : 
            <asp:Label ID="lbl_description" Text="" runat="server"></asp:Label>
        </div> 
        
    </div>

</asp:Content>
