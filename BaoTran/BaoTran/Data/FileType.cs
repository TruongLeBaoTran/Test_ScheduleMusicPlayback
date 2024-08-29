using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoTran.Data
{
    public class FileType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFileType { get; set; }
        public string Name { get; set; }
        public ICollection<MediaFile> MediaFiles { get; set; } = new List<MediaFile>();
    }
}
