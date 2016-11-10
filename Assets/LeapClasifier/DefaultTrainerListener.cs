using UnityEngine;
using System.Collections.Generic;

public class DefaultTrainerListener : MonoBehaviour {

    public LeapTrainer trainer;
    bool isTraining = false;

    void Start()
    {
        if (trainer)
        {
            // These are DELEGATES so one adition is enought to receive callbacks
            trainer.OnGestureCreated += Trainer_OnGestureCreated;
            trainer.OnGestureRecognized += Trainer_OnGestureRecognized;
            trainer.OnGestureUnknown += Trainer_OnGestureUnknown;
            trainer.OnTrainingCountdown += Trainer_OnTrainingCountdown;
            trainer.OnTrainingStarted += Trainer_OnTrainingStarted;
            trainer.OnTrainingComplete += Trainer_OnTrainingComplete;

            // This will only be needed in case you change the parameter inside LeapTrainer
            // because youll be able to track when a training gesture is recorded and notify the
            // repetitions left. 
            //  int trainingGestures = 1;   // The number of gestures samples that collected during training
            trainer.OnTrainingGestureSaved += Trainer_OnTrainingGestureSaved;
        }
    }

    private void Trainer_OnGestureCreated(string name, bool trainingSkipped)
    {
        Debug.Log("Gesture " + name + " has been created");
    }

    private void Trainer_OnTrainingCountdown(int countdown)
    {
        Debug.Log("Training will start in " + countdown + " seconds");
    }

    private void Trainer_OnTrainingStarted(string name)
    {
        Debug.Log("Started training gesture " + name);
    }

    private void Trainer_OnTrainingComplete(string name, List<List<Point>> gestures, bool isPose)
    {
        Debug.Log("Finished training gesture " + name);
    }

    private void Trainer_OnGestureRecognized(string name, float value, Dictionary<string, float> allHits)
    {
        Debug.Log("Gesture " + name + " recognized: " + value);
    }

    private void Trainer_OnGestureUnknown(Dictionary<string, float> allHits)
    {
        Debug.Log("No gesture recognized...");

        // However you can still work with the hits in case I detect some recording are underperforming...
        // For instance: if you have a recording that the best match is a value of 0.5 but the threshold is 0.7 you'll 
        //   never be notified, but you'll still receive the value here.
    }

    private void Trainer_OnTrainingGestureSaved(string name, List<List<Point>> gestures)
    {
        Debug.Log("Training gesture recorded... X more to go.");
    }
}
