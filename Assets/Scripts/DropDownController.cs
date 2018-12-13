using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropDownController : MonoBehaviour, IPointerClickHandler {

    DiceSpawn ds;
    public Dropdown rollList;



    // Use this for initialization
    void Start () {
        ds = new DiceSpawn();

        rollList.AddOptions(ds.GetRollsList());

    }

    //// Update is called once per frame
    //void Update () {

    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        // Load list of Save rolls
        if(ds.GetRollsList().Count > 0)
        {
            rollList.ClearOptions();
            rollList.AddOptions(ds.GetRollsList());
        }
    } // End OnPointerClick()
}
