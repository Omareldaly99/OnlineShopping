# Human Computer Interaction (HCI): Human Activity Recognition (HAR)

**Instructor/Presenter:** Moamen Zaher  
**Institution:** October University for Modern Sciences and Arts (MSA University)  
*Established by Dr. Nawal El Degwi (In Egypt Since 1996)*

---

## 1. Types of Interactions

Interaction in computational and human environments can be categorized into four main types:

| Interaction Type | Description |
| :--- | :--- |
| **Human – Human** | Direct interaction between people (e.g., verbal communication, body gestures). |
| **Computer – Computer** | Automated data exchange and network communication between devices. |
| **Human – Computer** | User input driving computer processing and system output back to the user. |
| **Computer – Human** | Automated system notifications, camera/sensor tracking, or proactive feedback to humans. |

---

## 2. Human Interaction Paradigm (HCI Model)

Human interaction with computers involves both primary and secondary paradigms mediated by cognitive processes:

```
                  [ COGNITIVE INTERACTION ]
                             │
     ┌───────────────┬───────┴───────┬───────────────┐
     ▼               ▼               ▼               ▼
  [ Sight ]       [ Touch ]     [ Hearing ]      [ Voice ]    [ Spatial ]
```

### Primary Interaction Paradigm
* **Input:** Mouse + Keyboard UI, Touch Screen UI
* **Output:** Monitor + Speakers, Screen + Speakers + Haptics/Vibrations
* **Core Senses:** Sight, Touch, Hearing

### Secondary Interaction Paradigm
* **Input:** Voice UI, Body Movement, Gesture + Face Tracking, Bio Tracking
* **Output:** Smart Speakers, Ambient Displays, Smart Mirrors
* **Emerging Modes:** Spatial Audio, NUI (Natural User Interfaces)

---

## 3. Sub-Categories of HCI

Human-Computer Interaction encompasses a wide range of specialized domains:

* **UI / UX Design** – User Interface & User Experience design principles.
* **Visualization** – Interactive data visualization and visual analytics.
* **Brain-Computer Interaction (BCI)** – Direct communication pathways between brain signals and external devices.
* **Human Activity Recognition (HAR)** – Computer vision and sensor-based detection of human actions.
* **Wearable Devices / IoT** – Smartwatches, health trackers, and connected edge devices.
* **Cloud Computing** – Distributed processing and backend AI services for HCI systems.
* **Eye Tracking** – Gaze estimation, attention mapping, and dwell-time interaction.
* **Face Recognition** – Facial feature detection and biometric authentication.
* **Emotion Analysis** – Affective computing via facial expression, tone, or physiology.
* **Speech Recognition** – Natural language processing and acoustic modeling.
* **Multimodal Interaction** – Combining voice, gesture, gaze, and touch simultaneously.
* **AR / VR** – Augmented Reality and Virtual Reality immersive interfaces.

---

## 4. Course & Lab Guidelines

### Lab Structure (Total Time per Session)
1. **Intro & History:** 5 – 10 minutes
2. **Objectives & Demos:** 5 minutes
3. **Discussions:** 5 – 10 minutes
4. **Implementation:** 50 minutes

* **Attendance:** Mandatory. Punctuality is strictly required.

### Grading Breakdown
* **Project (25 Marks Total)**
  * **Phase I:** 10 Marks
  * **Phase II:** 15 Marks
* **Lab Participation:** 5 Marks
* **Quizzes (10 Marks Total)**
  * **Lab Quiz:** 5 Marks
  * **Lecture Quiz:** 5 Marks
* **Extras & Bonus:** Kahoot quizzes, scientific paper submissions, and active lab participation.

---

## 5. Course Project Guidelines & Opportunities

### Project Taxonomy
```
                        [ HCI Project ]
                               │
               ┌───────────────┴───────────────┐
               ▼                               ▼
       [ Using Gestures ]               [ Using Objects ]
                                               │
                                       ┌───────┴───────┐
                                       ▼               ▼
                                  [ Markers ]    [ Markerless ]
```

### Key Tasks & Evaluation Criteria
* Compare **3 different Interaction Techniques**.
* Evaluate the techniques based on:
  1. User Satisfaction
  2. Engagement Level
  3. Usability Metrics
  4. User Surveys & Quantitative Feedback

