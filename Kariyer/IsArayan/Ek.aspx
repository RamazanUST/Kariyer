<%@ Page Title="Cv Ek Düzenle" Language="C#" MasterPageFile="~/Master/IsArayan.Master" AutoEventWireup="true" CodeBehind="Ek.aspx.cs" Inherits="Kariyer.IsArayan.Ek" %>

<%@ Register Src="~/Uc/CvDuzenle.ascx" TagPrefix="uc1" TagName="CvDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <uc1:CvDuzenle runat="server" ID="CvDuzenle" />
    <div class="row">
        <div class="heading style-3 sm">
            <h3>Özgeçmiş Düzenle<span class="main-color"> / Ek Bilgiler</span></h3>
        </div>

    </div>
    <asp:UpdatePanel runat="server" ID="UP_LEO">
        <ContentTemplate>
            <asp:Literal runat="server" ID="K_MESAJ"></asp:Literal>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="prg">
        <ProgressTemplate>
            <div class="leo">
                <ul class="bokeh ">
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                </ul>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="J" runat="server">
</asp:Content>
