using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour {

	//Parralax variable
	public float parralax = 2f;

	void Update () {
		//Get mesh renderer
		MeshRenderer mr = GetComponent<MeshRenderer>();

		//Get materal
		Material mat = mr.material;

		//Vector2 offset
		Vector2 offset = mat.mainTextureOffset;

		//Set the x and y of offset
		offset.x = transform.position.x / transform.localScale.x / parralax;
		offset.y = transform.position.y / transform.localScale.y / parralax;

		//Result
		mat.mainTextureOffset = offset;

	}

}
