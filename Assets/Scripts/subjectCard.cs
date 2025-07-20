using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class subjectCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subjectNameText;
    public string subjectName;
    public float subjectCredit = 10f;
    public semesterCard parentSemesterCard;

    public TMP_InputField gradeInputField;
    [SerializeField] private Dictionary<string, float> gradeInfo = new Dictionary<string, float>
    {
        { "A", 10 },
        { "A-", 9 },
        { "B", 8 },
        { "B-", 7 },
        { "C", 6 }
    };

    public void OnEnable()
    {
        subjectNameText.text = subjectName + "\nCredits: " + subjectCredit; // Initialize the subject name text
        gradeInputField.onEndEdit.AddListener(OnGradeInputEndEdit); // Add listener for grade input field
        gradeInputField.onDeselect.AddListener(OnGradeInputEndEdit); // Add listener for grade input field focus
        gradeInputField.onValueChanged.AddListener(OnGradeInputEndEdit); 
        StartCoroutine(UpdateSubjectInfo()); // Start the coroutine to update the subject info
    }

    void OnGradeInputEndEdit(string inputText)
    {
        inputText = inputText.Trim(); // Trim whitespace from the input text
        inputText = inputText.ToUpper(); // Convert input text to uppercase for consistency
        if (gradeInfo.ContainsKey(inputText))
        {
            float gradeValue = gradeInfo[inputText];
            parentSemesterCard.subjectInfo[subjectName][1] = gradeValue; // Update the grade value in the parent semester card
            Debug.Log("Grade for " + subjectName + " updated to: " + gradeValue);
        }
        else
        {
            Debug.LogWarning("Invalid grade input: " + inputText);
        }
    }

    IEnumerator UpdateSubjectInfo()
    {
        yield return new WaitForSeconds(0.1f); // Wait for a short duration before updating
        subjectNameText.text = subjectName + "\n" + $"<color=#FF0078>{subjectCredit}</color>" + "<color=#3D3D3D> Credits</color> "; // Update the subject name text
    }
}