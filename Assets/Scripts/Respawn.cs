using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    #region Visible Variables
    #endregion

    #region Hidden Variables
    CheckpointManager m_checkpointManager;
    bool m_isPlayer;
    Vector2 m_spawnPosition;
    Rigidbody2D m_rigidbody;
    private EffectManager m_effectManager;
    #endregion

    private void Start()
    {
        m_checkpointManager = FindObjectOfType<CheckpointManager>();
        m_effectManager = FindObjectOfType<EffectManager>();
        m_rigidbody = GetComponent<Rigidbody2D>();

        if (CompareTag("Player"))
            m_isPlayer = true;
        else
        {
            m_isPlayer = false;
            m_spawnPosition = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Kill"))
        {
            RespawnObject();
        }
    }

    private void RespawnObject()
    {
        Instantiate(m_effectManager.respawnObject, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        if (m_isPlayer)
            transform.position = m_checkpointManager.currentCheckpoint.transform.position;
        else
        {
            transform.position = m_spawnPosition;
            m_rigidbody.velocity = Vector2.zero;
        }
    }
}
