using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IngeneosTest.Core.Model
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public int IdBook { get; set; }
        [ForeignKey(nameof(IdBook))]
        public Book Book { get; set; }
    }
}
