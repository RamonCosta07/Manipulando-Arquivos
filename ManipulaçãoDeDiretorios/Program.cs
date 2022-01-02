using ManipulaçãoDeDiretorios.Helper;
using System;
using System.IO;
using System.Collections.Generic;

namespace ManipulaçãoDeDiretorios
{
    class Program
    {
        static void Main(string[] args)
        {
            var caminho = "C:\\TrabalhandoComArquivos";
            FileHelper helper = new FileHelper();
            Console.WriteLine("Listando diretórios: ");
            helper.ListarDiretorios(caminho); // irá printar todos os diretórios do caminho
            Console.WriteLine("\nListando Arquivos dos diretórios: ");
            helper.ListarArquivosDiretorios(caminho);
            Console.WriteLine("\nCriando um Diretório: ");
            /*O path.combine irá criar/combinar três caminhos
             *O endereço de "caminho", / Pasta Teste 3 / SubPastaTeste 3
             *De forma que não precisemos nos preocupar com colocarmos
             *\\ quando quisermos chegar até determinado diretório
             */
            var diretorioNovo = Path.Combine(caminho, "Pasta teste 3", "SubPastaTeste3");
            helper.CriarDiretorio(diretorioNovo);

            //Console.WriteLine("\nApagando um Diretório e seus arquivos... ");
            //helper.ApagarDiretorio(Path.Combine(caminho, "Pasta teste 2"), true);

            var caminhoArquivo = Path.Combine(caminho, "arquivo-teste.txt");
            Console.WriteLine("\nCriando um arquivo texto: ");
            helper.CriarArquivoTexto(caminhoArquivo, "Testando escrita no arquivo novo");

            var listaString = new List<string> { "Linha 1", "Linha 2", "Linha 3" };
            Console.WriteLine("\nCriando um arquivo texto com stream: ");
            helper.criarArquivoTextoStream(caminhoArquivo, listaString);

            var listaStringContinuacao = new List<string> { "Linha 4", "Linha 5", "Linha 6" };
            Console.WriteLine("\nAdicionandno novas linhas a um arquivo sem apagar seu conteúdo anterior: ");
            helper.adicionarTextoStream(caminhoArquivo, listaStringContinuacao);

            Console.WriteLine("\nLendo o conteúdo do arquivo por Stream: ");
            helper.lerArquivoStream(caminhoArquivo);
            Console.WriteLine();

            //Console.WriteLine("Movendo um arquivo: ");
            //var novoCaminhoArquivo = Path.Combine(caminho, "Pasta Teste 1", "arquivo -teste.txt");
            //helper.moverArquivo(caminhoArquivo, novoCaminhoArquivo, false);
            Console.WriteLine("Copiando um arquivo: ");
            var caminhoArquivoTeste = Path.Combine(caminho, "arquivo-teste.txt");
            var caminhoArquivoTesteCopia = Path.Combine(caminho, "arquivo-teste-backup.txt");
            helper.copiarArquivo(caminhoArquivoTeste, caminhoArquivoTesteCopia, true); // poderá sobrescrever

            Console.WriteLine("\nDeletando um arquivo: ");
            helper.deletarArquivo(caminhoArquivoTesteCopia);
        }
    }
}
