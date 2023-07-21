<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="RequestComputerSystem.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">

  <script>
      //alert('กำลังทำการปรับปรุง ขออภัยในความไม่สะดวก !!');
      //window.location.href = 'Default';
  </script>

  <!-- Page Wrapper -->
  <div id="wrapper" hidden="hidden">

    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">

      <!-- Main Content -->
      <div id="content">

        <!-- Begin Page Content -->
        <div class="container-fluid">

          <!-- Content Row -->
          <div class="row">

            <div class="input-group mb-3">
                <div class="col-3">
                    <input id="datepicker1" onchange="fn_date1change()" onclick="" width="276" />
                    <script>
                        $('#datepicker1').datepicker({
                            uiLibrary: 'bootstrap4'
                        });
                     </script>
                </div>
                <div class="col-1">
                    ถึง
                </div>
                <div class="col-3">
                    <input id="datepicker2" onchange="fn_date2change()" width="276" />
                    <script>
                        $('#datepicker2').datepicker({
                            uiLibrary: 'bootstrap4'
                        });
                     </script>
                </div>
                <div class="col-3">
                    <div hidden="hidden">
                        <input type="text" id="txt_D1" runat="server" />
                        <input type="text" id="txt_D2" runat="server" />
                    </div>
                    <asp:Button ID="bt_search" CssClass="btn btn-primary" Text="Search" OnClick="bt_search_Click" runat="server" />
                </div>
            </div>

            <!-- Pending Requests Card Example -->
            <div class="col-xl-6 mb-5">
              <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 font-weight-bold text-primary text-uppercase mb-1">ผู้ร้องขอใช้งาน ระบบคอมพิวเตอร์</div>
                      <div class="mb-0 font-weight-bold text-gray-800">
                          ทั้งหมด : <asp:Label ID="lblNewUserAll" runat="server" Text="0"></asp:Label> คน <br />
                          ในเดือนนี้ : <asp:Label ID="lblNewUserM" runat="server" Text="0"></asp:Label> คน
                      </div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-user fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-3 mb-5">
              <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 font-weight-bold text-primary text-uppercase mb-1">B-connect</div>
                      <div class="mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="lblBconnect" runat="server" Text="0"></asp:Label> คน
                      </div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-bold fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-3 mb-5">
              <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 font-weight-bold text-primary text-uppercase mb-1">E-mail</div>
                      <div class="mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="lblEmail" runat="server" Text="0"></asp:Label> คน
                      </div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-envelope fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Pending Requests Card Example -->
            <div class="col-xl-6 mb-5">
              <div class="card border-left-danger shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 font-weight-bold text-primary text-uppercase mb-1">ยกเลิกการร้องขอใช้งาน ระบบคอมพิวเตอร์</div>
                      <div class="mb-0 font-weight-bold text-gray-800">
                          ทั้งหมด : <asp:Label ID="lblCancelAll" runat="server" Text="0"></asp:Label> คน <br />
                          ในเดือนนี้ : <asp:Label ID="lblCancelM" runat="server" Text="0"></asp:Label> คน
                      </div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-user fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-3 mb-5">
              <div class="card border-left-danger shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 font-weight-bold text-primary text-uppercase mb-1">B-connect</div>
                      <div class="mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="lblCBconnect" runat="server" Text="0"></asp:Label> คน
                      </div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-bold fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-3 mb-5">
              <div class="card border-left-danger shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 font-weight-bold text-primary text-uppercase mb-1">E-mail</div>
                      <div class="mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="lblCEmail" runat="server" Text="0"></asp:Label> คน
                      </div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-envelope fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

          </div>

        </div>
        <!-- /.container-fluid -->

      </div>
      <!-- End of Main Content -->

    </div>
    <!-- End of Content Wrapper -->

  </div>
  <!-- End of Page Wrapper -->

    <!-- CANVAS CHART Start -->
    <div class="row col-12 mx-auto">
        <div class="row col-12 mx-auto my-auto">
            <div class="col-2 card card-title bg-dark text-center h1" style="color: white;">
                Data Date
            </div>
            <div class="col-6 card card-title bg-dark text-center h1" style="color: white;">
                <asp:Label ID="lbl_DataDate" Text="" runat="server"></asp:Label>
            </div>
            <div class="col-4 card card-title bg-dark text-center h1" style="color: white;">
                <asp:Label ID="lbl_total" Text="" runat="server"></asp:Label>
            </div>
        </div>
        <!-- Status -->
        <div class="col col-lg-4 col-sm-12 mx-auto my-3">
            <div class="card card-title bg-info text-center h3" style="color: white;">
                Status
            </div>
            <div class="card card-title text-center h3" style="color: white;">
                <asp:DropDownList ID="dd_status" CssClass="form-control" OnSelectedIndexChanged="dd_status_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    <asp:ListItem Text="ALL" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Cancel" Value="Cancel"></asp:ListItem>
                    <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>
                    <asp:ListItem Text="Wait" Value="Wait"></asp:ListItem>
                    <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                    <asp:ListItem Text="Acknowledge" Value="Acknowledge"></asp:ListItem>
                    <asp:ListItem Text="Finish" Value="Finish"></asp:ListItem>
                    <asp:ListItem Text="CloseJob" Value="CloseJob"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="card card-body bg-transparent">
                <canvas id="cv_status" height="300"></canvas>
                <div hidden="hidden">
                    <input type="text" id="txt_status" value="" runat="server" />
                    <input type="text" id="txt_status_value" value="" runat="server" />
                </div>
            </div>
        </div>

        <!-- Systems -->
        <div class="col col-lg-8 col-sm-12 mx-auto my-3">
            <div class="card card-title bg-info text-center h3" style="color: white;">
                Systems
            </div>
            <div class="card card-title text-center h3" style="color: white;">
                <asp:DropDownList ID="dd_systems" CssClass="form-control" OnSelectedIndexChanged="dd_systems_SelectedIndexChanged" AutoPostBack="true" runat="server">
                </asp:DropDownList>
            </div>
            <div class="card card-body bg-transparent">
                <canvas id="cv_System" height="300"></canvas>
                <div hidden="hidden">
                    <input type="text" id="txt_System" value="" runat="server" />
                    <input type="text" id="txt_System_value" value="" runat="server" />
                </div>
            </div>
        </div>

        <!-- QTY by Date -->
        <div class="col col-12 mx-auto my-3">
            <div class="card card-title bg-info text-center h3" style="color: white;">
                QTY by Date
            </div>
            <div class="card card-title text-center h3">
                <div class="row col-12 mx-auto">
                    <div class="col-5 mx-auto">
                        <input type="date" id="date_start" value="2022-06-01" runat="server" />
                    </div>
                    <div class="col-5 mx-auto">
                        <input type="date" id="date_end" value="2022-06-08" runat="server" />
                    </div>
                    <div class="col-2 mx-auto text-center">
                        <a id="btn_filter" class="btn btn-outline-primary" onserverclick="btn_filter_ServerClick" runat="server" style="cursor: pointer;">Filter</a>
                    </div>
                </div>
            </div>
            <div class="card card-body bg-transparent">
                <canvas id="cv_QtyDate" height="300"></canvas>
                <div hidden="hidden">
                    <input type="text" id="txt_QtyDate" value="" runat="server" />
                    <input type="text" id="txt_QtyDate_Value" value="" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <!-- CANVAS CHART End -->

