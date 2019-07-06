using System.Collections.Generic;
using UnityEngine;

public class Instancier : MonoBehaviour
{
    private Vector3[] pos = new Vector3[30];
    public GameObject keyPrefab = default;
    public GameObject[] keys = default;

    public List<int> spawnAllId = default;
    public List<int> spawUniqueRandom = default;

    private void Start()
    {
        keys = new GameObject[10];
        CreateSpawPositions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RandomPositions();
        }
    }

    private void CreateSpawPositions()
    {
        //generate all positions
        int[] x = new int[5] { 0, -2, -4, -6, -8 };
        int[] z = new int[6] { 0, -2, -4, -6, -8, -10 };

        int posIndex = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                pos[posIndex] = new Vector3(x[j] + 4, 0f, z[i] + 6);
                print(pos[posIndex]);
                posIndex++;
            }
        }
    }

    private void RandomPositions()
    {
        DestroyAllKeysExisting();

        //Simple addition of sequential indices
        for (int i = 0; i < 30; i++)
        {
            spawnAllId.Add(i);
        }

        //sort only 10 unique numbers
        for (int i = 0; i < 10; i++)
        {
            int n = Random.Range(0, spawnAllId.Count);
            spawUniqueRandom.Add(spawnAllId[n]);
            print(spawnAllId[n]);
            spawnAllId.Remove(spawnAllId[n]);
        }
        //Instantiated the keys in the correct locations
        for (int i = 0; i < spawUniqueRandom.Count; i++)
        {
            Quaternion quat = new Quaternion();
            keys[i] = Instantiate(keyPrefab, pos[spawUniqueRandom[i]], quat);
        }
    }

    private void DestroyAllKeysExisting()
    {
        //reset all lists and destroy all instantiate keys
        if (spawnAllId.Count > 0)
        {
            spawnAllId.Clear();
        }
        if (spawUniqueRandom.Count > 0)
        {
            spawUniqueRandom.Clear();

            if (keys.Length > 0)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    Destroy(keys[i]);
                }
            }
        }
    }
}
