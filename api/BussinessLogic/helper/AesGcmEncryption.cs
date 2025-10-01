using System.Security.Cryptography;
using System.Text;

public sealed class AesGcmEncryption
{
    private readonly byte[] _key;

    public AesGcmEncryption(byte[] key)
    {
        if (key is null || key.Length != 32) throw new ArgumentException("Key must be 32 bytes");
        _key = key;
    }

    public string Encrypt(string plaintext, byte[]? aad = null)
    {
        byte[] nonce = RandomNumberGenerator.GetBytes(12);
        byte[] pt = Encoding.UTF8.GetBytes(plaintext);
        byte[] ct = new byte[pt.Length];
        byte[] tag = new byte[16];

        using var aes = new AesGcm(_key);
        aes.Encrypt(nonce, pt, ct, tag, aad);

        // Pack: nonce | ct | tag
        byte[] output = new byte[nonce.Length + ct.Length + tag.Length];
        Buffer.BlockCopy(nonce, 0, output, 0, nonce.Length);
        Buffer.BlockCopy(ct, 0, output, nonce.Length, ct.Length);
        Buffer.BlockCopy(tag, 0, output, nonce.Length + ct.Length, tag.Length);

        return Convert.ToBase64String(output);
    }

    public string Decrypt(string base64, byte[]? aad = null)
    {
        byte[] input = Convert.FromBase64String(base64);
        if (input.Length < 12 + 16) throw new ArgumentException("Ciphertext too short");

        byte[] nonce = new byte[12];
        byte[] tag = new byte[16];
        int ctLen = input.Length - nonce.Length - tag.Length;

        byte[] ct = new byte[ctLen];

        Buffer.BlockCopy(input, 0, nonce, 0, nonce.Length);
        Buffer.BlockCopy(input, nonce.Length, ct, 0, ctLen);
        Buffer.BlockCopy(input, nonce.Length + ctLen, tag, 0, tag.Length);

        byte[] pt = new byte[ctLen];
        using var aes = new AesGcm(_key);
        aes.Decrypt(nonce, ct, tag, pt, aad);

        return Encoding.UTF8.GetString(pt);
    }
}
