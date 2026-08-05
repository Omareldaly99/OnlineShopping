# Human Computer Interaction: TUIO

**Institution:** October University for Modern Sciences and Arts (MSA University)  
**Faculty:** Computer Science / Information Systems  

---

## Table of Contents
1. [Introduction & Why HCI](#1-introduction--why-hci)
2. [Types & Paradigms of Interaction](#2-types--paradigms-of-interaction)
3. [Sub-categories of HCI](#3-sub-categories-of-hci)
4. [Course & Lab Guidelines](#4-course--lab-guidelines)
5. [Grading Scheme](#5-grading-scheme)
6. [HCI Project Overview](#6-hci-project-overview)
7. [Project Phases & Rewards](#7-project-phases--rewards)
8. [Course Roadmap](#8-course-roadmap)
9. [Markers & TUIO Protocol](#9-markers--tuio-protocol)
10. [TUIO Architecture & Setup](#10-tuio-architecture--setup)
11. [Instructor Contact Information](#11-instructor-contact-information)

---

## 1. Introduction & Why HCI
* **Evolution of Computing Interfaces:** Human-Computer Interaction has evolved from early command-line and monochrome terminal setups (such as the IBM 5155 Portable PC) to modern GUIs, advanced gaming hardware, touch-enabled platforms, and natural language AI systems (e.g., ChatGPT).
* **Core Goal:** Design intuitiveness, accessibility, efficiency, and seamless user experiences across various hardware and software contexts.

---

## 2. Types & Paradigms of Interaction

### Four Primary Interaction Channels
* **Human – Human**
* **Computer – Computer**
* **Human – Computer**
* **Computer – Human**

### Human Interaction Framework with Computers

#### Primary Interaction Paradigm
* **Input Mechanisms:**
  * Keyboard + Mouse UI
  * Touchscreen UI
* **Output Mechanisms:**
  * Monitor + Speakers
  * Screen + Speakers + Haptic/Vibrations

#### Cognitive Interaction Layer
Interaction bridges human cognitive processing through five core sensory modalities:
1. **Sight**
2. **Touch**
3. **Hearing**
4. **Voice**
5. **Spatial Perception**

#### Secondary Interaction Paradigm
* **Input Mechanisms:**
  * Voice User Interfaces (VUI)
  * Body Movement
  * Gesture + Face Tracking
  * Bio Tracking
* **Output Mechanisms:**
  * Smart Speakers
  * Multi-screen + Speaker + Vibration combinations
  * Smart Mirrors

---

## 3. Sub-categories of HCI
HCI spans multiple interdisciplinary domains:
* **UI/UX** (User Interface / User Experience Design)
* **Data Visualization**
* **Brain-Computer Interaction (BCI)**
* **Human Activity Recognition (HAR)**
* **Wearable Devices / Internet of Things (IoT)**
* **Cloud Computing**
* **Eye Tracking**
* **Face Recognition**
* **Emotion Analysis**
* **Speech Recognition**
* **Multimodal Interaction**
* **Augmented Reality (AR) / Virtual Reality (VR)**

---

## 4. Course & Lab Guidelines

### Lab Time Structure (~1.5 to 2 Hours)
* **5–10 Minutes:** Introduction & Historical Context
* **5 Minutes:** Objectives & Demos
* **5–10 Minutes:** Discussions
* **50 Minutes:** Implementation & Lab Exercises

### Rules & Policies
* **Attendance:** Mandatory.
* **Punctuality:** Avoid being late to lab sessions.

---

## 5. Grading Scheme

| Assessment Component | Weight / Marks |
| :--- | :--- |
| **Project** | **25 Marks** |
| └─ *Phase I* | *10 Marks* |
| └─ *Phase II* | *15 Marks* |
| **Lab Participation** | **5 Marks** |
| **Quizzes** | **10 Marks** |
| **Total** | **40 Marks** |

### Additional Points & Bonus Activities
* Interactive Kahoot quizzes during labs.
* Research paper submissions are considered for additional credit.

---

## 6. HCI Project Overview

### Project Taxonomy
```
                 HCI Project
                      │
        ┌─────────────┴─────────────┐
  Using Gestures              Using Objects
                                    │
                             ┌──────┴──────┐
                          Markers       Markerless
```

### Project Requirements & Evaluation Criteria
Projects require comparing **3 different interaction techniques** based on:
1. **User Satisfaction**
2. **Engagement**
3. **Usability**
4. **User Surveys & Metrics**

---

## 7. Project Phases & Rewards

### Delivery Schedule
* **Week 4:** Phase 1 (Online Demo)
* **Week 6:** Phase 2 (On-Campus Discussion)
* **Week 9:** Phase 3 (Formative Evaluation)
* **Week 13:** Phase 4 (On-Campus Final Discussion)

### Incentives & Academic Opportunities
* **DeepMinds Participation:** Top 2 projects qualify for DeepMinds.
* **Full Marks:** The best project receives the full 25 marks.
* **Social Media Recognition:** Dedicated LinkedIn post highlighting the winning team and project.
* **Professional Recommendations:** Members of the top 2 projects receive formal LinkedIn recommendations.
* **Competitions & Publications:**
  * Opportunity to enter national-level technology competitions.
  * Projects can be converted into scientific papers for journal publication.
  * Rapidly growing demand in **Multimodal Interaction**.
  * Publication enhances graduate study and international study abroad prospects.
  * Alignment with UGRF – CIS (*Evaluating Student Engagement*).

---

## 8. Course Roadmap

| Week | Topic / Technology | Assessment |
| :---: | :--- | :---: |
| **Week 1** | Markers & TUIO Protocol | Quiz |
| **Week 2** | TUIO + GUI Integration | Quiz |
| **Week 3** | Sockets Communication | Quiz |
| **Week 4** | Bluetooth + Context Awareness | Quiz |
| **Week 5** | MediaPipe + Gesture Recognition | — |
| **Week 6** | Face Detection & Facial Recognition | — |
| **Week 9** | Object Detection (YOLO) | — |
| **Week 10** | Emotion + Gaze Tracking | — |
| **Week 11** | Unity Development | — |
| **Week 12** | Augmented Reality (AR) | — |

---

## 9. Markers & TUIO Protocol

### Problem-Solving / Critical Thinking Steps
1. **What is the problem?**
2. **What are the proposed solutions?**
3. **How to implement these solutions?**

### Why Use Fiducial Markers Instead of QR Codes?
* **Orientation Awareness:** Fiducial markers allow algorithms to detect spatial orientation (2D/3D rotation and translation in real-time), whereas standard QR codes are designed primarily for data encoding/storage rather than real-time tracking.

### Comparison: ArUco vs. TUIO

| Feature | ArUco Markers | TUIO Protocol |
| :--- | :--- | :--- |
| **Marker Capacity** | Unlimited / Dynamic generation | Fixed / Limited number of markers |
| **OpenCV Integration** | Natively integrated in OpenCV | Not natively integrated in OpenCV |
| **Implementation Complexity** | Higher complexity | Lower complexity / Easier |
| **Code Availability** | Custom setup required | Ready-made client templates available |

### Applications of TUIO
* Tangible Child Education
* Tangible Gaming Systems
* Tangible Music Synthesisers / Controllers

---

## 10. TUIO Architecture & Setup

### System Architecture Pipeline
```
┌────────────────────┐   OSC / Sockets   ┌─────────────────────────┐
│ reacTIVision Server├──────────────────►│ TUIO Client Application │
└────────────────────┘                   └─────────────────────────┘
```

### Code Structure & Modification
* **reacTIVision Server:** Acts as a black box (captures camera video feed, tracks physical markers, and transmits tracking events over network sockets).
* **Client Applications:** Developers write application logic inside client applications.
  * Available client SDKs: **C++**, **Java**, **C#** *(Note: No official Python client provided)*.
* **Implementation Detail (Java):**
  * Application logic is written inside the Java client by overriding/updating the `paint()` method within `TUIO Demo Object`.

---

## 11. Instructor Contact Information

For inquiries regarding the course, labs, or projects, contact the teaching assistants:
* `fdarwish@msa.edu.eg`
* `maashraf@msa.edu.eg`
* `akamaleldin@msa.edu.eg`
* `maabdelfattah@msa.edu.eg`
