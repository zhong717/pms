<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Product_Batch_edit.aspx.cs" Inherits="EmptyProjectNet20.pms_Product_Batch_edit" %>

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
            <x:Form ID="Form2" runat="server" Height="90px" BodyPadding="5px" ShowHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Rows>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <x:Label ID="lbBatchID" runat="server" Label="批次编号" Text=""></x:Label>
                            <x:TextBox ID="tbxBatchName" runat="server" Label="批次名称" Required="true" ShowRedStar="true"></x:TextBox>                            
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow2" runat="server">
                        <Items>                            
                            <x:DropDownList runat="server" ID="ddlBisContact" Label="商务联系人" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>
                            <x:DropDownList runat="server" ID="ddlQuaContact" Label="质量联系人" AutoPostBack="true"></x:DropDownList>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow3" runat="server">
                        <Items>                            
                            <x:DropDownList runat="server" ID="ddlCompany" Label="顾客名称" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>
                            <x:DropDownList runat="server" ID="ddlFinCustom" Label="最终顾客" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                EnableCheckBoxSelect="true" EnableRowNumber="true" DataKeyNames="ProductInfoID" AllowSorting="true"
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
                            <x:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="添加新产品">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Toolbar runat="server" Position="Footer">
                    <Items>
                        <x:Button ID="btnSave" ValidateForms="Form2" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存"></x:Button>
                    </Items>
                    </x:Toolbar>
                </Toolbars>
                <Columns>
                    <x:BoundField DataField="批次名称" SortField="批次名称" ExpandUnusedSpace="true" HeaderText="批次名称" />
                    <x:BoundField DataField="产品名称" SortField="产品名称" ExpandUnusedSpace="true" HeaderText="产品名称" />
                    <x:BoundField DataField="内部顾客" SortField="内部顾客" ExpandUnusedSpace="true" HeaderText="内部顾客" />
                    <x:BoundField DataField="最终顾客" SortField="最终顾客" ExpandUnusedSpace="true" HeaderText="最终顾客" />
                    <x:BoundField DataField="顾客要求" SortField="顾客要求" ExpandUnusedSpace="true" HeaderText="顾客要求" />
                    <x:BoundField DataField="产品结构" SortField="产品结构" ExpandUnusedSpace="true" HeaderText="产品结构" />
                    <x:BoundField DataField="产品材质" SortField="产品材质" ExpandUnusedSpace="true" HeaderText="产品材质" />
                    <x:BoundField DataField="所在行业" SortField="所在行业" ExpandUnusedSpace="true" HeaderText="所在行业" />
                    <x:BoundField DataField="图号" SortField="图号" ExpandUnusedSpace="true" HeaderText="图号" />
                    <x:BoundField DataField="规范" SortField="规范" ExpandUnusedSpace="true" HeaderText="规范" />
                    <x:BoundField DataField="净重" SortField="净重" ExpandUnusedSpace="true" HeaderText="净重" />
                    <x:BoundField DataField="订单量" SortField="订单量" ExpandUnusedSpace="true" HeaderText="订单量" />
                    <x:BoundField DataField="商务联系人" SortField="商务联系人" ExpandUnusedSpace="true" HeaderText="商务联系人" />
                    <x:BoundField DataField="质量联系人" SortField="质量联系人" ExpandUnusedSpace="true" HeaderText="质量联系人" />
                    <x:BoundField DataField="营销员说明" SortField="营销员说明" ExpandUnusedSpace="true" HeaderText="营销员说明" />
                    <x:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑" WindowID="Window1"
                        Title="编辑" DataIFrameUrlFields="ProductInfoID" DataIFrameUrlFormatString="~/pms_Product_Info_edit.aspx?id={0}"
                        Width="50px" />
                    <x:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除" ConfirmText="确定删除此记录？"
                        ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true" Target="Top"
        EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="800px" Height="650px" OnClose="Window1_Close">
    </x:Window>
    </form>
</body>
</html>
