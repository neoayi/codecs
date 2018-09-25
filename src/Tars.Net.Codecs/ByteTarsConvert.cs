﻿using DotNetty.Buffers;

namespace Tars.Net.Codecs
{
    public class ByteTarsConvert : TarsConvertBase<byte>
    {
        public override byte Deserialize(IByteBuffer buffer, TarsConvertOptions options)
        {
            switch (options.TarsType)
            {
                case TarsStructType.ZERO_TAG:
                    return 0x0;

                case TarsStructType.BYTE:
                    return buffer.ReadByte();

                default:
                    throw new TarsDecodeException("type mismatch.");
            }
        }

        public override void Serialize(byte obj, IByteBuffer buffer, TarsConvertOptions options)
        {
            Reserve(buffer, 3);
            if (obj == 0)
            {
                WriteHead(buffer, TarsStructType.ZERO_TAG, options.Tag);
            }
            else
            {
                WriteHead(buffer, TarsStructType.BYTE, options.Tag);
                if (options.HasValue)
                {
                    buffer.WriteByte(obj);
                }
            }
        }
    }
}