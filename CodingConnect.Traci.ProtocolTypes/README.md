# README for `CodingConnected.Traci.ProtocolTypes`

[toc]

## 中文

### 概述

该库用于 `CodingConnected.Traci` 与 Traci 进行 TCP 通信时, 将发送/接受的数据流依照协议解析为 SUMO 官方定义的 Traci 命令结构. 包括以下部分:

1.  `TraciResult` 用于处理原始字节流, 得到结构化的数据结构.
2.  `IStatusResponse` 是 `TraciResult` 显式实现的接口. 由于在向 Traci 发送一条指令时, Traci 一般会返回两条 `TraciResult`, 第一条用于告知指令是否成功, 第二条包含指令执行的具体结果, 该接口提供了一些属性, 用于方便地获得指令是否执行成功
3.  `IAnswerFromSumo` 是 `TraciResult` 显式实现的接口. 和上述理由相同, 该接口提供了一些属性, 用于方便地获取指令的具体结果的数据类型和实际内容.
4.  `TraciResponse` 中包含了用于 Traci 订阅信息的数据结构. ⚠️向Traci订阅相关功能还未经测试⚠️

5.  `TraciCommand` 用于将数据包装成字节流发送给 Traci



---



## English

### OverView

This library is used when `CodingConnected.Traci` communicates with Traci in TCP, the sent/accepted data stream is resolved to the official SUMO Traci command structure defined by SUMO according to the protocol. It includes the following parts:

1. `TraciResult` is used to process the original byte stream and obtain a structured data structure.
2. `IStatusResponse` is an explicit interface implemented by `TraciResult`. Since when sending an instruction to Traci, Traci will generally return two `TraciResult`. The first one is used to tell whether the instruction is successful, and the second one contains the specific result of the instruction execution. The interface provides some attributes to facilitate the obtaining whether the instruction is successfully executed.
3. `IAnswerFromSumo` is an interface that is explicitly implemented by `TraciResult`. Same as the above reasons, this interface provides some properties for conveniently obtaining the data type and actual content of the specific results of the instruction.
4. `TraciResponse` contains the data structure for Traci subscription information. ⚠️Subscribe to Traci related functions have not been tested yet⚠️

5. `TraciCommand` is used to wrap data into byte streams and send it to Traci