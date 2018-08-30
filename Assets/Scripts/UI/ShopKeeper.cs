using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopKeeper : MonoBehaviour {

	public GameObject m_UICanvas;
	public String[] itemName;
	public int[] itemCost;
	private Player m_player;
	private int m_gemCount;
	private int currentSellection;
	private int currentItemCost;

	void Awake(){
		if (m_UICanvas.activeSelf) {
			m_UICanvas.SetActive(false);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		//Turn Canvas On and UpDate Gems
		m_player = other.gameObject.GetComponent<Player>();

		if (m_player != null) {
			m_gemCount = m_player.Diamonds;
			m_UICanvas.SetActive(true);
			UIManager.Instance.UI_UpDateGems(m_gemCount);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		//Turn Canvas Off
		m_player = other.gameObject.GetComponent<Player>();

		if (m_player != null) {
			m_UICanvas.SetActive(false);
		}
	}

	public void SelectItem(int item){
		//Switch between selected item
		switch (item) {
			case 0: //Flame Sword
				
				currentSellection = 0;
				UIManager.Instance.UI_UpdateSelectedItem(-36.9f);
				break;
			case 1: //Boots
				
				currentSellection = 1;
				UIManager.Instance.UI_UpdateSelectedItem(-138.9f);
				break;
			case 2: //Key
				
				currentSellection = 2;
				UIManager.Instance.UI_UpdateSelectedItem(-243.3f);
				break;
		}
	}

	public void BuyItem(){
		//BuyItem method
		//check if player gems is greater then or equal to itemCost
		if (m_gemCount >= itemCost[currentSellection]) {
			//Get Handle to Player Script
			m_player = FindObjectOfType<Player>().GetComponent<Player>();
			//Subtract currentItemCost from gems
			m_player.Diamonds -= itemCost[currentSellection];
			//reset gemCount variable
			m_gemCount = m_player.Diamonds;
			//update UI Gem Count
			UIManager.Instance.UI_UpDateGems(m_gemCount);

		} 
		else {
			Debug.Log("Not enough gems to buy " + itemName[currentSellection]);
			//TODO: Create a Out of Cash UI POPUP
			UIManager.Instance.UI_ToggleErrorPanel();
			UIManager.Instance.errorText.text = "Not Enough Gems to Buy " + itemName[currentSellection].ToString();
			return;
		}

	}

	public void ClosePanel(){

		UIManager.Instance.UI_ToggleErrorPanel();
	}

}
