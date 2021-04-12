using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartLastTwo : MonoBehaviour
{
    public Tuple<Vector3, Quaternion> _actPosition;

    public Queue<Tuple<Vector3, Quaternion>> _upcomingPositions = new Queue<Tuple<Vector3, Quaternion>>();
    private int _queueLength = 0;

    [SerializeField]
    public BodyPartLastThree _bodyPartLastThreePrefab;

    public BodyPartLastThree _bodyPartLastThree;

    // Start is called before the first frame update
    void Start()
    {
        _bodyPartLastThree = Instantiate(_bodyPartLastThreePrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (_actPosition != null)
        {
            transform.SetPositionAndRotation(_actPosition.Item1, _actPosition.Item2);
            if (_queueLength > 15)
            {
                if (_bodyPartLastThree != null)
                    _bodyPartLastThree.PushPositionToQueue(_upcomingPositions.Dequeue());
                else
                    _upcomingPositions.Dequeue();
                _queueLength--;
            }
        }
    }

    public void PushPositionToQueue(Tuple<Vector3, Quaternion> positionTuple)
    {
        _actPosition = positionTuple;
        _queueLength++;
        _upcomingPositions.Enqueue(positionTuple);
    }
}
