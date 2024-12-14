using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum ToyType { dumbell, box, amogus}
public class ContainsObject : MonoBehaviour
{
    public ToyType typeOfBox;
    public int maxCount = 3;
    public int toysInBox;
    private int totalToys;
    public TextMeshProUGUI toysText;

    // Start is called before the first frame update
    void Start()
    {
        totalToys = 3;
        UpdateAmount(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ToyScript findToy = other.gameObject.GetComponent<ToyScript>();
        if (findToy.toyType == typeOfBox)
        {
            toysInBox++;
            UpdateAmount(+1);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ToyScript findToy = other.gameObject.GetComponent<ToyScript>();
        if (findToy.toyType == typeOfBox)
        {
            toysInBox--;
            UpdateAmount(-1);
        }
    }

    public void UpdateAmount(int amount)
    {
        toysText.text = (toysInBox + "/" + totalToys);
        Debug.Log(amount + typeOfBox);
    }
}
