using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CurriculoFrancisco.Models;

namespace CurriculoFrancisco.Models
{
    public class CurriculoFranciscoContext : DbContext
    {
        public CurriculoFranciscoContext (DbContextOptions<CurriculoFranciscoContext> options)
            : base(options)
        {
        }

        public DbSet<CurriculoFrancisco.Models.DadosPessoais> DadosPessoais { get; set; }

        public DbSet<CurriculoFrancisco.Models.InformacaoAdicional> InformacaoAdicional { get; set; }

        public DbSet<CurriculoFrancisco.Models.verCurriculo> verCurriculo { get; set; }
    }
}
