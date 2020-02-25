using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    GameObject PlayerRef;
    NavMeshAgent navBoi;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = GameObject.Find("PlayerFab");
        navBoi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        navBoi.destination = PlayerRef.transform.position;
    }
}
