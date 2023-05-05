using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itens : MonoBehaviour
{
    public List<Item> listaDeItens;

    public bool IDExistente (int ID)
    {
        foreach(Item item in listaDeItens)
        {
            if(item.Identidade == ID)
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }

}
