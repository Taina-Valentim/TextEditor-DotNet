using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        public static void Main (string[] args){
            Menu();
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("O que vocêdeseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short opcao = short.Parse(Console.ReadLine());
            switch(opcao){
            case 0:
                System.Environment.Exit(0);
                break;
            case 1:
                Abrir();
                break;
            case 2:
                Editar();
                break;
            default:
                Menu();
                break;
            }
        }

        static void Abrir(){
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo que deseja abrir?");
            var path = Console.ReadLine();
            using(var file = new StreamReader(path)){
            string texto = file.ReadToEnd();
            Console.WriteLine(texto);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar(){
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (Pressione ESC para sair do editor)");
            Console.WriteLine("-----------------------------------------------------------");
            string texto = "";
            do{
            texto += Console.ReadLine();
            texto += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);
            Salvar(texto);
        }

        static void Salvar(string texto){
            Console.Clear();
            Console.WriteLine("Qual o caminho que deseja salvar?");
            string path = Console.ReadLine();
            using (var file = new StreamWriter(path)){
            file.Write(texto);
            }
            Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}