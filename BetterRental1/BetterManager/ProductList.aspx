<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="BetterRental1.BetterManager.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
      <!-- Content wrapper -->
  <div class="content-wrapper">
    <!-- Content -->

    <div class="container-xxl flex-grow-1 container-p-y">
      <h4 class="py-3 mb-4"><span class="text-muted fw-light">eCommerce /</span> רשימת מוצרים</h4>

      <!-- Product List Widget -->

      <div class="card mb-4">
        <div class="card-widget-separator-wrapper">
          <div class="card-body card-widget-separator">
            <div class="row gy-4 gy-sm-1">
              <div class="col-sm-6 col-lg-3">
                <div
                  class="d-flex justify-content-between align-items-start card-widget-1 border-end pb-3 pb-sm-0">
                  <div>
                    <h6 class="mb-2">In-store Sales</h6>
                    <h4 class="mb-2">$5,345.43</h4>
                    <p class="mb-0">
                      <span class="text-muted me-2">5k orders</span>
                      <span class="badge bg-label-success">+5.7%</span>
                    </p>
                  </div>
                  <span class="avatar me-sm-4">
                    <span class="avatar-initial bg-label-secondary rounded"
                      ><i class="ti-md ti ti-smart-home text-body"></i
                    ></span>
                  </span>
                </div>
                <hr class="d-none d-sm-block d-lg-none me-4" />
              </div>
              <div class="col-sm-6 col-lg-3">
                <div
                  class="d-flex justify-content-between align-items-start card-widget-2 border-end pb-3 pb-sm-0">
                  <div>
                    <h6 class="mb-2">Website Sales</h6>
                    <h4 class="mb-2">$674,347.12</h4>
                    <p class="mb-0">
                      <span class="text-muted me-2">21k orders</span
                      ><span class="badge bg-label-success">+12.4%</span>
                    </p>
                  </div>
                  <span class="avatar p-2 me-lg-4">
                    <span class="avatar-initial bg-label-secondary rounded"
                      ><i class="ti-md ti ti-device-laptop text-body"></i
                    ></span>
                  </span>
                </div>
                <hr class="d-none d-sm-block d-lg-none" />
              </div>
              <div class="col-sm-6 col-lg-3">
                <div
                  class="d-flex justify-content-between align-items-start border-end pb-3 pb-sm-0 card-widget-3">
                  <div>
                    <h6 class="mb-2">Discount</h6>
                    <h4 class="mb-2">$14,235.12</h4>
                    <p class="mb-0 text-muted">6k orders</p>
                  </div>
                  <span class="avatar p-2 me-sm-4">
                    <span class="avatar-initial bg-label-secondary rounded"
                      ><i class="ti-md ti ti-gift text-body"></i
                    ></span>
                  </span>
                </div>
              </div>
              <div class="col-sm-6 col-lg-3">
                <div class="d-flex justify-content-between align-items-start">
                  <div>
                    <h6 class="mb-2">Affiliate</h6>
                    <h4 class="mb-2">$8,345.23</h4>
                    <p class="mb-0">
                      <span class="text-muted me-2">150 orders</span
                      ><span class="badge bg-label-danger">-3.5%</span>
                    </p>
                  </div>
                  <span class="avatar p-2">
                    <span class="avatar-initial bg-label-secondary rounded"
                      ><i class="ti-md ti ti-wallet text-body"></i
                    ></span>
                  </span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- Product List Table -->
      <div class="card">
        <div class="card-header">
          <h5 class="card-title mb-0">Filter</h5>
          <div class="d-flex justify-content-between align-items-center row py-3 gap-3 gap-md-0">
            <div class="col-md-4 product_status"></div>
            <div class="col-md-4 product_category"></div>
            <div class="col-md-4 product_stock"></div>
          </div>
        </div>
        <div class="card-datatable table-responsive">
          <table class="datatables-products table">
            <thead class="border-top">
              <tr>
                <th>קוד</th>
                <th>שם</th>                
                <th>מחיר</th>
                <th>תיאור</th>
                <th>סטטוס</th> 
                <th>מלאי</th>                
                <th>קטגוריה</th>
                 <th>תמונה</th> 
                <th>הערות</th>        

              </tr>
            </thead>
              <tbody>
    <asp:Repeater ID="RptProds" runat="server">
        <ItemTemplate>
             <tr class="odd gradeX">
                <td><%#Eval("Pid") %></td>
                <td><%#Eval("Pname") %></td>
                <td><%#Eval("Pprice") %></td>
                <td><%#Eval("Pdesc") %></td>
                <td ><button class="<%--switch-off--%>"><%# Convert.ToBoolean(Eval("Status")) ? "פעיל" : "לא פעיל" %></button></td>   
                <td ><%#Eval("Pinventory") %></td>   
                <td ><%#Eval("Cid") %></td>   
                <td ><%#Eval("Picname") %></td>   
               <td ><%#Eval("Remarks") %></td>
        
      
                   <td > 
                          <button type="button" data-bs-toggle="modal"
