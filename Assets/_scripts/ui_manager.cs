using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_manager : MonoBehaviour
{
    bool inv_open = true;
    bool about_open = true;
    public void close_pannel(int num)
    {
        transform.GetChild(num).gameObject.SetActive(false);
    }
    public void open_pannel(int num)
    {
        transform.GetChild(num).gameObject.SetActive(true);
    }
    public void char_data_assign(GameObject tar)
    {
        open_pannel(0);
        charater_d data = tar.GetComponent<charater_d>();
        Transform panel = transform.GetChild(0).GetChild(0);
        panel.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = data._name;
        panel.GetChild(2).gameObject.GetComponent<Image>().sprite = data.dp;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inv_open = !inv_open;
            transform.GetChild(1).gameObject.SetActive(inv_open);
        }

        //if (slection.selectedObject != null && Input.GetKey(KeyCode.LeftShift))
        //{
        //    about_open = !about_open;
        //    transform.GetChild(0).gameObject.SetActive(about_open);
        //}
    }



}
