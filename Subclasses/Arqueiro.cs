using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Rpg.Subclasses
{
    public class Arqueiro : Personagem , IIAtacavel
    {
        private int turnosDeBonusAtaque = 0;
        private int bonusAtual = 0;


        public override void AtualizarTurno()
        {
            if (turnosDeBonusAtaque > 0)
            {
                turnosDeBonusAtaque--;
                if (turnosDeBonusAtaque == 0)
                {
                    Ataque -= bonusAtual;
                    Console.WriteLine("O efeito do bônus de ataque do Arqueiro acabou. Ataque retornou a: " + Ataque);
                    bonusAtual = 0;
                }
            }
        }


        public Arqueiro(string nome) : base(nome)
        {
            Vida = 110;
            Defesa = 12;
            Ataque = 8;
            AtaqueEspecial = 12;
        }
        public override void Atacar(Personagem inimigo)
        {
            Console.WriteLine("Ataca precisamente!");
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem >= 18) // Acerto Critico
            {

                int DanoCausado = Math.Max(Dado.RoollD8(), 8);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Acerto Crítico! Dano causado: " + DanoCausado);
                Console.ResetColor();
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else if (rolagem <= 3) // Uma penalidade para erros Criticos
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
                int DanoCausado = Dado.RoollD8();
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
            Console.WriteLine("Você traça um caminho entre sua flecha e o inimigo, tão certeira e clara em sua visão, e de forma precisa... ");
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem >= 18) // Acerto Critico
            {

                int bonus = Math.Max(Dado.RoollD20(), 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você sabe exatamente odne seu inimigo está, Dificuldade de ataque reduzido em: " + bonus);
                Console.ResetColor();
                bonusAtual = bonus;
                turnosDeBonusAtaque = 3;
                this.Ataque -= bonusAtual;
                 
            }
            else if (rolagem <= 3) // Uma penalidade para erros Criticos
            {
                int bonus = Dado.RoollD6();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Você se destraiu e perdeu o inimigo de vista, Dificuldade Ataque aumentado em: " + bonus);
                Console.ResetColor();
                bonusAtual = bonus;
                turnosDeBonusAtaque = 0;
                Ataque += bonusAtual;
                
            }
            else if (rolagem >= AtaqueEspecial)
            {
                int bonus = Dado.RoollD12();
                Console.WriteLine("Você está focado, Dificuldade de ataque reduzido em: " + bonus);
                bonusAtual = bonus;
                turnosDeBonusAtaque = 3;
                this.Ataque -= bonusAtual;
            }
            else
            {
                Console.WriteLine("Mas perdeu o foco");

            }
        }
    }
}