data-bs-target="#update" onclick="openModalEdit({
        Pid: '<%# Eval("Pid") %>',
        Pname: '<%# Eval("Pname") %>',
        Pprice: '<%# Eval("Pprice") %>',
        Pdesc: '<%# Eval("Pdesc") %>',
        Pinventory: '<%# Eval("Pinventory") %>',
        Cid: '<%# Eval("Cid") %>',
        Picname: '<%# Eval("Picname") %>',
        Status: '<%# Eval("Status") %>',                            
        Remarks: '<%# Eval("Remarks") %>',
    })">
                                                <i class="fas fa-edit"></i>
                                            </button>
                      
           <asp:LinkButton class="delete-button" ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Pid") %>' OnClick="btnDelete_Click" OnClientClick="return confirm('אתה בטוח שברצונך למחוק מוצר זה?');"> 
           <i class="fas fa-trash-alt"></i>
           </asp:LinkButton></td>
   
              

            </tr>
        </ItemTemplate>
    </asp:Repeater>
   
   
</tbody>
          </table>
        </div>
      </div>
    </div>
    <!-- / Content -->

    <div class="modal fade" id="update" tabindex="-1" aria-hidden="true">
 <div class="modal-dialog modal-lg modal-simple modal-add-new-address">
 <div class="modal-content p-3 p-md-5">
 <div class="modal-body">
 <!-- Modal Header -->
 <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
 <div class="text-center mb-4">
 <h3 class="address-title mb-2">ערוך מוצר</h3>
 </div>

 <!-- Form Content -->
 <div class="row">
 <!-- Hidden Product ID -->
 <div class="col-12">
 <asp:HiddenField ID="HFPid" runat="server" />
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

 <!-- Buttons -->
 <div class="col-12 text-center mt-4">
<%-- <asp:Button ID="btnSave" runat="server" Text="שמור שינויים"--%>
<%-- CssClass="btn btn-primary me-2" OnClick="SaveProduct"/>--%>
 <button type="button" class="btn btn-label-secondary"
 data-bs-dismiss="modal">ביטול</button>
 </div>
 </div>
 </div>
 </div>
 </div>
</div>


<%-- <div class="modal fade" id="update" tabindex="-1" aria-hidden="true"> 
  <div class="modal-dialog modal-lg modal-simple modal-add-new-address">
    <div class="modal-content p-3 p-md-5">
      <div class="modal-body">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        <div class="text-center mb-4">
          <h3 class="address-title mb-2">ערוך מוצר</h3>
        </div>
<div class="form-group">
    <div class="col-12">
           <asp:HiddenField ID="HFPid" runat="server" />
          </div>
          <div class="col-12 col-md-6">
              <div class="form-group">
            <label class="form-label" for="Pname    ">שם</label>
              <asp:TextBox ID="txtPname" runat="server" required="required" ></asp:TextBox>
             </div>
       </div>

          <div class="col-12 col-md-6">
              <div class="form-group">
            <label class="form-label" for="Pprice  ">מחיר</label>
           <asp:TextBox ID="textPprice" runat="server" required="required" ></asp:TextBox>
          </div>
            
     </div>
             <div class="col-12 col-md-6">
                 <div class="form-group">
   <label class="form-label" for="Pdesc   ">תיאור</label>
        <asp:TextBox ID="textPdesc" runat="server" required="required" ></asp:TextBox>
 </div>
  

          <div class="col-12 col-md-6">
              <div class="form-group">
            <label class="form-label" for="Pinventory ">מלאי</label>
                <asp:TextBox ID="textPinventory" runat="server" required="required" ></asp:TextBox>           
          </div>
 </div>
          <div class="col-12 col-md-6">
              <div class="form-group">
            <label class="form-label" for="Cid">קוד קטגוריה</label>
                <asp:TextBox ID="textCid" runat="server" required="required" ></asp:TextBox>           

           
          </div>
          <div class="col-12 col-md-6">
              <div class="form-group">
            <label class="form-label" for="Status">סטטוס</label>
                <asp:TextBox ID="textStatus" runat="server" required="required" ></asp:TextBox>           

           
          </div>
          <div class="col-12 col-md-6">
              <div class="form-group">
            <label class="form-label" for="Remarks">הערות</label>
                <asp:TextBox ID="textRemarks" runat="server" required="required" ></asp:TextBox>           

       
          </div>
          <div class="col-12">
            <label class="switch">
              <input type="checkbox" class="switch-input" />
              <span class="switch-toggle-slider">
                <span class="switch-on"></span>
                <span class="switch-off"></span>
              </span>
              <span class="switch-label">Use as a billing address?</span>
            </label>
          </div>
          <div class="col-12 text-center">
            
