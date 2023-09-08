using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject ReferencePoint;

    private void Awake()
    {
        GameDirectorController.GameDirector.AddSpawner(this);
        Destroy(ReferencePoint);
    }
}
