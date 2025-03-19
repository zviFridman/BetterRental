<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="OrderEdit.aspx.cs" Inherits="BetterRental1.BetterManager.OrderEdit" %>
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
    <body>
        <div class="text-center mb-4">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Blue" Visible="false" CssClass="successMessage" />
            <h3 class="address-title mb-2">הוספה / עריכת הזמנה</h3>
        </div>

        <div class="row">
            <!-- Hidden Order ID -->
            <div class="col-12">
                <asp:HiddenField ID="HiddenOrderId" runat="server" />
            </div>

            <!-- Order Date -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="txtOrderDate">תאריך הזמנה</label>
                    <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" type="date" required="required"></asp:TextBox>
                </div>
            </div>

            <!-- Customer Code -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="txtCustomerCode">קוד לקוח</label>
                    <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
            </div>

            <!-- Collection Date -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="txtCollectionDate">תאריך איסוף</label>
                    <asp:TextBox ID="txtCollectionDate" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                </div>
            </div>

            <!-- Return Date -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="txtReturnDate">תאריך החזרה</label>
                    <asp:TextBox ID="txtReturnDate" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                </div>
            </div>

            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="ddlStatusReady">סטטוס הכנה</label>
                    <asp:DropDownList ID="ddlStatusReady" runat="server" CssClass="form-select" required="required">
                        <asp:ListItem Value="0">לא מוכן</asp:ListItem>
                        <asp:ListItem Value="1">מוכן</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Order Status -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="ddlStatusOrder">סטטוס כולל</label>
                    <asp:DropDownList ID="ddlStatusOrder" runat="server" CssClass="form-select" required="required">
                        <asp:ListItem Value="0">לא פעיל</asp:ListItem>
                        <asp:ListItem Value="1">פעיל</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Payment Status -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="ddlStatusPay">סטטוס תשלום</label>
                    <asp:DropDownList ID="ddlStatusPay" runat="server" CssClass="form-select" required="required">
                        <asp:ListItem Value="0">לא שולם</asp:ListItem>
                        <asp:ListItem Value="1">שולם</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Collection Method -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="txtCollection">חלוקה/איסוף עצמי</label>
                    <asp:DropDownList ID="txtCollection" runat="server" CssClass="form-select" required="required">
                        <asp:ListItem Value="1">איסוף עצמי</asp:ListItem>
                        <asp:ListItem Value="0">חלוקה</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- Event Location -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="txtPlaceToSend">מקום האירוע</label>
                    <asp:TextBox ID="txtPlaceToSend" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <!-- Order Total Price -->
            <div class="col-12 col-md-6 mb-3">
                <div class="form-group">
                    <label class="form-label" for="txtSumOrder">מחיר הזמנה</label>
                    <asp:TextBox ID="txtSumOrder" runat="server" CssClass="form-control" type="number" min="0" step="0.01" required="required"></asp:TextBox>
                </div>
            </div>

            <!-- Remarks -->
            <div class="col-12 mb-3">
                <div class="form-group">
                    <label class="form-label" for="txtRemarks">הערות</label>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
        </div>

        <!-- Buttons -->
<asp:Button ID="btnSave" runat="server" 
    Text="שמור שינויים" 
    CssClass="btn btn-primary me-2" 
    OnClick="SaveOrder" 
    Style="visibility: visible; opacity: 1;" />
    </body>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="../assets/js/app-ecommerce-product-list.js"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server"></asp:Content>
