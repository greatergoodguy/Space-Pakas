using UnityEngine;

public class MenuStart : MonoBehaviour
{
    public static MenuStart I;
    
    GameObject _goContainer;
    
    void Awake()
    {
        I = this;
        _goContainer = transform.Find("Container").gameObject;
    }

    void Start() {
        Hide();
    }

    public void Show() {
        _goContainer.SetActive(true);
    }

    public void Hide() {
        _goContainer.SetActive(false);
    }
}