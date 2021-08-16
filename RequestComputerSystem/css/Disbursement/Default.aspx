<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequestComputerSystem.Disbursement.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="col-9 mx-auto" id="mainpage" runat="server">
        <div class="card">
            <div class ="card-body">
                <div class="text-center"><img src="img/LOGO-BRH.png" width="250px"/></div>
                <div class="card-header mt-1 text-center" style="background-color:aquamarine"><h3>เอกสารสำหรับการเบิกจ่ายสำหรับแพทย์</h3></div>
                <div class="col-12" style="background-color:aliceblue">
                    <div class="" style="background-color:white">
                      
                        <div class="ml-5 mt-2">
                        <b><u>รายการจ่าย</u></b><br />
                       <b> การเบิกค่าเดินทางแพทย์</b> <br />
                        1. ใบอนุมัติเบิก - จ่าย ค่าเดินทางแพทย์ (FM-02-ACC-015)<br />
                        2. ใบเสร็จรับเงิน ที่แพทย์เติมน้ำมัน (ถ้ามี) / ถ้าไม่มีใบเสร็จต้องแนบตารางการออกตรวจแพทย์<br />
                            <br />
                        ค่าเบี้ยประชุม / ค่าวิทยากร แพทย์<br />
                        1. ใบอนุมัติเบิก - จ่าย ค่าเดินทางแพทย์<br />
                        2. รายงานการประชุม (แพทย์เซ็นชื่อ)<br />

                        </div>
                       
                        <div class="ml-5 mt-2">
                       <b> รายการหัก</b><br />
                        ค่าเบี้ยประกันแพทย์<br />
                        1. ใบอนุมัติเบิก - จ่าย <br />
                        2. ใบเสร็จรับเงินจากทางบมจ. วิริยะประกันภัย<br />

                        เอกสารยกเลิกค่าแพทย์<br />
                        1. แบบบันทึกขออนุมัติยกเลิกค่าแพทย์ <br />
                        2. เอกสารแนบในการยกเลิกค่าแพทย์<br />

                        </div>
                        <br />                        
                    </div>   
                    <br />
                            <div class="col-12 mt-3 mx-auto text-center">
                                    <button type="button" class="btn btn-info" id="next" onserverclick="next_ServerClick"  runat="server">Next</button>
                            </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</form>
</asp:Content>
