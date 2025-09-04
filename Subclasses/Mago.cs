using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Rpg.Subclasses
{
    internal class Mago : Personagem , IIAtacavel
    {
        public Mago(string name) : base(name) 
        {
            Vida = 70;
            Defesa = 8;
            Ataque = 4;
            AtaqueEspecial = 10;
        }

        public override void Atacar(Personagem inimigo)
        {
            Console.WriteLine("Você atira uma bola de fogo!");
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem >= 18)
            {

                int DanoCausado = Math.Max(Dado.RoollD12(), 10);
                Console.WriteLine("Acerto Crítico! Dano causado: " + DanoCausado);
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else if (rolagem <= 2) // Uma penalidade para erros Criticos
            {
                int DanoCausado = Dado.RoollD6();
                Console.WriteLine("Erro Critico! Dano Recebido: " + DanoCausado);
                double vidaatual = Vida - DanoCausado;
                Vida = vidaatual;
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
            Console.WriteLine("Fecha os olhos e se concentra no simbulo de seu catalizador, assim invocando uma aura aconchegante. Você se sente bem!  ");
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem >= 18)
            {

                int cura = Math.Max(Dado.RoollD20(), 16);
                Console.WriteLine("Acerto Crítico! Você curou: " + cura);
                this.Vida += cura;
                
            }
            else if (rolagem >= AtaqueEspecial)
            {
                int cura = Dado.RoollD20();
                Console.WriteLine("Acertou o ataque! Você curou: " + DanoCausado);
                this.Vida += cura;
                
            }
            else
            {
                Console.WriteLine("Mas errou o ataque!");
            }
        }

    }
}
