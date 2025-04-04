using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class buttonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float holdTime = 1f; // Time in seconds to hold the button
    private float holdTimer = 0f;
    private bool isHolding = false;
    [SerializeField] private card cardScript; // Reference to the card script
    [SerializeField] GameObject cancelImage;
    private void Update()
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            Debug.Log(holdTimer);
            if (holdTimer >= holdTime)
            {
                OnHoldComplete();
                isHolding = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        holdTimer = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        holdTimer = 0f;
    }

    private void OnHoldComplete()
    {
        Debug.Log("Hold complete!");
        cardScript.Rollback(); // Call the Rollback method from the card script
        StartCoroutine(HoldCoroutine()); // Start the coroutine to handle the hold action
    }

    private IEnumerator HoldCoroutine()
    {
        cancelImage.SetActive(true); // Show the cancel image
        yield return new WaitForSeconds(.8f); // Wait for 1 second
        cancelImage.SetActive(false); // Hide the cancel image
        isHolding = false; // Reset the holding state
    }
}