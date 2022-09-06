# Demo of Protobuf with C#
Protocol buffers are Google's language-neutral, platform-neutral, extensible mechanism for serializing structured data.

## The **protobuf-net** nuget package that makes it all easy:

```xml
<ItemGroup>
    <PackageReference Include="protobuf-net" Version="3.1.17" />
</ItemGroup>
```

## What is a "Length Prefix"?
If we want multiple objects at once, and they are all encoded as bytes in the same stream, then we need to know when one object ends, and another begins. 

```csharp

// To serialize
Serializer.SerializeWithLengthPrefix(fileStream, obj1, PrefixStyle.Fixed32);
Serializer.SerializeWithLengthPrefix(fileStream, obj2, PrefixStyle.Fixed32);

// OPTIONS #1: To deserialize
do
{
    user = Serializer.DeserializeWithLengthPrefix<User>(fileStream, PrefixStyle.Fixed32);
} while (user != null);

// OPTIONS #2: To deserialize
var users = Serializer.DeserializeItems<User>(fileStream, PrefixStyle.Fixed32, -1)

```

---
## Links:
- [Google Protocol Buffers](https://developers.google.com/protocol-buffers)
- [Protocol Buffer Basics: C#](https://developers.google.com/protocol-buffers/docs/csharptutorial)
- [protobuf-net/protobuf-net](https://github.com/protobuf-net/protobuf-net)
- [Online Protobuf Decoder](https://protogen.marcgravell.com/decode)