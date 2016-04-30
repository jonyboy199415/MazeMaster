using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shopHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text shopText;
    public int buttonNum;

	// Use this for initialization
	void Start () {
        shopText.text = "Welcome to the shop! The items cost 200 loot.";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(buttonNum == 0)//scroll
            shopText.text = "The scroll increases health.";
        else if (buttonNum == 1)//amulet
            shopText.text = "The amulet increases stamina.";
        else if (buttonNum == 2)//bone amulet
            shopText.text = "The bone amulet increases fire power.";
        else if (buttonNum == 3)//statue
            shopText.text = "The statue increases ice power.";
        else if (buttonNum == 4)//ring
            shopText.text = "The ring decreases the cost to use fire.";
        else if (buttonNum == 5)//octopus
            shopText.text = "The octopus decreases the cost to use ice.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shopText.text = "Welcome to the shop! The items cost 200 loot.";
    }
}
