using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    #region Hidden Variables
    private Animator animator;
    private GameObject lightObject;
    #endregion

    void Start () {
        animator = GetComponent<Animator>();
        if(transform.childCount > 0)
            lightObject = transform.GetChild(0).gameObject;
	}

    public void EnableCheckpoint()
    {
        if(animator != null)
            animator.SetBool("isOn", true);
        if(lightObject != null)
            lightObject.SetActive(true);
    }
    public void DisableCheckpoint()
    {
        if(animator != null)
            animator.SetBool("isOn", false);
        if(lightObject != null)
            lightObject.SetActive(false);
    }
}
