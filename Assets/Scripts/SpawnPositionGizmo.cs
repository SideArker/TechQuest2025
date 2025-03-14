using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionGizmo : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}

