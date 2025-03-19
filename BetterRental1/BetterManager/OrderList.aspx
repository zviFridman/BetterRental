<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="BetterRental1.BetterManager.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        button.add-new {
    display: none !important;
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
      <!-- Content wrapper -->
  <div class="content-wrapper">
    <!-- Content -->

    <div class="container-xxl flex-grow-1 container-p-y">
      <h4 class="py-3 mb-4"><span class="text-muted fw-light"></span> רשימת הזמנות</h4>


      <!-- Product List Widget -->

<%--      <div class="card mb-4">
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
      </div>--%>
         <!-- כפתור הוספת מוצר חדש -->
                <div class="mb-3 text-end">
                    <a href="OrderEdit.aspx" class="btn btn-primary">
                        <i class="fas fa-plus"></i> הוסף הזמנה חדשה
                    </a>
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
                <th>תאריך ההזמנה</th>               
                <th>קוד לקוח</th>
                <th>תאריך איסוף</th>
                <th>תאריך החזרה</th>                
                <th>סטטוס הכנה</th>
                 <th>סטטוס כולל</th> 
                 <th>סטטוס תשלום</th> 
                 <th>חלוקה/איסוף עצמי</th> 
                 <th>מקום האירוע</th> 
                 <th>הערות</th> 
                <th>מחיר הזמנה</th>
                   <th>פעולות</th>

              </tr>
            </thead>
              <tbody>
    <asp:Repeater ID="RptOrders" runat="server">
        <ItemTemplate>
             <tr class="odd gradeX">
                <td><%#Eval("Oid ") %></td>
                <td><%#Eval("Odate") %></td>
                <td><%#Eval("CAid") %></td>
                <td><%#Eval("CollectionDate") %></td>
                <td><%#Eval("ReturnDate") %></td>
                <td ><%# Convert.ToBoolean(Eval("StatusRedy")) ? "מוכן" : "לא מוכן" %></td>   
                <td ><%# Convert.ToBoolean(Eval("StatusOrder")) ? "פעיל" : "לא פעיל" %></td>   
                <td ><%# Convert.ToBoolean(Eval("StatusPay")) ? "שולם" : "לא שולם" %></td>   
                  <td ><%# Convert.ToBoolean(Eval("Collection")) ? "איסוף עצמי" : "חלוקה" %></td>   
                <td ><%#Eval("PlaceToSend") %></td>   
                <td ><%#Eval("SumOrder") %></td>   
               <td ><%#Eval("Remarks") %></td>
        
      
                   <td > 
            <a href="OrderEdit.aspx?oid=<%#Eval("Oid ") %>"><i class="fas fa-edit"></i></a>       
                       
           <asp:LinkButton class="delete-button" ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Oid") %>' OnClick="btnDelete_Click" OnClientClick="return confirm('אתה בטוח שברצונך למחוק הזמנה זה?');"> 
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

    
      </body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
            <script src="../assets/js/app-ecommerce-product-list.js"></script>
        <!-- Main JS -->
    <script src="../assets/js/main.js">
    </script>
</asp:Content>
