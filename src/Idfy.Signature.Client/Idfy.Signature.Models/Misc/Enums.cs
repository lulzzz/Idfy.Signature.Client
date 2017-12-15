namespace Idfy.Signature.Models.Misc
{
    public enum AttachmentType
    {
        show_accept,
        read_accept,
        sign
    }


    public enum SignatureMethod
    {
        no_bankid,
        no_buypass,
        no_commfides,
        sv_bankid,
        da_nemid,
        fi_tupas,
        fi_mobiilivarmenne,
        nl_digid,
        es_dni,
        ee_esteid,
        mobile_connect,
        sms_otp,
        identification_papers,
        social,
        unknown
    }

    public enum SignaturePackageFormat
    {
        xades,
        pades,
        no_bankid_pades,
    }

    public enum NotificationLanguage
    {
        en,
        no,
        da,
        sv,
        fi
    }

    public enum Language
    {
        browser,
        en,
        no,
        da,
        sv,
        fi
    }

    public enum RedirectMode
    {
        donot_redirect,
        redirect,
        iframe_with_webmessaging,
        iframe_with_redirect,
        iframe_with_redirect_and_webmessaging
    }

    public enum Mechanisms
    {
        pkisignature,
        eaccept,
    }

    public enum SignerAddon
    {
        matchitPersonalInfo,
        matchitCompanyInfo,
        difiCompanyInfo,
        personalCreditCheck,
        businessCreditCheck,
        officialPersonalInfo,
        amlB2cIdentifyAndScreening,
    }

    public enum DocumentAddon
    {
        rightsAndProkura,
    }

    public enum SpesialProperty
    {
        bisnodeUsername,
        bisnodePassword,
        includePdfReports,
        officialUsername,
        officialPassword,
        officialReason,
        officialSystem,
        amlNationality,
        amlLanguage,
        amlMode
    }

    public enum NotificationType
    {
        request,
        reminder,
        signatureReceipt,
        finalReceipt,
        canceled,
        expired
    }

    public enum NotificationSetting
    {
        off,
        sendSms,
        sendEmail,
        sendBoth
    }

}