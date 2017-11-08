using System;
using System.Threading.Tasks;
using Idfy.Signature.Client.Client;
using Idfy.Signature.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Idfy.Signature.Models;

namespace Idfy.Signature.Client.Test
{
    [TestClass]
    public class SignClientTest
    {
        private const string AccountId = "a1bc7cef-9654-41ca-85ca-a768006d82a0";
        private const string ClientId = "64b15eda-2a76-40a8-b08b-e4f38293a5c8";
        private const string ClientSecret = "928iqxEZHLBpqzr6VgkBk6gGO12QODOSzU6/fEyvb4g=";
        private const string Scope = OauthScopes.Root;
        private const bool IsProd = false;

        private ISignClient Client { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Client = new SignClient(
                Guid.Parse(AccountId),
                ClientId,
                ClientSecret,
                Scope,
                IsProd
            );
        }

        [TestMethod]
        public async Task CreateDocument()
        {
            var response = await Client.CreateDocument(new Models.Documents.CreateDocumentRequest()
            {
                Title = "Test document",
                Description = "This is the description",
                ContactDetails = new Models.Misc.ContactDetails()
                {
                    Name = "Ingolf Kvamme",
                    Email = "ingolf@idfy.io",
                    Phone = "99999999",
                    Url = "ingolf.idfy.io"
                },
                ExternalId = "123123123-1231231-23123123",
                Signers = new System.Collections.Generic.List<Models.Signers.Signer>() {
                    new Models.Signers.Signer()
                    {
                        ExternalSignerId = "Hello",
                        SignerInfo = new Models.Signers.SignerInfo()
                        {
                            FirstName = "Ingolf",
                            LastName = "Kvamme",
                            Email = "ingolf@idfy.io",

                            Mobile = new Models.Misc.Mobile()
                            {
                                CountryCode = "47",
                                Number = "92635490"
                            },
                            OrganizationInfo = new Models.Signers.OrganizationInfo()
                            {
                                CompanyName = "Ingolf's Sykkel Supreme",
                                CountryCode = "47",
                                OrgNo = "1234567890"
                            },
                        },
                        RedirectSettings = new Models.Signers.RedirectSettings()
                        {
                            Cancel = "www.vg.no",
                            Error = "www.vg.no",
                            RedirectMode = Models.Misc.RedirectMode.redirect,
                            Success = "www.vg.no",
                        },
                        NotificationsEnabled = true,
                        SignatureType = new Models.Signers.SignatureType()
                        {
                            SignatureMethods = new System.Collections.Generic.List<Models.Misc.SignatureMethod>()
                            {
                                Models.Misc.SignatureMethod.no_bankid
                            },
                            Mechanism = Models.Misc.Mechanisms.pkisignature
                        }
                    }
                },
                DataToSign = new Models.Misc.DataToSign()
                {
                    FileName = "data.txt",
                    Base64Content = "RGV0dGUgZXIgYmFzZSA2NCBlbmNvZGVkIHRla3N0",
                    ConvertToPDF = true,
                    Packaging = new Models.Misc.Packaging()
                    {
                        PadesSettings = new Models.Misc.PadesSettings()
                        {
                            PrimaryLanguage = Models.Misc.NotificationLanguage.no,
                            SecondaryLanguage = Models.Misc.NotificationLanguage.en
                        }
                    }
                }
            });
            Assert.IsNotNull(response.Signers?[0]?.Url);
        }
    }
}
