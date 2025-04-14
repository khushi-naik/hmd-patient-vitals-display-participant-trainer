using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public TextAsset csvFile; // Reference to the CSV file

    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = csvFile.text.Split(new char[] { '\n' });

        foreach (string row in data)
        {
            string[] fields = row.Split(new char[] { ',' });
            Debug.Log("Field 1: " + fields[0] + " Field 2: " + fields[1] + " Field 3: " + fields[2]);
        }
    }
}
