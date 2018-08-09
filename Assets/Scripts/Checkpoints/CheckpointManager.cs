using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {
    
    #region Visible Variables
    //public GameObject checkpointParent;

    [Header("Checkpoints")]
    public Checkpoint currentCheckpoint;
    #endregion

    #region Hidden Variables
    //private Checkpoint[] m_checkpoints;
    #endregion

    void Start () {

	}
	
	void Update () {
		
	}

    public void SetCheckpoint(Checkpoint newCheckpoint)
    {
        if(currentCheckpoint != null)
            currentCheckpoint.DisableCheckpoint();

        currentCheckpoint = newCheckpoint;
        currentCheckpoint.EnableCheckpoint();
    }
    public void SetCheckpoint(GameObject newCheckpoint)
    {
        if (currentCheckpoint != null)
            currentCheckpoint.DisableCheckpoint();

        currentCheckpoint = newCheckpoint.GetComponent<Checkpoint>();
        currentCheckpoint.EnableCheckpoint();
    }
}
