# README for Base folder

this folder contains interface and abstract classes that are used in the other folders. 

## ITraiType

this interface defines the basic properties of a TraCI type:
> - `byte TYPE` - stands for the type of the TraCI type. Such as int, double, string, etc.
> - `byte[] ToBytes()` - converts the type to a byte array,which can be sent to the TraCI server though TCP connect.

## TraCIBaseType

this abstract class stands for the basic value type of Traci, which be defined in [sumo doc](https://sumo.dlr.de/docs/TraCI/Protocol.html#atomar_types).

## TraciListType

this abstract class stands for a list of a specified base traci type. In fact, it inherits from `List<TraciBaseType>`.


## TraciArrayType

this abstract class stands for a array of several **UNSPECIFIED** base traci type. Every element in the array is a `ITraciType` object, while the array has no idea about the type of the element.

> **Note**:this class was created for some traci data structure. For example, `TrafficLightPhase` In this class, the `ToBytes` hsa 3 items, <u>string, string, and byte</u>.
>
> You can consider `TraciArrayType` is a **Slice** of `TraciCompoudObject`
