using UnityEngine;
using System.Collections;

public class LeapRecorderController : MonoBehaviour {

    public RecordedServiceProvider recordedProvider;

    public string recorderFilePath;
    public string playerFilePath;
    public KeyCode keyToRecord = KeyCode.R;
    public KeyCode keyToSave = KeyCode.S;
    public KeyCode keyToReset = KeyCode.E;
    public KeyCode keyToPause = KeyCode.Space;
    public KeyCode keyToPlay = KeyCode.Z;
    public KeyCode keyToLoad = KeyCode.L;

    public LeapRecorder recorder;

    // Use this for initialization
    void Start () {
        if (recorder == null)
            this.recorder = recordedProvider.GetLeapRecorder();
	}

    void Update()
    {
        if (Input.GetKeyDown(keyToRecord))
        {
            Debug.Log("Record");
            recorder.Reset();
            recorder.state = RecorderState.Recording;
        }
        else if (Input.GetKeyDown(keyToSave))
        {
            Debug.Log("Save");

            recorder.state = RecorderState.Stopped;
            Debug.Log(recorder.SaveToNewFile(recorderFilePath));
        }
        else if (Input.GetKeyDown(keyToReset))
        {
            recorder.Reset();
            recorder.state = RecorderState.Stopped;
        }
        else if (Input.GetKeyDown(keyToPlay))
        {
            recorder.Play();

        }
        else if (Input.GetKeyDown(keyToPause))
        {
            recorder.state = RecorderState.Paused;
        }
        else if (Input.GetKeyDown(keyToLoad))
        {
            recorder.state = RecorderState.Paused;
            recorder.Reset();
            recorder.Load(playerFilePath);
            recorder.Play();
        }
    }
}
