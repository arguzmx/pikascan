using PikaScan.Modelo;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.IO;
using System.Reflection;

namespace PikaScan.Servicios.Repositorio
{
    public class DatabaseContext : DbContext
    {

        private static string GetDBPath()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(assemblyPath, "DB", "acapture.db");
        }

        //public DatabaseContext() :
        //    base(new SQLiteConnection()
        //    {
        //        ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = DatabaseContext.GetDBPath(), ForeignKeys = true }.ConnectionString
        //    }, true)
        //{


        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        // public DbSet<Config> AppConfiguration { get; set; }
        //public DbSet<OutputProcess> OutputProcesses { get; set; }
        //public DbSet<BatchOutputProcess> BatchOutputProcesses { get; set; }
        //public DbSet<PluginDefault> PluginDefaults { get; set; }
    }
}
