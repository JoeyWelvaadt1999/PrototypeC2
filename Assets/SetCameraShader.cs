using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetCameraShader : MonoBehaviour {
	public Material mat;
	void OnRenderImage(RenderTexture src, RenderTexture dest) {
		Graphics.Blit(src, dest, mat);
	}
}
