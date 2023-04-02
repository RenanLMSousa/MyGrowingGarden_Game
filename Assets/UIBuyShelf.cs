using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIBuyShelf : MonoBehaviour , IPointerClickHandler
{
    public GameObject ShelfPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(ShelfPrefab).transform.position = this.transform.position;
        this.transform.position += Vector3.up * 4;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
