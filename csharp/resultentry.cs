using TMPro;
using UnityEngine;

public class resultentry : MonoBehaviour
{
    [SerializeField] private TMP_Text nameentry,cor,incor;

    public void setname(string entryname)
    {
        nameentry.text = entryname;
    }

    public void setcor(string entrycor)
    {
        cor.text = entrycor;
    }

    public void setincor(string entryincor)
    {
        incor.text = entryincor;
    }
    
}
