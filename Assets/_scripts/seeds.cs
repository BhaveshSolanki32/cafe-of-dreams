using UnityEngine;
public class seeds : MonoBehaviour
{
    //envy
    //lust
    //greed
    //glut
    //sloth
    //pride
    //wraath
    public int num_of_seed = 0;
    public string title;
    public string about;
    int index;
    public Sprite badge;
    public string[] pos_tags;
    public string[] neg_tags;

    private void Start() => index = transform.GetSiblingIndex();

    public void seed_select_btn()
    {
        if (num_of_seed > 0)
        {
            if (slection.selectedObject != null)
            {
                slection.selectedObject.GetComponent<charater_d>().seeded = true;
                slection.selectedObject.GetComponent<charater_d>().seed_type.Add(index);
                slection.selectedObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                slection.selectedObject.transform.GetChild(0).GetChild(0).GetChild(index).gameObject.SetActive(true);
            }
            
        }
    }

}
