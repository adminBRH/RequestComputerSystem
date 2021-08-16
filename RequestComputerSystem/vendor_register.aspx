<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="vendor_register.aspx.cs" Inherits="RequestComputerSystem.vendor_register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="card card-header bg-primary text-center h3" style="color:white">
            Vendor Register
        </div>
     </div>

    <div class="container">
    <form runat="server">
    <div class="card">
    <div class="card-body">

    <div class="form-group">
    <label for="fname">First Name</label>
    <input type="text" class="form-control" required="required" id="firstname" runat="server">
    </div>  

    <div class="form-group">
    <label for="lname">Last Name</label>
    <input type="text" class="form-control" required="required" id="lastname" runat="server"> 
    </div>  
  
    <div class="form-group">
    <label for="vdmail">Email Address</label>
    <input type="email" class="form-control" required="required" id="vdemail" aria-describedby="emailHelp" runat="server">
    </div>
 
    <div class="form-group">
    <label for="shopname">Shop Name</label>
    <input type="text" class="form-control" id="vdshopname" runat="server">
    </div>  
     
    <div class="form-group">
    <label for="companyurl">Company URL</label>
    <input type="text" class="form-control" id="vdurl" runat="server">
    <small id="emailHelp" class="form-text text-muted">https://tscompany-test.com/test</small>
    </div>
    
    <div class="form-group">
    <label for="phonenumber">Phone Number</label>
    <input type="text" class="form-control" required="required" id="phonenumber" runat="server">
    </div>   

    <div class="form-group">
    <label for="address">Address</label>
    <input type="text" class="form-control" required="required" id="vdaddress" runat="server">
    </div> 

    <div class="form-group">
    <label for="street">Street</label>
    <input type="text" class="form-control" id="vdstreet" runat="server">
    </div>

    <div class="form-group">
    <label for="district">District</label>
    <input type="text" class="form-control" required="required" id="vddistrict" runat="server">
    </div>

    <div class="form-group">
    <label for="province">Province</label>
    <input type="text" class="form-control" required="required" id="vdprovince" runat="server">
    </div>

    <div class="form-group">
    <label for="state">Zip Code</label>
    <input type="text" class="form-control" id="vdzipcode" runat="server">  
    </div>

    <!--<div class="form-group">
    <select class="form-control">
    <option>United States</option>
        <option>Italy</option>
        <option>English</option>
        <option>Thailnd</option>
    </select>
    </div>-->

    <div class="text-center">
        <button type="submit" id="savedata" class="btn btn-primary" runat="server" onserverclick="savedata_ServerClick">Submit</button>     
    </div>
      
    </div>
    </div>
    </form>
    </div>

    <div class="container mb-5">
        <div class="card card-footer bg-primary text-center h3" style="color:white">
        </div>
     </div>

</asp:Content>
