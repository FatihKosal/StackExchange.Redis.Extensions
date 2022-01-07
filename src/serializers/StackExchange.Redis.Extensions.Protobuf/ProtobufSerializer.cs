// Copyright (c) Ugo Lattanzi.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System;
using System.IO;

using ProtoBuf;

using StackExchange.Redis.Extensions.Core;

namespace StackExchange.Redis.Extensions.Protobuf;

/// <summary>
/// Protobuf-net implementation of <see cref="ISerializer"/>
/// </summary>
public class ProtobufSerializer : ISerializer
{
    /// <inheritdoc/>
    public byte[] Serialize<T>(T? item)
        where T : class
    {
        if (item == null)
            return Array.Empty<byte>();

        using var ms = new MemoryStream();

        Serializer.Serialize(ms, item);

        return ms.ToArray();
    }

    /// <inheritdoc/>
    public T Deserialize<T>(byte[] serializedObject) where T : class
    {
        using var ms = new MemoryStream(serializedObject);

        return Serializer.Deserialize<T>(ms);
    }
}
