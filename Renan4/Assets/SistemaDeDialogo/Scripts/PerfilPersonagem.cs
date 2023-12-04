using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NovoPerfil", menuName = "scriptable/Perfil", order = 0)]
public class PerfilPersonagem : ScriptableObject
{
    public string Name;
    public Sprite Imagem;
    public AudioClip voz;
}
