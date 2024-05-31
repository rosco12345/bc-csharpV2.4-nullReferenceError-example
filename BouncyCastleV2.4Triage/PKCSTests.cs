using NUnit.Framework;

namespace BouncyCastleV2._4Triage;

[TestFixture]
public class PkcsTests
{
    internal const string c_FirstKey2048 = @"-----BEGIN RSA PRIVATE KEY-----
    MIIEpQIBAAKCAQEAqOuDYwlPRxr/nmIfIsW9f++XxWppVDI+Co5h56g3YP8wlc4b
    ptrMCoRWo5BPyEVw+aNzkKz5V0ZDXbPiw1Hpc5maoX44oxbeHBLf1t8zOkP0Svn+
    ofBsaGhGnpMoIVBcBQqIDHBK1lOzHQwJb8QNi+/5/durLq5N3UkrBQY8ulUsfJye
    r88xS2h1/d/XKMJOV3zhbw5UEkiyf3vCsf3vvuYX98EsgX6/aR00ZEFk8R2kMc0m
    CdYlbVvIZexIyj/zRgq2OArfkNgH/MkECT++SqkIkpwT6wSzEQQgb/5RLv28Aq4p
    tNxYO4Y6ufe0FHE6d+lfeBuk+gEfvd+AxWmSiQIDAQABAoIBAQCnKtOOuhLbwos/
    2ckIZ3qe1qRzOVjdew9M8RVQ5XdQpZsWVa+l05fjvI3lNpbOEnK4ipp+jcAAL8fR
    PolmVHTc8yFFOp2gQKw0SjV89sxCmCd136uv5TfTp4ZjviwTs+wtDPwQmzxkmNaE
    I3pfQj1JxIa5RKBHBTaHjLZnNYH5v14iTGiFZyacIPAxNBS65RhxQQDgaLq3+XDy
    CEn3UVJVWrHmZCUKuu+N/24C1zEIr1FoWI4/ytLWR0b/XdnscfGZAYDvGiNjHaKB
    LArZiC2Hq19FyXH73CGkezc7I0RU64TSZHkf0gLrSm/l1hsYrf5BHxHA6yOHJ6XI
    a3cW7zgBAoGBAN+9YXw3XhC+2TfBchyKRTN8B3i0e6yIq73aKHP68JxoiHTTPFgx
    hW/S31/vDHRhGi/2e0rcYVnKqq7YvVZ+ACMF6wr5ctJIPSjQvPQh2C5FwbYNQA6H
    VMnTTTvskxt09R6l4srn+Yeng44O1ZWPfHWUh50MsbEqqrWcCBe1+M8BAoGBAMFG
    o74bbsND294mbx5fFyAI11VTszG3aEHz5Xhj+7X3SW1IlG5Ca2HbxUKoOQyWeDnb
    1J9rnJSHbaxwIgvKkf4s+80r+ZiDo20+D0pyGmlTbbH7ZWBu3G7TahcYOWUhlGdj
    undy+DCINgWr7ThHfqmyJNb26xLWVs8987ikHcuJAoGBAKxsvFYILVvmWGxZjmFk
    RdRZf0CMhsr+QKx9FbPb7dX70T2HFPg6ocT909uQ1B5UPuQ7peSZVgTm5Qb+TVv8
    mopjIzI/7zcTKN7tjtDtzDZM1+4+4+DOdo9bYigON4hvaAAIg3EvuOPMOtwdnog2
    HgpXPvPPNpl8cjanWq07NdYBAoGBAKzRZQhPrzKaMrbo1uLpU9wpC6IYPVpvDKIs
    WzrS6/dBLj6xb0dHzIyr3i5EDP7cbJQPpIcHyfJlRgOyID862l/UCTLj50IgMrkz
    jKicblFPb/59M6COgDv4fhw4ZNmwtOndmpXED3gV03guyuZPx0olKBuunXMyhFy6
    oHqxBJNBAoGATOpsOyPfOa12ICXN0gJgOjEMrP4SZiQBgZcoKSgYV4+bSj1w5v7u
    mUeGgv8e8dqoK+HLBU1rjDgflqB0/WSP/TVlbLhJxtTA4gT4eqQJQ4/Tp6Fi2DvS
    epqP7fy9XFIdrTOF1OqElJiZUhkA7Sjy/eh4NUS7u2yVsjj7QUF4188=
    -----END RSA PRIVATE KEY-----
    ";
    
    [TestCase("test")]
    public void ExampleStringsRoundtrip(string originalString)
    {
        var keyPair = KeyToStringConverter.LoadKeyPair(c_FirstKey2048);
        string encrypted = PKCS.Encrypt(keyPair.PublicKey, originalString);
        string decrypted = PKCS.Decrypt(keyPair.PrivateKey, encrypted);

        Assert.That(decrypted, Is.EqualTo(originalString));
    }
}
