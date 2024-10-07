using System.Collections;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    [HideInInspector]public bool canDrag;
    [HideInInspector] public bool canPlace;
    [HideInInspector] public GameObject skillPanel;
    [HideInInspector] public GameObject highlight;
    private Vector3 origin;
    private Vector3 offset;

    private void Start()
    {
        SetOriginalPosition();

        highlight = transform.GetChild(3).gameObject;
    }

    void Update()
    {
        if (dragging)
        {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            highlight.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (canDrag)
        {
            // Record the difference between the objects centre, and the clicked point on the camera plane.
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragging = true;
        }
        if (canPlace) 
        {
            //Sets the x and y of the Camera
            GameObject.Find("Main Camera").transform.position = new Vector2(0, -1.45f);
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 6.5f;

            skillPanel.SetActive(true);

            //Sets the character data to use
            GameObject.Find("Pre-BattleMenu").GetComponent<SkillPlacement>().AddSelectedCharacterData(gameObject);
        }
    }

    private void OnMouseUp()
    {
        // Stop dragging.
        dragging = false;
        //Return to set location
        transform.position = origin;
        if (canDrag) { highlight.SetActive(true); }
        
    }

    public void SetOriginalPosition()
    {
        origin = transform.position;
    }

    //Detects any player characters to swap positions with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.gameObject.name.Contains("PlayerC") && dragging)
        {
            highlight.SetActive(true);
            dragging = false;
            transform.position = collision.transform.parent.position;
            collision.transform.parent.position = origin;

            collision.transform.parent.gameObject.GetComponent<Drag>().SetOriginalPosition();
            SetOriginalPosition();
        }
    }
}
