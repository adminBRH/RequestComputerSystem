<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequestComputerSystem.ArcusAir.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
    .btnMain {
        box-shadow: 2px 2px 2px #808080;
        border-radius: 20px;
        text-shadow: 2px 2px 2px #000000;
        font-size: xx-large;
        cursor: pointer;
    }
    .btnMain:hover {
        color: #0094ff;
        border-bottom: solid;
        border-bottom-color: #0094ff;
    }
</style>

    <div class="row col-12 mx-auto">
        <div class="col-5 mx-auto my-2 btn btnMain">
            Create Barcode.
        </div>
        <div class="col-5 mx-auto my-2 btn btnMain">
            Other.
        </div>
    </div>
    
</asp:Content>
