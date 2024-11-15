using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Models;
using System;

namespace SysGeSeApp2024.Data
{
    public class SysGeseDbContext : DbContext
    {
        public SysGeseDbContext(DbContextOptions<SysGeseDbContext> options) : base(options) { }

        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Unidade> Unidades { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<FiltroModel> Filtros { get; set; }

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<SociosV2Model> Socios2 { get; set; }

        public DbSet<UsuarioFiltroEmpresas> UsuariosFiltrosEmpresas { get; set; }

        public DbSet<SociosModel> Socios { get; set; }

        public DbSet<EmpresaModel> Empresas { get; set; }

        public DbSet<Tabela> Tabelas { get; set; }
        public DbSet<Acesso> Acessos { get; set; }

        public DbSet<Servidor> Servidores { get; set; }
    }
}
