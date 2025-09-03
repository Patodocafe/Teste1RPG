using Desafio1_Rpg;

namespace Desafio1_Rpg
{
    public class Personagem
    {
        public string Nome { get; set; }
        public double Vida { get; set; }
        public int Defesa { get; set; }
        public int Ataque = Dado.RoollD20();
        public int AtaqueEspecial { get; set; } = 15;
        public int DanoCausado = Dado.RoollD20();

        public Personagem(string nome)
        {
            Nome = nome;
        }


        public void Exibir()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Vida: " + Vida);
            Console.WriteLine("Defesa: " + Defesa);
            Console.WriteLine("Ataque: " + Ataque);
        }

        public Personagem(string nome, double vida, int defesa, int ataque)
        {
            Nome = nome;
            Vida = vida;
            Defesa = defesa;
            Ataque = ataque;
        }

        public virtual void Atacar(Personagem inimigo)
        {
            int rolagem = Dado.RoollD20();
            Console.WriteLine("Rolagem do dado: " + rolagem);

            if (rolagem == 20)
            {

                int DanoCausado = Math.Max(Dado.RoollD6(), 5);
                Console.WriteLine("Acerto Crítico! Dano causado: " + DanoCausado);
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else if (rolagem >= Ataque)
            {
                int DanoCausado = Dado.RoollD6();
                Console.WriteLine("Acertou o ataque! Dano causado: " + DanoCausado);
                double InimigoVidaTotal = inimigo.Vida - DanoCausado;
                inimigo.Vida = InimigoVidaTotal;
            }
            else
            {
                Console.WriteLine("Errou o ataque!");
            }
        }
    



public virtual void Especial(Personagem inimigo)
{
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

public virtual void DanoRecebido()
{
    int rolagem = Dado.RoollD20();
    Console.WriteLine("Rolagem do dado: " + rolagem);

    if (rolagem >= Defesa)
    {
        int DanoCausado = Dado.RoollD6();
        Console.WriteLine("Acertou o ataque! Dano Recebido: " + DanoCausado);
        double vidaatual = Vida - DanoCausado;
        Vida = vidaatual;
    }
    else
    {
        Console.WriteLine("Errou o ataque!");
    }
}



    }
}