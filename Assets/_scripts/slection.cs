using UnityEngine;

public class slection : MonoBehaviour
{
    Camera cam;
    GameObject cameras;
   static public GameObject selectedObject;
    GameObject hoverObject;
    [SerializeField] ui_manager ui_man;
    public float speed;
    Vector3 mouse_init_pos;

    private void Start()
    {
        Vector3 mouse_init_pos = Input.mousePosition;
        if (cam == null)
        {
            cam = Camera.main;
        }
        cameras = cam.transform.parent.gameObject;
    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mouse_new_pos = Input.mousePosition;
            print(mouse_new_pos.x - mouse_init_pos.x);
            pan_cam(mouse_new_pos.x - mouse_init_pos.x);
        }
        selection();
        mouse_init_pos = Input.mousePosition;
    }
    void selection()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        object_deselect(selectedObject);
        object_deselect(hoverObject);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.collider.gameObject.transform.position, Color.green);
            if (hit.collider.tag == "npc")
            {
                hoverObject = hit.collider.gameObject;
                if (Input.GetMouseButtonDown(0))
                {
                    if (selectedObject != null)
                    {
selectedObject.GetComponent<SpriteRenderer>().color = Color.white;
                        selectedObject.transform.GetChild(0).gameObject.SetActive(false);
                    }
                        
                    selectedObject = hoverObject;
                }

            }
            else
            {
                hoverObject = null;
            }
        }

        if ((selectedObject == null || hoverObject != selectedObject) && hoverObject != null)
        {
            hoverObject.GetComponent<SpriteRenderer>().color = Color.green;
            hoverObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (selectedObject != null)
        {
            selectedObject.GetComponent<SpriteRenderer>().color = Color.red;
            selectedObject.transform.GetChild(0).gameObject.SetActive(true);
            ui_man.char_data_assign(selectedObject);
        }
    }

    private void pan_cam(float v)
    {
        if (v == 0) return;
        Vector3 left = new Vector3(370.200012f, 147.200012f, 480.600006f);
        if (v < 0)
            cameras.transform.position = Vector3.MoveTowards(cameras.transform.position, left, speed);
        else
            cameras.transform.position = Vector3.MoveTowards(cameras.transform.position, new Vector3(290.899994f, 147.200012f, 367), speed);
    }

    void object_deselect(GameObject tar)
    {
        if (tar != null)
        {
            tar.GetComponent<SpriteRenderer>().color = Color.white;
            tar.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void obj_deslect()
    {
        if (selectedObject != null)
        {
selectedObject.GetComponent<SpriteRenderer>().color = Color.white;
            selectedObject.transform.GetChild(0).gameObject.SetActive(false);
        }
                        
        selectedObject = null;
    }
}