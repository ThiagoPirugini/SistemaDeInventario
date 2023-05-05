using UnityEngine;
using UnityEditor;


public class DemonstradorDeItens : EditorWindow
{
    Itens itens;

    [MenuItem("Window/Itens")]

    static void init()
    {
        DemonstradorDeItens _demoItens = (DemonstradorDeItens)GetWindow(typeof(DemonstradorDeItens)); 
    }
    private void OnGUI()
    {
        itens = GameObject.FindObjectOfType<Itens>();

        if(itens == null)
        {
            return;
        }
        for(int i = 0; i < itens.listaDeItens.Count - 1; i++)
        {
            //ID
            GUI.Label(new Rect(0, (70 * i) + 10, 64, 64), itens.listaDeItens[i + 1].Identidade.ToString());
            //NOME
            GUI.Label(new Rect(70, (70 * i) + 10, 100, 64), itens.listaDeItens[i + 1].Nome);
            //TEXTURA
            GUI.DrawTexture(new Rect(170, (70 * i) + 10, 64, 64), itens.listaDeItens[i + 1].Icone);
            //EMPILHAVEL
            GUI.Toggle(new Rect(240, (70 * i) + 10, 64, 64), itens.listaDeItens[i + 1].Empilhavel,"");
            //BOTÃO PARA DELETAR O ITEM
            bool deletarItem = GUI.Button(new Rect(Screen.width - 64, (70 * i) + 10, 64, 64), "X");

            if(deletarItem)
            {
                itens.listaDeItens.RemoveAt(i + 1);
            }
        }
        Repaint();
    }
}
