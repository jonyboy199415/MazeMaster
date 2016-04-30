using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shopHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text shopText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnPointerEnter(PointerEventData eventData)
    {
        shopText.text = "";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shopText.text = "";
    }
}
