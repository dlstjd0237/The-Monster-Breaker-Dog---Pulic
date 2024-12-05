using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshSet : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
    }

    public void NavMeshSetBake()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
