using UnityEngine;

public class slection : MonoBehaviour
{
    Camera cam;
    GameObject cameras;
    GameObject selectedObject;
    GameObject hoverObject;
    [SerializeField] ui_manager ui_man;
    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        cameras = cam.transform.parent.gameObject;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        object_deselect(selectedObject);
        object_deselect(hoverObject);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin,hit.collider.gameObject.transform.position,Color.green);
            if (hit.collider.tag == "npc")
            {
                hoverObject = hit.collider.gameObject;
                if (Input.GetMouseButtonDown(0))
                    selectedObject = hoverObject;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                selectedObject = null;
                ui_man.close_pannel(0);
            }
            else
            {
                hoverObject = null;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            selectedObject = null;
            ui_man.close_pannel(0);
        }


        if ((selectedObject == null || hoverObject != selectedObject) && hoverObject != null)
        {
            hoverObject.GetComponent<SpriteRenderer>().color = Color.green;
        }

        if (selectedObject != null)
        {
            selectedObject.GetComponent<SpriteRenderer>().color = Color.red;
            ui_man.char_data_assign(selectedObject);
        }


    }


    void object_deselect(GameObject tar)
    {
        if (tar != null)
        {
            tar.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}