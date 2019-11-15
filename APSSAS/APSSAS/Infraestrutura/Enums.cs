using System.ComponentModel;

namespace APSSAS.Infraestrutura
{
    public enum Processo
    {
        [Description("Criptografar")]
        [DefaultValue("C")]
        Encrypt,
        [Description("Descriptografar")]
        [DefaultValue("D")]
        Decrypt
    }

    public enum Criptografia
    {
        [Description("Base 64")]
        [DefaultValue("Base64")]
        Base64,
        [Description("DES")]
        [DefaultValue("DES")]
        DES,
        [Description("AES")]
        [DefaultValue("AES")]
        AES
    }
}