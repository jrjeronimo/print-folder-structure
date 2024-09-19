using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o caminho da pasta raiz:");
        string rootPath = Console.ReadLine();
        
        Console.WriteLine("Deseja incluir os arquivos na listagem? (s/n):");
        bool includeFiles = Console.ReadLine()?.Trim().ToLower() == "s";

        if (Directory.Exists(rootPath))
        {
            PrintDirectoryStructure(rootPath, includeFiles);
        }
        else
        {
            Console.WriteLine("O caminho informado não existe.");
        }
    }

    static void PrintDirectoryStructure(string path, bool includeFiles, string indent = "")
    {
        Console.WriteLine($"{indent}|--{Path.GetFileName(path)}");

        indent += "  ";

        foreach (string dir in Directory.GetDirectories(path))
        {
            PrintDirectoryStructure(dir, includeFiles, indent);
        }

        if (includeFiles)
        {
            foreach (string file in Directory.GetFiles(path))
            {
                Console.WriteLine($"{indent}{Path.GetFileName(file)}");
            }
        }
    }
}
