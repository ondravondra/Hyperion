using System;
using System.IO;

namespace Wire.ValueSerializers
{
    public class BoolSerializer : ValueSerializer
    {
        public static readonly ValueSerializer Instance = new BoolSerializer();
        private readonly byte[] _manifest = {6};

        public override void WriteManifest(Stream stream, Type type, SerializerSession session)
        {
            stream.Write(_manifest, 0, _manifest.Length);
        }

        public override void WriteValue(Stream stream, object value, SerializerSession session)
        {
            var b = (bool) value;
            stream.WriteByte((byte) (b ? 1 : 0));
        }

        public override object ReadValue(Stream stream, SerializerSession session)
        {
            var b = stream.ReadByte();
            if (b == 0)
                return false;
            return true;
        }

        public override Type GetElementType()
        {
            return typeof (bool);
        }
    }
}