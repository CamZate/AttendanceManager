using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;


public class cardsManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField newCardNameText;
    [SerializeField] private Button addCardButton;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardparent;


    private void Start() {
        addCardButton.onClick.AddListener(OnAddCardButtonClick);
        addCardButton.interactable = false; // Disable the button initially
        cardData cardStats = LoadData(); // Load the card data
        if(cardStats == null) return; // Check if data is null
        foreach(string key in cardStats.data.Keys){
            Instantiate(cardPrefab, cardparent).GetComponent<card>().cardName = key;
        }
    }

    private void OnDestroy() {
        addCardButton.onClick.RemoveListener(OnAddCardButtonClick);
    }

    public void OnValueChanged() {
        // Handle value changes if needed
        if(!string.IsNullOrEmpty(newCardNameText.text)) {
            addCardButton.interactable = true; // Enable the button if the input is not empty
        } else {
            addCardButton.interactable = false; // Disable the button if the input is empty
        }
    }

    private void OnAddCardButtonClick() {
        string cardName = newCardNameText.text;
        if (!string.IsNullOrEmpty(cardName)) {
            // Add the card to the list or perform any other action
            Debug.Log("Adding card: " + cardName);
            newCardNameText.text = ""; // Clear the input field after adding

            Instantiate(cardPrefab, cardparent).GetComponent<card>().cardName = cardName;
        } else {
            Debug.Log("Card name cannot be empty!");
        }
    }

    cardData LoadData(){
        string path = Application.persistentDataPath + "/" + "data" + ".lol";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path , FileMode.Open);

            cardData data = formatter.Deserialize(stream) as cardData;
            stream.Close();
            return data;

        }else{
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
}