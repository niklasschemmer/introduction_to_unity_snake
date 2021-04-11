using System;
using UnityEngine;

public class BodyPartLastThree : MonoBehaviour
{
    public Tuple<Vector3, Quaternion> _actPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(_actPosition.Item1, _actPosition.Item2);
    }

    public void PushPositionToQueue(Tuple<Vector3, Quaternion> positionTuple)
    {
        _actPosition = positionTuple;
    }
}
