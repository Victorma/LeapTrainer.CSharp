using UnityEngine;
using System.Collections;

public class RecordLoader : MonoBehaviour {

    public string recorderFilePath;
    public LeapTrainer trainer;

    private LeapRecorder loader;

    // Use this for initialization
    void Start () {
        loader = new LeapRecorder();
        loader.Load(recorderFilePath);
        trainer.loadFromFrames(recorderFilePath, loader.GetFrames(), false);
	}
}
