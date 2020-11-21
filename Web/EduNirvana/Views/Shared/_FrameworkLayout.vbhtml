@imports risersoft.shared.web.Extensions
@imports risersoft.shared.web
@imports risersoft.shared.portable
@imports risersoft.shared.cloud.common
@Imports risersoft.shared
@Imports risersoft.shared.cloud
@imports risersoft.shared.agent
@imports risersoft.shared.agent.auth

@Code
    Dim _user = AuthUtils.GetRSUser(Me.User)

    Dim mobile = myUtils.cValTN(Request.QueryString("mobile"))
    Dim ctx = CType(ViewContext.Controller, IHostedController).myWebController
End Code
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewData("Title")</title>
    @Html.RenderJsCss(False, "modernizr", "jquery", "bootstrap", "angular", "ig", "rs")
    @RenderSection("scripts", required:=False)
    @Html.RenderScripts(True, True)
    <style>
        div.spinnerTarget.backdrop {
            width: 100%;
            min-height: 1500px;
            position: absolute;
            background-color: #f7f7f7;
            opacity: 0.8;
            z-index: 99999;
        }
    </style>
</head>
<body ng-app="rsApp">
    <div class="spinnerTarget" us-spinner="{top:'30%', radius:30, width:8, length: 16}" spinner-key="spinner-1" spinner-theme="smallBlue"></div>

    @If mobile > 0 Then
        'add header suitable for mobile view
    Else
        @If Not _user Is Nothing Then
            @<div Class="top-header-navigation" style="height: 27px;">
                <div class="container">
                    @*<div class="btn-group margin-rgt10"><a href="/index" class="link-underline"><h2 class="uni-logo" style="margin-top: 0px;"><img src="~/Content/images/Nirvana.png" class="ninja-logo" />EdNirvana</h2></a></div>*@
                    <div class="btn-group margin-rgt10 navbar navbar-expand-md" style="float:right;margin-right: 22px;">
                        <a class="fa fa-user active" data-toggle="dropdown" style="text-decoration:none;margin-top:5px" href="#" aria-expanded="false">
                            <span class="caret"></span>
                        </a>
                        <ul class="dropdown-menu dropdown-men" style="left:-115px;">
                            <li> <a class="dropdown-item" href="/account/change">Manage</a></li>
                            <li> <a class="dropdown-item" href="/account/Logout">Logout</a></li>
                        </ul>
                    </div>

                    <div class="btn-group margin-rgt10 navbar navbar-expand-md" style="float:right;margin-right: 22px;">
                        <a class="" style="text-decoration:none" href="#" aria-expanded="false">
                            Welcome @_user.FullName
                        </a>
                    </div>
                </div>

            </div>
        Else
            @<ul Class="header-item">
                <li>
                    <a href="/Account/Login">Login</a>
                </li>
                <li>
                    <a href="Account/signup">Signup</a>
                </li>
            </ul>
        End If
        @Html.Menu(ctx)

    End If

    <div class="clsmargn">
        @RenderBody()

        <div id="dialogFilter" title="Filter">
        </div>
        <footer class="fcls">
            <p>&copy; @DateTime.Now.Year - @ctx.Controller.CalcPublisher</p>
        </footer>
    </div>
    <ul id="id_context2" style="display: none;">
        <li data-command="action1">Fetching Data ...</li>
    </ul>
    @RenderSection("BotScripts", required:=False)

    <script type="text/javascript">
        $(document).ready(function () {

            $('.navbar-nav').removeClass('nav');
            $(window).bind('scroll', function () {
                if ($(window).scrollTop() > 31) {

                    $('.navbar-fixed-top').addClass('navbar-fixed-top-change');
                    $('.top-line-move').addClass('fixed');
                }
                else {

                    $('.navbar-fixed-top').removeClass('navbar-fixed-top-change');
                    $('.top-line-move').removeClass('fixed');
                }
            });
            $(window).bind('scroll', function () {
                if ($(window).scrollTop() > 50) {

                    $('.navbar-fixed-top').addClass('navbar-fixed-top-change');
                    $('.top-line-move').addClass('fixed');
                }
                else {

                    $('.navbar-fixed-top').removeClass('navbar-fixed-top-change');
                    $('.top-line-move').removeClass('fixed');
                }
            });

        });
        function tablehtml(table) {

            var thtml = "<tr>";
            for (var k in table[0]) {
                thtml += "<th>" + k + "</th>";
            }
            thtml += "</tr>";
            $.each(table, function (index, value) {
                var TableRow = "<tr>";
                $.each(value, function (key, val) {
                    TableRow += "<td>" + val + "</td>";
                });
                TableRow += "</tr>";
                thtml += TableRow;;
            });
            return thtml;
        }

    </script>
</body>
</html>
