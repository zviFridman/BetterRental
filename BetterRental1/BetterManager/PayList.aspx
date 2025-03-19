<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="PayList.aspx.cs" Inherits="BetterRental1.BetterManager.PayList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        button.add-new {
            display: none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <!-- Content wrapper -->
    <div class="content-wrapper">
        <!-- Content -->
        <div class="container-xxl flex-grow-1 container-p-y">
            <h4 class="py-3 mb-4"><span class="text-muted fw-light"></span> רשימת תשלומים</h4>

            <!-- כפתור הוספת תשלום חדש -->
            <div class="mb-3 text-end">
                <a href="PayEdit.aspx" class="btn btn-primary">
                    <i class="fas fa-plus"></i> הוסף תשלום חדש
                </a>
            </div>

            <!-- Payment List Table -->
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title mb-0">רשימת תשלומים</h5>
                </div>
                <div class="card-datatable table-responsive">
                    <table class="datatables-customers table">
                        <thead class="border-top">
                            <tr>
                                <th>מזהה תשלום</th>
                                <th>תאריך תשלום</th>
                                <th>סכום</th>
                                <th>סוג תשלום</th>
                                <th>מזהה לקוח</th>
                                <th>סטטוס</th>
                                <th>מזהה הזמנה</th>
                                <th>תאריך הוספה</th>
                                <th>הערות</th>
                                <th>קוד חברה</th>
                                <th>פעולות</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RptPayments" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Paid") %></td>
                                        <td><%# Eval("Padata", "{0:dd/MM/yyyy}") %></td>
                                        <td><%# Eval("PaySum") %></td>
                                        <td><%# Eval("Ptid") %></td>
                                        <td><%# Eval("Caid") %></td>
                                        <td><%# Convert.ToBoolean(Eval("Status")) ? "פעיל" : "לא פעיל" %></td>
                                        <td><%# Eval("Oid") %></td>
                                        <td><%# Eval("AddDate", "{0:dd/MM/yyyy}") %></td>
                                        <td><%# Eval("Remarks") %></td>
                                        <td><%# Eval("CompanyCode") %></td>
                                        <td>
                                            <a href="PayEdit.aspx?pid=<%# Eval("Paid") %>">
                                                <i class="fas fa-edit"></i>
                                            </a>
                                            <asp:LinkButton class="delete-button" ID="btnDelete" runat="server" CommandArgument='<%# Eval("Paid") %>' OnClick="btnDelete_Click" OnClientClick="return confirm('אתה בטוח שברצונך למחוק תשלום זה?');">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
    <script src="../assets/js/app-ecommerce-product-list.js"></script>
    <script src="../assets/js/main.js"></script>
</asp:Content>