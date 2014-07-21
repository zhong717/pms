<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Quotation_Info.aspx.cs" Inherits="EmptyProjectNet20.pms_Quotation_Info" %>

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
                            <x:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在产品批次信心中搜索"
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
                        Title="编辑" DataIFrameUrlFields="QuotationInfoID,净重" DataIFrameUrlFormatString="~/pms_Quotation_Batch_edit.aspx?id={0}&id1={1}"
                        Width="50px" />
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
