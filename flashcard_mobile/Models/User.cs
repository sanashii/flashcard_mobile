using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcard_mobile.Models
{
#nullable enable

    public class User
    {
        public int Id { get; set; }  // Non-nullable by default as it's a value type
        public string Name { get; set; } = string.Empty;  // Non-nullable string, initialized to empty
        public string Email { get; set; } = string.Empty;  // Non-nullable string, initialized to empty
        public string Password { get; set; } = string.Empty;  // Non-nullable string, initialized to empty
    }

}
