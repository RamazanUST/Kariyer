<%@ Page Title="Prism Akademi | Kullanıcı Kayıt" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="KullaniciKayit.aspx.cs" Inherits="Kariyer.KullaniciKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <div class="container p-t-2">
        <h3>Özgeçmiş Bırak</h3>
        <hr />
    </div>
    <div class="sm-padding">
          <div class="container">
        <div class="row">
            <div class="col-md-12 contact-form">
                <asp:UpdatePanel runat="server" ID="UP_LEO">
                    <ContentTemplate>
                        <asp:Literal runat="server" ID="K_MESAJ"></asp:Literal>
                        <div class="row">
                            <div class="col-md-2 baslik">Adınız<span class="z">*</span></div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="K_AD" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R_AD" ControlToValidate="K_AD" runat="server" Display="Dynamic" ErrorMessage="* Ad boş geçilemez." CssClass="req"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row p-t-2">
                            <div class="col-md-2 baslik">Soyadınız<span class="z">*</span></div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="K_SOYAD" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R_SOYAD" ControlToValidate="K_SOYAD" Display="Dynamic" runat="server" ErrorMessage="* Soyad boş geçilemez." CssClass="req"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row p-t-2">
                            <div class="col-md-2 baslik">E-Posta Adresiniz<span class="z">*</span></div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="K_EPOSTA" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R_EPOSTA" ControlToValidate="K_EPOSTA" Display="Dynamic" runat="server" ErrorMessage="* E-posta adresi boş geçilemez." CssClass="req"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="R_EPOSTA_CONTROL" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="K_EPOSTA" CssClass="req" ErrorMessage="* Geçersiz e-posta adresi." Display="Dynamic"></asp:RegularExpressionValidator>

                            </div>
                            <div class="col-md-7 aciklama">
                                Sisteme giriş yaparken kullanmak istediğiniz e-posta adresini yandaki alana yazınız.
                            <span class="ornek">Örnek: ad_soyad@posta.com</span><br />
                                <br />
                                <span class="z">Uyarı:</span> Girilen e-posta adresine hesap doğrulama mesajı gönderileceği için, aktif olarak kullandığınız bir e-posta adresi belirtiniz.
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 baslik">Cinsiyetiniz<span class="z">*</span></div>
                            <div class="col-md-3">
                                <label class="radio-inline">
                                    <asp:RadioButton runat="server" ID="K_ERKEK" GroupName="Cinsiyet" />
                                    Erkek
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton runat="server" ID="K_KADIN" GroupName="Cinsiyet" />
                                    Kadın
                                </label>
                                <asp:CustomValidator runat="server" ID="R_VINSIYET" ErrorMessage="<br />* Cinsiyet seçiniz." OnServerValidate="CustomValidator1_ServerValidate" ClientValidationFunction="ValidateCinsiyet" Display="Dynamic" CssClass="req" EnableClientScript="true"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row p-t-2">
                            <div class="col-md-2 baslik">Şahsi Cep Telefonu<span class="z">*</span></div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="K_TELEFON" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R_TELEFON" ControlToValidate="K_TELEFON" Display="Dynamic" runat="server" ErrorMessage="* Cep telefonunuzu giriniz." CssClass="req"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RE_TELEFON" runat="server" ControlToValidate="K_TELEFON" ErrorMessage="* Telefon numarası geçersiz. " ValidationExpression="\d+" Display="Dynamic" CssClass="req"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-7 aciklama">
                                Size ulaşabileceğimiz özel cep telefonu numaranızı giriniz.
                            <span class="ornek">Örnek: 05554443322 | 5554443322</span>
                            </div>
                        </div>
                        <div class="row p-t-2">
                            <div class="col-md-2 baslik">Doğum Tarihiniz<span class="z">*</span></div>
                            <div class="col-md-3">
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
                            <div class="col-md-2 baslik">Medeni Durum<span class="z">*</span></div>
                            <div class="col-md-3">
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
                        <div class="row p-t-2" id="divTc">
                            <div class="col-md-2 baslik">T.C. Kimlik Numaranız<span class="z">*</span></div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="K_TC" CssClass="form-control" MaxLength="11"></asp:TextBox>
                                <label class="radio-inline" style="margin-left: -20px;">
                                    <asp:CheckBox runat="server" ID="K_YABANCI" onchange="YabanciAc(this);" />
                                    Yabancı uyrukluyum
                                </label>
                                <asp:CustomValidator runat="server" ID="R_TC" ErrorMessage="<br />* T.C. kimlik numarası geçerli değil." OnServerValidate="R_TC_ServerValidate" ClientValidationFunction="ValidateTc" Display="Dynamic" CssClass="req" EnableClientScript="true"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row p-t-2" id="divYabanci" style="display: none;">
                            <div class="col-md-2 baslik">Uyruğunuz<span class="z">*</span></div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="K_UYRUK" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                <label class="radio-inline" style="margin-left: -20px;">
                                    <asp:CheckBox runat="server" ID="K_TCLI" onchange="TcAc();" />
                                    T.C. uyrukluyum
                                </label>
                                <asp:CustomValidator runat="server" ID="R_UYRUK" ErrorMessage="<br />* Uyruk boş geçilemez." OnServerValidate="R_UYRUK_ServerValidate" ClientValidationFunction="ValidateUyruk" Display="Dynamic" CssClass="req" EnableClientScript="true"></asp:CustomValidator>

                            </div>
                            <div class="col-md-7 aciklama">
                                Uyruk adını yandaki alana yazınız.
                            <span class="ornek">Örnek: Almanya</span>
                            </div>
                        </div>
                        <div class="row p-t-2">
                            <div class="col-md-2 baslik">Şifreniz<span class="z">*</span></div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="K_SİFRE" CssClass="form-control" MinLength="5" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R_SIFRE" ControlToValidate="K_SİFRE" Display="Dynamic" CssClass="req" runat="server" ErrorMessage="Şifre boş geçilemez."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="K_SİFRE" ID="RG_SIFRE" ValidationExpression="^[\s\S]{5,15}$" runat="server" ErrorMessage="* Parolanız 5 ile 15 karakter arasında olmalıdır." CssClass="req"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-7">Şifreniz en az 5 karakter uzunluğunda olmalıdır. Aksi halde girilen şifre kabul edilmeyecektir.</div>
                        </div>
                        <div class="row p-t-2">
                            <div class="col-md-2 baslik">Şifre (Tekrar)<span class="z">*</span></div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="K_SİFRE_TEKRAR" TextMode="Password" CssClass="form-control" MinLength="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R_SİFRE_TEKRAR" ControlToValidate="K_SİFRE_TEKRAR" Display="Dynamic" CssClass="req" runat="server" ErrorMessage="Şifre tekrarı boş geçilemez."></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="RH_SİFRE_TEKRAR" ControlToValidate="K_SİFRE_TEKRAR" ControlToCompare="K_SİFRE" runat="server" Display="Dynamic" CssClass="req" ErrorMessage="* Şifreler uyuşmuyor."></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="row p-t-2">
                            <div class="col-md-2"></div>
                            <div class="col-md-3">
                                <asp:Button runat="server" ID="K_OK" Text="Hesabımı Oluştur" CssClass="btn btn-info" OnClick="K_OK_Click" />
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
            </div>
        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="J" runat="server">
    <script src="Content/js/page/kullaniciKayit.js"></script>
</asp:Content>
