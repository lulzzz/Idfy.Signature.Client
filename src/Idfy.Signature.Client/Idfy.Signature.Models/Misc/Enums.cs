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
        matchit_personal_info,
        matchit_company_info,
        difi_company_info,
        personal_credit_check,
        business_credit_check,
        official_personal_info,
        aml_b2c_identify_and_screening,
    }

    public enum DocumentAddon
    {
        rights_and_prokura,
    }

    public enum SpesialProperty
    {
        bisnode_username,
        bisnode_password,
        include_pdf_reports,
        official_username,
        official_password,
        official_reason,
        official_system,
        aml_nationality,
        aml_language,
        aml_mode
    }

    public enum NotificationType
    {
        off,
        request,
        reminder,
        signature_receipt,
        final_receipt
    }

    public enum NotificationSetting
    {
        off,
        send_sms,
        send_email,
        send_both
    }

}