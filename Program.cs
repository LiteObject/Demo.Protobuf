using System.Text;
using ProtoBuf;

namespace Demo.ProtoBuf
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new()
            {
                Id = 1,
                Username = "JDoe",
                FirstName = "Jon",
                LastName = "Doe",
                Email = "jon.doe@email.com"
            };

            // To serialize directly into a memory stream:
            var byteArray  = Serialize<User>(user);

            if(byteArray is not null)
            {
                Console.WriteLine(Encoding.Default.GetString(byteArray));            
            }

            // To serialize directly to a file:
            var filePath = Path.Join("./SerializedOutput", Path.GetRandomFileName() + ".buf"); 
            Serialize(user, filePath);
        }

        private static byte[]? Serialize<T>(T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                Serializer.Serialize<T>(memoryStream, obj);
                var byteArray = memoryStream.ToArray();

                return byteArray;
            }
        }

        private static void Serialize<T>(T obj, string filePath)
        {
            using (var fileStream = File.Create(filePath))
            {
                Serializer.Serialize(fileStream, obj);
            }
        }
    }
}