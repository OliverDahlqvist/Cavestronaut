using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour {
    
    #region Visible Variables
    public Enums.GravityEnum newGravity;
    [SerializeField]
    private ParticleSystem particlesUp;
    [SerializeField]
    private ParticleSystem particlesDown;
    #endregion

    #region Hidden Variables
    private GravityManager gravityManager;
    private BoxCollider2D boxCollider;
    #endregion

    void Start () {
        gravityManager = FindObjectOfType<GravityManager>();
        boxCollider = GetComponent<BoxCollider2D>();
        UpdateParticles();
	}
	
	void Update () {
		
	}

    public void UpdateParticles()
    {
        if((int)newGravity > (int)gravityManager.currentGravity)
        {
            
            //if (particlesUp.isPlaying)
                particlesUp.Stop();
            //if (!particlesDown.isPlaying)
                particlesDown.Play();

            boxCollider.enabled = true;
        }
        else if((int)newGravity < (int)gravityManager.currentGravity)
        {
            //if (!particlesUp.isPlaying)
                particlesUp.Play();
            //if (particlesDown.isPlaying)
                particlesDown.Stop();
            
            boxCollider.enabled = true;
        }
        else if((int)newGravity == (int)gravityManager.currentGravity)
        {
            if(particlesUp.isPlaying)
                particlesUp.Stop();
            if(particlesDown.isPlaying)
                particlesDown.Stop();

            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gravityManager.UpdateGravity(newGravity);
        }
    }
}
