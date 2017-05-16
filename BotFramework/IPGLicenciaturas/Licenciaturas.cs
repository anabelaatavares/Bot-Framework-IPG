using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPGLicenciaturas
{
    public class Licenciaturas
    {
        private static Dictionary<string, int> Cursos;

        public Licenciaturas()
        {
            if (Cursos == null || Cursos.Count == 0)
                InitializeCursos();
        }

        private void InitializeCursos()
        {
            Cursos = new Dictionary<string, int>();
            Cursos.Add("Engenharia Informática", 1);
            Cursos.Add("Comunicação e Relações Públicas", 2);
            Cursos.Add("Comunicação Multimédia", 3);
            Cursos.Add("Contabilidade", 4);
            Cursos.Add("Design de Equipamento", 5);
            Cursos.Add("Desporto", 6);
            Cursos.Add("Educação Básica", 7);
            Cursos.Add("Energia e Ambiente", 8);
            Cursos.Add("Enfermagem", 9);
            Cursos.Add("Engenharia Civil", 10);
            Cursos.Add("Animação Sociocultural", 11);
            Cursos.Add("Engenharia Topográfica", 12);
            Cursos.Add("Gestão", 13);
            Cursos.Add("Gestão de Recursos Humanos", 14);
            Cursos.Add("Gestão Hoteleira", 15);
            Cursos.Add("Marketing", 16);
            Cursos.Add("Restauração e Catering", 17);
            Cursos.Add("Turismo e Lazer", 18);
            Cursos.Add("Fármacia", 19);
        }

        public string GetCursos()
        {
            var sorted = Cursos.OrderBy(p => p.Value);
            List<string> orderedCursos = new List<string>();
            foreach (var e in sorted)
            {
                orderedCursos.Add(e.Key);
            }

            string combindedString = string.Join(", ", orderedCursos);
            return combindedString;
        }

        public int GetCursoCount()
        {
            return Cursos.Count;
        }

        public void Reset()
        {
            try
            {
                InitializeCursos();
            }
            catch (Exception)
            {
                throw new CursoDataException();
            }
        }

        public bool DoesCursoExist(string name)
        {
            foreach (var key in Cursos.Keys)
            {
                if (key.ToLower().Equals(name.ToLower()))
                    return true;
            }
            return false;
        }

        public string GetHighestRatedCurso()
        {
            var sorted = Cursos.OrderBy(p => p.Value);
            return sorted.First().Key;
        }

        public string GetTopThreeCursos()
        {
            var sorted = Cursos.OrderBy(p => p.Value);
            List<string> rtns = new List<string>();
            rtns.Add(sorted.ElementAt(0).Key);
            rtns.Add(sorted.ElementAt(12).Key);
            rtns.Add(sorted.ElementAt(5).Key);

            string combindedString = string.Join(", ", rtns);
            return combindedString;
        }

        public string GetLowestRatedCurso()
        {
            var sorted = Cursos.OrderBy(p => p.Value);
            return sorted.Last().Key;
        }
    }
}
