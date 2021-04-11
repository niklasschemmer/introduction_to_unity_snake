using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartFirst : MonoBehaviour
{
    [SerializeField]
    public BodyPart _bodyPartPrefab;
    [SerializeField]
    public BodyPartLast _lastBodyPartPrefab;

    public BodyPart _behindBodyPart;
    public BodyPartLast _lastBodyPart;

    private Queue<Tuple<Vector3, Quaternion>> _upcomingPositions = new Queue<Tuple<Vector3, Quaternion>>();
    private int _queueLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        _lastBodyPart = Instantiate(_lastBodyPartPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AddBodyPart();
        }

        var movementForward = Vector3.right * Time.deltaTime * 3;
        var rotation = Vector3.up * Time.deltaTime * 100 * Input.GetAxis("Horizontal");

        transform.Translate(movementForward);
        transform.Rotate(rotation);

        _upcomingPositions.Enqueue(new Tuple<Vector3, Quaternion>(transform.position, transform.rotation));
        _queueLength++;
        if(_queueLength > 25)
        {
            if(_lastBodyPart != null)
                _lastBodyPart.PushPositionToQueue(_upcomingPositions.Dequeue());
            else if (_behindBodyPart != null)
                _behindBodyPart.PushPositionToQueue(_upcomingPositions.Dequeue());
            else
                _upcomingPositions.Dequeue();
            _queueLength--;
        }
    }

    public void AddBodyPart()
    {
        if (_behindBodyPart == null)
        {
            _behindBodyPart = Instantiate(_bodyPartPrefab, transform.position, transform.rotation);
            _behindBodyPart._lastBodyPart = _lastBodyPart;
            _lastBodyPart = null;
        }
        else
        {
            var instanciatedBodyPart = Instantiate(_bodyPartPrefab);
            instanciatedBodyPart._behindBodyPart = _behindBodyPart;
            _behindBodyPart = instanciatedBodyPart;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We collided");
    }
}
