using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour {

	void Update () {

		//Mesh renderer
		MeshRenderer mr = GetComponent<MeshRenderer>();

		//Materal
		Material mat = mr.material;

		//Offset
		Vector2 offset = mat.mainTextureOffset;

		//X of offset, scrolling by time/float
		offset.x += Time.deltaTime / 10f;

		//Result
		mat.mainTextureOffset = offset;

	}

}
