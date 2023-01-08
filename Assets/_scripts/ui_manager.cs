using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_manager : MonoBehaviour
{
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
        panel.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = data._name;
        panel.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = data.age.ToString();
        panel.GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = data.occup;
        panel.GetChild(3).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = data.sin;
        
    }
}