</form>

<script>
    function fn_date1change() {
        var d1 = document.getElementById("datepicker1");
        var t1 = document.getElementById("<%= txt_D1.ClientID %>");

        t1.value = d1.value;
    }
    function fn_date2change() {
        var d2 = document.getElementById("datepicker2");
        var t2 = document.getElementById("<%= txt_D2.ClientID %>");

        t2.value = d2.value;
    }

    //------------------------------------------------------------------------- 

    function ChartColor(x) { // x = Intensity
        var Red = 'rgba(255, 99, 132, ' + x + ')';
        var Blue = 'rgba(54, 162, 235, ' + x + ')';
        var Yellow = 'rgba(255, 206, 86, ' + x + ')';
        var Orange = 'rgba(255, 159, 64, ' + x + ')';
        var Purple = 'rgba(153, 102, 255, ' + x + '';
        var Green = 'rgba(75, 192, 192, ' + x + ')';
        var Pink = 'rgba(255, 20, 147, ' + x + ')';

        var rs = [Red, Purple, Yellow, Orange, Blue, Green, Pink];
        return rs;
    }
    function IndexColor(index,x) {
        var arColor = ChartColor(x);
        return arColor[index];
    }
    function ChartPoint(Qtydate, Colorindex) {
        var rs = [];
        for (i = 1; i <= Qtydate; i++) {
            rs.push(ChartColor(2)[Colorindex]);
        }
        return rs;
    }

    GenerateChart();

    //-------------------------------------------------------------------------  
    function canvasStatus() {
        var ctx_status = document.getElementById('cv_status').getContext('2d');
        var statusLabel = document.getElementById('<%= txt_status.ClientID %>').value.split(',');
        var statusData = document.getElementById('<%= txt_status_value.ClientID %>').value.split(',');
        var cv_status = new Chart(ctx_status, {
            type: 'doughnut',
            data: {
                labels: statusLabel,
                datasets: [{
                    data: statusData,
                    backgroundColor: ChartColor(3),
                    borderColor: ChartColor(1),
                    borderWidth: 3
                }]
            },
            options: {
                legend: {
                    position: 'left',
                    align: 'start'
                }
            }
        });
    }

    //------------------------------------------------------------------------- 
    function canvasSystems() {
        var ctxSystem = document.getElementById('cv_System').getContext('2d');
        var systemLabel = document.getElementById('<%= txt_System.ClientID %>').value.split(',');
        var systemData = document.getElementById('<%= txt_System_value.ClientID %>').value.split(',');
        var cv_System = new Chart(ctxSystem, {
            type: 'bar',
            data: {
                labels: systemLabel,
                datasets: [{
                    label: '# of Votes',
                    data: systemData,
                    backgroundColor: ChartColor(0.5),
                    borderColor: ChartColor(1),
                    borderWidth: 3
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                legend: {
                    display: false
                }
            }
        });
    }

    //------------------------------------------------------------------------- 
    function canvasQtyDate() {
        var ctxQtyDate = document.getElementById('cv_QtyDate').getContext('2d');
        var qtydateLabel = document.getElementById('<%= txt_QtyDate.ClientID %>').value.split(',');
        var qtydateData = document.getElementById('<%= txt_QtyDate_Value.ClientID %>').value.split(',');
        var cv_QtyDate = new Chart(ctxQtyDate, {
            type: 'line',
            data: {
                labels: qtydateLabel,
                datasets: [{
                    label: '# of Votes',
                    data: qtydateData,
                    backgroundColor: IndexColor(4, 0.5),
                    borderColor: IndexColor(4, 1),
                    borderWidth: 3
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                legend: {
                    display: false
                }
            }
        });
    }

    //------------------------------------------------------------------------- 

    function GenerateChart() {
        canvasStatus();
        canvasSystems();
        canvasQtyDate();
    }

</script>

</asp:Content>
