using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    private Button myButton;
    private Image myImage;

    [SerializeField] public Counter myCounter;

    [SerializeField] private Image secondImage;

    void Start()
    {
        myButton = GetComponent<Button>();
        myImage = GetComponent<Image>();
        if(tag == "FirstImage")
        {
            myButton.onClick.AddListener(MyVoid);
        }
    }
 
    void MyVoid()
    {
        myCounter.inStock += 1;
        myImage.color = Color.white;
        secondImage.color = Color.white;
        myButton.enabled = false;
    }
}
