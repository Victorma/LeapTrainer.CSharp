using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Leap;
using System;

public class RecordLoader : MonoBehaviour {

    public string recorderFilePath;
    public LeapTrainer trainer;

    private LeapRecorder loader;

    // Use this for initialization
    void Start () {
        loader = new LeapRecorder();
        loader.Load(recorderFilePath);
        /*var original = ;
        var clean = CleanFrames(original);
        Debug.Log("Original: " + original.Count + " Cleaned: " + clean.Count);*/

        trainer.loadFromFrames(recorderFilePath, loader.GetFrames(), false);
	}

    private List<Frame> CleanFrames(List<Frame> toClean)
    {
        var sum = toClean.Sum(f => FrameSum(f));
        Debug.Log("Sum: " + sum);
        return toClean.FindAll(f => IsGoodFrame(f));
    }

    private bool IsGoodFrame(Frame frame)
    {
        return frame.Hands.TrueForAll(h => IsGoodVector(h.StabilizedPalmPosition) && h.Fingers.TrueForAll(f => IsGoodVector(f.StabilizedTipPosition)));
    }

    private bool IsGoodVector(Leap.Vector v)
    {
        return !float.IsInfinity(Point.Distance(new Point(), new Point(v.x, v.y, v.z, 0)));
    }

    public float FrameAverage(Frame frame)
    {
        return frame.Hands.Average(h => HandAverage(h));
    }

    public float HandAverage(Hand hand)
    {
        return hand.Fingers.ConvertAll(f1 => f1.StabilizedTipPosition).Average(f => f.Magnitude);
    }

    public float FrameSum(Frame frame)
    {
        return frame.Hands.Sum(h => HandSum(h));
    }

    public float HandSum(Hand hand)
    {
        Point prev = new Point(hand.StabilizedPalmPosition.x, hand.StabilizedPalmPosition.y, hand.StabilizedPalmPosition.z, 0);
        //bool first = true;
        //Point prev = new Point();
        float distance = 0f;
        hand.Fingers.ConvertAll(f => f.StabilizedTipPosition).ForEach(f => {
            Point p = new Point(f.x, f.y, f.z, 0);
           // if (first) first = false;
            distance += Point.Distance(p, prev);
            if (float.IsInfinity(distance))
                return;
            prev = p;
        });
        return distance;
    }

}
