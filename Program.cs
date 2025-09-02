using Desafio1_Rpg;
Personagem pedro = new Personagem("pedro", 40, 8, 13);


Personagem inimigo = new Personagem("Orc", 20, 4, 6);


while (true)
{
    Console.WriteLine("Player...");
    Console.WriteLine("Vida: " + pedro.Vida);
    Console.WriteLine("Ataque: " + pedro.Ataque);

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
        pedro.Atacar(inimigo);
    }
    else if (escolha == "2")
    {
        pedro.Especial(inimigo);
    }
    else if (escolha == "3")
    {
        pedro.Exibir();
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
    pedro.DanoRecebido();


    if(pedro.Vida <= 0)
    {
        break;
    }
    if (inimigo.Vida <= 0)
    {
        break;
    }
}
