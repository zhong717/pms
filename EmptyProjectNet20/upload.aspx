<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="EmptyProjectNet20.upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        .photo {
            height: 150px;
            line-height: 150px;
            overflow: hidden;
        }
 
            .photo img {
                height: 150px;
                vertical-align: middle;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" />
        <x:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="550px" EnableFrame="false" EnableCollapse="true"
            ShowBorder="True" Title="表单" ShowHeader="True">
            <Items>
                <x:Image ID="imgPhoto" CssClass="photo" ImageUrl="~/res/images/login/login_4.png" ShowEmptyLabel="true" runat="server">
                </x:Image>
                <x:FileUpload runat="server" ID="filePhoto" ShowRedStar="false" ShowEmptyLabel="true"
                    ButtonText="上传个人头像" ButtonOnly="true" Required="false"
                    AutoPostBack="true" OnFileSelected="filePhoto_FileSelected">
                </x:FileUpload>
                <x:TextBox runat="server" Label="用户名" ID="tbxUserName" Required="true" ShowRedStar="true">
                </x:TextBox>
                <x:TextBox runat="server" Label="邮箱" ID="tbxEmail" Required="true" RegexPattern="EMAIL"
                    ShowRedStar="true">
                </x:TextBox>
                <x:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1"
                    Text="提交表单">
                </x:Button>
                <x:Button ID="btnDownload" runat="server" Text="下载" OnClick="btnDownload_Click">
                </x:Button>
                <x:Button ID="Button1" runat="server" Text="cookies" OnClick="Button1_Click">
                </x:Button>
                <x:Button ID="Button2" runat="server" Text="下载附件" OnClick="btnDownload_Click2"></x:Button>
                <x:Label ID="labResult" EncodeText="false" runat="server">
                </x:Label>
            </Items>
        </x:SimpleForm>
 
    </form>
</body>
</html>