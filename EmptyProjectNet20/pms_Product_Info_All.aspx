<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Product_Info_All.aspx.cs" Inherits="EmptyProjectNet20.pms_Product_Info_All" %>

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
                            <x:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在所有产品中搜索同批次产品"
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
                EnableRowNumber="true" DataKeyNames="ProductInfoID" AllowSorting="true"
                OnSort="Grid1_Sort" SortColumnIndex="0" SortDirection="DESC" AllowPaging="true"
                IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound"
                OnPageIndexChange="Grid1_PageIndexChange">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Button ID="btnNew" runat="server" EnableAjax="false" DisableControlBeforePostBack="false" 
                             Text="导出为excel" OnClick="Button1_Click"></x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Columns>
                    <x:BoundField DataField="批次名称" SortField="批次名称" ExpandUnusedSpace="true" HeaderText="批次名称" />
                    <x:BoundField DataField="产品名称" SortField="产品名称" ExpandUnusedSpace="true" HeaderText="产品名称" />
                    <x:BoundField DataField="图号" SortField="图号" ExpandUnusedSpace="true" HeaderText="图号" />
                    <x:BoundField DataField="规范" SortField="规范" ExpandUnusedSpace="true" HeaderText="规范" />
                    <x:BoundField DataField="审批状态" SortField="审批状态" ExpandUnusedSpace="true" HeaderText="审批状态" />
                    <x:BoundField DataField="净重" SortField="净重" ExpandUnusedSpace="true" HeaderText="净重(吨)" />
                    <x:BoundField DataField="订单量" SortField="订单量" ExpandUnusedSpace="true" HeaderText="订单量" />
                    <x:BoundField DataField="营销员说明" SortField="营销员说明" ExpandUnusedSpace="true" HeaderText="营销员说明" />
                    <x:BoundField DataField="所在行业" SortField="所在行业" ExpandUnusedSpace="true" HeaderText="所在行业" />
                    <x:BoundField DataField="产品材质" SortField="产品材质" ExpandUnusedSpace="true" HeaderText="产品材质" />
                    <x:BoundField DataField="产品结构" SortField="产品结构" ExpandUnusedSpace="true" HeaderText="产品结构" />
                    <x:BoundField DataField="顾客要求" SortField="顾客要求" ExpandUnusedSpace="true" HeaderText="顾客要求" />
                    <x:BoundField DataField="报价人" SortField="报价人" ExpandUnusedSpace="true" HeaderText="报价人" />
                    <x:BoundField DataField="报价邮箱" SortField="报价邮箱" ExpandUnusedSpace="true" HeaderText="报价邮箱" />
                    <x:BoundField DataField="报价单位" SortField="报价单位" ExpandUnusedSpace="true" HeaderText="报价单位" />
                    <x:BoundField DataField="报价时间" SortField="报价时间" ExpandUnusedSpace="true" HeaderText="报价时间" />
                    <x:BoundField DataField="刀具费用" SortField="刀具费用" ExpandUnusedSpace="true" HeaderText="刀具费用" />
                    <x:BoundField DataField="刀具信息" SortField="刀具信息" ExpandUnusedSpace="true" HeaderText="刀具信息" />
                    <x:BoundField DataField="工装费用" SortField="工装费用" ExpandUnusedSpace="true" HeaderText="工装费用" />
                    <x:BoundField DataField="工装信息" SortField="工装信息" ExpandUnusedSpace="true" HeaderText="工装信息" />
                    <x:BoundField DataField="运输费用" SortField="运输费用" ExpandUnusedSpace="true" HeaderText="运输费用" />
                    <x:BoundField DataField="运费信息" SortField="运费信息" ExpandUnusedSpace="true" HeaderText="运费信息" />
                    <x:BoundField DataField="包装费用" SortField="包装费用" ExpandUnusedSpace="true" HeaderText="包装费用" />
                    <x:BoundField DataField="包装信息" SortField="包装信息" ExpandUnusedSpace="true" HeaderText="包装信息" />
                    <x:BoundField DataField="喷涂费用" SortField="喷涂费用" ExpandUnusedSpace="true" HeaderText="喷涂费用" />
                    <x:BoundField DataField="喷涂信息" SortField="喷涂信息" ExpandUnusedSpace="true" HeaderText="喷涂信息" />
                    <x:BoundField DataField="检测费用" SortField="检测费用" ExpandUnusedSpace="true" HeaderText="检测费用" />
                    <x:BoundField DataField="检测信息" SortField="检测信息" ExpandUnusedSpace="true" HeaderText="检测信息" />
                    <x:BoundField DataField="加工费用" SortField="加工费用" ExpandUnusedSpace="true" HeaderText="加工费用" />
                    <x:BoundField DataField="加工信息" SortField="加工信息" ExpandUnusedSpace="true" HeaderText="加工信息" />
                    <x:BoundField DataField="商务联系人" SortField="商务联系人" ExpandUnusedSpace="true" HeaderText="商务联系人" />
                    <x:BoundField DataField="商务邮箱" SortField="商务邮箱" ExpandUnusedSpace="true" HeaderText="商务邮箱" />
                    <x:BoundField DataField="内部顾客" SortField="内部顾客" ExpandUnusedSpace="true" HeaderText="内部顾客" />
                    <x:BoundField DataField="最终顾客" SortField="最终顾客" ExpandUnusedSpace="true" HeaderText="最终顾客" />
                    <x:BoundField DataField="生产部意见" SortField="生产部意见" ExpandUnusedSpace="true" HeaderText="生产部意见" />
                    <x:BoundField DataField="公司领导意见" SortField="公司领导意见" ExpandUnusedSpace="true" HeaderText="公司领导意见" />
                    <x:BoundField DataField="审批时间" SortField="审批时间" ExpandUnusedSpace="true" HeaderText="最后审批时间" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true" Target="Top"
        EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="800px" Height="650px">
    </x:Window>
    </form>
</body>
</html>
