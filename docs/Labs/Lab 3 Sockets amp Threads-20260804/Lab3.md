# Human Computer Interaction: Sockets & Threading (Lab 3)

**Course:** Human Computer Interaction (HCI) Labs  
**Topic Focus:** Lab Roadmap, Socket Communication, Threading & Concurrency  

---

## Table of Contents
1. [Updated Lab Roadmap & Quiz Schedule](#1-updated-lab-roadmap--quiz-schedule)
2. [Socket Communication](#2-socket-communication)
   - [What are Sockets?](#what-are-sockets)
   - [Socket Applications](#socket-applications)
   - [Sockets Architecture & Communication Lifecycle](#sockets-architecture--communication-lifecycle)
3. [Threading & Concurrency](#3-threading--concurrency)
   - [Core Concepts](#core-concepts)
   - [Multi-Threading vs. Multi-Processing](#multi-threading-vs-multi-processing)
   - [Synchronous vs. Asynchronous Execution](#synchronous-vs-asynchronous-execution)
   - [Single-Thread vs. Multi-Thread Execution Benchmark](#single-thread-vs-multi-thread-execution-benchmark)

---

## 1. Updated Lab Roadmap & Quiz Schedule

| Week | Topic / Technology | Quiz Status |
| :---: | :--- | :---: |
| **Week 1** | Markers TUIO | — |
| **Week 2** | TUIO + GUI | — |
| **Week 3** | Sockets | **Quiz** |
| **Week 4** | Bluetooth + Context Awareness | — |
| **Week 5** | Mediapipe + Gesture Recognition | **Quiz** |
| **Week 6** | Face Detection & Facial Recognition | — |
| **Week 9** | Object Detection (YOLO) | **Quiz** |
| **Week 10** | Emotion + Gaze Tracking | — |
| **Week 11** | Unity Development | **Quiz** |
| **Week 12** | Augmented Reality (AR) | — |

---

## 2. Socket Communication

### What are Sockets?
Sockets provide standard endpoints for bidirectional network communications between processes over a computer network.

### Socket Applications
Socket communication is widely used across key network domain applications:
* **File Transfer Applications:** Uploading/downloading files securely between client and server.
* **Instant Messaging Applications:** Direct peer/server message routing.
* **Online Games:** Real-time state synchronization between players and central servers.
* **Chat Applications:** Multi-client persistent connection broadcasting (e.g., Socket.io TypeScript Chat).
* **Peer-to-Peer Networking Applications:** Direct decentralized nodes exchanging data.
* **Internet of Things (IoT) Applications:** Low-latency telemetric data transmission between smart devices and micro-controllers.

---

## 3. Sockets Architecture & Communication Lifecycle

```
       SERVER PROCESS                                      CLIENT PROCESS
┌──────────────────────────┐                      ┌──────────────────────────┐
│          socket          │                      │          socket          │
└────────────┬─────────────┘                      └────────────┬─────────────┘
             │                                                 │
┌────────────▼─────────────┐                                   │
│           bind           │                                   │
└────────────┬─────────────┘                                   │
             │                                                 │
┌────────────▼─────────────┐                                   │
│          listen          │                                   │
└────────────┬─────────────┘                                   │
             │                                                 │
┌────────────▼─────────────┐    3-Way Handshake Connection     ┌▼─────────────────────────┐
│          accept          │◄─────────────────────────────────┤         connect          │
└────────────┬─────────────┘                                   └────────────┬─────────────┘
             │                                                              │
┌────────────▼─────────────┐        Client Sends Data                       │
│           recv           │◄───────────────────────────────────────────────┤
└────────────┬─────────────┘                                                │
             │                                                 ┌────────────▼─────────────┐
             │                                                 │           send           │
             │                      Server Sends Data          └────────────┬─────────────┘
┌────────────▼─────────────┐──────────────────────────────────►│                          │
│           send           │                                   │                          │
└────────────┬─────────────┘                                   ┌────────────▼─────────────┐
             │                                                 │           recv           │
             │                                                 └────────────┬─────────────┘
┌────────────▼─────────────┐       Client Close Signal                      │
│           recv           │◄───────────────────────────────────────────────┤
└────────────┬─────────────┘                                   ┌────────────▼─────────────┐
             │                                                 │          close           │
┌────────────▼─────────────┐                                   └──────────────────────────┘
│          close           │
└──────────────────────────┘
```

### Protocol Steps Breakdown
1. **Server Initialization:**
   * `socket`: Creates an endpoint socket object.
   * `bind`: Binds the socket to a specific local IP address and port number.
   * `listen`: Listens for incoming client connection requests.
   * `accept`: Blocks and waits until a client initiates a connection, returning a active connection context.
2. **Client Connection:**
   * `socket`: Client initializes its local socket endpoint.
   * `connect`: Initiates a three-way handshake with the server's listening socket.
3. **Data Exchange:**
   * Data is sent via `send` calls and retrieved through corresponding `recv` operations in both directions.
4. **Connection Teardown:**
   * Client sends a closure request via `close`, allowing the server's `recv` loop to finish and execute its own `close`.

---

## 4. Threading & Concurrency

### Core Concepts
* **Thread:** The smallest execution unit within a process.
* **Multi-Threading vs. Multi-Processing:**
  * **Multi-Threading:** Shared memory space, lower context-switching overhead, suitable for I/O-bound tasks.
  * **Multi-Processing:** Separate memory space for each process, leverages true CPU core parallelism, suitable for CPU-bound tasks.

---

### Synchronous vs. Asynchronous Execution

| Model | Mechanics | Behavior |
| :--- | :--- | :--- |
| **Synchronous** | Sequential task processing | Program execution halts/blocks until the active task (`getArticles()`) finishes before initiating subsequent operations (`otherWork()`). |
| **Asynchronous** | Non-blocking processing (Promise/Event Loop) | Tasks run in the background; dependent callbacks/promises trigger upon completion without locking main thread execution. |

---

### Single-Thread vs. Multi-Thread Execution Benchmark
* Visualized via testing tools where tasks are split into discrete action blocks (grid squares).
* **Single Thread Mode:** Processes grid squares linearly, turning each green one by one while keeping subsequent tasks on standby.
* **Multi-Thread Mode:** Distributes grid squares concurrently across multiple available threads, dramatically shortening completion times.
