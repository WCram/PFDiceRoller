using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIController : MonoBehaviour {

    #region Fields

    // Text Fields
    public Text txtD20Num;
    public Text txtD4Num;
    public Text txtD6Num;
    public Text txtD8Num;
    public Text txtD10Num;
    public Text txtD12Num;
    public Text txtD100Num;

    public Text txtDisplay;


    //Dictionary<string, int[]> rollDictionary;
    public Canvas cnvSaveRolls;
    public CanvasGroup cnvMainUiGrp;
    public CanvasGroup cnvRollsGrp;

    // # of dice
    int d4Value;
    int d6Value;
    int d8Value;
    int d10Value;
    int d12Value;
    int d20Value;
    int d100Value;

    // Total of dice
    int d4Total;
    int d6Total;
    int d8Total;
    int d10Total;
    int d12Total;
    int d20Total;
    int d100Total;

    // Dice arrays
    GameObject[] d4die;
    GameObject[] d6die;
    GameObject[] d8die;
    GameObject[] d10die;
    GameObject[] d12die;
    GameObject[] d20die;
    GameObject[] d100die;

    #endregion Fields

    // Use this for initialization
    void Start () {

        ResetValues();

        d4die = new GameObject[0];
        d4Total = 0;

        d6die = new GameObject[0];
        d6Total = 0;

        d8die = new GameObject[0];
        d8Total = 0;

        d10die = new GameObject[0];
        d10Total = 0;

        d12die = new GameObject[0];
        d12Total = 0;

        d20die = new GameObject[0];
        d20Total = 0;

        d100die = new GameObject[0];
        d100Total = 0;

    } // End Start()


    private void Update()
    {

        AddValues(d4die, out d4Total);
        AddValues(d6die, out d6Total);
        AddValues(d8die, out d8Total);
        AddValues(d10die, out d10Total);
        AddValues(d12die, out d12Total);
        AddValues(d20die, out d20Total);
        AddValues(d100die, out d100Total);

        txtDisplay.text = 
            "D4: " + d4Total + "\n" +
            "D6: " + d6Total + "\n" +
            "D8: " + d8Total + "\n" +
            "D10: " + d10Total + "\n" +
            "D12: " + d12Total + "\n" +
            "D20: " + d20Total + "\n" +
            "D100: " + d100Total + "\n"
            ;

        
    } // End Update()

    // Takes a diceArray, sums and returns total of all dice rolls
    void AddValues(GameObject[] diceArray, out int total)
    {
        int dieTotal = 0;

        if(diceArray.Length != 0)
        {
            foreach (GameObject item in diceArray)
            {
                if(item != null)
                {
                    dieTotal += item.GetComponent<PlayerController>().diceValue;

                }
            }
        }

        total = dieTotal;

    } // End AddValues()

    // Adds all dice to die specific array
    public void ParseDie()
    {
        d4die = GameObject.FindGameObjectsWithTag("d4");
        d6die = GameObject.FindGameObjectsWithTag("d6");
        d8die = GameObject.FindGameObjectsWithTag("d8");
        d10die = GameObject.FindGameObjectsWithTag("d10");
        d12die = GameObject.FindGameObjectsWithTag("d12");
        d20die = GameObject.FindGameObjectsWithTag("d20");
        d100die = GameObject.FindGameObjectsWithTag("d100");


    } // End ParseDie()

    // Increaments text value by 1
    public void DieIncrement(Text txtValue)
    {
        int value = int.Parse(txtValue.text);

        txtValue.text = (++value).ToString();

    } // End DieIncrement()

    // Sets the text of all dice nums to 0
    public void ResetValues()
    {

        d4Value = d6Value = d8Value = d10Value = d12Value = d20Value = d100Value = 0;

        txtD4Num.text = d4Value.ToString();
        txtD6Num.text = d6Value.ToString();
        txtD8Num.text = d8Value.ToString();
        txtD10Num.text = d10Value.ToString();
        txtD12Num.text = d12Value.ToString();
        txtD20Num.text = d20Value.ToString();
        txtD100Num.text = d100Value.ToString();

    } // End ResetValues()

    public void ToggleUISaveRolls()
    {

        txtDisplay.enabled = (txtDisplay.enabled) ? false : true;
        cnvRollsGrp.interactable = (cnvRollsGrp.interactable) ? false: true;

        //cnvMainUiGrp.interactable = (cnvMainUiGrp.interactable) ? false: true;
        cnvSaveRolls.enabled = (cnvSaveRolls.enabled) ? false : true;

    } // End ToggleUISaveRolls()

} // End class UIController
