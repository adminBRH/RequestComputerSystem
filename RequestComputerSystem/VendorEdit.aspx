<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendorEdit.aspx.cs" Inherits="RequestComputerSystem.VendorEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="card">
            <div class="card-body">
                <div class="text-center">

                          <div class="card mb-3" style="max-width: 100%;">
                          <div class="row no-gutters">
                            <div class="col-md-4">
                                <div class="card bg-light">
                                <asp:Label ID="edit_img" Text="" runat="server">
                                </asp:Label>
                                <asp:Label ID="lbl_img" Text="..." runat="server"></asp:Label>
                                    
                             </div>
                            </div>
                            <div class="col-md-8">
                                <h3 class="card-header card text-white bg-info "><B><i class="fas fa-address-card">&nbsp;Profile</i></B></h3>
                                <div class="card-body card bg-light mb-3">
                                <p class="card-text "><i class="fas fa-user"></i>&nbsp;
                                    <asp:Label ID="edit_fname" runat="server">&nbsp;               
                                    </asp:Label>
                                    <asp:Label ID="edit_lname" runat="server">
                                    </asp:Label>
                                 </p>
                                <p class="card-text"><i class="fas fa-map-marker-alt"></i>&nbsp;
                                    <asp:Label ID="edit_address" runat="server">
                                    </asp:Label>
                                    <asp:Label ID="edit_street" runat="server">
                                    </asp:Label>
                                    <asp:Label ID="edit_district" runat="server">
                                    </asp:Label>
                                    <asp:Label ID="edit_province" runat="server">
                                    </asp:Label>
                                    <asp:Label ID="edit_zipcode" runat="server">
                                    </asp:Label>
                                </p>
                                <p class="card-text"><i class="far fa-building"></i>&nbsp;
                                    <asp:Label ID="edit_shopname" runat="server">
                                    </asp:Label>
                                </p>
                                <p class="card-text"><i class="fas fa-phone-square-alt"></i>&nbsp;
                                    <asp:Label ID="edit_pnumber" runat="server">
                                    </asp:Label>
                                </p>
                                <p class="card-text"><i class="far fa-envelope"></i>&nbsp;
                                    <asp:Label ID="edit_email" runat="server">
                                    </asp:Label>
                                </p>
                                <p class="card-text"><i class="fas fa-link"></i>&nbsp;
                                    <asp:Label ID="edit_url" runat="server">
                                    </asp:Label>
                                </p>
                              </div>
                            </div>        
                          </div>
                        </div>

        
                    <!-- Button trigger modal -->
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
                          อัพเดทข้อมูล
                        </button>
                        <!--<button type="button" class="btn btn-primary" id="save_delete" runat="server" onserverclick="save_delete_ServerClick">
                          ลบข้อมูล
                        </button>-->
                </div>
            </div>
        </div>
                        <!-- Modal -->
                        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                          <div class="modal-dialog modal-dialog-centered" role="document">
                            <div class="modal-content">
                              <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLongTitle">อัพเดทข้อมูล</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                  <span aria-hidden="true">&times;</span>
                                </button>
                                     </div>
                                            <div class="modal-body">
                                                    <div class="container">
                                    
                                                    <div class="card">
                                                    <div class="card-body">

                                                    <div class="form-group">
                                                    <label for="fname">First Name</label>
                                                    <input type="text" class="form-control" id="firstname" runat="server">
                                                    </div>  

                                                    <div class="form-group">
                                                    <label for="lname">Last Name</label>
                                                    <input type="text" class="form-control" id="lastname" runat="server"> 
                                                    </div>  
  
                                                    <div class="form-group">
                                                    <label for="vdmail">Email Address</label>
                                                    <input type="email" class="form-control" id="vdemail" aria-describedby="emailHelp" runat="server">
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
                                                    <asp:FileUpload id="uploadimg" runat="server" />   
                                                    <br /><br />
                                                        <p>อัพโหลดไฟล์ JPG เท่านั้น</p>
                                                    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
                                                    </div>

                                                    <div class="form-group">
                                                    <label for="phonenumber">Phone Number</label>
                                                    <input type="text" class="form-control" id="phonenumber" runat="server">
                                                    </div>   

                                                    <div class="form-group">
                                                    <label for="address">Address</label>
                                                    <input type="text" class="form-control" id="vdaddress" runat="server">
                                                    </div> 

                                                    <div class="form-group">
                                                    <label for="street">Street</label>
                                                    <input type="text" class="form-control" id="vdstreet" runat="server">
                                                    </div>

                                                    <div class="form-group">
                                                    <label for="district">District</label>
                                                    <input type="text" class="form-control" id="vddistrict" runat="server">
                                                    </div>

                                                    <div class="form-group">
                                                    <label for="province">Province</label>
                                                    <input type="text" class="form-control" id="vdprovince" runat="server">
                                                    </div>

                                                    <div class="form-group">
                                                    <label for="state">State</label>
                                                    <input type="text" class="form-control" id="vdstate" runat="server">
                                                    <small id="zipcode" class="form-text text-muted">Zip Code</small>  
                                                    </div>
                                                    </div>
                                                    <div class="modal-footer">
                                                          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                          <button type="button" id="savechange" class="btn btn-primary" runat="server" onserverclick="savechange_ServerClick">Save changes</button>
                                                    </div>                                                    
                                              </div>
                                         </div>
                                     </div>
                                </div>
                            </div>
                       </div>                         
    </form>
</asp:Content>
