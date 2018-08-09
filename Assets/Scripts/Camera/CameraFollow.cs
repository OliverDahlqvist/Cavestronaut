using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] Transform target;

    public float viewSpeed = 0.25f;

    private Vector3 newPosition;

    void Start () {
		
	}
    private void Update()
    {
        newPosition = new Vector3(target.position.x, target.position.y, -10);
    }

    private void FixedUpdate()
    {
        //if respawn viewSpeed = 0
        //if viewSpeed < 0.25 ++
        transform.position = Vector3.Lerp(transform.position, newPosition, viewSpeed);
    }

}
