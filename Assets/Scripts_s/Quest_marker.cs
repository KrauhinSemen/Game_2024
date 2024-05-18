using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Quest_marker : MonoBehaviour
{
    public string quest_name;
    public string steps;
    void Update()
    {
        int[] steps_s = steps.Split(" ").Select(q => int.Parse(q)).ToArray();
        var need_shadow = true;
        var temp_step = 0;
        if (PlayerPrefs.HasKey(quest_name)) temp_step = PlayerPrefs.GetInt(quest_name);
        for (var i=0; i< steps_s.Length; i++)
        {
            if (PlayerPrefs.GetInt(quest_name) == steps_s[i] - 1)
            {
                need_shadow = false;
                break;
            }
        }
        if (need_shadow) gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        else gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //        if ((!PlayerPrefs.HasKey(quest_name) && step == 1) || PlayerPrefs.GetInt(quest_name) == step - 1)
        //  gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //   else gameObject.transform.rotation = Quaternion.Euler(0, 90, 0); // gameObject.transform.rotation = new Quaternion(0, 90, 0, 0);
    }
}
