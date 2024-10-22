using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    public GameObject ground;
    public Renderer renderer;
    [SerializeField] private Basdepapji basde;

    private List<Chunk> spawnedChunk = new List<Chunk>();

    private void Start()
    {
        spawnedChunk.Add(FirstChunk);
        renderer = ground.GetComponent<Renderer>();
    }

    private void Update()
    {
        if(Player != null)
        {
            if (Player.position.y > spawnedChunk[spawnedChunk.Count - 1].End.position.y - 100)
            {
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunk[spawnedChunk.Count-1].End.position - newChunk.Begin.localPosition;
        spawnedChunk.Add(newChunk);
        basde.chunkCount += 1;
        if (spawnedChunk.Count >= 7)
        {
            Destroy(spawnedChunk[0].gameObject);
            spawnedChunk.RemoveAt(0);
            ground.transform.position = spawnedChunk[0].Begin.position;
            renderer.material = spawnedChunk[0].material;
        }
    }


}
