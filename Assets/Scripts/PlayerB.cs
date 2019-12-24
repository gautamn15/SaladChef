using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
    public SaladManager _SaladManager;
    public List<InputData> _InputDataList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetSelectedItem(KeyCode.A);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetSelectedItem(KeyCode.S);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetSelectedItem(KeyCode.D);

        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SetSelectedItem(KeyCode.Q);

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetSelectedItem(KeyCode.W);

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetSelectedItem(KeyCode.E);

        }

    }

    public void SetSelectedItem(KeyCode keyCode)
    {
        InputData inputData = _InputDataList.Find(x => x._KeyCode == keyCode);
        _SaladManager.SetSelectedItem(this, inputData._ItemID);
    }
}
