<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Product_Info.aspx.cs" Inherits="EmptyProjectNet20.pms_Product_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="5px" EnableLargeHeader="false"
        EnableBackgroundColor="true" ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" ShowHeader="false" Title="新产品录入">
        <Items>
            <x:Form ID="Form2" runat="server" Height="36px" BodyPadding="5px" ShowHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Rows>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <x:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在新产品信息中搜索"
                                Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false" OnTrigger2Click="ttbSearchMessage_Trigger2Click"
                                OnTrigger1Click="ttbSearchMessage_Trigger1Click">
                            </x:TwinTriggerBox>
                            <x:Label ID="Label1" runat="server">
                            </x:Label>
                            <x:Label ID="Label2" runat="server">
                            </x:Label>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                EnableRowNumber="true" DataKeyNames="ProductBatchID" AllowSorting="true"
                OnSort="Grid1_Sort" SortColumnIndex="0" SortDirection="DESC" AllowPaging="true"
                IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound" OnRowCommand="Grid1_RowCommand"
                OnPageIndexChange="Grid1_PageIndexChange">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <%--<x:Button ID="btnDeleteSelected" Icon="Delete" runat="server" Text="删除选中记录" OnClick="btnDeleteSelected_Click">
                            </x:Button>--%>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="添加新批次">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Columns>
                    <x:BoundField DataField="批次名称" SortField="批次名称" ExpandUnusedSpace="true" HeaderText="批次名称" />
                    <x:BoundField DataField="内部顾客" SortField="内部顾客" ExpandUnusedSpace="true" HeaderText="内部顾客" />
                    <x:BoundField DataField="最终顾客" SortField="最终顾客" ExpandUnusedSpace="true" HeaderText="最终顾客" />
                    <x:BoundField DataField="商务联系人" SortField="商务联系人" ExpandUnusedSpace="true" HeaderText="商务联系人" />
                    <x:BoundField DataField="商务座机" SortField="商务联系电话" ExpandUnusedSpace="true" HeaderText="商务联系电话" />
                    <x:BoundField DataField="商务邮箱" SortField="商务联系邮箱" ExpandUnusedSpace="true" HeaderText="商务联系邮箱" />
                    <x:BoundField DataField="质量联系人" SortField="质量联系人" ExpandUnusedSpace="true" HeaderText="质量联系人" />                   
                    <x:BoundField DataField="质量座机" SortField="质量联系电话" ExpandUnusedSpace="true" HeaderText="质量联系电话" />             
                    <x:BoundField DataField="质量邮箱" SortField="质量联系邮箱" ExpandUnusedSpace="true" HeaderText="质量联系邮箱" />
                    <x:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑" WindowID="Window1"
                        Title="编辑" DataIFrameUrlFields="ProductBatchID" DataIFrameUrlFormatString="~/pms_Product_Batch_edit.aspx?id={0}"
                        Width="50px" />
                    <x:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除" ConfirmText="确定删除此记录？如果批次内的明细条目未全部删除,请将之完全删除后再删此处!"
                        ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true" Target="Top"
        EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="1000px" Height="650px" OnClose="Window1_Close">
    </x:Window>
    </form>
</body>
</html>
