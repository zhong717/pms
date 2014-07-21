<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Product_Info_new.aspx.cs" Inherits="EmptyProjectNet20.pms_Product_Info_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <x:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" EnableBackgroundColor="true" Title="SimpleForm">
        <Toolbars>
            <x:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <x:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存后关闭">
                    </x:Button>
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:TextBox ID="tbxProName" runat="server" Label="产品名称" Required="true" ShowRedStar="true"></x:TextBox>
            <x:DropDownList runat="server" ID="ddlReq" Label="顾客要求" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>
            <x:DropDownList runat="server" ID="ddlStr" Label="产品结构" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>
            <x:DropDownList runat="server" ID="ddlMet" Label="产品材质" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>
            <x:DropDownList runat="server" ID="ddlInd" Label="产品行业" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>
            <x:TextBox ID="tbxPic" runat="server" Label="图号" Required="true" ShowRedStar="true"></x:TextBox>
            <x:TextBox ID="tbxSta" runat="server" Label="规范" Required="true" ShowRedStar="true"></x:TextBox>
            <x:TextBox ID="tbxWei" runat="server" Label="净重(吨)" Required="true" ShowRedStar="true"></x:TextBox>
            <x:TextBox ID="tbxOrd" runat="server" Label="订单量" Required="true" ShowRedStar="true"></x:TextBox> 
            <x:TextBox ID="tbxRem" runat="server" Label="备注" Required="true" ShowRedStar="true"></x:TextBox> 
            <x:FileUpload runat="server" ID="filePhoto" EmptyText="多个附件请打包成一个上传" Label="附件"></x:FileUpload>
        </Items>
    </x:SimpleForm>
    </form>
</body>
</html>
