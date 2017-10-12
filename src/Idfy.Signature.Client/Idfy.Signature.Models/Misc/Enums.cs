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

    public enum Addon
    {
        personal_info,
        person_credit_check,
        business_credit_check,
        rights_and_prokura
    }

}