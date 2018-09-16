﻿using DotNetty.Buffers;
using System;

namespace Tars.Net.Codecs
{
    public interface ITarsConvert
    {
        int Order { get; }

        Codec Codec { get; }

        bool Accept((Codec, Type, short) options);

        object Deserialize(IByteBuffer buffer, Type type, out int order, TarsConvertOptions options = null);

        void Serialize(object obj, IByteBuffer buffer, int order, bool isRequire = true, TarsConvertOptions options = null);
    }
}