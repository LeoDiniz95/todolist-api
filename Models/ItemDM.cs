using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using todolist_api.General;

namespace todolist_api.Models
{
    [Table("todolist")]
    public class ItemDM
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = Messages.Errors.required)]
        [MinLength(3, ErrorMessage = Messages.Errors.length)]
        public string name { get; set; }

        [Required(ErrorMessage = Messages.Errors.required)]
        public decimal done { get; set; }

        [Required(ErrorMessage = Messages.Errors.required)]
        [StringLength(1)]
        public string status { get; set; }
    }
}
