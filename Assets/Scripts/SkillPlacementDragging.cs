using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPlacementDragging : MonoBehaviour
{
    /// ==========================================
    /// Need to Move UI Elements by with mouse
    /// touch
    /// ==========================================

    private bool dragging = false;
    private Vector3 origin;
    private Vector3 offset;

    private void Start()
    {
        origin = transform.position;
    }

    void Update()
    {
        if (dragging)
        {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        transform.parent.GetComponent<GridLayoutGroup>().enabled = false;
        // Record the difference between the objects centre, and the clicked point on the camera plane.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        transform.parent.GetComponent<GridLayoutGroup>().enabled = true;
        // Stop dragging.
        dragging = false;
        //Return to set location
        transform.position = origin;
    }

    //Detects any player characters to swap positions with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I AM ON: " + collision.name);
    }
}
