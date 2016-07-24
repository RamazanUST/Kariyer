<%@ Page Title="Cv Eğitim Düzenle" Language="C#" MasterPageFile="~/Master/IsArayan.Master" AutoEventWireup="true" CodeBehind="Egitim.aspx.cs" Inherits="Kariyer.IsArayan.Egitim" %>

<%@ Register Src="~/Uc/CvDuzenle.ascx" TagPrefix="uc1" TagName="CvDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <uc1:CvDuzenle runat="server" ID="CvDuzenle" />
        <div class="row">
        <div class="col-md-6">
            <div class="heading style-3 sm">
                <h3>Özgeçmiş Düzenle<span class="main-color"> / Eğitim Bilgileri</span></h3>
            </div>
        </div>
        <div class="col-md-6 text-right">
            <a href="Kariyer.aspx" class="main-color" style="cursor: pointer;"><i class="fa fa-share"></i>&nbsp; Sonraki Adıma Geç</a>
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
