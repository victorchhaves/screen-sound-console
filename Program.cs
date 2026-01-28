using System;
using System.Threading;
using System.Linq;

// Projeto Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound!";

// Dicionário de bandas
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗░█████╗░███╗░░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔══██╗████╗░██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░███████║██╔██╗██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══██║██║╚████║
██████╔╝╚█████╔╝██║░░██║███████╗██║░░██║██║░╚███║
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝
");
    Console.WriteLine(mensagemDeBoasVindas);
}

// Menu de opções
void MenuDeOpcoes()
{
    int opcaoEscolhida = 0;

    while (opcaoEscolhida != -1)
    {
        Console.WriteLine("\nDigite 1 para registrar uma banda.");
        Console.WriteLine("Digite 2 para listar todas as bandas.");
        Console.WriteLine("Digite 3 para avaliar uma banda.");
        Console.WriteLine("Digite 4 para exibir a média de uma banda.");
        Console.WriteLine("Digite -1 para sair.");

        Console.Write("\nDigite aqui sua opção: ");
        opcaoEscolhida = int.Parse(Console.ReadLine()!);

        switch (opcaoEscolhida)
        {
            case 1:
                RegistrarBanda();
                break;

            case 2:
                ExibirListaDeBandas();
                break;

            case 3:
                AvaliarUmaBanda();
                break;

            case 4:
                ExibirMediaDaBanda();
                break;

            case -1:
                EncerrarPrograma();
                break;

            default:
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirLogo();
                break;
        }
    }
}

// Função de registro de banda
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloComAsteriscos("Digite o nome da banda que você deseja registrar:");

    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());

    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirLogo();
}

// Função de exibir a lista de bandas
void ExibirListaDeBandas()
{
    Console.Clear();
    ExibirTituloComAsteriscos("Lista de bandas registradas:");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirLogo();
}

// Função de título com asteriscos
void ExibirTituloComAsteriscos(string titulo)
{
    int quantidadeDeAsteriscos = titulo.Length;
    string asteriscos = new string('*', quantidadeDeAsteriscos);

    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

// Função para avaliar uma banda
void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloComAsteriscos("Avaliar banda");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);

        bandasRegistradas[nomeDaBanda].Add(nota);

        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirLogo();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirLogo();
    }
}

// Função para exibir a média da banda
void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloComAsteriscos("Média da banda");

    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notas = bandasRegistradas[nomeDaBanda];

        if (notas.Count == 0)
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} ainda não possui avaliações.");
        }
        else
        {
            double media = notas.Average();
            Console.WriteLine($"\nA média da banda {nomeDaBanda} é {media:F2}");
        }
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
    }

    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirLogo();
}

// Função para encerrar o programa
void EncerrarPrograma()
{
    Console.Clear();
    ExibirTituloComAsteriscos("Encerrando o Screen Sound");
    Console.WriteLine("Obrigado por utilizar o Screen Sound!");
    Thread.Sleep(2000);
    Environment.Exit(0);
}

// Execução do programa
ExibirLogo();
MenuDeOpcoes();
