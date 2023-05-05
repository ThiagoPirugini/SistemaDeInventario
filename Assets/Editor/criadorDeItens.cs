using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Itens))]
public class criadorDeItens : Editor
{
    int _identidade;
    Texture2D _icone;
    GameObject _objeto;
    string _nome = "";
    bool _empilhavel;

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PrefixLabel("CRIADOR DE ITENS");
        EditorGUILayout.Separator();
        _identidade = EditorGUILayout.IntSlider("ID:", _identidade, 0, 100);
        _nome = EditorGUILayout.TextField("Nome do Item:",_nome);
        _objeto = (GameObject)EditorGUILayout.ObjectField("Objeto referente: ", _objeto, typeof(GameObject));
        _icone = (Texture2D)EditorGUILayout.ObjectField("Icone Referente: ", _icone, typeof(Texture2D));
        _empilhavel = EditorGUILayout.Toggle("Empilhabilidade: ", _empilhavel);
        bool criarItem = GUILayout.Button("Criar item");

        if(criarItem)
        {
            Itens itens = (Itens)target;
            if(itens.IDExistente(_identidade))
            {
                Debug.LogError("A ID selecionada já existe. Tente Outra");
            }
            else
            {
                Item novoItem = new Item(_identidade, _nome, _icone, _objeto, _empilhavel);
                itens.listaDeItens.Add(novoItem);
            }
            
        }
    }
}
