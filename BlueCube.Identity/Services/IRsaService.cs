namespace BlueCube.Identity.Services;

public interface IRsaService
{
    (string publicKey , string privateKey) CreateKeys();
    string? Encrypt(string text, string publicKey);
    string? Decrypt(string encryptedText, string privateKey);
    string? Sign(string text, string privateKey);
    bool Verify(string text, string publicKey, string signature );
    string GetPublicKeyFromPrivateKey(string privateKey);
    string GetNormalizedPublicKey(string publicKey);
}