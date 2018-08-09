using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator m_animator;
    private BoxCollider2D m_collider;

    void Start () {
        m_animator = GetComponent<Animator>();
        m_collider = GetComponent<BoxCollider2D>();
	}

    public void Activate()
    {
        m_animator.SetBool("active", true);
        m_collider.enabled = false;
    }
    public void Disable()
    {
        m_animator.SetBool("active", false);
        m_collider.enabled = true;
    }
}
