<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="WorkersEdit.aspx.cs" Inherits="BetterRental1.BetterManager.WorkersEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainCnt" runat="server">
        <style>
        .successMessage {
            color: #007bff;
            border: 1px solid #c3e6cb;
            padding: 10px;
            border-radius: 5px;
        }
        .btn {
    visibility: visible;
    opacity: 1;
    color: inherit; /* ודא שהצבע מתאים */
         }

    </style>
    <div class="content-wrapper">
        <div class="container-xxl flex-grow-1 container-p-y">
            <h4 class="py-3 mb-4"><span class="text-muted fw-light"></span> עריכת עובד</h4>
            <div class="card">
                <div class="card-body">
                    <asp:HiddenField ID="HiddenWorkerId" runat="server" />

                    <!-- שם פרטי -->
                    <div class="mb-3">
                        <label>שם פרטי</label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- שם משפחה -->
                    <div class="mb-3">
                        <label>שם משפחה</label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- אימייל -->
                    <div class="mb-3">
                        <label>אימייל</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- טלפון -->
                    <div class="mb-3">
                        <label>טלפון</label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- כתובת -->
                    <div class="mb-3">
                        <label>כתובת</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- שכר לשעה -->
                    <div class="mb-3">
                        <label>שכר לשעה</label>
                        <asp:TextBox ID="txtSalaryHour" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- שכר לחודש -->
                    <div class="mb-3">
                        <label>שכר לחודש</label>
                        <asp:TextBox ID="txtSalaryMonth" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- תפקיד -->
                    <div class="mb-3">
                        <label>תפקיד</label>
                        <asp:TextBox ID="txtJob" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- סטטוס -->
                    <div class="mb-3">
                        <label>סטטוס</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="פעיל" Value="true"></asp:ListItem>
                            <asp:ListItem Text="לא פעיל" Value="false"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- תאריך הוספה -->
                    <div class="mb-3">
                        <label>תאריך הוספה</label>
                        <asp:TextBox ID="txtAddDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>

                    <!-- הערות -->
                    <div class="mb-3">
                        <label>הערות</label>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>

                    <!-- קוד חברה -->
                    <div class="mb-3">
                        <label>קוד חברה</label>
                        <asp:TextBox ID="txtCompanyCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="text-end">
                        <asp:Button ID="btnSave" runat="server" Text="שמור" CssClass="btn btn-primary" OnClick="SaveWorker" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
