using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;

public class DiceSpawn : MonoBehaviour {

    public GameObject parentDie;

    public GameObject d4;
    public GameObject d6;
    public GameObject d8;
    public GameObject d10;
    public GameObject d12;
    public GameObject d20;
    public GameObject d100;

    Dictionary<GameObject, Text> diceValues;
    static Dictionary<string, int[]> rollDictionary = new Dictionary<string, int[]>();
    public Dropdown ddRolls;
    public InputField ifRollName;

    public Text[] textArray;
    public Text txtTest;

    public Text txtD4Num;
    public Text txtD6Num;
    public Text txtD8Num;
    public Text txtD10Num;
    public Text txtD12Num;
    public Text txtD20Num;
    public Text txtD100Num;

    public UIController uiCon;
    string path;

    private void Awake()
    {
        path =  Application.persistentDataPath + "/rolls.txt";
        LoadRollsFromText();
    }

    private void Start()
    {

        diceValues = new Dictionary<GameObject, Text>();
        diceValues.Add(d4, txtD4Num);
        diceValues.Add(d6, txtD6Num);
        diceValues.Add(d8, txtD8Num);
        diceValues.Add(d10, txtD10Num);
        diceValues.Add(d12, txtD12Num);
        diceValues.Add(d20, txtD20Num);
        diceValues.Add(d100, txtD100Num);

        PopulateRolls();
        txtTest.text = Application.persistentDataPath;

    } // End Start()

    void AddTorollDictionary(string fullString)
    {
        string name = fullString.Substring(0, fullString.Length - 7);
        string n = fullString.Substring(fullString.Length - 7, 7);
        int[] tempArray = new int[7];

        for (int i = 0; i < tempArray.Length; i++) tempArray[i] = int.Parse(n[i].ToString());

        rollDictionary.Add(name, tempArray);

    } // End AddTorollDictionary()

    public void SaveRollsToText()
    {

        // Write users rolls to rolls.txt

        using(StreamWriter writer = new StreamWriter(path, false))
        {
            foreach (string item in rollDictionary.Keys)
            {
                StringBuilder roll = new StringBuilder(item);

                foreach (int num in rollDictionary[item])
                {
                    roll.Append(num);
                }

                writer.WriteLine(roll);
            }
        }

    } // End SaveRollsToText()

    public void LoadRollsFromText()
    {

        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    AddTorollDictionary(line);

                }
            }
        }

    } // End LoadRollsFromText()

    /// <summary>
    /// Spawn new instance of game object in world
    /// </summary>
    /// <param name="dice">Dice Object</param>
    public void SpawnDie(GameObject dice)
    {

       GameObject newObject =  Instantiate(dice, new Vector3(0f,0f,21.5f), Quaternion.identity);

        // Scales new object to 1 / 10th scale
        newObject.transform.localScale = new Vector3(.1f, .1f, .1f);

        // Attaches new instance to Dice empty game object
        newObject.transform.SetParent(parentDie.transform);

    } // End SpawnDie()


    public void PopulateRolls()
    {
        ddRolls.ClearOptions();
        ddRolls.AddOptions(GetRollsList());
    }

    public void DDValue()
    {
        Debug.Log(ddRolls.captionText);
    } // End DDValue

    public void SpawnDiceFromRolls()
    {
       

        if(rollDictionary.ContainsKey(ddRolls.captionText.text))
        {
            int[] r = rollDictionary[ddRolls.captionText.text];

            txtD4Num.text = r[0].ToString();
            txtD6Num.text = r[1].ToString();
            txtD8Num.text = r[2].ToString();
            txtD10Num.text = r[3].ToString();
            txtD12Num.text = r[4].ToString();
            txtD20Num.text = r[5].ToString();
            txtD100Num.text = r[6].ToString();

            DestroyDice();
            SpawnAllDice();
        }
    }

    /// <summary>
    /// Returns a list of Roll Names
    /// </summary>
    /// <returns></returns>

    public List<string> GetRollsList()
    {
        //rollDictionary = new Dictionary<string, int[]>();
        return rollDictionary.Keys.ToList();

    } // End GetRollsList()


    /// <summary>
    /// Reads values of die to generate when Spawn Dice buton active
    /// </summary>
    public void SpawnAllDice()
    {

        foreach (GameObject item in diceValues.Keys)
        {

            for (int i = 0; i < int.Parse(diceValues[item].text); i++)
            {
                SpawnDie(item);
            }

        }

    } // End SpawnAllDice()

    // Destroys all instances of dice in Dice object
    public void DestroyDice()
    {


        foreach (Transform child in parentDie.transform)
        {
            Destroy(child.gameObject);
        }


    } // End DestroyDice()

    // Add Roll to Dictionary
    public void AddRolls()
    {
        
        if(ifRollName.text.Trim() != "" && !rollDictionary.ContainsKey(ifRollName.text.Trim()))
        {
            int d4 = int.Parse(txtD4Num.text);
            int d6 = int.Parse(txtD6Num.text);
            int d8 = int.Parse(txtD8Num.text);
            int d10 = int.Parse(txtD10Num.text);
            int d12 = int.Parse(txtD12Num.text);
            int d20 = int.Parse(txtD20Num.text);
            int d100 = int.Parse(txtD100Num.text);

            int total = d4 + d6 + d8 + d10 + d12 + d20 + d100;

            if(total > 0)
            {
                rollDictionary.Add(ifRollName.text.Trim(), new int[] {
                    d4,
                    d6,
                    d8,
                    d10,
                    d12,
                    d20,
                    d100
                });

                SaveRollsToText();
                PopulateRolls();
                DestroyDice();
                uiCon.ToggleUISaveRolls();
            }
            else
            {
                ifRollName.text = "Choose some dice";
            }



        }
        else
        {
            ifRollName.text = "Didn't Work";
        }

    } // End AddRolls()

    public int DiceCount()
    {
        return int.Parse(txtD4Num.text) +
            int.Parse(txtD6Num.text) +
            int.Parse(txtD8Num.text) +
            int.Parse(txtD10Num.text) +
            int.Parse(txtD12Num.text) +
            int.Parse(txtD20Num.text) +
            int.Parse(txtD100Num.text)
            ;

    } // End DiceCount()

}
