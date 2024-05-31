using Org.BouncyCastle.Crypto;

namespace BouncyCastleV2._4Triage;

public class PublicKey
{
    public PublicKey(AsymmetricKeyParameter value)
    {
        if (value.IsPrivate)
        {
            throw new ArgumentException("Expected a public key", nameof(value));
        }

        Value = value;
    }

    internal AsymmetricKeyParameter Value { get; }

    private bool Equals(PublicKey other)
    {
        return Equals(Value, other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PublicKey) obj);
    }

    public override int GetHashCode()
    {
        return (Value != null ? Value.GetHashCode() : 0);
    }
}