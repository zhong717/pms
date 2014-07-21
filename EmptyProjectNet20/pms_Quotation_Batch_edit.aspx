<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Quotation_Batch_edit.aspx.cs" Inherits="EmptyProjectNet20.pms_Quotation_Batch_edit" %>

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
            <x:Form ID="Form2" runat="server" Height="285px" BodyPadding="5px" ShowHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Rows>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <x:Label ID="lbBatchID" runat="server" Label="报价单编号" Text=""></x:Label>
                            <x:Label ID="lbProID" runat="server" Label="产品信息编号" Text=""></x:Label>                                                    
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:TextBox ID="tbxCharge" runat="server" Label="加工价格" Enabled="false"></x:TextBox>
                            <x:TextBox ID="tbxChargeDesc" runat="server" Label="费用说明"></x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:TextBox ID="tbxTrans" runat="server" Label="运输费用" Required="true" ShowRedStar="true" OnTextChanged="btn_PriceClick" AutoPostBack="true"></x:TextBox>
                            <x:TextBox ID="tbxTransDesc" runat="server" Label="费用说明"></x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:TextBox ID="tbxTest" runat="server" Label="检测费用" Required="true" ShowRedStar="true" OnTextChanged="btn_PriceClick" AutoPostBack="true"></x:TextBox>
                            <x:TextBox ID="tbxTestDesc" runat="server" Label="费用说明"></x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow4" runat="server">
                        <Items> 
                            <x:TextBox ID="tbxSpray" runat="server" Label="喷涂费用" Required="true" ShowRedStar="true" OnTextChanged="btn_PriceClick" AutoPostBack="true"></x:TextBox> 
                            <x:TextBox ID="tbxSprayDesc" runat="server" Label="费用说明"></x:TextBox>                            
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:TextBox ID="tbxPack" runat="server" Label="包装费用" Required="true" ShowRedStar="true" OnTextChanged="btn_PriceClick" AutoPostBack="true"></x:TextBox>
                            <x:TextBox ID="tbxPackDesc" runat="server" Label="费用说明"></x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow2" runat="server">
                        <Items> 
                            <x:TextBox ID="tbxKnife" runat="server" Label="刀具费用" Required="true" ShowRedStar="true" Width=""></x:TextBox> 
                            <x:TextBox ID="tbxKnifeDesc" runat="server" Label="费用说明"></x:TextBox>                          
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:TextBox ID="tbxTool" runat="server" Label="工装费用" Required="true" ShowRedStar="true"></x:TextBox> 
                            <x:TextBox ID="tbxToolDesc" runat="server" Label="费用说明"></x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow3" runat="server">
                        <Items> 
                            <x:Label ID="lbUnitPrice" runat="server" Label="吨单价" Text="" ></x:Label> 
                             <x:DropDownList runat="server" ID="ddlCom" Label="报价单位" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>                                                   
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:Button ID="btnDownload" runat="server" Text="下载营销员附件" OnClick="btnDownload_Click"></x:Button>
                            <x:FileUpload ID="fileUpload" runat="server" Label="上传附件" EmptyText="多个附件请打包为一个上传"></x:FileUpload>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                EnableRowNumber="true" DataKeyNames="QuotationDetailsID" AllowSorting="true"
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
                            <x:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="添加机床"></x:Button>
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
                    <x:BoundField DataField="报价单ID" SortField="报价单ID" ExpandUnusedSpace="true" HeaderText="报价单ID" />
                    <x:BoundField DataField="机床类型" SortField="机床类型" ExpandUnusedSpace="true" HeaderText="机床类型" />
                    <x:BoundField DataField="机床说明" SortField="机床说明" ExpandUnusedSpace="true" HeaderText="机床说明" />
                    <x:BoundField DataField="内部成本" SortField="内部成本" ExpandUnusedSpace="true" HeaderText="内部成本" />
                    <x:BoundField DataField="内部价格" SortField="内部价格" ExpandUnusedSpace="true" HeaderText="内部价格" />
                    <x:BoundField DataField="工时数" SortField="工时数" ExpandUnusedSpace="true" HeaderText="工时数" />
                    <x:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑" WindowID="Window1"
                        Title="编辑" DataIFrameUrlFields="QuotationDetailsID" DataIFrameUrlFormatString="~/pms_Quotation_Info_edit.aspx?id={0}"
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
