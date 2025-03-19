
<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="BetterRental1.BetterManager.ProductEdit" %>
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
        <!-- Favicon -->
<link rel="icon" type="image/x-icon" href="../assets/img/favicon/favicon.ico" />

<!-- Fonts -->

<link rel="preconnect" href="https://fonts.googleapis.com" />
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
<link href="https://fonts.googleapis.com/css2?family=Public+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;1,300;1,400;1,500;1,600;1,700&ampdisplay=swap"
      rel="stylesheet" />
     <!-- Icons -->
 <link rel="stylesheet" href="../assets/vendor/fonts/fontawesome.css" />
 <link rel="stylesheet" href="../assets/vendor/fonts/tabler-icons.css" />
 <link rel="stylesheet" href="../assets/vendor/fonts/flag-icons.css" />

    <!-- Page CSS -->
<!-- Helpers -->
<script src="../assets/vendor/js/helpers.js"></script>
<!--! Template customizer & Theme config files MUST be included after core stylesheets and helpers.js in the <head> section -->
<!--? Config:  Mandatory theme config file contain global vars & default theme options, Set your preferred theme option in this file.  -->
<script src="../assets/js/config.js"></script>
 <body>
           <%-- <div class="modal fade" id="update" tabindex="-1" aria-hidden="true">
 <div class="modal-dialog modal-lg modal-simple modal-add-new-address">
 <div class="modal-content p-3 p-md-5">
 <div class="modal-body">--%>
 <!-- Modal Header -->
<%-- <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>--%>
 <div class="text-center mb-4">
     <asp:Label ID="lblMessage" runat="server" 
           ForeColor="Blue" Visible="false" 
           CssClass="successMessage" />
 <h3 class="address-title mb-2">הוספה / עריכת מוצר</h3>
 </div>

 <!-- Form Content -->
 <div class="row">
 <!-- Hidden Product ID -->
 <div class="col-12">
   <asp:hiddenField ID="HiddenPid" runat="server" />
 </div>

 <!-- Product Name -->
 <div class="col-12 col-md-6 mb-3">
 <div class="form-group">
 <label class="form-label" for="txtPname">שם</label>
 <asp:TextBox ID="txtPname" runat="server" CssClass="form-control" required="required"></asp:TextBox>
 <div class="invalid-feedback">נא להזין שם מוצר</div>
 </div>
 </div>

 <!-- Product Price -->
 <div class="col-12 col-md-6 mb-3">
 <div class="form-group">
 <label class="form-label" for="textPprice">מחיר</label>
 <asp:TextBox ID="textPprice" runat="server" CssClass="form-control"
 type="number" min="0" step="0.01" required="required"></asp:TextBox>
 <div class="invalid-feedback">נא להזין מחיר תקין</div>
 </div>
 </div>

 <!-- Product Description -->
 <div class="col-12 col-md-6 mb-3">
 <div class="form-group">
 <label class="form-label" for="textPdesc">תיאור</label>
 <asp:TextBox ID="textPdesc" runat="server" CssClass="form-control"
 TextMode="MultiLine" Rows="3"></asp:TextBox>
 </div>
 </div>

 <!-- Product Inventory -->
 <div class="col-12 col-md-6 mb-3">
 <div class="form-group">
 <label class="form-label" for="textPinventory">מלאי</label>
 <asp:TextBox ID="textPinventory" runat="server" CssClass="form-control"
 type="number" min="0" required="required"></asp:TextBox>
 <div class="invalid-feedback">נא להזין כמות במלאי</div>
 </div>
 </div>

 <!-- Category ID -->
 <div class="col-12 col-md-6 mb-3">
 <div class="form-group">
 <label class="form-label" for="textCid">קוד קטגוריה</label>
 <asp:TextBox ID="textCid" runat="server" CssClass="form-control"
 type="number" min="1" required="required"></asp:TextBox>
 <div class="invalid-feedback">נא להזין קוד קטגוריה תקין</div>
 </div>
 </div>

 <!-- Status -->
 <div class="col-12 col-md-6 mb-3">
 <div class="form-group">
 <label class="form-label" for="textStatus">סטטוס</label>
 <asp:DropDownList ID="textStatus" runat="server" CssClass="form-select" required="required">
 <asp:ListItem Value="">בחר סטטוס</asp:ListItem>
 <asp:ListItem Value="1">פעיל</asp:ListItem>
 <asp:ListItem Value="0">לא פעיל</asp:ListItem>
 </asp:DropDownList>
 <div class="invalid-feedback">נא לבחור סטטוס</div>
 </div>
 </div>

 <!-- Remarks -->
 <div class="col-12 mb-3">
 <div class="form-group">
 <label class="form-label" for="textRemarks">הערות</label>
 <asp:TextBox ID="textRemarks" runat="server" CssClass="form-control"
 TextMode="MultiLine" Rows="2"></asp:TextBox>
 </div>
 </div>

      </div>

 <!-- Buttons -->


<asp:Button ID="btnSave" runat="server" Text="שמור שינויים"
     CssClass="btn btn-primary me-2" OnClick="SaveProduct"/>
 <%--<button type="button" class="btn btn-label-secondary"
 data-bs-dismiss="modal">ביטול</button>--%>

    </body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
                <script src="../assets/js/app-ecommerce-product-list.js"></script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
</asp:Content>
