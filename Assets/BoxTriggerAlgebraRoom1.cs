using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxTriggerAlgebraRoom1 : MonoBehaviour
{
    [SerializeField] private bool isNumberTrigger;
    public bool isCorrect;
    public GameObject target;
    public List<GameObject> listTargets;
    private Color colorCorrectBox;
    private Color colorIncorrectBox;
    private Color colorDefaultBox;
    // Start is called before the first frame update
    private void Awake() {
        target = null;
        isCorrect = false;

        colorCorrectBox = new Color(0.5f, 1, 0.5f);
        colorIncorrectBox = new Color(1, 0.5f, 0.5f);
        colorDefaultBox = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Object"){
            listTargets.Add(other.gameObject);

            Debug.Log("enter");
            ChangeTarget();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Object"){

            ChangeColorDefault(other.gameObject);
            if (listTargets.IndexOf(other.gameObject) != -1)
            {
                listTargets.Remove(other.gameObject);
            }
            Debug.Log("exit");

            ChangeTarget();
        }
    }
    private void ChangeColorTarget(GameObject obj)
    {
        SpriteRenderer objSpriteRenderer = obj.gameObject.gameObject.GetComponent<SpriteRenderer>();
            if (objSpriteRenderer != null)
            {
                if(obj.gameObject.GetComponent<CircleCollider2D>() != null)
                {
                    
                    objSpriteRenderer.color = isNumberTrigger ? colorIncorrectBox : colorCorrectBox;
                    
                }
                else if(obj.gameObject.GetComponent<BoxCollider2D>() != null)
                {
                    objSpriteRenderer.color = isNumberTrigger ? colorCorrectBox : colorIncorrectBox;
                }
            }

            isCorrect = (objSpriteRenderer.color == colorCorrectBox) ? true : false;
    }
    private void ChangeColorDefault(GameObject obj)
    {
        SpriteRenderer targetSpriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (targetSpriteRenderer != null)
        {
            targetSpriteRenderer.color = colorDefaultBox;
        }
    }
    private void ChangeTarget()
    {
        if (listTargets.Count > 0 )
        {
            target = listTargets[0];
            ChangeColorTarget(target);
        }
        else
        {
            target = null;
        }
        
    }
}

