using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerAlgebraRoom2 : MonoBehaviour
{
    public GameObject target;
    public List<GameObject> listTargets;
    private Color colorCorrectBox;
    private Color colorIncorrectBox;
    private Color colorDefaultBox;
    // Start is called before the first frame update
    private void Awake() {
        target = null;

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
    public void ChangeColorTarget(GameObject obj)
    {
        SpriteRenderer objSpriteRenderer = obj?.gameObject.gameObject.GetComponent<SpriteRenderer>();
        if (objSpriteRenderer != null)
        {
            objSpriteRenderer.color = colorCorrectBox;
        }
    }
    public void ChangeColorDefault(GameObject obj)
    {
        SpriteRenderer targetSpriteRenderer = obj?.GetComponent<SpriteRenderer>();
        if (targetSpriteRenderer != null)
        {
            targetSpriteRenderer.color = colorDefaultBox;
        }
    }
    public void ChangeColorIncorrent(GameObject obj)
    {
        SpriteRenderer objSpriteRenderer = obj?.gameObject.gameObject.GetComponent<SpriteRenderer>();
        if (objSpriteRenderer != null)
        {
            objSpriteRenderer.color = colorIncorrectBox;
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
