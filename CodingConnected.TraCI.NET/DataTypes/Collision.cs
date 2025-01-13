using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET.DataTypes;
public class Collision : TraCICompoundObject
    {

    public TraCIString ColliderId { get => (TraCIString)this[0]; set => this[0] = value; }

    public TraCIString VictimId { get => (TraCIString)this[1]; set => this[1] = value; }

    public TraCIString ColliderType { get => (TraCIString)this[2]; set => this[2] = value; }

    public TraCIString VictimType { get => (TraCIString)this[3]; set => this[3] = value; }

    public TraCIDouble ColliderSpeed { get => (TraCIDouble)this[4]; set => this[4] = value; }

    public TraCIDouble VictimSpeed { get => (TraCIDouble)this[5]; set => this[5] = value; }

    public TraCIString CollisionType { get => (TraCIString)this[6]; set => this[6] = value; }


    public TraCIString LaneId { get => (TraCIString)this[7]; set => this[7] = value; }

    public TraCIDouble PositionOnLane { get => (TraCIDouble)this[8]; set => this[8] = value; }
    }
