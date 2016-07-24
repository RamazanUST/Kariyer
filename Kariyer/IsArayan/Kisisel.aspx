<%@ Page Title="Cv Kişisel Bilgileri Düzenle" Language="C#" MasterPageFile="~/Master/IsArayan.Master" AutoEventWireup="true" CodeBehind="Kisisel.aspx.cs" Inherits="Kariyer.IsArayan.Kisisel" %>

<%@ Register Src="~/Uc/CvDuzenle.ascx" TagPrefix="uc1" TagName="CvDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <uc1:CvDuzenle runat="server" ID="CvDuzenle" />
    <div class="row">
        <div class="col-md-6">
            <div class="heading style-3 sm">
                <h3>Özgeçmiş Düzenle<span class="main-color"> / Kişisel Bilgiler</span></h3>
            </div>
        </div>
        <div class="col-md-6 text-right">
            <a href="Iletisim.aspx" class="main-color" style="cursor: pointer;"><i class="fa fa-share"></i>&nbsp; Sonraki Adıma Geç</a>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="UP_LEO">
        <ContentTemplate>
            <asp:Literal runat="server" ID="K_MESAJ"></asp:Literal>
            <div class="row">
                <div class="col-md-2 baslik">Adınız<span class="z">*</span></div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="K_AD" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="R_AD" ControlToValidate="K_AD" runat="server" Display="Dynamic" ErrorMessage="* Ad boş geçilemez." CssClass="req"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2 baslik">Soyadınız<span class="z">*</span></div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="K_SOYAD" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="R_SOYAD" ControlToValidate="K_SOYAD" Display="Dynamic" runat="server" ErrorMessage="* Soyad boş geçilemez." CssClass="req"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2 baslik">Doğum Yeri</div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="K_DOGUM_YER" CssClass="form-control" MaxLength="100"></asp:TextBox>
                </div>
                <div class="col-md-6 cvaciklama">
                    Eğer belirtmek istiyorsanız, doğum yerinizi ilçe / şehir / ülke olarak giriniz.
                        <span class="ornek">Örnek: Şişli / İstanbul / Türkiye</span>
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2 baslik">Doğum Tarihiniz<span class="z">*</span></div>
                <div class="col-md-4">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="K_GUN" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="K_AY" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="K_YIL" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <asp:CustomValidator runat="server" ID="R_TARIH" ErrorMessage="* Doğum tarihinizi belirtiniz." OnServerValidate="CustomValidator1_ServerValidate1" ClientValidationFunction="ValidateDogumTarih" Display="Dynamic" CssClass="req" EnableClientScript="true"></asp:CustomValidator>
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2 baslik">Cinsiyetiniz<span class="z">*</span></div>
                <div class="col-md-4">
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="K_ERKEK" GroupName="Cinsiyet" onchange="ErkekSec();" />
                        Erkek
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="K_KADIN" GroupName="Cinsiyet" onchange="KadinSec();"/>
                        Kadın
                    </label>
                    <asp:CustomValidator runat="server" ID="R_VINSIYET" ErrorMessage="<br />* Cinsiyet seçiniz." OnServerValidate="CustomValidator1_ServerValidate" ClientValidationFunction="ValidateCinsiyet" Display="Dynamic" CssClass="req" EnableClientScript="true"></asp:CustomValidator>
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2 baslik">Medeni Durum<span class="z">*</span></div>
                <div class="col-md-4">
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="K_BEKAR" GroupName="Medeni" />
                        Bekar
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="K_EVLI" GroupName="Medeni" />
                        Evli
                    </label>
                    <asp:CustomValidator runat="server" ID="R_MEDENI" ErrorMessage="<br />* Medeni durumunuzu belirtiniz." OnServerValidate="CustomValidator2_ServerValidate" ClientValidationFunction="ValidateMedeniDurum" Display="Dynamic" CssClass="req" EnableClientScript="true"></asp:CustomValidator>
                </div>
            </div>
            <div class="row p-t-2" id="asker">
                <div class="col-md-2 baslik">Askerlik Durumu<span class="z">*</span></div>
                <div class="col-md-4">
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="K_YAPILDI" GroupName="Asker" onchange="AskerTarihAc();" Checked="true" />
                        Yapıldı
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="K_MUAF" GroupName="Asker" onchange="AskerTarihKapa();" />
                        Muaf
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="K_TECIL" GroupName="Asker" onchange="AskerTarihAc();" />
                        Tecilli
                    </label>
                    <div class="form-inline p-t-1" id="askerTarih">
                        <span>Tarih:</span>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="K_AS_AY" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="K_AS_YIL" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-inline p-t-1" id="askerTecil" style="display:none">
                        <span>Tarih:</span>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="K_TECIL_AY" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="K_TECIL_YIL" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <asp:CustomValidator runat="server" ID="CustomValidator1" ErrorMessage="* Medeni durumunuzu belirtiniz." ClientValidationFunction="ValidateMedeniDurum" Display="Dynamic" CssClass="req" EnableClientScript="true"></asp:CustomValidator>
                </div>
                <div class="col-md-6 cvaciklama">
                    Askerlik durumunun seçilmesi erkek adaylar için zorunludur. Eğer tecilli ve muaf iseniz, tarih alanının girilmesi zorunludur. 
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2 baslik">Üyelikler</div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="K_UYE" CssClass="form-control" TextMode="MultiLine" MaxLength="500" Rows="3"></asp:TextBox>
                </div>
                <div class="col-md-6 cvaciklama">
                    Üye olduğunuz ve işverenlerin özgeçmişinizde görüntülemesini istediğiniz toplulukları burada belirtebilirsiniz.<br />
                    <span class="ornek">Örnek: Öğrenci Kulüpleri, İşadamları Dernekleri, Sivil Toplum Kuruluşları</span>
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2 baslik">Hobiler</div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="K_HOBI" CssClass="form-control" TextMode="MultiLine" MaxLength="500" Rows="3"></asp:TextBox>
                </div>
                <div class="col-md-6 cvaciklama">
                    Özgeçmişinizde görüntülenmesini istediğiniz hobilerinizi burada belirtebilirsiniz.
                </div>
            </div>
            <div class="row p-t-2">
                <div class="col-md-2"></div>
                <div class="col-md-3">
                    <asp:LinkButton runat="server" ID="K_OK" CssClass="btn btn-primary"><i class="fa fa-save fa-lg"></i>&nbsp;Kaydet ve İlerle</asp:LinkButton>
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
    <script src="../Content/js/page/kisisel.js"></script>
</asp:Content>
