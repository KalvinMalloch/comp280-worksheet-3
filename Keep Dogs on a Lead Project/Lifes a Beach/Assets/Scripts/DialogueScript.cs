using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject shopkeeperAllMenus;
    public GameObject shopkeeperFlirt;
    public GameObject shopkeeperFriendly;
    public GameObject shopkeeperNasty;
    public GameObject dialogueCanvas;
    public GameObject dialogueShopKeeperCanvas;
    public GameObject flirtButton;
    public GameObject friendlyButton;
    public GameObject nastyButton;
	public GameObject upVote;
	public GameObject downVote;
    public float dialogueFadeValue;
    public float dialogueShopKeeperFadeValue;
    public float dialogueCountdown;
    public bool dialogueMenuActive;
    public bool Discount;

    void Start()
    {
        Discount = false;
        dialogueCountdown = 5f;
        dialogueMenuActive = true;
        dialogueShopKeeperFadeValue = 1f;
    }
    void Update()
    {
        dialogueFade();
        if (dialogueMenuActive == false)
        {
            shopkeeperDialogueFade();
        }
    }
    public void Friendly()
    {
		if (gameObject.name == "ThePeopleShop Variant") 
		{
			downVote.SetActive(true);
		}
		if (gameObject.name == "TheDogShop Variant") 
		{
			downVote.SetActive(true);
		}
		if (gameObject.name == "TheSellingShop Variant") 
		{
			upVote.SetActive(true);
			Discount = true;
		}
        shopkeeperFriendly.SetActive(true);
        shopkeeperNasty.SetActive(false);
        shopkeeperFlirt.SetActive(false);
        dialogueMenuActive = false;
    }
    public void Flirt()
    {
		if (gameObject.name == "ThePeopleShop Variant") 
		{
			downVote.SetActive(true);
		}
		if (gameObject.name == "TheDogShop Variant") 
		{
			upVote.SetActive(true);
			Discount = true;
		}
		if (gameObject.name == "TheSellingShop Variant") 
		{
			downVote.SetActive(true);
		}
        shopkeeperFlirt.SetActive(true);
        shopkeeperNasty.SetActive(false);
        shopkeeperFriendly.SetActive(false);
        dialogueMenuActive = false;
    }
    public void Nasty()
    {
		if (gameObject.name == "ThePeopleShop Variant") 
		{
			upVote.SetActive(true);
			Discount = true;
		}
		if (gameObject.name == "TheDogShop Variant") 
		{
			downVote.SetActive(true);
		}
		if (gameObject.name == "TheSellingShop Variant") 
		{
			downVote.SetActive(true);
		}
        shopkeeperNasty.SetActive(true);
        shopkeeperFriendly.SetActive(false);
        shopkeeperFlirt.SetActive(false);
        dialogueMenuActive = false;
    }
    public void shopkeeperDialogueFade()
    {
        if (dialogueCountdown > 0)
        {
            dialogueCountdown -= Time.deltaTime;
        }
        else
        {
            shopkeeperSpeechDialogueFade();
        }
    }
    public void shopkeeperSpeechDialogueFade()
    {
        dialogueShopKeeperCanvas.GetComponent<CanvasGroup>().alpha = dialogueShopKeeperFadeValue;
        dialogueShopKeeperFadeValue -= Time.deltaTime;
        if (dialogueShopKeeperFadeValue <= 0)
        {
            dialogueShopKeeperCanvas.SetActive(false);
        }
    }
    public void dialogueFade()
    {
        dialogueCanvas.GetComponent<CanvasGroup>().alpha = dialogueFadeValue;
        if (dialogueMenuActive == true)
        {
            dialogueFadeValue = 1;
        }
        if (dialogueMenuActive == false)
        {
            friendlyButton.GetComponent<Button>().interactable = false;
            nastyButton.GetComponent<Button>().interactable = false;
            flirtButton.GetComponent<Button>().interactable = false;
            dialogueFadeValue -= Time.deltaTime;
            if (dialogueFadeValue <= 0)
            {
                dialogueCanvas.SetActive(false);
            }
        }
    }
}
