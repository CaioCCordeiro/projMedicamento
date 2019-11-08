using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMedicamento
{
    class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Laboratorio { get => laboratorio; set => laboratorio = value; }
        internal Queue<Lote> Lotes { get => lotes; set => lotes = value; }

        public Medicamento()
        {
            Lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            Lotes = new Queue<Lote>();
        }

        public int qtdeDisponivel()
        {
            int qt = 0;

            foreach (Lote a in lotes)
            {
                qt += a.Qtde;
            }

            return qt;
        }

        public void comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool vender(int qtde)
        {
            if(qtde <= qtdeDisponivel())
            {
                for(int i = qtde; i > 0; i--)
                {
                    lotes.Peek().Qtde--;

                    if (lotes.Peek().Qtde == 0)
                    {
                        lotes.Dequeue();
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public string toString()
        {
            return id + "-" + nome + "-" + laboratorio + "-" + qtdeDisponivel();
        }

        public override bool Equals(object obj)
        {
            return obj is Medicamento medicamento &&
                   id == medicamento.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }
    }
}
