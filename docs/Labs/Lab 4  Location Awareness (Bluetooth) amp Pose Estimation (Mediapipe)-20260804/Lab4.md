# Human Computer Interaction: Location Awareness and Pose Estimation

**Instructor:** Moamen Zaher  
**Institution:** October University for Modern Sciences and Arts (MSA University)

---

## Table of Contents
1. [Overview & Introduction](#overview--introduction)
2. [Evolution of Interaction](#evolution-of-interaction)
3. [Types of Interactions](#types-of-interactions)
4. [Human Interaction Framework](#human-interaction-framework)
5. [Sub-Categories of HCI](#sub-categories-of-hci)
6. [Course & Lab Guidelines](#course--lab-guidelines)
7. [Grading & Assessment Scheme](#grading--assessment-scheme)
8. [HCI Project Guidelines](#hci-project-guidelines)
9. [Course Roadmap & Topics](#course-roadmap--topics)
10. [Location Awareness Technologies](#location-awareness-technologies)
11. [Pose Estimation & Hand Tracking with MediaPipe](#pose-estimation--hand-tracking-with-mediapipe)
12. [Contact Information](#contact-information)

---

## Overview & Introduction
Human-Computer Interaction (HCI) is a multidisciplinary field focusing on the design, evaluation, and implementation of interactive computing systems for human use. This course covers core HCI principles with a special emphasis on **Location Awareness** and **Pose Estimation**.

---

## Evolution of Interaction

The paradigm of computer interfaces has evolved through distinct visual and physical iterations:

* **Command-Line Interfaces (CLI) & Terminal Computing:**
  * Early systems relied strictly on text commands (e.g., IBM 5155 Portable PC, early CRT monitors).
  * Interaction was rigid, requiring specific syntax knowledge.
* **Hardware Input Evolution:**
  * Transitioned from original mechanical IBM keyboards to modern ergonomic, high-precision gaming keyboards and multi-button optical mice.
* **Graphical User Interfaces (GUI):**
  * Desktop environments introduced visual metaphors (desktop icons such as Recycle Bin, Control Panel, Network).
* **Touchscreen Interfaces & Modern Spatial/Natural UI:**
  * Introduction of multi-touch, touch targets, and touch-grid layouts.
  * *Challenges:* Touch target size, visual occlusion, precision issues, and accidental touches.
  * *What's Next?* Moving beyond traditional touch screens toward hands-free, location-aware, gesture-driven, and multimodal interfaces.

---

## Types of Interactions

Interaction in computing and communication is classified into four fundamental modalities:

| Interaction Type | Description / Examples |
| :--- | :--- |
| **Human – Human** | Direct communication between people mediated by technology or direct context. |
| **Computer – Computer** | Machine-to-machine (M2M) communication, IoT data exchanges, network protocols. |
| **Human – Computer** | Traditional input via keyboard, mouse, touch, or natural input (voice, gestures, pose). |
| **Computer – Human** | Automated feedback, notifications, smart surveillance alerts, spatial tracking outputs. |

---

## Human Interaction Framework

```
                      +----------------------+
                      | COGNITIVE INTERACTION |
                      +----------+-----------+
                                 |
         +----------+------------+------------+----------+
         |          |                         |          |
      [Sight]    [Touch]   [Hearing]       [Voice]   [Spatial]
         |          |          |              |          |
```

### Primary Interaction Paradigm
* **Input Devices:** Mouse + Keyboard UI, Touchscreen UI
* **Output Devices:** Monitor + Speakers, Screen + Speakers + Vibrations (Haptic Feedback)

### Secondary Interaction Paradigm
* **Input Modalities:** Voice UI, Body Movement, Gesture + Face Tracking, Bio Tracking
* **Output Modalities:** Smart Speakers, Screens + Speakers + Vibrations, Smart Mirrors

---

## Sub-Categories of HCI

Human-Computer Interaction spans numerous sub-fields and emerging domains:

* **UI/UX Design:** User Interface and User Experience engineering.
* **Data Visualization:** Graphical representation of complex datasets for human interpretation.
* **Brain-Computer Interaction (BCI):** Direct communication pathways between brain signals and external devices.
* **Human Activity Recognition (HAR):** Identifying actions and behaviors from sensor or camera data.
* **Wearable Devices / IoT:** Context-aware smart hardware (smartwatches, sensors, fitness bands).
* **Cloud Computing:** Backend infrastructure supporting real-time interactive systems.
* **Eye Tracking:** Monitoring gaze direction, focus points, and pupil movement.
* **Face Recognition & Emotion Analysis:** Detecting facial landmarks and inferring affective states.
* **Speech Recognition:** Converting spoken acoustic signals into textual/actionable input.
* **Multimodal Interaction:** Combining sight, touch, voice, gesture, and spatial inputs concurrently.
* **Augmented Reality (AR) / Virtual Reality (VR):** Immersive and spatial computing environments.

---

## Course & Lab Guidelines

### Lab Session Structure (60–75 Minutes Total)
1. **Intro & History:** 5–10 Minutes
2. **Objectives & Demos:** 5 Minutes
3. **Discussions:** 5–10 Minutes
4. **Hands-on Implementation:** 50 Minutes

### General Rules
* **Attendance is mandatory.**
* Punctuality is required—avoid being late.

---

## Grading & Assessment Scheme

| Component | Marks / Weight | Notes |
| :--- | :---: | :--- |
| **HCI Project** | **25 Marks** | Phase I: 10 Marks \| Phase II: 15 Marks |
| **Quizzes** | **10 Marks** | Lab Quiz: 5 Marks \| Lecture Quiz: 5 Marks |
| **Lab Participation** | **5 Marks** | Ongoing evaluation |
| **Extras & Bonus** | -- | Kahoot sessions & Scientific Paper Submissions |

---

## HCI Project Guidelines

```
                             HCI Project
                                  |
              +-------------------+-------------------+
              |                                       |
       Using Gestures                           Using Objects
                                                      |
                                          +-----------+-----------+
                                          |                       |
                                       Markers                Markerless
```

### Project Requirements & Evaluation Criteria
* **Comparative Study:** Implement and compare **3 different Interaction Techniques**.
* **Evaluation Metrics:**
  1. User Satisfaction
  2. Engagement
  3. Usability
  4. User Surveys & Quantitative Feedback

### Incentives & Rewards for Top Projects
* **DeepMinds Participation:** Top 2 projects will participate in DeepMinds.
* **Full Marks:** Winning project receives top marks (25/25).
* **Recognition:** Dedicated LinkedIn showcase post for the top project.
* **Recommendations:** Members of the top 2 projects will receive formal LinkedIn recommendations.
* **Competitions & Publications:** Projects are eligible for national competitions and conversion into peer-reviewed scientific research papers.
* **CIS UGRF:** Evaluating Student Engagement.

---

## Course Roadmap & Topics

```
[ Software Setup ] ──► [ Location Awareness ] ──► [ Pose & Gesture Tracking ] ──► [ Project Evaluation ]
```

### Key Topics
1. **Software Frameworks & Environment Setup**
2. **Location-Aware Technologies**
3. **Hand & Body Pose Estimation**
4. **Interaction Usability Testing & Surveys**

---

## Location Awareness Technologies

Location awareness allows devices to determine their geographical or relative position:

### Technologies
* **Bluetooth (BLE):** Proximity sensing, indoor positioning, beacons.
* **Wi-Fi:** Access point triangulation, RSSI fingerprinting.
* **Cellular Network:** Tower triangulation, cell ID tracking.
* **GPS:** Global positioning via satellite signals for outdoor tracking.

### Key Bluetooth Applications
* **Attendance Systems:** Automated presence detection in classrooms/offices.
* **Surveillance Systems:** Asset and human tracking.
* **Location-Based Marketing:** Targeted proximity messaging.
* **Tracking & Navigation:** Indoor navigation and asset location.

### Popular Python Bluetooth Libraries
* `PyBluez2`
* `Bleak` (Bluetooth Low Energy platform-agnostic client)

---

## Pose Estimation & Hand Tracking with MediaPipe

MediaPipe by Google provides cross-platform, customizable ML solutions for live and streaming media.

### Key MediaPipe Solutions
* **Face Detection & Face Mesh** (Detailed 3D facial landmarks)
* **Hands** (21 3D hand joint landmarks per hand)
* **Pose** (33 3D full-body pose landmarks)
* **Holistic** (Combined face, hands, and pose tracking)
* **Object Tracking & Selfie Segmentation**

---

### Implementation 1: Hand Detection & Landmark Extraction

```python
import cv2
import mediapipe as mp

# Initialize MediaPipe Hands solution
mp_hands = mp.solutions.hands
mp_drawing = mp.solutions.drawing_utils

# Load image
image_path = 'hand_sample.jpg'
image = cv2.imread(image_path)

with mp_hands.Hands(
    static_image_mode=True,
    max_num_hands=2,
    min_detection_confidence=0.5
) as hands:
    # Convert BGR image to RGB
    rgb_image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    
    # Flip image horizontally for natural self-view display
    flipped_image = cv2.flip(rgb_image, 1)
    
    # Process image and extract landmarks
    results = hands.process(flipped_image)
    
    if results.multi_hand_landmarks:
        for hand_idx, hand_landmarks in enumerate(results.multi_hand_landmarks):
            # Print handedness (Left vs Right)
            handedness = results.multi_handedness[hand_idx].classification[0].label
            print(f"Handedness: {handedness}")
            
            # Print Index Finger Tip coordinates (Landmark ID 8)
            index_tip = hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP]
            print(f"Index Finger Tip - X: {index_tip.x:.4f}, Y: {index_tip.y:.4f}, Z: {index_tip.z:.4f}")
            
            # Draw landmarks on image
            mp_drawing.draw_landmarks(
                image, hand_landmarks, mp_hands.HAND_CONNECTIONS
            )
```

---

### Implementation 2: Pose Detection on Images

```python
import cv2
import mediapipe as mp

# Initialize MediaPipe Holistic / Pose solution
mp_pose = mp.solutions.pose
mp_drawing = mp.solutions.drawing_utils

# Load image
image = cv2.imread('person_sample.jpg')

with mp_pose.Pose(
    static_image_mode=True,
    model_complexity=2,
    min_detection_confidence=0.5
) as pose:
    # Convert BGR to RGB and flip around y-axis
    rgb_image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    flipped_image = cv2.flip(rgb_image, 1)
    
    results = pose.process(flipped_image)
    
    if results.pose_landmarks:
        # Extract Nose landmark coordinates (Landmark ID 0)
        nose = results.pose_landmarks.landmark[mp_pose.PoseLandmark.NOSE]
        print(f"Nose Coordinates - X: {nose.x:.4f}, Y: {nose.y:.4f}, Z: {nose.z:.4f}")
        
        # Draw pose skeleton landmarks
        mp_drawing.draw_landmarks(
            image, results.pose_landmarks, mp_pose.POSE_CONNECTIONS
        )
```

---

### Implementation 3: Real-Time Video Pose Tracking & Joint Extraction

```python
import cv2
import mediapipe as mp

mp_pose = mp.solutions.pose
mp_drawing = mp.solutions.drawing_utils

# Open webcam or video file
cap = cv2.VideoCapture(0)

point_list = []  # Store joint history

with mp_pose.Pose(
    min_detection_confidence=0.5,
    min_tracking_confidence=0.5
) as pose:
    while cap.isOpened():
        success, frame = cap.read()
        if not success:
            break
            
        # Convert BGR to RGB and flip
        rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        flipped_frame = cv2.flip(rgb_frame, 1)
        
        # Process frame
        results = pose.process(flipped_frame)
        
        if results.pose_landmarks:
            # Draw landmarks on frame
            mp_drawing.draw_landmarks(
                frame, results.pose_landmarks, mp_pose.POSE_CONNECTIONS
            )
            
            # Extract joints into Point List
            frame_points = []
            for landmark in results.pose_landmarks.landmark:
                frame_points.append((landmark.x, landmark.y, landmark.z, landmark.visibility))
            
            point_list.append(frame_points)
        
        cv2.imshow('MediaPipe Pose Tracking', frame)
        if cv2.waitKey(5) & 0xFF == 27:  # ESC to exit
            break

cap.release()
cv2.destroyAllWindows()
```

---

## Contact Information

For inquiries regarding labs, lectures, or project supervision:

* **Farida Darwish:** [fdarwish@msa.edu.eg](mailto:fdarwish@msa.edu.eg)
* **Mahmoud Ashraf:** [maashraf@msa.edu.eg](mailto:maashraf@msa.edu.eg)
* **Ahmed Kamaleldin:** [akamaleldin@msa.edu.eg](mailto:akamaleldin@msa.edu.eg)
* **Mohamed Abdelfattah:** [maabdelfattah@msa.edu.eg](mailto:maabdelfattah@msa.edu.eg)

---
*October University for Modern Sciences and Arts (MSA University)*
