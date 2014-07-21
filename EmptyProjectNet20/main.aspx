<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FineUIDemo.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .top-header .title
        {
            text-align:center;
            font-size: 28px;
            line-height: 50px;
            margin: 0 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></x:PageManager>
    <x:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>  
            <x:Region runat="server" Position="Top" ShowBorder="false" ShowHeader="false" Height="80px"
                Layout="Fit">
                <Items>
                    <x:ContentPanel runat="server" CssClass="top-header" ShowBorder="false" ShowHeader="false"
                        EnableBackgroundColor="true">
                        <div class="title">
                            生产管理系统
                        </div>
                    </x:ContentPanel>
                </Items>
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server" Position="Bottom">
                        <Items>
                            <x:Label ID="lbname" runat="server" Label="" Text="欢迎您:"></x:Label>
                            <x:ToolbarSeparator ID="tbspe" runat="server"></x:ToolbarSeparator>
                            <x:Label ID="lbdate" runat="server" Label="" Text="当前时间:"></x:Label>
                            <x:ToolbarFill ID="tbfill" runat="server"></x:ToolbarFill>
                            <x:Button ID="btnlogout" runat="server" Text="注销" Icon="Picture" OnClick="btnlogout_Click"></x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
            </x:Region>
            <x:Region ID="Region2" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                Margins="0 0 0 0" ShowHeader="false" Title="菜单" EnableLargeHeader="false" Icon="Outline"
                EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Items>
                    <x:Tree runat="server" ID="leftTree" Title="菜单" ShowBorder="false" EnableArrows="true" EnableSingleExpand="true">
                    </x:Tree>
                </Items>
            </x:Region>
            <x:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Items>
                    <x:TabStrip ID="mainTabStrip" ShowBorder="false" runat="server">
                        <Tabs>
                            <x:Tab runat="server" Title="首页" EnableIFrame="true" IFrameUrl="~/pms_User_Info.aspx"
                                IFrameName="mainframe">
                            </x:Tab>
                        </Tabs>
                    </x:TabStrip>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/menu.xml">
    </asp:XmlDataSource>
    </form>

    <script>

        var leftTreeID = '<%= leftTree.ClientID %>';
        var mainTabStripID = '<%= mainTabStrip.ClientID %>';
        
        
        function onReady() {

            X.util.initTreeTabStrip(X(leftTreeID), X(mainTabStripID), null, false, true, true);

        }


    
    </script>

</body>
</html>
