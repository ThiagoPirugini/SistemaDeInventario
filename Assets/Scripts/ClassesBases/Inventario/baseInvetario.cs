using UnityEngine;
using System.Collections.Generic;

public class baseInvetario : MonoBehaviour
{
    #region Variáveis
    public PropriedadesDoInvetario propriedadesDoInventario;
    public List<Slot> Slots;
    bool _invetarioAberto;
    Rect _retanguloDoInventario;
    Itens _controleDosItens;
    #endregion

    #region Encapsuladores/Propriedades
    public bool InvetarioAberto { get => _invetarioAberto; set => _invetarioAberto = value; }
    public Rect RetanguloDoInventario { get => _retanguloDoInventario; set => _retanguloDoInventario = value; }
    public Itens ControleDosItens { get => _controleDosItens; }
    #endregion

    #region Métodos/ Funções
    private void Start()
    {
        _controleDosItens = (Itens)GameObject.FindObjectOfType<Itens>();

        propriedadesDoInventario.definirTamanhoDoInventário();

        preencherSlots();

        _retanguloDoInventario = new Rect(0, 0, propriedadesDoInventario.tamanhoDoInventario.x, propriedadesDoInventario.tamanhoDoInventario.y);
    }

    void preencherSlots()
    {
        Slots = new List<Slot>();

        for (int i = 0; i < propriedadesDoInventario.Colunas * propriedadesDoInventario.Linhas;      i++)
        {
            Slot novoSlot = new Slot();
            Slots.Add(novoSlot);
        }
    }



   

    public void janelaDoInventario (int windowID)
    {
        for(int x = 0; x < propriedadesDoInventario.Colunas; x++)
        {
            for (int y = 0; y < propriedadesDoInventario.Linhas; y++)
            {
                int indice = x + (y * propriedadesDoInventario.Colunas);
                Rect retanguloDoSlot = new Rect(x * propriedadesDoInventario.tamanhoDoSlot.x, propriedadesDoInventario.espacamentoY + (y * propriedadesDoInventario.tamanhoDoSlot.y),
                    propriedadesDoInventario.tamanhoDoSlot.x,propriedadesDoInventario.tamanhoDoSlot.y);

                Rect retanguloDoSlotNaTela = new Rect(retanguloDoSlot.x + _retanguloDoInventario.x, retanguloDoSlot.y + RetanguloDoInventario.y, retanguloDoSlot.width, retanguloDoSlot.height);

                //GUI.Box(retanguloDoSlot, "");
                exibirItem(Slots[indice].item, retanguloDoSlot);

                Slots[indice].Retangulo = retanguloDoSlotNaTela;
                Slots[indice].Identidade = indice;
                
            }
        }

        Rect retanguloArrastavel = new Rect(0, 0, RetanguloDoInventario.width, propriedadesDoInventario.espacamentoY);
        GUI.DragWindow(retanguloArrastavel);

        if(propriedadesDoInventario.bloquearMovimento)
        {
            int posicaoX = (int)Mathf.Clamp(RetanguloDoInventario.x, 0, Screen.width - RetanguloDoInventario.width);
            int posicaoY = (int)Mathf.Clamp(RetanguloDoInventario.y, 0, Screen.height - RetanguloDoInventario.height);

            RetanguloDoInventario = new Rect(posicaoX, posicaoY, RetanguloDoInventario.width, RetanguloDoInventario.height);
        }
    }

    public void exibirItem (Item item, Rect retangulo)
    {
        if(item != null)
        {
            GUI.Box(retangulo, item.Icone);
            if(item.Empilhavel)
            {
                GUI.Label(new Rect(retangulo.xMax - 20, retangulo.yMax - 20, 20, 20), (item.Quantidade).ToString());
            }
        }else
        {
            GUI.Box(retangulo, "");
        }
    }
    #endregion
}

[System.Serializable]
public class PropriedadesDoInvetario
{
    #region Variáveis
    public int Linhas, Colunas, espacamentoY;
    public Vector2 tamanhoDoSlot;
    public bool bloquearMovimento;
    Vector2 _tamanhoDoInventario;
    #endregion

    #region Métodos/Funções
    public void definirTamanhoDoInventário()
    {
        _tamanhoDoInventario = new Vector2(Colunas * tamanhoDoSlot.x, espacamentoY + (Linhas * tamanhoDoSlot.y));
    }
    #endregion     

    #region Encapsuladores/Propriedades
    public Vector2 tamanhoDoInventario {
        get { return _tamanhoDoInventario; }
    }
    #endregion


}