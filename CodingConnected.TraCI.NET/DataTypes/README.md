# README for `Traci.NET.Types`

## Overview

this folder contains data types defined in this library. the interface and atomar types are defined in [TraCIBaseType.cs](TraCIBaseType.cs) , other composed types are defined in each other single files.

all defined type represent a real type can be analyzed from byte stream of TCP responses. a list of bytes from TCP is analyzed in way showed below:

```c#
byte[] TCPbytes; // bytes from TCP
(TraciType value1, TCPbytes) = TraciType.FromBytes(TCPbytes)
(TraciType value2, TCPbytes) = TraciType.FromBytes(TCPbytes)
...
>>> TCPbytes.Length == 0
>>> True
```

## Atomar Types

represent basic value type like `int`, `string`, `double`, etc.

also provide a static method `AtomarType.AsBytes(object value)` to convert basic type to bytes which to send to traci's TCP port.

## Composed Types

each property of a compose type is a [atomar type](## Atomar Types) .

## Constants
Identifiers for constants used in the library are defined in [Constants.cs](Constants.cs)