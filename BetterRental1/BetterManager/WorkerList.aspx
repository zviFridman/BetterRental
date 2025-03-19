<%@ Page Title="" Language="C#" MasterPageFile="~/BetterManager/Main.Master" AutoEventWireup="true" CodeBehind="WorkerList.aspx.cs" Inherits="BetterRental1.BetterManager.WorkerList" %>
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
        <div class="container-xxl flex-grow-1 container-p-y">
            <h4 class="py-3 mb-4"><span class="text-muted fw-light"></span> רשימת עובדים</h4>

            <!-- כפתור הוספת עובד חדש -->
            <div class="mb-3 text-end">
                <a href="WorkersEdit.aspx" class="btn btn-primary">
                    <i class="fas fa-plus"></i> הוסף עובד חדש
                </a>
            </div>

            <!-- Workers List Table -->
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title mb-0">רשימת עובדים</h5>
                </div>
                <div class="card-datatable table-responsive">
                    <table class="datatables-customers table">
                        <thead class="border-top">
                            <tr>
                                <th>מזהה</th>
                                <th>שם פרטי</th>
                                <th>שם משפחה</th>
                                <th>קוד חברה</th>
                                <th>אימייל</th>
                                <th>טלפון</th>
                                <th>כתובת</th>
                                <th>שכר שעה</th>
                                <th>שכר חודש</th>
                                <th>תפקיד</th>
                                <th>סטטוס</th>
                                <th>תאריך הוספה</th>
                                <th>הערות</th>
                                <th>פעולות</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RptWorkers" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Wid") %></td>
                                        <td><%# Eval("Wfname") %></td>
                                        <td><%# Eval("Wlname") %></td>
                                        <td><%# Eval("CompanyCode") %></td>
                                        <td><%# Eval("Wemail") %></td>
                                        <td><%# Eval("Wphone") %></td>
                                        <td><%# Eval("Wadress") %></td>
                                        <td><%# Eval("SaleryHour") %></td>
                                        <td><%# Eval("SaleryMonth") %></td>
                                        <td><%# Eval("Wjob") %></td>
                                        <td><%# Convert.ToBoolean(Eval("Status")) ? "פעיל" : "לא פעיל" %></td>
                                        <td><%# Eval("AddDate", "{0:dd/MM/yyyy}") %></td>
                                        <td><%# Eval("Remarks") %></td>
                                        <td>
                                            <a href="WorkersEdit.aspx?wid=<%# Eval("Wid") %>">
                                                <i class="fas fa-edit"></i>
                                            </a>
                                            <asp:LinkButton class="delete-button" ID="btnDelete" runat="server" CommandArgument='<%# Eval("Wid") %>' OnClick="btnDelete_Click" OnClientClick="return confirm('אתה בטוח שברצונך למחוק עובד זה?');">
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

