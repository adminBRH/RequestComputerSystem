<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CostCancel.aspx.cs" Inherits="RequestComputerSystem.Disbursement.CostCancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        input[type=radio] {
            border: 0px;
            width: 2em;
            height: 2em;
        }
    </style>
     <div class="col-12 mx-auto" id="mainpage" runat="server">
        <div class="card">  
            <div class ="card-body">                           
                <div class="col-12" style="background-color:white">
                    <div class="" style="background-color:white">                     
                     <br />
                        <table width="100%" id="printableArea" runat="server" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo" style="width: 21cm; height: 29.7cm; margin-left: auto; margin-right: auto;" border="0 ">                        
                                          
                                             <tr>                                            
                                                <td>                
                                                    <div class="text-center"><img src="img/LOGO-BRH.png" width="180px"/></div>                                                    
                                                </td> 
                                               <td>                     
                                                     <div class="text-center"><h5>แบบบันทึกขออนุมัติยกเลิกค่าแพทย์</h5></div>
                                                </td>     
                                            </tr>
                    
                                            <tr> 
                                                <td colspan="2">
                                                    <div class="col-12 mx-auto" style="border:1px; ">
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td class="text-left ">
                                                                  เรียน ผู้อำนวยการโรงพยาบาล <br />
                                                                  เรื่อง ขออนุมัติยกเลิกค่าแพทย์ เนื่องจาก
                                                                </td>  
                                                                <td class="text-right">
                                                                   
                                                                    &nbsp;&nbsp;<label ID="lbl_date_th">วันที่</label>...<asp:Label id="lbl_date" ForeColor="Black" Text="......................................." runat="server"></asp:Label>...
                                                                    
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
                                                               
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_untreated" disabled runat="server" />&nbsp;<label ID="lbl_untreated_th">ไม่ได้รับการตรวจรักษา</label><asp:Label id="lbl_untreated" ForeColor="Black" Text="" runat="server"></asp:Label>
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_sumipd"  disabled runat="server" />&nbsp;<label ID="lbl_sumipd_th">คิดค่าใช้จ่ายรวมกับผู้ป่วยใน</label><asp:Label id="lbl_sumipd" ForeColor="Black" Text="" runat="server"></asp:Label>
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_notcovered" disabled runat="server"  />&nbsp;<label ID="lbl_notcovered_th">บริษัท/ประกันไม่คุ้มครอง</label><asp:Label id="lbl_notcovered" ForeColor="Black" Text="" runat="server"></asp:Label>                                                      
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_wrongcost"  disabled runat="server"  />&nbsp;<label ID="lbl_wrongcost_th">คิดค่าใช้จ่ายผิดพลาด</label><asp:Label id="lbl_wrongcost" ForeColor="Black" Text="" runat="server"></asp:Label><br />                                                               
                                                                &nbsp;&nbsp;<input type="checkbox" id="rd_other"  disabled runat="server"  />&nbsp;<label ID="lbl_other_th">ยกเลิกกรณี อื่นๆ (ระบุ) </label>...<asp:Label id="lbl_other" ForeColor="Black" Text="............................................" runat="server"></asp:Label>...                                                               
                                            
                                                                                                               
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
                                                               
                                                                &nbsp;&nbsp;<label ID="lbl_fullname_th">ชื่อ-นามสกุล ผู้ป่วย</label>...<asp:Label id="lbl_fullname" ForeColor="Black" Text="..................................................................................." runat="server"></asp:Label>...
                                                                &nbsp;&nbsp;<label ID="lbl_hn_th">H.N</label>...<asp:Label id="lbl_hn" ForeColor="Black" Text="........................................................." runat="server"></asp:Label>...<br />
                                                                &nbsp;&nbsp;<label ID="lbl_datecome_th">วันที่รับการรักษา</label>...<asp:Label id="lbl_datecome" ForeColor="Black" Text="........../........../.........." runat="server"></asp:Label>...                                                      
                                                                &nbsp;&nbsp;<label ID="lbl_todate_th">ถึง</label>...<asp:Label id="lbl_todate" ForeColor="Black" Text="........../........../.........." runat="server"></asp:Label>...                                                              
                                                                &nbsp;&nbsp;<label ID="lbl_deptid_th">รหัสแผนก</label>...<asp:Label id="lbl_deptid" ForeColor="Black" Text="........................." runat="server"></asp:Label>...<br />
                                                                &nbsp;&nbsp;<label ID="lbl_dcnumber_th">เลขที่เอกสาร</label>...<asp:Label id="lbl_dcnumber" ForeColor="Black" Text="........................." runat="server"></asp:Label>... 
                                                                &nbsp;&nbsp;<label ID="lbl_wrongcancel_th">จำนวนค่าแพทย์ที่ยกเลิก</label>...<asp:Label id="lbl_wrongcancel" ForeColor="Black" Text="" runat="server"></asp:Label>... บาท 
                                                                &nbsp;&nbsp;<label ID="lbl_doctorname_th">ชื่อแพทย์</label>...<asp:Label id="lbl_doctorname" ForeColor="Black" Text="............................" runat="server"></asp:Label>...
                                            
                                                                                                               
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
                                                                &nbsp;&nbsp;&nbsp;<label ID="lbl_dtmore_th"></label>เหตุผลพิ่มเติม <br /><asp:Label id="lbl_dtmore" ForeColor="Black" 
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
                                                            <td width="60%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="40%" class="text-center">                                                                 
                                                              <label ID="lbl_uapprove_th"></label>ลงชื่อ...<asp:Label id="lbl_uapprove" ForeColor="Black" 
                                                              Text=".................................................." runat="server"></asp:Label>...ผู้ขออนุมัติ<br />
                                                                          (...............................................................)<br />
                                                                            ตำแหน่ง...<asp:label id="lbl_position_approve" ForeColor="Black" Text="..........................................." runat="server"></asp:label>...
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
                                                                <td colspan="3" class="text-center">พิจารณาตรวจสอบและเห็นชอบโดย
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                             <td class="text-center">
                                                                 <div class="mt-2"> 
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_hod_th"></label>ลงชื่อ..<asp:Label id="lbl_hod" ForeColor="Black" 
                                                                      Text="..............................................." runat="server"></asp:Label>..<br />
                                                             &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                                 &nbsp;&nbsp;&nbsp;หัวหน้าแผนก<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_app_hod" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>  </div>                                                                                                          
                                                             </td>
                                                                
                                                             <td class="text-center"> 
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_manager_th"></label>ลงชื่อ..<asp:Label id="lbl_manager" ForeColor="Black" 
                                                                      Text="................................................" runat="server"></asp:Label>..<br />
                                                                   &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                            
                                                                 &nbsp;&nbsp;&nbsp;ผู้จัดการฝ่าย<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_deptdirector" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>  </div>                                                                                                             
                                                             </td> 
                    
                                                             <td class="text-center">    
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_mao_th"></label>ลงชื่อ..<asp:Label id="lbl_mao" ForeColor="Black" 
                                                                      Text="................................................" runat="server"></asp:Label>..<br />
                                                                                  &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                             
                                                                 &nbsp;&nbsp;&nbsp;MAO<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_mao" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label> 
                                                                     </div>
                                                             </td> 
                                                            
                                                            </tr>

                                                            <tr>
                                                                <td class="text-center">อนุมัติโดย
                                                                    &nbsp;</td>
                                                                <td  class="text-center">รับทราบโดย
                                                                    &nbsp;</td>
                                                                <td class="text-center">ดำเนินการโดย
                                                                    &nbsp;</td>
                                                            </tr>

                                                            <tr>
                                                             <td class="text-center">
                                                                 <div class="mt-2"> 
                                                                     <input type="checkbox" id="ch_confirm" value="" />&nbsp;อนุมัติ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="checkbox" id="ch_notconfirm" value="" />&nbsp;ไม่อนุมัติ<br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_director_th"></label>ลงชื่อ..<asp:Label id="lbl_director" ForeColor="Black" 
                                                                      Text=".............................................." runat="server"></asp:Label>..<br />
                                                             &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                                 &nbsp;&nbsp;&nbsp;ผู้อำนวยการโรงพยาบาล<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_director" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>
                                                                 </div>  
                                                             </td>
                                                                
                                                             <td class="text-center"> 
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_doctor_th"></label>ลงชื่อ..<asp:Label id="lbl_doctor" ForeColor="Black" 
                                                                      Text="................................................" runat="server"></asp:Label>..<br />
                                                                   &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                            
                                                                 &nbsp;&nbsp;&nbsp;แพทย์ <br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_doctor" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label>
                                                                 </div>
                                                             </td> 
                    
                                                             <td class="text-center">    
                                                                 <div class="mt-2">
                                                                     <br><br />
                                                                      &nbsp;&nbsp;&nbsp;<label ID="lbl_DF_th"></label>ลงชื่อ..<asp:Label id="lbl_DF" ForeColor="Black" 
                                                                      Text="................................................" runat="server"></asp:Label>..<br />
                                                                                  &nbsp;&nbsp;&nbsp;(..................................................)<br />
                                                             
                                                                 &nbsp;&nbsp;&nbsp;เจ้าหน้าที่ DF<br />&nbsp;&nbsp;&nbsp;วันที่<asp:label id="lbl_date_df" ForeColor="Black" Text="........./.........../..........." runat="server"></asp:label> 
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

                    <!-- print area -->
                    <div id="div_print" class="col-12 mt-5 text-center" runat="server" visible="false">
                        <button id="btn_print" class="btn btn-primary" value="" style="font-size:50px" onclick="printDiv()" >PRINT</button>
                    </div>

                    <script>
                        function printDiv() {
                            var printContents = document.getElementById("<%= printableArea.ClientID %>").innerHTML;
                            var originalContents = document.body.innerHTML;
                            document.body.innerHTML = printContents;
                            window.print();
                            document.body.innerHTML = originalContents;
                        }
                    </script>
                     <!-- !print area -->

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

                         
                          <%--<div class="form-group text-left">
                            <label id="lbl_date_md" style="font-size: 25px;">วัน เดือน ปี </label>
                            <input type="date" class="form-control" value="" id="ip_date" runat="server" />
                          </div>--%>

                          <%-- CheckBox --%>
                          <div class="form-group text-left">
                            
                            <input type="checkbox" value="1" id="ip_untreated1"  onclick="CheckIDno()" runat="server" />&nbsp;&nbsp;
                              <label id="lbl_untreated_md" style="font-size: 25px;">ไม่ได้รับการตรวจรักษา</label>
                            &nbsp;&nbsp;
                            <input type="checkbox" value="2" id="ip_sumipd1"  onclick="CheckIDno1()" runat="server" />&nbsp;&nbsp;
                              <label id="lbl_sumipd_md" style="font-size: 25px;">คิดค่าใช้จ่ายรวมกับผู้ป่วยใน</label><br />
                              
                            <input type="checkbox" value="3" id="ip_notcovered1"  onclick="CheckIDno2()" runat="server" />&nbsp;&nbsp;
                              <label id="lbl_notcovered_md" style="font-size: 25px;">บริษัท/ประกันไม่คุ้มครอง</label>&nbsp;&nbsp;
                             
                            <input type="checkbox" value="4" id="ip_wrongcost1"  onclick="CheckIDno3()" runat="server" />&nbsp;&nbsp;
                              <label id="lbl_wrongcost_md" style="font-size: 25px;">คิดค่าใช้จ่ายผิดพลาด</label>
                          </div>
                          
                          <%--End CheckBox --%>

                          <div class="form-group text-left">
                            <label id="lbl_other_md" style="font-size: 25px;">ยกเลิกกรณี อื่น ๆ</label>   
                            <input type="text" class="form-control" value="" id="ip_other" runat="server" />
                          </div>

                          
                         <%-- Checkbox Script --%>

                              <div hidden="hidden" >
                                <input type="text" id="txtH_Score" value="" runat="server" />
                                <script>
                                    function CheckIDno() {
                                        var TxtHscore = document.getElementById('<%= txtH_Score.ClientID %>')
                                        var untreated = document.getElementById('<%= ip_untreated1.ClientID %>')
                                        if (untreated.checked) {
                                            TxtHscore.value = 'yes';
                                        } else {
                                            TxtHscore.value = '';
                                        }

                                        TxtHscore.value = x;
                                    }
                                </script>
                            </div>
                          <div hidden="hidden" >
                                <input type="text" id="txtH_Score1" value="" runat="server" />
                                <script>
                                    function CheckIDno1() {
                                        var TxtHscore1 = document.getElementById('<%= txtH_Score1.ClientID %>')
                                        var sumipd = document.getElementById('<%= ip_sumipd1.ClientID %>')
                                        if (sumipd.checked) {
                                            TxtHscore1.value = 'yes';
                                        } else {
                                            TxtHscore1.value = '';
                                        }

                                        TxtHscore1.value = x;
                                    }
                                </script>
                            </div>
                          <div hidden="hidden" >
                                <input type="text" id="txtH_Score2" value="" runat="server" />
                                <script>
                                    function CheckIDno2() {
                                        var TxtHscore2 = document.getElementById('<%= txtH_Score2.ClientID %>')
                                        var notcovered = document.getElementById('<%= ip_notcovered1.ClientID %>')
                                        if (notcovered.checked) {
                                            TxtHscore2.value = 'yes';
                                        } else {
                                            TxtHscore2.value = '';
                                        }

                                        TxtHscore2.value = x;
                                    }
                                </script>
                            </div>
                          <div hidden="hidden" >
                                <input type="text" id="txtH_Score3" value="" runat="server" />
                                <script>
                                    function CheckIDno3() {
                                        var TxtHscore3 = document.getElementById('<%= txtH_Score3.ClientID %>')
                                        var wrongcost = document.getElementById('<%= ip_wrongcost1.ClientID %>')
                                        if (wrongcost.checked) {
                                            TxtHscore3.value = 'yes';
                                        } else {
                                            TxtHscore3.value = '';
                                        }

                                        TxtHscore3.value = x;
                                    }
                                </script>
                            </div>

                        <%-- Checkbox Script --%>

                          <div class="form-group text-left col-8">
                            <label id="lbl_fullname_md" style="font-size: 25px;">ชื่อ-นามสกุล ผู้ป่วย</label>
                            <input type="text" class="form-control" value="" id="ip_fullname" runat="server" />
                          </div>

                          <div class="form-group text-left col-8">
                            <label id="lbl_hn_md" style="font-size: 25px;">HN</label>
                            <input type="text" class="form-control" value="" id="ip_hn" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_datecome_md" style="font-size: 25px;">วันที่รับการรักษา</label>
                            <input type="date" class="form-control" value="" id="ip_datecome" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_todate_md" style="font-size: 25px;">ถึงวันที่</label>
                            <input type="date" class="form-control" value="" id="ip_todate" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_deptid_md" style="font-size: 25px;">รหัสแผนก</label>
                            <input type="text" class="form-control" value="" id="ip_deptid" runat="server" />
                          </div>
                          
                          <div class="form-group text-left col-5">
                            <label id="lbl_dcnumber_md" style="font-size: 25px;">เลขที่เอกสาร </label>
                            <input type="text" class="form-control" value="" id="ip_dcnumber" runat="server" />
                          </div>
                          <div class="form-group text-left col-5">
                            <label id="lbl_wrongcancel_md" style="font-size: 25px;">จำนวนค่าแพทย์ที่ยกเลิก</label>
                            <input type="number" class="form-control" value="" id="ip_wrongcancel_nb" runat="server" />
                          </div>
                          <div class="form-group text-left col-8">
                            <label id="lbl_doctorname_deposit_md" style="font-size: 25px;">ชื่อแพทย์</label>
                            <input type="text" class="form-control" value="" id="ip_doctorname" runat="server" />
                          </div>
                          

                          <div class="form-group text-left">
                            <label id="lbl_moredetail_md" style="font-size: 25px;">รายละเอียดเพิ่มเติม</label>
                            <input type="text" class="form-control" value="" id="ip_moredetail" runat="server" />
                          </div>
                          <div class="form-group text-left col-8">
                            <label id="lbl_namereq_md" style="font-size: 25px;">ลงชื่อ-ผู้ขออนุมัติ</label>
                            <input type="text" class="form-control" value="" id="ip_namereq" runat="server" />
                          </div>
                          <div class="form-group text-left col-8">
                            <label id="lbl_position_md" style="font-size: 25px;">ตำแหน่ง</label>
                            <input type="text" class="form-control" value="" id="ip_position_approve" runat="server" />
                          </div>

                      </ContentTemplate>
                  </asp:UpdatePanel>

                  <div class="modal-footer col-12 mx-auto text-center">
                      <button type="button" class="btn btn-primary text-center" style="font-size:40px" data-dismiss="modal" onmouseover="btnok()">Ok</button>

                      <script>
                          function btnok() {

                              <%--var ipDate = document.getElementById('<%= ip_date.ClientID %>')--%>

                              var ipUntreated = document.getElementById('<%= ip_untreated1.ClientID %>')
                              var ipSumipd = document.getElementById('<%= ip_sumipd1.ClientID %>')
                              var ipNotcovered = document.getElementById('<%= ip_notcovered1.ClientID %>')
                              var ipWrongcost = document.getElementById('<%= ip_wrongcost1.ClientID %>')
                              var ipOther = document.getElementById('<%= ip_other.ClientID %>')
                              var checkBox = document.getElementById('<%= txtH_Score.ClientID %>')

                              var ipFullname = document.getElementById('<%= ip_fullname.ClientID %>')
                              var ipHN = document.getElementById('<%= ip_hn.ClientID %>')
                              var ipDateCome = document.getElementById('<%= ip_datecome.ClientID %>')
                              var ipToDate = document.getElementById('<%= ip_todate.ClientID %>')
                              var ipDeptID = document.getElementById('<%= ip_deptid.ClientID %>')
                              var ipdcnumber = document.getElementById('<%= ip_dcnumber.ClientID %>')
                              var ipwrongcancel = document.getElementById('<%= ip_wrongcancel_nb.ClientID %>')
                              var ipdoctorname = document.getElementById('<%= ip_doctorname.ClientID %>')  
                              
                              var ipMoreDetail = document.getElementById('<%= ip_moredetail.ClientID %>')

                              var ipNamereq = document.getElementById('<%= ip_namereq.ClientID %>')
                              var ipposition_approve = document.getElementById('<%= ip_position_approve.ClientID %>')



                              <%--var lblDate = document.getElementById('<%= lbl_date.ClientID %>')--%>
                              <%-- check box lbl --%>
                              var lblUntreated = document.getElementById('<%= rd_untreated.ClientID%>');
                              var lblSumipd = document.getElementById('<%= rd_sumipd.ClientID%>');
                              var lblNotcovered = document.getElementById('<%= rd_notcovered.ClientID%>');
                              var lblWrongcost = document.getElementById('<%= rd_wrongcost.ClientID%>');
                            <%-- check box lbl --%>

                              var lblOther = document.getElementById('<%= lbl_other.ClientID %>')
                              var lblFullname = document.getElementById('<%= lbl_fullname.ClientID %>')
                              var lblHN = document.getElementById('<%= lbl_hn.ClientID %>')
                              var lblDateCome = document.getElementById('<%= lbl_datecome.ClientID %>')
                              var lblToDate = document.getElementById('<%= lbl_todate.ClientID %>')
                              var lblDeptID = document.getElementById('<%= lbl_deptid.ClientID %>')
                              var lbldcnumber = document.getElementById('<%= lbl_dcnumber.ClientID %>')

                              var lblwrongcancel = document.getElementById('<%= lbl_wrongcancel.ClientID %>')
                              var lbldoctorname = document.getElementById('<%= lbl_doctorname.ClientID %>')
                              var lblMoreDetail = document.getElementById('<%= lbl_dtmore.ClientID %>')
                              var lblNamereq = document.getElementById('<%= lbl_uapprove.ClientID %>')
                              var lblposition_approve = document.getElementById('<%= lbl_position_approve.ClientID %>')
                              

                              if (ipFullname.value == '' || ipHN.value == '' ) {
                                  alert('กรุณากรอกให้ครบถ้วน !!');
                              }
                              else {
                                  
                                  //lblDate.innerText = ' ' + ipDate.value;
                                  lblUntreated.innerText = ' ' + ipUntreated;
                                  lblSumipd.innerText = ' ' + ipSumipd;
                                  lblNotcovered.innerText = ' ' + ipNotcovered;
                                  lblWrongcost.innerText = ' ' + ipWrongcost;

                                  lblOther.innerText = ' ' + ipOther.value;
                                  lblFullname.innerText = ' ' + ipFullname.value;
                                  lblHN.innerText = ' ' + ipHN.value;
                                  lblDateCome.innerText = ' ' + ipDateCome.value;
                                  lblToDate.innerText = ' ' + ipToDate.value;

                                  lblDeptID.innerText = ' ' + ipDeptID.value;
                                  lbldcnumber.innerText = ' ' + ipdcnumber.value;
                                  lblwrongcancel.innerText = ' ' + ipwrongcancel.value;
                                  lbldoctorname.innerText = ' ' + ipdoctorname.value;
            
                                  lblMoreDetail.innerText = ' ' + ipMoreDetail.value;
                                  lblNamereq.innerText = ' ' + ipNamereq.value;
                                  lblposition_approve.innerText = ' ' + ipposition_approve.value;
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
