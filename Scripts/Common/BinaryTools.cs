using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharedUtils.Common
{
    public sealed class BinaryTools
    {

        public static byte[] Serialize(object @object)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, @object);

            return ms.ToArray();
        }

        public static object Deserialize(byte[] bytes)
        {
            using MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            ms.Write(bytes, 0, bytes.Length);
            ms.Seek(0, SeekOrigin.Begin);

            return bf.Deserialize(ms);
        }
    }
}
