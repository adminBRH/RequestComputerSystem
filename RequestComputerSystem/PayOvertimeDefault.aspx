<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PayOvertimeDefault.aspx.cs" Inherits="RequestComputerSystem.PayOvertimeDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="col-9 mx-auto" id="mainpage" runat="server">
        <div class="card">
            <div class ="card-body">
                <div class="text-center"><img src="image/LOGO-BRH.png" width="250px"/></div>
                <div class="card-header mt-1 text-center" style="background-color:aquamarine"><h3>ใบเบิกค่าทำงานล่วงเวลา ค่าทำงานในวันหยุด ค่าจ้างตามสัญญาพิเศษ ค่าเวรและเงินพิเศษอื่น ๆ</h3></div>
                <div class="col-12" style="background-color:aliceblue">
                    <div class ="card-body mx-auto">                    
                      <div class="dropdown text-center mx-auto">                         
                                   <asp:UpdatePanel ID="UpdatePanel_dept" runat="server">
                                       <ContentTemplate>
                                           เลือกเดือนที่ต้องการเบิก : 
                                           <%--<input type="date" id="date_input" runat="server" />--%>
                                           <asp:DropDownList ID="ddl_month" runat="server">
                                                <asp:ListItem Text="มกราคม" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="กุมภาพันธ์" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="มีนาคม" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="เมษายน" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="พฤษภาคม" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="มิถุนายน" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="กรกฎาคม" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="สิงหาคม" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="กันยายน" Value="09"></asp:ListItem>
                                                <asp:ListItem Text="ตุลาคม" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="พฤศจิกายน" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="ธันวาคม" Value="12"></asp:ListItem>
                                           </asp:DropDownList>

                                           เลือกแแผนก : 
                                           <asp:DropDownList ID="dd_department" AutoPostBack="true" OnSelectedIndexChanged="dd_department_SelectedIndexChanged" runat="server">
                                               <asp:ListItem Text="" Value=""></asp:ListItem>  
                                           </asp:DropDownList>  
                                           <br /><asp:Label ID="lbl_HOD1" Text="" runat="server"></asp:Label>
                                           <br /><asp:Label ID="lbl_HOD2" Text="" runat="server"></asp:Label>
                                           <br />
                                           <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                                           <asp:Label ID="lbl_fileAlert" Text="" runat="server"></asp:Label>
                                        </ContentTemplate>
                                       <Triggers>
                                           <asp:AsyncPostBackTrigger ControlID="dd_department" EventName="selectedindexchanged" />
                                       </Triggers>                                    
                                   </asp:UpdatePanel>      
             
                            </div>                           
                        </div>                   
                    <div class="col-12 mx-auto text-center">
                        <asp:Label ID="lbl_alert" Text="" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                            <div class="col-12 mt-3 mx-auto text-center">
                                    <button type="button" class="btn btn-info" id="submit" onserverclick="submit_ServerClick"  runat="server">Submit</button>
                            </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</form>
</asp:Content>
