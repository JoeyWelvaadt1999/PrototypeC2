using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	private ChunkDataBase _chunks;

	private void Start() {
		_chunks = GetComponent<ChunkDataBase> ();

	}

	private void CreateWorld () {
		
	}
}
