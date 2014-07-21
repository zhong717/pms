<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_User_Info.aspx.cs" Inherits="EmptyProjectNet20.pms_User_Info" %>

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
        BoxConfigPosition="Start" ShowHeader="false" Title="">
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
                EnableRowNumber="true" DataKeyNames="UserInfoID" AllowSorting="true"
                OnSort="Grid1_Sort" SortColumnIndex="0" SortDirection="DESC" AllowPaging="true"
                IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound" OnRowCommand="Grid1_RowCommand"
                OnPageIndexChange="Grid1_PageIndexChange">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="添加新用户">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Columns>
                    <x:BoundField DataField="UserName" SortField="UserName" ExpandUnusedSpace="true" HeaderText="用户名" />
                    <x:BoundField DataField="CompanyName" SortField="CompanyName" ExpandUnusedSpace="true" HeaderText="公司" />
                    <x:BoundField DataField="DeptName" SortField="DeptName" ExpandUnusedSpace="true" HeaderText="部门" />
                    <x:BoundField DataField="Permission" SortField="Permission" ExpandUnusedSpace="true" HeaderText="权限" />
                    <x:BoundField DataField="UserTel" SortField="UserTel" ExpandUnusedSpace="true" HeaderText="办公电话" />
                    <x:BoundField DataField="UserPhone" SortField="UserPhone" ExpandUnusedSpace="true" HeaderText="手机" />
                    <x:BoundField DataField="UserMail" SortField="UserMail" ExpandUnusedSpace="true" HeaderText="邮箱地址" />
                    <x:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑" WindowID="Window1"
                        Title="编辑用户信息" DataIFrameUrlFields="UserInfoID" DataIFrameUrlFormatString="~/pms_User_Info_edit.aspx?id={0}"
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
