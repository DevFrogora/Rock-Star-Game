using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RockDragMove : MonoBehaviour , IBeginDragHandler ,IDragHandler,IEndDragHandler
{
    private void Start()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");
        // Vector3.up makes it move in the world x/z plane.
        MoveOnPlaneSurface(Vector3.up, transform.position, eventData);
        //MoveObjectRelativeToScreenMousePosition(eventData);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("eng");

    }

    void MoveObjectRelativeToScreenMousePosition(PointerEventData eventData)
    {
        Vector3 distanceToScreen = Camera.main.WorldToScreenPoint(transform.position);
        //Debug.Log(distanceToScreen); // its screen position from the center of canvas ;
        Vector3 c = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x,
            eventData.position.y, distanceToScreen.z)); // here z is just for depth
        //Debug.DrawLine(Camera.main.transform.position, c);
        transform.position = c;
        //Debug.Log(c);
    }

    void MoveOnPlaneSurface(Vector3 normaldirection, Vector3 originOfPlane , PointerEventData eventData)
    {
        // normal direction is the normal vector of plane
        // origin of plane is where the plane start
        Plane plane = new Plane(normaldirection, originOfPlane);
        Ray ray = eventData.pressEventCamera.ScreenPointToRay(eventData.position);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            //Debug.Log(distance);
            //Debug.DrawLine(ray.origin, transform.position);
            //vector3 direction = destinationPos - sourcePos; // here we are going from camera to our object ( and the direction(+/-) according to moving direction in world spave)
            //Debug.Log("ray origin: " + ray.origin + "ray Direction" + ray.direction + "distance from plane" + distance);
            //Debug.Log("multiplication " + ray.direction * distance);

            //Vector3 clickedPos = (ray.origin + ray.direction * distance);
            //float offset = (transform.position - clickedPos).magnitude ;
            transform.position = (ray.origin + ray.direction * distance ); // moving ray from a origin upto given distance in the given direction = position
        }
    }

}
