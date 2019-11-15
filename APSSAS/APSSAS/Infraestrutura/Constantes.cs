
namespace APSSAS.Infraestrutura
{
    public static class ConstanteProcesso
    {
        public const string ENCRYPT_VALUE = "E";
        public const string DECRYPT_VALUE = "D";

        public static Processo ConvertStringToEnum(string pValor)
        {
            switch (pValor)
            {
                default:
                case ENCRYPT_VALUE: return Processo.Encrypt;
                case DECRYPT_VALUE: return Processo.Decrypt;
            }
        }
    }

    public static class ConstanteCriptografia
    {
        public const string BASE64_VALUE = "Base64";
        public const string RSA_VALUE = "RSA";
        public const string DES_VALUE = "DES";
        public const string AES_VALUE = "AES";

        public static Criptografia ConvertStringToEnum(string pValor)
        {
            switch (pValor)
            {
                default:
                case BASE64_VALUE: return Criptografia.Base64;
                case DES_VALUE: return Criptografia.DES;
                case AES_VALUE: return Criptografia.AES;
            }
        }
    }
}