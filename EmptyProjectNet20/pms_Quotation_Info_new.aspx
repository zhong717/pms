<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_Quotation_Info_new.aspx.cs" Inherits="EmptyProjectNet20.pms_Quotation_Info_new" %>

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
            <x:DropDownList runat="server" ID="ddlMec" Label="请选择机床" AutoPostBack="true" ShowRedStar="true"></x:DropDownList>
            <x:TextBox ID="tbxHour" runat="server" Label="纯切削工时" Required="true" ShowRedStar="true" OnTextChanged="tbxHour_Changed" AutoPostBack="true"></x:TextBox> 
            <x:TextBox ID="tbxPeriod" runat="server" Label="加工周期(H)" Required="true" ShowRedStar="true" OnTextChanged="tbxPeriod_Changed" AutoPostBack="true"></x:TextBox>
            <x:Label ID="lbtext" runat="server" Text="纯切削工时=加工周期*0.52" Label="说明"></x:Label>
        </Items>
    </x:SimpleForm>
    </form>
</body>
</html>
