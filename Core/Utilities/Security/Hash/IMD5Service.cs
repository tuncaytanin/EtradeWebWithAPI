namespace Core.Utilities.Security.Hash
{
    public interface IMD5Service
    {
        string ConvertTextToMD5(string text);
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
