using UnityEngine;

public class slection : MonoBehaviour
{
    public Camera cam;
    public GameObject selectedObject;
    GameObject hoverObject;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        object_deselect(selectedObject);
        object_deselect(hoverObject);

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "npc")
        {
            hoverObject = hit.collider.gameObject;
            if (Input.GetMouseButtonDown(0))
                selectedObject = hoverObject;
        }

        if ((selectedObject == null || hoverObject != selectedObject)&& hoverObject!=null)
            hoverObject.GetComponent<SpriteRenderer>().color = Color.green;
        if (selectedObject != null)
            selectedObject.GetComponent<SpriteRenderer>().color = Color.red;


    }



    void object_deselect(GameObject tar)
    {
        if (tar != null)
        {
            tar.GetComponent<SpriteRenderer>().color = Color.white;
            tar = null;
        }
    }
}