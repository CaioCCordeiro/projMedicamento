using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMedicamento
{
    class Program
    {
        private Medicamentos med = new Medicamentos();
        static void Main(string[] args)
        {
            Program program = new Program();
            int index = 0;

            do
            {
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético: informar dados)");
                Console.WriteLine("3. Consultar medicamento (analítico: informar dados + lotes)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento (abater do lote mais antigo) ");
                Console.WriteLine("6. Listar medicamentos (informando dados sintéticos)");

                Console.Write("Insira a opção escolhida: ");
                index = int.Parse(Console.ReadLine());

                switch (index)
                {
                    case 0: break;
                    case 1: program.cadastrar(); break;
                    case 2:
                    case 3: program.consultar(index); break;
                    case 4: program.comprar(); break;
                    case 5: program.vender(); break;
                    case 6: program.listar(); break;
                    default: Console.WriteLine("Opção inválida"); break;
                }
            } while (index != 0);

        }

        public void cadastrar()
        {
            Medicamento cad = new Medicamento();
            int id;
            string nome, laboratorio;
            bool loop = false;
            Console.WriteLine("-----CADASTRAR-----");
            do
            {
                Console.Write("ID: ");
                id = int.Parse(Console.ReadLine());
                cad.Id = id;
                if (this.med.pesquisar(cad).Id == id)
                {
                    Console.WriteLine("ERRO! ID já cadastrado");
                    loop = true;
                }
                else
                    loop = false;
            } while (loop);
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("Laboratório: ");
            laboratorio = Console.ReadLine();

            Medicamento novo = new Medicamento(id, nome, laboratorio);

            this.med.adicionar(novo);

            Console.WriteLine("------------------------");
        }

        public void consultar(int option)
        {
            Medicamento cons = new Medicamento();
            Console.WriteLine("-----CONSULTAR-----");
            Console.Write("ID: ");
            cons.Id = int.Parse(Console.ReadLine());

            cons = this.med.pesquisar(cons);

            if (cons.Id != 0)
            {
                Console.WriteLine(cons.toString());

                if(option == 3)
                {
                    foreach(Lote l in cons.Lotes)
                    {
                        Console.WriteLine(l.toString());
                    }
                }
            }
            else
                Console.WriteLine("Medicamento não encontrado");

            Console.WriteLine("------------------------");
        }

        public void comprar()
        {
            Medicamento cons = new Medicamento();
            Console.WriteLine("-----COMPRAR-----");
            Console.Write("ID: ");
            cons.Id = int.Parse(Console.ReadLine());

            if (cons.Id != 0)
            {
                int id, qtde;
                DateTime venc = DateTime.MinValue;
                Boolean loop = false;
                Console.Write("ID do Lote: ");
                id = int.Parse(Console.ReadLine());
                Console.Write("Quantidade: ");
                qtde = int.Parse(Console.ReadLine());

                while (!loop)
                {
                    try
                    {
                        Console.Write("Data de Vencimento(dia/mês/ano): ");
                        venc = DateTime.Parse(Console.ReadLine());
                        loop = true;
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine("Formato de data inválido");
                    }
                }
                

                Lote novo = new Lote(id, qtde, venc);

                this.med.pesquisar(cons).comprar(novo);
            }
            else
                Console.WriteLine("Medicamento não encontrado");

            Console.WriteLine("------------------------");
        }

        public void vender()
        {
            int qtde = 0;
            Medicamento cons = new Medicamento();
            Console.WriteLine("-----VENDER-----");
            Console.Write("ID: ");
            cons.Id = int.Parse(Console.ReadLine());

            if (cons.Id != 0)
            {
                Console.Write("Quantidade: ");
                qtde = int.Parse(Console.ReadLine());
                if (this.med.pesquisar(cons).vender(qtde))
                    Console.WriteLine("Compra realizada com sucesso");
                else
                    Console.WriteLine("Quantidade acima do disponível");
                
            }
            else
                Console.WriteLine("Medicamento não encontrado");

            Console.WriteLine("------------------------");
        }

        public void listar()
        {
            foreach(Medicamento m in this.med.ListaMedicamentos)
            {
                Console.WriteLine(m.toString());
            }

            Console.WriteLine("------------------------");
        }
    }
}
