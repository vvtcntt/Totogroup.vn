using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace TOTOGROUP.Models.Mapping
{
    public class tblConnectNewMap : EntityTypeConfiguration<tblConnectNew>
    {
        public tblConnectNewMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblConnectNews");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idNew).HasColumnName("idNew");
            this.Property(t => t.idCate).HasColumnName("idCate");
        }
    }
}
