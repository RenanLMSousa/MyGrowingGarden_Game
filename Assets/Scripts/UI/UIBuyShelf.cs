using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIBuyShelf : MonoBehaviour , IPointerClickHandler
{
    public GameObject PlantingSpotPrefab;
    public GameObject UIInteracteableAreaPrefab;


    public void OnPointerClick(PointerEventData eventData)
    {
        InstantiatePrefab(new Vector3(1.5f, 0, 0));
        InstantiatePrefab(new Vector3(-1.5f, 0, 0));
        this.transform.position += Vector3.up * 4;


    }

    public void InstantiatePrefab(Vector3 translation) {

        GameObject _shelf = Instantiate(PlantingSpotPrefab);
        _shelf.transform.position = this.transform.position + translation;
        

        GameObject _go = Instantiate(UIInteracteableAreaPrefab);
        _go.transform.position = this.transform.position + translation;

        _go.GetComponent<UIPlantingArea>().plantingSpot = _shelf.GetComponent<PlantingSpot>();

        _go.transform.SetParent(this.transform.parent);
        _shelf.GetComponent<PlantingSpotManager>().UIInteractiveArea = _go;
    }
}
