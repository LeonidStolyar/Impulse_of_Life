using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private List<Interactable> listObjectsInteraction;
    [SerializeField] private TextMeshProUGUI textActionInteraction;
    [SerializeField] private Color colorDefaut;
    [SerializeField] private Color colorInteraction;
    
    private PlayerControls playerControls;
    private void Awake() {
        playerControls = new PlayerControls();

        colorDefaut = new Color(255, 255, 255, 255);
        colorInteraction = new Color(180, 180, 180, 255);
    }
    private void OnEnable() {
        playerControls.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        var otherInteractable = other.GetComponent<Interactable>();

        if (otherInteractable == null) return;

        var isOtherInList = listObjectsInteraction.Contains(otherInteractable);
        if (!isOtherInList)
        {
            listObjectsInteraction.Add(otherInteractable);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        var otherInteractable = other.GetComponent<Interactable>();
        
        if (otherInteractable == null) return;

        var isOtherInList = listObjectsInteraction.Contains(otherInteractable);
        if (isOtherInList)
        {
            otherInteractable.spriteRenderer.color = colorDefaut;
            listObjectsInteraction.Remove(otherInteractable);
        }
    }

    private void Update() 
    {
        InteractionUpdate();
    }
    private void InteractionUpdate()
    {
        Interactable interactableObject = null;
        float minDistanse = math.INFINITY;

        foreach (var interactable in listObjectsInteraction)
        {
            if(interactable.spriteRenderer != null)
                interactable.spriteRenderer.color = colorDefaut;

            var distanceObject = Vector2.Distance(interactable.transform.position, gameObject.transform.position);

            if (distanceObject < minDistanse)
            {
                minDistanse = distanceObject;
                interactableObject = interactable;
            }
        }

        if (interactableObject == null)
        {
            textActionInteraction.text = "";
        }
        else
        {
            var textAction = interactableObject.TextAction;
            textActionInteraction.text = $"(E) {textAction}";

            if(interactableObject.spriteRenderer != null)
                interactableObject.spriteRenderer.color = colorInteraction;
            if (playerControls.Interaction.Press.WasPressedThisFrame())
            {
                interactableObject.InteractAction.Invoke();
            }
            
        }
        
    }
}
