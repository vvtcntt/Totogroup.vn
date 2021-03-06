using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace TOTOGROUP.Models.Mapping
{
    public class tblConnectBaogiaMap : EntityTypeConfiguration<tblConnectBaogia>
    {
        public tblConnectBaogiaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblConnectBaogia");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idCate).HasColumnName("idCate");
            this.Property(t => t.idBG).HasColumnName("idBG");
        }
    }
}
