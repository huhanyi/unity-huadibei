using UnityEngine;

public class ScreenDrag : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                dragging = true;
                offset = transform.position - hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0)) dragging = false;

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 point = ray.GetPoint(distance);
                transform.position = new Vector3(transform.position.x, transform.position.y, point.z + offset.z);
            }
        }
    }
}
