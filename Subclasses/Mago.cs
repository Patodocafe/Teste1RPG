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
            VidaMaxima = 70;
        }

        public override void Atacar(Personagem inimigo)
        {
            Console.WriteLine("Você atira uma bola de fogo!");
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem >= 18)
            {

                int DanoCausado = Math.Max(Dado.RoollD12(), 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Acerto Crítico! Dano causado: " + DanoCausado);
                Console.ResetColor();
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else if (rolagem <= 2) // Uma penalidade para erros Criticos
            {
                int DanoCausado = Dado.RoollD6();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Erro Critico! Dano Recebido: " + DanoCausado);
                Console.ResetColor();
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
        

        public override void Especial(Personagem inimigo) // subscreve o método Especial da classe base para implementar a lógica específica do Mago adicionando uma cura
        {  
            Console.WriteLine("Fecha os olhos e se concentra no simbulo de seu catalizador, assim invocando uma aura aconchegante. Você se sente bem!  ");
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem >= 18)
            {

                int cura = Math.Max(Dado.RoollD20(), 16);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Acerto Crítico! Você curou: " + cura);
                Console.ResetColor();
                this.Vida += cura;
                if (this.Vida > VidaMaxima)
                {
                    this.Vida = VidaMaxima;
                }

            }
            else if (rolagem >= AtaqueEspecial)
            {
                int cura = Dado.RoollD20();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Acertou o ataque! Você curou: " + cura);
                Console.ResetColor();
                this.Vida += cura;
                if (this.Vida > VidaMaxima)
                {
                    this.Vida = VidaMaxima;
                }
            }
            else
            {
                Console.WriteLine("Mas errou o ataque!");
            }
        }

    }
}
