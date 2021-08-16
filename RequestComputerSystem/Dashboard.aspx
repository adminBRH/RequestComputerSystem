<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="RequestComputerSystem.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">

  <!-- Page Wrapper -->
  <div id="wrapper">

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
</script>

</asp:Content>
