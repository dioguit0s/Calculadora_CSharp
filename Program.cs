using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Program
    {
        
        static void Main()
        {
            //Aplicação de calculadora para realizar operações aritméticas
            //Definindo título um pouco mais enfeitado
            Console.WindowWidth= 150;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  ______      ___       __        ______  __    __   __           ___       _______    ______   .______           ___      \r\n /      |    /   \\     |  |      /      ||  |  |  | |  |         /   \\     |       \\  /  __  \\  |   _  \\         /   \\     \r\n|  ,----'   /  ^  \\    |  |     |  ,----'|  |  |  | |  |        /  ^  \\    |  .--.  ||  |  |  | |  |_)  |       /  ^  \\    \r\n|  |       /  /_\\  \\   |  |     |  |     |  |  |  | |  |       /  /_\\  \\   |  |  |  ||  |  |  | |      /       /  /_\\  \\   \r\n|  `----. /  _____  \\  |  `----.|  `----.|  `--'  | |  `----. /  _____  \\  |  '--'  ||  `--'  | |  |\\  \\----. /  _____  \\  \r\n \\______|/__/     \\__\\ |_______| \\______| \\______/  |_______|/__/     \\__\\ |_______/  \\______/  | _| `._____|/__/     \\__\\ \r\n                                                                                                                           ");
            Console.ForegroundColor= ConsoleColor.Gray;
            //chamando o código principal 
            CalculoPrincipal();

            //Método principal do código que cria um menu de calculadora e realiza as operações
            void CalculoPrincipal()
            {
                //Declarando variaveis
                double num1 = 0;
                double num2 = 0;
                double resultado = 0;
                int opcao;

                Console.WriteLine("Selecione a operação desejada:\n" +
                "1 - Adição\n" +
                "2 - Subtração\n" +
                "3 - Multiplicação\n" +
                "4 - Divisão\n" +
                "5 - Resto de divisão\n" +
                "0 - Sair");

                opcao = int.Parse(Console.ReadLine());

                //Verifica se a opção selecionada foi sair 
                if (opcao == 0)
                {
                    //chama o método que fecha a aplicação caso 
                    Fechar();
                }
                
                else if (opcao > 5) //Verifica se o número digitad foi maior que o esperado e repete a operação para o usuario tentar novamente
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Operação invalida, por favor pressione qualquer botão para tentar novamente");
                    Console.ForegroundColor= ConsoleColor.Gray;
                    Console.ReadKey();
                    Console.Clear();
                    CalculoPrincipal();
                }

                //Leitura dos números digitados pelo usuario
                try 
                {
                Console.WriteLine("Digite o primeiro número: ");
                num1 = double.Parse(Console.ReadLine());
                } catch (FormatException) 
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("O item digitado não foi um número, tente novamente");
                    Console.ForegroundColor= ConsoleColor.Gray;
                    Thread.Sleep(1000);
                    Console.Clear();
                    CalculoPrincipal();
                }

                try{
                Console.WriteLine("Digite o secundo número: ");
                num2 = double.Parse(Console.ReadLine());
                } catch (FormatException) 
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("O item digitado não foi um número, tente novamente");
                    Console.ForegroundColor= ConsoleColor.Gray;
                    Thread.Sleep(1000);
                    Console.Clear();
                    CalculoPrincipal();
                }
                
                //função switchcase para realização das operações
                switch (opcao)
                {
                    case 1:
                        resultado = num1 + num2;
                        break;

                    case 2:
                        resultado = num1 - num2;
                        break;

                    case 3:
                        resultado = num1 * num2;
                        break;

                    case 4:
                    try
                    {
                        resultado = num1 / num2;                       
                    }
                    catch (DivideByZeroException) //Essa exceção deveria evitar divisões por zero porém a linguagem reconhece divisões por zero como um número infinito
                                                  //então estará aqui apenas de enfeite pois usando numeros reais nunva irá dar um erro de divisão por 0
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Não é possivel dividir por zero, escolha outra operação");
                        Console.ForegroundColor= ConsoleColor.Gray;
                        Thread.Sleep(1000);
                        Console.Clear();
                        CalculoPrincipal();

                    }
                    break;

                    case 5:
                        resultado = num1 % num2;
                        break;                 
                }

                Console.WriteLine($"Seu resultado é {resultado}");

                //método que verifica se o usuario deseja realizar outro calculo
                 void Repetir()
                {
                    int repeticao = 0;

                    try {
                    Console.WriteLine("Deseja realizar outro cálculo?\n" + "Digite 1 para sim e 2 para não");
                    repeticao = int.Parse(Console.ReadLine());
                    } catch (FormatException) 
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("O item digitado não foi um número, tente novamente");
                    Console.ForegroundColor= ConsoleColor.Gray;
                    Thread.Sleep(1000);
                    Console.Clear();
                    Repetir();
                }
                    if (repeticao == 1)
                    {
                        //limpa o console e cria novamente o menu principal
                        Console.Clear();
                        CalculoPrincipal();
                    }
                    else if (repeticao == 2) Fechar();
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Comando inválido, fechando aplicação");
                        Console.ForegroundColor= ConsoleColor.Gray;
                        Fechar();
                    }

                }

                //método que agradece o usuario pelo uso e fecha a aplicação
                 void Fechar()
                {
                    Console.WriteLine("Agradecemos por usar nossa calculadora, nos vemos em uma próxima vez :)\n" +
                        "Pressione qualquer tecla para sair");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Repetir();
            }            
        }
    }
}
