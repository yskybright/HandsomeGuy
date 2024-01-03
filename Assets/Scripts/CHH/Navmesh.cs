using UnityEngine;

public class Navmesh : MonoBehaviour
{
    NavMeshPlus.Components.NavMeshSurface surfaces;

    private void Awake()
    {
        surfaces = GetComponent<NavMeshPlus.Components.NavMeshSurface>();
    }

    private void OnEnable()
    {
        if (surfaces != null)
        {
            surfaces.BuildNavMesh();
        }
        else
        {
            Debug.LogError("NavMeshSurface component not found!");
        }
    }
}