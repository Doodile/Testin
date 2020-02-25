using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTest : BaseInteract_Nick
{
    public GameObject toSpawn;
    public Vector3 locToSpawn;

    public override void Interact()
    {
        Instantiate(toSpawn, locToSpawn, Quaternion.identity);
    }
}
