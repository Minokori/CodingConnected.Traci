using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Types
    {
    public class CompoundObject : ComposedTypeBase
        {
        public List<ComposedTypeBase> Value { get; set; }

        public CompoundObject()
            {
            Value = [];
            }
        }
    }
