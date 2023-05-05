using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoInventario : baseInvetario
{
    public Mouse mouse;

    private void Update()
    {
        if (Input.GetButtonUp("AbrirInvetário"))
        {
            
            InvetarioAberto = !InvetarioAberto;
            
        }
    }

    private void OnGUI()
    {
        if (InvetarioAberto)
        {
            if (mouse.Ponteiro != null)
            {
                Cursor.visible = false;
                GUI.DrawTexture(mouse.Retangulo, mouse.Ponteiro);

                GUI.BringWindowToBack(0);
            }
            RetanguloDoInventario = GUI.Window(0, RetanguloDoInventario, janelaDoInventario, "Inventário");
        }

    }

    bool itensDoMesmoTipo(Item A, Item B)
    {
        if(A.Identidade == B.Identidade)
        {
            return true;
        }else
        {
            return false;
        }
    }

    void exibirNomeDoItem (string nome)
    {
        if(nome != null)
        {
            int largura = nome.Length * 10;
            GUI.Box(new Rect(mouse.Retangulo.xMax, mouse.Retangulo.yMax, largura, 20), nome);
        }
        
    }

    [System.Serializable]
    public class Mouse
    {
        public Texture2D Ponteiro;
        public Vector2 Escala;
        Vector2 _posicaoNaTela;
        [HideInInspector]public Item itemArrastavel;

        public Vector2 posicaoNaTela
        {
            get { return new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y); }
        }

        public Rect Retangulo
        {
            get { return new Rect(posicaoNaTela.x, posicaoNaTela.y, Escala.x, Escala.y); }
        }
    }
}