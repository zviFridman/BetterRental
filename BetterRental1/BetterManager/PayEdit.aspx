<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="PayEdit.aspx.cs" Inherits="BetterRental1.BetterManager.PayEdit" %>
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
    color: inherit; /* ודא שהצבע מתאים */
}

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="text-center mb-4">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue" Visible="false" CssClass="successMessage" />
        <h3 class="address-title mb-2">הוספה / עריכת תשלום</h3>
    </div>

    <div class="row">
        <!-- Hidden Pay ID -->
        <div class="col-12">
            <asp:HiddenField ID="HiddenPayId" runat="server" />
        </div>

        <!-- Payment ID -->
        <div class="col-12 col-md-6 mb-3">
            <label for="txtPayId">מזהה תשלום</label>
            <asp:TextBox ID="txtPayId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <!-- Payment Date -->
        <div class="col-12 col-md-6 mb-3">
            <label for="txtPayDate">תאריך תשלום</label>
            <asp:TextBox ID="txtPayDate" runat="server" CssClass="form-control" type="date"></asp:TextBox>
        </div>

        <!-- Payment Sum -->
        <div class="col-12 col-md-6 mb-3">
            <label for="txtPaySum">סכום תשלום</label>
            <asp:TextBox ID="txtPaySum" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>

        <!-- Payment Type ID -->
        <div class="col-12 col-md-6 mb-3">
            <label for="txtPtid">סוג תשלום</label>
            <asp:TextBox ID="txtPtid" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>

        <!-- Customer ID -->
        <div class="col-12 col-md-6 mb-3">
            <label for="txtCaid">מזהה לקוח</label>
            <asp:TextBox ID="txtCaid" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>

        <!-- Status -->
        <div class="col-12 col-md-6 mb-3">
            <label for="ddlStatus">סטטוס</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                <asp:ListItem Text="פעיל" Value="true" />
                <asp:ListItem Text="לא פעיל" Value="false" />
            </asp:DropDownList>
        </div>

        <!-- Order ID -->
        <div class="col-12 col-md-6 mb-3">
            <label for="txtOid">מזהה הזמנה</label>
            <asp:TextBox ID="txtOid" runat="server" CssClass="form-control" type="number"></asp:TextBox>
        </div>

        <!-- Add Date -->
      <%--  <div class="col-12 col-md-6 mb-3">
            <label for="txtAddDate">תאריך הוספה</label>
            <asp:TextBox ID="txtAddDate" runat="server" CssClass="form-control"></asp:TextBox>
        </div>--%>

        <!-- Remarks -->
        <div class="col-12 mb-3">
            <label for="txtRemarks">הערות</label>
            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>

        <!-- Company Code -->
       <%-- <div class="col-12 col-md-6 mb-3">
            <label for="txtCompanyCode">קוד חברה</label>
            <asp:TextBox ID="txtCompanyCode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>--%>
    </div>

    <!-- Save Button -->
    <asp:Button ID="btnSave" runat="server" Text="שמור שינויים" CssClass="btn btn-primary" OnClick="SavePay" />
</asp:Content>