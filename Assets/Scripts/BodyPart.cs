using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public BodyPart _behindBodyPart;
    public BodyPartLast _lastBodyPart;

    public Queue<Tuple<Vector3, Quaternion>> _upcomingPositions = new Queue<Tuple<Vector3, Quaternion>>();
    private int _queueLength = 0;

    public Tuple<Vector3, Quaternion> _actPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(_actPosition.Item1, _actPosition.Item2);
        if (_queueLength > 25)
        {
            if (_lastBodyPart != null)
                _lastBodyPart.PushPositionToQueue(_upcomingPositions.Dequeue());
            else if (_behindBodyPart != null)
                _behindBodyPart.PushPositionToQueue(_upcomingPositions.Dequeue());
            else
                _upcomingPositions.Dequeue();
            _queueLength--;
        }
    }

    public void PushPositionToQueue(Tuple<Vector3, Quaternion> positionTuple)
    {
        _actPosition = positionTuple;
        _queueLength++;
        _upcomingPositions.Enqueue(positionTuple);
    }
}
