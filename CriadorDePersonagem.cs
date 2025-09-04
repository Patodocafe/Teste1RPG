using Desafio1_Rpg.Subclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Rpg
{
    public class CriadorDePersonagem
    {

        public static Personagem CriarPersonagem()
        {
            Console.WriteLine("Escolha sua classe:");
            Console.WriteLine("1. Guerreiro");
            Console.WriteLine("2. Mago");
            Console.WriteLine("3 Arqueiro");
            string opcao = Console.ReadLine();

            Console.Write("Digite o nome de seu personagem... ");
            string nome = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    return new Guerreiro(nome);
                case "2":
                    return new Mago(nome);
                case "3":
                    return new Arqueiro(nome);
                default:
                    Console.WriteLine("Classe inválida, criando criando guerreiro como padrão.");
                    return new Guerreiro(nome);
            }
        }
    }
}
