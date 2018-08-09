using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoneTrigger : MonoBehaviour {
    public bool isBlue;
    //public UnityEvent triggerEvent;
    public List<Door> objectsToTrigger = new List<Door>();

    private Animator m_animator;
    private List<GameObject> currentColliders = new List<GameObject>();
    

	void Start () {
        m_animator = GetComponent<Animator>();
	}

	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone") && collision.GetComponent<StoneVariables>().isBlue == isBlue)
        {
            currentColliders.Add(collision.gameObject);
            m_animator.SetBool("active", true);
            foreach (Door triggerObject in objectsToTrigger)
            {
                triggerObject.Activate();
            }
            //triggerEvent.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone"))
        {
            currentColliders.Remove(collision.gameObject);

            if (currentColliders.Count <= 0)
            {
                m_animator.SetBool("active", false);
            }
            foreach (Door triggerObject in objectsToTrigger)
            {
                triggerObject.Disable();
            }
        }
    }
}