<%--<asp:Button ID="btnSave" runat="server" OnClick="SaveProduct" Text="שמירה" CssClass="btn btn-primary" />--%>
          <%--  <button
              type="reset"
              class="btn btn-label-secondary"
              data-bs-dismiss="modal"
              aria-label="Close">
              Cancel
            </button>
              </div>
              </div>
              </div>
              </div>
                 </div>
    </div>
           
      </div>
    </div>--%>
 <%-- </div>
</div>--%> 

      </body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
            <script src="../assets/js/app-ecommerce-product-list.js"></script>
        <!-- Main JS -->
    <script src="../assets/js/main.js">
         // פונקציה לפתיחת מודאל עריכת מוצר
        function openModalEdit(Product) {
    console.log('Starting openModalEdit function with Product:', Product);

    try {
        // Get modal element
        var modal = document.getElementById('update');
        console.log('Modal element found:', modal);
       
        if (!modal) {
            console.error('Modal element not found!');
            return;
        }

        // Validate Product object
        if (!Product || typeof Product !== 'object') {
            console.error('Invalid Product object:', Product);
            return;
        }

        // Update hidden field
        var pidField = document.getElementById('<%= HFPid.ClientID %>');
        if (pidField) {
            pidField.value = Product.Pid;
            console.log('Updated PID field with:', Product.Pid);
        }

        // Update product name
        var pnameField = document.getElementById('<%= txtPname.ClientID %>');
        if (pnameField) {
            pnameField.value = Product.Pname;
            console.log('Updated Product name field with:', Product.Pname);
        }

        // Update price
        var priceField = document.getElementById('<%= textPprice.ClientID %>');
        if (priceField) {
            priceField.value = Product.Pprice;
            console.log('Updated Price field with:', Product.Pprice);
        }

        // Update description
        var descField = document.getElementById('<%= textPdesc.ClientID %>');
        if (descField) {
            descField.value = Product.Pdesc;
            console.log('Updated Description field with:', Product.Pdesc);
        }

        // Update inventory
        var inventoryField = document.getElementById('<%= textPinventory.ClientID %>');
        if (inventoryField) {
            inventoryField.value = Product.Pinventory;
            console.log('Updated Inventory field with:', Product.Pinventory);
        }

        // Update category ID
        var cidField = document.getElementById('<%= textCid.ClientID %>');
        if (cidField) {
            cidField.value = Product.Cid;
            console.log('Updated Category ID field with:', Product.Cid);
        }

        // Update status
        var statusField = document.getElementById('<%= textStatus.ClientID %>');
        if (statusField) {
            statusField.value = Product.Status;
            console.log('Updated Status field with:', Product.Status);
        }

        // Update remarks
        var remarksField = document.getElementById('<%= textRemarks.ClientID %>');
        if (remarksField) {
            remarksField.value = Product.Remarks;
            console.log('Updated Remarks field with:', Product.Remarks);
        }

        // Show the modal
        if (modal && typeof modal.show === 'function') {
            modal.show();
            console.log('Modal displayed successfully');
        } else {
            // If modal.show() is not available, you might need to use a library or different method
            $(modal).modal('show'); // If using Bootstrap
            console.log('Modal displayed using Bootstrap');
        }

    } catch (error) {
        console.error('Error in openModalEdit:', error);
    }
}

<%--        function openModalEdit(Product) {
            var modal = document.getElementById('update');
<%--          var btnSave = document.getElementById('<%= btnSave.ClientID %>');--%>

           <%-- title.innerText = 'עריכת טכנאי';
            btnSave.value = 'שמור שינויים';--%>

<%--            populate form fields with technician data--%>
<%--            document.getElementById('<%= HFPid.ClientID %>').value = Product.Pid;
            document.getElementById('<%= txtPname.ClientID %>').value = Product.Pname;
            document.getElementById('<%= textPprice.ClientID %>').value = Product.Pprice;
            document.getElementById('<%= textPdesc.ClientID %>').value = Product.Pdesc;
            document.getElementById('<%= textPinventory.ClientID %>').value = Product.Pinventory;
            document.getElementById('<%= textCid.ClientID %>').value = Product.Cid;
            document.getElementById('<%= textStatus.ClientID %>').value = Product.Status;
            document.getElementById('<%= textRemarks.ClientID %>').value = Product.Remarks;
           

        }--%>

        
    </script>
</asp:Content>
