 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderRequest.aspx.cs" Inherits="RequestComputerSystem.OrderRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="card card-header text-center mb-3 bg-primary h1" style="color:white">
        ขออนุมัติเปลี่ยนแปลงหรือปรับ Order Items
    </div>

    <div class="card card-body">
        <asp:UpdatePanel ID="UpdatePanel_dept" runat="server">
            <ContentTemplate>
                <div class="col-12 mx-auto">
                    <u><b>เลือกโรงพยาบาล</b></u> 
                </div>
                <div class="col-12 mx-auto">
                    <asp:DropDownList ID="dl_branch" CssClass="col-lg-6 col-sm-12 form-control" OnSelectedIndexChanged="dl_branch_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>
                <div class="col-12 mx-auto mt-5">
                    <u><b>เลือกหน่วยงาน</b></u> 
                </div>
                <div class="col-12 mx-auto">
                   <asp:DropDownList ID="dl_department" CssClass="col-lg-6 col-sm-12 form-control" AutoPostBack="true" OnSelectedIndexChanged="dl_department_SelectedIndexChanged" runat="server">
                       <asp:ListItem Text="" Value=""></asp:ListItem>
                   </asp:DropDownList>
                    <div class="row col-12 mx-auto mt-3">
                        <div class="col-lg-6 col-sm-12 mx-auto my-2">
                            <asp:Label ID="lbl_HOD1" Text="" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-6 col-sm-12 mx-auto my-2">
                            <asp:Label ID="lbl_HOD2" Text="" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dl_department" EventName="selectedindexchanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div class="card card-body my-2">
       <u><b>วัตถุประสงค์เพื่อ</b></u>  
       <div class="mt-2 mb-5">
           <div class="row col-12 input-group" onclick="ShowOther()">
               <div class="col-3 mb-3">
                   <input id="rd_ecnomic" value="Economic Condition" type="radio" name="objective" runat="server"/>&nbsp;Economic Condition
               </div>
               <div class="col-3 mb-3">
                   <input id="rd_annual" value="Annual Reviews" type="radio" name="objective" runat="server"/>&nbsp;Annual Reviews
               </div>
               <div class="col-6 mb-3">
                   <input id="rd_newdept" value="New Department" type="radio" name="objective" runat="server"/>&nbsp;New Department
               </div>
               <div class="col-3">
                   <input id="re_newpro" value="New Product" type="radio" name="objective" runat="server"/>&nbsp;&nbsp;New Product
               </div>
               <div class="col-3">
                   <input id="re_newwork" value="New Wrok Flow" type="radio" name="objective" runat="server"/>&nbsp;&nbsp;New Work Flow
               </div>
               <div class="col-6">
                   <input id="re_other" value="Other" type="radio" name="objective" runat="server"/>&nbsp;&nbsp;Other
                   <input type="text" id="txt_other" class="form-control" value="" runat="server" hidden="hidden" /> 
               </div>
           </div>
           <script>
               var Other = document.getElementById('<%= re_other.ClientID %>');
               var txt = document.getElementById('<%= txt_other.ClientID %>');
               if (Other.checked) {
                   txt.hidden = "";
                   txt.setAttribute('required', 'required');
               }

               function ShowOther() {
                   if (Other.checked) {
                       txt.hidden = "";
                       txt.setAttribute('required','required');
                   }
                   else {
                       txt.hidden = "hidden";
                       txt.removeAttribute('required');
                   }
               }
            </script>
       </div> 
       <u><b>รายละเอียด</b></u>   
       <div class="mt-2 mb-5">
           <div class="row col-12 input-group">
               <div class="col-3 mb-3">
                   <input id="re_setup" value="Set up New Item" type="radio" name="detail" runat="server"/>&nbsp;&nbsp;Set up New Item
                </div>
               <div class="col-3 mb-3">
                   <input id="re_delete" value="Delete Order Items" type="radio" name="detail" runat="server"/>&nbsp;&nbsp;Delete Order Items  
                </div>
               <div class="col-6 mb-3">&nbsp;</div>
               <div class="col-3 mb-3">
                   <input id="re_pricedown" value="ปรับลดราคา Order Items" type="radio" name="detail" runat="server"/>&nbsp;&nbsp;ปรับลดราคา Order Items 
                </div>
               <div class="col-3 mb-3">
                   <input id="re_priceup" value="ปรับเพิ่มราคา Order Items" type="radio" name="detail" runat="server"/>&nbsp;&nbsp;ปรับเพิ่มราคา Order Items
                </div>
               <div class="col-6 mb-3">&nbsp;</div>
            </div>   
           <textarea id="txt_details" rows="10" class="form-control" placeholder="รายละเอียด" runat="server"></textarea>
       </div>
       <div class="row col-12 mt-2 mb-5">
           <div class="col-2 text-right">
               <b>Attach file :</b>
           </div>
           <div class="col-10">
               <asp:FileUpload ID="FileUpload1" AllowMultiple="true" CssClass="btn btn-outline-primary" runat="server" />
               <asp:Label ID="lbl_fileAlert" Text="" runat="server"></asp:Label>
           </div>
        </div>
    </div>

    <div class="col-12 mx-auto text-center my-5">
        <div id="div_submit" class="mx-auto ">
            <button type="button" class="btn btn-primary" id="btnsubmit" runat="server" onmouseover="CheckSubmit()" onserverclick="btnsubmit_ServerClick">Submit</button>
        </div> 
    </div>

    <script>
        function CheckSubmit() {
            var bj = document.getElementsByName('objective');
            if (Other.checked) {
                if (txt.value == '') {
                    alert('กรุณากรอกข้อมูลให้ครบถ้วน !!');
                }
            }
        }
    </script>
   
</form>
</asp:Content>
