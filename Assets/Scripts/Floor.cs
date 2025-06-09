using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject m_Start;
    [SerializeField] GameObject m_End;

    public void SpawnNext() 
    {
        Debug.Log("Spawn next");
    }
}
