<%@ Page Title="Özgeçmiş Düzenle / Giriş" Language="C#" MasterPageFile="~/Master/IsArayan.Master" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="Kariyer.IsArayan.Giris" %>

<%@ Register Src="~/Uc/CvDuzenle.ascx" TagPrefix="uc1" TagName="CvDuzenle" %>


<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <uc1:CvDuzenle runat="server" ID="CvDuzenle" />
    <div class="row">
        <div class="col-md-6">
            <div class="heading style-3 sm">
                <h3>Özgeçmiş Düzenle<span class="main-color"> / Giriş</span></h3>
            </div>
        </div>
        <div class="col-md-6 text-right">
            <a href="Kisisel.aspx" class="main-color" style="cursor: pointer;"><i class="fa fa-share"></i>&nbsp; Sonraki Adıma Geç</a>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="UP_LEO">
        <ContentTemplate>
            <asp:Literal runat="server" ID="K_MESAJ"></asp:Literal>
            <div class="row">
                <div class="col-md-2 baslik">Özgeçmiş Başlık</div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="K_BASLIK" CssClass="form-control" MaxLength="250"></asp:TextBox>
                </div>
                <div class="col-md-6 cvaciklama">
                    Sizi ifade eden ve sizi diğer adaylar içinden özgeçmişinizi farklılaştıracak bir başlık girebilirsiniz. Satış Rekortmeni, Deneyimli Bankacı
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 baslik">Meslek / Ünvan</div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="K_MESLEK" CssClass="form-control" MaxLength="250"></asp:TextBox>
                </div>
                <div class="col-md-6 cvaciklama">
                    Mesleğinizi veya kendinizi konumlandırdığınız pozisyonu giriniz.<span class="ornek">Örnek: Yönetici Asistanı, Sosyal Medya Uzmanı, Yönetici</span>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 baslik">İş Arama Durumu<span class="z">*</span></div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="K_IS_DURUM" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="R_IS_DURUM" ControlToValidate="K_IS_DURUM" runat="server" Display="Dynamic" ErrorMessage="* İş arama durumunu seçiniz." InitialValue="0" CssClass="req"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-6 cvaciklama">
                    İş arama durumunuzu listeden seçiniz. Bu bilgi, özgeçmişinizin değerlendirilmesi sırasında oldukça önemlidir. 
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2"></div>
                <div class="col-md-3">
                    <asp:LinkButton runat="server" ID="K_OK" CssClass="btn btn-primary" OnClick="K_OK_Click"><i class="fa fa-save fa-lg"></i>&nbsp;Kaydet ve İlerle</asp:LinkButton>
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2"></div>
                <div class="col-md-5">
                    <span class="z">*</span> ile belirtilen alanların doldurulması zorunludur.
                </div>
            </div>
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
