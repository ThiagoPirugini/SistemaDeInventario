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

    private void OnGUI()
    {
        GUI.Window(0, _retanguloDoInventario, janelaDoInventario, "Inventário");
    }

    public void janelaDoInventario (int windowID)
    {
        for(int x = 0; x < propriedadesDoInventario.Colunas; x++)
        {
            for (int y = 0; y < propriedadesDoInventario.Linhas; y++)
            {
                Rect retanguloDoSlot = new Rect(x * propriedadesDoInventario.tamanhoDoSlot.x, propriedadesDoInventario.espacamentoY + (y * propriedadesDoInventario.tamanhoDoSlot.y),
                    propriedadesDoInventario.tamanhoDoSlot.x,propriedadesDoInventario.tamanhoDoSlot.y);

                GUI.Box(retanguloDoSlot, "slot");
            }
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