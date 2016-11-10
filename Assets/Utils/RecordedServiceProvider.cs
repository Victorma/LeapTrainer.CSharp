using UnityEngine;
using System.Collections;
using Leap.Unity;
using Leap;
using System;

public class RecordedServiceProvider : LeapProvider
{
    public LeapProvider provider;

    private LeapRecorder recorder;
    public LeapRecorder GetLeapRecorder()
    {
        if (recorder == null)
            recorder = new LeapRecorder();

        return recorder;
    }

    public override Frame CurrentFixedFrame
    {
        get
        {
            switch (recorder.state)
            {
                // In these cases, show the playback
                case RecorderState.Playing:
                case RecorderState.Paused:
                    return recorder.GetCurrentFrame();

                // In these cases, show the user input
                default:
                    return provider.CurrentFixedFrame;
            }
        }
    }

    public override Frame CurrentFrame
    {
        get
        {
            switch (recorder.state)
            {
                // In these cases, show the playback
                case RecorderState.Playing:
                case RecorderState.Paused:
                    return recorder.GetCurrentFrame();

                // In these cases, show the user input
                default:
                    return provider.CurrentFrame;
            }
            
        }
    }

    public override Image CurrentImage
    {
        get
        {
            return provider.CurrentImage;
        }
    }

    // Use this for initialization
    void Start () {
        if (!provider)
            provider = GetComponent<LeapServiceProvider>();

        // Fixed Update frame
        // During the fixed update we may provide and or save information
        provider.OnFixedFrame += frame =>
        {
            switch (recorder.state)
            {
                case RecorderState.Recording:
                    recorder.AddFrame(frame);
                    break;
                case RecorderState.Playing:
                    recorder.NextFrame();
                    break;
            }

            DispatchUpdateFrameEvent(this.CurrentFixedFrame);
        };

        // Update frame
        // During the update we only provide information
        provider.OnUpdateFrame += frame =>
        {
            DispatchUpdateFrameEvent(this.CurrentFrame);
        };

        if(recorder == null)
            recorder = new LeapRecorder();

        recorder.state = RecorderState.Stopped;
	}
	
	void Update () {
    }

    void FixedUpdate()
    {

    }

}
