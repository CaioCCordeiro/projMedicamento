using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMedicamento
{
    class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        internal List<Medicamento> ListaMedicamentos { get => listaMedicamentos; set => listaMedicamentos = value; }

        public Medicamentos()
        {
            ListaMedicamentos = new List<Medicamento>();
        }

        public void adicionar(Medicamento medicamento)
        {
            this.listaMedicamentos.Add(medicamento);
        }

        public bool deletar(Medicamento medicamento)
        {
            Medicamento pesquisa = pesquisar(medicamento);

            foreach(Medicamento m in this.listaMedicamentos)
            {
                if (m.Equals(pesquisa))
                {
                    if (m.qtdeDisponivel() == 0)
                    {
                        this.listaMedicamentos.RemoveAt(listaMedicamentos.IndexOf(m));
                        return true;
                    }
                    else
                        return false;
                }
            }

            return false;
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            Medicamento vazio = new Medicamento();

            foreach(Medicamento m in this.listaMedicamentos)
            {
                if (m.Equals(medicamento))
                {
                    return m;
                }
            }

            return vazio;
        }
    }
}
