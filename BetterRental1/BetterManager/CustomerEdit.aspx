<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="BetterRental1.BetterManager.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    color: inherit; 
}

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="text-center mb-4">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue" Visible="false" CssClass="successMessage" />
        <h3 class="address-title mb-2">הוספה / עריכת לקוח</h3>
    </div>

    <div class="row">
        <!-- Hidden Customer ID -->
        <div class="col-12">
            <asp:HiddenField ID="HiddenCustomerId" runat="server" />
        </div>

        <!-- Customer Code -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtCustomerCode">קוד לקוח</label>
                <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <!-- Full Name -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtFullName">שם הלקוח</label>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            </div>
        </div>

        <!-- Email -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtEmail">אימייל</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email"></asp:TextBox>
            </div>
        </div>

        <!-- Phone -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtPhone">טלפון</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" type="tel" required="required"></asp:TextBox>
            </div>
        </div>

        <!-- Address -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtAddress">כתובת</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <!-- Customer Type -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="ddlCustomerType">סוג לקוח</label>
                <asp:DropDownList ID="ddlCustomerType" runat="server" CssClass="form-control">
                    <asp:ListItem Text="פרטי" Value="false" />
                    <asp:ListItem Text="עסקי" Value="true" />
                </asp:DropDownList>
            </div>
        </div>

        <!-- Balance -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtBalance">יתרה כספית</label>
                <asp:TextBox ID="txtBalance" runat="server" CssClass="form-control" type="number"></asp:TextBox>
            </div>
        </div>

        <!-- Ltd -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtLtd">ח.פ</label>
                <asp:TextBox ID="txtLtd" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <!-- Gid -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtGid">סוג לקוח</label>
                <asp:TextBox ID="txtGid" runat="server" CssClass="form-control" type="number"></asp:TextBox>
            </div>
        </div>

        <!-- Pay Name -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtPayName">שם לחיוב</label>
                <asp:TextBox ID="txtPayName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <!-- Pay Phone -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtPayPhone">טלפון לחיוב</label>
                <asp:TextBox ID="txtPayPhone" runat="server" CssClass="form-control" type="tel"></asp:TextBox>
            </div>
        </div>

        <!-- Oblogo -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtOblogo">חוב נותר</label>
                <asp:TextBox ID="txtOblogo" runat="server" CssClass="form-control" type="number"></asp:TextBox>
            </div>
        </div>

        <!-- Status -->
        <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="ddlStatus">סטטוס</label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Text="פעיל" Value="true" />
                    <asp:ListItem Text="לא פעיל" Value="false" />
                </asp:DropDownList>
            </div>
        </div>

        <!-- Add Date -->
      <%--  <div class="col-12 col-md-6 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtAddDate">תאריך הוספה</label>
                <asp:TextBox ID="txtAddDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>--%>

        <!-- Remarks -->
        <div class="col-12 mb-3">
            <div class="form-group">
                <label class="form-label" for="txtRemarks">הערות</label>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
        </div>
    </div>

    <!-- Save Button -->
    <asp:Button ID="btnSave" runat="server" Text="שמור שינויים" CssClass="btn btn-primary me-2" OnClick="SaveCustomer" />
</asp:Content>
