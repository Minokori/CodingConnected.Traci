# README for `CodingConneted.traci.DataTypes`

[toc]

## 中文

### 概述

该库包括与 Traci 通信时包含的数据类型 (下面简称"Traci 类型"). 包括:

1.  基本的数据类型. 例如 `int`, `double`, `string` 等数据类型
2.  有语义的数据类型. 例如 `RoadMapPosition`, 该类型由三个基本数据类型构成, 包括一个 `string` 类型的 `RoadId` 字段, 一个 `double` 类型的 Position 字段,  一个 `byte` 类型的 `LaneId` 字段, 用于表示交通体在路网上的位置[^1].

### 组成

#### 接口与抽象类

所有的Traci类型都实现了 `ITraciType` 接口, 以提供最基础的类型标识符属性和转为字节流的方法. 抽象类用于为不同的Traci类型提供公共方法,以减少代码量.

#### 基础数据类型

这些类型继承自 `TraciBaseType<T>` 抽象类, `T` 是 `.NET` 中对应的数据类型

#### 列表数据类型

这些类型继承自 `TraciListType<U,T>`抽象类, `U` 是基础数据类型, `T` 是 `.NET`中对应的数据类型. 用于表示由同一数据类型构成的列表, 例如 `Color : TraciListType<TraciByte, byte>` 是由四个 `TraciByte` 构成的列表, 其中每个元素是 `TraciByte` 类型, 每个字段 (r, g, b, a) 可以以 `byte` 类型直接读取,而无需显式将 `TraciByte` 转换为 `byte`.

#### 数组数据类型[^2]

这些类型继承自 `TraciArrayType` 抽象类. 不同于列表数据类型, 数组数据类型中每个元素的具体类型并不明确, 它们以接口 `ITraciType` 类型存在. 当需要被解释为对应类型时, 在具体的类型中会有强制类型转换. 当然, 每个字段提供了直接以 `.NET` 类型读取的类型, 您无需考虑转换问题.

#### TraciCompoudObject 类型

该类型是 SUMO 官方为 Traci 定义的混合数据类型. 我们的数组数据类型正是模仿它产生的. 不同的是 `TraciCompoundObject` 类型表示符均为 `0x0F`, 而数组数据类型 **没有** 类型标识符. 您可以认为一个 `TraciArrayType `是 `TraciCompoundObject` 的切片, 是一个不完整的 `TraciCompoundObject`. 与 `TraciArrayType` 相对的, 继承自 `TraciCompoundObject` 的子类有特定的解释元素的方式, 这些类型具有 **不同的**类型标识符.

[^1]: 确切的说, 在该库中使用的是 **属性**  而非 **字段** , 因为只提供了只读的 `getter` 方法.
[^2]: 在 `.NET` 中, `List<T>` 类型所有元素具有相同类型, 而 `Array` 类型对元素类型没有要求. 考虑到这一点, 将此类型命名为数组数据类型

#### 扩展方法

为 `TraciCompoudObject` 类型提供了转换为特定数据类型的扩展方法.

---

## English

### Overview

The library includes data types that are included when communicating with Traci (hereinafter referred to as "Traci Types"). Includes:

1. Basic data types. For example, data types such as `int`, `double`, `string`, etc
2. Semantic data types. For example, the `RoadMapPosition` type consists of three basic data types, including a `RoadId` field of the `string` type, a Position field of the `double` type, and a `LaneId` field of the `byte` type, which is used to represent the position of the traffic body on the road network[^3].

### Composition

#### Interfaces and Abstract Classes

All Traci types implement the `ITraciType` interface to provide the most basic type identifier properties and methods for converting to byte streams. Abstract classes are used to provide common methods for different Traci types to reduce the amount of code.

#### Basic Data Type

These types inherit from the `TraciBaseType` abstract class, and `T` is the corresponding data type in `.NET`

#### List data type

These types inherit from the `TraciListType` abstract class, `U` is the base data type, and `T` is the corresponding data type in `.NET`. It is used to represent a list of the same data type, e.g. `Color : TraciListType` is a list of four `TraciBytes`, where each element is of type `TraciByte` and each field (r, g, b, a) can be read directly as `byte` without explicitly converting `TraciByte` to `byte`

#### Array data type [^4]

These types inherit from the `TraciArrayType` abstract class. Unlike the list data type, the specific type of each element in the array data type is not clear, and they exist as the interface `ITraciType` type. When the need to be interpreted as a corresponding type, there will be a forced type conversion in the specific type. Of course, each field provides a type that reads directly in the `.NET` type, so you don`t need to think about the conversion

#### TraciCompoudObject type

This type is a hybrid data type officially defined by SUMO for Traci. Our array data type is exactly what it produces. The difference is that the `TraciCompoundObject` type representation is `0x0F`, while the array data type does not have a type identifier. You can think of a `TraciArrayType` as a slice of a `TraciCompoundObject` and an incomplete `TraciCompoundObject`. As opposed to `TraciArrayType`, subclasses that inherit from `TraciCompoundObject` have specific ways of interpreting elements, and these types have different type identifiers.

[^3]: To be exact, the library uses Properties instead of Fields, because only the read-only `getter` method is provided
[^4]: In `.NET`, all elements of the `List` type have the same type, while the `Array` type has no requirement for the element type. With that in mind, name this type the Array Data Type

#### Extension Method

The `TraciCompoudObject` type provides an extension method to convert to a specific data type.