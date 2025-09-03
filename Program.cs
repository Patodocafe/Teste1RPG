using Desafio1_Rpg;
Personagem jogador = CriadorDePersonagem.CriarPersonagem();
jogador.Exibir();


Personagem inimigo = new Personagem("Orc", 20, 4, 6);


while (true)
{
    Console.WriteLine("Inimigo...");
    Console.WriteLine("Vida: " + inimigo.Vida);
    Console.WriteLine("Ataque: " + inimigo.Ataque);


    Console.WriteLine("\nO que você deseja fazer?");
    Console.WriteLine("1 - Ataque normal");
    Console.WriteLine("2 - Ataque especial");
    Console.WriteLine("3 - Exibir");
    Console.WriteLine("4 - Sair");

    Console.Write("Escolha uma opção: ");
    string escolha = Console.ReadLine();

    if (escolha == "1")
    {
        jogador.Atacar(inimigo);
    }
    else if (escolha == "2")
    {
        jogador.Especial(inimigo);
    }
    else if (escolha == "3")
    {
        jogador.Exibir();
    }
    else if (escolha == "4")
    {
        Console.WriteLine("Encerrando o jogo...");
        break;
    }
    else
    {
        Console.WriteLine("Opção inválida, tente novamente!");
    }

    Console.WriteLine("");
    Console.WriteLine("Vez do inimigo...");
    Console.WriteLine("");
    jogador.DanoRecebido();


    if(jogador.Vida <= 0)
    {
        break;
    }
    if (inimigo.Vida <= 0)
    {
        Console.WriteLine("Parabéns, você venceu o inimigo!");
        break;
    }

    Console.WriteLine("Turno finalizado. Precione qualquer tecla");
    Console.ReadKey();
    Console.Clear();


}
