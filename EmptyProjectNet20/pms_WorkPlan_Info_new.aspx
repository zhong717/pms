<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pms_WorkPlan_Info_new.aspx.cs" Inherits="EmptyProjectNet20.pms_WorkPlan_Info_new" %>

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
            <x:DatePicker ID="da1" runat="server" Label="计划月份" DateFormatString="yyyy-MM"></x:DatePicker>
            <x:DropDownList runat="server" ID="ddlType" Label="工作项目" AutoPostBack="true"></x:DropDownList>
            <x:DropDownList runat="server" ID="ddlCont" Label="工作内容" AutoPostBack="true"></x:DropDownList>
            <x:TextArea runat="server" ID="txaPlan" Label="计划任务" AutoPostBack="true" ShowRedStar="true"></x:TextArea> 
            <x:DropDownList runat="server" ID="ddlRept" Label="责任人" AutoPostBack="true"></x:DropDownList> 
        </Items>
    </x:SimpleForm>
    </form>
</body>
</html>
