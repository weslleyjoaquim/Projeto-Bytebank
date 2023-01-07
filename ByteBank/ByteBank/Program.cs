using System.Globalization;
using System.Runtime.Serialization;

namespace ByteBank
{
    public class Program
    {
        //Criando o menu principal do programa
        static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("========== BEM VINDO AO BYTEBANK ===========");
            Console.WriteLine("============================================");
            Console.WriteLine("     Escolha uma operação");
            Console.WriteLine("     1 - Cadastrar nova conta");
            Console.WriteLine("     2 - Excluir conta");
            Console.WriteLine("     3 - Listas as contas cadastradas");
            Console.WriteLine("     4 - Fazer login");
            Console.WriteLine("     0 - Sair");
            Console.WriteLine("============================================");
            Console.WriteLine("============================================");
        }
        //Submenu - operações da conta
        static void SubMenuMovimentarConta()
        {
            
            Console.WriteLine("============================================");
            Console.WriteLine("============================================");
            Console.WriteLine("     1 - Sacar");
            Console.WriteLine("     2 - Depositar");
            Console.WriteLine("     3 - Transferir");
            Console.WriteLine("     0 - Logout");
            Console.WriteLine("============================================");
            Console.WriteLine("============================================");
            
        }

        //Metodo para realizar o primeiro cadastro
        static void CadastrarConta(List<string>nome, List<string>cpf,List<string>senha, List<double>saldo, List<int>numeroDaConta)
        {
            Random contaRandom = new Random(10);
            numeroDaConta.Add(contaRandom.Next());

            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("============ CADASTRE SUA CONTA ============");
            Console.WriteLine("============================================");
            Console.WriteLine("     Digite o seu nome completo: ");
            nome.Add(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("     Digite o seu CPF: ");
            cpf.Add(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("     Cadastre a sua senha de 6 digitos: ");
            senha.Add(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("     Insira o valor do seu depósito inicial");
            saldo.Add(double.Parse(Console.ReadLine()));
            Console.WriteLine("============================================");
            Console.WriteLine("============================================");
            Console.Clear();
        }

        //Metodo para exclusão de contas
        static void ExcluirContaCadastrada(List<string> nome, List<string> cpf, List<string> senha, List<double> saldo)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("========== EXCLUSÃO DE CADASTROS ===========");
            Console.WriteLine("============================================");
            Console.WriteLine("     Digite o CPF do titular da conta que deseja encerrar");
            
            int indexParaDeletar;
            string titularParaDeletar;

            do
                
            {
                titularParaDeletar = Console.ReadLine();
                indexParaDeletar = cpf.FindIndex(cpf => cpf == titularParaDeletar);

                if (indexParaDeletar == -1)
                {
                    Console.WriteLine("============================================");
                    Console.WriteLine("     Conta não encontrada na base de dados");
                    Console.WriteLine("============================================");
                    Console.WriteLine("============================================");
                    Console.WriteLine("     Aperte a tecla enter para digitar novamente");
                    Console.ReadKey();
                }
            } while (indexParaDeletar == -1);

            cpf.Remove(titularParaDeletar);
            nome.RemoveAt(indexParaDeletar);
            senha.RemoveAt(indexParaDeletar);
            saldo.RemoveAt(indexParaDeletar);
            Console.WriteLine("============================================");
            Console.WriteLine("     Conta excluida com sucesso");
            Console.WriteLine("============================================");
            Console.WriteLine("============================================");
            Console.WriteLine("     Aperte a tecla enter");
            Console.ReadKey();
            Console.Clear();
        }
        //Metodo para listar as contas salvas
        static void ListarContadasCadastradas(List<string> cpf, List<string>nome, List<double>saldo, List<int>numeroDaConta)
        {
            for (int i = 0; i < cpf.Count; i++)
            {
                
                Console.WriteLine("============================================");
                Console.WriteLine("============ CONTA CADASTRADA ============");
                Console.WriteLine("============================================");
                Console.WriteLine($"        {i} - Nome: {nome[i]} - CPF: {cpf[i]} - Conta: {numeroDaConta[i]} - Saldo: R$ {saldo[i]:F2}");
                Console.WriteLine("============================================");
                Console.WriteLine("     Aperte a tecla enter");
                Console.ReadKey();
                
            }
        }

        //Metodo para logar na conta e realizar as operações
        static void LogarNaConta(List<string> cpf, List<string> senha, List<string>nome,List<double>saldo)

        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("=================== LOGIN ==================");
            Console.WriteLine("============================================");
            Console.WriteLine("");
            Console.WriteLine("     Digite o seu CPF");
            string cpfDigitado = Console.ReadLine();
            int indexAutenticarCPF = cpf.FindIndex(cpf => cpf == cpfDigitado);
            Console.WriteLine("     Digite a sua senha");
            string senhaDigitada = Console.ReadLine();
            int indexAutenticarSenha = senha.FindIndex(senha => senha == senhaDigitada);

            if(indexAutenticarCPF == -1 && indexAutenticarSenha == -1)
            {
                Console.WriteLine("     Dados inválidos");
            }
            else
            {
                int opcao;
                do
                {
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("================= BEM VINDO ================");
                    Console.WriteLine("============================================");
                    Console.WriteLine("     Login realizado com sucesso");
                    Console.WriteLine($"        Saldo: R$ {saldo[indexAutenticarCPF]:F2}");
                                    
                    SubMenuMovimentarConta();
                    Console.WriteLine("     Escolha uma opção");
                    opcao = int.Parse(Console.ReadLine());
                    
                    //Condição para realizar um saque

                    if (opcao == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("============================================");
                        Console.WriteLine("============================================");
                        Console.WriteLine("     Digite o valor que deseja sacar: ");
                        double valor = double.Parse(Console.ReadLine());
                        if (saldo[indexAutenticarCPF] < valor)
                        {
                            Console.WriteLine("============================================");
                            Console.WriteLine($"     Saldo insuficiente! Saldo: R$ {saldo[indexAutenticarCPF]}");
                            Console.WriteLine("============================================");
                            Console.WriteLine("     Aperte a tecla enter");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            saldo[indexAutenticarCPF] -= valor;
                            Console.WriteLine("============================================");
                            Console.WriteLine($"        Saldo atual: R$ {saldo[indexAutenticarCPF]}");
                            Console.WriteLine("============================================");
                            Console.WriteLine("     Aperte a tecla enter");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                    //Condição para depositar

                    else if (opcao == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("============================================");
                        Console.WriteLine("============================================");
                        Console.WriteLine("     Digite o valor que deseja depositar: ");
                        double valor = double.Parse(Console.ReadLine());
                        saldo[indexAutenticarCPF] += valor;
                        Console.WriteLine("============================================");
                        Console.WriteLine($"        Saldo atual: R$ {saldo[indexAutenticarCPF]}");
                        Console.WriteLine("============================================");
                        Console.WriteLine("     Aperte a tecla enter");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    //Condição para transferir

                    else if (opcao == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("============================================");
                        Console.WriteLine("============================================");
                        Console.WriteLine("     Digite o valor que deseja transferir: ");
                        double valor = double.Parse(Console.ReadLine());
                        Console.WriteLine("     Digite o CPF do Favorecido");
                        string cpfFavorecido = Console.ReadLine();
                        int indexTransfer = cpf.FindIndex(cpf => cpf == cpfFavorecido);

                        if (indexTransfer == -1)
                        {
                            Console.WriteLine("     CPF não localizado");
                        }
                        saldo[indexTransfer] += valor;
                        saldo[indexAutenticarCPF] -= valor;

                        Console.WriteLine("============================================");
                        Console.WriteLine("============================================");
                        Console.WriteLine($"Transferência realizada com sucesso para: {nome[indexTransfer]}");
                        Console.WriteLine($"Saldo Atual: {saldo[indexAutenticarCPF]}");
                        Console.WriteLine("============================================");
                        Console.WriteLine("============================================");
                        Console.WriteLine("     Aperte a tecla enter");
                        Console.ReadKey();
                        Console.Clear();
                    }
                } while (opcao != 0);
                
            }

        }
       
        public static void Main(string[] args)
        {
            List<string> nome = new List<string>();
            List<string> cpf = new List<string>();
            List<string> senha = new List<string>();
            List<double> saldo = new List<double>();
            List<int> numeroDaConta = new List<int>();



            int opcao;
            do
            {
                MenuPrincipal();
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        CadastrarConta(nome, cpf, senha, saldo,numeroDaConta);
                        break;
                    case 2:
                        ExcluirContaCadastrada(nome, cpf, senha, saldo);
                        break;
                    case 3:
                        ListarContadasCadastradas(nome, cpf, saldo, numeroDaConta);
                        break;
                    case 4:
                        LogarNaConta(cpf, senha,nome,saldo);
                        break;
                }

            }while(opcao !=0);
        }
    }
}