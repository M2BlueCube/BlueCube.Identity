namespace LiteChat.Extensions;

public static class KeyManagements
{
    public const string DateOnlyRegex = @"20\d{2}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])*";
    public const string GuidRegex = @"^([0-9A-Fa-f]{8}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{12})$";
    
    private const int ByteCount = 16;
    
    public static Guid XorGuidCalculation(Guid first, Guid second)
    {
        var destByte = new byte[ByteCount];
        var guid1Byte = first.ToByteArray();
        var guid2Byte = second.ToByteArray();

        for (var i = 0; i < ByteCount; i++)
        {
            destByte[i] = (byte)(guid1Byte[i] ^ guid2Byte[i]);
        }

        return new Guid(destByte);
    }

    public static Guid XorStringCalculation(string firstStr, string secondStr)
    {
        var first = Guid.Parse(firstStr);
        var second = Guid.Parse(secondStr);

        return XorGuidCalculation(first, second);
    }
}
