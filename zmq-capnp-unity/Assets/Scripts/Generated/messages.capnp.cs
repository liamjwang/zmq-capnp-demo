using Capnp;
using Capnp.Rpc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CapnpGen
{
    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe583f441b27ffd15UL)]
    public class Vector3 : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe583f441b27ffd15UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            X = reader.X;
            Y = reader.Y;
            Z = reader.Z;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.X = X;
            writer.Y = Y;
            writer.Z = Z;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

        public float Z
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public float X => ctx.ReadDataFloat(0UL, 0F);
            public float Y => ctx.ReadDataFloat(32UL, 0F);
            public float Z => ctx.ReadDataFloat(64UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 0);
            }

            public float X
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }

            public float Y
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float Z
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe98790453ed349f8UL)]
    public class HandPose : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe98790453ed349f8UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Fingers = reader.Fingers?.ToReadOnlyList(_ => CapnpSerializable.Create<CapnpGen.Vector3>(_));
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Fingers.Init(Fingers, (_s1, _v1) => _v1?.serialize(_s1));
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<CapnpGen.Vector3> Fingers
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public IReadOnlyList<CapnpGen.Vector3.READER> Fingers => ctx.ReadList(0).Cast(CapnpGen.Vector3.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public ListOfStructsSerializer<CapnpGen.Vector3.WRITER> Fingers
            {
                get => BuildPointer<ListOfStructsSerializer<CapnpGen.Vector3.WRITER>>(0);
                set => Link(0, value);
            }
        }
    }
}