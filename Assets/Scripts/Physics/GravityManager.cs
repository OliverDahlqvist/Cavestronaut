using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GravityState
{
    public Enums.GravityEnum gravityEnum;
    public float value;
}

public class GravityManager : MonoBehaviour {
    #region Visible Variables
    public Enums.GravityEnum currentGravity;
    public GravityState[] gravityStates;
    #endregion

    #region Hidden Variables
    public List<GravityObject> gravityObjects = new List<GravityObject>();
    public List<GravityField> gravityFields = new List<GravityField>();
    #endregion

    void Start () {
        gravityObjects.AddRange(FindObjectsOfType<GravityObject>());
        gravityFields.AddRange(FindObjectsOfType<GravityField>());
        UpdateGravity(currentGravity);
    }
	
	void Update () {
		
	}

    public void UpdateGravity(Enums.GravityEnum newGravity)
    {
        currentGravity = newGravity;
        foreach (GravityObject gravityObject in gravityObjects)
        {
            if (!gravityObject.started)
                gravityObject.Initialize();
            
            gravityObject.Rigidbody.gravityScale = gravityStates[(int)currentGravity].value;
        }
        foreach (GravityField field in gravityFields)
        {
            field.UpdateParticles();
        }
    }
}