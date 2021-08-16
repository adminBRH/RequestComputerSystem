<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorTravelExpenses.aspx.cs" Inherits="RequestComputerSystem.Disbursement.DoctorTravelExpenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="col-12 mx-auto" id="mainpage" runat="server">
        <div class="card">
   
            <div class ="card-body">             
                
                <div class="col-12" style="background-color:white">
                    <div class="" style="background-color:white">                     
                     <br />
                        <table width="100%" id="printableArea" runat="server" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo" style="width: 21cm; height: 29.7cm; margin-left: auto; margin-right: auto;" border="0">                        
                                           <tr>
                                                <td colspan="2" class="border-0">
                                                    <div class="text-left"><img src="img/LOGO-BRH.png" width="180px"/></div>
                                                </td>                           
                                            </tr>
                                            <tr>                                
                                                    <td colspan="2">
                                                        <div class="text-center">
                                                             <table width="100%" border="0">
                                                                    แบบบันทึกการขออนุมัติเบิก-จ่ายเงิน <br /> ค่าเดินทางสำหรับแพทย์ (Internal Routing Slip)
                                                             </table>
                                                        </div>
                                                    </td>                               
                                            </tr>
                    
                                            <tr> 
                                                <td colspan="2">
                                                    <div class="col-12 mx-auto" style="border:1px; border:double">
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td class="text-left">
                                                                    &nbsp;&nbsp;<label ID="lbl_to_th">เรียน</label>...<asp:Label id="lbl_to" ForeColor="Black" Text="" runat="server"></asp:Label>... &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <br /><br />
                                                                    &nbsp;&nbsp;<label ID="lbl_from_th">จาก</label>...<asp:Label id="lbl_from" ForeColor="Black" Text="" runat="server"></asp:Label>... &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                 
                                                                </td>  
                                                                <td class="text-left">
                                                                    <br />
                                                                    &nbsp;&nbsp;<label ID="lbl_date_th">วันที่</label>...<asp:Label id="lbl_date" ForeColor="Black" Text="" runat="server"></asp:Label>...
                                                                    <br /><br />
                                                                    &nbsp;&nbsp;<label ID="lbl_submitcost_th">บันทึกค่าใช้จ่ายเข้าแผนก</label>...<asp:Label id="lbl_submitcost" ForeColor="Black" Text="" runat="server"></asp:Label>...   
                                                                    <br />
                                                                    &nbsp;&nbsp;<label ID="lbl_deptcode_th">Dept.Code</label>...<asp:Label id="lbl_deptcode" ForeColor="Black" Text="" runat="server"></asp:Label>...
                                                                </td>  
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                            
                                            <tr>
                                                <td colspan="2">
                                                    <div class="col-12 mx-auto" style="border:1px; border:">
                                                        <table width="100%" border="0">
                                                           <tr>
                                                            <td class="border-0">
                                                                &nbsp;&nbsp;<label ID="lbl_name_th">เรื่อง ขออนุมัติเบิก-จ่ายเงิน ให้แก่ </label>...<asp:Label id="lbl_name" ForeColor="Black" Text=" " runat="server"></asp:Label>...
                                                                <br />                                                  
                                                            </td>
                                                            <td class="">                                   
                                                               <label ID="lbl_money_th">จำนวนเงิน</label>...<asp:Label id="lbl_money" ForeColor="Black" Text="" runat="server"></asp:Label>... บาท                                     
                                                            </td>
                                                           </tr>
                                                         </table>                                                       
                                                    </div>
                                                </td>
                                            </tr>
                                             
                                            <tr>
                                                <td colspan="2">
                                                    <div class="col-12 mx-auto" style="border:1px; border:">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;เอกสารแนบมาพร้อมนี้ประกอบด้วย :
                                                        <table width="100%" border="0">
                                                           <tr>
                                                               
                                                            <td class="">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;<input type="checkbox" id="rd_record_travel" disabled runat="server"/>&nbsp;<label ID="lbl_record_travel_th">แบบบันทึกการเบิกค่าเดินทาง จำนวน</label>...<asp:Label id="lbl_retravel" ForeColor="Black" Text="" runat="server"></asp:Label>... ฉบับ<br />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;<input type="checkbox" id="rd_bill" disabled runat="server"/>&nbsp;<label ID="lbl_bill_th">ใบเสร็จรับเงิน จำนวน</label>...<asp:Label id="lbl_bill" ForeColor="Black" Text="" runat="server"></asp:Label>... แผ่น
                                                                <br />  
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp;&nbsp;&nbsp;<input type="checkbox" id="rd_other" disabled runat="server"/>&nbsp;<label ID="lbl_other_th">อื่นๆ</label>...<asp:Label id="lbl_other" ForeColor="Black" Text=" " runat="server"></asp:Label>...
                                                                <br />
                                                            </td>
                                                                                           
                                                           </tr>
                                                         </table>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2">
                                                    <div class="col-12 mx-auto" style="border:1px; border:">
                                                        <table width="100%" border="0">
                                                           <tr>
                                                            <td class="">
                                                                &nbsp;&nbsp;&nbsp;<label ID="lbl_dtmore_th"></label>รายละเอียดเพิ่มเติม<br /><asp:Label id="lbl_dtmore" ForeColor="Black" 
                                                                    Text="" runat="server">....................................................................................................................................................................................................................................<br />
                                                                         ....................................................................................................................................................................................................................................<br />
                                                                         ....................................................................................................................................................................................................................................<br />
                                                                         ....................................................................................................................................................................................................................................<br /></asp:Label>
                                                                <br />                                                  
                                                            </td>                                                                                                                                               
                                                           </tr>
                                                         </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="2">
                                                    <div class="col-12 mx-auto" style="border:1px; border:">
                                                        <table width="100%" border="0">
                                                           <tr>
                                                            <td width="60%">&nbsp;</td>
                                                            <td width="40%" class="text-center">                                                                
                                                              &nbsp;&nbsp;&nbsp;<label ID="lbl_uapprove_th"></label>ลงชื่อ...<asp:Label id="lbl_uapprove" ForeColor="Black" 
                                                              Text=".................................................." runat="server"></asp:Label>...ผู้ขออนุมัติ<br />
                                                                          (............................................................)                                                                                                             
                                                             </td>                                                                                                                                              
                                                           </tr>
                                                         </table>
                                                    </div>  
                                                </td>
                                            </tr>
                             
                                            <tr> 
                                                <td colspan="3">
                                            
                                                        <table width="100%" border="1">
                                                            <tr>
                                                                <td colspan="3">อนุมัติโดย:
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                             <td class="text-center">
                                                                 <div class="mt-2">  
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_assmanager_th"></label><label ID="lbl_assmanager_en" hidden="hidden">Assistmanager</label><asp:Label id="lbl_assmanager" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                             &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                                 &nbsp;&nbsp;&nbsp;ผู้ช่วยผู้จัดการฝ่าย/ผู้จัดการฝ่าย<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_app_assmanager" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label> </div>                                                                                                         
                                                             </td>
                                                                
                                                             <td class="text-center"> 
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_director_department_th"></label><label ID="lbl_director_department_en" hidden="hidden">Director Department</label><asp:Label id="director_department" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                                   &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                            
                                                                 &nbsp;&nbsp;&nbsp;ผู้อำนวยการฝ่าย<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_deptdirector" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>  </div>                                                                                                             
                                                             </td> 
                    
                                                             <td class="text-center">    
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_assdirector_th"></label><label ID="lbl_assdirector_en" hidden="hidden">Assdirector</label><asp:Label id="lbl_assdirector" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                                                  &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                             
                                                                 &nbsp;&nbsp;&nbsp;ผู้ช่วยผู้อำนวยการโรงพยาบาล<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_assdirec" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>  
                                                                     </div>
                                                             </td> 
                                                            
                                                            </tr>
                                                            <tr>
                                                             <td class="text-center">
                                                                 <div class="mt-2"> 
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_deputy_director_th"></label><label ID="lbl_deputy_director_en" hidden="hidden">Deputy Director</label><asp:Label id="deputy_director" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                             &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                                 &nbsp;&nbsp;&nbsp;รองผู้อำนวยการโรงพยาบาล<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_deputy" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>
                                                                 </div>  
                                                             </td>
                                                                
                                                             <td class="text-center"> 
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_director_th"></label><label ID="lbl_director_en" hidden="hidden">Director</label><asp:Label id="lbl_director" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                                   &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                            
                                                                 &nbsp;&nbsp;&nbsp;ผู้อำนวยการโรงพยาบาล<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_director" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>
                                                                 </div>
                                                             </td> 
                    
                                                             <td class="text-center">    
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_ceo_th"></label><label ID="lbl_ceo_en" hidden="hidden">More Detail</label><asp:Label id="lbl_ceo" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                                                  &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                             
                                                                 &nbsp;&nbsp;&nbsp;ประธานคณะผู้บริหารกลุ่ม 3<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_ceo" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>
                                                                 </div>
                                                             </td> 
                                                            
                                                            </tr>
                                                        </table> 
                                                    <br />
                                                     Document ID :<asp:Label ID="lbl_document_ID" runat="server"></asp:Label> 
                                                </td>
                                            </tr>
                                                               
                                            
                                   </table>
                                <br />                        
                            </div>   
         
                         <br />
                    <div class="mx-auto text-center">
                                <div class="col-4 mx-auto btn btn-info">
                                    <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                                </div>
                             </div>
                            <div class="col-12 mt-3 mx-auto text-center">
                                    <button type="button" class="btn btn-info" id="submit" onserverclick="submit_ServerClick"  runat="server">Submit</button>
                            </div>
                    <br />
                </div>
            </div>     
        </div>
   </div>
        <br />
 <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title" id="exampleModalLabel"><label id="lbl_inputhead_th">กรอกข้อมูล</label><label id="lbl_inputhead_en" hidden="hidden">INPUT DATA</label></h1>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
           
          <asp:UpdatePanel ID="UpdatePanel_Emp" runat="server">
              <ContentTemplate>

                  <div class="form-group text-left col-8">
                    <label id="lbl_to_md" style="font-size: 25px;">เรียน</label>
                    <input type="text" class="form-control" value="" id="ip_to" required="required" runat="server" />
                  </div>
                  <div class="form-group text-left col-8">
                    <label id="lbl_from_md" style="font-size: 25px;">จาก</label>
                    <input type="text" class="form-control" value="" id="ip_from" required="required" runat="server" />
                  </div>
                 <%-- <div class="form-group text-left">
                    <label id="lbl_date_md" style="font-size: 25px;">วัน เดือน ปี </label>
                    <input type="date" class="form-control" value="" id="ip_date" runat="server" />
                  </div>--%>
                  <div class="form-group text-left ">
                    <label id="lbl_submitcost_md" style="font-size: 25px;">บันทึกค่าใช้จ่ายเข้าแผนก</label>
                    <%--<input type="text" class="form-control" value="" id="ip_submitcost" runat="server" />--%>
                  </div>
                  <div class="form-group text-left">
                    <label id="lbl_deptcode_md" style="font-size: 25px;"></label>
                      <asp:UpdatePanel ID="UpdatePanel_dept" runat="server">
                          <ContentTemplate>
                      เลือกแแผนก : 
                      <asp:DropDownList ID="ddl_dept" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged">
                                  <asp:ListItem Text="" Value="" ></asp:ListItem>
                              </asp:DropDownList>

                              <div hidden="hidden">
                                 <input type="text" id="txtH_dept" value="" runat="server" />
                             </div>
                        </ContentTemplate>
                          <Triggers>
                              <asp:AsyncPostBackTrigger ControlID="ddl_dept" EventName="selectedindexchanged" />
                          </Triggers>
                      </asp:UpdatePanel>
                    <%--<input type="text" class="form-control" value="" id="ip_deptcode" runat="server" />--%>
                  </div>
                  <div class="form-group text-left col-8">
                    <label id="lbl_apmoney_md" style="font-size: 25px;">ขออนุมัติเบิก-จ่ายเงิน ให้แก่</label>
                    <input type="text" class="form-control" value="" id="ip_apmoney" runat="server" />
                  </div>
                  <div class="form-group text-left col-5">
                    <label id="lbl_amount_md" style="font-size: 25px;">จำนวนเงิน</label>
                    <input type="number" class="form-control" value="" id="ip_amount_nb" runat="server" />
                  </div>
                  <div class="form-group text-left col-5">
                    <label id="lbl_invoice_md" style="font-size: 25px;">แบบบันทึกการเบิกค่าเดินทาง จำนวน</label>
                    <input type="number" class="form-control" value="" id="ip_travel_nb" runat="server" />
                  </div>
                  <div class="form-group text-left col-5">
                    <label id="lbl_bill_md" style="font-size: 25px;">ใบเสร็จรับเงิน จำนวน </label>
                    <input type="number" class="form-control" value="" id="ip_bill_nb" runat="server" />
                  </div>
                  
                  <div class="form-group text-left col-8">
                    <label id="lbl_other_md" style="font-size: 25px;">อื่น ๆ</label>
                    <input type="text" class="form-control" value="" id="ip_other" runat="server" />
                  </div>
                  <div class="form-group text-left col-12">
                    <label id="lbl_moredetail_md" style="font-size: 25px;">รายละเอียดเพิ่มเติม</label>
                    <input type="text" class="form-control" value="" id="ip_moredetail" runat="server" />
                  </div>
                  <div class="form-group text-left col-8">
                    <label id="lbl_namereq_md" style="font-size: 25px;">ลงชื่อ-ผู้ขออนุมัติ</label>
                    <input type="text" class="form-control" value="" id="ip_namereq" runat="server" />
                  </div>

              </ContentTemplate>
          </asp:UpdatePanel>

          <div class="modal-footer col-12 mx-auto text-center">
              <button type="button" class="btn btn-primary text-center" style="font-size:40px" data-dismiss="modal" onmouseover="btnok()">Ok</button>

              <script>
                  function btnok() {

                      var ipTo = document.getElementById('<%= ip_to.ClientID %>')
                      var ipFrom = document.getElementById('<%= ip_from.ClientID %>')
                      <%--var ipDate = document.getElementById('<%= ip_date.ClientID %>')--%>
                      var ipSubmitC = document.getElementById('<%= ddl_dept.ClientID %>')
                      var ipDeptCode = document.getElementById('<%= ddl_dept.ClientID %>')
                      var DeptName = document.getElementById('<%= txtH_dept.ClientID %>')
                      var ipAPmoney = document.getElementById('<%= ip_apmoney.ClientID %>')
                      var ipAmout = document.getElementById('<%= ip_amount_nb.ClientID %>')
                      var ipTravel = document.getElementById('<%= ip_travel_nb.ClientID %>')
                      var ipBill = document.getElementById('<%= ip_bill_nb.ClientID %>')            
                      var ipOther = document.getElementById('<%= ip_other.ClientID %>')
                      var ipMoreDetail = document.getElementById('<%= ip_moredetail.ClientID %>')
                      var ipNamereq = document.getElementById('<%= ip_namereq.ClientID %>')


                      var lblTo = document.getElementById('<%= lbl_to.ClientID %>')
                      var lblFrom = document.getElementById('<%= lbl_from.ClientID %>')
                      <%--var lblDate = document.getElementById('<%= lbl_date.ClientID %>')--%>
                      var lblSubmitC = document.getElementById('<%= lbl_submitcost.ClientID %>')
                      var lblDeptcode = document.getElementById('<%= lbl_deptcode.ClientID %>')
                      var lblApTOname = document.getElementById('<%= lbl_name.ClientID %>')
                      var lblApmoney = document.getElementById('<%= lbl_money.ClientID %>')      
                      var lbltravel = document.getElementById('<%= lbl_retravel.ClientID %>')
                      var lblBill = document.getElementById('<%= lbl_bill.ClientID %>')
                     
                      var lblOther = document.getElementById('<%= lbl_other.ClientID %>')
                      var lblMdetail = document.getElementById('<%= lbl_dtmore.ClientID %>')
                      var lblNamereq = document.getElementById('<%= lbl_uapprove.ClientID %>')

                      if (ipTo.value == '' || ipFrom.value == '' || ipSubmitC.value == '' || ipDeptCode.value == '') {
                          alert('กรุณากรอกให้ครบถ้วน !!');
                      }
                      else {
                          lblTo.innerText = ' ' + ipTo.value;
                          lblFrom.innerText = ' ' + ipFrom.value;
                          //lblDate.innerText = ' ' + ipDate.value;
                          lblSubmitC.innerText = ' ' + ipSubmitC.value;
                          lblDeptcode.innerText = ' ' + ipDeptCode.value;
                          lblApTOname.innerText = ' ' + ipAPmoney.value;
                          lblApmoney.innerText = ' ' + ipAmout.value;
                          lbltravel.innerText = ' ' + ipTravel.value;
                          lblBill.innerText = ' ' + ipBill.value;                         
                          lblOther.innerText = ' ' + ipOther.value;
                          lblMdetail.innerText = ' ' + ipMoreDetail.value;
                          lblNamereq.innerText = ' ' + ipNamereq.value;
                      }
                  }
              </script>
              </div>
          </div>
        </div>
      </div>
 </div>
</form>
</asp:Content>
