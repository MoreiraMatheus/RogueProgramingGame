using System;

class RogueProgramingGame {
    static void Main() {
        string nome;

        while (true) {
            int menu;
            Console.Write("1 - Novo Jogo\n2 - Carregar\n3 - Sair\nSelecione uma opção: ");
            menu = int.Parse(Console.ReadLine());

            if (menu == 1) {
                Console.Write("Digite seu nome: ");
                nome = Console.ReadLine();
                Console.WriteLine($"Muito prazer {nome}, vamos começar nossa aventura");
                break;
            }
            else if (menu == 2) {
                Console.WriteLine("Nada por aqui ainda");
                break;
            }
            else {
                break;
            }   
        }
    }
}