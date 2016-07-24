<%@ Page Title="Prism Akademi | Parola Değiştir" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ParolaYeni.aspx.cs" Inherits="Kariyer.ParolaYeni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <div class="md-padding">
        <div class="container">
            <div class="row">
                <div class="wid-40 gry-bg tbl ">
                    <div class="modal-body">
                        <h4>Parola Değiştir</h4>
                        <hr class="colorgraph" />
                        <asp:Literal runat="server" ID="K_MESAJ"></asp:Literal>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="K_SİFRE" CssClass="form-control" MinLength="5" TextMode="Password" placeholder="Parola"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R_SIFRE" ControlToValidate="K_SİFRE" Display="Dynamic" CssClass="req" runat="server" ErrorMessage="Şifre boş geçilemez."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="K_SİFRE" ID="RG_SIFRE" ValidationExpression="^[\s\S]{5,15}$" runat="server" ErrorMessage="* Parolanız 5 ile 15 karakter arasında olmalıdır." CssClass="req"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="K_SİFRE_TEKRAR" TextMode="Password" CssClass="form-control" MinLength="5" placeholder="Parola Tekrar"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R_SİFRE_TEKRAR" ControlToValidate="K_SİFRE_TEKRAR" Display="Dynamic" CssClass="req" runat="server" ErrorMessage="Şifre tekrarı boş geçilemez."></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="RH_SİFRE_TEKRAR" ControlToValidate="K_SİFRE_TEKRAR" ControlToCompare="K_SİFRE" runat="server" Display="Dynamic" CssClass="req" ErrorMessage="* Şifreler uyuşmuyor."></asp:CompareValidator>
                        </div>
                        <hr class="colorgraph" />
                        <div class="modal-footer p-a-0">
                            <div>
                                <asp:Button runat="server" ID="K_OK" class="btn btn-info btn-lg btn-block" Text="Parolayı Değiştir" OnClick="K_OK_Click" />
                            </div>
                            <div class="p-t-2">
                                <a href="Login.aspx" class="btn btn-link no-padding"><i class="fa fa-key"></i>Benim Hesabım</a>
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
