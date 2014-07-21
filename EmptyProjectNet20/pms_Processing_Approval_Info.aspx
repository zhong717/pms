<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Processing_Approval_Info.aspx.cs" Inherits="EmptyProjectNet20.pms_Processing_Approval_Info" %>

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
                            <x:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在产品批次信息中搜索"
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
                <Columns>
                    <x:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="审批" WindowID="Window1"
                        Title="报价信息" DataIFrameUrlFields="ProductBatchID" DataIFrameUrlFormatString="~/pms_Processing_Approval.aspx?id={0}"
                        Width="50px" />
                    <x:BoundField DataField="批次名称" SortField="批次名称" ExpandUnusedSpace="true" HeaderText="批次名称" />
                    <x:BoundField DataField="内部顾客" SortField="内部顾客" ExpandUnusedSpace="true" HeaderText="内部顾客" />
                    <x:BoundField DataField="商务联系人" SortField="商务联系人" ExpandUnusedSpace="true" HeaderText="商务联系人" />
                    <x:BoundField DataField="商务座机" SortField="商务座机" ExpandUnusedSpace="true" HeaderText="商务座机" />
                    <x:BoundField DataField="商务邮箱" SortField="商务邮箱" ExpandUnusedSpace="true" HeaderText="商务邮箱" />
                    <x:BoundField DataField="质量联系人" SortField="质量联系人" ExpandUnusedSpace="true" HeaderText="质量联系人" />                   
                    <x:BoundField DataField="质量座机" SortField="质量座机" ExpandUnusedSpace="true" HeaderText="质量座机" />             
                    <x:BoundField DataField="质量邮箱" SortField="质量邮箱" ExpandUnusedSpace="true" HeaderText="质量邮箱" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true" Target="Top"
        EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="1000px" Height="600px" OnClose="Window1_Close">
    </x:Window>
    </form>
</body>
</html>
