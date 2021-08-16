<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Repayment.aspx.cs" Inherits="RequestComputerSystem.Disbursement.Repayment" %>
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
                                                                    แบบบันทึกการขออนุมัติเบิก-จ่ายเงิน (การจ่ายคืน Deposit) <br /> Internal Routing Slip
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
                                                                    &nbsp;&nbsp;<label ID="lbl_from_th">จาก</label>...<asp:Label id="lbl_from" ForeColor="Black" Text="" runat="server"></asp:Label>...&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                 
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
                                                                &nbsp;&nbsp;<label ID="lbl_name_th">เรื่อง ขออนุมัติเบิก-จ่ายเงิน ให้แก่ </label>...<asp:Label id="lbl_name" ForeColor="Black" Text="" runat="server"></asp:Label>...
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
                                                               
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_repayment" disabled runat="server"/>&nbsp;<label ID="lbl_repayment_th">ใบแบบฟอร์มการคืนเงินผู้ป่วย จำนวน</label>.<asp:Label id="lbl_repayment" ForeColor="Black" Text="..." runat="server"></asp:Label>.ฉบับ
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_deposit" disabled runat="server"/>&nbsp;<label ID="lbl_deposit_th">ใบ Deposit จำนวน</label>.<asp:Label id="lbl_deposit" ForeColor="Black" Text="..." runat="server"></asp:Label>.ฉบับ
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_certificate" disabled runat="server"/>&nbsp;<label ID="lbl_certificate_th">ใบสูติบัตร จำนวน</label>.<asp:Label id="lbl_certificate" ForeColor="Black" Text="..." runat="server"></asp:Label>.ฉบับ    <br />                                                       
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_refund_deposit" disabled runat="server"/>&nbsp;<label ID="refund_deposit_th">ใบ Refund Deposit จำนวน</label>.<asp:Label id="lbl_refund_deposit" ForeColor="Black" Text="..." runat="server"></asp:Label>.ฉบับ                                                               
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_idcard" disabled runat="server"/>&nbsp;<label ID="lbl_idcard_th">สำเนาบัตรประชาชน จำนวน</label>.<asp:Label id="lbl_idcard" ForeColor="Black" Text="..." runat="server"></asp:Label> .ฉบับ                                                               
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_powerofattorney" disabled runat="server"/>&nbsp;<label ID="lbl_powerofattorney_th">ใบมอบอำนาจจำนวน</label>.<asp:Label id="lbl_powerofattorney" ForeColor="Black" Text="..." runat="server"></asp:Label>.ฉบับ<br />                                                                
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_other" disabled runat="server"/>&nbsp;<label ID="lbl_other_th">อื่นๆ</label>.<asp:Label id="lbl_other" ForeColor="Black" Text="..." runat="server"></asp:Label>.ฉบับ
                                                                                                               
                                                            </td>
                                                            <td class="">                                   
                                                               
                                                               
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
                                                            <td class="text-right">                                                                 
                                                              &nbsp;&nbsp;&nbsp;<label ID="lbl_uapprove_th"></label>ลงชื่อ...<asp:Label id="lbl_uapprove" ForeColor="Black" 
                                                              Text=".................................................." runat="server"></asp:Label>...ผู้ขออนุมัติ<br />
                                                                          (............................................................)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                                                                                               
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
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_hod_th"></label><asp:Label id="lbl_hod" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                             &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                                 &nbsp;&nbsp;&nbsp;HOD<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_app_hod" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>  </div>                                                                                                          
                                                             </td>
                                                                
                                                             <td class="text-center"> 
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_manager_th"></label><asp:Label id="lbl_manager" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                                   &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                            
                                                                 &nbsp;&nbsp;&nbsp;ผู้จัดการฝ่าย/ผู้ตรวจการ<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_deptdirector" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>  </div>                                                                                                             
                                                             </td> 
                    
                                                             <td class="text-center">    
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_assdirector_th"></label><asp:Label id="lbl_assdirector" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                                                  &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                             
                                                                 &nbsp;&nbsp;&nbsp;ผู้ช่วยผู้อำนวยการโรงพยาบาล<br />&nbsp;&nbsp;&nbsp;<asp:label id="lbl_date_assdirec" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label> 
                                                                     </div>
                                                             </td> 
                                                            
                                                            </tr>
                                                            <tr>
                                                             <td class="text-center">
                                                                 <div class="mt-2">  
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_deputy_director_th"></label><asp:Label id="deputy_director" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                             &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                                 &nbsp;&nbsp;&nbsp;รองผู้อำนวยการโรงพยาบาล<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_deputy" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>
                                                                 </div>  
                                                             </td>
                                                                
                                                             <td class="text-center"> 
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_vice_president_th"></label><asp:Label id="lbl_vice_president" ForeColor="Black" 
                                                                      Text=".................................................." runat="server"></asp:Label><br />
                                                                   &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                            
                                                                 &nbsp;&nbsp;&nbsp;รองประธานคณะผู้บริหาร กลุ่ม 3<br> และผู้อำนวยการโรงพยาบาล <br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_vicepre" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>
                                                                 </div>
                                                             </td> 
                    
                                                             <td class="text-center">    
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_ceo_th"></label><asp:Label id="lbl_ceo" ForeColor="Black" 
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
                          <%--<div class="form-group text-left">
                            <label id="lbl_date_md" style="font-size: 25px;">วัน เดือน ปี </label>
                            <input type="date" class="form-control" value="" id="ip_date" runat="server" />
                          </div>--%>
                          <div class="form-group text-left">
                            <label id="lbl_submitcost_md" style="font-size: 25px;">บันทึกค่าใช้จ่ายเข้าแผนก</label>
                            <%--<input type="text" class="form-control" value="" id="ip_submitcost" runat="server" />--%>
                          </div>
                 <div class="form-group text-left">
                    <label id="lbl_deptcode_md" style="font-size: 25px;"></label>
                      เลือกแแผนก : 
                      <asp:UpdatePanel ID="UpdatePanel_dept" runat="server">
                          <ContentTemplate>

                         <asp:DropDownList ID="ip_deptcode3" AutoPostBack="true" OnSelectedIndexChanged="ip_deptcode3_SelectedIndexChanged"  runat="server">
                             <asp:ListItem Text="" Value=""></asp:ListItem>  
                         </asp:DropDownList> 

                              <div hidden="hidden">
                                 <input type="text" id="txtH_dept" value="" runat="server" />
                             </div>

                            </ContentTemplate>
                          <Triggers>
                              <asp:AsyncPostBackTrigger ControlID="ip_deptcode3" EventName="selectedindexchanged" />
                          </Triggers>
                          </asp:UpdatePanel>
                    <%--<input type="text" class="form-control" value="" id="ip_deptcode" runat="server" />--%>
                  </div>
                          <%--<div class="form-group text-left">
                            <label id="lbl_deptcode_md" style="font-size: 25px;">Dept. Code</label>
                            <input type="text" class="form-control" value="" id="ip_deptcode" runat="server" />
                          </div>--%>
                          <div class="form-group text-left col-8">
                            <label id="lbl_apmoney_md" style="font-size: 25px;">ขออนุมัติเบิก-จ่ายเงิน ให้แก่</label>
                            <input type="text" class="form-control" value="" id="ip_apmoney" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_amount_md" style="font-size: 25px;">จำนวนเงิน</label>
                            <input type="text" class="form-control" value="" id="ip_amount" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_invoice_md" style="font-size: 25px;">ใบแบบฟอร์มการคืนเงินผู้ป่วย</label>
                            <input type="number" class="form-control" value="" id="ip_repayment_nb" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_deposit_md" style="font-size: 25px;">ใบ Deposit จำนวน </label>
                            <input type="number" class="form-control" value="" id="ip_deposit_nb" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_certificate_md" style="font-size: 25px;">ใบสูติบัตร จำนวน </label>
                            <input type="number" class="form-control" value="" id="ip_certificate_nb" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_refund_deposit_md" style="font-size: 25px;">ใบ Refund Deposit จำนวน </label>
                            <input type="number" class="form-control" value="" id="ip_refund_deposit_nb" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_idcard_md" style="font-size: 25px;">สำเนาบัตรประชาชน จำนวน </label>
                            <input type="number" class="form-control" value="" id="ip_idcard_nb" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_powerofattorney_md" style="font-size: 25px;">ใบมอบอำนาจ จำนวน </label>
                            <input type="number" class="form-control" value="" id="ip_powerofattorney_nb" runat="server" />
                          </div>
                  
                          <div class="form-group text-left">
                            <label id="lbl_other_md" style="font-size: 25px;">อื่น ๆ</label>
                            <input type="text" class="form-control" value="" id="ip_other" runat="server" />
                          </div>
                          <div class="form-group text-left">
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
                              var ipsubmitc = document.getElementById('<%= ip_deptcode3.ClientID %>')
                              var ipDeptCode = document.getElementById('<%= ip_deptcode3.ClientID %>')
                              var DeptName = document.getElementById('<%= txtH_dept.ClientID %>')

                              var ipAPmoney = document.getElementById('<%= ip_apmoney.ClientID %>')
                              var ipAmout = document.getElementById('<%= ip_amount.ClientID %>')

                              var iprepayment = document.getElementById('<%= ip_repayment_nb.ClientID %>')
                              var ipdeposit = document.getElementById('<%= ip_deposit_nb.ClientID %>')
                              var ipcertificate = document.getElementById('<%= ip_certificate_nb.ClientID %>')
                              var iprefund_deposit = document.getElementById('<%= ip_refund_deposit_nb.ClientID %>')
                              var ipidcard = document.getElementById('<%= ip_idcard_nb.ClientID %>')
                              var ippowerofattorney = document.getElementById('<%= ip_powerofattorney_nb.ClientID %>')                                   
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
                              
                              var lblrepayment = document.getElementById('<%= lbl_repayment.ClientID %>')      
                              var lbldeposit = document.getElementById('<%= lbl_deposit.ClientID %>')  
                              var lblcertificate = document.getElementById('<%= lbl_certificate.ClientID %>')   
                              var lblrefund_deposit = document.getElementById('<%= lbl_refund_deposit.ClientID %>')   
                              var lblidcard = document.getElementById('<%= lbl_idcard.ClientID %>')      
                              var lblpowerofattorney = document.getElementById('<%= lbl_powerofattorney.ClientID %>')      
                              var lblOther = document.getElementById('<%= lbl_other.ClientID %>')
                              
                              var lblMdetail = document.getElementById('<%= lbl_dtmore.ClientID %>')
                              var lblNamereq = document.getElementById('<%= lbl_uapprove.ClientID %>')

                              if (ipTo.value == '' || ipFrom.value == '' || ipsubmitc.value == '' || ipDeptCode.value == '') {
                                  alert('กรุณากรอกให้ครบถ้วน !!');
                              }
                              else {
                                  lblTo.innerText = ' ' + ipTo.value;
                                  lblFrom.innerText = ' ' + ipFrom.value;
                                  //lblDate.innerText = ' ' + ipDate.value;
                                  lblSubmitC.innerText = ' ' + DeptName.value;
                                  lblDeptcode.innerText = ' ' + ipDeptCode.value;
                                  lblApTOname.innerText = ' ' + ipAPmoney.value;
                                  lblApmoney.innerText = ' ' + ipAmout.value;

                                  lblrepayment.innerText = ' ' + iprepayment.value;
                                  lbldeposit.innerText = ' ' + ipdeposit.value;                         
                                  lblcertificate.innerText = ' ' + ipcertificate.value;
                                  lblrefund_deposit.innerText = ' ' + iprefund_deposit.value;
                                  lblidcard.innerText = ' ' + ipidcard.value;
                                  lblpowerofattorney.innerText = ' ' + ippowerofattorney.value;
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
