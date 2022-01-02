using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulaçãoDeDiretorios.Helper
{
    class FileHelper
    {
        public void ListarDiretorios(string caminho)
        {
            /* SearchOption.AllDirectories irá buscar os diretórios recursivamente
             * passando por todas as pastas, e depois todas as pastas dentro
             * daquela pasta etc
             */
            var retornoCaminho = Directory.GetDirectories(caminho, "*", SearchOption.AllDirectories); // * é = todos os arquivos
            foreach (var retorno in retornoCaminho)
            {
                Console.WriteLine(retorno);
            }
        }

        public void ListarArquivosDiretorios(string caminho)
        {
            var retornoArquivos = Directory.GetFiles(caminho, "*.txt", SearchOption.AllDirectories); // traz apenas arquivos .txt
            var retornoArquivos2 = Directory.GetFiles(caminho, "*2.png", SearchOption.AllDirectories);
            // traz apenas arquivos que tenham 2 no nome e terminem com .png

            foreach (var retorno in retornoArquivos)
            {
                Console.WriteLine(retorno);
            }

            Console.WriteLine();
            foreach (var retorno in retornoArquivos2)
            {
                Console.WriteLine(retorno);
            }

        }
        
        public void CriarDiretorio(string caminho)
        {
            var retorno = Directory.CreateDirectory(caminho);
            Console.WriteLine(retorno.FullName); // irá imprimir o nome completo do diretório
        }

        public void ApagarDiretorio(string caminho, bool apagarArquivos)
        {
            Directory.Delete(caminho, apagarArquivos); // Se apagarArquivos = true, então irá apagar tudo do diretório
            // incluindo arquivos. Sem ele, caso exista algum arquivo no diretório, não será possível ser deletado
        }

        public void CriarArquivoTexto(string caminho, string conteudo)
        {
            /* A fim de evitar que sobrescrevemos um arquivo já existente
             * fazemos uma verificação antes se o arquivo já existe. Do
             * contrário caso ele já exista, e já possua algo dentro do
             * arquivo, tais dados serão perdidos e sobrescritos
             */
            if (!File.Exists(caminho))
            {
                File.WriteAllText(caminho, conteudo);
            }
            
        }

        /* Stream é mais ideal para ser utilizado em
         * arquivos grandes. Tanto para a escrita
         * quanto para a leitura
         */
        public void criarArquivoTextoStream(string caminho, List<string> conteudo)
        {
            /* Using garante que o processo de stream seja
             * finalizado para liberar o arquivo para que
             * outro processo possa usar. Ou seja, o using
             * é responsável por terminar essa stream
             */
            using (var stream = File.CreateText(caminho))
            {
                foreach (var linha in conteudo)
                {
                    stream.WriteLine(linha);
                }
            }
        }
        
        public void adicionarTexto(string caminho, string conteudo)
        {
            File.AppendAllText(caminho, conteudo); // Irá adicionar conteúdo, sem sobrescrever
        }

        public void adicionarTextoStream(string caminho, List<string> conteudo)
        {
            using (var stream = File.AppendText(caminho))
            {
                foreach (var linha in conteudo)
                {
                    stream.WriteLine(linha);
                }
            }
        }

        public void lerArquivo(string caminho)
        {
            var conteudo = File.ReadAllLines(caminho);
            foreach(var linha in conteudo)
            {
                Console.WriteLine(linha);
            }
        }

        public void lerArquivoStream(string caminho)
        {
            string linha = string.Empty;
            using (var stream = File.OpenText(caminho))
            {
                while((linha = stream.ReadLine()) != null) // irá percorrer linha a linha, até não ter mais linha para ler
                {
                    Console.WriteLine(linha);
                }
            }
        }

        public void moverArquivo (string caminho, string novoCaminho, bool sobrescrever)
        {
            File.Move(caminho, novoCaminho, sobrescrever); // Podendo, opcionalmente, mudar o nome do arquivo na hora de movê-lo
        }

        public void copiarArquivo (string caminho, string novoCaminho, bool sobrescrever)
        {
            File.Copy(caminho, novoCaminho, sobrescrever); // Por padrão não podemos copiar para uma mesma pasta com um
                                                                // mesmo nome
            // Porém, com sobrecarga, caso coloquemos true como 3° parametro, será possível sobrescrever
        }

        public void deletarArquivo(string caminho)
        {
            File.Delete(caminho);
        }
    }
}
