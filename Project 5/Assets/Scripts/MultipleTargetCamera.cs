using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour {

public Vector3 offset;
public List <Transform> targets;
public Camera cam;
public float smoothTime;

public float minZoom=40f;
public float maxZoom=10f;
public float zoomLimiter=50f;
private Vector3 velocity;
void LateUpdate() {
if(targets.Count==0)
return;
Move();
Zoom();
}


void Zoom()
{
float newZoom = Mathf.Lerp(maxZoom,minZoom,GetGreatestDistance());
cam.orthographicSize= Mathf.Lerp(cam.orthographicSize,newZoom,Time.deltaTime);
}

float GetGreatestDistance(){
var bounds= new Bounds(targets[0].position,Vector3.zero);
for (int i = 0; i < targets.Count; i++)
{
	bounds.Encapsulate(targets[i].position);
}
return bounds.size.x;
}
void Move(){

	Vector3 centerPoint= GetCenterPoint();

	Vector3 newPosition= centerPoint+offset;

	transform.position = newPosition;

	transform.position = Vector3.SmoothDamp(transform.position,newPosition, ref velocity,smoothTime);
}

Vector3 GetCenterPoint(){
if(targets.Count==1){
	return targets[0].position;
}

var bounds = new Bounds(targets[0].position,Vector3.zero);
// Jesus Christ 
for (int i = 0; i < targets.Count; i++)
{
	bounds.Encapsulate(targets[i].position);
}
return bounds.center;
}

}
