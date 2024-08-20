using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TastViewWeapon : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _mesh; // сделано просто на будующие например для смены скинов.

    
    void Awake()
    {
        _mesh = GetComponent<SkinnedMeshRenderer>();   
    }
    public void SetModel(Mesh mesh)
    {
        _mesh.sharedMesh  = mesh;
    }
    public void SpawnEffect() // про что я и говорил spawnEffect
    {
        // тут пусто )
    }
    public void SetParent(Transform parent)
    {
        if(parent == null) return;
        transform.parent = parent;
    }
}
