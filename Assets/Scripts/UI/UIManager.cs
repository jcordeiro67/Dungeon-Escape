using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class UIManager : MonoBehaviour {
	//Singleton Class UIManager

	private static UIManager _instance;
	public static UIManager Instance{
		
		get{
			if(_instance == null){
				Debug.LogError("UI Manager is Null!");
			}
			return _instance;
		}
	}

	public Text playerGemCountText;
	public Button buyButton;
	public Image selectionImage;
	public GameObject errorCanvas;
	public Text	errorText;
	public Text hudGemCountText;

	void Awake(){
		_instance = this;

	}

	void OnEnable(){
		//if selectionImage enable on activation of panel turn selectionImage off
		if (selectionImage.IsActive() == true) {
			UI_ToggleSelectionImage();
		}
	}

	//Updates the players gems count when they enter the shop
	public void UI_UpDateGems(Text UIEllement, int gemCount){
		UIEllement.text = gemCount.ToString();

	}

	//Updates the players selection in the shopKeepers UI
	public void UI_UpdateSelectedItem(float yPos){
		if (selectionImage.IsActive() == false) {
			UI_ToggleSelectionImage();
		}
		selectionImage.rectTransform.anchoredPosition = new Vector3(selectionImage.rectTransform.anchoredPosition.x, yPos, 0f);

	}

	//Toggles the selection Highlight Image
	public void UI_ToggleSelectionImage(){
		selectionImage.enabled = !selectionImage.IsActive();
	}

	//Toggle the buy botton interaction attribute
	public void UI_ToggleBuyButtonInteraction(){
		buyButton.interactable = !buyButton.interactable;
	}

	//Toggle the errorPanel
	public void UI_ToggleErrorPanel(){
		errorCanvas.SetActive(!errorCanvas.activeSelf);
	}


}
