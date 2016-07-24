<%@ Page Title="Prism Akademi | Kullanıcı Girişi" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Kariyer.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <div class="md-padding">
        <div class="container">
            <div class="row">
                <div class="wid-40 gry-bg tbl ">
                    <div class="modal-body">
                        <h4>Kullanıcı Girişi</h4>
                        <hr class="colorgraph" />
                        <asp:Literal runat="server" ID="K_MESAJ"></asp:Literal>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="K_EPOSTA" class="form-control" placeholder="E-posta" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R_EPOSTA" ControlToValidate="K_EPOSTA" Display="Dynamic" runat="server" ErrorMessage="* E-posta adresi boş geçilemez." CssClass="req"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="R_EPOSTA_CONTROL" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="K_EPOSTA" CssClass="req" ErrorMessage="* Geçersiz e-posta adresi." Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="K_PAROLA" class="form-control" placeholder="Şifre" MaxLength="20" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R_SIFRE" ControlToValidate="K_PAROLA" Display="Dynamic" CssClass="req" runat="server" ErrorMessage="Şifre boş geçilemez."></asp:RequiredFieldValidator>
                        </div>
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox runat="server" ID="K_HATIRLA" />
                                Beni Hatırla  
                            </label>
                        </div>
                        <hr class="colorgraph">
                        <div class="modal-footer p-a-0">
                            <div>
                                <asp:Button runat="server" ID="K_OK" class="btn btn-primary btn-lg btn-block" Text="Giriş Yap" OnClick="K_OK_Click" />
                            </div>
                            <div class="p-t-2">
                                <a href="ParolaUnuttum.aspx" class="btn btn-link no-padding"><i class="fa fa-key"></i>Parolamı Unuttum?</a>
                                <a href="KullaniciKayit.aspx" class="btn btn-link no-padding"><i class="fa fa-user"></i>Özgeçmiş Bırak</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="J" runat="server">
</asp:Content>
