using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Rpg.Subclasses
{
    public class Guerreiro : Personagem , IIAtacavel
    {
        public Guerreiro(string nome) : base(nome)
        {
            Vida = 150;
            Defesa = 14;
            Ataque = 10;
            AtaqueEspecial = 14;
        }
        public override void Atacar(Personagem inimigo)
        {
          Console.WriteLine("Ataca ferozmente!");
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem == 20)
            {

                int DanoCausado = Math.Max(Dado.RoollD12(), 8);
                Console.WriteLine("Acerto Crítico! Dano causado: " + DanoCausado);
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else if (rolagem >= Ataque)
            {
                int DanoCausado = Dado.RoollD12();
                Console.WriteLine("Acertou o ataque! Dano causado: " + DanoCausado);
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else
            {
                Console.WriteLine("Errou o ataque!");

            }
        }

        public override void Especial(Personagem inimigo)
        {
            Console.WriteLine("Focado em causar grande estrago você se arremassa pra que de um grande ataque causando tremores!  ");
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem == 20)
            {

                int DanoCausado = Math.Max(Dado.RoollD20(), 16);
                Console.WriteLine("Acerto Crítico! Dano causado: " + DanoCausado);
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else if (rolagem >= AtaqueEspecial)
            {
                int DanoCausado = Dado.RoollD20();
                Console.WriteLine("Acertou o ataque! Dano causado: " + DanoCausado);
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else
            {
                Console.WriteLine("Mas errou o ataque!");
            }
        }
        
    }


}

