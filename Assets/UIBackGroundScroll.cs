using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIBackGroundScroll : MonoBehaviour, IDragHandler ,IBeginDragHandler ,IEndDragHandler
{
    private float startDragPosY;
    private Vector3 camStartPos;

    public float minY = int.MinValue;
    public float maxY = int.MaxValue;

    private void Awake()
    {
        startDragPosY = 0;
        camStartPos = Camera.main.transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
       
        startDragPosY = Input.mousePosition.y;
        camStartPos = Camera.main.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float camCurrentPosY = Input.mousePosition.y;
        Vector3 camDiff = Camera.main.ScreenToWorldPoint(new Vector3(0, camCurrentPosY, 0)) - Camera.main.ScreenToWorldPoint(new Vector3(0, startDragPosY, 0));

        float Ypos = (camStartPos - camDiff).y;

        Ypos = Mathf.Min(Ypos, maxY);
        Ypos = Mathf.Max(Ypos, minY);

        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Ypos, Camera.main.transform.position.z); ;



    }
    public void OnEndDrag(PointerEventData eventData)
    {
        startDragPosY = 0;
    }
}
