<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="CustomersList.aspx.cs" Inherits="BetterRental1.BetterManager.CustomersList" %>
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
    <link href="https://fonts.googleapis.com/css2?family=Public+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700&ampdisplay=swap" rel="stylesheet" />
    
    <!-- Icons -->
    <link rel="stylesheet" href="../assets/vendor/fonts/fontawesome.css" />
    <link rel="stylesheet" href="../assets/vendor/fonts/tabler-icons.css" />
    <link rel="stylesheet" href="../assets/vendor/fonts/flag-icons.css" />

    <!-- Page CSS -->
    <!-- Helpers -->
    <script src="../assets/vendor/js/helpers.js"></script>
    <script src="../assets/js/config.js"></script>
    
    <body>
        <!-- Content wrapper -->
        <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
                <h4 class="py-3 mb-4"><span class="text-muted fw-light"></span> רשימת לקוחות</h4>

                <!-- כפתור הוספת לקוח חדש -->
                <div class="mb-3 text-end">
                    <a href="CustomerEdit.aspx" class="btn btn-primary">
                        <i class="fas fa-plus"></i> הוסף לקוח חדש
                    </a>
                </div>

                <!-- Customer List Table -->
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">רשימת לקוחות</h5>
                    </div>
                    <div class="card-datatable table-responsive">
                        <table class="datatables-customers table">
                            <thead class="border-top">
                                <tr>
                                    <th>קוד לקוח</th>
                                    <th>שם הלקוח</th>
                                    <th>אימייל</th>
                                    <th>טלפון</th>
                                    <th>כתובת</th>
                                    <th>סוג לקוח</th>
                                    <th>יתרה כספית</th>
                                    <th>סטטוס</th>
                                    <th>תאריך הוספה</th>
                                    <th>הערות</th>
                                    <th>פעולות</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RptCustomers" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td><%# Eval("CUid") %></td>
                                            <td><%# Eval("CUname") %></td>
                                            <td><%# Eval("CUemail") %></td>
                                            <td><%# Eval("CUphone") %></td>
                                            <td><%# Eval("CUadress") %></td>
                                            <td><%# Convert.ToBoolean(Eval("CUtype")) ? "עסקי" : "פרטי" %></td>
                                            <td><%# Eval("Money") %></td>
                                            <td><%# Convert.ToBoolean(Eval("Status")) ? "פעיל" : "לא פעיל" %></td>
                                            <td><%# Eval("AddDate", "{0:dd/MM/yyyy}") %></td>
                                            <td><%# Eval("Remarks") %></td>
                                            <td>
                                                <a href="CustomerEdit.aspx?cuid=<%# Eval("CUid") %>">
                                                    <i class="fas fa-edit"></i>
                                                </a>
                                                <asp:LinkButton class="delete-button" ID="LinkButton1" runat="server" CommandArgument='<%# Eval("CUid") %>' OnClick="btnDelete_Click" OnClientClick="return confirm('אתה בטוח שברצונך למחוק לקוח זה?');">
                                                    <i class="fas fa-trash-alt"></i>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
    <script src="../assets/js/app-ecommerce-product-list.js"></script>
    <script src="../assets/js/main.js"></script>
</asp:Content>
