using ProtoBuf;

namespace Demo.ProtoBuf
{
    [ProtoContract]
    public class User
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string? Username { get; set; }

        [ProtoMember(3)]
        public string? FirstName { get; set; }

        [ProtoMember(4)]
        public string? LastName { get; set; }

        [ProtoMember(5)]
        public string? Email { get; set; }
    }
}