using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Rpg
{
    public interface IIAtacavel
    {
        void Atacar(Personagem inimigo);
        void Especial(Personagem inimigo);
    }

}