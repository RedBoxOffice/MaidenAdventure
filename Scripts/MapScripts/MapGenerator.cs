using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private Transform _spawner;

    private List<Transform> _spawners;
    private Queue<Cube> _cubesQueue;

    private void Start()
    {
        _spawners = new List<Transform>();
        _cubesQueue = new Queue<Cube>();

        for (int i = 0; i < _spawner.childCount; i++)
        {
            _spawners.Add(_spawner.GetChild(i));
        }

        GenerateMap();
    }

    public Cube TransferCoordinateCube(Vector3 vector3)
    {
        foreach (var cube in _cubesQueue)
        {
            if (cube.transform.position == vector3 && cube.TryGetComponent(out EmptyCube emptyCube))
            {
                return cube;
            }
        }

        return null;
    }

    private void GenerateMap()
    {
        for (int i = 0; i < _spawners.Count; i++)
        {
            if (_cubes.Count != 0)
            {
                Vector3 tempSpawner = _spawners[i].transform.position;
                int randomCube = Random.Range(0, _cubes.Count);
                _cubesQueue.Enqueue(Instantiate(_cubes[randomCube], tempSpawner, Quaternion.Normalize(_cubes[randomCube].transform.rotation)));
                _cubes.Remove(_cubes[randomCube]);                
            }
        }       
    }
}
