using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{   
    [SerializeField] private string textAction;
    [SerializeField] private UnityEvent interactAction;

    public SpriteRenderer spriteRenderer;
    public string TextAction => textAction;
    public UnityEvent InteractAction => interactAction;
}

