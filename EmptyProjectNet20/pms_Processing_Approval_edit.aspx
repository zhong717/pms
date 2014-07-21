<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Processing_Approval_edit.aspx.cs" Inherits="EmptyProjectNet20.pms_Processing_Approval_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="5px" EnableLargeHeader="false"
        EnableBackgroundColor="true" ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" ShowHeader="false" Title="新产品录入">
        <Items>
            <x:Form ID="Form2" runat="server" Height="470px" BodyPadding="5px" ShowHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Toolbars>
                    <x:Toolbar ID="Toolbar2" runat="server" Position="Top">
                    <Items>
                        <x:Label ID="lbBatchID" runat="server" Label="报价单编号" Text="" ></x:Label> 
                    </Items>
                    </x:Toolbar>
                    <x:Toolbar ID="Toolbar3" runat="server" Position="Footer">
                    <Items>
                        <x:Button ID="btnSave" ValidateForms="Form2" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存"></x:Button>
                    </Items>
                    </x:Toolbar>
                </Toolbars>
                <Rows>
                    <x:FormRow ID="FormRow7" runat="server">
                        <Items> 
                            <x:Label ID="lbChar0" runat="server" Label="加工费用"></x:Label> 
                            <x:TextBox ID="tbxChar" runat="server" Label="领导建议" Required="true" ShowRedStar="true" 
                            OnTextChanged ="tbxChar_Click" AutoPostBack="true" Text="0"></x:TextBox> 
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:Label ID="lbChar2" runat="server" Label="说明"></x:Label> 
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:Label ID="lbPack0" runat="server" Label="包装费用" ></x:Label> 
                            <x:TextBox ID="tbxPack" runat="server" Label="领导建议" Required="true" ShowRedStar="true"
                            OnTextChanged ="tbxChar_Click" AutoPostBack="true" Text="0"></x:TextBox> 
                            
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:Label ID="lbPack2" runat="server" Label="说明"></x:Label>
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:Label ID="lbTest0" runat="server" Label="检测费用"></x:Label>
                            <x:TextBox ID="tbxTest" runat="server" Label="领导建议" Required="true" ShowRedStar="true"
                            OnTextChanged ="tbxChar_Click" AutoPostBack="true" Text="0"></x:TextBox> 
                            
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:Label ID="lbTest2" runat="server" Label="说明"></x:Label> 
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow8" runat="server">
                        <Items> 
                            <x:Label ID="lbTrans0" runat="server" Label="运输费用"></x:Label>
                            <x:TextBox ID="tbxTrans" runat="server" Label="领导建议" Required="true" ShowRedStar="true"
                            OnTextChanged ="tbxChar_Click" AutoPostBack="true" Text="0"></x:TextBox> 
                            
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow4" runat="server">
                        <Items> 
                            <x:Label ID="lbTrans2" runat="server" Label="说明"></x:Label>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow6" runat="server">
                        <Items> 
                            <x:Label ID="lbPrice0" runat="server" Label="单件合计" CssClass="highlight" ></x:Label> 

                            <x:Label ID="lbPrice1" runat="server" Label="最终单件合计" CssClass="highlight"></x:Label>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow2" runat="server" >
                        <Items> 
                            <x:Label ID="tbxPrice" runat="server" Label="上浮比例 %" CssClass="highlight"></x:Label>
                            <x:Label ID="lbUPrice0" runat="server" Label="吨单价" CssClass="highlight"></x:Label>
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:Label ID="lbKnife0" runat="server" Label="刀具费用"></x:Label> 
                            <x:TextBox ID="tbxKnife" runat="server" Label="领导建议" Required="true" ShowRedStar="true"
                            OnTextChanged ="tbxChar_Click" AutoPostBack="true" Text="0"></x:TextBox>
                             
                        </Items>
                    </x:FormRow>
                    <x:FormRow>
                        <Items>
                            <x:Label ID="lbKnife2" runat="server" Label="说明"></x:Label>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow5" runat="server">
                        <Items> 
                            <x:Label ID="lbTool0" runat="server" Label="工装费用"></x:Label>
                            <x:TextBox ID="tbxTool" runat="server" Label="领导建议" Required="true" ShowRedStar="true"
                            OnTextChanged ="tbxChar_Click" AutoPostBack="true" Text="0"></x:TextBox> 
                             
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow9" runat="server">
                        <Items> 
                            <x:Label ID="lbTool2" runat="server" Label="说明"></x:Label> 
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items> 
                            <x:Label ID="lbPriceOnce0" runat="server" Label="一次性投入合计" CssClass="highlight" ></x:Label> 
                            <x:Label ID="lbPriceOnce1" runat="server" Label="一次性投入合计" CssClass="highlight"></x:Label>
                        </Items>
                    </x:FormRow>             
                    <x:FormRow>
                        <Items>
                            <x:TextArea ID="tbxRemark" runat="server" Label="审批意见"></x:TextArea> 
                            <x:Button ID="btnDownload" runat="server" Text="下载附件" OnClick="btnDownload_Click"
                            EnableAjax="false" DisableControlBeforePostBack="false"></x:Button> 
                        </Items>
                    </x:FormRow> 
                </Rows>  
            </x:Form>
            <x:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                EnableCheckBoxSelect="false" EnableRowNumber="true" DataKeyNames="QuotationDetailsID" AllowSorting="true"
                OnSort="Grid1_Sort" SortColumnIndex="0" SortDirection="DESC" AllowPaging="true"
                IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound" OnPageIndexChange="Grid1_PageIndexChange">
                <Columns>
                    <x:BoundField DataField="报价单ID" SortField="报价单ID" ExpandUnusedSpace="true" HeaderText="报价单ID" />
                    <x:BoundField DataField="机床类型" SortField="机床类型" ExpandUnusedSpace="true" HeaderText="机床类型" />
                    <x:BoundField DataField="机床说明" SortField="机床说明" ExpandUnusedSpace="true" HeaderText="机床说明" />
                    <x:BoundField DataField="内部成本" SortField="内部成本" ExpandUnusedSpace="true" HeaderText="内部成本" />
                    <x:BoundField DataField="内部价格" SortField="内部价格" ExpandUnusedSpace="true" HeaderText="内部价格" />
                    <x:BoundField DataField="工时数" SortField="工时数" ExpandUnusedSpace="true" HeaderText="工时数" />
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
