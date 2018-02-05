using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Idfy.Signature.Client.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Idfy.Signature.Models.Signers;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Client.Test
{
    [Ignore]
    [TestClass]
    public class SignClientTest
    {
        private ISignClient Client { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Client = new SignClient(
                Config.Get("ClientId"),
                Config.Get("ClientSecret"),
                Config.Get("Scope"),
                bool.Parse(Config.Get("IsProd"))
            );
            
            var overrideBaseUrl = Config.Get("BaseUrlOverride");
            var overrideOauthUrl = Config.Get("OauthUrlOverride");
            if(!string.IsNullOrWhiteSpace(overrideBaseUrl))
            {
                Client.OverrideBaseUrl = overrideBaseUrl;
            }
            if(!string.IsNullOrWhiteSpace(overrideOauthUrl))
            {
                Client.OverrideOauthTokenUrl = overrideOauthUrl; 
            }
        }

        private async Task<Models.Documents.CreateDocumentResponse> CreateDoc(Func<Models.Documents.CreateDocumentRequest, Models.Documents.CreateDocumentRequest> modifyDefault = null)
        {
            var model = modifyDefault?.Invoke(DefaultCreateRequest) ?? DefaultCreateRequest;
            return await Client.CreateDocument(model);
        }

        [TestMethod]
        public async Task CreateDocument()
        {
            var response = await CreateDoc();
            Assert.IsNotNull(response.Signers?[0]?.Url);

        }

        [TestMethod]
        public async Task GetDocument()
        {
            var createResponse = await CreateDoc(m => {
                m.Title = "MSTest: GetDocument";
                m.Description = "This is a document generated by MSTest method GetDocument";
                m.DataToSign.Base64Content = "VGhpcyBpcyBhIHRlc3QgZG9jdW1lbnQgYmxhYmxhYmxh";
                return m;
            });
            Assert.IsNotNull(createResponse.Signers?[0]?.Url, "Failed to create test document");
            await Task.Delay(1000);
            var getResponse = await Client.RetrieveDocument(createResponse.DocumentId);
            Assert.AreEqual(createResponse.Title, getResponse.Title);
            Assert.AreEqual(createResponse.Description, getResponse.Description);
        }

        #region Default models
        private readonly Models.Documents.CreateDocumentRequest DefaultCreateRequest = new Models.Documents.CreateDocumentRequest()
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
                        Notifications = new Notifications()
                        {
                            Setup = new Dictionary<NotificationType, NotificationSetting>()
                            {
                                {NotificationType.request, NotificationSetting.off }
                            }
                        },
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
        };
#endregion
    }
}