### Rewards & Achievements
* **Top Projects Participation:** The best 2 projects get selected for **DeepMinds**.
* **Marks:** Top project gets full 25 marks.
* **Recognition:** 
  * Featured LinkedIn post for the top project.
  * Formal LinkedIn recommendation letters for members of the top 2 projects.
* **Competitions & Publications:**
  * National level competition submissions.
  * Opportunity to convert project into a published scientific journal paper (Multimodality is a rapidly growing field).
  * Example Success: *UGRF - CIS 18th Special Edition First Place Winner (EGP 7000)* — "Deep Learning in Students' Disengagement Detection".

---

## 6. Development Tools & Software Stack

* **Environment:** Anaconda (Python Data Science Platform)
* **Libraries & Frameworks:** MediaPipe, OpenCV, NumPy, SciPy, Scikit-Learn, PyTorch/TensorFlow.

---

## 7. MediaPipe Capabilities & Implementation

### Core Modules
* Face Detection
* Face Mesh
* Hands Tracking
* Pose Landmark Detection
* Object Tracking
* Selfie Segmentation
* MediaPipe Holistic (Unified Pose, Hands, & Face Mesh)

---

### Implementation Pipelines

#### A. Pose Detection Pipeline
1. Import required packages (`mediapipe`, `cv2`, etc.).
2. Load input image/video stream.
3. Convert image from BGR to RGB format.
4. Flip image horizontally (along y-axis) for mirror view / correct orientation.
5. Pass frame into MediaPipe Pose / Holistic estimator.
6. Extract keypoint spatial coordinates (e.g., Nose, Shoulders, Wrists).
7. Draw pose landmarks over the image frame using drawing utilities.

#### B. Hands Detection Pipeline
1. Import required packages.
2. Load image frame.
3. Convert BGR to RGB and flip around y-axis for proper handedness detection.
4. Process frame with `mp.solutions.hands.Hands`.
5. Classify handedness (`Left` vs `Right` hand).
6. Extract key landmarks (e.g., Index Finger Tip coordinates).
7. Draw 2D landmark overlays and plot 3D world landmarks for spatial orientation.

#### C. MediaPipe Holistic Solution
* **Problem:** Simultaneous requirement of hand keypoints, pose topology, and facial mesh landmarks.
* **Solution Output:**
  * `PoseLandmarks` (33 keypoints)
  * `RightHandLandmarks` (21 keypoints)
  * `LeftHandLandmarks` (21 keypoints)
  * `FaceMeshLandmarks` (468 keypoints)

---

## 8. Human Activity Recognition (HAR) Workflow & Models

### Problem Formulation & Critical Thinking
* **What is the problem?** Recognizing human activities and gestures in real-time continuous sensor/video feeds.
* **What are the proposed solutions?** Applying sequence models and template matching over feature vectors.
* **How to implement these solutions?** Pipeline engineering: Data capture -> Preprocessing -> Feature Extraction -> Classification.

### AI Model Paradigms for HAR

#### 1. Deep Learning Models (Sequence & Temporal Networks)
* **RNN** (Recurrent Neural Networks)
* **LSTM** (Long Short-Term Memory Networks)
* **Bi-LSTM** (Bidirectional LSTM for full-sequence context)
* **CNN-LSTM** (Spatial feature extraction + Temporal sequence modeling)

#### 2. Template Matching & Time-Series Models
* **DTW** (Dynamic Time Warping)
* **$1 Recognizer** ($1 Unistroke Recognizer)
* **HMM** (Hidden Markov Models)
* **DTWs** / Multistroke variations

#### 3. Classification Pipeline
* Point Cloud / Landmark Trajectory Parsing
* Stroke / Gesture Identification (`RecognizePoint1`, `Point2`, `StrokeId`)
* Activity Classification Output

---

## 9. Contacts & Inquiries

For questions, office hours, and project guidance, contact the instructional team:
* `fdarwish@msa.edu.eg`
* `maashraf@msa.edu.eg`
* `akamaleldin@msa.edu.eg`
* `maabdelfattah@msa.edu.eg`
