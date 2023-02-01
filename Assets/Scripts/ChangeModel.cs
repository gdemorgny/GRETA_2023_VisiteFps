using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour,IUsableObject
{
    [SerializeField] private GameObject[] _PrefabsToSpawn;
    private GameObject _objectSpawned;
    private int _actualPrefabNumber = -1;

    private void Start()
    {
        SpawnNewPrefab();
    }


    public void UseObject() { SpawnNewPrefab(); }

    private void SpawnNewPrefab()
    {
        if (_objectSpawned )
        {
            Destroy(_objectSpawned);
        }

        _actualPrefabNumber++;
        if (_actualPrefabNumber >= _PrefabsToSpawn.Length)
        {
            _actualPrefabNumber = 0;
        }
        _objectSpawned = Instantiate(_PrefabsToSpawn[_actualPrefabNumber], transform.position, transform.rotation);
    }
}
