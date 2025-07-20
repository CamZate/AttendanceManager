using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    [SerializeField] private Button attendanceButton;
    [SerializeField] private Button cgpaButton;

    [SerializeField] private sidebarAnimation sidebarAnimation;

    private void Start()
    {
        sidebarAnimation = GetComponent<sidebarAnimation>();
        attendanceButton.onClick.AddListener(() => { ChangeScene(0); attendanceButton.interactable = false; cgpaButton.interactable = true; StartCoroutine(toggleSidebar()); });
        cgpaButton.onClick.AddListener(() => { ChangeScene(1); cgpaButton.interactable = false; attendanceButton.interactable = true; StartCoroutine(toggleSidebar()); });
    }

    IEnumerator toggleSidebar()
    {
        yield return new WaitForSeconds(0.1f); // Wait for the sidebar animation to complete
        sidebarAnimation.ToggleSidebar();
    }

    void ChangeScene(int sceneIndex)
    {
        if (sceneIndex < 0 || sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Invalid scene index: " + sceneIndex);
            return;
        }
        if (SceneManager.GetActiveScene().buildIndex == sceneIndex)
        {
            Debug.Log("Already in the requested scene.");
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}