using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GravityObject : MonoBehaviour {

    #region Visible Variables
    public Enums.GravityEnum gravityState;

    #endregion

    #region Hidden Variables
    [HideInInspector]
    public Rigidbody2D Rigidbody { get; private set; }
    [HideInInspector]
    public  bool started = false;
    #endregion

    void Start () {
        if (!started)
            Initialize();
	}
	
	void Update () {
		
	}

    public void Initialize()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        started = true;
    }
}