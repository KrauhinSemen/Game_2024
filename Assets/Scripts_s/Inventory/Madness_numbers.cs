using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madness_numbers : MonoBehaviour
{
    void Start()
    {
        var madness = PlayerPrefs.GetInt("Madness");

        for (var i = 1; i <= 10; i++)
        {
            if (gameObject.name == "Ячейка Безумия " + i && madness >= i * 10)
            {
                gameObject.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
            }
        }
    }
}
