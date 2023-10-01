//ScreenSound
string mensagemDeBoasVindas = ("Boas vindas ao Screen Sound");
//List<string> BandList = new List<string> {"U2", "The Beatles", "Nirvana" };

Dictionary<string, List<int>>bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Nirvana", new List<int>{ 10, 8, 6 });
bandasRegistradas.Add("Beatles", new List<int>());



void ExibirLogo()
{
    Console.WriteLine(@"
        
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}
void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");
    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumber = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumber)
    {
        case 1:RegistrarBanda();
            break;
        case 2:ShowBands();
            break;
        case 3:AvaliarUmaBanda();
            break;
        case 4: mediaBanda();
            break;
        case -1:
            Console.WriteLine("Até mais :)");
            break;
        default: Console.WriteLine("Opção invalida");
            break;
    }
    void RegistrarBanda()
    {
        Console.Clear();
        ExibirTituloOpcao("Registro das bandas: ");
        Console.Write("Digite o Nome da Banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso ");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenu();
    }
    void ShowBands()
    {
        Console.Clear();
        ExibirTituloOpcao("Exibindo todas as Bandas registradas: ");

        //for (int i = 0; i < BandList.Count; i++)
        //{
        //    Console.WriteLine($"Banda {BandList[i]} ");
        //}
        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
    void AvaliarUmaBanda()
    {
        //Digite qual banda deseja avaliar
        //Se a banda existir no dicionario >> atribuir uma nota
        //Se nao, volta ao menu principal.

        Console.Clear();
        ExibirTituloOpcao("Avalair Banda");
        Console.Write("Digite o nome da Banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
            int nota = int.Parse(Console.ReadLine()!);
            bandasRegistradas[nomeDaBanda].Add(nota);
            Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
            Thread.Sleep(4000);
            Console.Clear();
            ExibirMenu();   

        }
        else
        {
            Console.WriteLine($"\n A banda {nomeDaBanda} não foi encontrada");
            Console.WriteLine("Digite uma tecla para voltar para o menu principal.");
            Console.ReadKey();
            Console.Clear();
            ExibirMenu();
        }
    }
    
    void mediaBanda()
    {
        Console.Clear();
        ExibirTituloOpcao("Verificar media de uma banda");
        Console.WriteLine("Digite o nome da banda que deseja avaliar");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            double mediaNota = bandasRegistradas[nomeDaBanda].Average();
            Console.WriteLine($"A nota media da banda {nomeDaBanda} é {mediaNota}");
        }else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada");
            Console.WriteLine("Aperte qualquer tecla para retornar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            ExibirMenu();
        }


    }
}

void ExibirTituloOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}
    
ExibirMenu();
