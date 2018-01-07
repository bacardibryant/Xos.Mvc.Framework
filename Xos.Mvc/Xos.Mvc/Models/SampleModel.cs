using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xos.Mvc.Framework.Models;

namespace Xos.Mvc.Models
{
    public class SampleModel : BaseModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ItemName { get; set; }
    }
}