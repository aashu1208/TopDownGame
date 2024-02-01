using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebConnector : MonoBehaviour
{
    public InputField field;

    public void LaunchURL()
    {
        Utils.LaunchUrl(field.text);
        
    }


}
