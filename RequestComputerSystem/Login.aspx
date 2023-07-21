<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RequestComputerSystem.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Login to BRH Systems request.</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->

	<style>
		.modal-xl {
            max-width: 80%;
        }
		.modal-md {
            max-width: 50%;
        }
	</style>

	<script src="../js/ajax/jquery-2.1.3.min.js"></script>
    <script>
        function alertModal(modalID) {
            $(window).load(function () {
                $(modalID).modal('show');
            });
        }
    </script>

<script>
	var is_chrome = navigator.userAgent.toLowerCase().indexOf('chrome') > -1;
	var is_safari = navigator.userAgent.toLowerCase().indexOf('safari') > -1;
	if (is_chrome == false) {
		if (is_safari == false) {
			alertModal('#ModalGoogleChrome');
			setTimeout(function () { location.reload(); }, 10000);
		}
	}
</script>

</head>
<body>

<!-- Modal -->
<div class="modal fade" id="ModalGoogleChrome" tabindex="-1" role="dialog" aria-labelledby="ModalGoogleChromeLabel" aria-hidden="true">
  <div class="modal-dialog modal-md" role="document">
    <div class="modal-content">
      <div class="modal-header" style="color:orange">
        <h1 class="modal-title" id="ModalGoogleChromeLabel">Warning !!</h1>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body h5 text-center">
		  <div class="row col-12 mx-auto">
			  <div class="col-6 mx-auto my-auto text-right">
				  กรุณาเปิดระบบนี้บน<br />"Google Chrome"
			  </div>
			  <div class="col-6 mx-auto my-auto text-left">
				  <img src="image/icons/google-chrome.png" style="width: 50%" />
			  </div>
			  <div class="col-12"><hr class="col-10" /></div>
			  <div class="col-12 mx-auto text-center">
				  Coply this Link to Google chrome
			  </div>
			  <div class="col-12"><hr class="col-10" /></div>
			  <div class="col-12 mx-auto text-center">
				  <span style="color:blue;"><script>document.write(window.location.href);</script></span>
			  </div>
		  </div>
      </div>
    </div>
  </div>
</div>
	
	<div class="limiter">
		<div class="container-login100" style="background-image: url('image/slide/img1.jpg');">
			<div class="wrap-login100 p-t-30 p-b-50">
				<span class="login100-form-title p-b-41">
					Account Login
				</span>
				<form id="form1" class="login100-form validate-form p-b-33 p-t-5" method="post">

					<div class="wrap-input100 validate-input" data-validate = "Enter username">
						<input id="InUser" class="input100" type="text" name="username" placeholder="User name" runat="server">
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password">
						<input id="InPass" class="input100" type="password" name="pass" placeholder="Password" runat="server">
						<span class="focus-input100" data-placeholder="&#xe80f;"></span>
					</div>

                    <div class="input-group">
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cb_remember" value="remember" runat="server" onclick="Fn_remember()" />
                        <label id="lbl_remember" for="cb_remember">Remember me</label>
                        <input type="text" id="txt_remember" runat="server" hidden/>
                    </div>

					<div class="container-login100-form-btn m-t-32">
						<button type="submit" id="submit1" class="login100-form-btn" runat="server">
							Login
						</button>
					</div>
                    <script>
                        $(function () {
                            $('[data-toggle="tooltip"]').tooltip()
                        })
                    </script>
				</form>
			</div>
		</div>
	</div>
	
<!--===============================================================================================-->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>

    <script>
        function Fn_remember() {
            // Get the checkbox
            var cb_re = document.getElementById("cb_remember");
            // Get the output text
            var txt_re = document.getElementById("txt_remember");

            // If the checkbox is checked, display the output text
            if (cb_re.checked == true) {
                txt_re.value = "remember";
            } else {
                txt_re.value = "";
            }
        }
    </script>

</body>
</html>