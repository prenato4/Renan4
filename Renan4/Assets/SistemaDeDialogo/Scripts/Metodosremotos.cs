using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "metodosremotos", menuName = "scriptable/Metodosremotos", order = 0)]
public class Metodosremotos : ScriptableObject
{
    public void DebugarMensagem(string msg)
    {
        Debug.Log(msg);
    }

    public void Playdialogo(Dialogo1 dialogo)
    {
        FindObjectOfType<DialogueManager>().Playdialogo(dialogo);
    }

}
