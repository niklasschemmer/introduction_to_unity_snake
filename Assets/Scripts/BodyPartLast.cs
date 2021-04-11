using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartLast : MonoBehaviour
{
    public Tuple<Vector3, Quaternion> _actPosition;

    public Queue<Tuple<Vector3, Quaternion>> _upcomingPositions = new Queue<Tuple<Vector3, Quaternion>>();
    private int _queueLength = 0;

    [SerializeField]
    public BodyPartLastTwo _bodyPartLastTwoPrefab;

    public BodyPartLastTwo _bodyPartLastTwo;

    // Start is called before the first frame update
    void Start()
    {
        _bodyPartLastTwo = Instantiate(_bodyPartLastTwoPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(_actPosition.Item1, _actPosition.Item2);
        if (_queueLength > 30)
        {
            if (_bodyPartLastTwo != null)
                _bodyPartLastTwo.PushPositionToQueue(_upcomingPositions.Dequeue());
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
