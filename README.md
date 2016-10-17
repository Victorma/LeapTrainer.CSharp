# LeapTrainer.CSharp
This is a port of https://github.com/roboleary/LeapTrainer.js to be used in Unity.

To use it, add it as a Component to any GameObject and link a LeapProvider to it.

To receive interaction, make sure you register to the events in LeapTrainer:
```csharp
    public event StartedRecordingDelegate     OnStartedRecording;
    public event EndedRecordingDelegate       OnEndedRecording;
    public event GestureDetectedDelegate      OnGestureDetected;
    public event GestureCreatedDelegate       OnGestureCreated;
    public event GestureRecognizedDelegate    OnGestureRecognized;
    public event GestureUnknownDelegate       OnGestureUnknown;
    
    // THE RUNTIME TRAINING IS NOT WORKING YET, SEE FEATURES
    public event TrainingCountdownDelegate    OnTrainingCountdown;
    public event TrainingStartedDelegate      OnTrainingStarted;
    public event TrainingCompleteDelegate     OnTrainingComplete;
    public event TrainingGestureSavedDelegate OnTrainingGestureSaved;
 ```

## Features
- [x] Train the trainer adding a set of recorded frames (LeapTrainer.loadFromFrames(...))
- [x] Train the trainer using a JSON (LeapTrainer.fromJSON(...)) **This is not tested.**
- [ ] Runtime training: See https://github.com/Victorma/LeapTrainer.CSharp/issues/2#issuecomment-254290932
- [x] Recognition using Geometric Template Matcher.
- [ ] Recognition using Cross Correlation.
- [ ] Recognition using Neural Networks. 

## Status
Some parts of the trainer are unfinished, but you might find help in these discussions:
* https://github.com/Victorma/LeapTrainer.CSharp/issues/1
* https://github.com/Victorma/LeapTrainer.CSharp/issues/2

Any contribution to finish the project is appreciated since I don't have a LeapMotion device anymore.
