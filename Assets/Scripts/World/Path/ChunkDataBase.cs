using UnityEngine;
using System.Collections;

public class ChunkDataBase : MonoBehaviour {
	[SerializeField]private Chunk[] _chunks;
	public Chunk[] Chunks {
		get { 
			return _chunks;
		}
	}
}
